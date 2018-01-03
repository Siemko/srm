namespace Azynmag.Services.Contracts
{
    public class BaseContractResponse
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }

        public BaseContractResponse()
        {
            Success = true;
        }
    }
}
