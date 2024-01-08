using ConfigDotNet.ObjectModel.Tests.TestClass;

namespace ConfigDotNet.ObjectModel.Tests
{
    public class ModelTests
    {
        [Fact]
        public void PropsInitializeTest()
        {
            var model = new Model<Mock, int>();

            Assert.NotNull(model.PropsSections);
        }
    }
}
