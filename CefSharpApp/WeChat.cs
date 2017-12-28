using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CefSharpApp
{
    public partial class WeChat : Form
    {
        public ChromiumWebBrowser browser1;
        public WeChat()
        {
            InitializeComponent();
            InitBrowser1();
        }
        public void InitBrowser1()
        {
            CefSettings settings = new CefSettings();
            settings.BrowserSubprocessPath = @"x86\CefSharp.BrowserSubprocess.exe";
            Cef.Initialize(settings);

            browser1 = new ChromiumWebBrowser("wx.qq.com");
            browser1.Dock = DockStyle.Fill;
            this.Controls.Add(browser1);
        }
    }
}
