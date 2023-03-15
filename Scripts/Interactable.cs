using Godot;

public partial class Interactable : Node2D
{
	[Export]
	Resource DialogueResource;
	[Export]
	string DialogueTitle;
	[Export]
	Texture2D Sprite;
	private Sprite2D _tooltip;
	private bool _canInteract;
	private bool _dialogOpened;
	private Area2D _interactionRange;
	private Sprite2D _sprite2D;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_tooltip = GetNode<Sprite2D>("Tooltip");
		_sprite2D = GetNode<Sprite2D>("Sprite2D");
		_sprite2D.Texture = Sprite;
		_interactionRange = GetNode<Area2D>("InteractionRange");
		_interactionRange.Connect(Area2D.SignalName.BodyEntered, Callable.From((Node2D body) => this.OnInteractionAreaEntered(body)));
		_interactionRange.Connect(Area2D.SignalName.BodyExited, Callable.From((Node2D body) => this.OnInteractionAreaExited(body)));
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (_canInteract && Input.IsActionPressed("interact") && !_dialogOpened) {
			_dialogOpened = true;
			GetNode<DialogueUiManager>("/root/DialogueUiManager").StartDialogue(DialogueResource, DialogueTitle, OnDialogueFinished);
		}
	}

    private void OnDialogueFinished()
    {
        _dialogOpened = false;
    }

	public void OnInteractionAreaEntered(Node2D body) 
	{
		if (body is CharacterBody2D){
			_canInteract = true;
			_tooltip.Visible = true;
		}
	}

	public void OnInteractionAreaExited(Node2D body) 
	{
		if (body is CharacterBody2D){
			_tooltip.Visible = false;
			_canInteract = false;
		}
	}
}
