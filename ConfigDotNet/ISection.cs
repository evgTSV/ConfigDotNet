// Licensed to the HardDriveS under one or more agreements.
// The HardDriveS licenses this file to you under the MIT license.

namespace ConfigDotNet
{
    /// <summary>
    /// Defines properties that provides access to Key and Value
    /// </summary>
    public interface ISection<out TKey, out TValue>
    {
        TKey Key { get; }
        TValue Value { get; }
    }
}
