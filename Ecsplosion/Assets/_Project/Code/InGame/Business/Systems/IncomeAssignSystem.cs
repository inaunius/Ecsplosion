using Inaunius.Ecsplosion.Configs;
using Inaunius.Ecsplosion.InGame.Business.Components;
using Leopotam.EcsLite;
using UnityEngine;

namespace Inaunius.Ecsplosion.InGame.Business
{
    public class IncomeAssignSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly InGameCfg _config;

        private EcsWorld _world;

        private EcsFilter _filter;

        public IncomeAssignSystem(InGameCfg config) => _config = config;

        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            _filter = _world.Filter<IncomeTimeLeft>().Inc<BusinessInfo>().End();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (int entity in _filter)
            {
                var businessInfo = _world.GetPool<BusinessInfo>().Get(entity);
                var timeLeft = _world.GetPool<IncomeTimeLeft>().Get(entity);

                timeLeft.TimeLeftTimer.PassTime(Time.deltaTime);
                if (timeLeft.TimeLeftTimer.IsTimeOut)
                {
                    _world.GetPool<IncomeReceiverTag>().Add(entity);
                    timeLeft.TimeLeftTimer.ResetTimer(_config.BusinessConfigs.AsDictionary[businessInfo.Id].Config.IncomeDelaySeconds);
                }
            }
        }
    }
}