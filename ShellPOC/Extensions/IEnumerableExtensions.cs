using System.Text;

namespace ShellPOC.Extensions;

public static class IEnumerableExtensions
{
    public static string ToDebugString<T>(this IEnumerable<T> source, Func<T, string>? selector = null)
    {
        StringBuilder sbDebugString = new StringBuilder();
        foreach (T item in source)
        {
            if (sbDebugString.Length > 0)
            {
                sbDebugString.Append(", ");
            }

            if (item != null)
            {
                if (selector != null)
                {
                    sbDebugString.Append(selector(item));
                }
                else
                {
                    sbDebugString.Append($"{item}");
                }
            }
            else
            {
                sbDebugString.Append("null");
            }
        }
        return $"[{sbDebugString}]";
    }
}