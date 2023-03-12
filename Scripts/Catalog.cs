using Godot;
using Godot.Collections;
using System;
using System.Text.Json;

 public class ItemsJson
    {
			public Array<Item> items { get; set; }
    }


public partial class Catalog : Node
{

	[Export]
		public Array<Item> CatalogItems;

	// Called when the node enters the scene tree for the first time.

	public Item findItem(string  itemName){
		for (int i = 0 ; i< CatalogItems.Count ; i++){
		GD.Print(CatalogItems[i].name);
			if (CatalogItems[i].name == itemName){
				return CatalogItems[i];
			}
			
		}
		return null;

	}
	public override void _Ready()
	{
		createCatalogItems(); 
	}

private void  createCatalogItems(){
	FileAccess file = FileAccess.Open("res://Assets/catalog.json", FileAccess.ModeFlags.Read);
	string content = file.GetAsText();
	var jsonObject = JsonSerializer.Deserialize<ItemsJson>(content);
		
		foreach(Item item in jsonObject.items){
			CatalogItems.Add(item);
		}
}


	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
