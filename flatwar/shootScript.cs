using Godot;
using System;

public class shootScript : KinematicBody2D
{
    private const int SPEED = 50;
    Vector2 velocity = new Vector2();

    public override void _Ready()
    {
        
    }

      public override void _Process(float delta)
    {
      velocity.x += SPEED * delta;
      MoveAndSlide(velocity, Vector2.Up);
    }
}
