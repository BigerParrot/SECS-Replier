using SECSLibs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SECSTry
{
    public static class LinkTableCenter
    {
        public static event EventHandler DoDGVListChangeEvent;
        public static event EventHandler ReNewLinkTableDGVEvent;
        public static event EventHandler ReNewLinkTableDGV_SendEvent;

        private static Dictionary<int, SECSItem> RecList = new Dictionary<int, SECSItem>();
        private static Dictionary<int, SECSItem> SenList = new Dictionary<int, SECSItem>();
        private static Dictionary<SECSItem, List<SECSItem>> linkTable = new Dictionary<SECSItem,List<SECSItem>>();

        public static Dictionary<int, SECSItem> RecList_SetGet { set { RecList = value; } get { return RecList; } }
        public static Dictionary<int, SECSItem> SenList_SetGet { set { SenList = value; } get { return SenList; } }
        public static Dictionary<SECSItem, List<SECSItem>> LinkTable_Get { get { return linkTable; } }

        public static void DoDGVListChange()
        {
            if (DoDGVListChangeEvent != null)
            {
                DoDGVListChangeEvent.Invoke(new object(), new EventArgs());
            }
        }

        public static void Init_LinkTable_Receives()
        {
            foreach (SECSItem item in RecList.Values)
            {
                if (!linkTable.ContainsKey(item))
                {
                    linkTable.Add(item, new List<SECSItem>());
                }
            }

            List<SECSItem> beAbortList = new List<SECSItem>();
            foreach (SECSItem item in linkTable.Keys)
            {
                if (!RecList.ContainsValue(item))
                {
                    beAbortList.Add(item);
                }
            }

            foreach (SECSItem item in beAbortList)
            {
                linkTable.Remove(item);
            }

            beAbortList.Clear();

            ReNewLinkTableDGV();
        }

        public static void Init_LinkTable_Send()
        {
            //增加LinkTable的Send數量
            foreach (SECSItem item in SenList.Values)
            {
                if (!linkTable.ContainsKey(item))
                {
                    linkTable.Add(item, new List<SECSItem>());
                }
            }

            //去除LinkTable中已被刪除的Send數量
            List<SECSItem> abort_SECSItems = new List<SECSItem>();
            foreach (SECSItem item in linkTable.Keys)
            {
                if (!SenList.ContainsValue(item))
                {
                    abort_SECSItems.Add(item);
                }
            }
            foreach (SECSItem item in abort_SECSItems)
            {
                linkTable.Remove(item);
            }
            abort_SECSItems.Clear();

            ReNewLinkTableDGV();
        }



        public static void Clear_LinkTable()
        {
            linkTable.Clear();
            ReNewLinkTableDGV();
        }

        public static void AddSend_to_Receive(SECSItem currentItem, SECSItem sendItem)
        {
            if (linkTable.ContainsKey(currentItem))
            {
                if (!linkTable[currentItem].Contains(sendItem))
                {
                    linkTable[currentItem].Add(sendItem);
                    ReNewLinkTableDGV_Send();
                }
            }
        }

        public static void RemoveSend_from_Receive(SECSItem ItemRec, SECSItem ItemRemove)
        {
            if (ItemRec != null && ItemRemove != null)
            {
                if (linkTable.ContainsKey(ItemRec))
                {
                    if (linkTable[ItemRec].Contains(ItemRemove))
                    {
                        linkTable[ItemRec].Remove(ItemRemove);
                        ReNewLinkTableDGV_Send();
                    }
                }
            }
        }

        private static void ReNewLinkTableDGV()
        {
            if (ReNewLinkTableDGVEvent != null)
            {
                ReNewLinkTableDGVEvent.Invoke(new object(), new EventArgs());
            }
        }

        public static void ReNewLinkTableDGV_Send()
        {
            if (ReNewLinkTableDGV_SendEvent != null)
            {
                ReNewLinkTableDGV_SendEvent.Invoke(new object(), new EventArgs());
            }
        }

        public static void OpenFileByPath_LinkTable(string path)
        {
            LinkTableStruct linking = DGV_XML_Converter.GetLinkTableByFile(path);
            linkTable.Clear();

            foreach (SingleLinkTableLine rec_Line in linking.linktable.Keys)
            {
                SECSItem nowRec = FindSECSItem_By_SingleLinkTableLine(rec_Line, true);
                linkTable.Add(nowRec, new List<SECSItem>());
                foreach (SingleLinkTableLine sen_Line in linking.linktable[rec_Line].Values)
                {
                    linkTable[nowRec].Add(FindSECSItem_By_SingleLinkTableLine(sen_Line, false));
                }
            }
        }

        private static SECSItem FindSECSItem_By_SingleLinkTableLine(SingleLinkTableLine line, bool isRec)
        {
            if (isRec)
            {
                List<SECSItem> match1 = new List<SECSItem>();
                foreach (SECSItem item in RecList.Values)
                {
                    if (item.Name.Equals(line.Name) && item.Stream.Equals(line.Stream) && item.Function.Equals(line.Function))
                    {
                        match1.Add(item);
                    }
                }
                if (match1.Count == 1)
                {
                    return match1[0];
                }
                else
                {
                    foreach (SECSItem item in match1)
                    {
                        int myKey = RecList.FirstOrDefault(x => x.Value == item).Key;
                        if (myKey == line.LineInList)
                        {
                            return item;
                        }
                    }
                }
            }
            else
            {
                List<SECSItem> match1 = new List<SECSItem>();
                foreach (SECSItem item in SenList.Values)
                {
                    if (item.Name.Equals(line.Name) && item.Stream.Equals(line.Stream) && item.Function.Equals(line.Function))
                    {
                        match1.Add(item);
                    }
                }
                if (match1.Count == 1)
                {
                    return match1[0];
                }
                else
                {
                    foreach (SECSItem item in match1)
                    {
                        int myKey = SenList.FirstOrDefault(x => x.Value == item).Key;
                        if (myKey == line.LineInList)
                        {
                            return item;
                        }
                    }
                }
            }

            return null;
        }

        public static List<SECSmsg> GetDatasSend_By_ReceivedMsg(SECSmsg recMsg)
        {
            List<SECSmsg> backDatas = new List<SECSmsg>();

            try
            {
                foreach (SECSItem item in linkTable.Keys)
                {
                    if (item.Stream == recMsg.Stream && item.Function == recMsg.Function)
                    {
                        if ((item as SECSmsg).SECS_Equals(recMsg) && item.IsUsed)
                        {
                            foreach (SECSItem putin in linkTable[item])
                            {
                                SECSmsg toSendMsg = putin.Clone();
                                if (toSendMsg.Function % 2 == 0) //自動判定回傳訊號類型
                                { 
                                    toSendMsg.IsWaitBit = false; 
                                    toSendMsg.AsSecondaryMessage = true;
                                }
                                else
                                {
                                    toSendMsg.IsWaitBit = true;
                                    toSendMsg.AsPrimaryMessage = true;
                                }
                                if (putin.IsUsed) { backDatas.Add(toSendMsg); Thread.Sleep(3); }
                            }
                            break;
                        }
                    }
                }
            }
            catch(Exception err)
            {
            
            }

            return backDatas;
        }
    }

    public static class LinkTableConverter
    {
        public static LinkTableStruct GetLinkTableStruct(Dictionary<SECSItem, List<SECSItem>> linktable, Dictionary<int, SECSItem> recList, Dictionary<int, SECSItem> senList)
        {
            LinkTableStruct str = new LinkTableStruct();
            foreach (SECSItem item_Rec in linktable.Keys)
            {
                if (recList.ContainsValue(item_Rec))
                {
                    int myKey = recList.FirstOrDefault(x => x.Value == item_Rec).Key;
                    SingleLinkTableLine rec = new SingleLinkTableLine(myKey, item_Rec);
                    str.linktable.Add(rec, new Dictionary<int,SingleLinkTableLine>());

                    foreach (SECSItem item_sen in linktable[item_Rec])
                    {
                        if (senList.ContainsValue(item_sen))
                        {
                            int myKey2 = senList.FirstOrDefault(x => x.Value == item_sen).Key;
                            SingleLinkTableLine sen = new SingleLinkTableLine(myKey2, item_sen);
                            str.linktable[rec].Add(str.linktable[rec].Count, sen);
                        }
                    }
                }
            }

            return str;
        }
    }

    public class LinkTableStruct
    {
        public Dictionary<SingleLinkTableLine, Dictionary<int, SingleLinkTableLine>> linktable = new Dictionary<SingleLinkTableLine,Dictionary<int,SingleLinkTableLine>>();
    }

    public class SingleLinkTableLine
    {
        private int lineInList = -1;
        private string name = string.Empty;
        private int stream = -1;
        private int function = -1;

        public int LineInList { get { return lineInList; } set { lineInList = value; } }

        public string Name { get { return name; } set { name = value; } }

        public int Stream { get { return stream; } set { stream = value; } }

        public int Function { get { return function; } set { function = value; } }

        public SingleLinkTableLine() { }

        public SingleLinkTableLine(int line, SECSItem item)
        {
            lineInList = line;
            name = item.Name;
            stream = item.Stream;
            function = item.Function;
        }

        public void BuidFrom_SECSItem(int line, SECSItem item)
        {
            lineInList = line;
            name = item.Name;
            stream = item.Stream;
            function = item.Function;
        }
    }
}
