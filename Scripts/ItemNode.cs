using Godot;
using System;

public partial class ItemNode : Node
{

	[Export]
	public string name;
	public string description;
	public string type;
	[Export]
	public CompressedTexture2D icon;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}


	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
