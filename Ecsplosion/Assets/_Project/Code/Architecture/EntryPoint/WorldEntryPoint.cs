using System.Collections;
using System.Collections.Generic;
using Inaunius.Ecsplosion.Configs;
using Leopotam.EcsLite;
using UnityEngine;

namespace Inaunius.Ecsplosion.Architecture.EntryPoint
{
    public class WorldEntryPoint : MonoBehaviour
    {
        [SerializeField] private InGameCfg _inGameConfig;

        [SerializeField] private StringsCfg _stringsConfig;

        private EcsWorld _world;

        private EcsSystems _systems;

        private void Start()
        {
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);

            _systems.Init();
        }

        private void Update() => _systems.Run();

        private void OnDestroy()
        {
            _systems.Destroy();
            _world.Destroy();
        }
  }
}

