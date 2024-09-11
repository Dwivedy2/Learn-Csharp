using EntryPoint.ExceptionHandeling.HandelResults;
namespace EntryPoint.ExceptionHandeling.Service
{
    public class UserService
    {
        List<CommonUser> users = new List<CommonUser>()
        {
            new CommonUser("Omkareshwar Nath Dwivedy"),
            new CommonUser("Pavan Singh"),
        };

        public GetCommonUserResult GetUserById(int id)
        {
            bool isValid = ValidateId(id);

            if(id == 100)
            {
                throw new CustomExceptionHandel($"User id: {id} is already reserved, you cannot use this.");
            }

            if (!isValid)
            {
                throw new ArgumentException("Invalid Id.");
            }

            CommonUser resUser = users.Find(user => user.Id == id);
            GetCommonUserResult result;
            if (resUser != null)
            {
                result = GetCommonUserResult.Success(resUser);
            }
            else
            {
                result = GetCommonUserResult.Error(id);
            }
            return result;
        }

        public bool ValidateId(int id)
        {
            return (id <= 0 && id > users.Count());
        }
    }
}