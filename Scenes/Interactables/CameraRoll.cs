using Godot;
using System.Threading.Tasks;

public partial class CameraRoll : Node2D, Interactable
{
	PackedScene BalloonScene = ResourceLoader.Load<PackedScene>("res://Scripts/Dialogue/balloon.tscn");
	Resource DialogResource = ResourceLoader.Load<Resource>("res://Resources/test.dialogue");
	Sprite2D Tooltip;
	private Character character;
	private Callable dialogFinishedCallable;
	private bool _canInteract;
	private bool _dialogOpened;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		dialogFinishedCallable = new Callable(this, "OnDialogueFinished");
		Tooltip = GetNode<Sprite2D>("Tooltip");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		if (_canInteract && Input.IsActionPressed("interact") && !_dialogOpened) {
			_dialogOpened = true;
			Interact();
		}
	}

    public async Task Interact()
    {
        character.InputEnabled = false;

		Engine.GetSingleton("DialogueManager").Connect("dialogue_finished", dialogFinishedCallable);

		await ToSignal(GetTree().CreateTimer(0.4), "timeout");

		Balloon balloon = (Balloon)BalloonScene.Instantiate();
		AddChild(balloon);
		balloon.Start(DialogResource, "convo_test");
    }

	public void OnInteractionAreaEntered(Node2D body) {
		character = body as Character;
		if (character != null) {
			_canInteract = true;
			Tooltip.Visible = true;
		}
	}

	public void OnInteractionAreaExited(Node2D body) {
		Tooltip.Visible = false;
		_canInteract = false;
	}


    private void OnDialogueFinished()
    {
		character.InputEnabled = true;
		Engine.GetSingleton("DialogueManager").Disconnect("dialogue_finished", dialogFinishedCallable);
		_dialogOpened = false;
    }
}
