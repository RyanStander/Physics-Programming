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

	NLineSegment _lineSegment;

    UnitTesting _unitTest;
	public MyGame () : base(800, 600, false,false)
	{
		_ball = new Ball (30, new Vec2 (width / 2, height / 2));
		AddChild (_ball);

		_text = new EasyDraw (250,25);
		_text.TextAlign (CenterMode.Min, CenterMode.Min);
		AddChild (_text);

		_lineSegment = new NLineSegment (new Vec2 (500,500), new Vec2 (100, 200), 0xff00ff00, 3);
		AddChild(_lineSegment);

        _unitTest = new UnitTesting();
        AddChild(_unitTest);
	}
    public Vec2 lineVec;

    void Update () {
        _ball.Step();
		_text.Clear (Color.Transparent);
		_text.Text("Distance to line: "+CalculateBallDistance(), 0, 0);
	}

    public float CalculateBallDistance()
    {
        Vec2 difference = _ball.position - _lineSegment.start;
        lineVec = _lineSegment.end - _lineSegment.start;
        return difference.Dot(lineVec.Normal());
    }

}

