using System.Collections.Frozen;
using System.Collections.ObjectModel;
using System.Diagnostics;
using static ConfigDotNet.Constants;

namespace ConfigDotNet
{
    /// <summary>
    /// Helps to create <see cref="Configuration{T}"/>
    /// </summary>
    internal static class ConfigurationBuildHelper
    {
        /// <summary>
        /// Helps to create readonly dictionary
        /// </summary>
        /// <remarks>
        /// Choice better readonly dictionary for keeping sections (only .NET 8 or greater)
        /// </remarks>
        /// <param name="keys">Keys of sections</param>
        /// <param name="values">Values of sections</param>
        /// <returns>Return readonly dictionary</returns>
        internal static IReadOnlyDictionary<string, T> CreateDictionary<T>(IEnumerable<string> keys, IEnumerable<T> values)
        {
            Debug.Assert(keys.Count() == values.Count());

            return CreateDictionary(
                  keys.Zip(values, (key, value) => new { key, value })
                  .ToDictionary((pair) => pair.key, (pair) => pair.value));
        }

        /// <summary>
        /// Helps to create readonly dictionary
        /// </summary>
        /// <remarks>
        /// Choice better readonly dictionary for keeping sections (only .NET 8 or greater)
        /// </remarks>
        /// <param name="sections">Dictionary of sections</param>
        /// <returns>Return readonly dictionary</returns>
        internal static IReadOnlyDictionary<string, T> CreateDictionary<T>(IDictionary<string, T> sections)
        {
            if (sections.Count > MaxSectionsInSmallConfig)
            {
#if NET8_0_OR_GREATER
                return sections.ToFrozenDictionary();
#endif
            }

            return new ReadOnlyDictionary<string, T>(sections);
        }
    }
}
