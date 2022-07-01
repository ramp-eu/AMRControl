namespace AMRControl
{

    // This class is used for mapping a workorder from JSON to a easily usable format
    public class Workorder
    {
        public string id { get; set; }
        public string type { get; set; }
        public Dictionary<string, string>? scheduledAt { get; set; }
        public Dictionary<string, string>? status { get; set; }
        public Dictionary<string, string>? erpId { get; set; }
        public Dictionary<string, string>? dateCreated { get; set; }
        public Dictionary<string, string>? dateModified { get; set; }
        public Dictionary<string, string>? workstationId { get; set; }
        public Dictionary<string, string>? workstation { get; set; }
        public Dictionary<string, string>? warehouseId { get; set; }
        public Dictionary<string, string>? warehouse { get; set; }
    }

    // This class is used for mapping robot-data from JSON to a easily usable format
    public class Robot
    {
        public string id { get; set; }
        public string type { get; set; }
        public object? coordinates { get; set; }
        public Dictionary<string, float>? angle { get; set; }
        public Dictionary<string, string>? name { get; set; }
        public Dictionary<string, string>? status { get; set; }
        public Dictionary<string, string>? dateCreated { get; set; }
        public Dictionary<string, string>? dateModified { get; set; }
        public Dictionary<string, string>? battery { get; set; }
        public Dictionary<string, string>? version { get; set; }
    }
}
