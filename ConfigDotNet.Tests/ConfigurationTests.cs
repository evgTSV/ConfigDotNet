using MoreLinq;
using System.Collections.ObjectModel;

namespace ConfigDotNet.Tests
{
    public class ConfigurationTests
    {
        [Fact]
        public void InitializationConfigurationTest()
        {
            var sections = new Dictionary<string, int>
            {
                { "gc_GenerationsCount", 3 },
                { "gc_EnableBackground", 1 },
                { "gc_EnableLOHCompress", 0 },
                { "gc_ServerMode", 0 }
            };

            var gcConfig = new Configuration<int>(sections);

            sections.ForEach((section) => Assert.Equal(section.Value, gcConfig.GetSection(section.Key).Value));
        }

        [Fact]
        public void UseNotReadOnlyDictionaryWhenSectionsMoreThanThreshold()
        {
            var sections = new Dictionary<string, int>();
            for (int i = 0; i < Constants.MaxSectionsInSmallConfig + 1; i++)
            {
                sections.Add(i.ToString(), i);
            }

            var config = new Configuration<int>(sections);

            Assert.NotEqual(typeof(ReadOnlyDictionary<string, int>), config.Base.GetType());
        }
    }
}