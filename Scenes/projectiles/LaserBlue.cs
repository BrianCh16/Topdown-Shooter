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
}
