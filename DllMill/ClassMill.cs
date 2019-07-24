using DBLZGX2L2.Enties;
using DBLZGX2L2.Enties.DbModels;
using DllBase;
using DllClient;
using DllOpc;
using EasySocket.vs13.Core;
using EasySocket.vs13.Telegram.Easy;
using Log4Ex;
using Models;
using SqlSugar;
using Sugar.Enties;
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
            string shift = "";
            string employee = "";
            DateTime enMill1Time = DateTime.Now;

            using (var db = SugarDao.Instance)
            {
                try
                {
                    db.Ado.BeginTran();

                    LogHelper.Info("**********************************************Begin***********************************************");
                    //取已出炉的第一支坯料
                    var matNoReadyMill = db.Queryable<BLT_PROC>().Where(p => p.BLT_FLG == "11").OrderBy(it => it.RF_OUT_DT, OrderByType.Asc).First();
                    if (matNoReadyMill == null)
                    {
                        throw new Exception("出炉辊道材料不存在");
                    }
                    //取当班主轧操作员信息
                    var curShift = db.Queryable<CURSHIFT>().Where(it => it.ROLE == "主轧操作员").First();
                    shift = curShift.SHIFT_DATE + curShift.SHIFT_GROUP;
                    employee = curShift.USER_CODE;
                    LogHelper.Info($"待轧制材料号:{matNoReadyMill.BLT_NO} , 班组班别:{shift}");

                    //更新主档信息数据   
                    matNoReadyMill.WR_RL_SAT_DT = enMill1Time;
                    matNoReadyMill.COAROLL_START_TIME = enMill1Time;
                    matNoReadyMill.BLT_FLG = "12";
                    matNoReadyMill.INFO_FLAG = "1";
                    matNoReadyMill.EN_MILL_TP = "A";
                    matNoReadyMill.ACC_END_TIME = enMill1Time.ToString("yyyyMMddHHmmss");
                    matNoReadyMill.WR_RL_OP_SFT = shift;
                    matNoReadyMill.EMPLOYEE_MILL = "AAAA";

                    LogHelper.Info($"更新材料主档信息,材料号:{matNoReadyMill.BLT_NO}");
                    db.Updateable<BLT_PROC>(matNoReadyMill).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommand();


                    //粗轧温度
                    var CZ_TEMP = opc.OpLinkTagValue("CZ_TEMP");

                    //更新轧制过程数据
                    var updateData2 = new BLT_PROC_DATA()
                    {
                        BLT_NO = matNoReadyMill.BLT_NO,
                        LOT_NO = matNoReadyMill.LOT_NO,
                        UPD_DATE = enMill1Time,
                        WR_RM_ESD_MAT_TM =CZ_TEMP.ToInt16()
                    };
                    LogHelper.Info($"更新材料过程数据,内容:{updateData2.ToLog()}");
                    db.Updateable<BLT_PROC_DATA>(updateData2).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommand();                    

                    //事务提交
                    db.Ado.CommitTran();
                    LogHelper.Info("**********************************************End***********************************************");
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
         
            //var value = opc.OpLinkTagValue("CZ_TEMP");
            //opc.MillChanged("轧线辊道上发生动作");

            //using (var db = SugarDao.Instance)
            //{
            //    try
            //    {
            //        //支持output
            //        var retvalP1 = new SugarParameter("@retval", null, true);//isOutput=true
            //        db.Ado.UseStoredProcedure().GetInt("sgis_track.enter_mill", retvalP1);

            //        var retvalP2 = new SugarParameter("@retval", null, true);//isOutput=true
            //        //停机管理用
            //        db.Ado.UseStoredProcedure().GetInt("sgis_track.enter_mill_1", retvalP1);



            //    }
            //    catch (Exception ex)
            //    {
            //        throw;
            //    }
            //}
        }

        [Api]
        [EasyLogFilter("轧线-粗轧结束，6号轧机抛钢")]
        public static void Mill6ActionPaoGang(this IOpc opc)
        {
            string shift = "";
            string employee = "";
            DateTime outMill6Time = DateTime.Now;

            using (var db = SugarDao.Instance)
            {
                try
                {
                    db.Ado.BeginTran();

                    LogHelper.Info("**********************************************Begin***********************************************");
                    //取已进入粗轧的第一支坯料，条件改为未中轧结束的第一支坯,且粗轧结束时间>粗轧开始时间
                    var matNoReadyMill = db.Queryable<BLT_PROC>()
                        .Where(p =>
                        p.BLT_FLG == "12"
                        && p.MIDROLL_END_TIME == null
                        && p.COAROLL_END_TIME == null
                        && outMill6Time > p.COAROLL_START_TIME)
                        .OrderBy(it => it.WR_RL_SAT_DT, OrderByType.Asc).First();
                    if (matNoReadyMill == null)
                    {
                        throw new Exception("粗轧辊道材料不存在");
                    }
                    //取当班主轧操作员信息
                    var curShift = db.Queryable<CURSHIFT>().Where(it => it.ROLE == "主轧操作员").First();
                    shift = curShift.SHIFT_DATE + curShift.SHIFT_GROUP;
                    employee = curShift.USER_CODE;
                    LogHelper.Info($"待轧制材料号:{matNoReadyMill.BLT_NO} , 班组班别:{shift}");

                    //更新主档信息数据   
                    matNoReadyMill.COAROLL_END_TIME = outMill6Time;

                    LogHelper.Info($"更新材料主档信息,材料号:{matNoReadyMill.BLT_NO}");
                    db.Updateable<BLT_PROC>(matNoReadyMill).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommand();

                    //事务提交
                    db.Ado.CommitTran();
                    LogHelper.Info("**********************************************End***********************************************");
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
        }

        [Api]
        [EasyLogFilter("轧线-中轧开始，7号轧机咬钢")]
        public static void Mill7ActionYaoGang(this IOpc opc)
        {
            string shift = "";
            string employee = "";
            DateTime enMill7Time = DateTime.Now;

            using (var db = SugarDao.Instance)
            {
                try
                {
                    db.Ado.BeginTran();

                    LogHelper.Info("**********************************************Begin***********************************************");
                    //取已过粗轧的第一支坯料
                    var matNoReadyMill = db.Queryable<BLT_PROC>().Where(p => p.BLT_FLG == "12"&& p.INFO_FLAG =="1").OrderBy(it => it.WR_RL_SAT_DT, OrderByType.Asc).First();
                    if (matNoReadyMill == null)
                    {
                        throw new Exception("粗轧辊道材料不存在");
                    }
                    //取当班主轧操作员信息
                    var curShift = db.Queryable<CURSHIFT>().Where(it => it.ROLE == "主轧操作员").First();
                    shift = curShift.SHIFT_DATE + curShift.SHIFT_GROUP;
                    employee = curShift.USER_CODE;
                    LogHelper.Info($"待轧制材料号:{matNoReadyMill.BLT_NO} , 班组班别:{shift}");

                    //更新主档信息数据   
                    matNoReadyMill.MIDROLL_START_TIME = enMill7Time;
                    matNoReadyMill.BLT_FLG = "12";
                    matNoReadyMill.INFO_FLAG = "2";                ;

                    LogHelper.Info($"更新材料主档信息,材料号:{matNoReadyMill.BLT_NO}");
                    db.Updateable<BLT_PROC>(matNoReadyMill).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommand();

                    //中轧温度缺失                   

                    //事务提交
                    db.Ado.CommitTran();
                    LogHelper.Info("**********************************************End***********************************************");
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
        }

        [Api]
        [EasyLogFilter("轧线-中轧结束，12号轧机抛钢")]
        public static void Mill12ActionPaoGang(this IOpc opc)
        {
            string shift = "";
            string employee = "";
            DateTime outMill12Time = DateTime.Now;

            using (var db = SugarDao.Instance)
            {
                try
                {
                    db.Ado.BeginTran();

                    LogHelper.Info("**********************************************Begin***********************************************");
                    //取已过粗轧的第一支坯料,由于中轧轧抛钢信号可能晚于预精轧咬钢信号，条件改为未预精轧结束的第一支坯
                    var matNoReadyMill = db.Queryable<BLT_PROC>().Where(p => 
                    p.BLT_FLG == "12" 
                    && p.MIDFINROLL_END_TIME == null
                    && p.MIDROLL_END_TIME == null
                    && outMill12Time>p.MIDROLL_START_TIME)
                    .OrderBy(it => it.WR_RL_SAT_DT, OrderByType.Asc).First();
                    if (matNoReadyMill == null)
                    {
                        throw new Exception("中轧辊道材料不存在");
                    }
                    //取当班主轧操作员信息
                    var curShift = db.Queryable<CURSHIFT>().Where(it => it.ROLE == "主轧操作员").First();
                    shift = curShift.SHIFT_DATE + curShift.SHIFT_GROUP;
                    employee = curShift.USER_CODE;
                    LogHelper.Info($"待轧制材料号:{matNoReadyMill.BLT_NO} , 班组班别:{shift}");

                    //更新主档信息数据   
                    matNoReadyMill.MIDROLL_END_TIME = outMill12Time;

                    LogHelper.Info($"更新材料主档信息,材料号:{matNoReadyMill.BLT_NO}");
                    db.Updateable<BLT_PROC>(matNoReadyMill).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommand();

                    //中轧温度缺失                   

                    //事务提交
                    db.Ado.CommitTran();
                    LogHelper.Info("**********************************************End***********************************************");
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
        }

        [Api]
        [EasyLogFilter("轧线-预精轧开始，13号轧机咬钢")]
        public static void Mill13ActionYaoGang(this IOpc opc)
        {
            string shift = "";
            string employee = "";
            DateTime enMill13Time = DateTime.Now;

            using (var db = SugarDao.Instance)
            {
                try
                {
                    db.Ado.BeginTran();

                    LogHelper.Info("**********************************************Begin***********************************************");
                    //取已过中轧的第一支坯料
                    var matNoReadyMill = db.Queryable<BLT_PROC>().Where(p => p.BLT_FLG == "12" && p.INFO_FLAG == "2").OrderBy(it => it.WR_RL_SAT_DT, OrderByType.Asc).First();
                    if (matNoReadyMill == null)
                    {
                        throw new Exception("中轧辊道材料不存在");
                    }
                    //取当班主轧操作员信息
                    var curShift = db.Queryable<CURSHIFT>().Where(it => it.ROLE == "主轧操作员").First();
                    shift = curShift.SHIFT_DATE + curShift.SHIFT_GROUP;
                    employee = curShift.USER_CODE;
                    LogHelper.Info($"待轧制材料号:{matNoReadyMill.BLT_NO} , 班组班别:{shift}");

                    //更新主档信息数据   
                    matNoReadyMill.MIDFINROLL_START_TIME = enMill13Time;
                    matNoReadyMill.INFO_FLAG = "3"; 

                    LogHelper.Info($"更新材料主档信息,材料号:{matNoReadyMill.BLT_NO}");
                    db.Updateable<BLT_PROC>(matNoReadyMill).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommand();

                    //预精轧温度
                    var YJZ_TEMP = opc.OpLinkTagValue("YJZ_TEMP");

                    //更新轧制过程数据
                    var updateData2 = new BLT_PROC_DATA()
                    {
                        BLT_NO = matNoReadyMill.BLT_NO,
                        LOT_NO = matNoReadyMill.LOT_NO,
                        UPD_DATE = enMill13Time,
                        WR_MID_FIN_RL_ESD_MAT_TM = YJZ_TEMP.ToInt16()
                    };
                    LogHelper.Info($"更新材料过程数据,内容:{updateData2.ToLog()}");
                    db.Updateable<BLT_PROC_DATA>(updateData2).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommand();

                    //事务提交
                    db.Ado.CommitTran();
                    LogHelper.Info("**********************************************End***********************************************");
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
        }

        [Api]
        [EasyLogFilter("轧线-预精轧结束，18号轧机抛钢")]
        public static void Mill18ActionPaoGang(this IOpc opc)
        {
            string shift = "";
            string employee = "";
            DateTime outMill18Time = DateTime.Now;

            using (var db = SugarDao.Instance)
            {
                try
                {
                    db.Ado.BeginTran();

                    LogHelper.Info("**********************************************Begin***********************************************");
                    //取已过预精轧的第一支坯料，由于预精轧抛钢信号可能晚于精轧咬钢信号\吐丝机咬钢信号，条件改为未精轧结束的第一支坯
                    var matNoReadyMill = db.Queryable<BLT_PROC>().Where(p => 
                    p.BLT_FLG == "12" 
                    && p.FINROLL_END_TIME == null
                    && p.MIDFINROLL_END_TIME == null
                    && outMill18Time>p.MIDFINROLL_START_TIME).OrderBy(it => it.WR_RL_SAT_DT, OrderByType.Asc).First();
                    if (matNoReadyMill == null)
                    {
                        throw new Exception("预精轧辊道材料不存在");
                    }
                    //取当班主轧操作员信息
                    var curShift = db.Queryable<CURSHIFT>().Where(it => it.ROLE == "主轧操作员").First();
                    shift = curShift.SHIFT_DATE + curShift.SHIFT_GROUP;
                    employee = curShift.USER_CODE;
                    LogHelper.Info($"待轧制材料号:{matNoReadyMill.BLT_NO} , 班组班别:{shift}");

                    //更新主档信息数据   
                    matNoReadyMill.MIDFINROLL_END_TIME = outMill18Time;


                    LogHelper.Info($"更新材料主档信息,材料号:{matNoReadyMill.BLT_NO}");
                    db.Updateable<BLT_PROC>(matNoReadyMill).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommand();

                    //事务提交
                    db.Ado.CommitTran();
                    LogHelper.Info("**********************************************End***********************************************");
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
        }

        [EasyLogFilter("轧线-精轧开始，精轧机咬钢")]
        public static void JZActionYaoGang(this IOpc opc)
        {
            string shift = "";
            string employee = "";
            DateTime enMillJzTime = DateTime.Now;

            using (var db = SugarDao.Instance)
            {
                try
                {
                    db.Ado.BeginTran();

                    LogHelper.Info("**********************************************Begin***********************************************");
                    //取已过预精轧的第一支坯料
                    var matNoReadyMill = db.Queryable<BLT_PROC>().Where(p => p.BLT_FLG == "12" && p.INFO_FLAG == "3").OrderBy(it => it.WR_RL_SAT_DT, OrderByType.Asc).First();
                    if (matNoReadyMill == null)
                    {
                        throw new Exception("预精轧辊道材料不存在");
                    }
                    //取当班主轧操作员信息
                    var curShift = db.Queryable<CURSHIFT>().Where(it => it.ROLE == "主轧操作员").First();
                    shift = curShift.SHIFT_DATE + curShift.SHIFT_GROUP;
                    employee = curShift.USER_CODE;
                    LogHelper.Info($"待轧制材料号:{matNoReadyMill.BLT_NO} , 班组班别:{shift}");

                    //更新主档信息数据   
                    matNoReadyMill.FINROLL_START_TIME = enMillJzTime;
                    matNoReadyMill.INFO_FLAG = "4";

                    LogHelper.Info($"更新材料主档信息,材料号:{matNoReadyMill.BLT_NO}");
                    db.Updateable<BLT_PROC>(matNoReadyMill).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommand();

                    //精轧入口温度
                    var JZ_RK_TEMP = opc.OpLinkTagValue("YJZ_TEMP");

                    //更新轧制过程数据
                    var updateData2 = new BLT_PROC_DATA()
                    {
                        BLT_NO = matNoReadyMill.BLT_NO,
                        LOT_NO = matNoReadyMill.LOT_NO,
                        UPD_DATE = enMillJzTime,
                        FINROLL_IN_TMEP= JZ_RK_TEMP.ToInt32()
                    };
                    LogHelper.Info($"更新材料过程数据,内容:{updateData2.ToLog()}");
                    db.Updateable<BLT_PROC_DATA>(updateData2).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommand();

                    //事务提交
                    db.Ado.CommitTran();
                    LogHelper.Info("**********************************************End***********************************************");
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
        }
        [EasyLogFilter("轧线-精轧结束，精轧机抛钢")]
        public static void JZActionPaoGang(this IOpc opc)
        {
            string shift = "";
            string employee = "";
            DateTime outMillJzTime = DateTime.Now;

            using (var db = SugarDao.Instance)
            {
                try
                {
                    db.Ado.BeginTran();

                    LogHelper.Info("**********************************************Begin***********************************************");
                    //取已进入精轧的第一支坯料,由于精轧抛钢信号可能晚于吐丝机咬钢信号，，条件改为未吐丝结束的第一支坯
                    var matNoReadyMill = db.Queryable<BLT_PROC>().Where(p => 
                    p.BLT_FLG == "12" 
                    && p.TUSHI_END_TIME ==null
                    && p.FINROLL_END_TIME == null
                    && outMillJzTime>p.FINROLL_START_TIME)
                    .OrderBy(it => it.WR_RL_SAT_DT, OrderByType.Asc).First();//精轧开始时间为空
                    if (matNoReadyMill == null)
                    {
                        throw new Exception("精轧辊道材料不存在");
                    }
                    //取当班主轧操作员信息
                    var curShift = db.Queryable<CURSHIFT>().Where(it => it.ROLE == "主轧操作员").First();
                    shift = curShift.SHIFT_DATE + curShift.SHIFT_GROUP;
                    employee = curShift.USER_CODE;
                    LogHelper.Info($"待轧制材料号:{matNoReadyMill.BLT_NO} , 班组班别:{shift}");

                    //更新主档信息数据   
                    matNoReadyMill.FINROLL_END_TIME = outMillJzTime;

                    LogHelper.Info($"更新材料主档信息,材料号:{matNoReadyMill.BLT_NO}");
                    db.Updateable<BLT_PROC>(matNoReadyMill).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommand();

                    //精轧出口温度
                    var JZ_CK_TEMP = opc.OpLinkTagValue("JZ_CK_TEMP");

                    //更新轧制过程数据
                    var updateData2 = new BLT_PROC_DATA()
                    {
                        BLT_NO = matNoReadyMill.BLT_NO,
                        LOT_NO = matNoReadyMill.LOT_NO,
                        UPD_DATE = outMillJzTime,
                        FINROLL_OUT_TEMP = JZ_CK_TEMP.ToInt32()
                    };
                    LogHelper.Info($"更新材料过程数据,内容:{updateData2.ToLog()}");
                    db.Updateable<BLT_PROC_DATA>(updateData2).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommand();

                    //事务提交
                    db.Ado.CommitTran();
                    LogHelper.Info("**********************************************End***********************************************");
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
        }
        [Api]
        [EasyLogFilter("轧线-吐丝开始，吐丝机咬钢")]
        public static void TSActionYaoGang(this IOpc opc)
        {
            string shift = "";
            string employee = "";
            DateTime enMillTsTime = DateTime.Now;

            using (var db = SugarDao.Instance)
            {
                try
                {
                    db.Ado.BeginTran();

                    LogHelper.Info("**********************************************Begin***********************************************");
                    //取已进入精轧的第一支坯料
                    var matNoReadyMill = db.Queryable<BLT_PROC>().Where(p => p.BLT_FLG == "12" && p.INFO_FLAG == "4").OrderBy(it => it.WR_RL_SAT_DT, OrderByType.Asc).First();
                    if (matNoReadyMill == null)
                    {
                        throw new Exception("精轧辊道材料不存在");
                    }
                    //取当班主轧操作员信息
                    var curShift = db.Queryable<CURSHIFT>().Where(it => it.ROLE == "主轧操作员").First();
                    shift = curShift.SHIFT_DATE + curShift.SHIFT_GROUP;
                    employee = curShift.USER_CODE;
                    LogHelper.Info($"待轧制材料号:{matNoReadyMill.BLT_NO} , 班组班别:{shift}");

                    //更新主档信息数据   
                    matNoReadyMill.TUSHI_START_TIME= enMillTsTime;
                    matNoReadyMill.BLT_FLG = "12";
                    matNoReadyMill.INFO_FLAG = "5";

                    LogHelper.Info($"更新材料主档信息,材料号:{matNoReadyMill.BLT_NO}");
                    db.Updateable<BLT_PROC>(matNoReadyMill).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommand();

                    //吐丝机温度
                    var TSJ_TEMP = opc.OpLinkTagValue("TSJ_TEMP");

                    //更新轧制过程数据
                    var updateData2 = new BLT_PROC_DATA()
                    {
                        BLT_NO = matNoReadyMill.BLT_NO,
                        LOT_NO = matNoReadyMill.LOT_NO,
                        UPD_DATE = enMillTsTime,
                        TUSI_TEMP = TSJ_TEMP.ToInt32()
                    };
                    LogHelper.Info($"更新材料过程数据,内容:{updateData2.ToLog()}");
                    db.Updateable<BLT_PROC_DATA>(updateData2).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommand();

                    //事务提交
                    db.Ado.CommitTran();
                    LogHelper.Info("**********************************************End***********************************************");
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
        }

        [Api]
        [EasyLogFilter("轧线-轧制结束，吐丝机抛钢")]
        public static void TSActionPaoGang(this IOpc opc)
        {
            string shift = "";
            string employee = "";
            DateTime outMillTsTime = DateTime.Now;

            using (var db = SugarDao.Instance)
            {
                try
                {
                    db.Ado.BeginTran();

                    LogHelper.Info("**********************************************Begin***********************************************");
                    //取已进入轧机的第一支坯料
                    var matNoReadyMill = db.Queryable<BLT_PROC>().Where(p =>
                    p.BLT_FLG == "12"
                    //&& p.INFO_FLAG == "5"
                    //&& p.TUSHI_END_TIME ==null
                    //&& outMillTsTime > p.TUSHI_START_TIME
                    )
                    .OrderBy(it => it.WR_RL_SAT_DT, OrderByType.Asc).First();

                    if (matNoReadyMill == null)
                    {
                        throw new Exception("轧机辊道材料不存在");
                    }
                    //取当班主轧操作员信息
                    var curShift = db.Queryable<CURSHIFT>().Where(it => it.ROLE == "主轧操作员").First();
                    shift = curShift.SHIFT_DATE + curShift.SHIFT_GROUP;
                    employee = curShift.USER_CODE;
                    LogHelper.Info($"待轧制材料号:{matNoReadyMill.BLT_NO} , 班组班别:{shift}");

                    //更新主档信息数据  
                    matNoReadyMill.BLT_FLG = "13";
                    matNoReadyMill.TUSHI_END_TIME = outMillTsTime;                    
                    matNoReadyMill.WR_RL_DN_DT = outMillTsTime;
                    matNoReadyMill.WR_RL_OP_SFT = shift;
                    matNoReadyMill.EMPLOYEE_MILL = "AAAA";

                    LogHelper.Info($"更新材料主档信息,材料号:{matNoReadyMill.BLT_NO}");
                    db.Updateable<BLT_PROC>(matNoReadyMill).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommand();

                    //过程数据获取
                    var blt_proc_data = db.Queryable<BLT_PROC_DATA>().Where(it=>it.BLT_NO == matNoReadyMill.BLT_NO).First();
                    //if (blt_proc_data==null)
                    //{
                    //    throw new Exception($"材料号:{matNoReadyMill.BLT_NO}-过程数据不存在");
                    //}

                    var insertData3 = new X2H503()
                    {
                        //MSG_ID 在实体中定义特性OracleSequenceName = "X2H503_SEQ"
                        MSG_TIME_STAMP = outMillTsTime.ToString("yyyyMMddHHmmss"),
                        MSG_FLAG = "0",
                        ACTION = "N",
                        BILLET_NO = matNoReadyMill.BLT_NO,
                        FAC_OP_CD = "WD",
                        CREATED_PROGRAM_ID = "L2sgis",
                        CREATION_D = outMillTsTime.ToString("yyyyMMddHHmmss"),
                        WR_RL_OP_SFT = curShift.GetShiftNo() + curShift.GetGroupNo(),
                        EMPLOYEE_N1 = matNoReadyMill.EMPLOYEE_MILL,
                        WR_RL_SAT_DT = ((DateTime)(matNoReadyMill.WR_RL_SAT_DT)).ToString("yyyyMMddHHmmss"),
                        WR_RL_DN_DT = ((DateTime)(matNoReadyMill.WR_RL_DN_DT)).ToString("yyyyMMddHHmmss"),
                        WR_RL_RQR_TM = Convert.ToInt16(((DateTime)(matNoReadyMill.WR_RL_DN_DT)).Subtract(Convert.ToDateTime(matNoReadyMill.WR_RL_SAT_DT)).TotalMinutes),
                        WR_RL_INTERVAL_TM = 0,
                        RL_OP_ABNR_OCR_DT = "",
                        RL_OP_ABNR_CAU_CD = "",
                        WR_COB_OCR_SFT = "",
                        WR_RL_OP_ABNR_OCR_TP_LOC_TP = "",
                        WR_RL_OP_ABNR_OCR_EQP_LOC_TP = "",
                        TEMP_START_ROLL = (blt_proc_data == null ? 0 : blt_proc_data.WR_RM_ESD_MAT_TM),
                        FINROLL_IN_TMEP= (blt_proc_data == null ? 0 : blt_proc_data.FINROLL_IN_TMEP),
                        TUSI_TEMP = (blt_proc_data == null ? 0 : blt_proc_data.TUSI_TEMP)
                    };
                    LogHelper.Info($"新增电文X2H503数据,内容:{insertData3.ToLog()}");
                    db.Insertable<X2H503>(insertData3).ExecuteCommand();

                    //事务提交
                    db.Ado.CommitTran();
                    LogHelper.Info("**********************************************End***********************************************");
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
        }
        /// <summary>
        /// 停机开始-1号轧机抛钢
        /// </summary>
        public static void DownTimeStart(this IOpc opc)
        {
            DateTime beginTime = DateTime.Now;

            using (var db = SugarDao.Instance)
            {
                try
                {
                    db.Ado.BeginTran();
                    LogHelper.Info("停机开始时间计算");                    
                    var downtime = db.Queryable<DOWNTIME>().First();
                    downtime.ACC_START_TIME = beginTime.ToString("yyyyMMddHHmmss");

                    db.Updateable<DOWNTIME>(downtime).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommand();
                    LogHelper.Info($"停机时间ACC_START_TIME={downtime.ACC_START_TIME}, ACC_END_TIME={downtime.ACC_END_TIME}");
                    //事务提交
                    db.Ado.CommitTran();
                    LogHelper.Info("**********************************************End***********************************************");
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
                  
        }
        /// <summary>
        /// 停机结束-1号轧机咬钢
        /// </summary>
        public static void DownTimeStop(this IOpc opc)
        {
            string shift = "";
            string employee = "";
            DateTime dateTime = DateTime.Now;

            using (var db = SugarDao.Instance)
            {
                try
                {
                    db.Ado.BeginTran();
                    LogHelper.Info("停机开始时间计算");
                    //取当班主轧操作员信息
                    var curShift = db.Queryable<CURSHIFT>().Where(it => it.ROLE == "主轧操作员").First();
                    employee = curShift.USER_CODE;
                    LogHelper.Info($"班组班别:{shift}");

                    var downtime = db.Queryable<DOWNTIME>().First();
                    downtime.ACC_END_TIME = dateTime.ToString("yyyyMMddHHmmss");
                    db.Updateable<DOWNTIME>(downtime).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommand();
                    LogHelper.Info($"停机时间ACC_START_TIME={downtime.ACC_START_TIME}, ACC_END_TIME={downtime.ACC_END_TIME}");

                    var insertData = new X2H505()
                    {
                        MSG_TIME_STAMP = dateTime.ToString("yyyyMMddHHmmss"),
                        MSG_FLAG = "0",
                        STAND_NO = "1",
                        ACC_START_TIME = downtime.ACC_START_TIME,
                        ACC_END_TIME = downtime.ACC_END_TIME,
                        SHIFT_NO = curShift.GetShiftNo(),
                        GROUP_NO = curShift.GetGroupNo()
                    };
                    LogHelper.Info($"新增电文X2H505数据,内容:{insertData.ToLog()}");
                    db.Insertable<X2H505>(insertData).ExecuteCommand();
                    //事务提交
                    db.Ado.CommitTran();
                    LogHelper.Info("**********************************************End***********************************************");
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

        }

        [EasyLogFilter("轧线动作")]
        public static void MillAction(this IOpc opc)
        {          
            DateTime outMillTsTime = DateTime.Now;

            using (var db = SugarDao.Instance)
            {
                try
                {
                    db.Ado.BeginTran();

                    LogHelper.Info("**********************************************Begin***********************************************");

                    List<string> pars = new List<string>();
                    pars.Add( "H1YAOGANG" );
                    pars.Add( "H2YAOGANG" );
                    pars.Add( "H3YAOGANG" );
                    pars.Add( "H4YAOGANG" );
                    pars.Add( "H5YAOGANG" );
                    pars.Add( "H6YAOGANG" );
                    pars.Add( "H7YAOGANG" );
                    pars.Add( "H8YAOGANG" );
                    pars.Add( "H9YAOGANG" );
                    pars.Add( "H10YAOGANG" );
                    pars.Add( "H11YAOGANG" );
                    pars.Add( "H12YAOGANG" );
                    pars.Add( "H13YAOGANG" );
                    pars.Add( "H14YAOGANG" );
                    pars.Add( "H15YAOGANG" );
                    pars.Add( "H16YAOGANG" );
                    pars.Add( "H17YAOGANG" );
                    pars.Add( "H18YAOGANG" );                    
                    pars.Add( "JZYAOGANG" );
                    pars.Add( "TSYAOGANG" );
                    pars.Add("JIJUAN1");
                    pars.Add("JIJUAN2");
                    pars.Add("JIJUAN3");
                    pars.Add("JIJUAN4");
                    pars.Add("JIJUAN5");
                    pars.Add("JIJUAN6");




                    List<TagSimple> result =  opc.GetTriggersFromOPC(pars);

                    string dfdf = result.Where(p => p.TagName == "H1YAOGANG").FirstOrDefault().ValueCast<bool>() ? "1" : "0";

                    BLT_STATUS updateData = new BLT_STATUS()
                    { ID = 1,
                      MILL1 = result.Where(p => p.TagName == "H1YAOGANG").FirstOrDefault().ValueCast<bool>() ? "1" : "0",
                      MILL2 = result.Where(p => p.TagName == "H2YAOGANG").FirstOrDefault().ValueCast<bool>() ? "1" : "0",
                        MILL3 = result.Where(p => p.TagName == "H3YAOGANG").FirstOrDefault().ValueCast<bool>() ? "1" : "0",
                        MILL4 = result.Where(p => p.TagName == "H4YAOGANG").FirstOrDefault().ValueCast<bool>() ? "1" : "0",
                        MILL5 = result.Where(p => p.TagName == "H5YAOGANG").FirstOrDefault().ValueCast<bool>() ? "1" : "0",
                        MILL6 = result.Where(p => p.TagName == "H6YAOGANG").FirstOrDefault().ValueCast<bool>() ? "1" : "0",
                        MILL7 = result.Where(p => p.TagName == "H7YAOGANG").FirstOrDefault().ValueCast<bool>() ? "1" : "0",
                        MILL8 = result.Where(p => p.TagName == "H8YAOGANG").FirstOrDefault().ValueCast<bool>() ? "1" : "0",
                        MILL9 = result.Where(p => p.TagName == "H9YAOGANG").FirstOrDefault().ValueCast<bool>() ? "1" : "0",
                        MILL10 = result.Where(p => p.TagName == "H10YAOGANG").FirstOrDefault().ValueCast<bool>() ? "1" : "0",
                        MILL11 = result.Where(p => p.TagName == "H11YAOGANG").FirstOrDefault().ValueCast<bool>() ? "1" : "0",
                        MILL12 = result.Where(p => p.TagName == "H12YAOGANG").FirstOrDefault().ValueCast<bool>() ? "1" : "0",
                        MILL13 = result.Where(p => p.TagName == "H13YAOGANG").FirstOrDefault().ValueCast<bool>() ? "1" : "0",
                        MILL14 = result.Where(p => p.TagName == "H14YAOGANG").FirstOrDefault().ValueCast<bool>() ? "1" : "0",
                        MILL15 = result.Where(p => p.TagName == "H15YAOGANG").FirstOrDefault().ValueCast<bool>() ? "1" : "0",
                        MILL16 = result.Where(p => p.TagName == "H16YAOGANG").FirstOrDefault().ValueCast<bool>() ? "1" : "0",
                        MILL17 = result.Where(p => p.TagName == "H17YAOGANG").FirstOrDefault().ValueCast<bool>() ? "1" : "0",
                        MILL18 = result.Where(p => p.TagName == "H18YAOGANG").FirstOrDefault().ValueCast<bool>() ? "1" : "0",
                        MILL19 = result.Where(p => p.TagName == "JZYAOGANG").FirstOrDefault().ValueCast<bool>() ? "1" : "0",
                        TUSHI = result.Where(p => p.TagName == "TSYAOGANG").FirstOrDefault().ValueCast<bool>() ? "1" : "0",
                        COIL1 = result.Where(p => p.TagName == "JIJUAN1").FirstOrDefault().ValueCast<bool>() ? "1" : "0",
                        COIL2 = result.Where(p => p.TagName == "JIJUAN2").FirstOrDefault().ValueCast<bool>() ? "1" : "0",
                        COIL3 = result.Where(p => p.TagName == "JIJUAN3").FirstOrDefault().ValueCast<bool>() ? "1" : "0",
                        COIL4 = result.Where(p => p.TagName == "JIJUAN4").FirstOrDefault().ValueCast<bool>() ? "1" : "0",
                        COIL5 = result.Where(p => p.TagName == "JIJUAN5").FirstOrDefault().ValueCast<bool>() ? "1" : "0",
                        COIL6 = result.Where(p => p.TagName == "JIJUAN6").FirstOrDefault().ValueCast<bool>() ? "1" : "0"
                    };

                    LogHelper.Info($"更新轧线跟踪信号");
                    db.Updateable<BLT_STATUS>(updateData).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommand();                 

                    //事务提交
                    db.Ado.CommitTran();
                    LogHelper.Info("**********************************************End***********************************************");
                }
                catch (Exception e)
                {
                    //事务回滚
                    db.Ado.RollbackTran();
                    LogHelper.Error(e.Message);
                    LogHelper.Error("**********************************************End With Error***********************************************");
                }
            }

        }

        [EasyLogFilter("上钩动作")]
        public static void HookAction(this IOpc opc,int hookNo)
        {
            DateTime outMillTsTime = DateTime.Now;

            using (var db = SugarDao.Instance)
            {
                try
                {
                    db.Ado.BeginTran();

                    LogHelper.Info("**********************************************Begin***********************************************"); 

                    BLT_STATUS updateData = new BLT_STATUS()
                    {
                        ID = 1,
                        HOOK_NO =Convert.ToInt16(hookNo)
                    };

                    LogHelper.Info($"更新轧线跟踪信号");
                    db.Updateable<BLT_STATUS>(updateData).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommand();

                    //事务提交
                    db.Ado.CommitTran();
                    LogHelper.Info("**********************************************End***********************************************");
                }
                catch (Exception e)
                {
                    //事务回滚
                    db.Ado.RollbackTran();
                    LogHelper.Error(e.Message);
                    LogHelper.Error("**********************************************End With Error***********************************************");
                }
            }

        }
    }
}
