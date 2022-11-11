using System.Text.Json;
using System.Text.Json.Nodes;

namespace AMRControl.Data
{
    // Retrieves the workorders (tasks) for the robot
    public class AmrTasksService
    {
        public Task<AmrTasks[]> GetAmrTasksAsync(DateTime startDate) // Get 1 to n tasks, parse them, store in an object and return
        {
            var Api = new ApiCalls();
            List<Workorder>? Workorders = JsonSerializer.Deserialize<List<Workorder>>(Api.GetWorkorders()); // Get workorders and map to object
            var Wo = Api.GetWorkorders();

            List<AmrTasks> Tasks = new List<AmrTasks>(); // Map workorders to a list

            if (Workorders != null)
            {
                foreach (var Wl in Workorders) // Walk through the list and extract the required fields
                {
                    var Temp = new AmrTasks();
                    Temp.Id = Wl.id;
                    Temp.IsActive = true;
                    Temp.Date = DateTime.Parse(Wl.dateCreated.value);
                    Temp.TaskName = Wl.type;
                    Temp.NrOfTools = (Random.Shared.Next(15) + 1);
                    Temp.Workstation = Wl.workstationId.value.Substring(Wl.workstationId.value.LastIndexOf(":")).Replace(":", "");
                    Temp.WorkstationId = Wl.workstationId.value;

                    Tasks.Add(Temp);
                }
            }

            return Task.FromResult(Tasks.ToArray());
        }
    }
}