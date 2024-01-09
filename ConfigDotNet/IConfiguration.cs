// Licensed to the HardDriveS under one or more agreements.
// The HardDriveS licenses this file to you under the MIT license.

namespace ConfigDotNet
{
    /// <summary>
    /// Defines methods that provides access to <see cref="ISection{TKey, TValue}"/>
    /// </summary>
    public interface IConfiguration<TKey, out TValue> : IEnumerable<ISection<TKey, TValue>>
    {
        public ISection<TKey, TValue> GetSection(TKey key);
        public ISection<TKey, TValue> this[TKey key] { get; }
    }
}
