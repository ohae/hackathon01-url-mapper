using System;
using Xunit;

namespace UrlMapper.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var parambuilder = new SimpleStringParameterBuilder();
            var param = parambuilder.Parse("https://mana.com/linkto/{link-id}");

            var result = param.IsMatched("https://mana.com/linkto/A2348");

            Assert.True(result);
        }
    }
}
