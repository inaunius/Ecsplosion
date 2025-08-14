using System.Collections.Generic;
using System.Linq;
using Inaunius.Ecsplosion.Configs;
using Inaunius.Ecsplosion.Ecs.InGame.Balance.Components;
using Inaunius.Ecsplosion.Ecs.InGame.Business.Components;
using Inaunius.Ecsplosion.Ecs.InGame.Shared.Components;
using Inaunius.Ecsplosion.Ecs.InGame.Upgrade.Components;
using Inaunius.Ecsplosion.Static;
using Inaunius.Ecsplosion.Static.Enums;
using Leopotam.EcsLite;

namespace Inaunius.Ecsplosion.Ecs.InGame.Balance.Systems
{
    public class IncomeToBalanceSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly InGameCfg _config;

        private EcsWorld _world;

        private EcsFilter _incomeSourceFilter;

        private EcsFilter _balanceFilter;

        private EcsFilter _upgradesFilter;

        public IncomeToBalanceSystem(InGameCfg config) => _config = config;

        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            _incomeSourceFilter = _world.Filter<IncomeSourceTag>().Inc<BusinessInfo>().End();
            _balanceFilter = _world.Filter<CurrentBalance>().End();
            _upgradesFilter = _world.Filter<UpgradeInfo>().End();
        }

        public void Run(IEcsSystems systems)
        {
            var boughtUpgrades = new List<UpgradeId>();
            if (_incomeSourceFilter.GetEntitiesCount() != 0)
            {
                foreach (var entity in _upgradesFilter)
                {
                    if (_world.GetPool<DevelopmentLvl>().Get(entity).Value > 0)
                    {
                        boughtUpgrades.Add(_world.GetPool<UpgradeInfo>().Get(entity).Id);
                    }
                }
            }

            foreach (var entity in _incomeSourceFilter)
            {
                var businessConfig = _config.BusinessConfigs.AsDictionary[_world.GetPool<BusinessInfo>().Get(entity).Id];
                int businessLvl = _world.GetPool<DevelopmentLvl>().Get(entity).Value;
                var upgradesPercents = new UpgradeId[] { businessConfig.Config.Upgrade1, businessConfig.Config.Upgrade2 }
                    .Where(upgradeId => boughtUpgrades.Contains(upgradeId))
                    .Select(upgradeId => _config.UpgradesConfigs.AsDictionary[upgradeId].IncomeMultiplierPercent)
                    .ToArray();
                
                float income = InGameCalculations.CalculateIncome(businessLvl, businessConfig.Config.BaseIncome, upgradesPercents);
                _world.GetPool<CurrentBalance>().Get(_balanceFilter.GetSingle()).Value += income;
                _world.GetPool<IncomeSourceTag>().Del(entity);
            }
        }
    }
}