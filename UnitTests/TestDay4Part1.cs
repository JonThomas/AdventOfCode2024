namespace UnitTests
{
    [TestClass]
    public sealed class TestDay4Part1
    {
        [TestMethod]
        public void CountRight_XmasIsFoundRightAtTheEnd_Success()
        {
            var row = new char[] { 'A', 'A', 'X', 'M', 'A', 'S' };
            Day04Part1.xmasBoardWidth = row.Length;

            var found = Day04Part1.CountRight(row, new Day04Part1.Point(44, 2));

            Assert.IsTrue(found);
        }

        [TestMethod]
        public void CountRight_XmasWithoutTheS_NotFound()
        {
            var row = new char[] { 'A', 'A', 'X', 'M', 'A' };
            Day04Part1.xmasBoardWidth = row.Length;

            var found = Day04Part1.CountRight(row, new Day04Part1.Point(44, 2));

            Assert.IsFalse(found);
        }

        [TestMethod]
        public void CountRight_Xmam_NotFound()
        {
            var row = new char[] { 'A', 'A', 'X', 'M', 'A', 'M' };
            Day04Part1.xmasBoardWidth = row.Length;

            var found = Day04Part1.CountRight(row, new Day04Part1.Point(44, 2));

            Assert.IsFalse(found);
        }

        [TestMethod]
        public void CountDown_XmasStartingAt2_Found()
        {
            var table = new char[][] {
                new char[]{ 'A' },
                new char[]{ 'X' }, 
                new char[]{ 'M' },
                new char[]{ 'A' },
                new char[]{ 'S' } 
            };
            Day04Part1.xmasBoardHeight = table.Length;

            var found = Day04Part1.CountDown(table, new Day04Part1.Point(1, 0));

            Assert.IsTrue(found);
        }

        [TestMethod]
        public void CountLeft_XmasIsFoundRightAtTheStart_Success()
        {
            var row = new char[] { 'S', 'A', 'M', 'X', 'A', 'S' };
            Day04Part1.xmasBoardWidth = row.Length;

            var found = Day04Part1.CountLeft(row, new Day04Part1.Point(44, 3));

            Assert.IsTrue(found);
        }

    }
}
