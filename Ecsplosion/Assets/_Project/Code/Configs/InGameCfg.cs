using System;
using System.Collections.Generic;
using System.Linq;
using Inaunius.Ecsplosion.Common;
using Inaunius.Ecsplosion.Static.Enums;
using UnityEngine;

namespace Inaunius.Ecsplosion.Configs
{
    [CreateAssetMenu(menuName = "_Configs/InGameCfg")]
    public class InGameCfg : ScriptableObject
    {
        [field: SerializeField] public InspectorDictionary<BusinessId, BusinessConfigEntry> BusinessConfigs { get; private set; }
        
        [field: SerializeField] public InspectorDictionary<UpgradeId, BusinessUpgradeCfg> UpgradesConfigs { get; private set; }

        [Serializable]
        public struct BusinessConfigEntry
        {
            [field: SerializeField] public BusinessCfg Config { get; private set; }

            [field: SerializeField] public int LvlAtStart { get; private set; }
        }
    }
}