using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ers_Pro.App_Code.Intd_Lts
{
    public partial class Tb_Dead
    {
        public string FullName
        {
            get { return this.xDedFName + " " + this.xDedLName; }
        }
        public string xHozeh
        {
            get { return this.Tb_Files.Single(n=>n.xDedId_fk==this.xDedId_pk).xHozeh; }
        }

        public string xClass
        {
            get { return this.Tb_Files.Single(n => n.xDedId_fk == this.xDedId_pk).xClass; }

        }
    }
}