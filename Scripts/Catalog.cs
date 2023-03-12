using Godot;
using System.Collections.Generic;
using System.Text.Json;


	 public class ItemsJson
    {
			public Item[] items { get; set; }
    }
	
	public class Item
	{
		public string name { get; set; }
		public string description { get; set; }
		public string type { get; set; }
		public string icon { get; set; }
	}


public partial class Catalog : Node
{


		public List<Item> CatalogItems = new List<Item>();

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
