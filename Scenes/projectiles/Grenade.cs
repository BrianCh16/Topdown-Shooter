using Godot;
using System;

public partial class Grenade : RigidBody2D
{
    AnimationPlayer animation;
    Sprite2D explode;

    public const int SPEED = 750;

    public override void _Ready()
    {
        animation = GetNode<AnimationPlayer>("AnimationPlayer");
        explode = GetNode<Sprite2D>("Explosion");
        explode.Visible = false;
    }

    public void explosion()
    {
        explode.Visible = true;
        animation.Play("Explosion");
    }
}