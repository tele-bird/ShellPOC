using System;

namespace ShellPOC.Helpers;

public static class NavigationHelper
{
    private static string[] knownTabPaths = 
    {
        "//market/home/",
        "//market/brands/",
        "//market/plan/",
        "//market/maps/"
    };

	public static bool TryGetKnownTabSubpath(string path, out string? tabPath, out string? remainingRelativePath)
	{
        foreach(var knownTabPath in knownTabPaths)
        {
            if(path.StartsWith(knownTabPath) && path.Length > knownTabPath.Length)
            {
                tabPath = knownTabPath.TrimEnd('/');
                remainingRelativePath = path.Substring(knownTabPath.Length);
                return true;
            }
        }

        tabPath = null;
        remainingRelativePath = null;
        return false;
	}
}
