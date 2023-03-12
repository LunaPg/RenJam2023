using Godot;

public partial class Interactable : Node2D
{
	[Export]
	Resource DialogueResource;
	[Export]
	string DialogueTitle;
	private Sprite2D _tooltip;
	private bool _canInteract;
	private bool _dialogOpened;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_tooltip = GetNode<Sprite2D>("Tooltip");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (_canInteract && Input.IsActionPressed("interact") && !_dialogOpened) {
			_dialogOpened = true;
			GetNode<DialogueUiManager>("/root/DialogueUiManager").StartDialogue(DialogueResource, DialogueTitle);
		}
	}

    private void OnDialogueFinished()
    {
        _dialogOpened = false;
    }

	public void OnInteractionAreaEntered(Node2D body) 
	{
		_canInteract = true;
		_tooltip.Visible = true;
	}

	public void OnInteractionAreaExited(Node2D body) 
	{
		_tooltip.Visible = false;
		_canInteract = false;
	}
}
