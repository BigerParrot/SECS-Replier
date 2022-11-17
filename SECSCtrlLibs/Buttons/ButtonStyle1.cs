using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing.Design;

namespace SECSCtrlLibs
{
    public partial class ButtonStyle1 : UserControl
    {
        public event EventHandler ButtonStyle1_OnclickEvent;
        public event EventHandler ButtonStyle1_OffclickEvent;

        private EButtonStyle1 style = EButtonStyle1.None;
        private Color targetColor = Color.FromKnownColor(KnownColor.Control);
        private bool clickState = false;
        private bool warnChannel = false;
        private int speed = 3;
        private bool isOnOffClick = true;

        private bool isListDown = false;
        private ButtonStyle1Collection bS1_Collection = new ButtonStyle1Collection();
        private ContentAlignment listAlign = ContentAlignment.BottomCenter;
        private Size subButtonSize = new Size(100, 25);

        private UserControl U_listDown = new UserControl();
        private int totalHeight = 0;

        private System.Windows.Forms.Timer colorTimer = new System.Windows.Forms.Timer();
        private System.Windows.Forms.Timer listDownTimer = new System.Windows.Forms.Timer();

        //0.None
        private Color buttonNoneColor_KnownColor = Color.FromKnownColor(KnownColor.Control);

        //1.一般色彩按鈕
        private Color buttonOffColor_KnownColor = Color.FromKnownColor(KnownColor.Control);
        private Color buttonOnColor_KnownColor = Color.FromKnownColor(KnownColor.Control);
        private Color buttonEnterColor_KnownColor = Color.FromKnownColor(KnownColor.Control);

        //2.警示功能
        private Color buttonWarnningColor1_KnownColor = Color.FromKnownColor(KnownColor.Control);
        private Color buttonWarnningColor2_KnownColor = Color.FromKnownColor(KnownColor.Control);

        //3.鎖住
        private Color buttonLockedColor_KnownColor = Color.FromKnownColor(KnownColor.Control);

        [Category("ButtonList")]
        public bool IsListDown
        {
            get { return isListDown; }
            set
            {
                isListDown = value; 
            }
        }

        [Category("ButtonList")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor(typeof(ButtonStyle1CollectionEditor), typeof(UITypeEditor))]//属性编辑器
        public ButtonStyle1Collection BS1_Collection { get { return bS1_Collection; } set { bS1_Collection = value; } }

        [Category("ButtonList")]
        public ContentAlignment ListAlign { get { return listAlign; } set { listAlign = value; } }

        [Category("ButtonList")]
        public Size SubButtonSize { get { return subButtonSize; } set { subButtonSize = value; } }

        [Category("ButtonStyle")]
        public EButtonStyle1 bS_Style { get { return style; } set { style = value; DoAnimation(); } }

        [Category("ButtonStyle")]
        public String Text_Button { get { return buttonBase.Text; } set { buttonBase.Text = value; DoAnimation(); } }

        [Category("ButtonStyle")]
        public int Speed { get { return speed; } set { speed = value; DoAnimation(); } }

        [Category("ButtonStyle")]
        public bool IsOnOffClick { get { return isOnOffClick; } set { isOnOffClick = value; } }

        [Category("ButtonStyle")]
        public ImageList BtnImageList { get { return buttonBase.ImageList; } set { buttonBase.ImageList = value; DoAnimation(); } }

        [Category("ButtonStyle")]
        public int BtnImageIndex { get { return buttonBase.ImageIndex; } set { buttonBase.ImageIndex = value; DoAnimation(); } }

        [Category("ButtonColor None")]
        public Color ButtonNoneColor_KnownColor { get { return buttonNoneColor_KnownColor; } set { buttonNoneColor_KnownColor = value; DoAnimation(); } }

        [Category("ButtonColor 1")]
        public Color ButtonOffColor_KnownColor { get { return buttonOffColor_KnownColor; } set { buttonOffColor_KnownColor = value; DoAnimation(); } }
        
        [Category("ButtonColor 1")]
        public Color ButtonOnColor_KnownColor { get { return buttonOnColor_KnownColor; } set { buttonOnColor_KnownColor = value; DoAnimation(); } }
        
        [Category("ButtonColor 1")]
        public Color ButtonEnterColor_KnownColor { get { return buttonEnterColor_KnownColor; } set { buttonEnterColor_KnownColor = value; DoAnimation(); } }

        [Category("ButtonColor Warnning")]
        public Color ButtonWarnningColor1_KnownColor { get { return buttonWarnningColor1_KnownColor; } set { buttonWarnningColor1_KnownColor = value; DoAnimation(); } }

        [Category("ButtonColor Warnning")]
        public Color ButtonWarnningColor2_KnownColor { get { return buttonWarnningColor2_KnownColor; } set { buttonWarnningColor2_KnownColor = value; DoAnimation(); } }

        [Category("ButtonColor Locked")]
        public Color ButtonLockedColor_KnownColor { get { return buttonLockedColor_KnownColor; } set { buttonLockedColor_KnownColor = value; DoAnimation(); } }

        public ButtonStyle1()
        {
            InitializeComponent();
            DoAnimation();

            buttonBase.Click += buttonBase_Click;
            buttonBase.MouseEnter += buttonBase_MouseEnter;
            buttonBase.MouseLeave += buttonBase_MouseLeave;

            colorTimer.Interval = 1;
            colorTimer.Tick += colorTimer_Tick;

            listDownTimer.Interval = 1;
            listDownTimer.Tick += listDownTimer_Tick;
        }

        void listDownTimer_Tick(object sender, EventArgs e)
        {
            if (U_listDown.Height < totalHeight)
            {
                U_listDown.Height += 5;
            }
            else
            {
                U_listDown.Focus();
                listDownTimer.Stop();
            }
        }

        private void DoBuildListDown()
        {
            U_listDown.Controls.Clear();
            totalHeight = 0;

            Panel pl = new Panel();
            pl.Dock = DockStyle.Fill;

            U_listDown.Width = subButtonSize.Width;
            U_listDown.Height = 0;
            U_listDown.BackColor = Color.FromKnownColor(KnownColor.Black);

            switch (listAlign)
            {
                case ContentAlignment.BottomCenter:
                    U_listDown.Location = new Point(this.Location.X, this.Location.Y + this.Height);
                    break;
                case ContentAlignment.MiddleRight:
                    U_listDown.Location = new Point(this.Location.X + this.Width , this.Location.Y);
                    break;
                case ContentAlignment.BottomRight:
                    U_listDown.Location = new Point(this.Location.X + this.Width, this.Location.Y + this.Height);
                    break;
                default:
                    U_listDown.Location = new Point(this.Location.X, this.Location.Y + this.Height);
                    break;
            }
           
            foreach (var ob in bS1_Collection)
            {
                if (ob is ButtonStyle1)
                {
                    ((ButtonStyle1)ob).Margin = new Padding(0,0,0,0);
                    ((ButtonStyle1)ob).Height = subButtonSize.Height;
                    totalHeight += subButtonSize.Height;
                    ((ButtonStyle1)ob).Dock = DockStyle.Top;

                    pl.Controls.Add((ButtonStyle1)ob);
                    pl.Controls.SetChildIndex((ButtonStyle1)ob, 0);
                }
            }

            U_listDown.Controls.Add(pl);
            this.ParentForm.Controls.Add(U_listDown);
            U_listDown.BringToFront();
        }

        private void DoAnimation()
        {
            DoInitButton();
            switch (style)
            {
                case EButtonStyle1.None:
                    DoNone();
                    break;
                case EButtonStyle1.Normal:
                    DoNormal();
                    break;
                case EButtonStyle1.Warrning:
                    DoWarrning();
                    break;
                case EButtonStyle1.locked:
                    DoLocked();
                    break;
            }
        }

        private void DoInitButton()
        {
            buttonBase.Enabled = true;

        }

        private void DoNone()
        {
            buttonBase.BackColor = buttonNoneColor_KnownColor;
            targetColor = buttonNoneColor_KnownColor;
            ShowTextClear();
        }

        private void DoNormal()
        {
            buttonBase.BackColor = buttonOffColor_KnownColor;
            targetColor = buttonOffColor_KnownColor;
            if (!colorTimer.Enabled) { colorTimer.Start(); }
        }

        private void DoWarrning()
        {
            buttonBase.BackColor = buttonWarnningColor1_KnownColor;
            targetColor = buttonWarnningColor2_KnownColor;
            if (!colorTimer.Enabled) { colorTimer.Start(); }
        }

        private void DoLocked()
        {
            buttonBase.Enabled = false;
            buttonBase.BackColor = buttonLockedColor_KnownColor;
            targetColor = buttonLockedColor_KnownColor;
            ShowTextClear();
        }

        private void colorTimer_Tick(object sender, EventArgs e)
        {
            bool isChange = false;
            if (!Color.Equals(buttonBase.BackColor,targetColor.ToArgb()))
            {
                int cR = buttonBase.BackColor.R;
                int cG = buttonBase.BackColor.G;
                int cB = buttonBase.BackColor.B;

                if (cR > targetColor.R + speed) { cR -= speed; isChange = true; } else if (cR < targetColor.R - speed) { cR += speed; isChange = true; } else { cR = targetColor.R; }
                if (cG > targetColor.G + speed) { cG -= speed; isChange = true; } else if (cG < targetColor.G - speed) { cG += speed; isChange = true; } else { cG = targetColor.G; }
                if (cB > targetColor.B + speed) { cB -= speed; isChange = true; } else if (cB < targetColor.B - speed) { cB += speed; isChange = true; } else { cB = targetColor.B; }

                buttonBase.BackColor = Color.FromArgb(cR, cG, cB);
                ShowTextSmooth();
            }
            if(!isChange && style != EButtonStyle1.Warrning)
            {
                colorTimer.Stop();
            }
            else if (style == EButtonStyle1.Warrning)
            {
                if (!isChange)
                {
                    if (warnChannel) 
                    { targetColor = buttonWarnningColor1_KnownColor; warnChannel = false; }
                    else
                    { targetColor = buttonWarnningColor2_KnownColor; warnChannel = true; }
                }
            }
        }

        private void buttonBase_MouseLeave(object sender, EventArgs e)
        {
            if (style != EButtonStyle1.Normal) { return; }
            if (!clickState)
            {
                targetColor = buttonOffColor_KnownColor;
                if (isListDown)
                {
                    U_listDown.Height = 0;
                }
            }
            if (!colorTimer.Enabled) { colorTimer.Start(); }
        }

        private void buttonBase_MouseEnter(object sender, EventArgs e)
        {
            if (style != EButtonStyle1.Normal) { return; }
            if (!clickState)
            {
                targetColor = buttonEnterColor_KnownColor;
                if (isListDown)
                {
                    DoBuildListDown();
                    listDownTimer.Start();
                }
            }
            if (!colorTimer.Enabled) { colorTimer.Start(); }
        }

        private void buttonBase_Click(object sender, EventArgs e)
        {
            clickState = !clickState;
            
            switch (style)
            {
                case EButtonStyle1.None:
                case EButtonStyle1.Warrning:
                    if (ButtonStyle1_OnclickEvent != null)
                    {
                        colorTimer.Stop();  //異常已排除
                        ButtonStyle1_OnclickEvent.Invoke(this, new EventArgs());
                        colorTimer.Start(); //異常已排除
                    }
                    break;
                case EButtonStyle1.Normal:
                    if (ButtonStyle1_OnclickEvent != null && clickState)
                    {
                        ButtonStyle1_OnclickEvent.Invoke(this, new EventArgs());
                    }
                    else if (ButtonStyle1_OffclickEvent != null && !clickState)
                    {
                        ButtonStyle1_OffclickEvent.Invoke(this, new EventArgs());
                    }

                    if (!isOnOffClick)
                    {
                        if (clickState) { clickState = false; }
                    }

                    break;
            }
            if (style != EButtonStyle1.Normal) { return; }

            if (clickState)
            {
                targetColor = buttonOnColor_KnownColor;
            }
            else
            {
                targetColor = buttonOffColor_KnownColor;
            }

            if (!colorTimer.Enabled) { colorTimer.Start(); }
        }

        private void ShowTextClear()
        {
            int r = buttonBase.BackColor.R;
            int g = buttonBase.BackColor.G;
            int b = buttonBase.BackColor.B;

            if (r + g + b > 380)
            {
                buttonBase.ForeColor = Color.FromKnownColor(KnownColor.Black);
            }
            else
            {
                buttonBase.ForeColor = Color.FromKnownColor(KnownColor.White);
            }
        }

        private void ShowTextSmooth()
        {
            int r = buttonBase.BackColor.R;
            int g = buttonBase.BackColor.G;
            int b = buttonBase.BackColor.B;

            buttonBase.ForeColor = Color.FromArgb(255 - r, 255 - g, 255 - b);
        }
    }

    public class ButtonStyle1CollectionEditor : CollectionEditor
    {
        public ButtonStyle1CollectionEditor(Type tp)
            : base(tp)
        { }

        /// <summary>
        /// 限制一次选一个实例
        /// </summary>
        /// <returns></returns>
        protected override bool CanSelectMultipleInstances()
        {
            return false;
        }

        /// <summary>
        /// 指定创建的对象类型
        /// </summary>
        /// <returns></returns>
        protected override Type CreateCollectionItemType()
        {
            return typeof(ButtonStyle1);
        }

        protected override object CreateInstance(Type itemType)
        {
            //创建一个实例
            ButtonStyle1 o = (ButtonStyle1)itemType.Assembly.CreateInstance(itemType.FullName);

            IDesignerHost host = (IDesignerHost)this.GetService(typeof(IDesignerHost));
            host.Container.Add(o);//重要！自动生成组件的设计时代码！

            //或者：
            //this.Context.Container.Add(o);//重要！自动生成组件的设计时代码！

            return o;
        }

        protected override void DestroyInstance(object instance)
        {
            base.DestroyInstance(instance);//重要！自动删除组件的设计时代码！
        }
    }

    public class ButtonStyle1Collection : BaseCollection, IList
    {
        private ArrayList listHere;

        public ButtonStyle1Collection()
        {
            listHere = new ArrayList();
        }

        protected override ArrayList List
        {
            get{ return (ArrayList)listHere; }
        }

        #region IList Members

        public int Add(object value)
        {
            return this.List.Add(value);
        }

        public void Clear()
        {
            this.List.Clear();
        }

        public bool Contains(object value)
        {
            return this.List.Contains(value);
        }

        public int IndexOf(object value)
        {
            return this.List.IndexOf(value);
        }

        public void Insert(int index, object value)
        {
            this.List.Insert(index, value);
        }

        public bool IsFixedSize
        {
            get { return this.List.IsFixedSize; }
        }

        public void Remove(object value)
        {
            this.List.Remove(value);
        }

        public void RemoveAt(int index)
        {
            this.List.RemoveAt(index);
        }

        public object this[int index]
        {
            get
            {
                return List[index];
            }
            set
            {
                List[index] = value;
            }
        }

        #endregion
    }

    public enum EButtonStyle1 : int
    {
        None,

        Normal,
        Warrning,
        locked,
    }
}
