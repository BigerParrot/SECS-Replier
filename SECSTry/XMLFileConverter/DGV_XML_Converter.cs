using SECSLibs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SECSTry
{
    public static class DGV_XML_Converter
    {
        public static void DoSaveDGVDatas(DGVstruct dgvData, LinkTableStruct linkTable, bool isSaveManual = false)
        {
            /* Method 1
            if (!SECSsystem.IsFileBeenWorked) { return; }
            string filePath = string.Empty;

            if (string.IsNullOrEmpty(SECSsystem.SecsDGVfileName) && !isSaveManual)
            {
                if (!Directory.Exists(SECSsystem.SecsDGVfileFolder)) { Directory.CreateDirectory(SECSsystem.SecsDGVfileFolder); }

                SECSsystem.SecsDGVfileName = string.Format("Test_HSMS_{0}", DateTime.Now.ToString("yyyyMMdd"));
                filePath = string.Format("{0}\\{1}.xml", SECSsystem.SecsDGVfileFolder, SECSsystem.SecsDGVfileName);

                int x = 1;
                while (File.Exists(filePath))
                {
                    filePath = string.Format("{0}\\{1}_{2}.xml", SECSsystem.SecsDGVfileFolder, SECSsystem.SecsDGVfileName, x.ToString());
                    x++;
                }
            }
            else
            {
                filePath = SECSsystem.SecsDGVfileName;
            }

            if (SECSsystem.IsAutoSaveDGVfile && !string.IsNullOrEmpty(SECSsystem.SystemInitOpenFile) && isSaveManual)
            {
                filePath = SECSsystem.SystemInitOpenFile;
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }

            FileStream f = File.Create(filePath);
            f.Close();
            */

            // Method 2

            string filePath = string.Empty;

            if (!isSaveManual)
            {
                if (!string.IsNullOrEmpty(SECSsystem.SystemInitOpenFile) && SECSsystem.SystemInitOpenFile.Contains(SECSsystem.SecsDGVfileFolder))
                {
                    filePath = SECSsystem.SystemInitOpenFile;
                }
                else
                {
                    if (!Directory.Exists(SECSsystem.SecsDGVfileFolder)) { Directory.CreateDirectory(SECSsystem.SecsDGVfileFolder); }

                    SECSsystem.SecsDGVfileName = string.Format("Test_HSMS_{0}", DateTime.Now.ToString("yyyyMMdd"));
                    filePath = string.Format("{0}\\{1}.xml", SECSsystem.SecsDGVfileFolder, SECSsystem.SecsDGVfileName);

                    int x = 1;
                    while (File.Exists(filePath))
                    {
                        filePath = string.Format("{0}\\{1}_{2}.xml", SECSsystem.SecsDGVfileFolder, SECSsystem.SecsDGVfileName, x.ToString());
                        x++;
                    }
                }
            }
            else
            {
                filePath = SECSsystem.SystemInitOpenFile;
            }

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            FileStream f = File.Create(filePath);
            f.Close();

            //開始存成xml檔
            XmlDocument doc = new XmlDocument();
            XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = doc.CreateElement(string.Format("SECSReplier_v0_0"));

            #region --SECSmsg Datas--

            XmlElement root_Layer1 = doc.CreateElement(string.Format("SECSmsg_Datas"));
            for (int i = 0; i < dgvData.AllDatas.Count; i++)
            {
                XmlElement elayer1 = doc.CreateElement(string.Format("SECSItem{0}",i.ToString()));

                XmlElement index = doc.CreateElement(string.Format("Index"));
                index.InnerText = dgvData.AllDatas[i].Index.ToString();
                XmlElement state = doc.CreateElement(string.Format("State"));
                if (dgvData.AllDatas[i].IsReceive)
                {
                    state.InnerText = string.Format("Receive");
                }
                else if (dgvData.AllDatas[i].IsSend)
                {
                    state.InnerText = string.Format("Send");
                }
                else
                {
                    state.InnerText = string.Format("[error]");
                }
                XmlElement sf = doc.CreateElement("StreamFunction");
                sf.SetAttribute("Stream", dgvData.AllDatas[i].Stream.ToString());
                sf.SetAttribute("Function", dgvData.AllDatas[i].Function.ToString());
                sf.InnerText = string.Format("S{0}F{1}",dgvData.AllDatas[i].Stream.ToString(),dgvData.AllDatas[i].Function.ToString());
                XmlElement name = doc.CreateElement("Name");
                name.InnerText = dgvData.AllDatas[i].Name;
                XmlElement isUse = doc.CreateElement("IsUse");
                isUse.InnerText = dgvData.AllDatas[i].IsUse.ToString();
                XmlElement description = doc.CreateElement("Description");
                description.InnerText = dgvData.AllDatas[i].Description;

                XmlElement secsStruct = doc.CreateElement("SECS_Struct");
                DoSECSstructBuild(dgvData.AllDatas[i].SECSMsg, doc, ref secsStruct);

                elayer1.AppendChild(index);
                elayer1.AppendChild(state);
                elayer1.AppendChild(sf);
                elayer1.AppendChild(name);
                elayer1.AppendChild(isUse);
                elayer1.AppendChild(description);
                elayer1.AppendChild(secsStruct);

                root_Layer1.AppendChild(elayer1);
            }
            root.AppendChild(root_Layer1);

            #endregion --SECSmsg Datas--

            #region --SECS LinkTable--

            XmlElement root_Layer2 = doc.CreateElement(string.Format("SECS_LinkTable"));
            int count = 0;
            foreach (SingleLinkTableLine recLine in linkTable.linktable.Keys)
            {
                XmlElement elayer1 = doc.CreateElement(string.Format("Link{0}", count.ToString()));

                XmlElement index = doc.CreateElement(string.Format("Info"));
                index.SetAttribute("Function", recLine.Function.ToString());
                index.SetAttribute("Stream", recLine.Stream.ToString());
                index.SetAttribute("Name", recLine.Name);
                index.SetAttribute("Line", recLine.LineInList.ToString());
                
                int count1 = 0;
                foreach (SingleLinkTableLine senLine in linkTable.linktable[recLine].Values)
                {
                    XmlElement index2 = doc.CreateElement(string.Format("Link_Item{0}", count1.ToString()));

                    index2.SetAttribute("Function", senLine.Function.ToString());
                    index2.SetAttribute("Stream", senLine.Stream.ToString());
                    index2.SetAttribute("Name", senLine.Name);
                    index2.SetAttribute("Line", senLine.LineInList.ToString());

                    index.AppendChild(index2);
                    count1++;
                }

                elayer1.AppendChild(index);
                root_Layer2.AppendChild(elayer1);
                count++;
            }
            root.AppendChild(root_Layer2);

            #endregion --SECS LinkTable--

            doc.AppendChild(dec);
            doc.AppendChild(root);

            doc.Save(filePath);
        }

        public static DGVstruct GetDGVDatasByFile(string path)
        {
            DGVstruct dgvs = new DGVstruct();

            XmlTextReader reader = null;

            try
            {

                // Load the reader with the data file and ignore all white space nodes.
                if(Path.GetExtension(path) != ".xml") { return dgvs; }
                reader = new XmlTextReader(path);
                reader.WhitespaceHandling = WhitespaceHandling.None;

                // Parse the file and display each of the nodes.
                while (reader.Read())
                {
                    if (reader.NodeType.Equals(XmlNodeType.Element))
                    {
                        if (reader.Name.Contains("SECSItem"))
                        {
                            ROWstruct row = new ROWstruct();
                            while (reader.Read())
                            {
                                if (reader.NodeType.Equals(XmlNodeType.Element))
                                {
                                    switch (reader.Name)
                                    {
                                        case "Index":
                                            DoToInnerText(ref reader);
                                            row.Index = int.Parse(reader.Value);
                                            break;
                                        case "State":
                                            DoToInnerText(ref reader);
                                            string v = reader.Value.ToString();
                                            if (v.Contains("Receive")) { row.IsReceive = true; }
                                            if (v.Contains("Send")) { row.IsSend = true; }
                                            break;
                                        case "StreamFunction":
                                            if (reader.HasAttributes)
                                            {
                                                while (reader.MoveToNextAttribute())
                                                {
                                                    if (reader.Name.Equals("Stream")) { row.Stream = int.Parse(reader.Value.ToString());}
                                                    if (reader.Name.Equals("Function")) { row.Function = int.Parse(reader.Value.ToString()); }
                                                }
                                            }
                                            break;
                                        case "Name":
                                            DoToInnerText(ref reader);
                                            row.Name = reader.Value.ToString();
                                            break;
                                        case "IsUse":
                                            DoToInnerText(ref reader);
                                            row.IsUse = bool.Parse(reader.Value.ToString());
                                            break;
                                        case "Description":
                                            DoToInnerText(ref reader);
                                            row.Description = reader.Value.ToString();
                                            break;
                                        case "SECS_Struct":
                                            row.SECSMsg = DoBuildSECSMsg(row.Stream, row.Function, ref reader);
                                            break;
                                        default:
                                            break;
                                    }
                                }

                                if (reader.NodeType.Equals(XmlNodeType.EndElement) && reader.Name.Contains("SECSItem"))
                                {
                                    dgvs.AllDatas.Add(dgvs.AllDatas.Count, row);
                                    break;
                                }
                            }
                        }
                        
                    }
                }
            }

            finally
            {
                if (reader != null)
                    reader.Close();
            }
            return dgvs;
        }

        public static LinkTableStruct GetLinkTableByFile(string path)
        {
            LinkTableStruct linkTable = new LinkTableStruct();

            XmlTextReader reader = null;

            try
            {

                // Load the reader with the data file and ignore all white space nodes.
                reader = new XmlTextReader(path);
                reader.WhitespaceHandling = WhitespaceHandling.None;

                // Parse the file and display each of the nodes.
                while (reader.Read())
                {
                    if (reader.NodeType.Equals(XmlNodeType.Element))
                    {
                        if (reader.Name.Contains("SECS_LinkTable"))
                        {
                            while (reader.Read())
                            {
                                SingleLinkTableLine rec = null;
                                Dictionary<int, SingleLinkTableLine> rec_link = null;
                                if (reader.NodeType.Equals(XmlNodeType.Element))
                                {
                                    if (reader.Name.Contains("Link"))
                                    {
                                        rec = new SingleLinkTableLine();
                                        rec_link = new Dictionary<int,SingleLinkTableLine>();
                                        while (reader.Read())
                                        {
                                            if (reader.NodeType.Equals(XmlNodeType.Element))
                                            {
                                                if (reader.Name.Contains("Info") && reader.HasAttributes)
                                                {
                                                    while (reader.MoveToNextAttribute())
                                                    {
                                                        if (reader.Name.Equals("Stream")) { rec.Stream = int.Parse(reader.Value.ToString()); }
                                                        if (reader.Name.Equals("Function")) { rec.Function = int.Parse(reader.Value.ToString()); }
                                                        if (reader.Name.Equals("Name")) { rec.Name = reader.Value.ToString(); }
                                                        if (reader.Name.Equals("Line")) { rec.LineInList = int.Parse(reader.Value.ToString()); }
                                                    }
                                                }
                                                if (reader.Name.Contains("Link_Item") && reader.HasAttributes)
                                                {
                                                    SingleLinkTableLine sen_Item = new SingleLinkTableLine();
                                                    while (reader.MoveToNextAttribute())
                                                    {
                                                        if (reader.Name.Equals("Stream")) { sen_Item.Stream = int.Parse(reader.Value.ToString()); }
                                                        if (reader.Name.Equals("Function")) { sen_Item.Function = int.Parse(reader.Value.ToString()); }
                                                        if (reader.Name.Equals("Name")) { sen_Item.Name = reader.Value.ToString(); }
                                                        if (reader.Name.Equals("Line")) { sen_Item.LineInList = int.Parse(reader.Value.ToString()); }
                                                    }
                                                    rec_link.Add(rec_link.Count, sen_Item);
                                                }
                                            }

                                            if (reader.NodeType.Equals(XmlNodeType.EndElement) && reader.Name.Contains("Link"))
                                            {
                                                break;
                                            }
                                        }

                                        if (rec != null)
                                        {
                                            linkTable.linktable.Add(rec, rec_link);
                                        }
                                        rec = null;
                                        rec_link = null;
                                    }
                                }

                            }
                        }

                    }
                    if (reader.NodeType.Equals(XmlNodeType.EndElement) && reader.Name.Contains("SECS_LinkTable"))
                    {
                        break;
                    }
                }
            }
            catch
            {
                SECSReplierMessage.Label2Message("Link Table Fail", EMessageState.Error);
            }

            finally
            {
                if (reader != null)
                    reader.Close();
            }
            return linkTable;
        }

        private static void DoToInnerText(ref XmlTextReader reader)
        {
            while (!reader.NodeType.Equals(XmlNodeType.Text))
            {
                if (reader.NodeType.Equals(XmlNodeType.EndElement)) { return; }
                reader.Read();
            }
        }

        private static void DoSECSstructBuild(SECSmsg msg, XmlDocument doc, ref XmlElement element)
        {
            Dictionary<int, int> nowAddress = new Dictionary<int, int>();
            Dictionary<int, XmlElement> eleAddress = new Dictionary<int,XmlElement>();

            XmlElement root = doc.CreateElement("Root");
            root.SetAttribute("Type", msg.RootItem.Type.ToString());
            root.SetAttribute("Value", string.Format(msg.RootItem.Value.ToString()));
            nowAddress.Add(0, 0);
            eleAddress.Add(0, root);
            

            
            while (nowAddress.Count > 0)
            {
                bool isContinue = true;
                int layerLast = nowAddress.Count;
                int layerNow = 0;
                XmlElement item = null;

                if (msg.ToNextAddress(nowAddress))
                {
                    layerNow = nowAddress.Count;
                    SECSsingleLine line = new SECSsingleLine();
                    if (msg.GetLine(nowAddress, ref line))
                    {
                        item = doc.CreateElement(string.Format("Line{0}", nowAddress[nowAddress.Count - 1].ToString()));
                        item.SetAttribute("Type", line.Type.ToString());
                        item.SetAttribute("Value", string.Format(line.Value.ToString()));
                    }
                }
                else
                {
                    isContinue = false;
                }

                if (!isContinue)
                {
                    int count = eleAddress.Count;
                    for (int i = 1; i < count; i++)
                    {
                        if (eleAddress.Count <= 1) { break; }
                        eleAddress[eleAddress.Count - 2].AppendChild(eleAddress[eleAddress.Count - 1]);
                        eleAddress.Remove(eleAddress.Count - 1);
                    }
                    break;
                }

                if (layerNow > layerLast)
                {
                    eleAddress.Add(eleAddress.Count, item);
                }
                else
                {
                    if (layerNow < layerLast)
                    {
                        for (int i = layerNow; i < layerLast; i++)
                        {
                            eleAddress[eleAddress.Count - 2].AppendChild(eleAddress[eleAddress.Count - 1]);
                            eleAddress.Remove(eleAddress.Count - 1);
                        }
                    }

                    eleAddress[eleAddress.Count - 2].AppendChild(eleAddress[eleAddress.Count - 1]);
                    eleAddress.Remove(eleAddress.Count - 1);
                    eleAddress.Add(eleAddress.Count, item);
                }
            }

            element.AppendChild(root);
        }

        private static SECSmsg DoBuildSECSMsg(int s, int f, ref XmlTextReader reader)
        {
            SECSmsg msg = new SECSmsg();
            msg.Stream = s;
            msg.Function = f;
            bool isFinish = false;

            while (reader.Read() && !isFinish)
            {
                if (reader.NodeType.Equals(XmlNodeType.Element))
                {
                    if (reader.Name.Equals("Root"))
                    {
                        if (reader.HasAttributes)
                        {
                            while (reader.MoveToNextAttribute())
                            {
                                if (reader.Name.Equals("Type")) { msg.RootItem.Type = (ESECSsingleType)Enum.Parse(typeof(ESECSsingleType), reader.Value, true); }
                                if (reader.Name.Equals("Value")) { msg.RootItem.Value = reader.Value; }
                            }
                        }
                    }

                    if (reader.Name.Contains("Line"))
                    {
                        SECSsingleLine line = new SECSsingleLine();
                        if (reader.HasAttributes)
                        {
                            while (reader.MoveToNextAttribute())
                            {
                                if (reader.Name.Equals("Type")) { line.Type = (ESECSsingleType)Enum.Parse(typeof(ESECSsingleType), reader.Value, true); }
                                if (reader.Name.Equals("Value")) { line.Value = reader.Value; }
                            }
                            msg.SetLatestLine(line);
                        }
                    }
                }
                else if (reader.NodeType.Equals(XmlNodeType.EndElement) && reader.Name.Contains("SECS_Struct"))
                {
                    isFinish = true;
                }
            }

            return msg;
        }
    }
}
