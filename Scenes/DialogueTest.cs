using Godot;

public partial class DialogueTest : Node2D
{
    [Export]
    PackedScene Balloon;

    [Export]
    string Title = "start";

    [Export]
    Resource DialogueResource;


    public async override void _Ready()
    {
        Engine.GetSingleton("DialogueManager").Connect("dialogue_finished", new Callable(this, "OnDialogueFinished"));

        await ToSignal(GetTree().CreateTimer(0.4), "timeout");

        Balloon balloon = (Balloon)Balloon.Instantiate();
        AddChild(balloon);
        balloon.Start(DialogueResource, Title);
    }


    private async void OnDialogueFinished()
    {
        await ToSignal(GetTree().CreateTimer(0.4), "timeout");
        GetTree().Quit();
    }
}
