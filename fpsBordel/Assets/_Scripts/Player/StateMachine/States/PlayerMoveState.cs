public class PlayerMoveState : PlayerState
{
    public override void OnEnter()
    {
        stateMachine.main.inputs.OnMove += stateMachine.main.movement.Move;
        stateMachine.main.inputs.OnMouseMove += stateMachine.main.movement.Look;
        stateMachine.main.inputs.OnLock += () => stateMachine.TransitionTo(stateMachine.lockedState);
    }

    public override void OnExit()
    {
        throw new System.NotImplementedException();
    }

    public override void Update()
    {
        throw new System.NotImplementedException();
    }
}
