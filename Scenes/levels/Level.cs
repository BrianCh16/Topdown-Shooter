using Godot;
using System;

public partial class Level : Node2D
{
	Gate gate;
	Player player;

	PackedScene LaserScene = GD.Load<PackedScene>("res://Scenes/projectiles/laserBlue.tscn");
	PackedScene GrenadeScene = GD.Load<PackedScene>("res://Scenes/projectiles/Grenade.tscn");
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		gate = GetNode<Gate>("Gate");
		player = GetNode<Player>("Player");
		gate.PlayerEnteredGate += OnPlayerEnteredGate;
		player.GrenadeFired += OnPlayerGrenadeFired;
		player.LaserFired += OnPlayerLaserFired;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void OnPlayerEnteredGate(Player body)
	{
		Tween tween = GetTree().CreateTween();
		tween.TweenProperty(GetNode<CharacterBody2D>("Player"), "speed", 0, 0.4);
	}

	private void OnPlayerLaserFired(Vector2 pos, Vector2 direction)
	{
		LaserBlue laser = (LaserBlue) LaserScene.Instantiate();
		laser.Position = pos;
		laser.RotationDegrees = (float) (direction.Angle() * 180/Math.PI) + 90;
		laser.direction = direction;
		GetNode("Projectiles").AddChild(laser);
	}

	private void OnPlayerGrenadeFired(Vector2 pos, Vector2 direction)
	{
		Grenade grenade = (Grenade) GrenadeScene.Instantiate();
		grenade.Position = pos;
		grenade.LinearVelocity = direction * Grenade.SPEED;
		GetNode("Projectiles").AddChild(grenade);
		GD.Print("Grenade from level");
	}

	private void OnHousePlayerEntered()
	{
		Tween tween = GetTree().CreateTween();
		tween.TweenProperty(GetNode<Camera2D>("Player/Camera2D"), "zoom", new Vector2(1,1), 1);
	}

	private void OnHousePlayerExited()
	{
		Tween tween = GetTree().CreateTween();
		tween.TweenProperty(GetNode<Camera2D>("Player/Camera2D"), "zoom", new Vector2(1,1) * (float)0.6, 1);
	}
}
