using System.Linq.Expressions;

namespace Shared.Extensions;

public static class EnumExtension
{
    public static string ToPropertyIdName<T>(Expression<Func<T, object>> propertyExpression)
    {
        return propertyExpression.Body switch
        {
            MemberExpression member => ProcessPropertyName(member.Member.Name),
            UnaryExpression {Operand: MemberExpression memberExpression} =>
                ProcessPropertyName(memberExpression.Member.Name),
            _ => throw new ArgumentException("The expression does not refer to a property.")
        };
    }

    private static string ProcessPropertyName(string propertyName)
    {
        return propertyName.EndsWith("Enum") 
            ? propertyName.Replace("Enum", "Id") 
            : propertyName + "Id";
    }
}