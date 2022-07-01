namespace AMRControl.Data
{
    public class AmrTasks
    {
        public string Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime Date { get; set; }
        public string TaskName  { get; set; }
        public int NrOfTools { get; set; }
        public string Workstation { get; set; }
        public string WorkstationId { get; set; }
    }
}