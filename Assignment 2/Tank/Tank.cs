using GXPEngine;
using System;

// TODO: Fix this mess! - see Assignment 2.2
class Tank : Sprite 
{
	// public fields & properties:
	public Vec2 position 
	{
		get 
		{
			return _position;
		}
	}
	public Vec2 velocity;

	// private fields:
	Vec2 _position;
    public Vec2 _prevVector;
    public Barrel _barrel;
    float _speed;

	public Tank(float px, float py) : base("assets/bodies/PewPew.png") 
	{
		_position.x = px;
		_position.y = py;
		_barrel = new Barrel ();
		AddChild (_barrel);
        SetOrigin(width / 2, height / 2);
	}

	void Controls() 
	{
            if (Input.GetKey(Key.LEFT))
            {
            rotation -= 0.2f * _speed;
            }

            if (Input.GetKey(Key.RIGHT))
            {
            rotation += 0.2f * _speed;
        }
		if (Input.GetKey (Key.UP)) 
		{
            _speed += 0.1f;
            /*velocity += new Vec2(0.5f, 0); 
            velocity.RotateDegrees(rotation);

            velocity = velocity * 0.5f + _prevVector * 0.5f;
            if (velocity.Length()==15)
            {
                
            }*/
		}
		if (Input.GetKey (Key.DOWN)) 
		{
            _speed -= 0.1f;
		}
        _speed *= 0.99f;
        if (rotation > 360)
        {
            rotation = 0;
        }
        if (rotation < 0)
        {
            rotation = 360;
        }
        //Console.WriteLine(rotation);
	}

	

	void UpdateScreenPosition() 
	{
		x = _position.x;
		y = _position.y;
	}

	public void Update() 
	{
		Controls ();
        // Basic Euler integration:
        velocity = Vec2.GetUnitVectorDeg(rotation)*_speed;
		_position += velocity;
		UpdateScreenPosition ();
	}
    public float GetBarrelRotation()
    {
        return _barrel.rotation;
    }
    public float GetBarrelLength()
    {
        return _barrel.width / 2;
    }
}
