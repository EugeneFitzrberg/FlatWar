using Godot;
using System;

public class PlayerController : KinematicBody2D
{

	private int speed = 200;
	private AnimatedSprite mainSprite;
	private Area2D magHit;
	private bool isIdle = true;
	public int health = 3;
	Vector2 velocity = new Vector2();
	private bool isFullAttack = false;
	private int facingDirection = 0;
	private bool isTakeDamage = false;

	FlatWar.IEnemy enemyInsideCollider;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

		mainSprite = (AnimatedSprite)GetNode("MainSprite");
		
		magHit = (Area2D)mainSprite.GetNode("MagHit");
	}

	public override void _Process(float delta)
	{

		facingDirection = 0;
		if (!isTakeDamage)
		{
			if(Input.IsActionPressed("Attack_seccond")){
				mainSprite.Play("Attack_second");
				isIdle = false;
			}
			if (Input.IsActionPressed("attack"))
			{
				mainSprite.Play("Attack");
				isIdle = false;
				isFullAttack = false;
				
				if (mainSprite.GetFrame() == mainSprite.Frames.GetFrameCount("Attack") -1) {
					isFullAttack = true;
					if (enemyInsideCollider != null)
					{
						enemyInsideCollider.removeEnemy();
					}
					mainSprite.Stop();
					isIdle = true;
				}
				
			}
			else
			{
				isFullAttack =false;
				if (Input.IsActionPressed("ui_left"))
				{
					velocity.x -= speed;
					facingDirection = -1;
					mainSprite.FlipH = true;
					mainSprite.Play("Running");
					isIdle = false;
					magHit.Position = Transform.x * -155;
				}
				if (Input.IsActionPressed("ui_right"))
				{
					velocity.x += speed;
					facingDirection = 1;
					mainSprite.FlipH = false;
					magHit.Position = Transform.x;
					mainSprite.Play("Running");
					isIdle = false;
				}
				 if (Input.IsActionPressed("ui_down"))
				{
					facingDirection = -1;
					velocity.y += speed;
					mainSprite.Play("Running");
					isIdle = false;
				}
				 if (Input.IsActionPressed("ui_up"))
				{
					velocity.y -= speed;
					mainSprite.Play("Running");
					isIdle = false;
				}
				if(isIdle)
				{
					
					mainSprite.Play("Idle");
					
				}
				isIdle = true;
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
	
private void _on_MagHit_area_entered(object area)
{
		
	
	}


	private void _on_MagHit_body_entered(object body)
	{
		if (body is FlatWar.IEnemy)
		{
			enemyInsideCollider = (FlatWar.IEnemy)body;
			body = (FlatWar.IEnemy)body;
			if (isFullAttack)
			{
				((FlatWar.IEnemy)body).removeEnemy();
			}
			GD.Print("PET DeTECTED");
		}
		else { 
				
		}
	}
	private void _on_MagHit_body_exited(object body)
	{
		
		// Replace with function body.
	}
	
	
	private void _on_Area2D_body_entered(object body)
	{
	// Replace with function body.
	if (body is FlatWar.IEnemy)
		{
			GD.Print(body);
		}
	}

}








