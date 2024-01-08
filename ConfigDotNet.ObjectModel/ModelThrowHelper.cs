using System.Diagnostics.CodeAnalysis;
using ConfigDotNet.ObjectModel.Exceptions;
using System.Reflection;
using static ConfigDotNet.ObjectModel.Exceptions.ExceptionMessagesConstants;

namespace ConfigDotNet.ObjectModel
{
    /// <summary>
    /// Represent a helper class that generates exceptions if the model not valid
    /// </summary>
    internal static class ModelThrowHelper
    {
        /// <exception cref="InvalidModelException"/>
        internal static void ThrowIfModelNotHaveParameterlessConstructor(Type modelType)
        {
            if (modelType.GetConstructor(BindingFlags.Public | BindingFlags.Instance, []) == null)
                ThrowInvalidModelException(modelType, ModelNotHaveParameterlessConstructor);
        }

        /// <exception cref="InvalidModelException"/>
        internal static void ThrowIfModelNotHaveConfigurationModelAttribute<TValue>(Type modelType)
        {
            if (modelType
                    .GetCustomAttribute(typeof(ConfigurationModelAttribute<TValue>)) == null)
                ThrowInvalidModelException(modelType, ModelNotHaveConfigurationModelAttribute);
        }

        [DoesNotReturn]
        private static void ThrowInvalidModelException(Type modelType, string reason)
            => throw new InvalidModelException(modelType, reason);
    }
}
