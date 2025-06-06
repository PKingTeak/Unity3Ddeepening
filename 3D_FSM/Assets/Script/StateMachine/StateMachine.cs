

public interface IState
{
    public void Enter();
    public void Exit();
    public void HandleInput();
    public void Update();
    public void PhysicsUpdate();


}

public abstract class StateMachine 
{
    protected IState currentstate;

    public void ChangeState(IState state)
    {
        currentstate?.Exit();
        currentstate = state;
        currentstate?.Enter();
    }
    public void HandleInput()
    {

        currentstate?.HandleInput();
    }


    public void Update()
    {
        currentstate?.Update();
    }

    public void PhysicsUpdate()
    {
        currentstate?.PhysicsUpdate();
    }
}
