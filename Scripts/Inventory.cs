using Godot;
using System;

public partial class Inventory : Node
{

 [Export]
 Button itemButton;

	public void PickItem(string itemName){
		Catalog catalog =  GetNode<Catalog>("/root/Catalog");
		Item item = catalog.findItem(itemName);
		if (item != null)
		{
			itemButton.Icon = GD.Load<Texture2D>(item.icon);
		}
	}
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		this.itemButton = new Button();
		this.itemButton.Text = "film";
    	AddChild(itemButton);

		// Testing purpose : Add item in inventory on spawn
		this.PickItem("film");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
