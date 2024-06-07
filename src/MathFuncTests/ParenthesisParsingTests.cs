using System;
using Antlr4.Runtime;
using LatexGrammar;
using MathFunc;
using MathFunc.Expression;
using NUnit.Framework;
using Shouldly;

namespace MathFuncTests;

[TestFixture]
internal class ParenthesisParsingTests
{
    private LatexExpressionParser parser;

    [SetUp]
    public void SetUp()
    {
        parser = new LatexExpressionParser();
        Console.SetOut(TestContext.Progress);
    }

    [TestCase("(-12.5)")]
    public void should_be_parenthesis_token(string str)
    {
        //arrange

        //Act
        var latexParser = parser.Parser(str);
        latexParser.expression();
        var stream = latexParser.InputStream;

        //Assert
        var tokenStream = stream.ShouldBeAssignableTo<CommonTokenStream>();
        tokenStream.Get(0).Type.ShouldBe(LatexParser.LP);
        tokenStream.Get(1).Type.ShouldBe(LatexParser.REAL_NUMBER);
        tokenStream.Get(2).Type.ShouldBe(LatexParser.RP);
    }

    [TestCase("(123.5678)", 123.5678)]
    public void should_parse_number_with_parenthesis(string str, double expected)
    {
        //arrange

        //act
        var expression = parser.Parse(str);

        //assert
        expression
            .ShouldBeOfType<Number>()
            .Value
            .ShouldBe(expected);
    }
}