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

namespace DllMill
{
    /// <summary>
    /// 轧线操作
    /// </summary>
    public static class ClassMill
    {
        [Api]
        [EasyLogFilter("轧线-粗轧开始，1号轧机咬钢")]
        public static void Mill1ActionYaoGang(this IOpc opc)
        { 
            var value = opc.OpLinkTagValue("Ramp101");
            opc.MillChanged("轧线辊道上发生动作");

            using (var db = SugarDao.Instance)
            {
                try
                {
                    //支持output
                    var retvalP1 = new SugarParameter("@retval", null, true);//isOutput=true
                    db.Ado.UseStoredProcedure().GetInt("sgis_track.enter_mill", retvalP1);

                    var retvalP2 = new SugarParameter("@retval", null, true);//isOutput=true
                    //停机管理用
                    db.Ado.UseStoredProcedure().GetInt("sgis_track.enter_mill_1", retvalP1);


                    //DBOleDb.ExecutePorcedure("sgis_track.update_millspd", new OleDbParameter[] { op2, op3, op4, op5, op1 }); //更新粗轧入口速度
                    //DBOleDb.ExecutePorcedure("sgis_track.update_milltm", new OleDbParameter[] { op2, op3, op6, op7, op1 });//更新粗轧入口温度 
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        [Api]
        [EasyLogFilter("轧线-1号轧机抛钢")]
        public static void Mill1ActionPaoGang(this IOpc opc)
        {
            var value = opc.OpLinkTagValue("Ramp101");
            opc.MillChanged("轧线辊道上发生动作");

            using (var db = SugarDao.Instance)
            {
                try
                {
                    //支持output
                    var retvalP1 = new SugarParameter("@retval", null, true);//isOutput=true
                    db.Ado.UseStoredProcedure().GetInt("sgis_track.enter_mill", retvalP1);

                    var retvalP2 = new SugarParameter("@retval", null, true);//isOutput=true
                    //停机管理用
                    db.Ado.UseStoredProcedure().GetInt("sgis_track.enter_mill_1", retvalP1);


                    //DBOleDb.ExecutePorcedure("sgis_track.update_millspd", new OleDbParameter[] { op2, op3, op4, op5, op1 }); //更新粗轧入口速度
                    //DBOleDb.ExecutePorcedure("sgis_track.update_milltm", new OleDbParameter[] { op2, op3, op6, op7, op1 });//更新粗轧入口温度 
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        [Api]
        [EasyLogFilter("轧线-粗轧结束，6号轧机抛钢")]
        public static void Mill6ActionPaoGang(this IOpc opc)
        {
            // 通知其它fast会话加热炉发生变化
            //foreach (var session in this.OtherSessions)
            //{
            //    session.InvokeApi("LoginNotify", 1, user.Account);
            //}
            LogHelper.Info("轧线-轧制开始，1号轧机咬钢");
            var value = opc.OpLinkTagValue("Ramp101");
            opc.MillChanged("轧线辊道上发生动作");
            

            using (var db = SugarDao.Instance)
            {
                try
                {
                    //支持output
                    var retvalP1 = new SugarParameter("@retval", null, true);//isOutput=true
                    db.Ado.UseStoredProcedure().GetInt("sgis_track.enter_mill", retvalP1);

                    var retvalP2 = new SugarParameter("@retval", null, true);//isOutput=true
                    //停机管理用
                    db.Ado.UseStoredProcedure().GetInt("sgis_track.enter_mill_1", retvalP1);


                    //DBOleDb.ExecutePorcedure("sgis_track.update_millspd", new OleDbParameter[] { op2, op3, op4, op5, op1 }); //更新粗轧入口速度
                    //DBOleDb.ExecutePorcedure("sgis_track.update_milltm", new OleDbParameter[] { op2, op3, op6, op7, op1 });//更新粗轧入口温度 
                }
                catch (Exception ex)
                {  
                    throw;
                }
            }
        }
        [Api]
        [EasyLogFilter("轧线-中轧开始，7号轧机咬钢")]
        public static void Mill7ActionYaoGang(this IOpc opc)
        {
            // 通知其它fast会话加热炉发生变化
            //foreach (var session in this.OtherSessions)
            //{
            //    session.InvokeApi("LoginNotify", 1, user.Account);
            //}
            LogHelper.Info("轧线-轧制开始，1号轧机咬钢");
            var value = opc.OpLinkTagValue("Ramp101");
            opc.MillChanged("轧线辊道上发生动作");


            using (var db = SugarDao.Instance)
            {
                try
                {
                    //支持output
                    var retvalP1 = new SugarParameter("@retval", null, true);//isOutput=true
                    db.Ado.UseStoredProcedure().GetInt("sgis_track.enter_mill", retvalP1);

                    var retvalP2 = new SugarParameter("@retval", null, true);//isOutput=true
                    //停机管理用
                    db.Ado.UseStoredProcedure().GetInt("sgis_track.enter_mill_1", retvalP1);


                    //DBOleDb.ExecutePorcedure("sgis_track.update_millspd", new OleDbParameter[] { op2, op3, op4, op5, op1 }); //更新粗轧入口速度
                    //DBOleDb.ExecutePorcedure("sgis_track.update_milltm", new OleDbParameter[] { op2, op3, op6, op7, op1 });//更新粗轧入口温度 
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
        [Api]
        [EasyLogFilter("轧线-中轧结束，12号轧机抛钢")]
        public static void Mill12ActionPaoGang(this IOpc opc)
        {
            // 通知其它fast会话加热炉发生变化
            //foreach (var session in this.OtherSessions)
            //{
            //    session.InvokeApi("LoginNotify", 1, user.Account);
            //}
            LogHelper.Info("轧线-轧制开始，1号轧机咬钢");
            var value = opc.OpLinkTagValue("Ramp101");
            opc.MillChanged("轧线辊道上发生动作");


            using (var db = SugarDao.Instance)
            {
                try
                {
                    //支持output
                    var retvalP1 = new SugarParameter("@retval", null, true);//isOutput=true
                    db.Ado.UseStoredProcedure().GetInt("sgis_track.enter_mill", retvalP1);

                    var retvalP2 = new SugarParameter("@retval", null, true);//isOutput=true
                    //停机管理用
                    db.Ado.UseStoredProcedure().GetInt("sgis_track.enter_mill_1", retvalP1);


                    //DBOleDb.ExecutePorcedure("sgis_track.update_millspd", new OleDbParameter[] { op2, op3, op4, op5, op1 }); //更新粗轧入口速度
                    //DBOleDb.ExecutePorcedure("sgis_track.update_milltm", new OleDbParameter[] { op2, op3, op6, op7, op1 });//更新粗轧入口温度 
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
        [Api]
        [EasyLogFilter("轧线-预精轧开始，13号轧机咬钢")]
        public static void Mill13ActionYaoGang(this IOpc opc)
        {
            // 通知其它fast会话加热炉发生变化
            //foreach (var session in this.OtherSessions)
            //{
            //    session.InvokeApi("LoginNotify", 1, user.Account);
            //}
            LogHelper.Info("轧线-轧制结束，13号轧机抛钢");
            var value = opc.OpLinkTagValue("Ramp101");
            opc.MillChanged("轧线辊道上发生动作");


            using (var db = SugarDao.Instance)
            {
                try
                {
                    //支持output
                    var retvalP = new SugarParameter("@retval", null, true);//isOutput=true
                    db.Ado.UseStoredProcedure().GetInt("sgis_track.exit_mill", retvalP);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
        [Api]
        [EasyLogFilter("轧线-预精轧结束，18号轧机抛钢")]
        public static void Mill18ActionPaoGang(this IOpc opc)
        {
            // 通知其它fast会话加热炉发生变化
            //foreach (var session in this.OtherSessions)
            //{
            //    session.InvokeApi("LoginNotify", 1, user.Account);
            //}
            LogHelper.Info("轧线-轧制结束，18号轧机抛钢");
            var value = opc.OpLinkTagValue("Ramp101");
            opc.MillChanged("轧线辊道上发生动作");


            using (var db = SugarDao.Instance)
            {
                try
                {
                    //支持output
                    var retvalP = new SugarParameter("@retval", null, true);//isOutput=true
                    db.Ado.UseStoredProcedure().GetInt("sgis_track.exit_mill", retvalP);
                  }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
        [EasyLogFilter("轧线-精轧开始，精轧机咬钢")]
        public static void JZActionYaoGang(this IOpc opc)
        {
            // 通知其它fast会话加热炉发生变化
            //foreach (var session in this.OtherSessions)
            //{
            //    session.InvokeApi("LoginNotify", 1, user.Account);
            //}
            LogHelper.Info("轧线-轧制结束，18号轧机抛钢");
            var value = opc.OpLinkTagValue("Ramp101");
            opc.MillChanged("轧线辊道上发生动作");


            using (var db = SugarDao.Instance)
            {
                try
                {
                    //支持output
                    var retvalP = new SugarParameter("@retval", null, true);//isOutput=true
                    db.Ado.UseStoredProcedure().GetInt("sgis_track.exit_mill", retvalP);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
        [EasyLogFilter("轧线-精轧结束，精轧机抛钢")]
        public static void JZActionPaoGang(this IOpc opc)
        {
            // 通知其它fast会话加热炉发生变化
            //foreach (var session in this.OtherSessions)
            //{
            //    session.InvokeApi("LoginNotify", 1, user.Account);
            //}
            LogHelper.Info("轧线-轧制结束，18号轧机抛钢");
            var value = opc.OpLinkTagValue("Ramp101");
            opc.MillChanged("轧线辊道上发生动作");


            using (var db = SugarDao.Instance)
            {
                try
                {
                    //支持output
                    var retvalP = new SugarParameter("@retval", null, true);//isOutput=true
                    db.Ado.UseStoredProcedure().GetInt("sgis_track.exit_mill", retvalP);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
        [Api]
        [EasyLogFilter("轧线-轧制结束，吐丝机抛钢")]
        public static void TSActionPaoGang(this IOpc opc)
        {
            // 通知其它fast会话加热炉发生变化
            //foreach (var session in this.OtherSessions)
            //{
            //    session.InvokeApi("LoginNotify", 1, user.Account);
            //}
            LogHelper.Info("轧线-轧制结束，18号轧机抛钢");
            var value = opc.OpLinkTagValue("Ramp101");
            opc.MillChanged("轧线辊道上发生动作");

            using (var db = SugarDao.Instance)
            {
                try
                {
                    //支持output
                    var retvalP = new SugarParameter("@retval", null, true);//isOutput=true
                    db.Ado.UseStoredProcedure().GetInt("sgis_track.exit_mill", retvalP);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
    }
}
