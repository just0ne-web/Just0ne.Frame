using System;
using Dapper;
using System.Data;
using DapperExtensions;
using System.Data.SqlClient;
using System.Linq;
using System.Collections.Generic;
using System.Data.Common;
namespace Just0ne.Common
{
    /// <summary>
    /// @MSSQLdapper帮助类
    /// </summary>
    public class MSSqlDapperHelper
    {
        #region  初始化

        /// <summary>
        /// 读
        /// </summary>
        static string READ_STR = "";

        /// <summary>
        /// 写
        /// </summary>
        static string WRITE_STR = "";


        /// <summary>
        /// 返回数据库连接
        /// </summary>
        /// <param name="isWrite">是否读库</param>
        /// <returns></returns>
        public static SqlConnection GetConnection(bool isWrite = false)
        {
            return isWrite ? new SqlConnection(WRITE_STR) : new SqlConnection(READ_STR);
        }

        /// <summary>
        /// 打开数据库连接
        /// </summary>
        /// <returns></returns>
        public static SqlConnection OpenConnection()
        {
            SqlConnection connection = new SqlConnection(WRITE_STR);
            connection.Open();
            return connection;
        }

        #endregion 初始化

        #region  查询

        /// <summary>
        /// 执行sql返回一个实体
        /// </summary>
        /// <param name="sql">待执行的sql</param>
        /// <param name="param">参数</param>
        /// <param name="transaction">事务</param>
        /// <param name="isWrite">是否读库</param>
        /// <typeparam name="T">返回实体类型</typeparam>
        /// <returns></returns>
        public static T ExecuteSqlReturnT<T>(string sql, object param = null, DbTransaction transaction = null, bool isWrite = false)
        {
            if (transaction == null)
            {
                using (var connection = GetConnection(isWrite))
                {
                    connection.Open();
                    return connection.QueryFirstOrDefault<T>(sql, param, transaction);
                }
            }
            else
            {
                return transaction.Connection.QueryFirstOrDefault<T>(sql, param, transaction);
            }

        }

        /// <summary>
        /// 执行sql返回一集合
        /// </summary>
        /// <param name="sql">待执行的sql</param>
        /// <param name="param">参数</param>
        /// <param name="transaction">事务</param>
        /// <param name="isWrite">是否读库</param>
        /// <typeparam name="T">返回实体类型</typeparam>
        /// <returns></returns>
        public static List<T> ExecuteSqlReturnList<T>(string sql, object param = null, DbTransaction transaction = null, bool isWrite = false)
        {

            if (transaction == null)
            {
                using (var connection = GetConnection(isWrite))
                {
                    connection.Open();
                    return connection.Query<T>(sql, param, transaction).ToList();
                }
            }
            else
            {
                return transaction.Connection.Query<T>(sql, param, transaction).ToList();
            }
        }

        #endregion 查询

        #region  增删改

        /// <summary>
        /// 执行sql返回受影响行数
        /// </summary>
        /// <param name="sql">待执行的sql</param>
        /// <param name="param">参数</param>
        /// <param name="transaction">事务</param>
        /// <returns></returns>
        public static int ExecuteSqlInt(string sql, object param = null, DbTransaction transaction = null)
        {

            if (transaction == null)
            {
                using (var connection = GetConnection(true))
                {
                    connection.Open();
                    return connection.Execute(sql, param, transaction: null);
                }
            }
            else
            {
                return transaction.Connection.Execute(sql, param, transaction);
            }
        }

        /// <summary>
        /// 添加一条数据并返回主键
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        public static long ExecuteInsert<T>(T data, DbTransaction transaction = null) where T : class
        {

            if (transaction == null)
            {
                using (var connection = GetConnection(true))
                {
                    connection.Open();
                    return (long)connection.Insert<T>(data, transaction: null);
                }
            }
            else
            {
                return (long)transaction.Connection.Insert<T>(data, transaction);
            }
        }

        #endregion 增删改



    }
}