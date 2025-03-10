namespace ShellPOC.Models;

public class ShellPage
{
    public string Path {get; set;}
    public string Description {get; set;}

    public ShellPage(string path, string description)
    {
        Path = path;
        Description = description;
    }

    public override bool Equals(object? obj)
    {
        var other = obj as ShellPage;
        return other != null && Path.Equals(other.Path);
    }

    public override int GetHashCode()
    {
        return Path.GetHashCode();
    }
}
