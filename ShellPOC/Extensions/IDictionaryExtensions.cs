using System;
using System.Text;

namespace ShellPOC.Extensions;

public static class IDictionaryExtensions
{
    public static string ToDebugString(this IDictionary<string, object> dictionary)
    {
        StringBuilder sbDebugString = new StringBuilder();
        foreach (var key in dictionary.Keys)
        {
            if (sbDebugString.Length > 0)
            {
                sbDebugString.Append(", ");
            }
            sbDebugString.Append($"{key}: {dictionary[key]}");
        }
        return $"[{sbDebugString}]";
    }

    public static string ToDebugString(this IDictionary<string, string> dictionary)
    {
        StringBuilder sbDebugString = new StringBuilder();
        foreach (var key in dictionary.Keys)
        {
            if (sbDebugString.Length > 0)
            {
                sbDebugString.Append(", ");
            }
            sbDebugString.Append($"{key}: {dictionary[key]}");
        }
        return $"[{sbDebugString}]";
    }

    public static string ToDebugString<T>(this IDictionary<string, List<T>> dictionary) where T : class
    {
        StringBuilder sbDebugString = new StringBuilder();
        foreach (var key in dictionary.Keys)
        {
            if (sbDebugString.Length > 0)
            {
                sbDebugString.Append(", ");
            }
            sbDebugString.Append($"{key}: {dictionary[key].ToDebugString()}");
        }
        return $"[{sbDebugString}]";
    }

    public static string ToQueryString(this IDictionary<string, object> dictionary)
    {
        StringBuilder sbQueryString = new StringBuilder();
        if(dictionary.Count > 0)
        {
            foreach(var key in dictionary.Keys)
            {
                var value = dictionary[key];
                if(key != null && value != null)
                {
                    sbQueryString.Append(sbQueryString.Length == 0 ? "?" : "&");
                    sbQueryString.Append($"{key}={value}");
                }
            }
        }
        return sbQueryString.ToString();
    }
}
