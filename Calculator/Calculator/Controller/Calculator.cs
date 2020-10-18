using Calculator.Enum;
using Calculator.Interfaces;
using CultureInfo = System.Globalization.CultureInfo;

namespace Calculator.Controller
{
    public class Calculator : ICalculator
    {
        private readonly Validation.Validation _validation;
        private bool isFirstValueSet;
        private string numberOne;
        private string numberTwo;
        private string calcOperator;
        private bool isGuiToBeCleared;

        public Calculator()
        {
            _validation = new Validation.Validation();
        }

        #region public methods
        public string AddOperand(string givenNumber)
        {
            if (isFirstValueSet)
            {
                numberTwo = numberTwo + givenNumber;
            }
            else
            {
                numberOne = numberOne + givenNumber;
            }

            return isFirstValueSet
                ? numberTwo
                : numberOne;
        }

        public string SetOperator(Operator setOperator)
        {
            return SetCalculationOperator(setOperator);
        }

        public string GetResult()
        {
            isGuiToBeCleared = true;
            var one = decimal.Parse(numberOne);
            var two = decimal.Parse(numberTwo);
            var isValid = _validation.Validator(Operator.Plus, isFirstValueSet,
                two.ToString(CultureInfo.InvariantCulture));

            if (isValid)
            {
                switch (calcOperator)
                {
                    case "+":
                        return Sum(one, two);
                    case "-":
                        return Substraction(one, two);
                    case "*":
                        return Multiply(one, two);
                    case ":":
                        return Divide(one, two);
                }
            }

            return "There was a validation error. Press C to start over.";
        }

        public string PositiveNegativeSwitcher(string givenNumber)
        {
            var number = decimal.Parse(givenNumber, CultureInfo.InvariantCulture);

            return PositiveNegativeSwitcher(number);
        }

        public bool IsClear()
        {
            if (isGuiToBeCleared)
            {
                Clear();
                return true;
            }

            return false;
        }

        #endregion

        #region operators
        private string Sum(decimal one, decimal two)
        {
            return (one + two).ToString(CultureInfo.InvariantCulture);
        }

        private string Substraction(decimal one, decimal two)
        {
            return (one - two).ToString(CultureInfo.InvariantCulture);
        }

        private string Multiply(decimal one, decimal two)
        {
            return (one * two).ToString(CultureInfo.InvariantCulture);
        }

        private string Divide(decimal one, decimal two)
        {
            return (one / two).ToString(CultureInfo.InvariantCulture);
        }

        private string Percentage(double givenNumber)
        {
            var number = (givenNumber * 0.01).ToString(CultureInfo.InvariantCulture);

            if (isFirstValueSet)
            {
                numberTwo = number;
            }
            else
            {
                numberOne = number;
            }

            return number;
        }
        #endregion

        private string PositiveNegativeSwitcher(decimal givenNumber)
        {
            var number = (givenNumber * -1).ToString(CultureInfo.InvariantCulture);
            if (isFirstValueSet)
            {
                numberTwo = number;
            }
            else
            {
                numberOne = number;
            }

            return number;
        }

        private string Clear()
        {
            isFirstValueSet = false;
            numberOne = string.Empty;
            numberTwo = string.Empty;
            calcOperator = string.Empty;
            isGuiToBeCleared = false;
            return string.Empty;
        }

        private string SetCalculationOperator(Operator setOperator)
        {

            switch (setOperator)
            {
                case Operator.Plus:
                    calcOperator = "+";
                    break;
                case Operator.Minus:
                    calcOperator = "-";
                    break;
                case Operator.Multiply:
                    calcOperator = "*";
                    break;
                case Operator.Divide:
                    calcOperator = ":";
                    break;
                case Operator.Percentage:
                    return Percentage(double.Parse(numberOne));
                case Operator.Clear:
                    return Clear();
            }

            isFirstValueSet = !isFirstValueSet;

            return (numberOne).ToString(CultureInfo.InvariantCulture) + calcOperator;
        }
    }
}
