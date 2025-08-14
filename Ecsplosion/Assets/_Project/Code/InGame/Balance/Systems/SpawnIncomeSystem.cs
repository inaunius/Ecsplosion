using Inaunius.Ecsplosion.InGame.Balance.Components;
using Leopotam.EcsLite;

namespace Inaunius.Ecsplosion.InGame.Balance.Systems
{
    public class SpawnIncomeSystem : IEcsInitSystem
    {
        public void Init(IEcsSystems systems)
        {
            systems.GetWorld().GetPool<CurrentBalance>().Add(systems.GetWorld().NewEntity());
        }
    }
}