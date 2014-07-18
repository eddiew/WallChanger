using Microsoft.VisualStudio.TestTools.UnitTesting;
using WallChanger;

namespace UnitTestProject
{
    [TestClass]
    public class WindowsOpsTest
    {
        [TestMethod]
        public void TestCreateLocalPath()
        {
            string tag = "nature";
            WindowsOps.CreateLocalPath(tag);
        }

        [TestMethod]
        public void TestChangeWall()
        {
            WindowsOps.ChangeWall();
        }
    }
}