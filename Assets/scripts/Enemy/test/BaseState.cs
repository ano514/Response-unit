public abstract class BaseState
{
    public Enemy enemy;
    public StateMachine stateMachine;
    public abstract void Enter();
    public abstract void Perfomr();
    public abstract void Exit();
}