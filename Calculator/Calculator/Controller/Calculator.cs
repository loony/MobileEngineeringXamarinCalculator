using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Calculator.Interfaces;

namespace Calculator.Controller
{
    public class Calculator : ICalculator
    {
        private bool isFirstValueSet;
        private decimal numberOne;
        private decimal numberTwo;
        private string calcOperator;

        public void AddOperand(string givenNumber)
        {
            if (isFirstValueSet)
            {
                numberOne = decimal.Parse(givenNumber, CultureInfo.InvariantCulture);
            }
            else
            {
                numberTwo = decimal.Parse(givenNumber, CultureInfo.InvariantCulture);
            }
        }

        public void SetOperator(string setOperator)
        {
            calcOperator = setOperator;
            isFirstValueSet = !isFirstValueSet;
        }

        public string GetResult()
        {
            switch (calcOperator)
            {
                case "+":
                    Sum();
                    break;
                case "-":
                    Substraction();
                    break;
                case "*":
                    Multiply();
                    break;
                case "/":
                    Divide();
                    break;
                case "+-":
                    numberOne = numberOne * -1;
                    //CalculatorViewField.Text = (inputValueOne).ToString(CultureInfo.InvariantCulture);
                    //WholeCalculationOutput.Text = (inputValueOne).ToString(CultureInfo.InvariantCulture);
                    //return;
                    break;
            }

            return "";
        }

        public void Sum()
        {
            throw new NotImplementedException();
        }

        public void Substraction()
        {
            throw new NotImplementedException();
        }

        public void Multiply()
        {
            throw new NotImplementedException();
        }

        public void Divide()
        {
            throw new NotImplementedException();
        }

        public void PositiveNegativeSwitcher()
        {
            throw new NotImplementedException();
        }

        public void Percentage()
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }
    }
}
