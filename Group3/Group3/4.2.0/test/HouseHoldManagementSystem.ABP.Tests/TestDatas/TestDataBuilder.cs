using HouseHoldManagementSystem.ABP.EntityFrameworkCore;

namespace HouseHoldManagementSystem.ABP.Tests.TestDatas
{
    public class TestDataBuilder
    {
        private readonly ABPDbContext _context;

        public TestDataBuilder(ABPDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            _context.LoginUsers.AddRange(
                new LoginUser.LoginUser()
                {
                    LoginName = "Admin",
                    Password = "123qwe"
                }
                );
        }
    }
}