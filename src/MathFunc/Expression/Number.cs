namespace MathFunc.Expression;

public record Number(double Value) : IMathematicalExpression
{
    public static implicit operator double(Number number) => number.Value;
    public static implicit operator Number(double value) => new (value);
}