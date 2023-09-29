using Godot;
using System;

public class BulletForSatir : Node2D
{
	private int speed = 150;
	private float life = 30;

	public override void _Ready()
	{
		
	}

  public override void _Process(float delta)
 {
		Position += Transform.x * delta * speed;
		life -= delta;
		if (life < 0) {
			QueueFree();
		}
  }


	private void _on_Area2D_body_entered(object body)
	{
		QueueFree();
	}

}

