using System.Reflection;

namespace ConfigDotNet.ObjectModel.Exceptions
{
    public class InvalidModelException(Type modelType, string reason)
        : Exception($"Invalid model ({modelType.FullName}) Reason:{reason}")
    {
        public TypeInfo TypeInfo { get; init; } = modelType.GetTypeInfo();
    }
}