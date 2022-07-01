using System;
using GXPEngine;

public struct Vec2 
{
	public float x;
	public float y;

	public Vec2 (float pX = 0, float pY = 0) 
	{
		x = pX;
		y = pY;
	}
    //|||||||||||||||||operator +|||||||||||||||||||||||||||
    public static Vec2 operator+ (Vec2 left, Vec2 right) {
		return new Vec2(left.x+right.x, left.y+right.y);
	}
    //|||||||||||||||||operator -|||||||||||||||||||||||||||
    public static Vec2 operator- (Vec2 left, Vec2 right)
    {
        return new Vec2(left.x - right.x, left.y - right.y);
    }
    //|||||||||||||||||operator *|||||||||||||||||||||||||||
    public static Vec2 operator* (Vec2 point,  float scalar)
    {
        return new Vec2(scalar * (point.x), scalar * (point.y));
    }
    //|||||||||||||||||length|||||||||||||||||||||||||||
    public float Length()
    {
        return (Mathf.Sqrt(Mathf.Pow(x, 2) + Mathf.Pow(y, 2)));
    }
    //|||||||||||||||||normalize|||||||||||||||||||||||||||
    public void Normalize()
    {
        Vec2 normalizedVector = this.Normalized();
        x = normalizedVector.x;
        y = normalizedVector.y;
    }
    public Vec2 Normalized()
    {
        if (Mathf.Abs(Length()) < float.Epsilon)
        {
            return new Vec2(0f, 0f);
        }
        else
        return new Vec2(x / Length(), y / Length());
    }
    public override string ToString () 
	{
		return String.Format ("({0},{1})", x, y);
	}
    public void SetXY(float tempX, float tempY)
    {
        x = tempX;
        y = tempY;
    }
}

