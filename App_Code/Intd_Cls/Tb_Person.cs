using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ers_Pro.App_Code.Intd_Lts
{
    public partial class Tb_Person
    {
        public string PrsFullName
        {
            get { return this.xPrsFName + " " + this.xPrsLName; }
        }
    }
}