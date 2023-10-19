using Godot;
using System;

public class Node2D : Godot.Node2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		string path = "res://pet.tscn";
		PackedScene petScene = GD.Load<PackedScene>(path);
		for (int i = 0; i < 4; i++) {
			pet localPet = petScene.Instance<pet>();
			localPet.GlobalPosition = new Vector2(100 * (i), 100 * (i));
			CallDeferred("add_child", localPet);
			
		}

	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
