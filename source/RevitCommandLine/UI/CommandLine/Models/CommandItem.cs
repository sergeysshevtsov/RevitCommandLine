using Autodesk.Revit.UI;

namespace RevitCommandLine.UI.CommandLine.Models;
public class CommandItem
{
    public CommandType CommandType { get; set; }
    public RevitCommandId RevitCommandId { get; set; }
    public string CommandId { get; set; }
    public string DisplayName { get; set; }
    public string Description { get; set; }
    public override string ToString() => DisplayName;
}
