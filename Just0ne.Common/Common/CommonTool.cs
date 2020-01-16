using System;

namespace Just0ne.Common
{
    /// <summary>
    /// @公共工具方法
    /// </summary>
    public static class CommonTool
    {
        /// <summary>
        /// string 转化int32 位
        /// </summary>
        /// <param name="text">需要转换的值</param>
        /// <param name="defaultValue">转换失败 默认值</param>
        /// <returns></returns>
        public static int ConvertInt32(this string text ,int defaultValue)
        {
            bool isSuccess = int.TryParse(text, out int result);
            return isSuccess ? result : defaultValue;
        }

    }
}