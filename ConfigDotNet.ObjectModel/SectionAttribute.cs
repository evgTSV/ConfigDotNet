// Licensed to the HardDriveS under one or more agreements.
// The HardDriveS licenses this file to you under the MIT license.

namespace ConfigDotNet.ObjectModel;

/// <summary>
/// Marks the field or prop that will be taken into account during configuration mapping
/// </summary>
/// <remarks>
/// <c>WARNING!</c> Fields are not given their name by default, please specify them in the constructor
/// </remarks>
/// <param name="sectionName">Override the name of section (default use name of member)</param>
[AttributeUsage(
    AttributeTargets.Field | AttributeTargets.Property,
    AllowMultiple = false, Inherited = false)]
public sealed class SectionAttribute([System.Runtime.CompilerServices.CallerMemberName] string? sectionName = null) : Attribute
{
    public string? SectionName { get; init; } = sectionName;
}