using Godot;
using System;

public class SatirKB : KinematicBody2D
{
	Vector2 velocity = new Vector2();

	private PlayerController playerController;
	private bool active;
	private bool ableToAttack = true;
	private float attackFreeze = 1f;
	private float attackFreezeReset = 1f;
	[Export]
	public PackedScene BulletForSatir;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _Process(float delta)
  {
	  		if (active) {
			//Position += Transform.x * delta * 25;
			velocity += Transform.x * delta * 20 * 25;
			var angle = GlobalPosition.AngleToPoint(playerController.GlobalPosition);
			if (Mathf.Abs(angle) > Mathf.Pi / 2)
			{
				GetNode<AnimatedSprite>("AnimatedSprite").FlipV = false;
			}
			else {
				GetNode<AnimatedSprite>("AnimatedSprite").FlipV = true;
			}

			if (ableToAttack) {

				GD.Print("Shoot");
				GD.Print(playerController.Position);
				LookAt(playerController.Position);
				this.GetNode<Position2D>("Position2D").LookAt(playerController.Position);
				BulletForSatir bullet = BulletForSatir.Instance () as BulletForSatir;
				Owner.AddChild(bullet);
				bullet.GlobalTransform = this.GetNode<Position2D>("Position2D").GlobalTransform;

				var spaceStat = GetWorld2d().DirectSpaceState;
				
				Godot.Collections.Dictionary result = spaceStat.IntersectRay(this.Position, playerController.Position, new Godot.Collections.Array { this });// not working
				if (result != null) {
					GD.Print(result.Count);
					if (result.Contains("collider"))
					{
						GD.Print("collider");
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
		MoveAndSlide(velocity, Vector2.Up);
				velocity = new Vector2();
  }



private void _on_Area2D_body_entered(object body)
{
		GD.Print("Body has entered "  + body);
		if (body is PlayerController) { 
			playerController = body as PlayerController;
			active = true;
			
			//Position += playerController.Position.x;
		}
}


private void _on_Area2D_body_exited(object body)
{
	GD.Print("Body has closed " + body);
		if (body is PlayerController) { 
			active = false;
		}
}
}
