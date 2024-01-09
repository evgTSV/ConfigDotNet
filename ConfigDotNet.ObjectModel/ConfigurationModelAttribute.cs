// Licensed to the HardDriveS under one or more agreements.
// The HardDriveS licenses this file to you under the MIT license.

namespace ConfigDotNet.ObjectModel;

[AttributeUsage(
    AttributeTargets.Class,
    AllowMultiple = false, Inherited = false)]
public sealed class ConfigurationModelAttribute<T> : Attribute {}