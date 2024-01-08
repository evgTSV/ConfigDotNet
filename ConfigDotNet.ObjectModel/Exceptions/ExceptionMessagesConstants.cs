namespace ConfigDotNet.ObjectModel.Exceptions
{
    /// <summary>
    /// Class that keeps an exceptions messages
    /// </summary>
    internal static class ExceptionMessagesConstants
    {
        internal const string ModelNotHaveParameterlessConstructor = "Model not have a public parameterless constructor, pls chek your model";
        internal const string ModelNotHaveConfigurationModelAttribute = $"Model not have a {nameof(ConfigurationModelAttribute<object>)}";

        internal const string InvalidModelMapping = "Invalid model mapping, pls chek inner exception for more information";
    }
}
