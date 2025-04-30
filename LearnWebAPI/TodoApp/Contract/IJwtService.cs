using Entities.Models;

namespace Contract
{
    public interface IJwtService
    {
        string GenerateToken(Employee employee);
    }
}
