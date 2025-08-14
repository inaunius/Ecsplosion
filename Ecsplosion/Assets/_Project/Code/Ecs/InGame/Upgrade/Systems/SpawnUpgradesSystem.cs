using Inaunius.Ecsplosion.Configs;
using Inaunius.Ecsplosion.Ecs.InGame.Shared.Components;
using Inaunius.Ecsplosion.Ecs.InGame.Upgrade.Components;
using Inaunius.Ecsplosion.Static.Enums;
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

            foreach (var upgradeConfigKv in _config.UpgradesConfigs.AsDictionary)
            {
                int entity = _world.NewEntity();
                InitializeBusinesses(upgradeInfoPool, incomeMultiplier, improvementPool, developmentLevelPool, upgradeConfigKv.Value, upgradeConfigKv.Key, entity);
            }
        }

        private static void InitializeBusinesses(
            EcsPool<UpgradeInfo> upgradeInfoPool,
            EcsPool<IncomeMultiplier> incomeMultiplierPool,
            EcsPool<Improvement> improvementPoolPool,
            EcsPool<DevelopmentLvl> developmentLevelPoolPool,
            UpgradeCfg upgradeConfig,
            UpgradeId id,
            int entity
        )
        {
            const int DefaultLvl = 0;

            upgradeInfoPool.Add(entity) = new UpgradeInfo { Id = id };
            incomeMultiplierPool.Add(entity) = new IncomeMultiplier { ValuePercent = upgradeConfig.IncomeMultiplierPercent };
            improvementPoolPool.Add(entity) = new Improvement { Cost = upgradeConfig.Cost };
            developmentLevelPoolPool.Add(entity) = new DevelopmentLvl { Value = DefaultLvl };
        }
    }
}