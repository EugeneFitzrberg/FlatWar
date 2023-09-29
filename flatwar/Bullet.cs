using Godot;
using System;

public class Bullet : Node2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	private int speed = 50;
	private float lifeSpan = 20f;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _Process(float delta)
  {
		Position += Transform.x * delta * speed;
		lifeSpan -= delta;
		if (lifeSpan < 0) { 
			QueueFree();                                                // deleted 
		}
  }


	private void _on_Area2D_body_entered(object body)
	{
		QueueFree();
	}
}



