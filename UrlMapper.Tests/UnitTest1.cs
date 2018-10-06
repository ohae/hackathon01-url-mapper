using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace UrlMapper.Tests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("https://mana.com/linkto/{link-id}")]
        [InlineData("https://mana.com/linkdddto/{link-id}")]
        [InlineData("https://mana.com/linkto/{link-id}")]
        [InlineData("https://msdfsdfddlinkto/{link-id}")]
        public void SimpleStringParameterBuilderParsingCompleted(string pattern)
        {
            var parambuilder = new SimpleStringParameterBuilder();
            var param = parambuilder.Parse(pattern);

            Assert.NotNull(param);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void SimpleStringParameterBuilderParsingFail(string pattern)
        {
            var parambuilder = new SimpleStringParameterBuilder();
            var param = parambuilder.Parse(pattern);

            Assert.Null(param);
        }

        [Theory]
        [InlineData("https://mana.com/linkto/{link-id}/home/api/{username}", "https://mana.com/linkto/A23/d5dd658d48/home/api/sirinarin@gmail.com/d/d5d8d/d9d5d", true)]
        [InlineData("https://mana.com/linkto/{link-id}", "https://mana.com/linkto/A2348", true)]
        [InlineData("https://mana.com/linkto/{link-id}/home/api/{username}", "https://mana.com/linkto/A2348/home/api/sirinarin@gmail.com", true)]
        [InlineData("https://mana.com/linkto/{link-id}", "https://mana.com/lidddnkto/A2348", false)]
        [InlineData("https://mana.com/linkto/{link-id}/home/controller/", "https://mana.com/linkto/A2348/home/controller/", true)]
        [InlineData("https://mana.com/linkto/{link-id}/home/controller/{id}", "https://mana.com/linkto/A2348/home/controller/88", true)]
        public void IsMatchOk(string pattern, string target, bool expected)
        {
            var parambuilder = new SimpleStringParameterBuilder();
            var param = parambuilder.Parse(pattern);

            var result = param.IsMatched(target);
            Assert.Equal(expected, result);
        }


        [Theory]
        [InlineData("https://mana.com/linkto/{link-id}", "https://mana.com/linkto/A2348", "{link-id}", "A2348")]
        [InlineData("https://mana.com/linkto/aa{link-id}", "https://mana.com/linkto/A2348", "{aalink-id}", "A2348")]
        [InlineData("https://mana.com/linkto/{link-id}aa", "https://mana.com/linkto/A2348", "{link-idaa}", "A2348")]
        [InlineData("https://mana.com/linkto/aa{link-id}aa", "https://mana.com/linkto/A2348", "{aalink-idaa}", "A2348")]
        [InlineData("https://mana.com/linkto/aa{link-id}aa/ddd", "https://mana.com/linkto/A2348/ddd", "{aalink-idaa}", "A2348")]
        [InlineData("https://mana.com/linkto/{link-id}/home/api/{username}",
            "https://mana.com/linkto/A23/d5dd658d48/home/api/sirinarin@gmail.com/d/d5d8d/d9d5d",
            "{link-id},{username}", "A23/d5dd658d48,sirinarin@gmail.com/d/d5d8d/d9d5d")]
        public void ExtractValue(string pattern, string target, string keys, string values)
        {
            Dictionary<string, string> expected = new Dictionary<string, string>();
            var keyyyy = keys.Split(',');
            var valuee = values.Split(',');
            for (int i = 0; i < keyyyy.Length; i++)
            {
                expected.Add(keyyyy[i], valuee[i]);
            }

            var parambuilder = new SimpleStringParameterBuilder();
            var param = parambuilder.Parse(pattern);

            Dictionary<string, string> dict = new Dictionary<string, string>();

            //param.IsMatched(target);
            param.ExtractVariables(target, dict);

            expected.Should().BeEquivalentTo(dict);
        }

    }
}
