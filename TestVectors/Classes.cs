
namespace InputParser // Note: actual namespace depends on the project name.
{
    public class Rootobject
    {
        public Project Project { get; set; }
        public TestPointCollection[] TestPointCollections { get; set; }
    }

    public class Project
    {
        public string Name { get; set; }
        public Sample[] Samples { get; set; }
        public InputCondition[] InputConditions { get; set; }
        public int Id { get; set; }
    }

    public class Sample
    {
        public string FamilyName { get; set; }
        public string ProductName { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }
    }

    public class InputCondition
    {
        public string Parameter { get; set; }
        public float Min { get; set; }
        public float Typical { get; set; }
        public float Max { get; set; }
        public float TimeBetweenPoints { get; set; }
        public int Id { get; set; }
    }

    public class TestPointCollection
    {
        public int InputConditionId { get; set; }
        public int[] SampleIds { get; set; }
        public TestPoint[] TestPoints { get; set; }
        public int Id { get; set; }
    }

    public class TestPoint
    {
        public float Value { get; set; }
        public string Unit { get; set; }
    }
}