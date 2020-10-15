using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Calculator.Interfaces;

namespace Calculator.UWP
{
    public sealed partial class MainPage
    {
        private ICalculator _calculator;

        public MainPage(ICalculator calculator)
        {
            this._calculator = calculator;
            this.InitializeComponent();

            LoadApplication(new Calculator.App(calculator));
        }
    }
}
