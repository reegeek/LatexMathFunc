using System;
using System.Globalization;
using LatexGrammar;
using MathFunc.Expression;

namespace MathFunc.LatexVisitor;

public partial class LatexParserVisitor
{
    private static readonly NumberFormatInfo PointFormatInfo = new() {NumberDecimalSeparator = "."};

    public override IMathematicalExpression VisitNumberAtomExpression(LatexParser.NumberAtomExpressionContext context)
    {
        var realNumber = context.REAL_NUMBER();
        var text = realNumber.GetText();
        double result;
        if (double.TryParse(text, NumberStyles.Any, PointFormatInfo, out result))
            return new Number(result);
        throw new Exception($"Unable to parse '{text}' to double");
    }
}