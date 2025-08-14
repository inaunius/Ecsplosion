using System.Collections;
using System.Collections.Generic;
using Inaunius.Ecsplosion.Configs;
using Leopotam.EcsLite;
using UnityEngine;

namespace Inaunius.Ecsplosion.Architecture
{
    public class WorldEntryPoint : MonoBehaviour
    {
        [SerializeField] private InGameCfg _inGameConfig;

        [SerializeField] private StringsCfg _stringsConfig;

        private EcsWorld _ecsWorld;

        private EcsSystems _ecsSystems;

        private void Start()
        {
            _ecsWorld = new EcsWorld();
            _ecsSystems = new EcsSystems(_ecsWorld);

            _ecsSystems.Init();
        }

        private void Update() => _ecsSystems.Run();

        private void OnDestroy()
        {
            _ecsSystems.Destroy();
            _ecsWorld.Destroy();
        }
  }
}

