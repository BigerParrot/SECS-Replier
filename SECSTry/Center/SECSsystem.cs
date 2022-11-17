using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SECSLibs;
using System.Net;
using System.IO;
using System.Xml;
using System.Threading;

namespace SECSTry
{
    public static class SECSsystem
    {
        public static event EventHandler<EventArgs_SystemParas> SECSsystem_SystemParas_Event;
        public static event EventHandler DoBeforeCloseAppEvent_1;
        public static event EventHandler<EventArgs_SingleString> DoWhileOpenAppEvent_1; //執行最新檔案讀取
        public static event EventHandler<EventArgs_SingleMessage> DoMessageBoxShowEvent;
        public static event EventHandler DoDisconnectEvent;
        public static event EventHandler DoRoleChangeEvent;
        public static event EventHandler DoOpenFileEvent;
        public static event EventHandler DoCloseFileEvent;
        public static event EventHandler DoSaveDGVFileEvent;
        public static event EventHandler DoRenewChangeEvent;

        private static string startupPath = System.IO.Directory.GetCurrentDirectory();

        private static string secsInitFolderPath = string.Empty;
        private static string secsDGVFolderPath = string.Empty;
        private static string secsInitFilePath = string.Empty;

        private static string systemInitOpenFile = string.Empty;

        private static string secsDGVfileFolder = string.Empty;
        private static string secsDGVfileName = string.Empty;
        private static bool isAutoSaveDGVfile = false;
        private static bool isFileBeenWorked = false;
        private static int logRenewNum = 200;

        private static SECSmsg secs_Clipboard = null;

        private static IPAddress hostIP = IPAddress.Parse("127.0.0.1");
        private static int port = 5000;
        private static EConnectState tcpIPConnectState = EConnectState.Disconnect;
        private static ESECSRole secsRole = ESECSRole.None;

        public static IPAddress HostIP { get { return hostIP; } set { hostIP = value; } }
        public static int Port { get { return port; } set { port = value; } }
        public static EConnectState SystemConnectState_TCPIP { get { return tcpIPConnectState; } set { tcpIPConnectState = value; } }
        public static string SecsDGVfileFolder { get { return secsDGVfileFolder; } set { if (!string.IsNullOrEmpty(value)) { secsDGVfileFolder = value; } else { secsDGVfileFolder = secsDGVFolderPath; } } }
        public static string SecsDGVfileName { get { return secsDGVfileName; } set { secsDGVfileName = value; } }
        public static string SystemInitOpenFile { get { return systemInitOpenFile; } set { systemInitOpenFile = value; } }
        public static bool IsAutoSaveDGVfile { get { return isAutoSaveDGVfile; } set { isAutoSaveDGVfile = value; } }
        public static bool IsFileBeenWorked { get { return isFileBeenWorked; } set { if (isFileBeenWorked != value) { DoOpenOrCloseFile(value); } isFileBeenWorked = value; } }
        public static bool IsFileBeenWorked_StateChange { set { isFileBeenWorked = value; } }
        public static SECSmsg SECS_Clipboard { get { return secs_Clipboard; } set { secs_Clipboard = value; } }
        public static int LogRenewNum { get { return logRenewNum; } set { if (logRenewNum != value) { logRenewNum = value; DoChangeReNewNum(); } } }
        public static ESECSRole SECSRole
        {
            get { return secsRole; }
            set
            {
                if (secsRole != value)
                {
                    secsRole = value;
                    DoRoleChange();
                }
                
            }
        }


        public static void InitSystemParameter()
        {
            secsInitFolderPath = string.Format("{0}\\SystemParas", startupPath);
            secsDGVFolderPath = string.Format("{0}\\DGVFiles", startupPath);
            secsInitFilePath = string.Format("{0}\\SysInit.xml", secsInitFolderPath);

            BuildSysInitFile(new EventArgs_SystemParas(), true);
            SetSystemInit(secsInitFilePath);
            
        }
        public static void BuildSysInitFile(EventArgs_SystemParas arg, bool isEmptyArg)
        {
            if (!isEmptyArg)
            {
                if (File.Exists(secsInitFilePath))
                {
                    File.Delete(secsInitFilePath);
                }
            }

            if (FindOrBuildFolder(secsInitFolderPath))
            {
                if (!File.Exists(secsInitFilePath))
                {
                    FileStream f = File.Create(secsInitFilePath);
                    f.Close();
                }
                else
                {
                    if (isEmptyArg) { return; }
                }
            }

            XmlDocument doc = new XmlDocument();
            XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = doc.CreateElement(string.Format("SystemInitFile"));
            root.InnerText = string.Format("{0}", DateTime.Now.ToString("yyyyMMdd"));

            #region --Connection Para--

            XmlElement connect = doc.CreateElement(string.Format("Connect"));

            XmlElement connect_AutoConnect = doc.CreateElement(string.Format("AutoConnect"));
            XmlElement connect_IP = doc.CreateElement(string.Format("IP"));
            XmlElement connect_Port = doc.CreateElement(string.Format("Port"));
            XmlElement connect_AsServer = doc.CreateElement(string.Format("AsServer"));
            XmlElement connect_AsClient = doc.CreateElement(string.Format("AsClient"));

            if (isEmptyArg)
            {
                connect_AutoConnect.InnerText = true.ToString();
                connect_IP.InnerText = string.Format("127.0.0.1");
                connect_Port.InnerText = string.Format("5000");
                connect_AsServer.InnerText = true.ToString();
                connect_AsClient.InnerText = false.ToString();
            }
            else
            {
                connect_AutoConnect.InnerText = arg.isAutoConnect.ToString();
                connect_IP.InnerText = arg.ip;
                connect_Port.InnerText = arg.port.ToString();
                connect_AsServer.InnerText = arg.asServer.ToString();
                connect_AsClient.InnerText = arg.asClient.ToString();
            }

            connect.AppendChild(connect_AutoConnect);
            connect.AppendChild(connect_IP);
            connect.AppendChild(connect_Port);
            connect.AppendChild(connect_AsServer);
            connect.AppendChild(connect_AsClient);

            #endregion --Connection Para--

            #region --Datas Para--

            XmlElement datas = doc.CreateElement(string.Format("Datas"));

            XmlElement datas_Preset = doc.CreateElement(string.Format("IsPreset1"));
            XmlElement datas_FolderPath = doc.CreateElement(string.Format("FolderPath1"));
            XmlElement datas_ReadLatest = doc.CreateElement(string.Format("ReadLatestFile"));
            XmlElement datas_AutoSave = doc.CreateElement(string.Format("AutoSave"));

            if (isEmptyArg)
            {
                datas_Preset.InnerText = true.ToString();
                datas_FolderPath.InnerText = string.Empty;
                datas_ReadLatest.InnerText = true.ToString();
                datas_AutoSave.InnerText = true.ToString();
            }
            else
            {
                datas_Preset.InnerText = arg.isPreset1.ToString();
                datas_FolderPath.InnerText = arg.folderPath1;
                datas_ReadLatest.InnerText = arg.isReadLatestFile.ToString();
                datas_AutoSave.InnerText = arg.isAutoSave.ToString();
            }

            datas.AppendChild(datas_Preset);
            datas.AppendChild(datas_FolderPath);
            datas.AppendChild(datas_ReadLatest);
            datas.AppendChild(datas_AutoSave);

            #endregion --Datas Para--

            #region --Logger Para--

            XmlElement logger = doc.CreateElement(string.Format("Logger"));

            XmlElement logger_Preset = doc.CreateElement(string.Format("IsPreset2"));
            XmlElement logger_FolderPath = doc.CreateElement(string.Format("FolderPath2"));
            XmlElement logger_KeepDays = doc.CreateElement(string.Format("FilesKeepDays"));

            if (isEmptyArg)
            {
                logger_Preset.InnerText = true.ToString();
                logger_FolderPath.InnerText = string.Empty;
                logger_KeepDays.InnerText = string.Format("30");
            }
            else
            {
                logger_Preset.InnerText = arg.isPreset2.ToString();
                logger_FolderPath.InnerText = arg.folderPath2;
                logger_KeepDays.InnerText = arg.keepDays.ToString();
            }

            logger.AppendChild(logger_Preset);
            logger.AppendChild(logger_FolderPath);
            logger.AppendChild(logger_KeepDays);

            #endregion --Logger Para--

            root.AppendChild(connect);
            root.AppendChild(datas);
            root.AppendChild(logger);

            doc.AppendChild(dec);
            doc.AppendChild(root);

            doc.Save(secsInitFilePath);
        }
        public static void DoBeforeCloseAppEvent()
        {
            if (DoBeforeCloseAppEvent_1 != null)
            {
                DoBeforeCloseAppEvent_1.Invoke(new object(), new EventArgs());
            }
        }

        public static void DoDisconnect()
        {
            if (DoDisconnectEvent != null && tcpIPConnectState != EConnectState.Disconnect)
            {
                DoDisconnectEvent.Invoke(new object(), new EventArgs());
            }
        }

        public static void DoMessageShow(string message, string titl = "")
        {
            if (DoMessageBoxShowEvent != null)
            {
                EventArgs_SingleMessage arg = new EventArgs_SingleMessage();
                arg.message = message;
                arg.tittle = titl;

                DoMessageBoxShowEvent.Invoke(new object(), arg);
            }
        }

        private static void DoRoleChange()
        {
            if (DoRoleChangeEvent != null)
            {
                DoRoleChangeEvent.Invoke(new object(), new EventArgs());
            }
        }

        private static bool FindOrBuildFolder(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return true;
        }
        private static void SetSystemInit(string filename)
        {
            XmlTextReader reader = null;
            EventArgs_SystemParas arg = new EventArgs_SystemParas();

            try
            {

                // Load the reader with the data file and ignore all white space nodes.
                reader = new XmlTextReader(filename);
                reader.WhitespaceHandling = WhitespaceHandling.None;

                // Parse the file and display each of the nodes.
                while (reader.Read())
                {
                    if (reader.NodeType.Equals(XmlNodeType.Element))
                    {
                        switch (reader.Name)
                        {
                            case "AutoConnect":
                                DoToInnerText(ref reader);
                                arg.isAutoConnect = bool.Parse(reader.Value);
                                break;
                            case "IP":
                                DoToInnerText(ref reader);
                                arg.ip = reader.Value.ToString();
                                IPAddress ipChoose;
                                bool isIP = IPAddress.TryParse(arg.ip, out ipChoose);
                                if (isIP) { hostIP = ipChoose; }
                                break;
                            case "Port":
                                DoToInnerText(ref reader);
                                arg.port = int.Parse(reader.Value.ToString());
                                port = arg.port;
                                break;
                            case "AsServer":
                                DoToInnerText(ref reader);
                                arg.asServer = bool.Parse(reader.Value);
                                if (arg.asServer) { SECSsystem.SECSRole = ESECSRole.Server; }
                                break;
                            case "AsClient":
                                DoToInnerText(ref reader);
                                arg.asClient = bool.Parse(reader.Value);
                                if (arg.asServer) { SECSsystem.SECSRole = ESECSRole.Client; }
                                break;
                            case "IsPreset1":
                                DoToInnerText(ref reader);
                                arg.isPreset1 = bool.Parse(reader.Value);
                                break;
                            case "FolderPath1":
                                DoToInnerText(ref reader);
                                arg.folderPath1 = reader.Value.ToString();
                                SecsDGVfileFolder = reader.Value.ToString();
                                break;
                            case "ReadLatestFile":
                                DoToInnerText(ref reader);
                                arg.isReadLatestFile = bool.Parse(reader.Value);
                                break;
                            case "AutoSave":
                                DoToInnerText(ref reader);
                                arg.isAutoSave = bool.Parse(reader.Value);
                                break;
                            case "IsPreset2":
                                DoToInnerText(ref reader);
                                arg.isPreset2 = bool.Parse(reader.Value);
                                break;
                            case "FolderPath2":
                                DoToInnerText(ref reader);
                                arg.folderPath2 = reader.Value.ToString();
                                break;
                            case "FilesKeepDays":
                                DoToInnerText(ref reader);
                                arg.keepDays = int.Parse(reader.Value.ToString());
                                break;
                            default:
                                break;
                        }
                    }
                }
            }

            finally
            {
                if (reader != null)
                    reader.Close();
                if (SECSsystem_SystemParas_Event != null)
                {
                    SECSsystem_SystemParas_Event.Invoke(new object(), arg);
                }

                Task.Factory.StartNew(()=>{
                    int x = 0;
                    while (x < 1000)
                    {
                        if (arg.isReadLatestFile)
                        {
                            DirectoryInfo directory = new DirectoryInfo(SecsDGVfileFolder);
                            FileInfo myFile = directory.GetFiles()
                                         .OrderByDescending(f => f.LastWriteTime)
                                         .First();
                            if (myFile.Extension.Equals(".xml") && DoWhileOpenAppEvent_1 != null)
                            {
                                EventArgs_SingleString arg1 = new EventArgs_SingleString();
                                arg1.theString = myFile.FullName;
                                systemInitOpenFile = myFile.FullName;
                                SECSReplierMessage.Label1Message(string.Format("Opened the File: {0}", myFile.FullName));
                                DoWhileOpenAppEvent_1.Invoke(new object(), arg1);
                                break;
                            }
                        }
                        Thread.Sleep(1);
                        x++;
                    }
                });
                
            }
        }
        private static void DoToInnerText(ref XmlTextReader reader)
        {
            while (!reader.NodeType.Equals(XmlNodeType.Text))
            {
                if (reader.NodeType.Equals(XmlNodeType.EndElement)) { return; }
                reader.Read();
            }
        }

        private static void DoOpenOrCloseFile(bool open_close)
        {
            if (open_close && DoOpenFileEvent != null)
            {
                DoOpenFileEvent.Invoke(new object(), new EventArgs());
            }
            else if (!open_close && DoCloseFileEvent != null)
            {
                DoCloseFileEvent.Invoke(new object(), new EventArgs());
            }
        }

        public static void DoSaveDGVFile()
        {
            if (DoSaveDGVFileEvent != null)
            {
                DoSaveDGVFileEvent.Invoke(new object(), new EventArgs());
            }
        }

        private static void DoChangeReNewNum()
        {
            if (DoRenewChangeEvent != null)
            {
                DoRenewChangeEvent.Invoke(new object(), new EventArgs());
            }
        }
    }

    public static class TimeoutSystem
    {
        public static event EventHandler DoTimerListChangeEvent;

        private static Dictionary<int, int> timeList = new Dictionary<int, int>();

        public static Dictionary<int, int> TimerList { get { return new Dictionary<int, int>(timeList); } set { timeList = new Dictionary<int, int>(value); DoTimerListChange(); } }

        private static void DoTimerListChange()
        {
            if (DoTimerListChangeEvent != null)
            {
                DoTimerListChangeEvent.Invoke(new object(), new EventArgs());
            }
        }
    
    }

    public static class SECSReplierMessage
    {
        public static event EventHandler<EventArgs_FormLabelMessage> DoLabel1Message_Event;
        public static event EventHandler<EventArgs_FormLabelMessage> DoLabel2Message_Event;
        public static event EventHandler<EventArgs_FormLabelMessage> DoLabelState_Event;

        public static void Label1Message(string message, EMessageState state = EMessageState.None)
        {
            if (DoLabel1Message_Event != null)
            {
                EventArgs_FormLabelMessage arg = new EventArgs_FormLabelMessage();
                arg.message = message;
                arg.state = state;

                DoLabel1Message_Event.Invoke(new object(), arg);
            }
        }

        public static void Label2Message(string message, EMessageState state = EMessageState.None)
        {
            if (DoLabel2Message_Event != null)
            {
                EventArgs_FormLabelMessage arg = new EventArgs_FormLabelMessage();
                arg.message = message;
                arg.state = state;

                DoLabel2Message_Event.Invoke(new object(), arg);
            }
        }

        public static void LabelStateMessage(string message, EMessageState state = EMessageState.None)
        {
            if (DoLabelState_Event != null)
            {
                EventArgs_FormLabelMessage arg = new EventArgs_FormLabelMessage();
                arg.message = message;
                arg.state = state;

                DoLabelState_Event.Invoke(new object(), arg);
            }
        }


    }

    public static class SECSsystemConnectionConfigure
    {
        public static event EventHandler ServerModeChangeEvent;
        private static EServerAllowMode  serverMode= EServerAllowMode.Single_First;

        public static EServerAllowMode ServerMode
        {
            get { return serverMode; }
            set
            {
                if (serverMode != value)
                {
                    serverMode = value;
                    if (ServerModeChangeEvent != null)
                    {
                        ServerModeChangeEvent.Invoke(new object(), new EventArgs());
                    }
                }
            }
        }
    }

}
