using DllBase;
using DllClient;
using DllOpc;
using EasySocket.vs13.Core;
using EasySocket.vs13.Telegram.Easy;
using Log4Ex;
using SqlSugar;
using Sugar.Enties;
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
        /// <summary>
        /// PF线集卷-上钩 HookA
        /// </summary>
        /// <param name="opc"></param>
        /// <param name="hookNo"></param>
        public static void CoilHookFinish(this IOpc opc,int hookNo)
        {
            string shift = "";
            string employee = "";
            DateTime hookTime = DateTime.Now;

            using (var db = SugarDao.Instance)
            {
                try
                {
                    db.Ado.BeginTran();

                    LogHelper.Info("**********************************************Begin***********************************************");
                    //取已进入精轧的第一支坯料
                    var matNoReadyMill = db.Queryable<BLT_PROC>().Where(p => p.BLT_FLG == "13").OrderBy(it => it.WR_RL_SAT_DT, OrderByType.Asc).First();
                    if (matNoReadyMill == null)
                    {
                        throw new Exception("风冷辊道材料不存在");
                    }
                    //取当班主轧操作员信息
                    var curShift = db.Queryable<CURSHIFT>().Where(it => it.ROLE == "集卷操作员").First();
                    shift = curShift.SHIFT_DATE + curShift.SHIFT_GROUP;
                    employee = curShift.USER_CODE;
                    LogHelper.Info($"待上钩材料号:{matNoReadyMill.BLT_NO} , 班组班别:{shift}");

                    //更新主档信息数据   
                    matNoReadyMill.WR_HOOK_DT = hookTime;
                    matNoReadyMill.BLT_FLG = "14";
                    matNoReadyMill.HANGING_OP_SFT = shift;
                    matNoReadyMill.EMPLOYEE_HANG = "AAAA";
                    matNoReadyMill.WR_HOOK_NUM =Convert.ToInt16( hookNo);
                   


                    LogHelper.Info($"更新材料主档信息,材料号:{matNoReadyMill.BLT_NO}");
                    db.Updateable<BLT_PROC>(matNoReadyMill).ExecuteCommand();                 

                    //事务提交
                    db.Ado.CommitTran();
                }
                catch (Exception e)
                {
                    //事务回滚
                    db.Ado.RollbackTran();
                    LogHelper.Error(e.Message);
                    LogHelper.Error("**********************************************End With Error***********************************************");
                    throw e;
                }
            }


            //LogHelper.Info($"PF线集卷上钩，钩号{hookNo}");
            //using (var db = SugarDao.Instance)
            //{
            //    try
            //    {
            //        //钩号
            //        var hookNoP = new SugarParameter("@p_hookno", hookNo);
            //        //支持output
            //        var retvalP = new SugarParameter("@retval", null, true);//isOutput=true
            //        var succ = db.Ado.UseStoredProcedure().GetInt("sgis_track.finish_hook", hookNoP, retvalP);

            //        //DBOleDb.ExecutePorcedure("sgis_track.update_millspd", new OleDbParameter[] { op2, op3, op4, op5, op1 }); //更新粗轧入口速度
            //        //DBOleDb.ExecutePorcedure("sgis_track.update_milltm", new OleDbParameter[] { op2, op3, op6, op7, op1 });//更新粗轧入口温度 
            //    }
            //    catch (Exception ex)
            //    {
            //        throw;
            //    }
            //}
        }

    }
}
