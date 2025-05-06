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
        CreateRibbon(application);
        return Result.Succeeded;
    }

    public Result OnShutdown(UIControlledApplication application) => Result.Succeeded;

    ObservableCollection<CommandItem> commandItems = [];
    public void GetRibbonButtonNames()
    {
        var ribbon = ComponentManager.Ribbon;
        var tabs = ribbon.Tabs;
        foreach (var tab in tabs)
        {
            var panels = tab.Panels;
            foreach (var panel in panels)
            {
                var items = panel.Source.Items;
                foreach (var item in items)
                {
                    if (item is Autodesk.Windows.RibbonButton button)
                    {
                        // To research - can we transform button ID into CommandPost item?
                        //is there any way to get the command post that sent to Revit from the button?
                        //can we collect full path to the command with Tab->Panel->DropDown button name(if needed)-> button name?
                        var name = button.Name;
                    }
                }
            }
        }
    }
}