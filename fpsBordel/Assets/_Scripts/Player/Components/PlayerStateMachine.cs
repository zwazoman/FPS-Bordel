using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    #region PlayerMain Link

    [SerializeField] public  PlayerMain main;

    private void Awake()
    {
        if (main == null)
            TryGetComponent(out main);
    }
    #endregion

    #region States
    public PlayerMoveState moveState = new();
    public PlayerAirbornState airbornState = new();
    public PlayerLockedState lockedState = new();
    #endregion

    PlayerState currentState;

    private void Start()
    {
        TransitionTo(moveState);
    }

    public void TransitionTo(PlayerState state)
    {
        if(currentState != null)
            currentState.OnExit();

        currentState = state;

        currentState.OnEnter();
        print(currentState.ToString() + " entered");
    }

    private void Update()
    {
        currentState.Update();
    }

    private void FixedUpdate()
    {
        
    }
}
