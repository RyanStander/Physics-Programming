using GXPEngine;

class Bullet : Sprite 
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
    Tank _tank;
    float _speed = 5;

	public Bullet(Vec2 pPosition, float tempRotation,float barrelLength) : base("assets/bullet.png") 
	{
        Vec2 barrelLengthShift = Vec2.GetUnitVectorDeg(tempRotation) * barrelLength;
		_position = pPosition+barrelLengthShift;
        //x = pPosition.x;
        //y = pPosition.y;
        rotation = tempRotation;
	}

	void UpdateScreenPosition() 
	{
		x = _position.x;
		y = _position.y;
	}

	public void Update() 
	{
        velocity = Vec2.GetUnitVectorDeg(rotation) * _speed;
        _position += velocity;
		UpdateScreenPosition ();
	}
}
