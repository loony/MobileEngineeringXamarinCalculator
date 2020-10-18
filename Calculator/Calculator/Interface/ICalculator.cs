using System;
using System.Collections.Generic;
using System.Text;
using Calculator.Enum;

namespace Calculator.Interfaces
{
    public interface ICalculator
    {
        string AddOperand(string operand);

        string SetOperator(Operator setOperator);

        string GetResult();

        string PositiveNegativeSwitcher(string givenNumber);

        bool IsClear();
    }
}
