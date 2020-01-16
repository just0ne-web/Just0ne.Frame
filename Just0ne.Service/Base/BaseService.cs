using System;
using System.Data;
using Just0ne.Model;
using Just0ne.IService;
using Just0ne.IRepository;
using System.Data.Common;
namespace Just0ne.Service
{
    public class BaseService<T> : IBaseService<T>, IDependency where T : BaseEntity
    {
        public  static  IBaseRepository<T> _baseRepository;
        public BaseService(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        /// <summary>
        /// 查询单条(从库)
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="param">参数</param>
        /// <param name="transaction">事务</param>
        /// <returns></returns>
        public T GetModelByRead(string sql, object param = null, DbTransaction transaction = null)
        {
               return _baseRepository.GetModelByRead(sql,param,transaction);
        }
    }
}