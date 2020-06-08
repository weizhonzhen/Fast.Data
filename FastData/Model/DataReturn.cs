using System.Collections.Generic;
using System.Data;
using FastUntility.Page;

namespace FastData.Model
{
    /// <summary>
    /// 返回操作数据结果
    /// </summary>
    public sealed class DataReturn<T> where T : class,new()
    {
        /// <summary>
        /// 条数
        /// </summary>
        public int count { get; set; }

        /// <summary>
        /// 实体
        /// </summary>
        public T item { set; get; } = new T();

        /// <summary>
        /// 列表
        /// </summary>
        public List<T> list { set; get; } = new List<T>();

        /// <summary>
        /// sql
        /// </summary>
        public string sql { get; set; }

        /// <summary>
        /// 分页
        /// </summary>
        public PageResult<T> pageResult { set; get; } = new PageResult<T>();

        /// <summary>
        /// 写返回结果
        /// </summary>
        public WriteReturn writeReturn { set; get; } = new WriteReturn();
    }

     /// <summary>
    /// 返回操作数据结果
    /// </summary>
    public class DataReturn
    {
        /// <summary>
        /// 条数
        /// </summary>
        public int Count { get; set; }
        
        /// <summary>
        /// sql
        /// </summary>
        public string Sql { get; set; }

        /// <summary>
        /// json
        /// </summary>
        public string Json { get; set; }

        /// <summary>
        /// dic list
        /// </summary>
        public List<Dictionary<string, object>> DicList { get; set; } = new List<Dictionary<string, object>>();

        /// <summary>
        /// dic item
        /// </summary>
        public Dictionary<string, object> Dic { get; set; } = new Dictionary<string, object>();

        /// <summary>
        /// data table
        /// </summary>
        public DataTable Table { get; set; } = new DataTable();

        /// <summary>
        /// 分页
        /// </summary>
        public PageResult PageResult { set; get; } = new PageResult();

        /// <summary>
        /// 写返回结果
        /// </summary>
        public WriteReturn writeReturn { set; get; } = new WriteReturn();
    }

    /// <summary>
    /// 写返回结果
    /// </summary>
    public class WriteReturn
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// 出错信息
        /// </summary>
        public string Message { get; set; }
    }
}
