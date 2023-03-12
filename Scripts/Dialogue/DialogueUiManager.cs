using Godot;
using System;

public partial class DialogueUiManager : Node
{
    PackedScene balloon;
	Character character;
	Callable dialogueFinishedCallable;
	Action onFinishedCallback;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		dialogueFinishedCallable = new Callable(this, "OnDialogueFinished");
		balloon = GD.Load<PackedScene>("res://Scripts/Dialogue/balloon.tscn");
	}

	public async void StartDialogue(Resource dialogueResource, string dialogueTitle, Action onFinished = null)
	{
		character = GetNode<Character>("/root/Node/Game/Character");
		character.InputEnabled = false;

		onFinishedCallback = onFinished;

		Engine.GetSingleton("DialogueManager").Connect("dialogue_finished", dialogueFinishedCallable);

		await ToSignal(GetTree().CreateTimer(0.4), "timeout");

		Balloon balloon = (Balloon)this.balloon.Instantiate();
		AddChild(balloon);
		balloon.Start(dialogueResource, dialogueTitle);
    }

    private void OnDialogueFinished()
    {
		Engine.GetSingleton("DialogueManager").Disconnect("dialogue_finished", dialogueFinishedCallable);
		character.InputEnabled = true;
		if (onFinishedCallback != null)
		{
			onFinishedCallback();
			onFinishedCallback = null;
		}
    }
}