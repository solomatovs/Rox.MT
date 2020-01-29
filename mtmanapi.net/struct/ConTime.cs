using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;

namespace rox.mt4.api
{
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct NDays
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 24)]
        public Int32[] name;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct NConTime
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7, ArraySubType = (UnmanagedType)27)]
        public NDays[] days;          // server's accessebility (7 days-24 hours, 0-denied, 1-allowed)
        public Int32 dayscontrol;     // internal variable
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public Int32[] reserved;      // reserved
    };
    
    /// <summary>
    /// Object that represents time configuration
    /// </summary>
    public class ConTime : MT4Model<NConTime>
    {
        public ConTime(int codePage) : base(codePage)
        {
            native.days = new NDays[7];
        }
        public ConTime() : this(0) { }

        /// <summary>
        /// Server's accessebility (7 days-24 hours, 0-denied, 1-allowed)
        /// </summary>
        public List<List<Int32>> Days
        {
            get
            {
                var result = new List<List<Int32>>();
                for(Int32 i = 0; i < native.days.Count(); i++)
                {
                    var dayEntity = new List<Int32>();
                    dayEntity.AddRange(native.days[i].name);
                    result.Add(dayEntity);
                }

                return result;
            }
            set
            {
                Int32 i = 0;
                foreach(var entity in value)
                {
                    if (i > 7)
                    {
                        break;
                    }

                    native.days[i].name = entity.Take(24).ToArray();
                    i++;
                }
            }
        }
    }
}