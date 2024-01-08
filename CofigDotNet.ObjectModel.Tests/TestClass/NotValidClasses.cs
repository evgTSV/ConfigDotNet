namespace ConfigDotNet.ObjectModel.Tests.TestClass
{
    public class WithoutAttribute
    {
        [Section] public string Name { get; set; } = null!;
        [Section] public string Description { get; set; } = null!;
        [Section] public string Type { get; set; } = null!;
    }

    [ConfigurationModel<string>]
    public class DontHaveANonParametrizedConstructor
    {
        public DontHaveANonParametrizedConstructor(bool dummy) {}

        [Section] public static string Prop { get; set; } = null!;
    }

    [ConfigurationModel<string>]
    public class NoMatchTypes
    {
        [Section] public int Number { get; set; }
    }
}
