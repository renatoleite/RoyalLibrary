namespace Application.Shared
{
    public class Output<TResult>
    {
        protected Output()
        {
        }

        public Output(TResult data)
        {
            Data = data;
        }

        public TResult Data { get; }
    }
}
