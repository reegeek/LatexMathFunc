using MathFunc.Expression;

namespace MathFunc;

public static class LatexExpressionParserHelpers
{
    public static IMathematicalExpression ToMathematicalExpression(this string latexExpression)
    {
        var parser = new LatexExpressionParser();
        return parser.Parse(latexExpression);
    }
}