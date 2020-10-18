using System;
using System.Globalization;
using Calculator.Enum;
using Calculator.Interfaces;
using Xamarin.Forms;

namespace Calculator
{
    public partial class MainPage : ContentPage
    {
        private readonly ICalculator _calculator;

        public MainPage(ICalculator calculator)
        {
            this._calculator = calculator;
            InitializeComponent();
        }

        #region Numbers
        private void Button_Zero(object sender, EventArgs e)
        {
            IsClear();
            CalculatorViewField.Text = _calculator.AddOperand("0");
        }

        private void Button_One(object sender, EventArgs e)
        {
            IsClear();
            CalculatorViewField.Text = _calculator.AddOperand("1");
        }

        private void Button_Two(object sender, EventArgs e)
        {
            IsClear();
            CalculatorViewField.Text = _calculator.AddOperand("2");
        }

        private void Button_Three(object sender, EventArgs e)
        {
            IsClear();
            CalculatorViewField.Text = _calculator.AddOperand("3");
        }

        private void Button_Four(object sender, EventArgs e)
        {
            IsClear();
            CalculatorViewField.Text = _calculator.AddOperand("4");
        }

        private void Button_Five(object sender, EventArgs e)
        {
            IsClear();
            CalculatorViewField.Text = _calculator.AddOperand("5");
        }

        private void Button_Six(object sender, EventArgs e)
        {
            IsClear();
            CalculatorViewField.Text = _calculator.AddOperand("6");
        }

        private void Button_Seven(object sender, EventArgs e)
        {
            IsClear();
            CalculatorViewField.Text = _calculator.AddOperand("7");
        }

        private void Button_Eight(object sender, EventArgs e)
        {
            IsClear();
            CalculatorViewField.Text = _calculator.AddOperand("8");
        }

        private void Button_Nine(object sender, EventArgs e)
        {
            IsClear();
            CalculatorViewField.Text = _calculator.AddOperand("9");
        }
        #endregion

        #region Basic Calculation Methods
        private void Button_Plus(object sender, EventArgs e)
        {
            IsClear();
            SetOperatorAndShowValue(Operator.Plus);
        }

        private void Button_Minus(object sender, EventArgs e)
        {
            IsClear();
            SetOperatorAndShowValue(Operator.Minus);
        }

        private void Button_Multiply(object sender, EventArgs e)
        {
            IsClear();
            SetOperatorAndShowValue(Operator.Multiply);
        }

        private void Button_Div(object sender, EventArgs e)
        {
            IsClear();
            SetOperatorAndShowValue(Operator.Divide);
        }

        private void Button_Percent(object sender, EventArgs e)
        {
            IsClear();
            SetOperatorAndShowValue(Operator.Percentage);
        }
        #endregion

        #region diverse methods
        private void Button_Equal(object sender, EventArgs e)
        {
            IsClear();
            WholeCalculationOutput.Text += CalculatorViewField.Text + "=";
            CalculatorViewField.Text = _calculator.GetResult();
            WholeCalculationOutput.Text += CalculatorViewField.Text;
        }

        private void Button_Point(object sender, EventArgs e)
        {
            IsClear();
            CalculatorViewField.Text = _calculator.AddOperand(".");
        }

        private void Button_Clear(object sender, EventArgs e)
        {
            CalculatorViewField.Text = _calculator.SetOperator(Operator.Clear);
            WholeCalculationOutput.Text = CalculatorViewField.Text;
        }

        private void Button_PositiveNegativeSwitcher(object sender, EventArgs e)
        {
            IsClear();
            CalculatorViewField.Text = _calculator.PositiveNegativeSwitcher(CalculatorViewField.Text);
        }
        #endregion

        private void SetOperatorAndShowValue(Operator givenOperator)
        {
            WholeCalculationOutput.Text += _calculator.SetOperator(givenOperator);
            CalculatorViewField.Text = string.Empty;
        }

        private void IsClear()
        {
            if (_calculator.IsClear())
            {
                WholeCalculationOutput.Text = string.Empty;
                CalculatorViewField.Text = string.Empty;
            }
        }
    }
}
