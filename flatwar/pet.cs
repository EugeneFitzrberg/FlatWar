using Godot;
using System;

public class pet : KinematicBody2D
{
	private bool isMove = false;
	private bool isPcDetected = false;
	PlayerController pc;
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
			Position += Transform.x * delta * 25;
			}
		}
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



}



