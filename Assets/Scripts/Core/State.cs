namespace RPG.Core
{
    public abstract class State<T>
    {
        public T controller;
        public StateMachine<T> state;
        
        protected State(T controller, StateMachine<T> state)
        {
            this.controller = controller;
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