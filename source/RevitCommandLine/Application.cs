using Autodesk.Revit.UI;
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
}