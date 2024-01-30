using Godot;
using System;

public partial class Player : CharacterBody2D
{
	[Signal]
	public delegate void LaserFiredEventHandler(Vector2 Position, Vector2 Direction);
	[Signal]
	public delegate void GrenadeFiredEventHandler(Vector2 Position, Vector2 Direction);
	[Export]
	public int speed;

	Timer laserTimer;
	Timer grenadeTimer;

	GpuParticles2D particles;

	bool canLaser = true;
	bool canGrenade = true;
	Random rand = new Random();
	public override void _Ready()
	{
		laserTimer = GetNode<Timer>("LaserTimer");
		grenadeTimer = GetNode<Timer>("GrenadeTimer");
		particles = GetNode<GpuParticles2D>("GPUParticles2D");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		//directional inputs
		Vector2 direction = Input.GetVector("left", "right", "up", "down").Normalized();
		Velocity = direction * speed;

		//rotate follow mouse
		LookAt(GetGlobalMousePosition());

		//shooting inputs for laser
		Vector2 playerDirection = (GetGlobalMousePosition() - Position).Normalized();
		if(Input.IsActionPressed("primary action") && canLaser)
		{
			canLaser = false;
			var laserMarkers = GetNode("StartPositions").GetChildren();
			Marker2D selectedLaser = (Marker2D) laserMarkers[rand.Next(laserMarkers.Count)];
			laserTimer.Start();
			EmitSignal(SignalName.LaserFired, selectedLaser.GlobalPosition, playerDirection);
			particles.Emitting = true;
		}
		//shooting inputs for grenade
		if(Input.IsActionPressed("secondary action") && canGrenade)
		{
			canGrenade = false;
			var grenadeMarkers = GetNode("StartPositions").GetChildren();
			Marker2D selectedGrenade = (Marker2D) grenadeMarkers[0];
			grenadeTimer.Start();
			EmitSignal(SignalName.GrenadeFired, selectedGrenade.GlobalPosition, playerDirection);
		}
		MoveAndSlide();
	}
	public void OnLaserTimerTimeout()
	{
		canLaser = true;
	}
	public void OnGrenadeTimerTimeout()
	{
		canGrenade = true;
	}
}
