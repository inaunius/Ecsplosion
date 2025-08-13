using System;
using System.Collections.Generic;
using System.Linq;
using Inaunius.Ecsplosion.Static.Enums;
using UnityEngine;

namespace Inaunius.Ecsplosion.Configs
{
    [CreateAssetMenu(menuName = "_Configs/InGameCfg")]
    public class InGameCfg : ScriptableObject
    {
        [field: SerializeField] public BusinessConfigEntry[] BusinessConfigs { get; private set; }

        private void OnValidate()
        {
            var businessIds = new List<BusinessId>();
            var upgradesIds = new List<UpgradeId>();
            foreach (var businessCfg in BusinessConfigs)
            {
                if (businessIds.Contains(businessCfg.Config.Id))
                {
                    throw new ArgumentException($"Business id duplicate {businessCfg.Config.Id}!");
                }
                if (businessCfg.Config.Upgrades.Any(upgrade => upgradesIds.Contains(upgrade.Id)))
                {
                    throw new ArgumentException($"Upgrade id duplicate in {businessCfg.Config.Id}!");
                }
                businessIds.Add(businessCfg.Config.Id);
            }
        }

        [Serializable]
        public struct BusinessConfigEntry
        {
            [field: SerializeField] public BusinessCfg Config { get; private set; }

            [field: SerializeField] public bool IsBoughtAtStart { get; private set; }
        }
    }
}