// Licensed to the HardDriveS under one or more agreements.
// The HardDriveS licenses this file to you under the MIT license.

using System.Reflection;

namespace ConfigDotNet.ObjectModel.Exceptions
{
    public class InvalidModelException(Type modelType, string reason)
        : Exception($"Invalid model ({modelType.FullName}) Reason:{reason}")
    {
        public TypeInfo TypeInfo { get; init; } = modelType.GetTypeInfo();
    }
}