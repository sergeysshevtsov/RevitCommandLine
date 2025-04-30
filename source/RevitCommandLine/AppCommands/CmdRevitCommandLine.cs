using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using System.Windows.Interop;
using System.Windows;
using System.Runtime.InteropServices;
using RevitCommandLine.UI.CommandLine.Views;

namespace RevitCommandLine.AppCommands;

[Transaction(TransactionMode.Manual)]
[Regeneration(RegenerationOption.Manual)]
internal class CmdRevitCommandLine : IExternalCommand
{
    [DllImport("user32.dll")]
    static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;
    }

    [DllImport("user32.dll")]
    static extern IntPtr MonitorFromWindow(IntPtr hwnd, uint dwFlags);

    [DllImport("shcore.dll")]
    static extern int GetDpiForMonitor(IntPtr hmonitor, int dpiType, out uint dpiX, out uint dpiY);

    const int MDT_EFFECTIVE_DPI = 0;

    private static void EnsureMeasured(Window window)
    {
        if (double.IsNaN(window.Width) || double.IsNaN(window.Height))
        {
            window.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
            window.Arrange(new Rect(0, 0, window.DesiredSize.Width, window.DesiredSize.Height));
        }
    }

    public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
    {
        var window = new CommandLineView();
        var revitHandle = Autodesk.Windows.ComponentManager.ApplicationWindow;
        if (GetWindowRect(revitHandle, out RECT rect))
        {
            IntPtr monitor = MonitorFromWindow(revitHandle, 2);
            GetDpiForMonitor(monitor, MDT_EFFECTIVE_DPI, out uint dpiX, out uint dpiY);

            double revitLeftDip = rect.Left * 96.0 / dpiX;
            double revitTopDip = rect.Top * 96.0 / dpiY;
            double revitWidthDip = (rect.Right - rect.Left) * 96.0 / dpiX;
            double revitHeightDip = (rect.Bottom - rect.Top) * 96.0 / dpiY;

            EnsureMeasured(window);

            double childWidth = window.Width;
            double childHeight = window.Height;

            if (double.IsNaN(childWidth) || childWidth == 0)
                childWidth = 270;

            if (double.IsNaN(childHeight) || childHeight == 0)
                childHeight = 45;

            window.WindowStartupLocation = WindowStartupLocation.Manual;
            window.Left = revitLeftDip + (revitWidthDip - childWidth) / 2;
            window.Top = revitTopDip + (revitHeightDip - childHeight) / 2;
        }

        new WindowInteropHelper(window)
        {
            Owner = Autodesk.Windows.ComponentManager.ApplicationWindow
        };

        window.ShowDialog();

        if (window.CommandItem != null && window.CommandItem?.CommandType == UI.CommandLine.Models.CommandType.Standard)
        {
            var UIApp = commandData.Application;
            var postableCommand = (PostableCommand)Enum.Parse(typeof(PostableCommand), window.CommandItem.PostableCommandName);
            var revitCmd = RevitCommandId.LookupPostableCommandId(postableCommand);

            if (UIApp.CanPostCommand(revitCmd))
                UIApp.PostCommand(revitCmd);
        }

        return Result.Succeeded;
    }
}
