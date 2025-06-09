namespace UnitTests
{
    [TestClass]
    public sealed class TestDay2Part2
    {
        [TestMethod]
        public void CheckIfReportIsSafe_FirstLevelMustBeRemoved_Index2IsReturned()
        {
            var levelIndexOrSuccess = Day02Part2.CheckIfReportIsSafe(["44", "41", "42", "44"]);

            Assert.AreEqual(2, levelIndexOrSuccess);
        }

        [TestMethod]
        public void CheckIfReportIsSafe_ReportIsSafe_SuccessIsReturned()
        {
            var levelIndexOrSuccess = Day02Part2.CheckIfReportIsSafe(["12", "13", "14", "15"]);

            Assert.AreEqual(-1, levelIndexOrSuccess);
        }
    }
}
