using Godot;
using System;

public partial class GameProgress : Node
{
	public enum GriefStage
	{
		Denial,
		Anger,
		Depression,
		Bargaining,
		Acceptance
	}

	private GriefStage _griefStage;
	public string grief_stage {get { return _griefStage.ToString(); }}
	public GriefStage griefStage { get {return _griefStage; } set {_griefStage = value; }}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
