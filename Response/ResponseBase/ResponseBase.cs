namespace Raizes.Response.ResponseBase
{
    public class ResponseBase<T> where T : class
    {
        public IEnumerable<T> Data { get; set; }

        public ResponseBase(IEnumerable<T> data)
        {
            Data = data;
        }
    }
}
