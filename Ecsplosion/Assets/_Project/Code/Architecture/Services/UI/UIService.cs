using Inaunius.Ecsplosion.Architecture.Services.ProgressSaveLoad;
using Inaunius.Ecsplosion.Configs;
using Inaunius.Ecsplosion.UIView;

namespace Inaunius.Ecsplosion.Architecture.Services.UI
{
    public class UIService
    {
        private readonly InGameUIView _inGameUIView;

        public UIService(InGameUIView inGameUIView) => _inGameUIView = inGameUIView;

        public void InitializeUIViews(InGameCfg inGameConfig) => _inGameUIView.Initialize(inGameConfig);

        public void UpdateUIFromSnapshot(ProgressSnapshot snapshot) => _inGameUIView.UpdateUIFromSnapshot(snapshot);
    }
}