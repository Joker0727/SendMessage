using System;
using System.Windows.Forms;
using CopyDataStruct;

namespace Receiver
{
    public partial class frmReceiver : Form
    {
        const int WM_COPYDATA = 0x004A;
        public frmReceiver()
        {
            InitializeComponent();
        }

        protected override void DefWndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_COPYDATA:
                    COPYDATASTRUCT cds = new COPYDATASTRUCT();
                    Type t = cds.GetType();
                    cds = (COPYDATASTRUCT)m.GetLParam(t);
                    string strResult = cds.dwData.ToString() + ":" + cds.lpData;
                    lsvMsgList.Items.Add(strResult);
                    break;
                default:
                    base.DefWndProc(ref m);
                    break;
            }
        }
    }
}

