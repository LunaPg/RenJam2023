using Godot;
using Godot.Collections;
using System;


public partial class inventory : Node
{
	public Item ItemInHand = null;

	public void pickItem(Item item) {
		if (this.ItemInHand != null){
			throw new Exception("Already have something !");
		}
		this.ItemInHand = item;
	}
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
