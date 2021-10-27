using Company.Learn.Cross.Common;
using Company.Learn.Domain.Entity;
using Company.Learn.Infrastructure.Interface;
using Dapper;

namespace Company.Learn.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public UserRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public User Authenticate(string userName, string password)
        {
            using (var conn = _connectionFactory.GetConnection)
            {
                var query = "LoginUser";
                var parameters = new DynamicParameters();
                parameters.Add("userName", userName);
                parameters.Add("password", password);

                var user = conn.QuerySingle<User>(
                    sql: query,
                    param: parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                );

                return user;
            }
        }
    }
}
