using Antlr4.Runtime;

using LatexGrammar;
using MathFunc.Expression;
using MathFunc.LatexVisitor;

namespace MathFunc
{
    public class LatexExpressionParser
    {
        public IMathematicalExpression? Parse(string latexExpression)
        {
            var parser = Parser(latexExpression);
            var expression = parser.expression();
            return expression?.Accept(new LatexParserVisitor());
        }

        public LatexParser Parser(string latexExpression)
        {
            var charStream = new AntlrInputStream(latexExpression);
            var lexer = new LatexLexer(charStream);
            var tokenStream = new CommonTokenStream(lexer);
            var parser = new LatexParser(tokenStream);
            return parser;
        }
    }
}
