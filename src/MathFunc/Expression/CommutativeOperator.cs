namespace MathFunc.Expression;

public record CommutativeOperator(IMathematicalExpression Left, string Operator, IMathematicalExpression Right) : IMathematicalExpression;