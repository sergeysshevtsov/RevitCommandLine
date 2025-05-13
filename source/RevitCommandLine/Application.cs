using Autodesk.Revit.UI;
using Autodesk.Windows;
using RevitCommandLine.UI.CommandLine.Models;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Windows.Media.Imaging;

namespace RevitCommandLine;
public class Application : IExternalApplication
{
    private void CreateRibbon(UIControlledApplication application)
    {
        var assemblyPath = Assembly.GetExecutingAssembly().Location;
        var resourceString = "pack://application:,,,/RevitCommandLine;component/Resources/Icons/";

        var panel = application.CreateRibbonPanel("Utilities");
        panel.AddItem(
            new PushButtonData("CmdRevitCommandLine", "Command line", assemblyPath, "RevitCommandLine.AppCommands.CmdRevitCommandLine")
            {
                ToolTip = "Open Revit command line",
                LargeImage = new BitmapImage(new Uri(string.Concat(resourceString, "CommandLine32.png"))),
                Image = new BitmapImage(new Uri(string.Concat(resourceString, "CommandLine16.png")))
            });
    }

    public Result OnStartup(UIControlledApplication application)
    {
        GetRibbonButtonNames();
        CreateRibbon(application);
        return Result.Succeeded;
    }

    public Result OnShutdown(UIControlledApplication application) => Result.Succeeded;

    public ObservableCollection<CommandItem> CommandItems { get; set; } = [];
    private List<Tuple<string, string, string, string, string>> _commandItems = new();

    private void GetRibbonButtonNames()
    {
        var tabs = ComponentManager.Ribbon.Tabs;
        foreach (var tab in tabs)
            foreach (var panel in tab?.Panels)
                CollectCommandItems(panel?.Source.Items, tab.AutomationName, panel.Source.Title);
    }

    private void CollectCommandItems(RibbonItemCollection items, string tabName, string panelName)
    {
        foreach (var item in items)
        {
            if (item is Autodesk.Windows.RibbonButton button)
            {
                if (string.IsNullOrEmpty(button?.AutomationName))
                    continue;

                var displayName = button.AutomationName.Replace("\r", " ").Replace("\n", " ");
                var description = string.Concat(tabName, " → ", panelName, " → ", displayName);
                CommandItems.Add(new CommandItem() {
                    CommandType = CommandType.Standard,
                    CommandId = button.Id,
                    DisplayName = displayName,
                    Description = description,
                });
                _commandItems.Add(new Tuple<string, string, string, string, string>(tabName, panelName, displayName, description, button.Id));
            }

            if (item is RibbonFoldPanel foldPanel)
                CollectCommandItems(foldPanel.Items, tabName, panelName);

            if (item is RibbonRowPanel rowPanel)
                CollectCommandItems(rowPanel.Items, tabName, panelName);
        }
    }
}