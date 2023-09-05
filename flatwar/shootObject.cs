using Godot;
using System;

public class shootObject : Node2D
{
    private const int SPEED = 500;
    Vector2 velocity = new Vector2();

    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }
    

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _Process(float delta)
  {
      velocity.x = SPEED * delta;
      
  }
}
