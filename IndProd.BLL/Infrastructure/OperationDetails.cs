namespace IndProd.BLL.Infrastructure
{
    public class OperationDetails
    {
        public OperationDetails(bool successed, string message, string property)
        {
            Successed = successed;
            Message = message;
            Property = property;
        }
        public bool Successed { get; private set; }
        public string Message { get; private set; }
        public string Property { get; private set; }
    }
}
