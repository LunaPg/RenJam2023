using Godot;
using System;

public partial class DialogueTrigger : Area2D
{
    [Export]
    Resource DialogueResource;
    [Export]
    string Title = "start";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		BodyEntered += OnBodyEntered;
	}

	private void OnBodyEntered(Node2D body)
	{
		GetNode<DialogueUiManager>("/root/DialogueUiManager").StartDialogue(DialogueResource, Title);
    }
}
