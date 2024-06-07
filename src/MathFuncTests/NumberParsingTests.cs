using System;
using Antlr4.Runtime;
using LatexGrammar;
using MathFunc;
using MathFunc.Expression;
using NUnit.Framework;
using Shouldly;

namespace MathFuncTests
{
    [TestFixture]
    internal class NumberParsingTests
    {
        private LatexExpressionParser parser;

        [SetUp]
        public void SetUp()
        {
            parser = new LatexExpressionParser();
            Console.SetOut(TestContext.Progress);
        }

        [TestCase("0")]
        [TestCase("-1")]
        [TestCase("12")]
        [TestCase("-12.5")]
        [TestCase("123.5")]
        public void should_be_real_number_token(string str)
        {
            //arrange
            
            //Act
            var latexParser = parser.Parser(str);
            latexParser.expression();
            var stream = latexParser.InputStream;

            //Assert
            var tokenStream = stream.ShouldBeAssignableTo<CommonTokenStream>();
            tokenStream.Size.ShouldBe(2);
            tokenStream.Get(0).Type.ShouldBe(LatexParser.REAL_NUMBER);
        }

        [TestCase("0", 0)]
        [TestCase("-1", -1)]
        [TestCase("10", 10)]
        [TestCase("-1.5", -1.5)]
        [TestCase("123.5678", 123.5678)]
        public void should_parse_number(string str, double expected)
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
}
