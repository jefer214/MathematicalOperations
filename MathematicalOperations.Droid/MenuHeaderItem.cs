using MathematicalOperations.Droid.Interfaces;
using System;

namespace MathematicalOperations.Droid
{
    public class MenuHeaderItem : IMenuItemsType
    {
        public string HeaderAverage { get; set; }
        public string HeaderMin { get; set; }
        public string HeaderMax { get; set; }

        public int GetMenuItemsType()
        {
            return 0;
        }

        public MenuHeaderItem(string headerAverage, string headerMin, string headerMax )
        {
            HeaderAverage = $"Promedio en el campo resultado: {headerAverage}";
            HeaderMin = $"Valor mínimo en el campo resultado: {headerMin}";
            HeaderMax = $"Valor máximo en el campo resultado: {headerMax}";
        }
    }

    public class MenuContentItem : IMenuItemsType
    {
        public string FirstNumber { get; set; }
        public string SecondNumber { get; set; }
        public string TypeOperation { get; set; }
        public string Result { get; set; }

        public int GetMenuItemsType()
        {
            return 1;
        }

        public MenuContentItem(string numberOne, string numberTwo, string typeOperation, string result)
        {
            FirstNumber = numberOne;
            SecondNumber = numberTwo;
            TypeOperation = typeOperation;
            Result = result;
        }
    }
}