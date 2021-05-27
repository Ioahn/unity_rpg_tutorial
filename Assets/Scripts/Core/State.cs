namespace RPG.Core
{
    public abstract class State<T>
    {
        public T stateManager;
        public StateMachine<T> state;
        
        protected State(T stateManager, StateMachine<T> state)
        {
            this.stateManager = stateManager;
            this.state = state;
        }

        public virtual void Enter()
        {
            
        }

        public virtual void Exit()
        {
            
        }

        public virtual void HandleInput()
        {
            
        }

        public virtual void LogicUpdate()
        {
            
        }

        public virtual void PhysicsUpdate()
        {
            
        }
    }
}