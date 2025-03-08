using System.Collections.Specialized;

namespace ShellPOC.Extensions;

public static class NameValueCollectionExtensions
{
    public static IDictionary<string,object> ToDictionary(this NameValueCollection collection)
    {
        var result = new Dictionary<string, object>();
        foreach(var key in collection.AllKeys)
        {
            if(key != null)
            {
                var value = collection[key];
                if(value != null)
                {
                    result.Add(key, value);
                }
            }
        }
        return result;
    }
 }
