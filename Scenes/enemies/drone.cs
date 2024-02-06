using Godot;
using System;

public partial class drone : CharacterBody2D
{
	[Export]
	public float speed = 300.0f;
    public override void _Ready()
    {
    }
    public override void _PhysicsProcess(double delta)
	{
		//Vector2 direction = Input.GetVector("left", "right", "up", "down").Normalized();
		Vector2 direction = Vector2.Right;
		Velocity = direction * speed;
		MoveAndSlide();
	}

	public void hit()
	{
		GD.Print("damage");
	}
}
