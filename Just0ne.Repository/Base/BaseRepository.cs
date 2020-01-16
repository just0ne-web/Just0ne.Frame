using Just0ne.Model;
using System.Data.Common;
using Just0ne.IRepository;

namespace Just0ne.Repository
{
    /// <summary>
    /// 仓储层
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseRepository<T> : IBaseRepository<T>, IDependency where T :  BaseEntity
    {

        /// <summary>
        /// 查询单条(从库)
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="param">参数</param>
        /// <param name="transaction">事务</param>
        /// <returns></returns>
        public T GetModelByRead(string sql, object param = null, DbTransaction transaction = null) 
        {
            return  default(T) ;
        }

    }
}