using RevitCommandLine.UI.CommandLine.Models;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace RevitCommandLine.UI.CommandLine.Views;
public partial class CommandLineView : Window
{
    public CommandLineView()
    {
        InitializeComponent();

        this.PreviewKeyDown += (s, e) =>
        {
            if (e.Key == Key.Escape)
            {
                Window_Deactivated(s, e);
                CommandItem = null;
            }

            if (e.Key == Key.Enter)
            {
                Window_Deactivated(s, e);
            }
        };

        comboBoxAC.Loaded += ComboBoxAC_Loaded;

        ObservableCollection<CommandItem> commandItems = [];
        CollectCommands(ref commandItems);
        comboBoxAC.ItemsSource = commandItems;
    }

    public CommandItem CommandItem { get; set; }

    private void Window_Deactivated(object sender, EventArgs e)
    {
        try
        {
            this.Close();
        }
        catch { }
    }

    private async void ComboBoxAC_Loaded(object sender, RoutedEventArgs e)
    {
        await Task.Factory.StartNew(() => { Thread.Sleep(100); });
        if (comboBoxAC.CustomCbControl != null)
            comboBoxAC.CustomCbControl.SelectionChanged += ComboBoxAC_SelectionChanged; 
    }

    private void ComboBoxAC_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
    {
        if (comboBoxAC.CustomCbControl.SelectedItem is CommandItem ci)
            CommandItem = ci;
    }

    private void CollectCommands(ref ObservableCollection<CommandItem> commandItems)
    {
        commandItems.Add(new CommandItem() { Name = "ArchitecturalWall", Description = "Architecture → Wall → Wall: Architectural"  });
        commandItems.Add(new CommandItem() { Name = "StructuralWall", Description = "Architecture → Wall → Wall: Structural" });
    }
}
