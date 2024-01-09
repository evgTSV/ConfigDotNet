// Licensed to the HardDriveS under one or more agreements.
// The HardDriveS licenses this file to you under the MIT license.

using System.Collections;

namespace ConfigDotNet
{
    /// <summary>
    /// Represents class, that keep config sections
    /// </summary>
    public class Configuration<T> : IConfiguration<string, T>, IEquatable<Configuration<T>>
    {
        private readonly IReadOnlyDictionary<string, T> _configuration;

        public Configuration(IDictionary<string, T> sections)
        {
            _configuration = ConfigurationBuildHelper.CreateDictionary(sections);
        }

        public Configuration(IEnumerable<string> keys, IEnumerable<T> values)
        {
            _configuration = ConfigurationBuildHelper.CreateDictionary(keys, values);
        }

        public Configuration(IEnumerable<Section<T>> sections)
            : this(sections.ToDictionary((s) => s.Key, (s) => s.Value)) { }

        /// <summary>
        /// Collection, that keep sections
        /// </summary>
        public IReadOnlyDictionary<string, T> Base => _configuration;

        ISection<string, T> IConfiguration<string, T>.this[string key] 
            => GetSection(key);
        ISection<string, T> IConfiguration<string, T>.GetSection(string key)
            => GetSection(key);

        public Section<T> this[string key] => GetSection(key);

        /// <summary>
        /// Returns Section`1 by name
        /// </summary>
        /// <param name="sectionName">Name of section</param>
        /// <returns></returns>
        public Section<T> GetSection(string sectionName)
            => new(sectionName, _configuration[sectionName]);

        public override bool Equals(object? obj)
        {
            if (obj is Configuration<T> config)
            {
                return Equals(config);
            }

            return false;
        }

        public bool Equals(Configuration<T>? other)
        {
            if (other is null) return false;
            return ReferenceEquals(this, other) || _configuration.Equals(other._configuration);
        }

        public static bool operator ==(Configuration<T> left, Configuration<T> right)
            => left.Equals(right);

        public static bool operator !=(Configuration<T> left, Configuration<T> right)
            => !left.Equals(right);

        public override int GetHashCode()
        {
            return _configuration.GetHashCode();
        }

        public IEnumerator<ISection<string, T>> GetEnumerator()
            => _configuration.Select(pair => (ISection<string, T>)(new Section<T>(pair.Key, pair.Value)))
               .GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        IEnumerator<ISection<string, T>> IEnumerable<ISection<string, T>>.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
