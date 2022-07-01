﻿using System;
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
            TestRight();
            TestLeft();
            TestAddition();
            TestSubtraction();            
            TestLength();
            TestNormalize();
            testNormalized();
            TestDegToRad();
            TestRadToDeg();
            TestUnitVecDeg();
            TestUnitVecRadian();
            TestRandomUnitVec();
            TestSetAngleDegrees();
            TestSetAngleRadians();
            TestGetAngleRadians();
            TestGetAngleDegree();
            TestRotateDegrees();
            TestRotateRadians();
            TestRotateAroundDegrees();
            TestRotateAroundRadians();
        }
        public void TestRight()
        {
            Vec2 result = myVec1 * 3;
            Console.WriteLine("Scalar multiplication right: " + (result.x == 12 && result.y == 9));
        }
        public void TestLeft()
        {
            Vec2 result = myVec1 * 4;
            Console.WriteLine("Scalar multiplication left " + (result.x == 16 && result.y == 12));
        }
        public void TestAddition()
        {
            Vec2 result = myVec1 + myVec2;
            Console.WriteLine("Addition Result: " + (result.x == 5 && result.y == 4));
        }
        public void TestSubtraction()
        {
            Vec2 result = myVec1 - myVec2;
            Console.WriteLine("Subtraction Result: " + (result.x == 3 && result.y == 2));
        }
        public void TestLength()
        {
            Console.WriteLine("Length: " + (myVec1.Length()==5));
        }
        public void TestNormalize()
        {
            myVec1.Normalize();
            Console.WriteLine("Normalization Result: " + (myVec1.x == 0.8f && myVec1.y == 0.6f));
        }
        public void testNormalized()
        {
            Vec2 testNormalizedVector = new Vec2(-3, 4);
            Vec2 result = testNormalizedVector.Normalized();
            Console.WriteLine("Vector Match Normalized: " + (result.x == -0.6f && result.y == 0.8f&&testNormalizedVector.x==-3&&testNormalizedVector.y==4));
        }
        public void TestDegToRad()
        {            
            Console.WriteLine("DegToRad match: " + (Vec2.DegToRad(360)==(2*Mathf.PI)));
        }

        public void TestRadToDeg()
        {
            Console.WriteLine("RadToDeg Match: " + (Vec2.RadToDeg(2 * Mathf.PI) == 360));
        }
        public void TestUnitVecDeg()
        {
            Vec2 TestUnitVec = Vec2.GetUnitVectorDeg(33);
            Console.WriteLine("UnitVecDegree Match: " + (TestUnitVec.Length()==1));
        }
        public void TestUnitVecRadian()
        {
            Vec2 TestUnitVec = Vec2.GetUnitVectorRad(2 * Mathf.PI);
            Console.WriteLine("UnitVecRadians Match: " + (TestUnitVec.Length() == 1));
        }
        public void TestRandomUnitVec()
        {
            Vec2 TestUnitVec = Vec2.RandomUnitVector();
            Console.WriteLine("Random Unit Match: " + (TestUnitVec.Length() == 1));
        }
        bool FloatEqual(float float1, float float2)
        {
            if (Mathf.Abs(float1 - float2) < 0.00001f)
            {
                return true;
            }
            else
                return false;
        }
        public void TestSetAngleDegrees()
        {
            Vec2 OldVec = new Vec2(0, 1);
            Vec2 NewVec = new Vec2(0, 1);
            NewVec.SetAngleDegrees(180);
            Console.WriteLine("SetAngleDegrees Match: " + (FloatEqual(NewVec.x, -1f) && FloatEqual(NewVec.y, 0f)));
        }
        public void TestSetAngleRadians()
        {
            Vec2 NewVec = new Vec2(0, 1);
            NewVec.SetAngleRadians(Mathf.PI);          
            Console.WriteLine("SetAngleRadians Match: " + (FloatEqual(NewVec.x, -1f) && FloatEqual(NewVec.y, 0f)));

        }
        public void TestGetAngleRadians()
        {
            Vec2 TestVec = new Vec2(0, 1);
            Console.WriteLine("GetAngleRadians Match: " + (TestVec.GetAngleRadians() == Mathf.PI / 2));
        }
        public void TestGetAngleDegree()
        {
            Vec2 TestVec = new Vec2(0, 1);
            Console.WriteLine("GetAngleDegrees Match: " + (TestVec.GetAngleDegrees() == 90));
        }
        public void TestRotateDegrees()
        {
            Vec2 TestVec = new Vec2(2, 5);
            TestVec.RotateDegrees(90);
            Console.WriteLine("RotateDegrees Match: " + (FloatEqual(TestVec.x, -5f) && FloatEqual(TestVec.y, 2f)));
        }
        public void TestRotateRadians()
        {
            Vec2 TestVec = new Vec2(2, 5);
            TestVec.RotateRadians(Mathf.PI/2);
            Console.WriteLine("RotateRadians Match: " + (FloatEqual(TestVec.x, -5f) && FloatEqual(TestVec.y, 2f)));
        }
        public void TestRotateAroundDegrees()
        {
            Vec2 OldVec = new Vec2(2, 1);
            Vec2 NewVec = new Vec2(2, 5);
            NewVec.RotateAroundDegrees(OldVec, 90);
            Console.WriteLine("RotateAroundDegrees Match: " + (FloatEqual(NewVec.x, -2f) && FloatEqual(NewVec.y, 1)));
        }
        public void TestRotateAroundRadians()
        {
            Vec2 OldVec = new Vec2(2, 1);
            Vec2 NewVec = new Vec2(2, 5);
            NewVec.RotateAroundRadians(OldVec, Mathf.PI/2);
            Console.WriteLine("RotateAroundRadians Match: " + (FloatEqual(NewVec.x, -2f) && FloatEqual(NewVec.y, 1)));
        }
    }
}
