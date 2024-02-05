using Godot;
using System;

public partial class House : Area2D
{
    [Signal]
    public delegate void PlayerEnteredEventHandler();
    [Signal]
    public delegate void PlayerExitedEventHandler();

    private void OnBodyEntered(CharacterBody2D body)
    {
        EmitSignal(SignalName.PlayerEntered);
    }

    private void OnBodyExited(CharacterBody2D body)
    {
        EmitSignal(SignalName.PlayerExited);
    }
}
