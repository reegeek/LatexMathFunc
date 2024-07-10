using System;
using System.Globalization;
using Antlr4.Runtime.Tree;
using LatexGrammar;
using MathFunc.Expression;

namespace MathFunc.LatexVisitor;

public partial class LatexParserVisitor
{
    private static readonly NumberFormatInfo PointFormatInfo = new() {NumberDecimalSeparator = "."};

    public override IMathematicalExpression VisitNumberAtomExpression(LatexParser.NumberAtomExpressionContext context)
    {
        var realNumber = context.POSITIVE_NUMBER();
        return ExtractNumber(realNumber);
    }

    private static Number ExtractNumber(ITerminalNode realNumber)
    {
        var text = realNumber.GetText();
        double result;
        if (double.TryParse(text, NumberStyles.Any, PointFormatInfo, out result))
            return new Number(result);
        throw new Exception($"Unable to parse '{text}' to double");
    }

    public override IMathematicalExpression VisitNegativeNumberAtomExpression(LatexParser.NegativeNumberAtomExpressionContext context)
    {
        var extractNumber = ExtractNumber(context.POSITIVE_NUMBER());
        return extractNumber with {Value = -extractNumber.Value};
    }
}