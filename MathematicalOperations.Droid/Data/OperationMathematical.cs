namespace MathematicalOperations.Droid.Data
{
    public class OperationMathematical
    {
        public double NumberOne { get; set; }
        public double NumberTwo { get; set; }
        public string TypeOperation { get; set; }
        public double Result { get; set; }

        public override string ToString()
        {
            return $"{NumberOne},{NumberTwo},{TypeOperation},{Result}";
        }
    }
}