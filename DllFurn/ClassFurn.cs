using DllBase;
using EasySocket.vs13.Core;
using EasySocket.vs13.Telegram.Easy;
using Log4Ex;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllFurn
{
    /// <summary>
    /// 加热炉操作
    /// </summary>
    public class ClassFurn:EasyApiService
    {
        /// <summary>
        /// 获取其它已登录的会话
        /// </summary>
        public IEnumerable<EasySession> OtherSessions
        {
            get
            {
                return this
                    .CurrentContext
                    .EasySessions
                    .Where(item =>
                    item != this.CurrentContext.Session &&
                    item.Tag.Get("category").Value.ToString() == "client");
            }
        }

            /// 登录操作
            /// </summary>       
            /// <param name="user">用户数据</param>
            /// <param name="ifAdmin"></param>
            /// <returns></returns>    
            [Api]
        [EasyLogFilter("加热炉-入炉")]
        public void FurnIn()
        {
            // 通知其它fast会话加热炉发生变化
            foreach (var session in this.OtherSessions)
            {
                //session.InvokeApi("LoginNotify", 1, user.Account);
            }
            using (var db = SugarDao.Instance)
            {
                try
                {
                    var result = db.Ado.UseStoredProcedure().GetDecimal("sgis_track.ENTER_RF");
                }
                catch (Exception ex)
                {
                    LogHelper.Error(ex.Message.ToString());
                    throw;
                }
            }
        }

    }
}
