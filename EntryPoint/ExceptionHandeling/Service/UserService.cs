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
    }
}