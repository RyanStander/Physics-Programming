using System;
using GXPEngine;

public class Ball : EasyDraw
{
    public Vec2 velocity;

    int _radius;
    Vec2 _position;
    Vec2 _mousePosition;
    public Vec2 _deltaVector;
    public Vec2 _preVec;
    float _speed;

    public bool _gameOver = false;

    public Ball(int pRadius, Vec2 pPosition, float pSpeed = 5) : base(pRadius * 2 + 1, pRadius * 2 + 1)
    {
        _radius = pRadius;
        _position = pPosition;
        _speed = pSpeed;

        UpdateScreenPosition();
        SetOrigin(_radius, _radius);

        Draw(150, 0, 255);
    }

    void Draw(byte red, byte green, byte blue)
    {
        Fill(red, green, blue);
        Stroke(red, green, blue);
        Ellipse(_radius, _radius, 2 * _radius, 2 * _radius);
    }

    //ASSIGNMENT 1.1/2 - SETUP
    void KeyControls()
    {
        velocity.x = 0;
        velocity.y = 0;

        if (Input.GetKey(Key.RIGHT))
        {
            velocity.x += _speed;
        }
        else if (Input.GetKey(Key.LEFT))
        {
            velocity.x -= _speed;
        }

        if (Input.GetKey(Key.UP))
        {
            velocity.y -= _speed;
        }
        if (Input.GetKey(Key.DOWN))
        {
            velocity.y += _speed;
        }

        velocity.Normalize();
        velocity *=_speed;

    }
    //ASSIGNMENT 1.3 - AVOID THE BALL GAME
    void BallChase()
    {
        // Calculate the delta vector between mouse and ball
        //Normalize this delta
        //Multiply with current speed
        //Increase speed each frame
        //Check distance between ball &mouse: either move, or go to game ove
        _deltaVector = _mousePosition - _position;

        //Game over collision
        if (_deltaVector.Length()<=_radius)
        {
            _gameOver = true;
            velocity *= 0;
        }
        else if (!_gameOver)
        {
            _deltaVector.Normalize();
            _deltaVector *= _speed;
            _speed += 0.05f;

            velocity = _deltaVector*0.5f + _preVec*0.5f;
            
            _preVec = velocity;
        }
    }

    void UpdateScreenPosition()
    {
        x = _position.x;
        y = _position.y;
    }

    public void Step()
    {
        //ASSIGNMENT 1.3 - AVOID THE BALL GAME
        _mousePosition.x = Input.mouseX;
        _mousePosition.y = Input.mouseY;

        BallChase();

        //ASSIGNMENT 1.1/2 - SETUP
        //KeyControls();

        _position += velocity;

        UpdateScreenPosition();
    }

    public bool GetGameOver()
    {
        return _gameOver;
    }

    public Vec2 position
    {
        get
        {
            return _position;
        }
    }

}
