namespace EntryPoint.ExceptionHandeling.HandelResults
{
    public class GetCommonUserResult
    {
        public string? ErrorMessage { get; set; }
        public bool IsSuccessful { get; set; }
        public CommonUser? User { get; set; }

        public static GetCommonUserResult Success(CommonUser pUser)
        {
            return new GetCommonUserResult()
            {
                IsSuccessful = true,
                User = pUser
            };
        }

        public static GetCommonUserResult Error(int id)
        {
            return new GetCommonUserResult()
            {
                ErrorMessage = $"User not found with id {id}",
            };
        }
    }
}
