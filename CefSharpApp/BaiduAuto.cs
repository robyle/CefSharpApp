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
using CefSharp;
using System.IO;

namespace CefSharpApp
{
    public partial class BaiduAuto : Form
    {
        public BaiduAuto()
        {
            InitializeComponent();
            // Start the browser after initialize global component
            InitializeChromium();
            // Register an object in javascript named "cefCustomObject" with function of the CefCustomObject class :3
            chromeBrowser.RegisterJsObject("cefCustomObject", new CefCustomObject(chromeBrowser, this));
        }

        ChromiumWebBrowser webInsider = null;
        string[] kws = new string[] { };
        private void Form1_Load(object sender, EventArgs e)
        {
            //string path = "http://www.baidu.com";
            //webInsider = new ChromiumWebBrowser(path);
            //webInsider.Dock = DockStyle.Fill;
            //this.Controls.Add(webInsider);
            
            //chromeBrowser.ShowDevTools();
            kws = File.ReadAllLines("keyword.txt");

            //SearchKeyWord(kws);
        }

        private void SearchKeyWord(string[] ks)
        {
            for (int i = 0; i < ks.Length; i++)
            {
                chromeBrowser.Load("https://m.baidu.com");
                System.Threading.Thread.Sleep(1000);
                var script = "document.getElementById('index-kw').value='"+ks[i]+"'";//document.body.style.backgroundColor = 'red';";
                chromeBrowser.ExecuteScriptAsync(script);
                System.Threading.Thread.Sleep(1000);
                script = "document.getElementById('index-bn').click();";
                chromeBrowser.ExecuteScriptAsync(script);
                System.Threading.Thread.Sleep(2000);
                script = @"var goToWhere = function (where) {
            var me = this;
            me.site = [];
            me.sleep = me.sleep ? me.sleep : 16;
            me.fx = me.fx ? me.fx : 6;
            clearInterval(me.interval);
            var dh = document.documentElement.scrollHeight || document.body.scrollHeight;
            var height = !!where ? dh : 0;
            me.interval = setInterval(function () {
                var top = document.documentElement.scrollTop || document.body.scrollTop;
                var speed = (height - top) / me.fx;
                if (speed === me.site[0]) {
                    window.scrollTo(0, height);
                    clearInterval(me.interval);
                }
                window.scrollBy(0, speed);
                me.site.unshift(speed);
            }, me.sleep);
        };goToWhere(1);";
                chromeBrowser.ExecuteScriptAsync(script);
                System.Threading.Thread.Sleep(3000);
                //if (i>100)
                //{
                //    MessageBox.Show("超额限制,请联系设计人员进行修复！");
                //    break;
                //}
            }
        }

        public ChromiumWebBrowser chromeBrowser;
        /// <summary>
        /// https://ourcodeworld.com/articles/read/173/how-to-use-cefsharp-chromium-embedded-framework-csharp-in-a-winforms-application
        /// </summary>
        public void InitializeChromium_org()
        {
            CefSettings settings = new CefSettings();
            settings.BrowserSubprocessPath = @"x86\CefSharp.BrowserSubprocess.exe";
            // Initialize cef with the provided settings
            Cef.Initialize(settings);
            // Create a browser component
            chromeBrowser = new ChromiumWebBrowser("http://baidu.com");
            // Add it to the form and fill it to the form window.
            this.Controls.Add(chromeBrowser);
            chromeBrowser.Dock = DockStyle.Fill;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Cef.Shutdown();
        }

        public void InitializeChromium()
        {
            CefSettings settings = new CefSettings();
            settings.BrowserSubprocessPath = @"x86\CefSharp.BrowserSubprocess.exe";
            // Note that if you get an error or a white screen, you may be doing something wrong !
            // Try to load a local file that you're sure that exists and give the complete path instead to test
            // for example, replace page with a direct path instead :
            // String page = @"C:\Users\SDkCarlos\Desktop\afolder\index.html";

            String page = "https://m.baidu.com";//string.Format(@"{0}\HtmlSource\html\index.html", Application.StartupPath);
            //String page = @"C:\Users\SDkCarlos\Desktop\artyom-HOMEPAGE\index.html";

            //if (!File.Exists(page))
            //{
            //    MessageBox.Show("Error The html file doesn't exists : " + page);
            //}

            // Initialize cef with the provided settings
            Cef.Initialize(settings);
            // Create a browser component
            chromeBrowser = new ChromiumWebBrowser(page);

            // Add it to the form and fill it to the form window.
            scUD.Panel1.Controls.Add(chromeBrowser);
            chromeBrowser.Dock = DockStyle.Fill;

            // Allow the use of local resources in the browser
            BrowserSettings browserSettings = new BrowserSettings();
            browserSettings.FileAccessFromFileUrls = CefState.Enabled;
            browserSettings.UniversalAccessFromFileUrls = CefState.Enabled;
            chromeBrowser.BrowserSettings = browserSettings;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chromeBrowser.ShowDevTools();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            chromeBrowser.FrameLoadEnd += chromeBrowser_FrameLoadEnd;
            chromeBrowser.LoadHtml("百度", "https://www.baidu.com/");
        }

        void chromeBrowser_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var script = "document.getElementById('index-kw').value='2';document.getElementById('index-bn').click();";//document.body.style.backgroundColor = 'red';";
            chromeBrowser.ExecuteScriptAsync(script);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            chromeBrowser.Load("http://m.baidu.com");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (kws!=null&&kws.Length>0)
            {
                //button5.Enabled = false;
                SearchKeyWord(kws);
                //button5.Enabled = true;
            }
            else
            {
                //if (ofKeyWord.ShowDialog() == DialogResult.OK)
                //{
                //    kws = File.ReadAllLines(ofKeyWord.FileName);
                //}
            }
        }
    }
}
