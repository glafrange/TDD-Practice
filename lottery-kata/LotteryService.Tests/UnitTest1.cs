using NUnit.Framework;
using LotteryService;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        Class1 _testService = new Class1();
        [Test]
        public void return_Array()
        {
            int[]lotteryNumbers0 = new int[0];
            var output = _testService.SortNumbers(lotteryNumbers0);
            Assert.AreEqual(new int[0], output);
        }

        [Test]
        public void return_OneNumSorted()
        {
            int[] lotterNumbers1 = new int[1] { 1 };
            var output = _testService.SortNumbers(lotterNumbers1);
            var expectedOutput = new int[1] { 1 };
            Assert.AreEqual(expectedOutput, output);
        }
        
        [Test]
        public void return_TwoNumsSorted()
        {
            int[] lotterNumbers1 = new int[2] { 3, 1 };
            var output = _testService.SortNumbers(lotterNumbers1);
            var expectedOutput = new int[2] { 1, 3 };
            Assert.AreEqual(expectedOutput, output);
        }

        [Test]
        public void return_ThreeNumsSorted()
        {
            int[] lotterNumbers1 = new int[3] { 6, 3, 1 };
            var output = _testService.SortNumbers(lotterNumbers1);
            var expectedOutput = new int[3] { 1, 3, 6 };
            Assert.AreEqual(expectedOutput, output);
        }

        [Test]
        public void return_TenNumsSorted()
        {
            int[] lotterNumbers1 = new int[10] { 10, 9, 8, 7, 6, 5, 4, 3, 1, 2 };
            var output = _testService.SortNumbers(lotterNumbers1);
            var expectedOutput = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Assert.AreEqual(expectedOutput, output);
        }
    }
}