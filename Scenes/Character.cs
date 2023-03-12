using Godot;
using Godot.Collections;
public partial class Character : CharacterBody2D
{
	[Export]
	public float Speed = 300;

	public bool InputEnabled { get; set; }

	private AnimationTree _animationTree;
	private AnimationNodeStateMachinePlayback _animStateMachine;
	private Direction _currentDirection;
	private bool _isWalking;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_animationTree = GetNode<AnimationTree>("AnimationTree");
		_animStateMachine = (AnimationNodeStateMachinePlayback)_animationTree.Get("parameters/playback");

		InputEnabled = true;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		var direction = InputEnabled ? Input.GetVector("move_left", "move_right", "move_up", "move_down") : Vector2.Zero;
		Velocity = direction * Speed;
		if (direction.Length() > 0){
			_animStateMachine.Travel("walk");
			_animationTree.Set("parameters/idle/blend_position", direction);
			_animationTree.Set("parameters/walk/blend_position", direction);
		}
		else {
			_animStateMachine.Travel("idle");
		}
		MoveAndSlide();
	}
}
