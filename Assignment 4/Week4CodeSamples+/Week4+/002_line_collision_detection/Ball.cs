using System;
using GXPEngine;

public class Ball : EasyDraw
{
	public int radius {
		get {
			return _radius;
		}
	}

	public Vec2 velocity;
	public Vec2 position;
    public Vec2 resetPosition;
    private bool _didPass=false;

	int _radius;
	float _speed;

	public Ball (int pRadius, Vec2 pPosition, float pSpeed=5) : base (pRadius*2 + 1, pRadius*2 + 1)
	{
		_radius = pRadius;
		position = pPosition;
		_speed = pSpeed;

		UpdateScreenPosition ();
		SetOrigin (_radius, _radius);

		Draw (255, 255, 255);
	}

	void Draw(byte red, byte green, byte blue) {
		Fill (red, green, blue);
		Stroke (red, green, blue);
		Ellipse (_radius, _radius, 2*_radius, 2*_radius);
        velocity = new Vec2(0.5f, 3);
            }

	void FollowMouse() {
		position.SetXY (Input.mouseX, Input.mouseY);
	}

	void UpdateScreenPosition() {
		x = position.x;
		y = position.y;
	}

	public void Step () {

        //FollowMouse ();
        position += velocity;
        BallReset();      
        UpdateScreenPosition ();
	}
    public void BallReset()
    {
        MyGame myGame = (MyGame)game;
        if (myGame.CalculateBallDistance() < radius)
        {
            SetColor(1, 0, 0);
            position += (-myGame.CalculateBallDistance() + radius) * myGame.lineVec.Normal();
            ballReflect();
        }
        else
        {
            SetColor(0, 1, 0);
        }
    }
    public void ballReflect()
    {
        MyGame myGame = (MyGame)game;
        velocity.Reflect(1, myGame.lineVec.Normal());
    }
}
