using System;
using Xunit;

namespace UrlMapper.Tests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("https://mana.com/linkto/{link-id}", "https://mana.com/linkto/A2348", true)]
        [InlineData("https://mana.com/linkto/{link-id}", "https://mana.com/lidddnkto/A2348", false)]
        [InlineData("https://mana.com/linkto/{link-id}/home/controller/", "https://mana.com/linkto/A2348/home/controller/", true)]
        [InlineData("https://mana.com/linkto/{link-id}/home/controller/{id}", "https://mana.com/linkto/A2348/home/controller/88", true)]
        public void Test1(string pattern, string target, bool expected)
        {
            var parambuilder = new SimpleStringParameterBuilder();
            var param = parambuilder.Parse(pattern);

            var result = param.IsMatched(target);
            Assert.Equal(expected, result);
        }
    }
}
