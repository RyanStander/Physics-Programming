using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class UnitTesting : GameObject
    {
        Vec2 myVec1;
        Vec2 myVec2;
        public UnitTesting()
        {
            myVec1 = new Vec2(4, 3);
            myVec2 = new Vec2(1, 1);
            TestAddition();
            TestSubtraction();
            TestRight();
            TestLeft();
            TestLength();
            TestNormalize();
            testNormalized();
        }
        public void TestRight()
        {
            Vec2 result = myVec1 * 3;
            Console.WriteLine("Scalar multiplication right : x=" + result.x + "y=" + result.y);
        }
        public void TestLeft()
        {
            Vec2 result = myVec1 * 4;
            Console.WriteLine("Scalar multiplication left x=" + result.x + "y=" + result.y);
        }
        public void TestAddition()
        {
            Vec2 result = myVec1 + myVec2;
            Console.WriteLine("Addition Result: x=" + result.x + " y=" + result.y);
        }
        public void TestSubtraction()
        {
            Vec2 result = myVec1 - myVec2;
            Console.WriteLine("Subtraction Result: x=" + result.x + " y=" + result.y);
        }
        public void TestLength()
        {
            //Vec2 result = myVec1.Length();
            //Console.WriteLine("Length: " + (result.);
        }
        public void TestNormalize()
        {
            Console.WriteLine("Normalization Result: x=" + myVec1.Normalized().x + " y=" + myVec1.Normalized().y);
        }
        public void testNormalized()
        {
            Vec2 testNormalizedVector = new Vec2(-3, 4);
            Vec2 result = testNormalizedVector.Normalized();
            Console.WriteLine("Vector Match Normalized: " + (result.x == -0.6f && result.y == 0.8f&&testNormalizedVector.x==-3&&testNormalizedVector.y==4));
        }
    }
}
