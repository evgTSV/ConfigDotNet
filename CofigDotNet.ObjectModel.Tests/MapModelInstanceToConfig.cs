using ConfigDotNet.ObjectModel.Tests.TestClass;
using System.Diagnostics;

namespace ConfigDotNet.ObjectModel.Tests
{
    public class MapModelInstanceToConfig
    {
        [Fact]
        public void ValidMockModelMappingTest()
        {
            Mock instance = new Mock();

            var expected = new Configuration<int>(new Dictionary<string, int>()
            {
                { "0", 0 },
                { "1", 1 },
                { "2", 2 },
                { "3", 3 },
                { "4", 4 },
                { "5", 5 }
            });

            Configuration<int> actual = ConfigurationMapper.MapToConfig<Mock, int>(instance);

            Debug.Assert(expected.Base.Count == actual.Base.Count);

            foreach (var item in expected)
            {
                Assert.Equal(item.Key, actual[item.Key].Key);
                Assert.Equal(item.Value, actual[item.Key].Value);
            }
        }

        [Fact]
        public void ValidUserConfigMappingTest()
        {
            var expected = new Configuration<string>(new Dictionary<string, string>()
            {
                { "Name", "Sigma" },
                { "Email", "sigma@gmail.com" },
                { "Secret_Pass", "123" }
            });

            var userConfig = new UserConfig()
            {
                Name = "Sigma",
                Email = "sigma@gmail.com",
                Password = "123"
            };

            Configuration<string> actual = ConfigurationMapper.MapToConfig<UserConfig, string>(userConfig);

            Debug.Assert(expected.Base.Count == actual.Base.Count);

            foreach (var item in expected)
            {
                Assert.Equal(item.Key, actual[item.Key].Key);
                Assert.Equal(item.Value, actual[item.Key].Value);
            }
        }
    }
}
