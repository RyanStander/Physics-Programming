using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using System.Drawing;

public class ScoreCounter : Canvas
{
    private Font _arial;
    private int _currentScore;
    Ball _targetBall;

    public ScoreCounter(Ball target) : base(100, 42, addCollider: false)
    {
        _targetBall = target;
        _arial = new Font("Arial", 15);

        SetXY(0,50);

        scoreUpdate();
    }
    // follows the player around
    public void Update()
    {
        if (_targetBall.GetGameOver() == true)
        {

        }
        else
        {
            scoreUpdate();
        }
    }

    private void scoreUpdate()
    {
        _currentScore = (int)Time.time/1000;

        graphics.Clear(Color.GhostWhite);
        graphics.DrawString("Score: " + _currentScore, _arial, Brushes.Black, 0, 0);
    }
}