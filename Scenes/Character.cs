using Godot;
using Godot.Collections;
public partial class Character : CharacterBody2D
{
	[Export]
	public float Speed = 300;

	public bool InputEnabled { get; set; }

	private AnimationNodeStateMachinePlayback _animStateMachine;
	private Direction _currentDirection;
	private bool _isWalking;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var animationTree = GetNode<AnimationTree>("AnimationTree");
		_animStateMachine = (AnimationNodeStateMachinePlayback)animationTree.Get("parameters/playback");

		InputEnabled = true;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		var direction = InputEnabled ? Input.GetVector("move_left", "move_right", "move_up", "move_down") : Vector2.Zero;
		Velocity = direction * Speed;
		if (direction.Length() > 0){
			_animStateMachine.Travel("walk");
		}
		else {
			_animStateMachine.Travel("idle");
		}
		MoveAndSlide();
	}
}
