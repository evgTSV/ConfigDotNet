namespace ConfigDotNet.ObjectModel.Tests.TestClass;

[ConfigurationModel<string>]
public class UserConfig
{
    [Section("Email")] public string Email = null!;
    [Section] public string Name { get; set; } = null!;

    [Section("Secret_Pass")]
    public string Password { get; set; } = null!;
}