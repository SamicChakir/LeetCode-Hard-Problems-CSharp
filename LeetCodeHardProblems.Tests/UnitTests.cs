using System;
using NUnit.Framework;
using System.Linq;
namespace LeetCodeHardProblems.Tests
    
{

    public class UnitTests
    {
        [Test]
        public void PrintHelloWorld()
        {
            Console.WriteLine("Hello world !");
        }
        [Test]
        public void TestProductofArrayExceptSelf()
        {
            var nums = new int[] { 1, 2, 3, 4 };
            Assert.AreEqual("[24,12,8,6]", Helpers.TransformArray(ProductofArrayExceptSelf.ProductExceptSelf(nums)));

            var numsSecond = new int[] { -1, 1, 0, -3, 3 };
            Assert.AreEqual("[0,0,9,0,0]", Helpers.TransformArray(ProductofArrayExceptSelf.ProductExceptSelf(numsSecond)));
        }
        [Test]
        public void TestSpiralMatrix()
        {
            var matrix = new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[] { 7, 8, 9 } };
            Assert.AreEqual("[1,2,3,6,9,8,7,4,5]", Helpers.TransformArray(SpiralMatrix.SpiralOrder(matrix).ToArray()));
            var matrixSec = new int[][] { new int[] { 1, 2, 3, 4 }, new int[] { 5, 6, 7, 8 }, new int[] { 9, 10, 11, 12 } };
            Assert.AreEqual("[1,2,3,4,8,12,11,10,9,5,6,7]", Helpers.TransformArray(SpiralMatrix.SpiralOrder(matrixSec).ToArray()));
            var matrixThird = new int[][] { new int[] { 1, 2 }, new int[] { 3, 4 } };
            Assert.AreEqual("[1,2,4,3]", Helpers.TransformArray(SpiralMatrix.SpiralOrder(matrixThird).ToArray()));
        }
        [Test] 
        public void TestSum4()
        {
            Assert.AreEqual(2, Sum4.FourSumCount(new int[] { 1, 2 }, new int[] { -2, -1 }, new int[] { -1, 2 }, new int[] { 0, 2 }));
            Assert.AreEqual(1, Sum4.FourSumCount(new int[] { 0 }, new int[] { 0 }, new int[] { 0 }, new int[] { 0 }));
            Assert.AreEqual(132, Sum4.FourSumCount(new int[] { -1,1,1,1,-1 }, new int[] { 0,-1,-1,0,1 }, new int[] { -1,-1,1,-1,-1 }, new int[] { 0,1,0,-1,-1 }));
        }
        [Test]
        public void TestContainerWithMostWater()
        {
            Assert.AreEqual(36, ContainerWithMostWater.MaxArea(new int[] { 2, 3, 10, 5, 7, 8, 9 }));
            Assert.AreEqual(4, ContainerWithMostWater.MaxArea(new int[] { 1, 2, 4, 3 }));
            Assert.AreEqual(49, ContainerWithMostWater.MaxArea(new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 }));
            Assert.AreEqual(1, ContainerWithMostWater.MaxArea(new int[] { 1,1 }));
            Assert.AreEqual(16, ContainerWithMostWater.MaxArea(new int[] { 4, 3, 2, 1, 4 }));
            Assert.AreEqual(2, ContainerWithMostWater.MaxArea(new int[] { 1, 2, 1 }));
        }

        [Test]
        public void TestLongestConsecutiveSequence()
        {

            Assert.AreEqual(7, LongestConsecutiveSequence.LongestConsecutiveFunction(new int[] { 9, 1, 4, 7, 3, -1, 0, 5, 8, -1, 6 }));
            Assert.AreEqual(4, LongestConsecutiveSequence.LongestConsecutiveFunction(new int[] { 100, 4, 200, 1, 3, 2 }));
            Assert.AreEqual(9, LongestConsecutiveSequence.LongestConsecutiveFunction(new int[] { 0, 3, 7, 2, 5, 8, 4, 6, 0, 1 }));
            Assert.AreEqual(2, LongestConsecutiveSequence.LongestConsecutiveFunction(new int[] { 1, 3, 4, 2, 2, 2, 2 }));

        }
        [Test]
        public void TestFindDuplicateNumber()
        {
            Assert.AreEqual(2, FindDuplicateNumber.FindDuplicate(new int[] { 1, 3, 4, 2, 2, 2, 2 }));
        }

        [Test]
        public void TestMinSubstring()
        {
            //Assert.AreEqual("aaa", MinimumWindowSubstring.MinWindow("aaflslflsldkalskaaa", "aaa"));
            //"aaaaaaaaaaaabbbbbcdd"
            //"abcdd"
            Assert.AreEqual("abbbbbcdd", MinimumWindowSubstring.MinWindow("aaaaaaaaaaaabbbbbcdd", "abcdd"));
        }

            

    }
}
