using DBLZGX2L2.Enties;
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

namespace DllFurn
{
    /// <summary>
    /// 加热炉操作
    /// </summary>
    public static class ClassFurn
    {
        [Api]
        [EasyLogFilter("加热炉-入炉")]
        /// <summary>
        /// 加热炉-入炉
        /// </summary>
        /// <param name="opc"></param>
        public static void FurnIn(this IOpc opc)
        {
            //生产计划
            PRIDATAManager pRIDATAManager = new PRIDATAManager();
            //生产跟踪
            BLT_PROCManager bLT_PROCManager = new BLT_PROCManager();
            CURSHIFTManager cURSHIFTManager = new CURSHIFTManager();
            //过程数据
            BLT_PROC_DATAManager bLT_PROC_DATAManager = new BLT_PROC_DATAManager();
            //入炉电文
            X2H501Manager x2H501Manager = new X2H501Manager();
            string shift = "";
            string employee = "";
            DateTime enFurnTime = DateTime.Now;


            //取待入炉的第一支坯料
            var matNoReadyIn = pRIDATAManager.PRIDATADb.AsQueryable().Where(p => p.FLAG == 0).OrderBy(it => it.SEQ_NO).OrderBy(it => SqlFunc.ToInt32(it.COIL_NO)).First();
            //取当班装炉操作员信息
            var curShift = cURSHIFTManager.GetList(it=>it.ROLE=="装炉操作员").First();
            shift = curShift.SHIFT_DATE + curShift.SHIFT_GROUP;
            employee = curShift.USER_CODE;

            //新增入炉数据
            var insertData1 = new BLT_PROC() {
                BLT_NO = matNoReadyIn.BILLET_NO,
                LOT_NO = matNoReadyIn.LOT_NO,
                HEAT_NO = matNoReadyIn.HEAT_NO,
                SEQ_NO = matNoReadyIn.SEQ_NO,
                COIL_NO = matNoReadyIn.COIL_NO,
                BLT_WGT = matNoReadyIn.BLT_WGT,
                BLT_FLG = "10",
                RF_EN_DT = enFurnTime,
                RF_CH_OP_SFT = shift,
                EMPLOYEE_ENRF = "AAAA" };        
            if (!bLT_PROCManager.Insert(insertData1))
            {  
                throw new Exception("加热炉实绩新增失败");
            }

            matNoReadyIn.FLAG = 1;
            pRIDATAManager.Update(matNoReadyIn);


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
            };//传入参数            
            if (!bLT_PROC_DATAManager.Insert(insertData2))
            {
                throw new Exception("加热炉过程数据新增失败");
            }
           
            //新增电文内容
            var insertData3 = new X2H501()
            {
                //MSG_ID 在实体中定义特性OracleSequenceName = "X2H501_SEQ"
                MSG_TIME_STAMP = enFurnTime.ToString("yyyyMMddhhmmss"), 
                BILLET_NO = matNoReadyIn.BILLET_NO,
                FAC_OP_CD = "WB",
                CREATED_PROGRAM_ID = "L2sgis",
                CREATION_D = enFurnTime.ToString("yyyyMMddhhmmss"),
                RF_CH_DT = enFurnTime.ToString("yyyyMMddhhmmss"),
                RF_CH_OP_SFT = curShift.GetShiftDateByCode()+curShift.GetShiftGroupByCode(),
                EMPLOYEE_N1 = "AAAA",
                WR_HT_FCE_CH_BT_SEC = Convert.ToInt16(matNoReadyIn.BLT_FAC.Substring(0,3)),
                RF_CH_MAT_LEN = matNoReadyIn.BLT_LEN,
                RF_CH_MAT_RL_WGT= matNoReadyIn.BLT_WGT,
                RF_CH_MAT_CAL_WGT= matNoReadyIn.BLT_WGT,
                RF_CH_MAT_TM= Convert.ToInt16(JRL_RL_TEMP),
                RF_MAT_CH_LEAD_TIME=0,
                RF_CHARGE_STATUS="1",
                RST_HCR_FLAG="C"
            };
            if (!x2H501Manager.Insert(insertData3))
            {
                throw new Exception("电文新增失败");
            }

            // 通知其它fast会话加热炉发生变化
            opc.FurnChanged("加热炉炉内发生动作");

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
            // 通知其它fast会话加热炉发生变化
            //foreach (var session in this.OtherSessions)
            //{
            //    session.InvokeApi("LoginNotify", 1, user.Account);
            //}
            //加热炉出炉材料温度
            var chugang_temp = opc.OpLinkTagValue("JRL_CL_TEMP");
            LogHelper.Info("加热炉-出炉");

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
