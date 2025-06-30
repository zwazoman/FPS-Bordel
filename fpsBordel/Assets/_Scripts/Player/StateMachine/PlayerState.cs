public abstract class PlayerState
{
    public PlayerStateMachine stateMachine;

    public abstract void OnEnter();

    public abstract void Update();

    public abstract void OnExit();
}
