using Inaunius.Ecsplosion.Configs;
using Inaunius.Ecsplosion.Ecs.InGame.Shared.Components;
using Inaunius.Ecsplosion.Ecs.InGame.Upgrade.Components;
using Leopotam.EcsLite;

namespace Inaunius.Ecsplosion.Ecs.InGame.Upgrade
{
    public class SpawnUpgradesSystem : IEcsInitSystem
    {
        private readonly InGameCfg _config;

        private EcsWorld _world;

        public SpawnUpgradesSystem(InGameCfg config)
        {
            _config = config;
        }

        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();

            var upgradeInfoPool = _world.GetPool<UpgradeInfo>();
            var incomeMultiplier = _world.GetPool<IncomeMultiplier>();
            var improvementPool =_world.GetPool<Improvement>();
            var developmentLevelPool = _world.GetPool<DevelopmentLvl>();

            foreach (var upgradeConfig in _config.UpgradesConfigs.AsDictionary.Values)
            {
                int entity = _world.NewEntity();
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