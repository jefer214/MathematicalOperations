namespace MathematicalOperations.Droid.Helpers
{
    using System;

    public static class OperationHelper
    {
        public static double Calculate(double valueOne, double valueTwo, int option)
        {
            double result = 0;

            switch (option)
            {
                case 0:
                    break;
                case 1:
                    result = valueOne + valueTwo;
                    break;
                case 2:
                    result = valueOne - valueTwo;
                    break;
                case 3:
                    result = valueOne * valueTwo;
                    break;
                case 4:
                    result = valueTwo == 0 ? 0 : valueOne / valueTwo;
                    break;
                case 5:
                    result = valueTwo == 0 ? 0 : valueOne % valueTwo;
                    break;
                case 6:
                    result = Math.Sqrt(valueOne);
                    break;
                default:
                    break;
            }

            return result;
        }
    }
}