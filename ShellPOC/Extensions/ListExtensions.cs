using System.Text;

namespace ShellPOC.Extensions;

public static class ListExtensions
{
    public static string ToDebugString<T>(this List<T> list) where T : class
    {
        StringBuilder sbDebugString = new StringBuilder();
        foreach (var t in list)
        {
            if (sbDebugString.Length > 0)
            {
                sbDebugString.Append(", ");
            }
            sbDebugString.Append(t == null ? "null" : t.ToString());
        }

        return $"[{sbDebugString}]";
    }
}
