namespace RPAdev.Domain
{
    public class Response
    {       
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }

        public Response()
        {
        }

        public Response(bool isSuccessful, string message)
        {
            IsSuccessful = isSuccessful;
            Message = message;
        }

    }
}
