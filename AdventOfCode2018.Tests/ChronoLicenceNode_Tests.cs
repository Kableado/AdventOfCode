using Xunit;

namespace AdventOfCode2018.Tests
{
    public class ChronoLicenceNode_Tests
    {
        [Fact]
        public void BuildFromIntStream__Test()
        {
            Day08 day = new Day08();

            IntStream values = new IntStream("2 3 0 3 10 11 12 1 1 0 1 99 2 1 1 2");
            ChronoLicenceNode result = ChronoLicenceNode.BuildFromIntStream(values);

            Assert.Equal(2, result.Childs.Count);
            Assert.Equal(3, result.Metadata.Count);
            Assert.Equal(1, result.Metadata[0]);
            Assert.Equal(1, result.Metadata[1]);
            Assert.Equal(2, result.Metadata[2]);

            Assert.Equal(0, result.Childs[0].Childs.Count);
            Assert.Equal(3, result.Childs[0].Metadata.Count);
            Assert.Equal(10, result.Childs[0].Metadata[0]);
            Assert.Equal(11, result.Childs[0].Metadata[1]);
            Assert.Equal(12, result.Childs[0].Metadata[2]);

            Assert.Equal(1, result.Childs[1].Childs.Count);
            Assert.Equal(1, result.Childs[1].Metadata.Count);
            Assert.Equal(2, result.Childs[1].Metadata[0]);

            Assert.Equal(0, result.Childs[1].Childs[0].Childs.Count);
            Assert.Equal(1, result.Childs[1].Childs[0].Metadata.Count);
            Assert.Equal(99, result.Childs[1].Childs[0].Metadata[0]);
        }
    }
}