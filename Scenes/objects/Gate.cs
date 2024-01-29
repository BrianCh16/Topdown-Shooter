using Godot;
using System;

public partial class Gate : StaticBody2D
{
	[Signal]
	public delegate void PlayerEnteredGateEventHandler(Player body);
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void OnGateAreaBodyEntered(Node2D body)
	{
		EmitSignal(SignalName.PlayerEnteredGate, body);
	}
}