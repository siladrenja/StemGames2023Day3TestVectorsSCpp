using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace InputParser
{
    internal class ReadAndParse
    {

        private readonly string _sampleJsonFilePath;
        public ReadAndParse(string sampleJsonFilePath)
        {
            _sampleJsonFilePath = sampleJsonFilePath;
        }

        private readonly JsonSerializerOptions _options = new()
        {
            PropertyNameCaseInsensitive = true
        };


        //public List<Project> UseFileReadAllTextWithSystemTextJson()
        //{
        //    string json = File.ReadAllText(_sampleJsonFilePath);
        //    json = "[" + json + "]";
        //    List<Project> teachers = JsonSerializer.Deserialize<List<Project>>(json, _options);
        //    return teachers;
        //}

        public Rootobject Read()
        {
            //string json = File.ReadAllText(_sampleJsonFilePath);
            //json = "[" + json + "]";
            //return JsonConvert.DeserializeObject<Project>(json);


            string jsonString = File.ReadAllText(_sampleJsonFilePath);
            return JsonSerializer.Deserialize<Rootobject>(jsonString);

        }
        
    }
}
