using ConfigDotNet.ObjectModel.Exceptions;
using ConfigDotNet.ObjectModel.Tests.TestClass;

namespace ConfigDotNet.ObjectModel.Tests
{
    public class MapConfigToModelTest
    {
        private static readonly Configuration<string> Config = new(new Dictionary<string, string>()
        {
            { "Name", "Bob" },
            { "Email", "bob@outlook.com" },
            { "Secret_Pass", "qwerty123" }
        });

        [Fact]
        public void ValidMapTest()
        {
            UserConfig expected = new UserConfig()
            {
                Email = "bob@outlook.com",
                Name = "Bob",
                Password = "qwerty123"
            };

            UserConfig actual = ConfigurationMapper.MapToModel<UserConfig, string>(Config);

            Assert.Equal(expected, actual, new UserConfigComparer());
        }

        [Fact]
        public void IfModelWithoutAttributeThrowException()
        {
            var wa = new WithoutAttribute();

            Assert.Throws<MappingException>(() => ConfigurationMapper.MapToModel<WithoutAttribute, string>(Config));
        }

        [Fact]
        public void IfModelNotHaveNonParametrizedConstructorThrowException()
        {
            var wa = new DontHaveANonParametrizedConstructor(false);

            Assert.Throws<MappingException>(() => ConfigurationMapper.MapToModel<DontHaveANonParametrizedConstructor, string>(Config));
        }
    }
}