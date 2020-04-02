﻿using System;
using System.Linq;
using System.Reflection;

namespace FastUntility.Base
{
    public static class BaseMap
    {
        /// <summary>
        /// 对象复制
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public static T CopyModel<T, T1>(T1 model) where T : class, new()
        {
            var result = new T();
            var dynGet = new DynamicGet<T1>();
            var dynSet = new DynamicSet<T>();
            var list = BaseDic.PropertyInfo<T>();

            foreach (var item in BaseDic.PropertyInfo<T1>())
            {
                var info = list.Find(a => a.Name.ToLower() == item.Name.ToLower());

                if (info.PropertyType.Namespace == "System")
                {
                    if (item.PropertyType.Name == "Nullable`1" && item.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                        dynSet.SetValue(result, info.Name, dynGet.GetValue(model, item.Name, true), true);
                    else
                        dynSet.SetValue(result, info.Name, Convert.ChangeType(dynGet.GetValue(model, item.Name, true), item.PropertyType), true);
                }
                else
                {
                    var tempModel = Convert.ChangeType(dynGet.GetValue(model, item.Name, true), item.PropertyType);
                    var leafModel = Activator.CreateInstance(info.PropertyType.Assembly.GetType(info.PropertyType.FullName));
                    var leafList = (info.PropertyType as TypeInfo).GetProperties().ToList();
                    foreach (var leaf in (item.PropertyType as TypeInfo).GetProperties())
                    {
                        if (leafList.Exists(a => a.Name == leaf.Name))
                        {
                            var temp = leafList.Find(a => a.Name.ToLower() == leaf.Name.ToLower());
                            temp.SetValue(leafModel, leaf.GetValue(tempModel));
                        }
                    }
                    dynSet.SetValue(result, info.Name, leafModel, true);
                }
            }

            return result;
        }
    }
}