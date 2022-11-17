using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SECSLibs
{
    public enum ESECSRole : int
    {
        None = 0,

        Server = 1,
        Client = 2,
    }

    public enum EServerAllowMode : int
    {
        Single_Latest,
        Single_First,
        Multi,
    }
}
