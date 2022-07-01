using System;
using GXPEngine;
using System.Drawing;

public class MyGame : Game
{
    static void Main() 
	{
		new MyGame().Start();
	}
    Tank _tank;
    public MyGame () : base(800, 600, false,false)
	{
        
		// background:
		AddChild (new Sprite ("assets/desert.png"));
		// tank:
        _tank=new Tank(width / 2, height / 2);

        AddChild (_tank);
        //unit testing
        AddChild(new UnitTesting());
	}
    public void Update()
    {
        Shoot();
    }
    void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AddChild(new Bullet(new Vec2(_tank.x, _tank.y),_tank.GetBarrelRotation()+_tank.rotation,_tank.GetBarrelLength()));
        }
    }
}