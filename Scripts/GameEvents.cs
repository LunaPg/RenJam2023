using Godot;

public partial class GameEvents : Node
{
    [Signal]
    public delegate void NewGameEventHandler();

    [Signal]
    public delegate void ExitGameEventHandler();

    [Signal]
    public delegate void ExitToMainMenuEventHandler();

    [Signal]
    public delegate void PickItemEventHandler();
    [Signal]
    public delegate void DropItemEventHandler();
}
