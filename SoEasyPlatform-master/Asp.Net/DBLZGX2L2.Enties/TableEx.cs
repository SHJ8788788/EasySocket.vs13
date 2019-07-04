using Sugar.Enties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBLZGX2L2.Enties
{
    public static class TableEx
    {
        public static string GetShiftNo(this CURSHIFT cURSHIFT)
        {
            var shiftDateCode="";
            switch (cURSHIFT.SHIFT_DATE)
            {
                case "晚":
                    shiftDateCode = "1";
                    break;
                case "白":
                    shiftDateCode = "2";
                    break;
                case "中":
                    shiftDateCode = "3";
                    break;
                default:
                    break;
            }
            return shiftDateCode;
        }
        public static string GetGroupNo(this CURSHIFT cURSHIFT)
        {
            var shiftGroupCode = "";
            switch (cURSHIFT.SHIFT_GROUP)
            {
                case "甲":
                    shiftGroupCode = "A";
                    break;
                case "乙":
                    shiftGroupCode = "B";
                    break;
                case "丙":
                    shiftGroupCode = "C";
                    break;
                case "丁":
                    shiftGroupCode = "D";
                    break;
                default:
                    break;
            }
            return shiftGroupCode;
        }
    }
}

