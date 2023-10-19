using Godot;
using System;

public class pet : KinematicBody2D, FlatWar.IEnemy
{
	private bool isMove = false;
	private bool isPcDetected = false;
	PlayerController pc;
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


		if (pc != null)
		{
			LookAt(pc.Position);
			if(!isPcDetected){
				velocity += Transform.x * delta * 20 * 20 * 5;
				MoveAndSlide(velocity, Vector2.Up);
				velocity = new Vector2();
			}
		}
	}

	public void removePet()
	{
		try
		{
			QueueFree();
		}
		catch (Exception ex) { }
	}
	private void _on_DetectionRadius_body_entered(object body)
	{
		if (body is PlayerController)
		{
			GD.Print("PC");
			pc = body as PlayerController;
			isMove = isPcDetected;
		}
	}

	private void _on_DetectedPC_body_entered(object body)
	{
		if (body is PlayerController)
		{
			isPcDetected = true;
			GD.Print("detected");
			isMove = false;
		}

	}


	private void _on_DetectedPC_body_exited(object body)
	{
		if (body is PlayerController)
		{
			isPcDetected = false;
			GD.Print("not detected");
		}
	}

	public void removeEnemy()
	{
		removePet();
	}
}



