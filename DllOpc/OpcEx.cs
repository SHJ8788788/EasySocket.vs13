using EasySocket.vs13.Core;
using EasySocket.vs13.Telegram.Easy;
using Log4Ex;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllOpc
{
    /// <summary>
    /// 提供与Opc通讯的扩展方法
    /// 基于IOpc
    /// </summary>
    public static class OpcEx
    {
        public static String OpLinkTagValue(this IOpc opc, string tagName)
        {
            try
            {                
                var temp = GetTagValue(opc, tagName).Result;
                LogHelper.Info(string.Format($"获取Tag点成功，tagName = {tagName} ,value = {temp}"));
                return temp;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"tagName = { tagName}  "+ex.Message);
                return "0";               
            }
        }

        public static String GetTriggerValueFromOPC(this IOpc opc, string tagName)
        {
            try
            {
                var temp = GetTriggerValue(opc, tagName).Result;
                LogHelper.Info(string.Format($"获取Trigger点成功，tagName = {tagName} ,value = {temp}"));
                return temp;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"tagName = { tagName}  " + ex.Message);
                return "0";
            }            
        }
        public static List<TagSimple> GetTriggersFromOPC(this IOpc opc, List<string> tagNames)
        {
            try
            {
                var temp = GetTriggers(opc, tagNames).Result;
                LogHelper.Info(string.Format("返回需要的数据集合，tagsList = {0}", temp.ToString()));              
                return temp;
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.Message);
                return  null;
            }
        }
        public static List<TagSimple> OpLinkTags(this IOpc opc, List<string> tagNames)
        {
            try
            {
                var tagsList = GetTags(opc, tagNames).Result;
                //var sdf = tagsList.FirstOrDefault().ValueCast();
                LogHelper.Info(string.Format("返回需要的数据集合，tagsList = {0}", tagsList.ToString()));
                return tagsList;
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.Message);
                throw ex.InnerException;
            }
        }
        public static String OpLinkTagValueMaxBetweenDate(this IOpc opc, string tagName,DateTime dateFrom,DateTime dateTo = default(DateTime))
        {
            try
            {
                var value = GetTagValueMaxBetweenDate(opc, tagName, dateFrom, dateTo).Result;
                LogHelper.Info(string.Format($"获取Tag点成功，tagName = {tagName} ,value = {value}"));
                return value;          
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.Message);
                throw ex.InnerException;
            }
        }
        private static Task<string> GetTagValue(IOpc opc, string tagName)
        {
            return opc.OpcSession.InvokeApi<string>("GetTagValue", tagName); 
        }

        private static Task<string> GetTriggerValue(IOpc opc, string tagName)
        {
            return opc.OpcSession.InvokeApi<string>("GetTriggerValue", tagName);
        }

        private static Task<List<TagSimple>> GetTriggers(IOpc opc, List<string> tagNames)
        {
            return opc.OpcSession.InvokeApi<List<TagSimple>>("GetTriggers", tagNames);
        }

        private static Task<List<TagSimple>> GetTags(IOpc opc, List<string> tagNames)
        {
            return opc.OpcSession.InvokeApi<List<TagSimple>>("GetTags", tagNames);
        }
        private static Task<string> GetTagValueMaxBetweenDate(IOpc opc, string tagName, DateTime dateFrom, DateTime dateTo = default(DateTime))
        {
            return opc.OpcSession.InvokeApi<string>("GetTagValueMaxBetweenDate", tagName, dateFrom,dateTo);
        }
    }
}
