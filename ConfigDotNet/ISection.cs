// Licensed to the HardDriveS under one or more agreements.
// The HardDriveS licenses this file to you under the MIT license.

namespace ConfigDotNet
{
    /// <summary>
    /// Defines properties that provides access to Key and Value
    /// </summary>
    public interface ISection<out TKey, out TValue>
    {
        /// <summary>
        /// Key of section
        /// </summary>
        TKey Key { get; }
        /// <summary>
        /// Value of section
        /// </summary>
        TValue Value { get; }
    }
}
