using System;
using Calculator.Interfaces;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calculator
{
    public partial class App : Application
    {
        private ICalculator calculator;

        public App(ICalculator calculator)
        {
            this.calculator = calculator;
            InitializeComponent();

            MainPage = new MainPage(calculator);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
