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
            if (e.Key == Key.Escape || e.Key == Key.Enter)
                Window_Deactivated(s, e);
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
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, Name = "ArchitecturalWall", Description = "Architecture → Build → Wall → Wall: Architectural" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, Name = "StructuralWall", Description = "Architecture → Build → Wall → Wall: Structural" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, Name = "WallByFaceWall", Description = "Architecture → Build → Wall → Wall by Face" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, Name = "WallByFaceWall", Description = "Architecture → Build → Wall → Wall by Face" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, Name = "Door", Description = "Architecture → Build → Door" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, Name = "Window", Description = "Architecture → Build → Window" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, Name = "PlaceAComponent", Description = "Architecture → Build  → Component → Place a Component" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, Name = "ModelInPlace", Description = "Architecture → Build  → Component → Model In-Place" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, Name = "StructuralColumn", Description = "Architecture → Build → Column → Structural Column" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, Name = "ArchitecturalColumn", Description = "Architecture → Build → Column → Column: Architectural" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, Name = "RoofByFootprint", Description = "Architecture → Build → Roof → Roof by Footprint" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, Name = "RoofByExtrusion", Description = "Architecture → Build → Roof → Roof by Extrusion" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, Name = "RoofByFace", Description = "Architecture → Build → Roof → Roof by Face" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, Name = "AutomaticCeiling", Description = "Architecture → Build → Ceiling" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, Name = "ArchitecturalFloor", Description = "Architecture → Build → Floor → Floor: Architectural" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, Name = "StructuralFloor", Description = "Architecture → Build → Floor → Floor: Structural" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, Name = "FloorByFaceFloor", Description = "Architecture → Build → Floor → Floor by Face" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, Name = "SlabEdgeFloor", Description = "Architecture → Build → Floor → Floor: Slab Edge" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, Name = "CurtainSystemByFace", Description = "Architecture → Build → Curtain System" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, Name = "CurtainGrid", Description = "Architecture → Build → Curtain Grid" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, Name = "CurtainWallMullion", Description = "Architecture → Build → Curtain Mullion" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, Name = "Railing", Description = "Architecture → Circulation → Railing → Scetch Path" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, Name = "PlaceOnStairOrRamp", Description = "Architecture → Circulation → Railing → Place on Stair/Ramp" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, Name = "Ramp", Description = "Architecture → Circulation → Ramp" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, Name = "Stair", Description = "Architecture → Circulation → Stair" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, Name = "ModelText", Description = "Architecture → Model → ModelText" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, Name = "ModelLine", Description = "Architecture → Model → ModelLine" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, Name = "PlaceDetailGroup", Description = "Architecture → Model → Model Group → Place Model Group" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, Name = "CreateGroup", Description = "Architecture → Model → Model Group → Create Group" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, Name = "LoadAsGroup", Description = "Architecture → Model → Model Group → Load as Group into Open Projects" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, Name = "Room", Description = "Architecture → Room & Area → Room" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, Name = "RoomSeparator", Description = "Architecture → Room & Area → Room Separator" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, Name = "RoomTag", Description = "Architecture → Room & Area → Tag Room" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, Name = "TagAllNotTagged", Description = "Architecture → Room & Area → Tag All Not Tagged" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, Name = "AreaPlan", Description = "Architecture → Room & Area → Area → Area Plan" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, Name = "OpeningByFace", Description = "Architecture → Opening → By Face" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, Name = "ShaftOpening", Description = "Architecture → Opening → Shaft" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, Name = "WallOpening", Description = "Architecture → Opening → Wall" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, Name = "VerticalOpening", Description = "Architecture → Opening → Vertical" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, Name = "DormerOpening", Description = "Architecture → Opening → Dormer" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, Name = "Level", Description = "Architecture → Datum → Level" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, Name = "Grid", Description = "Architecture → Datum → Grid" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, Name = "SetWorkPlane", Description = "Architecture → Work Plane → Set → Set Work Plane" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, Name = "PickAPlane", Description = "Architecture → Work Plane → Set → Pick a Plane" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, Name = "ShowWorkPlane", Description = "Architecture → Work Plane → Show" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, Name = "ReferencePlane", Description = "Architecture → Work Plane → Ref Plane" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, Name = "FormWorkPlaneView", Description = "Architecture → Work Plane → Viewer" });

    }
}
