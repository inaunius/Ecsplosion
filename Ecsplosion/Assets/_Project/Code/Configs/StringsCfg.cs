using Inaunius.Ecsplosion.Static.Enums;
using Inaunius.Ecsplosion.Common;
using UnityEngine;

namespace Inaunius.Ecsplosion.Configs
{
    [CreateAssetMenu(menuName = "_Configs/StringsCfg")]
    public class StringsCfg : ScriptableObject
    {
        [field: SerializeField] public InspectorDictionary<BusinessId, string> BusinessNames { get; private set; }
        [field: SerializeField] public InspectorDictionary<UpgradeId, string> UpgradeNames { get; private set; }
    }
}