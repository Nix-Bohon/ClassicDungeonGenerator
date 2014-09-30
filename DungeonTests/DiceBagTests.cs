using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassicDungeonGenerator.Models;

namespace DungeonTests
{
    [TestClass]
    public class DiceBagTests
    {
        [TestMethod]
        public void TestRollRanges()
        {
            DiceBag d = DiceBag.getDice();
            int iterations = 1000;
            Action<int> test; 
            test = getRangeTest(1, 4, "d4()");
            for (int i = 0; i < iterations; i++)
            {
                test(d.d4());
            }
            test = getRangeTest(1, 6, "d6()");
            for (int i = 0; i < iterations; i++)
            {
                test(d.d6());
            }
            test = getRangeTest(1, 8, "d8()");
            for (int i = 0; i < iterations; i++)
            {
                test(d.d8());
            }
            test = getRangeTest(1, 10, "d10()");
            for (int i = 0; i < iterations; i++)
            {
                test(d.d10());
            }
            test = getRangeTest(1, 12, "d12()");
            for (int i = 0; i < iterations; i++)
            {
                test(d.d12());
            }
            test = getRangeTest(1, 20, "d20()");
            for (int i = 0; i < iterations; i++)
            {
                test(d.d20());
            }
        }
        private void ResultInRange(int min, int max, int value, String message)
        {

        }

        private Action<int> getRangeTest(int min, int max, String msg)
        {
            return delegate(int val)
            {
                Assert.IsTrue(val >= min, msg + ": {0} >= {1}", val, min);
                Assert.IsTrue(val <= max, msg + ": {0} <= {1}", val, max);
            };
        }
    }
}
