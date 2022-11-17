using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace SECSLibs
{
    public class SECSTimer
    {
        public event EventHandler<EventArgs_Timeout> DoTimeoutEvent;

        private Dictionary<int, List<Timeouts>> timers = new Dictionary<int, List<Timeouts>>();
        private Dictionary<int, int> timeList = new Dictionary<int,int>();

        public List<Timeouts> T1s { get { return timers[0]; } }

        public List<Timeouts> T2s { get { return timers[1]; } }

        public List<Timeouts> T3s { get { return timers[2]; } }

        public List<Timeouts> T4s { get { return timers[3]; } }

        public List<Timeouts> T5s { get { return timers[4]; } }

        public List<Timeouts> T6s { get { return timers[5]; } }

        public List<Timeouts> T7s { get { return timers[6]; } }

        public List<Timeouts> T8s { get { return timers[7]; } }

        public Dictionary<int, int> TimeList { set { timeList = value; ChangeAllValue(); } get { return timeList; } }

        public SECSTimer()
        {
            for (int i = 0; i < 8; i++) { timers.Add(i, new List<Timeouts>()); }
        }

        public SECSTimer(Dictionary<int, int> timeList)
        {
            for (int i = 0; i < 8; i++) { timers.Add(i, new List<Timeouts>()); }
            this.timeList = timeList;
        }

        public Timeouts AddTimer(ETimeout sty, byte[] id = null)
        {
            Timeouts timo = new Timeouts();

            if (id != null) { Array.Copy(id, timo.ByteID_4, id.Length); }
            timo.Value = timeList[(int)sty - 1];
            timo.Style = sty;
            timo.DoTimeoutEvent += timo_DoTimeoutEvent;
            timo.DoDequeueEvent += timo_DoRemoveEvent;

            timers[(int)sty - 1].Add(timo);

            timo.Start();

            return timo;
        }

        public void FinishTimer(ETimeout sty, byte[] id)
        {
            foreach (Timeouts timo in timers[(int)sty - 1])
            {
                if(timo == null) { continue; }
                if (timo.ByteID_4.SequenceEqual(id))
                {
                    timo.Stop();
                }
            }
        }

        void timo_DoRemoveEvent(object sender, EventArgs e)
        {
            Timeouts sTimeout = (Timeouts)sender;

            if (timers[(int)sTimeout.Style - 1].Contains(sTimeout))
            {
                timers[(int)sTimeout.Style - 1].Remove(sTimeout);
            }
        }

        private void ChangeAllValue()
        {
            foreach (List<Timeouts> ts in timers.Values)
            {
                foreach (Timeouts tout in ts)
                {
                    tout.Value = timeList[(int)tout.Style - 1];
                }
            }
        }

        void timo_DoTimeoutEvent(object sender, EventArgs_Timeout e)
        {
            if (DoTimeoutEvent != null)
            {
                DoTimeoutEvent.Invoke(sender, e);
            }
        }
    }

    public class EventArgs_Timeout : EventArgs
    {
        public ETimeout style = ETimeout.None;
        public byte[] T7_using= new byte[]{};
        public int tims = 0;
    }

    public class Timeouts
    {
        public event EventHandler DoDequeueEvent;
        public event EventHandler<EventArgs_Timeout> DoTimeoutEvent;

        private bool IsEnd = false;
        private bool isCounting = false;

        private int Tvalue = 0;
        private ETimeout style = ETimeout.None;
        private byte[] byteID = new byte[4];
        public int Value { set { Tvalue = value; } get { return Tvalue; } }

        public ETimeout Style { set { style = value; } get { return style; } }

        public byte[] ByteID_4 { set { byteID = value; } get { return byteID; } }

        public bool IsCounting { set { isCounting = value; } get { return isCounting; } }

        public Timeouts(){ }

        public bool IsEventBinded()
        {
            if (DoTimeoutEvent == null && DoDequeueEvent == null) { return false; } else { return true; }
        }

        public void Start()
        {
            IsEnd = false;
            isCounting = true;
            int count = Tvalue;
            Task.Factory.StartNew(()=>{
                Thread.Sleep(count * 1000);
                if (!IsEnd && DoTimeoutEvent != null)
                {
                    EventArgs_Timeout arg = new EventArgs_Timeout();
                    arg.style = this.style;
                    arg.tims = count;
                    if (this.style == ETimeout.T7) { arg.T7_using = ByteID_4; }
                    DoTimeoutEvent.Invoke(this, arg);
                }
                isCounting = false;
                if (DoDequeueEvent != null) { DoDequeueEvent(this, new EventArgs()); }
            });
            
        }

        public void Stop()
        {
            IsEnd = true;
        }
    }

    public enum ETimeout : int
    {
        None = 0,
        T1 = 1,
        T2 = 2,
        T3 = 3,
        T4 = 4,
        T5 = 5,
        T6 = 6,
        T7 = 7,
        T8 = 8,
    }
}
