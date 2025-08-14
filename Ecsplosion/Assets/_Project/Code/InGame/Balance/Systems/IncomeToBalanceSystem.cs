using System.Linq;
using Inaunius.Ecsplosion.Configs;
using Inaunius.Ecsplosion.InGame.Balance.Components;
using Inaunius.Ecsplosion.InGame.Business.Components;
using Inaunius.Ecsplosion.InGame.Shared.Components;
using Inaunius.Ecsplosion.Static;
using Leopotam.EcsLite;

namespace Inaunius.Ecsplosion.InGame.Balance.Systems
{
    public class IncomeToBalanceSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly InGameCfg _config;

        private EcsWorld _world;

        private EcsFilter _incomeSourceFilter;

        private EcsFilter _balanceFilter;

        public IncomeToBalanceSystem(InGameCfg config) => _config = config;

        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            _incomeSourceFilter = _world.Filter<IncomeSourceTag>().Inc<BusinessInfo>().End();
            _balanceFilter = _world.Filter<CurrentBalance>().End();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _incomeSourceFilter)
            {
                var businessConfig = _config.BusinessConfigs.AsDictionary[_world.GetPool<BusinessInfo>().Get(entity).Id];
                int businessLvl = _world.GetPool<DevelopmentLvl>().Get(entity).Value;

                var upgradesPercents = businessConfig.Config.Upgrades
                    .Select(upgradeId => _config.UpgradesConfigs.AsDictionary[upgradeId].IncomeMultiplierPercent)
                    .ToArray();

                float income = InGameCalculations.CalculateIncome(businessLvl, businessConfig.Config.BaseIncome, upgradesPercents);
                _world.GetPool<CurrentBalance>().Get(_balanceFilter.GetSingle()).Value += income;
            }
        }
    }
}