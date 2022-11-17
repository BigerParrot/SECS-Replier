using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SECSLibs
{
    /// <summary>
    /// 用於解析SECS資訊或產生SECS訊號串
    /// </summary>
    public static class SECSstruct
    {
        public static bool BuildSECSmsg(byte[] byteArray,ref SECSmsg backMessage)
        {
            backMessage = new SECSmsg();

            for (int x = 1; x < byteArray.Length; x++)
            {
                SECSsingleLine lineHere = new SECSsingleLine();
                bool checkHere = true;
                int padLength = 0;

                lineHere.Type = GetSECSType(byteArray[x - 1], out padLength, out checkHere);

                if (padLength == 0) { continue; }
                if (padLength < 0 || padLength > 3)
                {
                    checkHere = false;
                }
                else if (checkHere)
                {
                    byte[] subByteArray = new byte[padLength];
                    Array.Copy(byteArray, x, subByteArray, 0, padLength);
                    int padValue = GetPadValue(subByteArray);

                    x += padLength;
                    byte[] subByteArray2 = new byte[padValue];
                    if (padValue != 0)
                    {
                        Array.Copy(byteArray, x, subByteArray2, 0, padValue);
                    }
                    if (subByteArray2.Length > 0)
                    {
                        switch (lineHere.Type)
                        {
                            case ESECSsingleType.L:
                                lineHere.AsList = padValue;
                                break;
                            case ESECSsingleType.Bi:
                                if (padValue.Equals(1)) { lineHere.AsBi = subByteArray2[0]; }
                                break;
                            case ESECSsingleType.Bo:
                                lineHere.AsBo = BitConverter.ToBoolean(subByteArray2, 0);
                                break;
                            case ESECSsingleType.A:
                                lineHere.AsA = System.Text.Encoding.UTF8.GetString(subByteArray2, 0, padValue);
                                break;
                            case ESECSsingleType.J:
                                lineHere.AsJ = System.Text.Encoding.UTF8.GetString(subByteArray2, 0, padValue);
                                break;
                            case ESECSsingleType.I1:
                                lineHere.AsI1 = BitConverter.ToInt32(subByteArray2, 0);
                                break;
                            case ESECSsingleType.I2:
                                lineHere.AsI2 = BitConverter.ToInt32(subByteArray2, 0);
                                break;
                            case ESECSsingleType.I4:
                                lineHere.AsI4 = BitConverter.ToInt32(subByteArray2, 0);
                                break;
                            case ESECSsingleType.I8:
                                lineHere.AsI8 = BitConverter.ToInt32(subByteArray2, 0);
                                break;
                            case ESECSsingleType.F4:
                                lineHere.AsF4 = BitConverter.ToSingle(subByteArray2, 0); //待改善
                                break;
                            case ESECSsingleType.F8:
                                lineHere.AsF8 = BitConverter.ToSingle(subByteArray2, 0); //待改善
                                break;
                            case ESECSsingleType.U1:
                                lineHere.AsU1 = BitConverter.ToUInt32(subByteArray2, 0);
                                break;
                            case ESECSsingleType.U2:
                                lineHere.AsU2 = BitConverter.ToUInt32(subByteArray2, 0);
                                break;
                            case ESECSsingleType.U4:
                                lineHere.AsU4 = BitConverter.ToUInt32(subByteArray2, 0);
                                break;
                            case ESECSsingleType.U8:
                                lineHere.AsU8 = BitConverter.ToUInt32(subByteArray2, 0);
                                break;
                        }
                    }
                    else
                    {
                        switch (lineHere.Type)
                        {
                            case ESECSsingleType.L:
                                lineHere.AsList = padValue;
                                break;
                            case ESECSsingleType.Bi:
                                lineHere.AsBi = 0x00;
                                break;
                            case ESECSsingleType.Bo:
                                lineHere.AsBo = false;
                                break;
                            case ESECSsingleType.A:
                                lineHere.AsA = string.Empty;
                                break;
                            case ESECSsingleType.J:
                                lineHere.AsJ = string.Empty;
                                break;
                            case ESECSsingleType.I1:
                                lineHere.AsI1 = 0;
                                break;
                            case ESECSsingleType.I2:
                                lineHere.AsI2 = 0;
                                break;
                            case ESECSsingleType.I4:
                                lineHere.AsI4 = 0;
                                break;
                            case ESECSsingleType.I8:
                                lineHere.AsI8 = 0;
                                break;
                            case ESECSsingleType.F4:
                                lineHere.AsF4 = 0; //待改善
                                break;
                            case ESECSsingleType.F8:
                                lineHere.AsF8 = 0; //待改善
                                break;
                            case ESECSsingleType.U1:
                                lineHere.AsU1 = 0;
                                break;
                            case ESECSsingleType.U2:
                                lineHere.AsU2 = 0;
                                break;
                            case ESECSsingleType.U4:
                                lineHere.AsU4 = 0;
                                break;
                            case ESECSsingleType.U8:
                                lineHere.AsU8 = 0;
                                break;
                        }
                        
                    }
                    
                    if (lineHere.Type != ESECSsingleType.L) { x += padValue; }
                }
                else
                {
                    backMessage = new SECSmsg();
                    return false;
                }

                if (!backMessage.SetLatestLine(lineHere))
                {
                    break;
                }
            }
            return true;
        }

        #region --BuildSECSmsg私有方法--
        private static ESECSsingleType GetSECSType(byte signal, out int padLength, out bool checking)
        {
            string now8 = Convert.ToString(signal, 2).PadLeft(8, '0');
            string sub6_now8 = now8.Substring(0, 6);
            padLength = Convert.ToInt32(now8.Substring(6, 2), 2);

            checking = true;
            switch (sub6_now8)
            {
                case "000000":
                    return ESECSsingleType.L;
                case "001000":
                    return ESECSsingleType.Bi;
                case "001001":
                    return ESECSsingleType.Bo;
                case "010000":
                    return ESECSsingleType.A;
                case "010001":
                    return ESECSsingleType.J;
                case "011000":
                    return ESECSsingleType.I8;
                case "011001":
                    return ESECSsingleType.I1;
                case "011010":
                    return ESECSsingleType.I2;
                case "011100":
                    return ESECSsingleType.I4;
                case "100000":
                    return ESECSsingleType.F8;
                case "100100":
                    return ESECSsingleType.F4;
                case "101000":
                    return ESECSsingleType.U8;
                case "101001":
                    return ESECSsingleType.U1;
                case "101010":
                    return ESECSsingleType.U2;
                case "101100":
                    return ESECSsingleType.U4;
                default:
                    checking = false;
                    return ESECSsingleType.Error;
            }
        }

        private static int GetPadValue(byte[] byteArray)
        {
            string totals = string.Empty;
            for (int y = 0; y < byteArray.Length; y++)
            {
                totals += Convert.ToString((byte)byteArray[y], 2).PadLeft(8, '0');
            }
            return checked((int)Convert.ToUInt32(totals, 2));
        }

        private static int GetIntValue(byte[] byteArray)
        {
        /*
            string UintTotals = string.Empty;
            for (int y = 0; y < byteArray.Length; y++)
            {
                UintTotals += Convert.ToString((byte)byteArray[y], 2).PadLeft(8, '0');
            }
            return Convert.ToInt32(UintTotals, 2);
         */
            return Convert.ToInt32(byteArray);
        }

        #endregion --BuildSECSmsg私有方法--

        public static byte[] Send_SelectReq(byte[] ReqGet)
        {
            byte[] SessionID = new byte[] { 0xFF, 0xFF };
            return BuildSendSECSmsg(ESType.Select_Req, SessionID, ReqGet);
        }

        public static byte[] Send_LinkTest(byte[] ReqGet)
        {
            byte[] SessionID = new byte[] { 0xFF, 0xFF };
            return BuildSendSECSmsg(ESType.LinkTest_Req, SessionID, ReqGet);
        }

        public static byte[] BuildSendSECSmsg(ESType MsgType, byte[] SessionID, byte[] ReqGet, SECSmsg msg = null)
        {
            if (msg == null)
            {
                byte[] backMsg = new byte[]{
                    0x00,
                    0x00,
                    0x00,
                    0x0A,

                    SessionID[0],
                    SessionID[1],

                    0x00,
                    0x00,

                    0x00,
                    Convert.ToByte((int)MsgType),

                    ReqGet[0],
                    ReqGet[1],
                    ReqGet[2],
                    ReqGet[3],
                };
                return backMsg;
            }
            else
            {
                if (!msg.IsEnd()) { return null; }
                List<byte> msgPart = new List<byte>();

                Dictionary<int,int> ad = new Dictionary<int,int>();
                ad.Add(0,0);
                GetByteOfLine((SECSsingleLine)msg.RootItem, ref msgPart);

                while (msg.ToNextAddress(ad))
                {
                    SECSsingleLine line = new SECSsingleLine();
                    msg.GetLine(ad, ref line);
                    GetByteOfLine(line, ref msgPart);
                }

                byte[] b4 = new byte[4];
                b4 = BitConverter.GetBytes(msgPart.Count + 10);

                byte[] backMsg = new byte[]{
                    b4[3],
                    b4[2],
                    b4[1],
                    b4[0],

                    0x00, // Device ID
                    0x00, // Device ID

                    BitConverter.GetBytes(msg.Stream + 128)[0],
                    BitConverter.GetBytes(msg.Function)[0],

                    0x00,
                    0x00,

                    ReqGet[0],
                    ReqGet[1],
                    ReqGet[2],
                    ReqGet[3],
                };
                byte[] backM = new byte[msgPart.Count + 14];
                backMsg.CopyTo(backM, 0);
                msgPart.ToArray().CopyTo(backM, 14);
                return backM;
            }
        }

        private static void GetByteOfLine(SECSsingleLine line, ref List<byte> byteList)
        {
            string sub6 = string.Empty;
            string sub2 = string.Empty;

            switch (line.Type)
            {
                
                case ESECSsingleType.L:
                    sub6 = "000000";
                    break;
                case ESECSsingleType.Bi:
                    sub6 = "001000";
                    break;
                case ESECSsingleType.Bo:
                    sub6 = "001001";
                    break;
                case ESECSsingleType.A:
                    sub6 = "010000";
                    break;
                case ESECSsingleType.J:
                    sub6 = "010001";
                    break;
                case ESECSsingleType.I1:
                    sub6 = "011001";
                    break;
                case ESECSsingleType.I2:
                    sub6 = "011010";
                    break;
                case ESECSsingleType.I4:
                    sub6 = "011100";
                    break;
                case ESECSsingleType.I8:
                    sub6 = "011000";
                    break;
                case ESECSsingleType.F4:
                    sub6 = "100100";
                    break;
                case ESECSsingleType.F8:
                    sub6 = "100000";
                    break;
                case ESECSsingleType.U1:
                    sub6 = "101001";
                    break;
                case ESECSsingleType.U2:
                    sub6 = "101010";
                    break;
                case ESECSsingleType.U4:
                    sub6 = "101100";
                    break;
                case ESECSsingleType.U8:
                    sub6 = "101000";
                    break;
                default:
                    return;
            }

            if (line.Type == ESECSsingleType.L)
            {
                int v = line.AsList;
                List<byte> q = new List<byte>();
                while ((v / 256 > 0 || v % 256 != 0)&& q.Count < 3)
                {
                    q.Add(Convert.ToByte(v % 256));
                    v = v / 256;
                }
                switch (q.Count)
                {
                    case 0:
                    case 1:
                        sub2 = "01";
                        break;
                    case 2:
                        sub2 = "10";
                        break;
                    case 3:
                        sub2 = "11";
                        break;
                }

                byteList.Add(Convert.ToByte(string.Format("{0}{1}", sub6, sub2), 2));
                if (q.Count == 0) { byteList.Add(0x00); return; }
                int c = q.Count;
                for (int i = c -1; i >= 0; i--)
                {
                    byteList.Add(q[i]);
                    q.RemoveAt(i);
                }
                return;
            }
            else
            {
                byte[] stringByteArray = null;
                switch (line.Type)
                {
                    case ESECSsingleType.Bo:
                        stringByteArray = new byte[] { Convert.ToByte(line.AsBo) };
                        break;
                    case ESECSsingleType.Bi:
                        stringByteArray = new byte[] { line.AsBi };
                        break;
                    case ESECSsingleType.A:
                    case ESECSsingleType.J:
                        string va = line.Value.ToString();
                        stringByteArray = Encoding.UTF8.GetBytes(va);
                        break;
                    case ESECSsingleType.F4:
                    case ESECSsingleType.F8:
                        stringByteArray = BitConverter.GetBytes(line.AsF4);
                        break;
                    case ESECSsingleType.I1:
                    case ESECSsingleType.I2:
                    case ESECSsingleType.I4:
                    case ESECSsingleType.I8:
                        stringByteArray = BitConverter.GetBytes(int.Parse(line.Value.ToString())).ToArray();
                        //Array.Reverse(stringByteArray);
                        break;
                    case ESECSsingleType.U1:
                    case ESECSsingleType.U2:
                    case ESECSsingleType.U4:
                    case ESECSsingleType.U8:
                        stringByteArray = BitConverter.GetBytes(uint.Parse(line.Value.ToString())).ToArray();
                        //Array.Reverse(stringByteArray);
                        break;
                    default:
                        return;
                }
                if (stringByteArray == null) { return; }

                int v = stringByteArray.Length;
                List<byte> q = new List<byte>();

                while ((v / 256 > 0 || v % 256 != 0) && q.Count < 3)
                {
                    q.Add(Convert.ToByte(v % 256));
                    v = v / 256;
                }
                switch (q.Count)
                {
                    case 0:
                    case 1:
                        sub2 = "01";
                        break;
                    case 2:
                        sub2 = "10";
                        break;
                    case 3:
                        sub2 = "11";
                        break;
                }

                byteList.Add(Convert.ToByte(string.Format("{0}{1}", sub6, sub2), 2));
                if (q.Count == 0) { byteList.Add(0x00); return; }
                int c = q.Count;
                for (int i = c - 1; i >= 0; i--)
                {
                    byteList.Add(q[i]);
                    q.RemoveAt(i);
                }
                byteList.AddRange(stringByteArray);
                return;
            }
        }
    }

    /// <summary>
    /// 用於紀錄SECS資訊，含(名稱、描述)
    /// </summary>
    public class SECSItem : SECSmsg
    {
        private string description = string.Empty;
        private string name = string.Empty;
        private bool isUsed = false;

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get { return description; } set { description = value; } }

        /// <summary>
        /// 名稱
        /// </summary>
        public string Name { get { return name; } set { name = value; } }

        /// <summary>
        /// 訊號使用與否
        /// </summary>
        public bool IsUsed { get { return isUsed; } set { isUsed = value; } }

        /// <summary>
        /// 設置其訊號資訊
        /// </summary>
        /// <param name="msg">要設置的訊號</param>
        public void SetBase(SECSmsg msg)
        {
            base.SetSF(msg.Stream, msg.Function);
            base.RootItem = msg.RootItem;
        }

        public override string ToString()
        {
            return string.Format("{0}: {1}", GetSF_string, name);
        }
    }

    /// <summary>
    /// 用於紀錄SECS訊號資訊(Stream Function)
    /// </summary>
    public class SECSmsg
    {
        private int stream = 0;
        private int function = 0;

        private Root rootItem = new Root();
        private bool msgState = true;

        /// <summary>
        /// 取得訊號的複製項
        /// </summary>
        /// <returns></returns>
        public SECSmsg Clone()
        {
            SECSmsg msg = new SECSmsg();

            msg.Stream = stream;
            msg.Function = function;

            msg.RootItem = rootItem.Clone();

            return msg;
        }

        public bool IsMsgHas_Spare
        {
            get
            {
                Dictionary<int, int> ad = new Dictionary<int, int>();
                ad.Add(0, 0);
                while (ToNextAddress(ad))
                {
                    SECSsingleLine line = new SECSsingleLine();
                    GetLine(ad, ref line);
                    if (line.Type == ESECSsingleType.Spare) { return true; }
                }
                return false;
            }
        }

        public bool AsPrimaryMessage { get { return msgState; }set { msgState = value; } }
        public bool AsSecondaryMessage { get { return !msgState; } set { msgState = !value; } }

        /// <summary>
        /// 訊號的根項目
        /// </summary>
        public Root RootItem { get { return rootItem; } set { rootItem = value; } }

        /// <summary>
        /// 訊號的Stream
        /// </summary>
        public int Stream { get { return stream; } set { stream = value; } }

        /// <summary>
        /// 訊號的Function
        /// </summary>
        public int Function { get { return function; } set { function = value; } }

        /// <summary>
        /// 以string形式輸出訊號的SF(如:S0F0)
        /// </summary>
        public string GetSF_string
        {
            get
            {
                return string.Format("S{0}F{1}", stream.ToString(), function.ToString());
            }
        }

        /// <summary>
        /// 設置訊號的Stream、Function
        /// </summary>
        /// <param name="stream">設置的Stream</param>
        /// <param name="function">設置的Function</param>
        public void SetSF(int stream, int function)
        {
            this.stream = stream;
            this.function = function;
        }

        public static Dictionary<int, int> GetFirstAddress()
        {
            Dictionary<int, int> firstMsg = new Dictionary<int,int>();
            firstMsg.Add(0,0);
            return firstMsg;
        }

        /// <summary>
        /// 從SECS資訊取得單行資訊
        /// </summary>
        /// <param name="address">單行資訊位於SECS的地址</param>
        /// <param name="backLine">回傳的單行資訊</param>
        /// <returns>取得成功與否</returns>
        public bool GetLine(Dictionary<int, int> address,ref SECSsingleLine backLine)
        {
            backLine = new SECSsingleLine();
            Item item = new Item();

            for (int i = 0; i < address.Count; i++)
            {
                if (!address.ContainsKey(i)) { return false; }

                if(i == 0 && address[i] == 0){ backLine = rootItem; }
                else if (i == 1)
                {
                    item = rootItem.Items[address[i]].Clone();
                    if (address.Count == i + 1) { backLine = item; return true; }
                }
                else
                {
                    item = item.Items[address[i]].Clone();
                    if(address.Count == i + 1) { backLine = item;  return true; }
                }
            }
            return false;
        }

        /// <summary>
        /// 設置SECS資訊裡的單行資訊
        /// </summary>
        /// <param name="address">單行資訊位於SECS的地址</param>
        /// <param name="backLine">回傳的單行資訊</param>
        /// <returns>取得成功與否</returns>
        public bool SetLine(Dictionary<int, int> address, SECSsingleLine backLine)
        {
            Item item = new Item();

            for (int i = 0; i < address.Count; i++)
            {
                if (!address.ContainsKey(i)) { return false; }

                if (i == 0 && address[i] == 0) 
                {
                    if (address.Count == i + 1) { rootItem.SetLine(backLine); return true; }
                }
                else if (i == 1)
                {
                    item = rootItem.Items[address[i]];
                    if (address.Count == i + 1) { item.SetLine(backLine); return true; }
                }
                else
                {
                    item = item.Items[address[i]];
                    if (address.Count == i + 1) { item.SetLine(backLine); return true; }
                }
            }
            return false;
        }

        /// <summary>
        /// 清除行資訊
        /// </summary>
        /// <param name="address">行的地址</param>
        /// <returns>清除成功與否</returns>
        public bool ClearLine(Dictionary<int, int> address)
        {
            Item item = new Item();

            for (int i = 0; i < address.Count; i++)
            {
                if (!address.ContainsKey(i)) { return false; }

                if (i == 0)
                {
                    if (address.Count == 1)
                    {
                        rootItem = new Root();
                        return true;
                    }
                }
                else if (i == 1)
                {
                    if (address.Count == 2)
                    {
                        rootItem.Items[address[i]] = new Item();
                        return true;
                    }
                    item = rootItem.Items[address[i]];
                }
                else
                {
                    if (address.Count == i + 1)
                    {
                        item.Items[address[i]] = new Item();
                        return true;
                    }
                    item = item.Items[address[i]];
                }

            }
            return false;
        }

        /// <summary>
        /// 設置下一行
        /// </summary>
        /// <param name="inputLine">要寫入的行</param>
        /// <returns></returns>
        public bool SetLatestLine(SECSsingleLine inputLine)
        {
            if(rootItem.Type == ESECSsingleType.None) { rootItem.SetLine(inputLine); return true; }
            if(rootItem.Type == ESECSsingleType.L)
            {
                for(int x = 0; x < rootItem.AsList; x++)
                {
                    Item item = rootItem.Items[x];
                    if (rootItem.Items[x].Type == ESECSsingleType.L)
                    {
                        if (IsListtheEnd(item)) { continue; } else
                        {
                            if (InputLine(item, inputLine)) { return true; }
                        }
                    }else if(rootItem.Items[x].Type == ESECSsingleType.None)
                    {
                        if (InputLine(item, inputLine)) { return true; }
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 清除最後一行
        /// </summary>
        /// <returns>是否完成</returns>
        public bool ClearLatestLine()
        {
            if (rootItem.Type == ESECSsingleType.None) 
            { 
                return false; 
            }
            else
            {
                Dictionary<int, int> nowAddress = new Dictionary<int, int>();
                nowAddress.Add(0, 0);

                if (rootItem.Type == ESECSsingleType.L && rootItem.AsList != 0)
                {
                    for (int x = rootItem.AsList - 1; x >= 0; x--)
                    {
                        Item item = rootItem.Items[x];
                        if (rootItem.Items[x].Type != ESECSsingleType.None)
                        {
                            nowAddress.Add(1,x);
                            Dictionary<int, int> lastAddress = new Dictionary<int, int>(nowAddress);
                            while (ToNextAddress(nowAddress))
                            {
                                SECSsingleLine line = new SECSsingleLine();
                                GetLine(nowAddress, ref line);
                                if (line.Type != ESECSsingleType.None)
                                {
                                    lastAddress = new Dictionary<int, int>(nowAddress);
                                }
                            }
                            ClearLine(lastAddress);
                            return true;
                        }
                    }
                    rootItem = new Root();
                    return true;
                }
                else
                {
                    rootItem = new Root();
                    return true;
                }
            }
        }

        /// <summary>
        /// 回傳SECSmsg的String格式
        /// </summary>
        /// <returns>回傳String格式</returns>

        public override string ToString()
        {
            Dictionary<int, int> nowAddress = new Dictionary<int, int>();

            string allmsg = string.Empty;

            nowAddress.Add(0, 0);
            allmsg += GetLineString(rootItem, 0);

            bool isContinue = true;
            while (nowAddress.Count > 0 && isContinue)
            {
                if (ToNextAddress(nowAddress))
                {
                    SECSsingleLine line = new SECSsingleLine();
                    if (GetLine(nowAddress,ref line))
                    {
                        allmsg += GetLineString(line, nowAddress.Count - 1);
                    }
                }
                else
                {
                    isContinue = false;
                }
            }

            return allmsg;
        }

        public bool SECS_Equals(object obj)
        {
            SECSmsg ob_SECSmsg = obj as SECSmsg;
            if (ob_SECSmsg == null) { return false; }

            if (ob_SECSmsg.Stream != stream || ob_SECSmsg.Function != function) { return false; }
            if (!ob_SECSmsg.RootItem.SECS_Root_Equals(rootItem)) { return false; }

            return true;
        }

        /// <summary>
        /// 檢查此訊號是否完成編輯
        /// </summary>
        /// <returns>是否完成</returns>
        public bool IsEnd()
        {
             Dictionary<int, int> ad = new Dictionary<int, int>();
             ad.Add(0,0);
             while (ToNextAddress(ad))
             {
                SECSsingleLine line = new SECSsingleLine();
                GetLine(ad, ref line);
                if (line.Type == ESECSsingleType.None) { return false; }
             }
             return true;
        }

        /// <summary>
        /// 取得下一個行位置
        /// </summary>
        /// <param name="address">目前的行位置</param>
        /// <returns>取得下個行的位置</returns>
        public bool ToNextAddress(Dictionary<int, int> address)
        {
            Dictionary<int, int> ad = new Dictionary<int, int>(address);
            Dictionary<int, bool> ad_List = new Dictionary<int, bool>();
            int latestUnfullLayer = 0;

            if (ad.Count == 0) { return false; }

            Item item = new Item();
            for(int i = 0; i < ad.Count; i++)
            {
                if (!ad.ContainsKey(i)) { return false; }
                if (i == 0 && ad[i] != 0) { return false; } else
                {
                    if (i == 0)
                    {
                        ad_List.Add(0, true);
                    }
                    else if (i == 1)
                    {
                        if (rootItem.AsList <= ad[i] + 1)
                        {
                            ad_List.Add(i, true);
                        }
                        else
                        {
                            ad_List.Add(i, false);
                            latestUnfullLayer = i;
                        }
                    }
                    else
                    {
                        if (item.AsList <= ad[i] + 1)
                        {
                            ad_List.Add(i, true);
                        }
                        else
                        {
                            ad_List.Add(i, false);
                            latestUnfullLayer = i;
                        }
                    }


                    if(i == 1)
                    {
                        item = rootItem.Items[ad[i]].Clone();
                    }
                    else if(i > 1)
                    {
                        item = item.Items[ad[i]].Clone();
                    } 
                }
            }

            if (ad.Count == 1 && ad[0] == 0)
            {
                if (rootItem.AsList != 0)
                {
                    address.Add(address.Count, 0); return true;
                }
                else
                {
                    return false;
                }
            }

            if (item.Type == ESECSsingleType.L && item.AsList != 0) { address.Add(address.Count, 0); return true; }
            else
            {
                if (latestUnfullLayer == 0 && !ad_List.ContainsValue(false)) { return false; }
                if (latestUnfullLayer == address.Count - 1)
                {
                    int nextValue = address[address.Count - 1] + 1;
                    address.Remove(address.Count - 1);
                    address.Add(address.Count, nextValue);
                    return true;
                }
                else if (latestUnfullLayer != address.Count - 1)
                {
                    int v = address.Count - 1;
                    int nextValue = address[latestUnfullLayer] + 1;
                    for (int i = v; i >= latestUnfullLayer; i--)
                    {
                        address.Remove(i);
                    }
                    address.Add(address.Count, nextValue);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// 取得單行的String資訊
        /// </summary>
        /// <param name="lineMsg">單行</param>
        /// <param name="layer">第幾層</param>
        /// <returns>輸出資訊</returns>
        private string GetLineString(SECSsingleLine lineMsg, int layer)
        {
            string msg = string.Empty;

            for (int x = 0; x < layer; x++)
            {
                msg += "    ";
            }

            switch (lineMsg.Type)
            {
                case ESECSsingleType.L:
                    msg += "< L [" + lineMsg.AsList + "]" + "\n";
                    break;
                case ESECSsingleType.Bi:
                    msg += "< Binary '" + lineMsg.AsBi.ToString("X2") + "' >" + "\n";
                    break;
                case ESECSsingleType.Bo:
                    msg += "< Boolean '" + lineMsg.AsBo.ToString() + "' >" + "\n";
                    break;
                case ESECSsingleType.A:
                    msg += "< A '" + lineMsg.AsA + "' >" + "\n";
                    break;
                case ESECSsingleType.J:
                    msg += "< J '" + lineMsg.AsJ + "' >" + "\n";
                    break;
                case ESECSsingleType.I1:
                    msg += "< I1 '" + lineMsg.AsI1.ToString() + "' >" + "\n";
                    break;
                case ESECSsingleType.I2:
                    msg += "< I2 '" + lineMsg.AsI2.ToString() + "' >" + "\n";
                    break;
                case ESECSsingleType.I4:
                    msg += "< I4 '" + lineMsg.AsI4.ToString() + "' >" + "\n";
                    break;
                case ESECSsingleType.I8:
                    msg += "< I8 '" + lineMsg.AsI8.ToString() + "' >" + "\n";
                    break;
                case ESECSsingleType.F4:
                    msg += "< F4 '" + lineMsg.AsF4.ToString() + "' >" + "\n"; //待改善
                    break;
                case ESECSsingleType.F8:
                    msg += "< F8 '" + lineMsg.AsF8.ToString() + "' >" + "\n"; //待改善
                    break;
                case ESECSsingleType.U1:
                    msg += "< U1 '" + lineMsg.AsU1.ToString() + "' >" + "\n";
                    break;
                case ESECSsingleType.U2:
                    msg += "< U2 '" + lineMsg.AsU2.ToString() + "' >" + "\n";
                    break;
                case ESECSsingleType.U4:
                    msg += "< U4 '" + lineMsg.AsU4.ToString() + "' >" + "\n";
                    break;
                case ESECSsingleType.U8:
                    msg += "< U8 '" + lineMsg.AsU8.ToString() + "' >" + "\n";
                    break;
                case ESECSsingleType.Spare:
                    msg += "< Spare line... >" + "\n";
                    break;
            }
            return msg;

        }

        /// <summary>
        /// 檢查子資訊(List)下是否完成編輯
        /// </summary>
        /// <param name="checkMsg">要檢查的子項目</param>
        /// <returns>完成與否</returns>
        private bool IsListtheEnd(Item checkMsg)
        {
            if (checkMsg.Type != ESECSsingleType.L) { return true; }
            for (int x = 0; x < checkMsg.AsList; x++)
            {
                if (!checkMsg.Items.ContainsKey(x)) { return false; } else if (checkMsg.Items[x].Type == ESECSsingleType.None) { return false; }
                if (checkMsg.Items[x].Type == ESECSsingleType.L)
                {
                    if (!IsListtheEnd(checkMsg.Items[x])) { return false; }
                }
            }
            return true;
        }

        /// <summary>
        /// 設置新的行資訊
        /// </summary>
        /// <param name="listMsg"></param>
        /// <param name="inputLine">要放入的行</param>
        /// <returns>成功與否</returns>
        private bool InputLine(Item listMsg, SECSsingleLine inputLine)
        {
            if (listMsg.Type == ESECSsingleType.None) { listMsg.SetLine(inputLine); return true; }
            if (listMsg.Type == ESECSsingleType.L)
            {
                for (int x = 0; x < listMsg.AsList; x++)
                {
                    if (!listMsg.Items.ContainsKey(x)) { return false; } else if (listMsg.Items[x].Type == ESECSsingleType.None) { listMsg.Items[x].SetLine(inputLine); return true; }
                    if (listMsg.Items[x].Type == ESECSsingleType.L)
                    {
                        if (InputLine(listMsg.Items[x], inputLine)) { return true; }
                    }
                }
            }
            return false;
        }
    }

    /// <summary>
    /// SECS資訊裡的根目錄
    /// </summary>
    public class Root : SECSsingleLine
    {
        Dictionary<int, Item> items = new Dictionary<int, Item>();

        public Dictionary<int, Item> Items { get { return items; } set { items = value; } }

        protected override void SetAsList()
        {
            items.Clear();
            for (int i = 0; i < this.AsList; i++)
            {
                items.Add(i, new Item());
            }
        }

        protected override void DoTypeChange()
        {
            if (this.Type != ESECSsingleType.L) { items.Clear(); }
        }

        public Root Clone()
        {
            Root backItem = new Root();
            backItem.SetLine((SECSsingleLine)this);
            backItem.Items = new Dictionary<int, Item>(items);
            return backItem;
        }

        public bool SECS_Root_Equals(object obj)
        {
            Root item = obj as Root;
            if (item == null) { return false; }

            if (this.Type == ESECSsingleType.Spare) { return true; }
            if ((this as SECSsingleLine).SECS_Equals(item as SECSsingleLine))
            {
                bool isMatch = true;
                for (int count = 0; count < items.Count; count++)
                {
                    if (items.ContainsKey(count) && item.Items.ContainsKey(count))
                    {
                        if (!(items[count] as Item).SECS_Item_Equals(item.Items[count] as Item))
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                return isMatch;
            }
            return false;
        }

    }

    /// <summary>
    /// SECS資訊裡的細項
    /// </summary>
    public class Item : SECSsingleLine
    {
        Dictionary<int, Item> items = new Dictionary<int, Item>();

        public Dictionary<int, Item> Items { get { return items; } set { items = value; } }

        protected override void SetAsList()
        {
            items.Clear();
            for(int i = 0; i < this.AsList; i++)
            {
                items.Add(i, new Item());
            }
        }

        protected override void DoTypeChange()
        {
            if(this.Type != ESECSsingleType.L) { items.Clear(); }
        }

        public Item Clone()
        {
            Item backItem = new Item();
            backItem.SetLine((SECSsingleLine)this);
            backItem.Items = new Dictionary<int, Item>(items);
            return backItem;
        }

        public bool SECS_Item_Equals(object obj)
        {
            Item item = obj as Item;
            if (item == null) { return false; }

            if (this.Type == ESECSsingleType.Spare || item.Type == ESECSsingleType.Spare) { return true; }
            if ((this as SECSsingleLine).SECS_Equals(item as SECSsingleLine))
            {
                bool isMatch = true;
                for (int count = 0; count < items.Count; count++)
                {
                    if (items.ContainsKey(count) && item.Items.ContainsKey(count))
                    {
                        if (items[count].Type == ESECSsingleType.L && item.Items[count].Type == ESECSsingleType.L)
                        {
                            if (!(items[count] as Item).SECS_Item_Equals(item.Items[count] as Item))
                            {
                                return false;
                            }
                        }
                        else
                        {
                            if (!(items[count] as SECSsingleLine).SECS_Equals(item.Items[count] as SECSsingleLine))
                            {
                                return false;
                            }
                        }
                        
                    }
                    else
                    {
                        return false;
                    }
                }
                return isMatch;
            }
            return false;
        }

    }

    /// <summary>
    /// SECS的單行資訊
    /// </summary>
    public class SECSsingleLine
    {
        ESECSsingleType type = ESECSsingleType.None;
        private bool boolValue = false;
        private bool isSpare = false;
        private int intValue = 0;
        private uint uintValue = 0;
        private float floatValue = 0F;
        private string stringValue = string.Empty;
        private byte binaryValue = 0x00;

        public ESECSsingleType Type { set { type = value; } get { return type; } }
        public int AsList { set { intValue = value; SetAsList(); } get { return intValue; } }
        public byte AsBi { set { binaryValue = value; } get { return binaryValue; } }
        public bool AsBo { set { boolValue = value; } get { return boolValue; } }
        public string AsA { set { stringValue = value; } get { return stringValue; } }
        public string AsJ { set { stringValue = value; } get { return stringValue; } }
        public int AsI1 { set { intValue = value; } get { return intValue; } }
        public int AsI2 { set { intValue = value; } get { return intValue; } }
        public int AsI4 { set { intValue = value; } get { return intValue; } }
        public int AsI8 { set { intValue = value; } get { return intValue; } }
        public float AsF4 { set { floatValue = value; } get { return floatValue; } }
        public float AsF8 { set { floatValue = value; } get { return floatValue; } }
        public uint AsU1 { set { uintValue = value; } get { return uintValue; } }
        public uint AsU2 { set { uintValue = value; } get { return uintValue; } }
        public uint AsU4 { set { uintValue = value; } get { return uintValue; } }
        public uint AsU8 { set { uintValue = value; } get { return uintValue; } }

        protected virtual void SetAsList() { }

        protected virtual void DoTypeChange() { }

        public object Value
        {
            get
            {
                switch (type)
                {
                    case ESECSsingleType.L:
                        return AsList;
                    case ESECSsingleType.Bi:
                        return AsBi;
                    case ESECSsingleType.Bo:
                        return AsBo;
                    case ESECSsingleType.A:
                        return AsA;
                    case ESECSsingleType.J:
                        return AsJ;
                    case ESECSsingleType.I1:
                        return AsI1;
                    case ESECSsingleType.I2:
                        return AsI2;
                    case ESECSsingleType.I4:
                        return AsI4;
                    case ESECSsingleType.I8:
                        return AsI8;
                    case ESECSsingleType.F4:
                        return AsF4; //待改善
                    case ESECSsingleType.F8:
                        return AsF8; //待改善
                    case ESECSsingleType.U1:
                        return AsU1;
                    case ESECSsingleType.U2:
                        return AsU2;
                    case ESECSsingleType.U4:
                        return AsU4;
                    case ESECSsingleType.U8:
                        return AsU8;
                    case ESECSsingleType.Spare:
                    default:
                        return new object();
                }
            }

            set
            {
                switch (type)
                {
                    case ESECSsingleType.L:
                        AsList = int.Parse(value.ToString());
                        break;
                    case ESECSsingleType.I1:
                    case ESECSsingleType.I2:
                    case ESECSsingleType.I4:
                    case ESECSsingleType.I8:
                        intValue = int.Parse(value.ToString());
                        break;
                    case ESECSsingleType.U1:
                    case ESECSsingleType.U2:
                    case ESECSsingleType.U4:
                    case ESECSsingleType.U8:
                        uintValue = uint.Parse(value.ToString());
                        break;
                    case ESECSsingleType.Bi:
                        binaryValue = byte.Parse(value.ToString());
                        break;
                    case ESECSsingleType.Bo:
                        boolValue = bool.Parse(value.ToString());
                        break;
                    case ESECSsingleType.A:
                    case ESECSsingleType.J:
                        stringValue = value.ToString();
                        break;
                    case ESECSsingleType.F4:
                    case ESECSsingleType.F8:
                        floatValue = float.Parse(value.ToString());
                        break; //待改善
                    case ESECSsingleType.Spare:
                    default:
                        break;
                }
            }
        }

        public void SetLine(SECSsingleLine inputLine)
        {
            isSpare = false;
            Type = inputLine.Type;

            switch (inputLine.Type)
            {
                case ESECSsingleType.L:
                    AsList = inputLine.AsList;
                    break;
                case ESECSsingleType.Bi:
                    binaryValue = inputLine.AsBi;
                    break;
                case ESECSsingleType.Bo:
                    boolValue = inputLine.AsBo;
                    break;
                case ESECSsingleType.A:
                    stringValue = inputLine.AsA;
                    break;
                case ESECSsingleType.J:
                    stringValue = inputLine.AsJ;
                    break;
                case ESECSsingleType.I1:
                    intValue = inputLine.AsI1;
                    break;
                case ESECSsingleType.I2:
                    intValue = inputLine.AsI2;
                    break;
                case ESECSsingleType.I4:
                    intValue = inputLine.AsI4;
                    break;
                case ESECSsingleType.I8:
                    intValue = inputLine.AsI8;
                    break;
                case ESECSsingleType.F4:
                    floatValue = inputLine.AsF4; //待改善
                    break;
                case ESECSsingleType.F8:
                    floatValue = inputLine.AsF8; //待改善
                    break;
                case ESECSsingleType.U1:
                    uintValue = inputLine.AsU1;
                    break;
                case ESECSsingleType.U2:
                    uintValue = inputLine.AsU2;
                    break;
                case ESECSsingleType.U4:
                    uintValue = inputLine.AsU4;
                    break;
                case ESECSsingleType.U8:
                    uintValue = inputLine.AsU8;
                    break;
                case ESECSsingleType.Spare:
                    isSpare = true;
                    break;
            }
        }

        public bool SECS_Equals(object obj)
        {
            SECSsingleLine item = obj as SECSsingleLine;
            bool isMatch = true;

            if (item == null)
            {
                return false;
            }

            if (type != ESECSsingleType.Spare && item.type != ESECSsingleType.Spare)
            {
                if (type != item.type) { isMatch = false; }
                switch (type)
                {
                    case ESECSsingleType.L:
                        if (AsList != item.AsList) { isMatch = false; }
                        break;
                    case ESECSsingleType.I1:
                    case ESECSsingleType.I2:
                    case ESECSsingleType.I4:
                    case ESECSsingleType.I8:
                        if (intValue != item.intValue) { isMatch = false; }
                        break;
                    case ESECSsingleType.U1:
                    case ESECSsingleType.U2:
                    case ESECSsingleType.U4:
                    case ESECSsingleType.U8:
                        if (uintValue != item.uintValue) { isMatch = false; }
                        break;
                    case ESECSsingleType.Bi:
                        if (binaryValue != item.binaryValue) { isMatch = false; }
                        break;
                    case ESECSsingleType.Bo:
                        if (boolValue != item.boolValue) { isMatch = false; }
                        break;
                    case ESECSsingleType.A:
                    case ESECSsingleType.J:
                        if (stringValue != item.stringValue) { isMatch = false; }
                        break;
                    case ESECSsingleType.F4:
                    case ESECSsingleType.F8:
                        if (floatValue != item.floatValue) { isMatch = false; }
                        break; //待改善
                    case ESECSsingleType.Spare:
                    default:
                        break;
                }
            }
            return isMatch;
        }

    }

    /// <summary>
    /// SECS行資訊的型態
    /// </summary>
    public enum ESECSsingleType : int
    {
        Error = -2,
        None = -1,

        L = 0,
        Bi = 1,
        Bo = 2,

        A = 5,
        J = 6,

        I1 = 11,
        I2 = 12,
        I4 = 14,
        I8 = 18,

        U1 = 21,
        U2 = 22,
        U4 = 24,
        U8 = 28,

        F4 = 34,
        F8 = 38,

        Spare = 100,
    }

}
