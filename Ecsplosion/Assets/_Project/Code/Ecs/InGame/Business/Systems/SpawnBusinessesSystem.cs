using Inaunius.Ecsplosion.Configs;
using Inaunius.Ecsplosion.Ecs.InGame.Business.Components;
using Inaunius.Ecsplosion.Ecs.InGame.Shared.Components;
using Inaunius.Ecsplosion.Static;
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

            foreach (var businessConfig in _config.BusinessConfigs.AsDictionary.Values)
            {
                int entity = _world.NewEntity();
                InitializeBusinesses(businessInfoPool, baseIncomePool, incomeDelayPool, improvementPool, developmentLevelPool, businessConfig, entity);
            }
        }

        private static void InitializeBusinesses(
            EcsPool<BusinessInfo> businessInfoPool,
            EcsPool<BaseIncome> baseIncomePool,
            EcsPool<IncomeDelay> incomeDelayPool,
            EcsPool<Improvement> improvementPool,
            EcsPool<DevelopmentLvl> developmentLevelPool,
            InGameCfg.BusinessConfigEntry businessConfig,
            int entity
        )
        {
            businessInfoPool.Add(entity) = new BusinessInfo { Id = businessConfig.Config.Id };
            baseIncomePool.Add(entity) = new BaseIncome { Value = businessConfig.Config.BaseIncome };
            incomeDelayPool.Add(entity) = new IncomeDelay { ValueSeconds = businessConfig.Config.IncomeDelaySeconds };
            improvementPool.Add(entity) = new Improvement { Cost = InGameCalculations.CalculateLvlUpCost(businessConfig.LvlAtStart, businessConfig.Config.BaseCost) };
            developmentLevelPool.Add(entity) = new DevelopmentLvl { Value = businessConfig.LvlAtStart };
        }
    }
}