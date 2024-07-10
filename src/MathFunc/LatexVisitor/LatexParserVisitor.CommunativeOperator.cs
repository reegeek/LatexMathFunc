using LatexGrammar;
using MathFunc.Expression;

namespace MathFunc.LatexVisitor;

public partial class LatexParserVisitor
{
    public override IMathematicalExpression VisitCommutativeOperatorExpression(LatexParser.CommutativeOperatorExpressionContext context)
    {
        var left = Visit(context.left);
        var right = Visit(context.right);
        var op = context.@operator.Text;
        return new CommutativeOperator(left, op, right);
    }
}