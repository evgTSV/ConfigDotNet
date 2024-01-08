namespace ConfigDotNet.ObjectModel;

[AttributeUsage(
    AttributeTargets.Class,
    AllowMultiple = false, Inherited = false)]
public sealed class ConfigurationModelAttribute<T> : Attribute {}