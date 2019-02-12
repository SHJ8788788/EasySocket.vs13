using DllBase;
using DllClient;
using DllOpc;
using EasySocket.vs13.Core;
using EasySocket.vs13.Telegram.Easy;
using Log4Ex;
using SqlSugar;
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
    public static class ClassFurn
    {
        /// <summary>
        /// 加热炉-入炉
        /// </summary>
        /// <param name="opc"></param>
        public static void FurnIn(this IOpc opc)
        {
            // 通知其它fast会话加热炉发生变化
            //foreach (var session in this.OtherSessions)
            //{
            //    session.InvokeApi("LoginNotify", 1, user.Account);
            //}
            var value = opc.OpLinkTagValue("Ramp101");
            opc.FurnChanged("加热炉炉内发生动作");
            LogHelper.Debug("加热炉-入炉");

            using (var db = SugarDao.Instance)
            {
                try
                {
                    //支持output
                    var retvalP = new SugarParameter("@retval", null, true);//isOutput=true
                    db.Ado.UseStoredProcedure().GetInt("sgis_track.enter_rf", retvalP);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// 加热炉-出炉
        /// </summary>
        /// <param name="opc"></param>
        public static void FurnOut(this IOpc opc)
        {
            // 通知其它fast会话加热炉发生变化
            //foreach (var session in this.OtherSessions)
            //{
            //    session.InvokeApi("LoginNotify", 1, user.Account);
            //}
            //加热炉出炉材料温度
            var chugang_temp = opc.OpLinkTagValue("Ramp101");
            LogHelper.Debug("加热炉-出炉");

            using (var db = SugarDao.Instance)
            {
                try
                {
                    //opc.OpLinkTagValue("333");  
                    //var tran_id = db.Ado.SqlQuerySingle<double>("select Itf_Tran_ID_S.NEXTVAL  from  dual");

                    //支持output
                    var retvalP = new SugarParameter("@retval", null, true);//isOutput=true
                    var outtmP = new SugarParameter("@p_outtm", null, false);//isOutput=false
                    db.Ado.UseStoredProcedure().GetInt("sgis_track.exit_rf", outtmP, retvalP);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
    }
}
