﻿using Fast.Context;
using Fast.Model;
using System.Runtime.Remoting.Messaging;

namespace Fast.Base
{
    internal static class BaseContext
    {
        #region 获取读上下文
        /// <summary>
        /// 获取读上下文
        /// </summary>
        /// <returns></returns>
        public static DataContext GetContext(DataQuery item)
        {
            return new DataContext(item.Key, item.Config); 
        }
        #endregion

        #region 获取读上下文
        /// <summary>
        /// 获取读上下文
        /// </summary>
        /// <returns></returns>
        public static DataContext GetContext(string key)
        {
            return new DataContext(key);            
        }
        #endregion
    }
}