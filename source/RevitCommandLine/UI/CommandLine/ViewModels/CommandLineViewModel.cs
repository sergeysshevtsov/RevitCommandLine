using RevitCommandLine.UI.CommandLine.Models;
using RevitCommandLine.UI.CommandLine.Views;
using RevitCommandLine.UI.CommandLine.Views.CustomControls;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace RevitCommandLine.UI.CommandLine.ViewModels;
public class CommandLineViewModel : INotifyPropertyChanged
{
    private readonly ComboBoxAC comboBox;
    private readonly Window window;

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string name = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    public CommandLineViewModel(Window window)
    {
      
       
    }

   
}
