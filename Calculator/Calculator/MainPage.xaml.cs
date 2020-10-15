using System;
using System.Globalization;
using Calculator.Interfaces;
using Xamarin.Forms;

namespace Calculator
{
    public partial class MainPage : ContentPage
    {
        private readonly ICalculator _calculator;
        private bool isInputValueOneSet;
        private decimal inputValueOne;
        private decimal inputValueTwo;
        private string setOperator;
        //private Controller.Calculator calculator;

        public MainPage(ICalculator calculator)
        {
            this._calculator = calculator;
            InitializeComponent();
        }

        public void Sum()
        {
            CalculatorViewField.Text = (inputValueOne + inputValueTwo).ToString(CultureInfo.InvariantCulture);
        }

        public void Substraction()
        {
            _calculator.Substraction();
        }

        public void Multiply()
        {
            CalculatorViewField.Text = (inputValueOne * inputValueTwo).ToString(CultureInfo.InvariantCulture);
        }

        public void Divide()
        {
            // Todo: implement logic to say division by Zero is not allowed
            if (IsDivisionByZero(inputValueTwo))
            {
                WholeCalculationOutput.Text = (inputValueOne / inputValueTwo).ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                CalculatorViewField.Text = "Division by zero not allowed";
            }
        }

        public void PositiveNegativeSwitcher()
        {
            inputValueOne = decimal.Parse(CalculatorViewField.Text, CultureInfo.InvariantCulture);
            setOperator = "+-";
            Equal();
        }

        public void Percentage()
        {
            isInputValueOneSet = !isInputValueOneSet;
            CalculatorViewField.Text = "%";
        }

        public void Equal()
        {
            isInputValueOneSet = !isInputValueOneSet;
            inputValueTwo = decimal.Parse(CalculatorViewField.Text, CultureInfo.InvariantCulture);

            switch (setOperator)
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
                    inputValueOne = inputValueOne * -1;
                    CalculatorViewField.Text = (inputValueOne).ToString(CultureInfo.InvariantCulture);
                    WholeCalculationOutput.Text = (inputValueOne).ToString(CultureInfo.InvariantCulture);
                    return;
            }

            WholeCalculationOutput.Text += inputValueTwo.ToString(CultureInfo.InvariantCulture) + " = " + CalculatorViewField.Text;
        }

        public void Clear()
        {
            isInputValueOneSet = false;
            CalculatorViewField.Text = "0";
            WholeCalculationOutput.Text = string.Empty;
        }

        private bool IsDivisionByZero(decimal givenNumber)
        {
            return givenNumber > 0 || givenNumber < 0 ;
        }

        #region Numbers
        private void Button_Zero(object sender, EventArgs e)
        {
            _calculator.AddOperand(CalculatorViewField.Text);
        }

        private void Button_One(object sender, EventArgs e)
        {
            _calculator.AddOperand("1");
        }

        private void Button_Two(object sender, EventArgs e)
        {
            _calculator.AddOperand("2");
        }

        private void Button_Three(object sender, EventArgs e)
        {
            _calculator.AddOperand("3");
        }

        private void Button_Four(object sender, EventArgs e)
        {
            CalculatorViewField.Text += "4";
        }

        private void Button_Five(object sender, EventArgs e)
        {
            CalculatorViewField.Text += "5";
        }

        private void Button_Six(object sender, EventArgs e)
        {
            CalculatorViewField.Text += "6";
        }

        private void Button_Seven(object sender, EventArgs e)
        {
            CalculatorViewField.Text += "7";
        }

        private void Button_Eight(object sender, EventArgs e)
        {
            CalculatorViewField.Text += "8";
        }

        private void Button_Nine(object sender, EventArgs e)
        {
            CalculatorViewField.Text += "9";
        }
        #endregion

        #region Basic Calculation Methods
        private void Button_Plus(object sender, EventArgs e)
        {
            isInputValueOneSet = !isInputValueOneSet;
            inputValueOne = decimal.Parse(CalculatorViewField.Text, CultureInfo.InvariantCulture);
            ShowOutput("+");
            setOperator = "+";
            CalculatorViewField.Text = "0";
        }

        private void Button_Minus(object sender, EventArgs e)
        {
            isInputValueOneSet = !isInputValueOneSet;
            inputValueOne = decimal.Parse(CalculatorViewField.Text, CultureInfo.InvariantCulture);
            ShowOutput("-");
            setOperator = "-";
            CalculatorViewField.Text = "";
        }

        private void Button_Multiply(object sender, EventArgs e)
        {
            isInputValueOneSet = !isInputValueOneSet;
            inputValueOne = decimal.Parse(CalculatorViewField.Text, CultureInfo.InvariantCulture);
            ShowOutput("*");
            setOperator = "*";
            CalculatorViewField.Text = "";
        }

        private void Button_Percent(object sender, EventArgs e)
        {
            isInputValueOneSet = !isInputValueOneSet;
            CalculatorViewField.Text = "%";
        }
        #endregion

        #region diverse methods
        private void Button_Equal(object sender, EventArgs e)
        {
            CalculatorViewField.Text = _calculator.GetResult();
        }

        private void Button_Point(object sender, EventArgs e)
        {
            CalculatorViewField.Text += ".";
        }

        private void Button_Div(object sender, EventArgs e)
        {
            isInputValueOneSet = !isInputValueOneSet;
            inputValueOne = decimal.Parse(CalculatorViewField.Text, CultureInfo.InvariantCulture);
            ShowOutput("/");
            setOperator = "/";
            CalculatorViewField.Text = "";
        }

        private void Button_Clear(object sender, EventArgs e)
        {
            isInputValueOneSet = false;
            WholeCalculationOutput.Text = string.Empty;
            Clear();
        }

        private void Button_PositiveNegativeSwitcher(object sender, EventArgs e)
        {
            PositiveNegativeSwitcher();
        }
        #endregion

        private void ShowOutput(string calculatorOperator)
        {
            WholeCalculationOutput.Text += CalculatorViewField.Text + " " + calculatorOperator;

            CalculatorViewField.Text = calculatorOperator;
        }
    }
}
