using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SECSLibs
{
    class AllEventArgs
    {
    }

    public class EventArgs_Checked : EventArgs
    {
        public bool Checked = false;
    }

    public class EventArgs_SingleString : EventArgs
    {
        public string theString = string.Empty;
    }

    public class EventArgs_SingleMessage : EventArgs
    {
        public string tittle = string.Empty;
        public string message = string.Empty;
    }

    public class EventArgs_TypeValue : EventArgs
    {
        public ESECSsingleType type = ESECSsingleType.None;
        public string string_Value = string.Empty;
        public int int_Value = 0;
        public uint uint_Value = 0;
        public byte binary_Value = 0x00;
        public bool bool_Value = false;
    }

    public class EventArgs_FormLabelMessage : EventArgs
    {
        public string message = string.Empty;
        public EMessageState state = EMessageState.None;
    }

    public enum EMessageState : int
    {
        None = 0,
        Error = 1,

        Normal = 5,
        Succeed = 10,
    }
}
