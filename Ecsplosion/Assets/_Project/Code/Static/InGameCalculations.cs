using System.Linq;

namespace Inaunius.Ecsplosion.Static
{
    public static class InGameCalculations
    {
        public static float CalculateIncome(int lvl, float baseIncome, params float[] upgradesMultipliersPercent) =>
            lvl * baseIncome * (1f + upgradesMultipliersPercent.Aggregate(0f, (sum, multiplier) => sum + (multiplier / 100f)));

        public static float CalculateLvlUpCost(int currentLvl, float baseCost) =>
            (currentLvl + 1) * baseCost;
    }
}