using Inaunius.Ecsplosion.Common;
using Inaunius.Ecsplosion.Static.Enums;

namespace Inaunius.Ecsplosion.InGame.Business.Components
{
    public struct BusinessInfo { public BusinessId Id { get; set; } }

    public struct BaseIncome { public float Value { get; set; } }

    public struct IncomeDelay { public float ValueSeconds { get; set; } }

    public struct IncomeTimeLeft { public float Value { get; set; } }

    public struct IncomeSourceTag {}
}