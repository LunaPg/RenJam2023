using Godot;
using System;

public partial class MainMenu : Control
{
	GameEvents GameEvents;
	public override void _Ready()
	{
		GameEvents = GetNode<GameEvents>("/root/GameEvents");
	}

	public void OnNewGamePressed() {
		GameEvents.EmitSignal(GameEvents.SignalName.NewGame);
	}

}
