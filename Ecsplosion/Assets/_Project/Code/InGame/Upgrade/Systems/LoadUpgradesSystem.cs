using Inaunius.Ecsplosion.Configs;
using Inaunius.Ecsplosion.InGame.Shared.Components;
using Inaunius.Ecsplosion.InGame.Upgrade.Components;
using Leopotam.EcsLite;

namespace Inaunius.Ecsplosion.InGame.Upgrade
{
    public class LoadUpgradesSystem : IEcsInitSystem
    {
        private readonly InGameCfg _config;

        private EcsWorld _ecsWorld;

        public LoadUpgradesSystem(InGameCfg config)
        {
            _config = config;
        }

        public void Init(IEcsSystems systems)
        {
            _ecsWorld = systems.GetWorld();

            var upgradeInfoPool = _ecsWorld.GetPool<UpgradeInfo>();
            var incomeMultiplier = _ecsWorld.GetPool<IncomeMultiplier>();
            var improvementPool =_ecsWorld.GetPool<Improvement>();
            var developmentLevelPool = _ecsWorld.GetPool<DevelopmentLvl>();

            foreach (var upgradeConfig in _config.UpgradesConfigs)
            {
                int entity = _ecsWorld.NewEntity();
                InitializeBusinesses(upgradeInfoPool, incomeMultiplier, improvementPool, developmentLevelPool, upgradeConfig, entity);
            }
        }

        private static void InitializeBusinesses(
            EcsPool<UpgradeInfo> upgradeInfo,
            EcsPool<IncomeMultiplier> incomeMultiplier,
            EcsPool<Improvement> improvementPool,
            EcsPool<DevelopmentLvl> developmentLevelPool,
            BusinessUpgradeCfg upgradeConfig,
            int entity
        )
        {
            const int DefaultLvl = 0;

            upgradeInfo.Add(entity) = new UpgradeInfo { Id = upgradeConfig.Id };
            incomeMultiplier.Add(entity) = new IncomeMultiplier { ValuePercent = upgradeConfig.IncomeMultiplierPercent };
            improvementPool.Add(entity) = new Improvement { Cost = upgradeConfig.Cost };
            developmentLevelPool.Add(entity) = new DevelopmentLvl { Value = DefaultLvl };
        }
    }
}