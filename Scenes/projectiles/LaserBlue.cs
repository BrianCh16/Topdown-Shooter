using Godot;
using System;

public partial class LaserBlue : Area2D
{
    [Export]
    public int speed;
    internal Vector2 direction;

    public override void _Process(double delta)
    {
        Position += direction * speed * (float) delta;
    }

    private void OnBodyEntered(Node2D body)
    {
        if (body is drone)
        {
            drone droneBody = (drone) body;
            droneBody.hit();
        }
        QueueFree();
    }

    private void OnDestroyTimerTimeout()
    {
        QueueFree();
    }
}
