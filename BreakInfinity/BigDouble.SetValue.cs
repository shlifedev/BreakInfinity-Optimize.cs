using System;
using System.Linq; 
namespace BreakInfinity
{ 
    public partial struct BigDouble : IFormattable, IComparable, IComparable<BigDouble>, IEquatable<BigDouble>
    {
        private const int ALLOW_POINT_LENGTH = 4;
        /// <summary>
        /// 조건 -999~999 값만 허용함.
        /// 뒤 소수점은 최적화를 위해 4자리 까지만 허용함. 
        /// </summary>
        /// <param name="value"></param>
        static void SetValue(string value)
        {
            double number = 0;
            int exponent = 0;
            int exponent_start_index = -1;  
            int manfissa_count = 0;

            for (int i = 0; i < value.Length; i++)
            {
                
            }
        }
    }
}