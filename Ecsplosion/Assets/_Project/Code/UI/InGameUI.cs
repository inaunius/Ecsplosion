using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inaunius.Ecsplosion.UI
{
    public class InGameUI : MonoBehaviour
    {
        [SerializeField] private BalanceDisplayUI _balanceDisplay;

        [SerializeField] private Transform _businessCardsParent;

        [SerializeField] private BusinessCardUI _businessCardPrefab;
    }
}
