using System.Collections;
using System.Collections.Generic;
using Inaunius.Ecsplosion.Architecture.Services.ProgressSaveLoad;
using Inaunius.Ecsplosion.Architecture.Services.UI;
using Inaunius.Ecsplosion.Configs;
using Inaunius.Ecsplosion.UIView;
using Leopotam.EcsLite;
using UnityEngine;

namespace Inaunius.Ecsplosion.Architecture.EntryPoint
{
    public class WorldEntryPoint : MonoBehaviour
    {
        [SerializeField] private InGameCfg _inGameConfig;

        [SerializeField] private StringsCfg _stringsConfig;

        [SerializeField] private InGameUIView _inGameUI;

        private UIService _uiService;

        private SaveLoadService _saveLoadService;

        private EcsWorld _world;

        private EcsSystems _systems;

        private void Start()
        {
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);

            CreateAndInitializeServices();
            SetupSystems();
        }

        private void Update() => _systems.Run();

        private void OnDestroy()
        {
            _systems.Destroy();
            _world.Destroy();
        }

        private void CreateAndInitializeServices()
        {
            _uiService = new UIService(_inGameUI);
            _inGameUI.Initialize(_inGameConfig);

            _saveLoadService = new SaveLoadService(_inGameConfig);
        }

        public void SetupSystems()
        {
            _systems
                .Init();
        }
  }
}

