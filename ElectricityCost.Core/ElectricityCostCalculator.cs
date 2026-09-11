namespace ElectricityCost.Core
{
    public static class ElectricityCostCalculator
    {
        public static double Calculate(int powerConsumption, double usageHours, double energyPrice)
        {
            double powerInKilowatts = powerConsumption / 1000.0;
            double result = powerInKilowatts * usageHours * energyPrice * 30;
            
            return result;
        }
    }
}
