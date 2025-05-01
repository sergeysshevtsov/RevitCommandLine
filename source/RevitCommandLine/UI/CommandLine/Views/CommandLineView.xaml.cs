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
        
        //-----------Steel
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "Plate", Description = "Steel → Fabrication Elements → Plate" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "Bolts", Description = "Steel → Fabrication Elements → Bolts → Bolts" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "Anchors", Description = "Steel → Fabrication Elements → Bolts → Anchors" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "Holes", Description = "Steel → Fabrication Elements → Bolts → Holes" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "ShearStuds", Description = "Steel → Fabrication Elements → Bolts → Shear Studs" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "Welds", Description = "Steel → Fabrication Elements → Welds" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "CornerCut", Description = "Steel → Modifiers → Corner Cut" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "CopeSkewed", Description = "Steel → Modifiers → Notch Skewed" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "Shorten", Description = "Steel → Modifiers → Shorten" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "ContourCut", Description = "Steel → Modifiers → Contour Cut" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "Cope", Description = "Steel → Parametric Cuts → Notch" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "Miter", Description = "Steel → Parametric Cuts → Miter → Miter" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "SawCutFlange", Description = "Steel → Parametric Cuts → Miter → Saw cut - Flange" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "SawCutWeb", Description = "Steel → Parametric Cuts → Miter → Saw cut - Web" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "CutThrough", Description = "Steel → Parametric Cuts → Cut Through" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "CutBy", Description = "Steel → Parametric Cuts → Cut By" });

        //----------Systems
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "Duct", Description = "Systems → HVAC → Duct" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "DuctPlaceholder", Description = "Systems → HVAC → Duct Placeholder" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "DuctFitting", Description = "Systems → HVAC → Duct Fitting" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "DuctAccessory", Description = "Systems → HVAC → Duct Accessory" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "ConvertToFlexDuct", Description = "Systems → HVAC → Convert to Flex Duct" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "FlexDuct", Description = "Systems → HVAC → Flex Duct" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "AirTerminal", Description = "Systems → HVAC → Air Terminal" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "FabricationPart", Description = "Systems → Fabrication → Fabrication Part" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "MultiPointRouting", Description = "Systems → Fabrication → Multi-Point Routing" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "MEPFabricationDuctworkStiffener", Description = "Systems → MEP Detailing → MEP Fabrication Ductwork Stiffener" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "PAndIDModeler", Description = "Systems → P&ID Collaboration → P&ID Modeler" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "MechanicalEquipment", Description = "Systems → Mechanical → Mechanical Equipment" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "MechanicalControlDevice", Description = "Systems → Mechanical → Mechanical Control Device" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "Pipe", Description = "Systems → Plumbing & Piping → Pipe" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "PipePlaceholder", Description = "Systems → Plumbing & Piping → Pipe Placeholder" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "ParallelPipes", Description = "Systems → Plumbing & Piping → Parallel Pipes" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "PipeFitting", Description = "Systems → Plumbing & Piping → Pipe Fitting" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "PipeAccessory", Description = "Systems → Plumbing & Piping → Pipe Accessory" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "FlexPipe", Description = "Systems → Plumbing & Piping → Flex Pipe" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "PlumbingEquipment", Description = "Systems → Plumbing & Piping → Plumbing Equipment" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "PlumbingFixture", Description = "Systems → Plumbing & Piping → Plumbing Fixture" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "Sprinkler", Description = "Systems → Plumbing & Piping → Sprinkler" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "ArcWire", Description = "Systems → Electrical → Wire" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "CableTray", Description = "Systems → Electrical → Cable Tray" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "Conduit", Description = "Systems → Electrical → Conduit" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "ParallelConduits", Description = "Systems → Electrical → Parallel Conduits" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "CableTrayFitting", Description = "Systems → Electrical → Cable Tray Fitting" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "ElectricalEquipment", Description = "Systems → Electrical → Electrical Equipment" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "ElectricalFixture", Description = "Systems → Electrical → Device → Electrical Fixture" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "Communication", Description = "Systems → Electrical → Device → Communication" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "Data", Description = "Systems → Electrical → Device → Data" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "FireAlarm", Description = "Systems → Electrical → Device → Fire Alarm" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "Lighting", Description = "Systems → Electrical → Device → Lighting" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "NurseCall", Description = "Systems → Electrical → Device → Nurse Call" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "Security", Description = "Systems → Electrical → Device → Security" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "Telephone", Description = "Systems → Electrical → Device → Telephone" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "LightingFixture", Description = "Systems → Electrical → Lighting Fixture" });

        //-----------Insert
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "LinkRevit", Description = "Insert → Link → Link Revit" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "LinkIFC", Description = "Insert → Link → Link IFC" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "LinkCAD", Description = "Insert → Link → Link CAD" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "LinkTopography", Description = "Insert → Link → Link Topography" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "DWFMarkup", Description = "Insert → Link → DWF Markup" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "PlaceDecal", Description = "Insert → Link → Decal → Place Decal" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "DecalTypes", Description = "Insert → Link → Decal → Decal Types" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "PointCloud", Description = "Insert → Link → Point Cloud" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "CoordinationModelLocal", Description = "Insert → Link → Coordination Model → Local" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "CoordinationModelAutodeskDocs", Description = "Insert → Link → Coordination Model → Autodesk Docs" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "LinkPDF", Description = "Insert → Link → Link PDF" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "LinkImage", Description = "Insert → Link → Link Image" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "ManageLinks", Description = "Insert → Link → Manage Links" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "ImportCAD", Description = "Insert → Import → Import CAD" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "ImportGBXML", Description = "Insert → Import → Import gbXML" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "ImportPDF", Description = "Insert → Import → Import PDF" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "ImportImage", Description = "Insert → Import → Import Image" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "LoadFamilyIntoProjectAndClose", Description = "Insert → Load from Library → Load Family" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "LoadAutodeskFamily", Description = "Insert → Load from Library → Load Autodesk Family" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "InsertViewsFromFile", Description = "Insert → Load from Library → Insert from File → Insert Views from File" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "Insert2DElementsFromFile", Description = "Insert → Load from Library → Insert from File → Insert 2D Elements from File" });

        //-----------Annotate
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "AlignedDimension", Description = "Annotate → Dimension → Aligned" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "LinearDimension", Description = "Annotate → Dimension → Linear" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "AngularDimension", Description = "Annotate → Dimension → Angular" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "RadialDimension", Description = "Annotate → Dimension → Radial" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "ArcLengthDimension", Description = "Annotate → Dimension → Arc Length" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "SpotElevation", Description = "Annotate → Dimension → Spot Elevation" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "SpotCoordinate", Description = "Annotate → Dimension → Spot Coordinate" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "SpotSlope", Description = "Annotate → Dimension → Spot Slope" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "DetailLine", Description = "Annotate → Detail → Detail Line" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "FilledRegion", Description = "Annotate → Detail → Region → Filled Region" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "MaskingRegion", Description = "Annotate → Detail → Region → Masking Region" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "DetailComponent", Description = "Annotate → Detail → Component → Detail Component" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "RepeatingDetailComponent", Description = "Annotate → Detail → Component → Repeating Detail Component" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "LegendComponent", Description = "Annotate → Detail → Component → Legend Component" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "RevisionCloud", Description = "Annotate → Detail → Revision Cloud" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "Insulation", Description = "Annotate → Detail → Insulation" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "Text", Description = "Annotate → Text → Text" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "CheckSpelling", Description = "Annotate → Text → Check Spelling" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "FindOrReplace", Description = "Annotate → Text → Find/Replace" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "TagByCategory", Description = "Annotate → Tag → Tag by Category" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "TagAllNotTagged", Description = "Annotate → Tag → Tag All" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "BeamAnnotations", Description = "Annotate → Tag → Beam Annotations" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "MultiCategoryTag", Description = "Annotate → Tag → Multi-Category Tag" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "MaterialTag", Description = "Annotate → Tag → Material Tag" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "AreaTag", Description = "Annotate → Tag → Area Tag" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "RoomTag", Description = "Annotate → Tag → Room Tag" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "ViewReference", Description = "Annotate → Tag → View Reference" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "StairTreadOrRiserNumber", Description = "Annotate → Tag → Tread Number" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "AlignedMultiRebarAnnotation", Description = "Annotate → Tag → Multi-Rebar → Aligned Multi-Rebar Annotation" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "LinearMultiRebarAnnotation", Description = "Annotate → Tag → Multi-Rebar → Linear Multi-Rebar Annotation" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "ElementKeynote", Description = "Annotate → Tag → Keynote → Element Keynote" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "MaterialKeynote", Description = "Annotate → Tag → Keynote → Material Keynote" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "UserKeynote", Description = "Annotate → Tag → Keynote → User Keynote" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "KeynotingSettings", Description = "Annotate → Tag → Keynote → Keynoting Settings" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "DuctLegend", Description = "Annotate → Color Fill → Duct Legend" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "PipeLegend", Description = "Annotate → Color Fill → Pipe Legend" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "ColorFillLegend", Description = "Annotate → Color Fill → Color Fill Legend" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "Symbol", Description = "Annotate → Symbol → Symbol" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "SpanDirectionSymbol", Description = "Annotate → Symbol → Span Direction" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "BeamSystemSymbol", Description = "Annotate → Symbol → Beam" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "StairPath", Description = "Annotate → Symbol → Stair Path" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "AreaReinforcementSymbol", Description = "Annotate → Symbol → Area" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "PathReinforcementSymbol", Description = "Annotate → Symbol → Path" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "RebarBendingDetail", Description = "Annotate → Symbol → Rebar" });
        commandItems.Add(new CommandItem() { CommandType = CommandType.Standard, PostableCommandName = "FabricReinforcementSymbol", Description = "Annotate → Symbol → Fabric" });
    }
}
