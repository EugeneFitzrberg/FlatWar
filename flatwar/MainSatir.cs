using Godot;
using System;

public class MainSatir : Node2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	private PlayerController playerController;
	private bool active;
	private bool ableToAttack = true;
	private float attackFreeze = 1f;
	private float attackFreezeReset = 2f;
	[Export]
	public PackedScene BulletForSatir;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

	//  // Called every frame. 'delta' is the elapsed time since the previous frame.

/*	public override void _PhysicsProcess(float delta)
	{
		base._PhysicsProcess(delta);
		var spaceStat = GetWorld2d().DirectSpaceState;

		if (playerController != null)
		{
		//	GD.Print(this.Position);
		//	GD.Print(playerController.Position);
			Godot.Collections.Dictionary result = spaceStat.IntersectRay(this.Position, playerController.Position, new Godot.Collections.Array { this });
			if (result != null) {
				if (result.Contains("collider")) {
				//	GD.Print(result);
				}
			}

			
			
		}
	}*/

	public override void _Process(float delta)
  {
		if (active) {
			if (ableToAttack) {

				GD.Print("Shoot");
				GD.Print(playerController.Position);
				LookAt(playerController.Position);
				this.GetNode<Position2D>("ProjectSpawn").LookAt(playerController.Position);
				BulletForSatir bullet = BulletForSatir.Instance () as BulletForSatir;
				Owner.AddChild(bullet);
				bullet.GlobalTransform = this.GetNode<Position2D>("ProjectSpawn").GlobalTransform;



				var spaceStat = GetWorld2d().DirectSpaceState;
				
				Godot.Collections.Dictionary result = spaceStat.IntersectRay(this.Position, playerController.Position, new Godot.Collections.Array { this });// not working
				if (result != null) {
					//GD.Print(result.Count);
					if (result.Contains("collider"))
					{
						
					}
				}
				
				ableToAttack = false;
				//GD.Print("!");
				attackFreeze = attackFreezeReset;
			}
			
		}

		if (attackFreeze <= 0)
		{
			ableToAttack = true;
		}
		else {
			attackFreeze -= delta;
		}
  }



private void _on_Detection_Radius_body_entered(object body)
{
	GD.Print("Body has entered "  + body);
		if (body is PlayerController) { 
			playerController = body as PlayerController;
			active = true;
		}
}


private void _on_Detection_Radius_body_exited(object body)
{
	
	GD.Print("Body has closed " + body);
		if (body is PlayerController) { 
			active = false;
		}
}
}
