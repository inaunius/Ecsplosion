using Inaunius.Ecsplosion.Common.Extensions;
using Inaunius.Ecsplosion.Ecs.Architecture.Progress.Components;
using Inaunius.Ecsplosion.Ecs.InGame.Business.Components;
using Leopotam.EcsLite;

namespace Inaunius.Ecsplosion.Ecs.Architecture.Progress.Systems
{
    public class SnapshotCollectSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _world;

        private EcsFilter _holderFilter;
        private EcsFilter _businessesFilter;

        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            _holderFilter = _world.Filter<ProgressSnapshotHolder>().End();
            _businessesFilter = _world.Filter<BusinessInfo>().Inc<BaseIncome>().Inc<IncomeDelay>().Inc<BaseIncome>().End();
        }

        public void Run(IEcsSystems systems)
        {
            _holderFilter.GetSingle();
        }
    }
}