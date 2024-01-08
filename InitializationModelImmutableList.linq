<Query Kind="Program">
  <Reference Relative="ConfigDotNet\bin\Debug\net8.0\ConfigDotNet.dll">E:\CSProj\ConfigDotNet\ConfigDotNet\bin\Debug\net8.0\ConfigDotNet.dll</Reference>
  <Reference Relative="ConfigDotNet.ObjectModel\bin\Debug\net8.0\ConfigDotNet.ObjectModel.dll">E:\CSProj\ConfigDotNet\ConfigDotNet.ObjectModel\bin\Debug\net8.0\ConfigDotNet.ObjectModel.dll</Reference>
  <Namespace>BenchmarkDotNet</Namespace>
  <Namespace>BenchmarkDotNet.Attributes</Namespace>
  <Namespace>BenchmarkDotNet.Configs</Namespace>
  <Namespace>BenchmarkDotNet.Diagnosers</Namespace>
  <Namespace>BenchmarkDotNet.Engines</Namespace>
  <Namespace>BenchmarkDotNet.Environments</Namespace>
  <Namespace>BenchmarkDotNet.Exporters</Namespace>
  <Namespace>BenchmarkDotNet.Jobs</Namespace>
  <Namespace>BenchmarkDotNet.Loggers</Namespace>
  <Namespace>BenchmarkDotNet.Reports</Namespace>
  <Namespace>BenchmarkDotNet.Running</Namespace>
  <Namespace>BenchmarkDotNet.Validators</Namespace>
  <Namespace>ConfigDotNet</Namespace>
  <Namespace>ConfigDotNet.ObjectModel</Namespace>
  <Namespace>System.Collections.Immutable</Namespace>
  <IncludeUncapsulator>false</IncludeUncapsulator>
  <RuntimeVersion>8.0</RuntimeVersion>
</Query>

#load "BenchmarkDotNet"
#nullable enable

void Main()
{
	"Start Benchmark".Dump();
	RunBenchmark(false);
}

[MemoryDiagnoser]
public class Model
    {
        [GlobalSetup]
        public void SetUp()
        {
            Dictionary<string, int> dict = [];

            for(int i = 0; i < 100000; i++)
            {
                dict.Add(i.ToString(), i);
            }

            _config = new Configuration<int>(dict);
        }

        private Configuration<int> _config = null!;

        [Benchmark]
        public void Initialize()
        {
            var modelType = typeof(Mock);

            PropsSections = (from prop in modelType.GetProperties()
                where prop.PropertyType == typeof(int) &&
                      prop.CanWrite &&
                      prop.GetCustomAttribute(typeof(SectionAttribute)) is not null
                select prop).ToImmutableList();
        }

        [Benchmark]
        public void CreateInstance()
        {
            var model = Activator.CreateInstance<Mock>();	

            foreach (var section in _config)
            {
                PropertyInfo? prop = PropsSections.FirstOrDefault(prop =>
                    ((SectionAttribute?)prop.GetCustomAttribute(typeof(SectionAttribute)))
                    !.SectionName == section.Key);

                prop?.SetValue(model, section.Value);
            }
        }
		
        private static ImmutableList<PropertyInfo> PropsSections { get; set; } = null!;
    }

[ConfigurationModel<int>]
public class Mock 
{
    [Section("0")] public int A { get; set; }
	[Section("1")] public int B { get; set; }
	[Section("2")] public int C { get; set; }
	[Section("3")] public int D { get; set; }
	[Section("4")] public int E { get; set; }
	[Section("5")] public int F { get; set; }
	[Section("6")] public int G { get; set; }
	[Section("7")] public int H { get; set; }
	[Section("8")] public int I { get; set; }
	[Section("9")] public int K { get; set; }
	[Section("10")] public int J { get; set; }
	[Section("11")] public int L { get; set; }
	[Section("12")] public int M { get; set; }
	[Section("13")] public int N { get; set; }
	[Section("14")] public int O { get; set; }
}
