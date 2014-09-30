using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassicDungeonGenerator.Models;

namespace DungeonTests
{
    [TestClass]
    public class DungeonComponentTests
    {
        [TestMethod]
        public void TestCollisionDetection()
        {
            DungeonComponent component1, component2;
            component1 = new DungeonComponent(0, 0, 3, 3);
            component2 = new DungeonComponent(1, 1, 3, 3);
            Assert.IsTrue(component1.Collision(component2), "Failed to detect collision");
            Assert.AreEqual<bool>(component2.Collision(component1), component1.Collision(component2), "collisions incosistent");
            component2.x = 3;
            Assert.IsFalse(component1.Collision(component2), "Falsely reported collision on edge case");
            Assert.AreEqual<bool>(component2.Collision(component1), component1.Collision(component2), "collisions incosistent");
        }

        [TestMethod]
        public void TestFourArgumentConstructor()
        {
            int height = 10;
            int width = 20;
            int x = 1;
            int y = 2;
            DungeonComponent c = new DungeonComponent(x, y, height, width);
            CheckCoordinates(c, x, y, height, width);
        }

        [TestMethod]
        public void TestTranslations()
        {
            int height = 10;
            int width = 20;
            int x = 1;
            int y = 2;
            DungeonComponent c = new DungeonComponent(x, y, height, width);

            c.x = 30;
            Assert.AreEqual<int>(c.Height, height, "height broken by x change");
            Assert.AreEqual<int>(c.Width, width, "width broken by x change");
            
            c = new DungeonComponent(x, y, height, width);
            c.y = 30;
            Assert.AreEqual<int>(c.Height, height, "height broken by y change");
            Assert.AreEqual<int>(c.Width, width, "width broken by y change");
        }

        public void CheckCoordinates(DungeonComponent c, int x, int y, int height, int width){
            Assert.AreEqual<int>(x, c.x, "x is incorrectly stored.");
            Assert.AreEqual<int>(y, c.y, "y is inccorectly stored.");
            Assert.AreEqual<int>(height, c.Height, "Height is incorrectly stored.");
            Assert.AreEqual<int>(width, c.Width, "Width is inccorectly stored.");
        }
    }
}
