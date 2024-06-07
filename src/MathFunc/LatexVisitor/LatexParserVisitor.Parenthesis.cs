using LatexGrammar;
using MathFunc.Expression;

namespace MathFunc.LatexVisitor;

public partial class LatexParserVisitor
{
    public override IMathematicalExpression VisitParenthesisExpression(LatexParser.ParenthesisExpressionContext context)
    {
        var expression = context.expression();
        return Visit(expression);
    }
}