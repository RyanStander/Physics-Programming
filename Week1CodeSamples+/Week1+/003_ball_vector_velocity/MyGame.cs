using System;
using GXPEngine;
using System.Drawing;

public class MyGame : Game
{	

	static void Main() {
		new MyGame().Start();
	}

	Ball _ball;

	EasyDraw _text;

    UnitTesting _unitTest;

    ScoreCounter scoreCounter;

    public MyGame () : base(800, 600, false,false)
	{
		_ball = new Ball (30, new Vec2 (width / 2, height / 2));
		AddChild (_ball);

		_text = new EasyDraw (200,25);
		_text.TextAlign (CenterMode.Min, CenterMode.Min);
		AddChild (_text);

        _unitTest = new UnitTesting();
        AddChild(_unitTest);

        //Creates the text score counter
        scoreCounter = new ScoreCounter(_ball);
        AddChild(scoreCounter);
    }

	void Update () {
		_ball.Step ();

		_text.Clear (Color.Transparent);
		_text.Text("Velocity: "+_ball._deltaVector, 0, 0);
	}



}

