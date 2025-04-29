namespace RevitCommandLine.UI.CommandLine.Models;
public class CommandItem
{
    public string Name { get; set; }
    public string Description { get; set; }

    public override string ToString()
    {
        return Name; 
    }
}
