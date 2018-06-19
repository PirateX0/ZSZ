using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Long.Utilities;
using ZSZ.Service;
using System.IO;

namespace LongUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Assert.AreEqual(2, MathHelper.Add(1, 1));
            //Assert.AreEqual(3, MathHelper.Add(1, 1));

            File.Create("testClean.txt").Close();
            Assert.IsTrue(File.Exists("testClean.txt"));
            Console.WriteLine("ok");
            File.Delete("testClean.txt");
        }

        [TestCleanup]
        public void Clean()
        {
            if (File.Exists("testClean.txt"))
            {
                File.Delete("testClean.txt");
            }
            Console.WriteLine("cleaned.");
        }
    }
}
