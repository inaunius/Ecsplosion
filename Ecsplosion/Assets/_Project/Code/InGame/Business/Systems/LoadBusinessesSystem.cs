using Inaunius.Ecsplosion.Configs;
using Inaunius.Ecsplosion.InGame.Business.Components;
using Inaunius.Ecsplosion.InGame.Shared.Components;
using Inaunius.Ecsplosion.Static;
using Leopotam.EcsLite;

namespace Inaunius.Ecsplosion.InGame.Business.Systems
{
    public class LoadBusinessesSystem : IEcsInitSystem
    {
        private readonly InGameCfg _config;

        private EcsWorld _ecsWorld;

        public LoadBusinessesSystem(InGameCfg config)
        {
            _config = config;
        }

        public void Init(IEcsSystems systems)
        {
            _ecsWorld = systems.GetWorld();

            var businessInfoPool = _ecsWorld.GetPool<BusinessInfo>();
            var baseIncomePool = _ecsWorld.GetPool<BaseIncome>();
            var incomeDelayPool = _ecsWorld.GetPool<IncomeDelay>();
            var improvementPool =_ecsWorld.GetPool<Improvement>();
            var developmentLevelPool = _ecsWorld.GetPool<DevelopmentLvl>();

            foreach (var businessConfig in _config.BusinessConfigs)
            {
                int entity = _ecsWorld.NewEntity();
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
            improvementPool.Add(entity) = new Improvement { Cost = InGameCalculations.CalculateLevelCost(businessConfig.LvlAtStart, businessConfig.Config.BaseCost) };
            developmentLevelPool.Add(entity) = new DevelopmentLvl { Value = businessConfig.LvlAtStart };
        }
    }
}