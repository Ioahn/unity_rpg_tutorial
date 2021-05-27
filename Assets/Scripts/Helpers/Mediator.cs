namespace RPG.Helpers
{
    public interface IMediator
    {
        void Notify(object sender, string ev);
        
        void Notify<T>(object sender, string ev, T arg);
    }

    public class BaseMediatorComponent
    {
        protected IMediator _mediator;

        public BaseMediatorComponent(IMediator mediator = null)
        {
            this._mediator = mediator;
        }

        public void SetMediator(IMediator mediator)
        {
            this._mediator = mediator;
        }
    }

}