using Godot;
using System;

public class PlayerController : KinematicBody2D
{

	private int speed = 200;
	private AnimatedSprite mainSprite;

	public int health = 3;
	Vector2 velocity = new Vector2();

	private int facingDirection = 0;
	private bool isTakeDamage = false;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

		mainSprite = (AnimatedSprite)GetNode("MainSprite");
	}

	public override void _Process(float delta)
	{

		facingDirection = 0;
		if (!isTakeDamage)
		{
			if (Input.IsActionPressed("ui_left"))
			{
				velocity.x -= speed;
				facingDirection = -1;
				mainSprite.FlipH = true;
			}
			if (Input.IsActionPressed("ui_right"))
			{
				velocity.x += speed;
				facingDirection = 1;
				mainSprite.FlipH = false;
			}
			if (Input.IsActionPressed("ui_down"))
			{
				facingDirection = -1;
				velocity.y += speed;
			}
			if (Input.IsActionPressed("ui_up"))
			{
				velocity.y -= speed;
			}
		}
		isTakeDamage = false;

		if (Input.IsActionJustPressed("ui_select"))
		{
			mainSprite.Playing = true;
			if (mainSprite.Frame == 1)
			{
				mainSprite.Playing = false;
			}
		}


		MoveAndSlide(velocity, Vector2.Up);
		velocity = new Vector2();
	}

	public void takeDamager()
	{
		health -= 1;
		GD.Print("HEALT " + health);
		velocity = MoveAndSlide(new Vector2(500f * -facingDirection, -800), Vector2.Up);   
		isTakeDamage = true;
		if (health <= 0) { 
			health = 0;
			GD.Print("playerController has died");
		}

	}
}
