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
    public partial class TwoWebBrowser : Form
    {
        public ChromiumWebBrowser browser1;
        public ChromiumWebBrowser browser2;
        public void InitBrowser1()
        {
            CefSettings settings = new CefSettings();
            settings.BrowserSubprocessPath = @"x86\CefSharp.BrowserSubprocess.exe";
            Cef.Initialize(settings);

            browser1 = new ChromiumWebBrowser("www.baidu.com");
            browser1.Dock = DockStyle.Fill;
            splitContainer1.Panel1.Controls.Add(browser1);
        }
        public void InitBrowser2()
        {
            //Cef.Initialize(new CefSettings());
            browser2 = new ChromiumWebBrowser("www.baidu.com");
            browser2.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(browser2);
        }
        public TwoWebBrowser()
        {
            InitializeComponent();
            InitBrowser1();
            InitBrowser2();
        }
    }
}
