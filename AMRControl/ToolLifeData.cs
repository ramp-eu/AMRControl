using System.Net;
using System.Net.Http.Headers;

namespace AMRControl
{
    // This class handles data that describes the tool-lifecycle
    public class ToolLifeData
    {
        private string JsonString = ""; // Contains the raw Json-string that shows the tool-life-data
        Dictionary<int, Dictionary<string, string>>? ToolLifeDict = new Dictionary<int, Dictionary<string, string>>();
        private ApiCalls Api;

        public ToolLifeData()
        {
            Api = new ApiCalls();
        }

        public Dictionary<int, Dictionary<string, string>> GetToolLifeData() {
            string ToolLifeData = Api.GetEntityByType("Tool_life"); // Get tool-life-data
            this.JsonString = ToolLifeData;

            bool FoundMonitoringType = false;
            int Iteration = 0;
            Dictionary<string, string> ToolLife = new Dictionary<string, string>();

            if (ToolLifeData.Length > 10)
            {
                int StringPos = ToolLifeData.IndexOf("Tool_life");
                ToolLifeData = ToolLifeData.Substring(StringPos);
            }

            do
            {
                int StringPos = ToolLifeData.IndexOf("id");
                if (StringPos > 0)
                {
                    FoundMonitoringType = true;
                    ToolLifeData = ToolLifeData.Substring(StringPos + 5);
                    string Id = ToolLifeData.Substring(0, ToolLifeData.IndexOf("\""));
             //       System.Diagnostics.Debug.WriteLine("------------------ ID: " + StringPos + " --- " + Id);
                    string WarningLimit = ToolLifeData.Substring(ToolLifeData.IndexOf("warninglimit"));
                    WarningLimit = WarningLimit.Substring(WarningLimit.IndexOf("value") + 1);
                    WarningLimit = WarningLimit.Substring(WarningLimit.IndexOf(":") + 2);
                    WarningLimit = WarningLimit.Substring(0, WarningLimit.IndexOf("\""));
               //     System.Diagnostics.Debug.WriteLine("------------------ WarningLimit: " + StringPos + " --- " + WarningLimit);

                    string ActualQuantity = ToolLifeData.Substring(ToolLifeData.IndexOf("actualquantity"));
                    ActualQuantity = ActualQuantity.Substring(ActualQuantity.IndexOf("value") + 1);
                    ActualQuantity = ActualQuantity.Substring(ActualQuantity.IndexOf(":") + 2);
                    ActualQuantity = ActualQuantity.Substring(0, ActualQuantity.IndexOf("\""));
               //     System.Diagnostics.Debug.WriteLine("------------------ ActualQuantity: " + StringPos + " --- " + ActualQuantity);
               //     System.Diagnostics.Debug.WriteLine("------------------ StringPos: " + ToolLifeData);
                    
                    var Temp = new Dictionary<string, string>();
                    Temp["id"]             = Id;
                    Temp["warninglimit"]   = WarningLimit;
                    Temp["actualquantity"] = ActualQuantity;

                    this.ToolLifeDict[Iteration] = new Dictionary<string, string>();
                    this.ToolLifeDict[Iteration] = Temp;

                }
                else
                {
           //         System.Diagnostics.Debug.WriteLine("------------------ End: " + ToolLifeData);
                    FoundMonitoringType = false;
                }
            //    System.Diagnostics.Debug.WriteLine("------------------ Iteration: " + Iteration);

                Iteration++;
            } while (FoundMonitoringType == true);

            return ToolLifeDict;
            }
    }
}