using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ers_Pro.App_Code.Intd_Lts
{
    public partial class Tb_Estate
    {
        public string EstateType
        {
            get
            {
                return this.Tb_EstateType.xEstType;
            }
        }
    }
}