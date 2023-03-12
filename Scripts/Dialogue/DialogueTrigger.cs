using Godot;
using System;

public partial class DialogueTrigger : Area2D
{
    [Export]
    PackedScene Balloon;

    [Export]
    string Title = "start";

    [Export]
    Resource DialogueResource;

	Character character;
	Callable dialogueFinishedCallable;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		BodyEntered += OnBodyEntered;
		dialogueFinishedCallable = new Callable(this, "OnDialogueFinished");
	}

	private async void OnBodyEntered(Node2D body)
	{
		character = body as Character;

		if (character != null)
		{
			character.InputEnabled = false;

			Engine.GetSingleton("DialogueManager").Connect("dialogue_finished", dialogueFinishedCallable);

			await ToSignal(GetTree().CreateTimer(0.4), "timeout");

			Balloon balloon = (Balloon)Balloon.Instantiate();
			AddChild(balloon);
			balloon.Start(DialogueResource, Title);
		}
    }


    private void OnDialogueFinished()
    {
		character.InputEnabled = true;
		Engine.GetSingleton("DialogueManager").Disconnect("dialogue_finished", dialogueFinishedCallable);
    }
}
