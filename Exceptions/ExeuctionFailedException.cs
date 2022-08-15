namespace Exceptions
{
    public class ExeuctionFailedException : Exception
    {
        public string? Reason { get; set; }
        public Exception? Exception { get; set; }
    }
}
