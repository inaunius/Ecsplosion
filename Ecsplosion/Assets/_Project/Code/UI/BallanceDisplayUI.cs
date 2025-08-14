using TMPro;
using UnityEngine;

namespace Inaunius.Ecsplosion.UI
{
    public class BalanceDisplayUI : MonoBehaviour
    {
        const string BalanceValueTextTemplate = "{0}$";

        [SerializeField] private TextMeshProUGUI _balanceValueText;

        public void SetBalanceValue(float value) =>
            _balanceValueText.text = string.Format(BalanceValueTextTemplate, value);
    } 
}