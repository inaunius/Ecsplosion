using Inaunius.Ecsplosion.Configs;
using Inaunius.Ecsplosion.Ecs.InGame.Business.Components;
using Inaunius.Ecsplosion.Ecs.InGame.Shared.Components;
using Inaunius.Ecsplosion.Static;
using Inaunius.Ecsplosion.Static.Enums;
using Leopotam.EcsLite;

namespace Inaunius.Ecsplosion.Ecs.InGame.Business.Systems
{
    public class SpawnBusinessesSystem : IEcsInitSystem
    {
        private readonly InGameCfg _config;

        private EcsWorld _world;

        public SpawnBusinessesSystem(InGameCfg config)
        {
            _config = config;
        }

        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();

            var businessInfoPool = _world.GetPool<BusinessInfo>();
            var baseIncomePool = _world.GetPool<BaseIncome>();
            var incomeDelayPool = _world.GetPool<IncomeDelay>();
            var improvementPool =_world.GetPool<Improvement>();
            var developmentLevelPool = _world.GetPool<DevelopmentLvl>();

            foreach (var businessConfigKv in _config.BusinessConfigs.AsDictionary)
            {
                int entity = _world.NewEntity();
                InitializeBusinesses(businessInfoPool, baseIncomePool, incomeDelayPool, improvementPool, developmentLevelPool, businessConfigKv.Value, businessConfigKv.Key, entity);
            }
        }

        private static void InitializeBusinesses(
            EcsPool<BusinessInfo> businessInfoPool,
            EcsPool<BaseIncome> baseIncomePool,
            EcsPool<IncomeDelay> incomeDelayPool,
            EcsPool<Improvement> improvementPool,
            EcsPool<DevelopmentLvl> developmentLevelPool,
            InGameCfg.BusinessConfigEntry businessConfig,
            BusinessId id,
            int entity
        )
        {
            businessInfoPool.Add(entity) = new BusinessInfo { Id = id };
            baseIncomePool.Add(entity) = new BaseIncome { Value = businessConfig.Config.BaseIncome };
            incomeDelayPool.Add(entity) = new IncomeDelay { ValueSeconds = businessConfig.Config.IncomeDelaySeconds };
            improvementPool.Add(entity) = new Improvement { Cost = InGameCalculations.CalculateLvlUpCost(businessConfig.LvlAtStart, businessConfig.Config.BaseCost) };
            developmentLevelPool.Add(entity) = new DevelopmentLvl { Value = businessConfig.LvlAtStart };
        }
    }
}