using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;
using DevExpress.XtraEditors;

namespace VinaLib
{
    public enum ProgressStatus { InProgress = 1, Complete = 2 };

    public class ProgressEventArgs : EventArgs
    {
        private ProgressStatus _status;

        public ProgressStatus Status
        {
            get
            {
                return _status;
            }
        }

        public ProgressEventArgs(ProgressStatus status)
        {
            _status = status;
        }
    }

    public delegate void ProgressEventHandler(object sender, ProgressEventArgs e);
    
    public class VinaProgressBar
    {
        private static Thread ProgressThread;
        private static guiProgressBar _guiProgressBar = null;
        public static string Text = "";

        public static void Start(string startString)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (_guiProgressBar == null)
                _guiProgressBar = new guiProgressBar();
            _guiProgressBar.Show(startString + "...");
            Application.DoEvents();
        }

        public static void Start()
        {
            VinaProgressBar.Start("");
        }

        public static void SetText(string strText)
        {
            if (_guiProgressBar != null)
                _guiProgressBar.Show(strText + "...");
        }

        public static void Close()
        {
            Cursor.Current = Cursors.Default;
            if (_guiProgressBar != null)
                _guiProgressBar.Hide();
        }
    }
}
