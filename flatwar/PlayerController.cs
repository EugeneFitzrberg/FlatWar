using Godot;
using System;

public class PlayerController : KinematicBody2D
{
	
	private int speed = 200;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _Process(float delta)
  {   
	Vector2 velocity = new Vector2();
	if(Input.IsActionPressed("ui_left")){
		velocity.x -= speed;
	}
	if(Input.IsActionPressed("ui_right")){
		velocity.x += speed;
	}
	if(Input.IsActionJustPressed("ui_down")){
		velocity.y += speed;
	}
	if(Input.IsActionJustPressed("ui_up")){
		velocity.y -= speed;
	}
	MoveAndSlide(velocity,Vector2.Up);
  }
}
