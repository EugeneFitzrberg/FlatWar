using Godot;
using System;

public class PlayerController : KinematicBody2D
{
	
	private int speed = 200;
	private AnimatedSprite mainSprite;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		mainSprite = (AnimatedSprite)GetNode("MainSprite");
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _Process(float delta)
  {
	Vector2 velocity = new Vector2();
		if (Input.IsActionPressed("ui_left"))
		{
			velocity.x -= speed;
			mainSprite.FlipH = true;
		}
	if(Input.IsActionPressed("ui_right")){
		velocity.x += speed;
			mainSprite.FlipH = false;
		}
	if(Input.IsActionJustPressed("ui_down")){
		velocity.y += speed;
	}
	if(Input.IsActionJustPressed("ui_up")){
		velocity.y -= speed;
	}

		if (Input.IsActionJustPressed("ui_select")) {
			mainSprite.Playing = true;
			if (mainSprite.Frame == 1) {
				mainSprite.Playing = false;
			}
		}


	MoveAndSlide(velocity,Vector2.Up);
  }
}
