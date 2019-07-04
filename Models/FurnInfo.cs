using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// 加热炉内数据
    /// </summary>
    [ProtoContract]
    public class FurnInfo
    {
        /// <summary>
        /// Desc:线卷号
        /// Default:
        /// Nullable:False
        /// </summary>  
        [ProtoMember(1)]
        public string COIL_NO { get; set; }

        /// <summary>
        /// Desc:方坯号
        /// Default:
        /// Nullable:False
        /// </summary>           
        [ProtoMember(2)]
        public string BLT_NO { get; set; }

        /// <summary>
        /// Desc:生产批号
        /// Default:
        /// Nullable:False
        /// </summary>           
        [ProtoMember(3)]
        public string LOT_NO { get; set; }

        /// <summary>
        /// Desc:生产序号
        /// Default:
        /// Nullable:True
        /// </summary>           
        [ProtoMember(4)]
        public string SEQ_NO { get; set; }

        /// <summary>
        /// Desc:方坯钢种 
        /// Default:
        /// Nullable:True
        /// </summary>           
        [ProtoMember(5)]
        public string STEEL_GRADE { get; set; }             
                
        /// <summary>
        /// Desc:方坯规格
        /// Default:
        /// Nullable:True
        /// </summary>           
        [ProtoMember(6)]
        public string BLT_FAC { get; set; }

        /// <summary>
        /// Desc:轧制规格
        /// Default:
        /// Nullable:True
        /// </summary>           
        [ProtoMember(7)]
        public Single? FINISH_SIZE { get; set; }

        /// <summary>
        /// Desc:方坯实际重量
        /// Default:
        /// Nullable:True
        /// </summary>           
        [ProtoMember(8)]
        public double? BLT_WGT { get; set; }

        /// <summary>
        /// Desc:加热炉装炉日期
        /// Default:
        /// Nullable:True
        /// </summary>           
        [ProtoMember(9)]
        public DateTime? RF_EN_DT { get; set; }

        /// <summary>
        /// Desc:方坯状态0=还未投产	1=作业中	10=进入加热炉	11=出加热炉	12=开始轧制	13=轧制结束 挂钩前	14=挂钩后 称重前	15= 称重完成	2=成品入库结束	3=挑废结束	4=轧废结束
        /// Default:
        /// Nullable:True
        /// </summary>           
        [ProtoMember(10)]
        public string BLT_FLG { get; set; }

        /// <summary>
        /// Desc:(钢坯)入炉温度
        /// Default:
        /// Nullable:True
        /// </summary>           
        [ProtoMember(11)]
        public Single? IN_FURNACE_TEMP { get; set; }

        /// <summary>
        /// Desc:预热段温度
        /// Default:
        /// Nullable:True
        /// </summary> 
        [ProtoMember(12)]
        public Single? PRE_HEAT_TEMP { get; set; }

        /// <summary>
        /// Desc:上加温度
        /// Default:
        /// Nullable:True
        /// </summary>           
        [ProtoMember(13)]
        public decimal? HEAT_TEMP_1 { get; set; }

        /// <summary>
        /// Desc:下加温度
        /// Default:
        /// Nullable:True
        /// </summary>           
        [ProtoMember(14)]
        public Single? HEAT_TEMP_2 { get; set; }

        /// <summary>
        /// Desc:上均左温度
        /// Default:
        /// Nullable:True
        /// </summary>           
        [ProtoMember(15)]
        public Single? HEAT_TEMP_3 { get; set; }

        /// <summary>
        /// Desc:下均左温度
        /// Default:
        /// Nullable:True
        /// </summary>           
        [ProtoMember(16)]
        public Single? HEAT_TEMP_4 { get; set; }

        /// <summary>
        /// Desc:上均中温度
        /// Default:
        /// Nullable:True
        /// </summary>           
        [ProtoMember(17)]
        public Single? HEAT_TEMP_5 { get; set; }

        /// <summary>
        /// Desc:下均中温度
        /// Default:
        /// Nullable:True
        /// </summary>           
        [ProtoMember(18)]
        public Single? HEAT_TEMP_6 { get; set; }

        /// <summary>
        /// Desc:上均右温度
        /// Default:
        /// Nullable:True
        /// </summary>           
        [ProtoMember(19)]
        public Single? HEAT_TEMP_7 { get; set; }

        /// <summary>
        /// Desc:下均右温度
        /// Default:
        /// Nullable:True
        /// </summary>           
        [ProtoMember(20)]
        public Single? HEAT_TEMP_8 { get; set; }
        /// <summary>
        /// Desc:(钢坯)出炉炉温度
        /// Default:
        /// Nullable:True
        /// </summary>           
        [ProtoMember(21)]
        public Single? OUT_FURNACE_TEMP { get; set; }
    }
}
