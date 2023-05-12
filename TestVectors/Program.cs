using System;

namespace InputParser // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        public static List<List<Object>> GetSampleVectors(List<TestPointCollection> testPointCollections){
        List<List<Object>> vectors = new List<List<Object>>();
        Console.WriteLine(testPointCollections.Count());
        for(int i=0; i<testPointCollections[0].TestPoints.Count(); i++){
            for(int j=0; j<testPointCollections[1].TestPoints.Count(); j++){
                for(int k=0; k<testPointCollections[2].TestPoints.Count(); k++){
                    for(int z=0; z<testPointCollections[3].TestPoints.Count(); z++){
                        List<Object> vector = new List<Object>{
                            testPointCollections[0].TestPoints[i].Value,
                            testPointCollections[1].TestPoints[j].Value,
                            testPointCollections[2].TestPoints[k].Value,
                            testPointCollections[3].TestPoints[z].Value,
                        };
                        vectors.Append(vector);
                    }
                }
            }
        }
        return vectors;
    }


        static List<List<List<Object>>> getProjectSampleVectors(Rootobject rootobject) {
            Project project = rootobject.Project;
            List<TestPointCollection> testPointCollections = rootobject.TestPointCollections.ToList();
            List<List<List<Object>>> sampleVectors = new List<List<List<object>>>();
            foreach(Sample sample in project.Samples){
                List<TestPointCollection> sampleTPCS = new List<TestPointCollection>();
                foreach(TestPointCollection testPointCollection in testPointCollections){
                    if(testPointCollection.SampleIds.Contains(sample.Id)){
                        sampleTPCS.Add(testPointCollection);
                    }
                }
                sampleVectors.Append(GetSampleVectors(sampleTPCS));
            }
            return sampleVectors;
        }

        static void Main(string[] args)
        {
            ReadAndParse parser = new ReadAndParse("./Demo.json");
            List<List<List<Object>>> sampleVectors = getProjectSampleVectors(parser.Read());
            foreach(var sample in sampleVectors){
                System.Console.WriteLine();
                System.Console.WriteLine();
                foreach(var sampleVector in sample){
                    System.Console.WriteLine();
                    System.Console.WriteLine(String.Join(' ', sampleVector));
                }
            }
        }
    }
}