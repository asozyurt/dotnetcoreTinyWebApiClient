namespace TinyWebApiForBalanceAdjustment
{
    public class ApiResponse
    {
        public bool IsError { get; set; }
        public string ErrorDescription { get; set; }
        public static ApiResponse Success { get { return new ApiResponse(); } }
    }
}
