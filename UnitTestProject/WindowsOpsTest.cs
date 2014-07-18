using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WallChanger;

namespace UnitTestProject
{
    [TestClass]
    public class WindowsOpsTest
    {
        public static string BaseDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + @"\BackgroundChanger\";

        [TestMethod]
        public void TestCreateLocalPath()
        {
            string tag = "nature";
            WindowsOps.CreateLocalPath(tag);
            tag = "multi word test";
            WindowsOps.CreateLocalPath(tag);
        }

        [TestMethod]
        public void TestLoadTags()
        {
            var tags = WindowsOps.LoadTags();
            Assert.IsNotNull(tags);
        }

        [TestMethod]
        public void TestChangeWall()
        {
            string[] tags =
            {
                "nature",
            };
            WindowsOps.ChangeWall(tags);
        }
    }
}