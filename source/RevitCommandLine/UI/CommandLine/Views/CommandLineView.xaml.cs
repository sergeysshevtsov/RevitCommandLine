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

    private string GetDisplayName(string description)
    {
        var displayName = description.Split('→').Last();
        if (!string.IsNullOrEmpty(displayName))
            return displayName.Trim();
        return string.Empty;
    }

    private void CollectCommands(ref ObservableCollection<CommandItem> commandItems)
    {
        //-----------Architecture
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "ArchitecturalWall", Description = "Architecture → Build → Wall → Wall: Architectural" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "StructuralWall", Description = "Architecture → Build → Wall → Wall: Structural" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "WallByFaceWall", Description = "Architecture → Build → Wall → Wall by Face" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "SweepWall", Description = "Architecture → Build → Wall → Wall: Sweep" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "RevealWall", Description = "Architecture → Build → Wall → Wall: Reveal" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "Door", Description = "Architecture → Build → Door" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "Window", Description = "Architecture → Build → Window" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "PlaceAComponent", Description = "Architecture → Build  → Component → Place a Component" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "ModelInPlace", Description = "Architecture → Build  → Component → Model In-Place" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "StructuralColumn", Description = "Architecture → Build → Column → Structural Column" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "ArchitecturalColumn", Description = "Architecture → Build → Column → Column: Architectural" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "RoofByFootprint", Description = "Architecture → Build → Roof → Roof by Footprint" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "RoofByExtrusion", Description = "Architecture → Build → Roof → Roof by Extrusion" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "RoofByFace", Description = "Architecture → Build → Roof → Roof by Face" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "AutomaticCeiling", Description = "Architecture → Build → Ceiling" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "ArchitecturalFloor", Description = "Architecture → Build → Floor → Floor: Architectural" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "StructuralFloor", Description = "Architecture → Build → Floor → Floor: Structural" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "FloorByFaceFloor", Description = "Architecture → Build → Floor → Floor by Face" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "SlabEdgeFloor", Description = "Architecture → Build → Floor → Floor: Slab Edge" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "CurtainSystemByFace", Description = "Architecture → Build → Curtain System" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "CurtainGrid", Description = "Architecture → Build → Curtain Grid" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "CurtainWallMullion", Description = "Architecture → Build → Curtain Mullion" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "Railing", Description = "Architecture → Circulation → Railing → Scetch Path" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "PlaceOnStairOrRamp", Description = "Architecture → Circulation → Railing → Place on Stair/Ramp" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "Ramp", Description = "Architecture → Circulation → Ramp" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "Stair", Description = "Architecture → Circulation → Stair" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "ModelText", Description = "Architecture → Model → ModelText" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "ModelLine", Description = "Architecture → Model → ModelLine" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "PlaceDetailGroup", Description = "Architecture → Model → Model Group → Place Model Group" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "CreateGroup", Description = "Architecture → Model → Model Group → Create Group" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "LoadAsGroup", Description = "Architecture → Model → Model Group → Load as Group into Open Projects" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "Room", Description = "Architecture → Room & Area → Room" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "RoomSeparator", Description = "Architecture → Room & Area → Room Separator" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "RoomTag", Description = "Architecture → Room & Area → Tag Room" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "TagAllNotTagged", Description = "Architecture → Room & Area → Tag All Not Tagged" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "AreaPlan", Description = "Architecture → Room & Area → Area → Area Plan" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "AreaBoundary", Description = "Architecture → Room & Area → Area → Area Boundary" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "OpeningByFace", Description = "Architecture → Opening → By Face" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "ShaftOpening", Description = "Architecture → Opening → Shaft" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "WallOpening", Description = "Architecture → Opening → Wall" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "VerticalOpening", Description = "Architecture → Opening → Vertical" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "DormerOpening", Description = "Architecture → Opening → Dormer" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "Level", Description = "Architecture → Datum → Level" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "Grid", Description = "Architecture → Datum → Grid" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "SetWorkPlane", Description = "Architecture → Work Plane → Set → Set Work Plane" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "PickAPlane", Description = "Architecture → Work Plane → Set → Pick a Plane" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "ShowWorkPlane", Description = "Architecture → Work Plane → Show" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "ReferencePlane", Description = "Architecture → Work Plane → Ref Plane" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "FormWorkPlaneView", Description = "Architecture → Work Plane → Viewer" });
        //Autodesk.Revit.UI.PostableCommand.AreaBoundary
        //-----------Structure
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "Beam", Description = "Structure → Structure → Beam" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "StructuralTrusses", Description = "Structure → Structure → StructuralTrusses" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "Brace", Description = "Structure → Structure → Brace" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "AutomaticBeamSystem", Description = "Structure → Structure → Beam System" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "StructuralConnection", Description = "Structure → Connection → Connection" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "Isolated", Description = "Structure → Foundation → Isolated" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "Wall", Description = "Structure → Foundation → Wall" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "Slab", Description = "Structure → Foundation → Slab → Structural Foundation: Slab" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "SlabEdgeFloor", Description = "Structure → Foundation → Slab → Floor: Slab Edge" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "StructuralRebar", Description = "Structure → Reinforcement → Rebar" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "Area", Description = "Structure → Reinforcement → Area" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "StructuralPathReinforcement", Description = "Structure → Reinforcement → Path" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "StructuralFabricArea", Description = "Structure → Reinforcement → Fabric Area" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "SingleFabricSheetPlacement", Description = "Structure → Reinforcement → Fabric Sheet" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "EditRebarCover", Description = "Structure → Reinforcement → Cover" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "InsertCoupler", Description = "Structure → Reinforcement → Rebar Coupler" });

    }
}
