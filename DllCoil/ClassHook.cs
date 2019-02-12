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

namespace DllCoil
{
    /// <summary>
    /// 集卷操作
    /// </summary>
    public static class ClassHook
    {
        [Api]
        [EasyLogFilter("PF线集卷上钩")]
        public static void CoilHookFinish(this IOpc opc,int hookNo)
        {
            // 通知其它fast会话加热炉发生变化
            //foreach (var session in this.OtherSessions)
            //{
            //    session.InvokeApi("LoginNotify", 1, user.Account);
            //}
            LogHelper.Debug($"PF线集卷上钩，钩号{hookNo}");
            using (var db = SugarDao.Instance)
            {
                try
                {
                    //钩号
                    var hookNoP = new SugarParameter("@p_hookno", hookNo);
                    //支持output
                    var retvalP1 = new SugarParameter("@retval", null, true);//isOutput=true
                    db.Ado.UseStoredProcedure().GetInt("sgis_track.finish_hook", retvalP1);

                    //DBOleDb.ExecutePorcedure("sgis_track.update_millspd", new OleDbParameter[] { op2, op3, op4, op5, op1 }); //更新粗轧入口速度
                    //DBOleDb.ExecutePorcedure("sgis_track.update_milltm", new OleDbParameter[] { op2, op3, op6, op7, op1 });//更新粗轧入口温度 
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

    }
}
