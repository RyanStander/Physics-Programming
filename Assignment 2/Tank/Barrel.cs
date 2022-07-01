using GXPEngine;
using System;

class Barrel : Sprite 
{
    Vec2 _parentPos;
    Vec2 _mousePos;
    Vec2 _deltaVec;
    float rotationSpeed;
    float rotationSpeedMax=3;
	public Barrel() : base("assets/barrels/PewPew.png") 
	{
        SetOrigin(width / 3f, height / 2);
	}

	public void Update() 
	{
        UpdatePos();
        _deltaVec =  _mousePos- _parentPos;
        float mouseAngle = _deltaVec.GetAngleDegrees() - parent.rotation;
        if (mouseAngle < 0) mouseAngle += 360;
        if (rotation < 0) rotation += 360;
        if (rotation > 360) rotation -= 360;
        float angleDifference = ((mouseAngle - rotation + 540) % 360) - 180;
        if (angleDifference < 3) rotation -= rotationSpeed;
        else rotation += rotationSpeed;


        //Acceleration
        if (rotationSpeed < rotationSpeedMax)
        {
            rotationSpeed += 0.2f;
        }

        //Snap to Position
        if (Mathf.Abs(mouseAngle % 360 - rotation % 360) < rotationSpeed)
        {
            rotation = mouseAngle;
            rotationSpeed = 0f;
        }

        //compliments to leo for assisting!
    }
    public void UpdatePos()
    {
        _parentPos.x = parent.x;
        _parentPos.y = parent.y;
        _mousePos.x = Input.mouseX;
        _mousePos.y = Input.mouseY;
    }
}
