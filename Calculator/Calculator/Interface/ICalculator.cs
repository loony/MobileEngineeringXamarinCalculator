using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Interfaces
{
    public interface ICalculator
    {
        void AddOperand(string operand);

        void SetOperator(string setOperator);

        string GetResult();

        void Sum();

        void Substraction();

        void Multiply();

        void Divide();

        void PositiveNegativeSwitcher();

        void Percentage();

        void Clear();
    }
}
