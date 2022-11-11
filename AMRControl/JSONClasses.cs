namespace AMRControl
{
    // Collection of classes to map JSON-Data from Orion to object


    // This class is used for mapping a workorder from JSON to a easily usable format
      public class Workorder
    {
        public string? id { get; set; }
        public string? type { get; set; }
        public Subentry? dateCreated { get; set; }
        public Materials? materials { get; set; }
        public Subentry? scheduledAt { get; set; }
        public Subentry? status { get; set; }
        public Subentry? warehouseId { get; set; }
        public Subentry? workstationId { get; set; }
    }

    // Used for storing an array of materials that are sent together with the Workorders
    public class Materials
    {
        public string? type { get; set; }

        public MaterialsValue? value { get; set; }
        
    }
    // Values of the materials
    public class MaterialsValue
    {
        public string? type { get; set; }
        public WoValue[]? value { get; set; }
    }

    // Workorder-values
    public class WoValue
    {
        public Tool[]? tools { get; set; }
        public Component[]? components { get; set; }
    }

    // Tool-entries
    public class Tool
    {
        public string? id { get; set; }
        public string? turret { get; set; }
        public string? station { get; set; }
        public string? orientation { get; set; }
    }

    // Component-entries
    public class Component
    {
        public string? id { get; set; }
    }

    // General Subentry for storing type, string-value and metadata
    public class Subentry
    {
        public string? type { get; set; }
        public string? value { get; set; }
        public object? metadata { get; set; }
    }

    // General Subentry for storing type, float-value and metadata
    public class SubentryFloat
    {
        public string? type { get; set; }
        public float? value { get; set; }
        public object? metadata { get; set; }
    }

    // This class is used for mapping robot-data from JSON to a easily usable format
    public class Robot
    {
        public string? id { get; set; }
        public string? type { get; set; }
        public SubentryFloat? battery { get; set; }
        public Subentry? macAddress { get; set; }
        public Subentry? name { get; set; }
        public Subentry? refDestination { get; set; }
        public Subentry? status { get; set; }
        public Subentry? version { get; set; }
        public Location? location { get; set; }
    }

    // Hold the data of a workstation (coordiates)
    public class Workstation
    {
        public string? id { get; set; }
        public string? type { get; set; }
        public Location? location { get; set; }
        public Subentry? name { get; set; }
        public Subentry? status { get; set; }
    }

    // Stores location-data (x,y -coordinates and an angle)
    public class Location
    {
        public string? type { get; set; }
        public LocationValue? value { get; set; }
        public AngleMetadata? metadata { get; set; }
    }

    // X and Y-Coordinates of an location
    public class LocationValue
    {
        public string? type { get; set; }
        public float[]? coordinates { get; set; }
        public Dictionary<string, float>? metadata { get; set; }
    }

    // Angle-values that belong to location-data
    public class AngleMetadata
    {
        public object? angle { get; set; }
    }

    // Tool-life data is stored as string, as the JSON is not really good to map to an object
    public class ToolLife
    {
        public int? id { get; set; }
        public string? type { get; set; }
        public object? content { get; set; }
    }
}