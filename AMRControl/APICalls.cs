using System.Net;
using System.Net.Http.Headers;

namespace AMRControl
{
    // This class encapsules all the calls to the different APIs. It uses base-URLs defined in appsettings.json
    public class ApiCalls
    {
        readonly string? FiwareUrl; // Contains the URL to Fiware
        readonly string? BrokerUrl; // Contains the URL to broker
        readonly string Errors = "";
        readonly IConfigurationRoot? AppSettings = null; // Stores the AppSettings
        public ApiCalls()
        {
            AppSettings = new ConfigurationBuilder() // Extract AppSettings from JSON-File
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();

            FiwareUrl = AppSettings["FiwareUrl"]; // Set Fiware Url
            BrokerUrl = AppSettings["BrokerUrl"]; // Set Broker Url
        }

        // Perform a request to an API by using GET
        public string PerformGetRequest(string? BaseUrl = "", string? Endpoint = "")
        {
            // BaseUrl represents the general URl of the API
            // Endpoint sets the specific target

            if (BaseUrl == null)
            {
                return "No base-URL set!";
            }

            using var httpClient = new HttpClient(); // Setup request
            var request = new HttpRequestMessage(HttpMethod.Get, BaseUrl + Endpoint);
            var response = httpClient.Send(request); // Perform request
            using var reader = new StreamReader(response.Content.ReadAsStream()); // Get data
            string Result = reader.ReadToEnd(); // Read it to a string

            return Result.Length > 0 ? Result : "Error reading from " + BaseUrl + Endpoint; // Return result or error
        }

        // Perform a request to an API by using DELETE
        public string PerformDeleteRequest(string? BaseUrl = "", string? Endpoint = "")
        {
            // BaseUrl represents the general URl of the API
            // Endpoint sets the specific target

            if (BaseUrl == null)
            {
                return "No base-URL set!";
            }

            using var httpClient = new HttpClient(); // Setup request
            var request = new HttpRequestMessage(HttpMethod.Delete, BaseUrl + Endpoint);
            var response = httpClient.Send(request); // Perform request
            using var reader = new StreamReader(response.Content.ReadAsStream()); // Get data
            string Result = reader.ReadToEnd(); // Read it to a string

            return Result.Length > 0 ? Result : "Error reading from " + BaseUrl + Endpoint; // Return result or error
        }

        // Perform a request to an API by using PUT
        public string PerformPutRequest(string? BaseUrl = "", string? Endpoint = "", string payload = "")
        {
            // BaseUrl represents the general URl of the API
            // Endpoint sets the specific target

            if (BaseUrl == null)
            {
                return "No base-URL set!";
            }

            using var httpClient = new HttpClient(); // Setup request
            var request = new HttpRequestMessage(HttpMethod.Put, BaseUrl + Endpoint);
            request.Content = new StringContent("\"" + payload + "\"");
            var response = httpClient.Send(request); // Perform request
            using var reader = new StreamReader(response.Content.ReadAsStream()); // Get data
            string Result = reader.ReadToEnd(); // Read it to a string

            return Result.Length > 0 ? Result : "Error reading from " + BaseUrl + Endpoint; // Return result or error
        }

        // The following methods call specific parts of the APIs and should self-explanatory
        public string GetFiwareVersion()
        {
            return PerformGetRequest(FiwareUrl, "version");           
        }

        public string GetEntryPoints()
        {
            return PerformGetRequest(FiwareUrl, "v2");
        }

        public string GetEntities()
        {
            return PerformGetRequest(FiwareUrl, "v2/entities");
        }

        public string GetTypes()
        {
            return PerformGetRequest(FiwareUrl, "v2/types");
        }

        public string GetSubscriptions()
        {
            return PerformGetRequest(FiwareUrl, "v2/subscriptions");
        }

        public string GetRegistrations()
        {
            return PerformGetRequest(FiwareUrl, "v2/registrations");
        }

        public string GetWorkorders()
        {
            return PerformGetRequest(FiwareUrl, "v2/entities?type=WorkOrder");
        }

        public string GetRobotById(string Id = "")
        {
            return PerformGetRequest(FiwareUrl, "robot/" + Id);
        }

        public string GetWorkstationById(string Id = "")
        {
            return PerformGetRequest(FiwareUrl, "station/work/" + Id);
        }

        public string GetEntityById(string Id = "")
        {
            return PerformGetRequest(FiwareUrl, "/v2/entities/" + Id);
        }

        public string GetEntityByType(string Type = "")
        {
            return PerformGetRequest(FiwareUrl, "/v2/entities/?type=" + Type);
        }

        public string UpdateEntityById(string Id = "", string value = "", string payload = "")
        {
            return PerformPutRequest(FiwareUrl, "v2/entities/" + Id + "/attrs/" + value, payload);
        }

        public string DeleteEntityById(string Id = "")
        {
            return PerformDeleteRequest(FiwareUrl, "v2/entities/" + Id);
        }

    }
}