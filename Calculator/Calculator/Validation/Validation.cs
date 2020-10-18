using Calculator.Enum;

namespace Calculator.Validation
{
    public class Validation
    {
        public bool Validator(Operator setOperator, bool isFirstValueSet, string numberTwo)
        {
            var two = decimal.Parse(numberTwo);
            return isFirstValueSet && two != 0 && IsDivisionByZero(setOperator, two);
        }

        private bool IsDivisionByZero(Operator setOperator, decimal numberTwo)
        {
            return numberTwo != 0 && setOperator != Operator.Divide;
        }
    }
}
