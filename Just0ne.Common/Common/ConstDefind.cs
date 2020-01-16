using System;
using System.Data;

namespace Just0ne.Common
{
    /// <summary>
    ///@公共常量
    /// </summary>
    public partial class ConstDefind
    {

    }

    /// <summary>
    ///@静态配置
    /// </summary>
    public partial class ConstDefind
    {

        #region  队列 账号

        /// <summary>
        /// 本地
        /// </summary>
        public const string LOCALHOST = "localhost";

        /// <summary>
        /// 队列地址
        /// </summary>
        public static string RABBIT_HOST = "";

        /// <summary>
        /// 队列账号
        /// </summary>
        public static string RABBIT_USER = "";

        /// <summary>
        /// 队列密码
        /// </summary>
        public static string RABBIT_PASSWORD = "";

        /// <summary>
        /// 通讯端口
        /// </summary>
        public static int RABBIT_PROT = "".ConvertInt32(5672);

        #endregion 队列 账号


    }
}