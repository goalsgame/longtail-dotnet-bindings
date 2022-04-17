﻿using System.Linq;
using CodeGen.Syntax;
using CodeGen.Syntax.Expressions;
using NUnit.Framework;

namespace CodeGen.Tests;

internal class ExpressionParserTests
{
    [TestCase("+")]
    [TestCase("-")]
    [TestCase("*")]
    [TestCase("/")]
    [TestCase("%")]
    [TestCase("^")]
    [TestCase("|")]
    [TestCase("&")]
    [TestCase("&&")]
    [TestCase("||")]
    public void Parse_BinaryOperator_ReturnExpression(string op)
    {
        var code = $"1 {op} 2";

        var result = (BinaryExpression)new Parser(code).Parse().GetChildren().SingleOrDefault()!;
        var left = (LiteralExpression)result.Left;
        var right = (LiteralExpression)result.Right;

        Assert.That(result, Is.Not.Null);
        Assert.That(left.Value, Is.EqualTo("1"));
        Assert.That(right.Value, Is.EqualTo("2"));
        Assert.That(result.Operator, Is.EqualTo(op));
    }

    [TestCase("=")]
    [TestCase("+=")]
    [TestCase("-=")]
    [TestCase("*=")]
    [TestCase("/=")]
    [TestCase("^=")]
    [TestCase("|=")]
    [TestCase("&=")]
    [TestCase("!=")]
    [TestCase(">>=")]
    [TestCase("<<=")]
    public void Parse_AssigmentOperator_ReturnExpression(string op)
    {
        var code = $"a {op} 2";

        var result = (AssigmentExpression)new Parser(code).Parse().GetChildren().SingleOrDefault()!;
        var left = (IdentifierExpression)result.Left;
        var right = (LiteralExpression)result.Right;

        Assert.That(result, Is.Not.Null);
        Assert.That(left.Value, Is.EqualTo("a"));
        Assert.That(right.Value, Is.EqualTo("2"));
        Assert.That(result.Operator, Is.EqualTo(op));
    }

    [TestCase("!")]
    [TestCase("++")]
    [TestCase("--")]
    [TestCase("~")]
    [TestCase("*")]
    [TestCase("&")]
    public void Parse_UnaryExpression_ReturnExpression(string unary)
    {
        var code = $"{unary}a";
        var result = (UnaryExpression)new Parser(code).Parse().GetChildren().SingleOrDefault()!;
        var right = (IdentifierExpression)result.Expression;

        Assert.That(right.Value, Is.EqualTo("a"));
        Assert.That(result.Operator, Is.EqualTo(unary));
    }

    [Test]
    public void Parse_ParenthesizedExpression_ReturnExpression()
    {
        var code = "(1 + 2)";

        var parenthesizedExpression = (ParenthesizedExpression)new Parser(code).Parse().GetChildren().Single()!;
        var result = (BinaryExpression)parenthesizedExpression.Inner;
        var left = (LiteralExpression)result.Left;
        var right = (LiteralExpression)result.Right;

        Assert.That(result, Is.Not.Null);
        Assert.That(left.Value, Is.EqualTo("1"));
        Assert.That(right.Value, Is.EqualTo("2"));
        Assert.That(result.Operator, Is.EqualTo("+"));
    }
}