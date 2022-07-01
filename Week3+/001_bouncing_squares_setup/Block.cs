using System;
using GXPEngine;


public class Block : EasyDraw
{
	/******* PUBLIC FIELDS AND PROPERTIES *********************************************************/

	// These four public static fields are changed from MyGame, based on key input (see Console):
	public static bool drawDebugLine = false;
	public static bool wordy = false;
	public static float bounciness = 0.98f;
	// For ease of testing / changing, we assume every block has the same acceleration (gravity):
	public static Vec2 acceleration = new Vec2 (0, 0);

	public readonly int radius;

	// Mass = density * volume.
	// In 2D, we assume volume = area (=all objects are assumed to have the same "depth")
	public float Mass {
		get {
			return 4 * radius * radius * _density;
		}
	}

	public Vec2 position {
		get {
			return _position;
		}
	}

	public Vec2 velocity;

	/******* PRIVATE FIELDS *******************************************************************/

	Vec2 _position;
	Vec2 _oldPosition;

	Arrow _velocityIndicator;

	float _red = 1;
	float _green = 1;
	float _blue = 1;

	float _density = 1;

	const float _colorFadeSpeed = 0.025f;

	/******* PUBLIC METHODS *******************************************************************/

	public Block (int pRadius, Vec2 pPosition, Vec2 pVelocity) : base (pRadius*2, pRadius*2)
	{
		radius = pRadius;
		_position = pPosition;
		velocity = pVelocity;

		SetOrigin (radius, radius);
		draw ();
		UpdateScreenPosition();
		_oldPosition = new Vec2(0,0);

		_velocityIndicator = new Arrow(_position,velocity, 10);
		AddChild(_velocityIndicator);
	}

	public void SetFadeColor(float pRed, float pGreen, float pBlue) {
		_red = pRed;
		_green = pGreen;
		_blue = pBlue;
	}

	public void Update() {
		// For extra testing flexibility, we call the Step method from MyGame instead:
		//Step();
	}

	public void Step() {
		_oldPosition=_position;

		// No need to make changes in this Step method (most of it is related to drawing, color and debug info). 
		// Work in Move instead.
		Move();

		UpdateColor();
		UpdateScreenPosition();
		ShowDebugInfo();
	}

	/******* PRIVATE METHODS *******************************************************************/

	/******* THIS IS WHERE YOU SHOULD WORK: ***************************************************/

	void Move() {
        // TODO: implement Assignment 3 here (and in methods called from here).
        velocity += acceleration;
		_position += velocity;

        // Example methods (replace/extend):
        CheckBoundaryCollisions();
        CheckBlockOverlaps();

		// TIP: You can use the CollisionInfo class to pass information between methods, e.g.:
		//
		//Collision firstCollision=FindEarliestCollision();
		//if (firstCollision!=null)
		//	ResolveCollision(firstCollision);
	}
    void CheckBoundaryCollisions()
    {
        MyGame myGame = (MyGame)game;
        if(_position.x - radius < myGame.LeftXBoundary)
        {

            
            _position = POI(true, myGame.LeftXBoundary + radius);
            velocity.x *= -bounciness;
            SetFadeColor(1, 0.2f, 0.2f);
            if (wordy)
            {
                Console.WriteLine("Left boundary collision");
            }
        }
        else if (_position.x + radius > myGame.RightXBoundary)
        {
            
            _position = POI(true, myGame.RightXBoundary - radius);  
            velocity.x *= -bounciness;
            SetFadeColor(1, 0.2f, 0.2f);
            if (wordy)
            {
                Console.WriteLine("Right boundary collision");
            }
        }
        if (_position.y - radius < myGame.TopYBoundary)
        {
            
            _position = POI(false, myGame.TopYBoundary + radius);
            velocity.y *= -bounciness;
            SetFadeColor(0.2f, 1, 0.2f);
            if (wordy)
            {
                Console.WriteLine("Top boundary collision");
            }
        }
        else if (_position.y + radius > myGame.BottomYBoundary)
        {
            
            _position = POI(false, myGame.BottomYBoundary - radius);
            velocity.y *= -bounciness;
            SetFadeColor(0.2f, 1, 0.2f);
            if (wordy)
            {
                Console.WriteLine("Bottom boundary collision");
            }
        }
    }
    Vec2 POI(bool horizontalCollision, float collidingPoint)
    {     
        float t=TOI(horizontalCollision, collidingPoint);
        Vec2 _pointOfImpact = _oldPosition + velocity * t;
        return _pointOfImpact;
    }

    float TOI(bool horizontalCollision, float collidingPoint)
    {
        float a;
        float b;//if smaller then coming from left
        if (horizontalCollision)
        {
            a = collidingPoint - _oldPosition.x;
            b = velocity.x;
        }
        else
        {
            a = collidingPoint - _oldPosition.y;
            b = velocity.y;
        }
        float t = a / b;

        return t;
    }
    // This method is just an example of how to get information about other blocks in the scene.
    void CheckBlockOverlaps()
    {
        MyGame myGame = (MyGame)game;
        for (int i = 0; i < myGame.GetNumberOfMovers(); i++)
        {
            Block other = myGame.GetMover(i);

            if (other != this)
            {
                resolveBlockOverlaps(other);

            }
        }
    }

    void resolveBlockOverlaps(Block _givenOther)
    {
        float _thisRight = _position.x + radius;
        float _thisLeft = _position.x - radius;
        float _thisTop = _position.y - radius;
        float _thisBottom = _position.y + radius;
        float _otherRight = _givenOther.position.x + _givenOther.radius;
        float _otherLeft = _givenOther.position.x - _givenOther.radius;
        float _otherTop = _givenOther._position.y - _givenOther.radius;
        float _otherBottom = _givenOther.position.y + _givenOther.radius;
        if (_thisRight > _otherLeft && _thisLeft < _otherRight && _thisTop < +_otherBottom && _thisBottom > _otherTop)
        {
            Console.WriteLine("collision");
            SetFadeColor(0.2f, 0.2f, 1);
            //---------------------------------
            //Collisions
            //---------------------------------

            float _xImpact = Mathf.Abs(TOI(true, _givenOther._position.x));
            float _yImpact = Mathf.Abs(TOI(false, _givenOther._position.y));

            if (_xImpact > _yImpact)
            {
                velocity.x *= -bounciness;
            }
            else
            {
                velocity.y *= -bounciness;
            }          
            //---------------------------------
            //color thingy
            //---------------------------------
            _givenOther.SetFadeColor(0.2f, 0.2f, 1);
            if (wordy)
            {
                Console.WriteLine("Block-block overlap detected.");
            }
        }
        
    }

    /******* NO NEED TO CHANGE ANY OF THE CODE BELOW: **********************************************/

            void UpdateColor() {
		if (_red < 1) {
			_red = Mathf.Min (1, _red + _colorFadeSpeed);
		}
		if (_green < 1) {
			_green = Mathf.Min (1, _green + _colorFadeSpeed);
		}
		if (_blue < 1) {
			_blue = Mathf.Min (1, _blue + _colorFadeSpeed);
		}
		SetColor(_red, _green, _blue);
	}

	void ShowDebugInfo() {
		if (drawDebugLine) {
			((MyGame)game).DrawLine (_oldPosition, _position);
		}
		_velocityIndicator.startPoint = _position;
		_velocityIndicator.vector = velocity;
	}

	void UpdateScreenPosition() {
		x = _position.x;
		y = _position.y;
	}

	void draw() {
		Fill (200);
		NoStroke ();
		ShapeAlign (CenterMode.Min, CenterMode.Min);
		Rect (0, 0, width, height);
	}
}
