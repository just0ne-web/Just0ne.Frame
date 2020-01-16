using RabbitMQ.Client;
using Just0ne.Common;

namespace Just0ne.RabbitMQ
{
    /// <summary>
    /// @ 创建 rabbit连接
    /// </summary>
    public class RabbitMQConnect
    {
        public static ConnectionFactory factory = null;
        static string _rabbitHost = ConstDefind.RABBIT_HOST;
        static string _rabbitUser = ConstDefind.RABBIT_USER;
        static string _rabbitPwd = ConstDefind.RABBIT_PASSWORD;
        static int _rabbitProt = ConstDefind.RABBIT_PROT;

        /// <summary>
        ///创建队列链接 
        /// </summary>
        static RabbitMQConnect()
        {
            if (_rabbitHost == ConstDefind.LOCALHOST)
            {
                factory = new ConnectionFactory() { HostName = _rabbitHost };
            }
            else
            {
                factory = new ConnectionFactory() { HostName = _rabbitHost, UserName = _rabbitUser, Password = _rabbitPwd, Port = _rabbitProt };
            }
        }
    }
}