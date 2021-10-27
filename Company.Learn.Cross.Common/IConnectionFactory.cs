using System.Data;

namespace Company.Learn.Cross.Common
{
    public interface IConnectionFactory
    {
        IDbConnection GetConnection { get; }
    }
}
