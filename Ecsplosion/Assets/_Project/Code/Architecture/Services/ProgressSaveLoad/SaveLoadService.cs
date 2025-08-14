using System.Linq;
using Inaunius.Ecsplosion.Configs;
using Inaunius.Ecsplosion.Ecs.Architecture.Progress;

namespace Inaunius.Ecsplosion.Architecture.Services.ProgressSaveLoad
{
    public class SaveLoadService
    {
        private readonly InGameCfg _config;


        private ProgressSnapshot _localSnapshot;

        public SaveLoadService(InGameCfg config) => _config = config;

        public IProgressSnapshot GetProgressSnapshot() => _localSnapshot;

        public void UpdateLocalSnapshot(ProgressSnapshot snapshot) => _localSnapshot = snapshot;

        public void SaveLocalSnapshot()
        {

        }

        public void LoadOrInitLocalSnapshot()
        {
            _localSnapshot = new ProgressSnapshot
            {
                Balance = 0f,
                Businesses = _config.BusinessConfigs.AsDictionary.ToDictionary
                (
                    key => key.Key,
                    value => new BusinessProgress
                    {
                        DevelopmentLvl = value.Value.LvlAtStart,
                        IncomeSecondsLeft = value.Value.Config.IncomeDelaySeconds
                    }
                ),
                Upgrades = _config.UpgradesConfigs.AsDictionary.ToDictionary
                (
                    key => key.Key,
                    value => new UpgradeProgress
                    {
                        DevelopmentLvl = 0
                    }
                )
            };
        }
    }
}