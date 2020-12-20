using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zzkluck.Arknights.Library.AkdataObject
{
    public class Blackboard
    {
        public string key { get; set; }
        public float value { get; set; }
        public string valueStr { get; set; }
    }

    public class Definedable<T>
    {
        public bool m_defined { get; set; }
        public T m_value { get; set; }
    }


}
