﻿using System;

namespace CodeGen.Syntax.Expressions;

internal class ConstExpression : Expression
{
    public Expression Expression { get; }
    public ConstExpression(Expression expression)
    {
        Expression = expression;
    }

    public override string ToString() => $"const {Expression}";
    public override void PrettyPrint(int indentation = 0)
    {
        Console.WriteLine($"{new string(' ', indentation)}{GetType().Name}");
        Expression.PrettyPrint(indentation + 2);
    }
}