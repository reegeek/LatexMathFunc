using MathFunc;
using MathFunc.Expression;
using NUnit.Framework;
using System;
using System.Globalization;
using Shouldly;
using Antlr4.Runtime;
using LatexGrammar;
using System.Linq.Expressions;

namespace MathFuncTests;

[TestFixture]
internal class CommutativeOperatorParsingTests
{
    private LatexExpressionParser parser;

    [SetUp]
    public void SetUp()
    {
        parser = new LatexExpressionParser();
        Console.SetOut(TestContext.Progress);
    }

    [TestCase(12.5, "+", -1)]
    [TestCase(12.5, "*", 1.65)]
    [TestCase(12.5, "/", -1)]
    [TestCase(12.5, "-", 1)]
    public void should_parse_commutative_operator(double left, string op, double right)
    {
        //Arrange
        var numberFormat = new NumberFormatInfo {NumberDecimalSeparator = "."};
        var str = $"{left.ToString(numberFormat)}{op}{right.ToString(numberFormat)}";
        var expected = new CommutativeOperator(new Number(left), op, new Number(right));

        //Act
        var actual = parser.Parse(str);

        //Assert
        actual
            .ShouldBeOfType<CommutativeOperator>()
            .ShouldBe(expected);
    }

    [Test]
    public void should_commutative_token()
    {
        //arrange
        var str = "12.5-1";
        var charStream = new AntlrInputStream(str);
        var lexer = new LatexLexer(charStream);
        var tokenStream = new CommonTokenStream(lexer);

        //act
        tokenStream.Fill();

        //assert
        var tokens = tokenStream.GetTokens();
    }
}