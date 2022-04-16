﻿using System;

namespace CodeGen.Syntax.Expressions;

public sealed class BinaryExpression : Expression
{
    public Expression Left { get; }
    public Expression Right { get; }
    public string Operator { get; }
    public BinaryExpression(Expression left, Expression right, string op)
    {
        Left = left;
        Right = right;
        Operator = op;
    }
    public override string ToString() => $"{Left} {Operator} {Right}";

    public override void PrettyPrint(int indentation = 0)
    {
        Console.WriteLine($"{new string(' ', indentation)}{GetType().Name} ({Operator})");
        Left.PrettyPrint(indentation+2);
        Right.PrettyPrint(indentation+2);
    }
}