namespace ConfigDotNet.ObjectModel.Tests.TestClass
{
    [ConfigurationModel<int>]
    public class Mock
    {
        [Section("0")] public int A { get; set; } = 0;
        [Section("1")] public int B { get; set; } = 1;
        [Section("2")] public int C { get; set; } = 2;
        [Section("3")] public int D { get; set; } = 3;
        [Section("4")] public int E { get; set; } = 4;
        [Section("5")] public int F { get; set; } = 5;
    }
}
