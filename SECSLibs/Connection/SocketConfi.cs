using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SECSLibs
{
    class SocketConfi
    {

    }

    public static class SECSshowBuilder
    {
        public static string SECSmsg_Base_ToString(ESECSMsgState state, int lengthOfmsgByte,ESType msgType, bool isWaitBit, int stream = 0, int function = 0)
        {
            string allmsg = string.Empty;
            allmsg += string.Format("{0} \n", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
            if (isWaitBit)
            {
                allmsg += "訊息傳輸: " + state.ToString() + " [W]\n";
            }
            else
            {
                allmsg += "訊息傳輸: " + state.ToString() + "\n";
            }
            
            allmsg += "訊息長度為: " + lengthOfmsgByte.ToString() + "\n";
            allmsg += "Stream Function為: S" + stream.ToString() + "F" + function.ToString() + "\n";
            allmsg += "訊號類型為: " + msgType.ToString() + "\n";

            return allmsg;
        }
        public static string SECSmsg_Struct_ToString(ESECSMsgState state, SECSmsg msg)
        {
            string allmsg = string.Empty;

            allmsg += string.Format("{0} \n", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
            allmsg += string.Format("{0}, {1}. \n", msg.GetSF_string, state.ToString());
            allmsg += (msg.Clone()).ToString();

            return allmsg;
        }
       
    }

    public class EventArgs_EConnectState : EventArgs
    {
        public EConnectState nowState = EConnectState.None;
        public string errorCode = string.Empty;
    }

    public class EventArgs_EMsgState : EventArgs
    {
        public EMsgState nowState = EMsgState.None;
        public string errorCode = string.Empty;
    }

    public class EventArgs_TheMessage : EventArgs
    {
        public bool IsSend = false;
        public bool IsReceive = false;
        public TheMessage themsg = new TheMessage();
    }

    public class EventArgs_Client : EventArgs
    {
        public bool onoff = false;
        public Socket socket = null;
        public string Name = string.Empty;
        public string ID = string.Empty;
    }

    public class ClientSocket
    {
        public Socket C_socket = null;
        public byte[] T7_byte = new byte[] {};
        public string Name = string.Empty;
        public string ID = string.Empty;

        public bool isSECSconnected = false;
        public object socket_locker = new object();

    }

    public class TheMessage
    {
        public string ID = string.Empty;
        public string Msg = string.Empty;

        public string SF = "S0F0";
        public SECSmsg SECS_Msg = new SECSmsg();
    }

    public enum EConnectState : int
    {
        None,
        Disconnect,
        Connecting,
        Connected,

        Down,
        Error,
    }

    public enum EMsgState : int
    {
        None,
        Sending,
        Sent,
        Receiving,
        Received,

        Error,
    }

    public enum ESType : int
    {
        None = -1,

        DataMessage = 0,
        Select_Req = 1,
        Select_Rsp = 2,
        Deselect_Req = 3,
        Deselect_Rsp = 4,
        LinkTest_Req = 5,
        LinkTest_Rsp = 6,
        Reject_Req = 7,

        Separate_Req = 9,
    }

    public enum ESECSMsgState : int
    {
        Receive = 0,
        Send = 1,
    }
}
