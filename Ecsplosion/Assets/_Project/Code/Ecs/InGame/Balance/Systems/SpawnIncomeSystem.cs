using Inaunius.Ecsplosion.Ecs.InGame.Balance.Components;
using Leopotam.EcsLite;

namespace Inaunius.Ecsplosion.Ecs.InGame.Balance.Systems
{
    public class SpawnIncomeSystem : IEcsInitSystem
    {
        public void Init(IEcsSystems systems)
        {
            systems.GetWorld().GetPool<CurrentBalance>().Add(systems.GetWorld().NewEntity());
        }
    }
}