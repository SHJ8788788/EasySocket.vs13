using DBLZGX2L2.Enties;
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
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DllFurn
{
    /// <summary>
    /// 加热炉操作
    /// </summary>
    public static class ClassFurn
    {
        [Api]
        [EasyLogFilter("加热炉-事务写法")]
        public static void demoTest(this IOpc opc)
        {
            //try
            //{
            //    db.Ado.BeginTran();
            //    操作
            //   db.Ado.CommitTran();
            //}
            //catch (Exception ex)
            //{
            //    db.Ado.RollbackTran();
            //    throw ex;
            //}
        }

        [Api]
        [EasyLogFilter("加热炉-入炉")]
        /// <summary>
        /// 加热炉-入炉
        /// </summary>
        /// <param name="opc"></param>
        public static void FurnIn(this IOpc opc)
        {
            string shift = "";
            string employee = "";
            DateTime enFurnTime = DateTime.Now;

            using (var db = SugarDao.Instance)
            {
                try
                {
                    db.Ado.BeginTran();

                    LogHelper.Info("**********************************************Begin***********************************************");
                    //取待入炉的第一支坯料
                    var matNoReadyIn = db.Queryable<PRIDATA>().Where(p => p.FLAG == 0).OrderBy(it => it.SEQ_NO).OrderBy(it => SqlFunc.ToInt32(it.COIL_NO)).First();
                    if (matNoReadyIn == null)
                    {
                        throw new Exception("可入炉计划为空");
                    }
                    //取当班装炉操作员信息
                    var curShift = db.Queryable<CURSHIFT>().Where(it => it.ROLE == "装炉操作员").First();
                    shift = curShift.SHIFT_DATE + curShift.SHIFT_GROUP;
                    employee = curShift.USER_CODE;
                    LogHelper.Info($"待入炉材料号:{matNoReadyIn.BILLET_NO} , 班组班别:{shift}");

                    //新增入炉数据
                    var insertData1 = new BLT_PROC()
                    {
                        BLT_NO = matNoReadyIn.BILLET_NO,
                        LOT_NO = matNoReadyIn.LOT_NO,
                        HEAT_NO = matNoReadyIn.HEAT_NO,
                        SEQ_NO = matNoReadyIn.SEQ_NO,
                        COIL_NO = matNoReadyIn.COIL_NO,
                        BLT_WGT = matNoReadyIn.BLT_WGT,
                        BLT_FLG = "10",
                        RF_EN_DT = enFurnTime,
                        RF_CH_OP_SFT = shift,
                        EMPLOYEE_ENRF = "AAAA"
                    };
                    LogHelper.Info($"新增材料主档信息,材料号:{insertData1.BLT_NO}");
                    db.Insertable<BLT_PROC>(insertData1).ExecuteCommand();

                    LogHelper.Info($"更新计划状态,材料号:{matNoReadyIn.BILLET_NO}");
                    matNoReadyIn.FLAG = 1;
                    db.Updateable<PRIDATA>(matNoReadyIn).ExecuteCommand();

                    /*********************过程数据采集***********************/
                    //入炉温度
                    var JRL_RL_TEMP = opc.OpLinkTagValue("JRL_RL_TEMP");
                    //炉膛炉压
                    var LUTANG_P = opc.OpLinkTagValue("LUTANG_P");
                    //煤气总管压力
                    //煤气总管流量
                    var MQ_ZG_F = opc.OpLinkTagValue("MQ_ZG_F");
                    //煤气热值
                    //换热器前风压
                    //换热器后风压
                    var HRQ_H_AIR_ZG_P = opc.OpLinkTagValue("HRQ_H_AIR_ZG_P");
                    //热风温度
                    //残氧含量
                    //预热段温度
                    var YR_LDZ_T = opc.OpLinkTagValue("YR_LDZ_T");
                    //上加温度-右
                    var S_JIARE_Y_T = opc.OpLinkTagValue("S_JIARE_Y_T");
                    //下加温度-右
                    var X_JIARE_Y_T = opc.OpLinkTagValue("X_JIARE_Y_T");
                    //上均左温度
                    var S_JUNRE_Z_T = opc.OpLinkTagValue("S_JUNRE_Z_T");
                    //下均左温度
                    var X_JUNRE_Z_T = opc.OpLinkTagValue("X_JUNRE_Z_T");
                    //上均中温度
                    var S_JUNRE_D_T = opc.OpLinkTagValue("S_JUNRE_D_T");
                    //下均中温度
                    var X_JUNRE_D_T = opc.OpLinkTagValue("X_JUNRE_D_T");
                    //上均右温度
                    var S_JUNRE_Y_T = opc.OpLinkTagValue("S_JUNRE_Y_T");
                    //下均右温度
                    var X_JUNRE_Y_T = opc.OpLinkTagValue("X_JUNRE_Y_T");

                    //新增入炉过程数据
                    var insertData2 = new BLT_PROC_DATA()
                    {
                        BLT_NO = matNoReadyIn.BILLET_NO,
                        LOT_NO = matNoReadyIn.LOT_NO,
                        UPD_DATE = enFurnTime,
                        IN_FURNACE_TEMP = JRL_RL_TEMP.ToInt32(),
                        FURN_PRESS = LUTANG_P.ToInt32(),
                        GAS_FLUX = MQ_ZG_F.ToInt32(),
                        HUANRE_PRESS_R = HRQ_H_AIR_ZG_P.ToInt32(),
                        PRE_HEAT_TEMP = YR_LDZ_T.ToInt32(),
                        HEAT_TEMP_1 = S_JIARE_Y_T.ToInt32(),
                        HEAT_TEMP_2 = X_JIARE_Y_T.ToInt32(),
                        HEAT_TEMP_3 = S_JUNRE_Z_T.ToInt32(),
                        HEAT_TEMP_4 = X_JUNRE_Z_T.ToInt32(),
                        HEAT_TEMP_5 = S_JUNRE_D_T.ToInt32(),
                        HEAT_TEMP_6 = X_JUNRE_D_T.ToInt32(),
                        HEAT_TEMP_7 = S_JUNRE_Y_T.ToInt32(),
                        HEAT_TEMP_8 = X_JUNRE_Y_T.ToInt32(),
                    };
                    LogHelper.Info($"新增材料过程数据,内容:{insertData2.ToLog()}");
                    db.Insertable<BLT_PROC_DATA>(insertData2).ExecuteCommand();

                    var insertData3 = new X2H501()
                    {
                        //MSG_ID 在实体中定义特性OracleSequenceName = "X2H501_SEQ"
                        MSG_TIME_STAMP = enFurnTime.ToString("yyyyMMddhhmmss"),
                        MSG_FLAG = "0",
                        BILLET_NO = matNoReadyIn.BILLET_NO,
                        FAC_OP_CD = "WB",
                        CREATED_PROGRAM_ID = "L2sgis",
                        CREATION_D = enFurnTime.ToString("yyyyMMddhhmmss"),
                        RF_CH_DT = enFurnTime.ToString("yyyyMMddhhmmss"),
                        RF_CH_OP_SFT = curShift.GetShiftNo() + curShift.GetGroupNo(),
                        EMPLOYEE_N1 = "AAAA",
                        WR_HT_FCE_CH_BT_SEC = Convert.ToInt16(matNoReadyIn.BLT_FAC.Substring(0, 3)),
                        RF_CH_MAT_LEN = matNoReadyIn.BLT_LEN,
                        RF_CH_MAT_RL_WGT = matNoReadyIn.BLT_WGT,
                        RF_CH_MAT_CAL_WGT = matNoReadyIn.BLT_WGT,
                        RF_CH_MAT_TM = Convert.ToInt16(JRL_RL_TEMP),
                        RF_MAT_CH_LEAD_TIME = 0,
                        RF_CHARGE_STATUS = "1",
                        RST_HCR_FLAG = "C"
                    };
                    LogHelper.Info($"新增电文X2H501数据,内容:{insertData3.ToLog()}");
                    db.Insertable<X2H501>(insertData3).ExecuteCommand();

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


            // 通知其它fast会话加热炉发生变化
            GetFurnInfo(opc);
            //opc.FurnChanged("加热炉炉内发生动作");

            //foreach (var session in this.OtherSessions)
            //{
            //    session.InvokeApi("LoginNotify", 1, user.Account);
            //}

            //using (var db = SugarDao.Instance)
            //{
            //    try
            //    {
            //        //支持output
            //        var retvalP = new SugarParameter("@retval", null, true);//isOutput=true
            //        db.Ado.UseStoredProcedure().GetInt("sgis_track.enter_rf", retvalP);
            //    }
            //    catch (Exception ex)
            //    {
            //        throw ex;
            //    }
            //}
        }

        [Api]
        [EasyLogFilter("加热炉-出炉炉")]
        /// <summary>
        /// 加热炉-出炉
        /// </summary>
        /// <param name="opc"></param>
        public static void FurnOut(this IOpc opc)
        {
            string shift = "";
            string employee = "";
            DateTime outFurnTime = DateTime.Now;

            using (var db = SugarDao.Instance)
            {
                try
                {
                    db.Ado.BeginTran();

                    LogHelper.Info("**********************************************Begin***********************************************");
                    //取待出炉的第一支坯料
                    var matNoReadyOut = db.Queryable<BLT_PROC>().Where(p => p.BLT_FLG == "10").OrderBy(it => it.RF_EN_DT).First();
                    if (matNoReadyOut == null)
                    {
                        throw new Exception("可出炉材料不存在");
                    }
                    //取当班装炉操作员信息
                    var curShift = db.Queryable<CURSHIFT>().Where(it => it.ROLE == "出炉操作员").First();
                    shift = curShift.SHIFT_DATE + curShift.SHIFT_GROUP;
                    employee = curShift.USER_CODE;
                    LogHelper.Info($"待出炉材料号:{matNoReadyOut.BLT_NO} , 班组班别:{shift}");

                    //更新主档信息数据
                    matNoReadyOut.RF_OUT_DT = outFurnTime;
                    matNoReadyOut.BLT_FLG = "11";
                    matNoReadyOut.RF_DEV_OP_SFT = shift;
                    matNoReadyOut.EMPLOYEE_OUTRF = "AAAA";

                    LogHelper.Info($"新增材料主档信息,材料号:{matNoReadyOut.BLT_NO}");
                    db.Updateable<BLT_PROC>(matNoReadyOut).ExecuteCommand();

                    /*********************过程数据采集***********************/
                    //出炉炉温度
                    var JRL_CL_TEMP = opc.OpLinkTagValue("JRL_CL_TEMP");


                    //更新出炉过程数据
                    var updateData2 = new BLT_PROC_DATA()
                    {
                        BLT_NO = matNoReadyOut.BLT_NO,
                        LOT_NO = matNoReadyOut.LOT_NO,
                        UPD_DATE = outFurnTime,
                        OUT_FURNACE_TEMP = JRL_CL_TEMP.ToInt32()
                    };
                    LogHelper.Info($"新增材料过程数据,内容:{updateData2.ToLog()}");
                    db.Updateable<BLT_PROC_DATA>(updateData2).ExecuteCommand();

                    var blt_proc_data = db.Queryable<BLT_PROC_DATA>().Where(it => it.BLT_NO == matNoReadyOut.BLT_NO).First();

                    var insertData3 = new X2H502()
                    {
                        //MSG_ID 在实体中定义特性OracleSequenceName = "X2H501_SEQ"
                        MSG_TIME_STAMP = outFurnTime.ToString("yyyyMMddhhmmss"),
                        MSG_FLAG = "0",
                        BILLET_NO = matNoReadyOut.BLT_NO,
                        FAC_OP_CD = "WC",
                        CREATED_PROGRAM_ID = "L2sgis",
                        CREATION_D = outFurnTime.ToString("yyyyMMddhhmmss"),
                        RF_DEV_DT = outFurnTime.ToString("yyyyMMddhhmmss"),
                        RF_DEV_OP_SFT = curShift.GetShiftNo() + curShift.GetGroupNo(),
                        EMPLOYEE_N1 = "AAAA",
                        RF_IN_FCE_TIME = Convert.ToInt16(outFurnTime.Subtract(Convert.ToDateTime(matNoReadyOut.RF_EN_DT)).TotalMinutes),
                        RF_PRHT_IN_FCE_TIME = 0,
                        RF_HT_Z_IN_FCE_TIME = 0,
                        RF_NOR_Z_IN_FCE_TIME = 0,
                        RF_DEV_MAT_TM = Convert.ToInt16(blt_proc_data.OUT_FURNACE_TEMP),
                        RF_HT_Z_MAT_TM = Convert.ToInt16(blt_proc_data.HEAT_TEMP_1),
                        RF_NOR_Z_MAT_TM = Convert.ToInt16(blt_proc_data.HEAT_TEMP_3),
                        RF_PRHT_TM = Convert.ToInt16(blt_proc_data.PRE_HEAT_TEMP),
                        RF_HT_Z_TM = Convert.ToInt16(blt_proc_data.HEAT_TEMP_1),
                        RF_NOR_Z_TM = Convert.ToInt16(blt_proc_data.HEAT_TEMP_3),
                        RF_PRHT_VEFFI = 0,
                        RF_HT_Z_VEFFI = 0,
                        RF_NOR_Z_VEFFI = 0,
                        RF_PRHT_O2_ASIS_V = 0,
                        RF_HT_Z_O2_ASIS_V = 0,
                        RF_NOR_Z_O2_ASIS_V = 0,
                        WR_DESCALER_OP_F1 = "Y",
                        WR_DESCALER_OP_PRS1 = 0,
                        RF_EXIT_STATUS = "1"
                    };
                    LogHelper.Info($"新增电文X2H502数据,内容:{insertData3.ToLog()}");
                    db.Insertable<X2H501>(insertData3).ExecuteCommand();

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

            // 通知其它fast会话加热炉发生变化
            GetFurnInfo(opc);


            // 通知其它fast会话加热炉发生变化
            //foreach (var session in this.OtherSessions)
            //{
            //    session.InvokeApi("LoginNotify", 1, user.Account);
            //}
            //加热炉出炉材料温度
            //var chugang_temp = opc.OpLinkTagValue("JRL_CL_TEMP");
            //LogHelper.Info("加热炉-出炉");

            //using (var db = SugarDao.Instance)
            //{
            //    try
            //    {
            //        //opc.OpLinkTagValue("333");  
            //        //var tran_id = db.Ado.SqlQuerySingle<double>("select Itf_Tran_ID_S.NEXTVAL  from  dual");

            //        //支持output
            //        var retvalP = new SugarParameter("@retval", null, true);//isOutput=true
            //        var outtmP = new SugarParameter("@p_outtm", null, false);//isOutput=false
            //        db.Ado.UseStoredProcedure().GetInt("sgis_track.exit_rf", outtmP, retvalP);
            //    }
            //    catch (Exception ex)
            //    {
            //        throw;
            //    }
            //}
        }

        public static void GetFurnInfo(IOpc opc)
        {
            using (var db = SugarDao.Instance)
            {
                try
                {
                    //多表查询,结果为匿名类
                    var matsInFurn = db.Queryable<BLT_PROC, PRIDATA, BLT_PROC_DATA>
                        ((st, sc, sc2) => sc.BILLET_NO == st.BLT_NO && st.BLT_NO == sc2.BLT_NO)
                        .Where(st => st.BLT_FLG == "10")
                        .OrderBy(st => SqlFunc.ToInt32(st.COIL_NO))
                        .Select((st, sc, sc2) => 
                        new { st.COIL_NO, st.BLT_NO, st.LOT_NO, st.SEQ_NO, sc.STEEL_GRADE, sc.BLT_FAC, sc.FINISH_SIZE, sc.BLT_WGT, st.RF_EN_DT, st.BLT_FLG, sc2.IN_FURNACE_TEMP, sc2.PRE_HEAT_TEMP, sc2.HEAT_TEMP_1, sc2.HEAT_TEMP_2, sc2.HEAT_TEMP_3, sc2.HEAT_TEMP_4, sc2.HEAT_TEMP_5, sc2.HEAT_TEMP_6, sc2.HEAT_TEMP_7, sc2.HEAT_TEMP_8, sc2.OUT_FURNACE_TEMP }).ToList();

                    List<FurnInfo> furnInfos = new List<FurnInfo>();
                    foreach (var mat in matsInFurn)
                    {
                        FurnInfo furnInfo = mat.Transfer<FurnInfo>();
                        furnInfos.Add(furnInfo);
                     }

                    opc.FurnChanged(furnInfos);

                  
                }
                catch (Exception e)
                {
                    LogHelper.Error(e.Message);
                    throw e;
                }

            }
        }


      
    }
}
