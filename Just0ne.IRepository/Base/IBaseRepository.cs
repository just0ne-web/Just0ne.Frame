using Just0ne.Model;
using System.Data.Common;
namespace Just0ne.IRepository
{

    public interface IBaseRepository<T> :IDependency where T: BaseEntity 
    {
        /// <summary>
        /// 查询单条(从库)
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="param">参数</param>
        /// <param name="transaction">事务</param>
        /// <returns></returns>
        T GetModelByRead(string sql,object param =null,DbTransaction transaction=null);

    }
}