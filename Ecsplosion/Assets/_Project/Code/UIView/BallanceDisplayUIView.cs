using Inaunius.Ecsplosion.Architecture.Services.ProgressSaveLoad;
using TMPro;
using UnityEngine;

namespace Inaunius.Ecsplosion.UIView
{
    public class BalanceDisplayUIView : MonoBehaviour
    {
        const string BalanceValueTextTemplate = "{0}$";

        [SerializeField] private TextMeshProUGUI _balanceValueText;

        public void UpdateFromSnapshot(ProgressSnapshot snapshot) =>
            _balanceValueText.text = string.Format(BalanceValueTextTemplate, snapshot.Balance);
    } 
}