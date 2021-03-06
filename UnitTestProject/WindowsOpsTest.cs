﻿using System;
using System.Linq;
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
            WindowsOps.LoadTags();
        }

        [TestMethod]
        public void TestChangeWall()
        {
            WindowsOps.ChangeWall();
        }
    }
}