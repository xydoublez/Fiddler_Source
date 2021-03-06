namespace Fiddler
{
    using Microsoft.Win32;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Globalization;
    using System.IO;
    using System.Net;
    using System.Runtime.InteropServices;
    using System.Security.Principal;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading;
    using System.Windows.Forms;
    using Xceed.FileSystem;
    using Xceed.Zip;

    public class frmViewer : Form
    {
        private Point _ptContextPopup;
        private Button btnDecodeResponse;
        private Button btnSquish;
        private Button btnTamperSendClient;
        private Button btnTamperSendServer;
        private ComboBox cbxLoadFrom;
        private ColumnHeader colComments;
        private ColumnHeader colContentType;
        private ColumnHeader colCustom;
        private ColumnHeader colExpires;
        private ColumnHeader colHost;
        private ColumnHeader colID;
        private ColumnHeader colProcess;
        private ColumnHeader colProtocol;
        private ColumnHeader colRequest;
        private ColumnHeader colResponseSize;
        private ColumnHeader colStatus;
        private IContainer components;
        private OpenFileDialog dlgLoadZip;
        private SaveFileDialog dlgSaveBinary;
        private SaveFileDialog dlgSaveZip;
        private Form frmFloatingInspectors;
        public ImageList imglSessionIcons;
        public ImageList imglToolbar;
        private Label lblBreakpoint;
        private Label lblSessions;
        public SessionListView lvSessions;
        private MenuItem menuItem15;
        private MenuItem menuItem19;
        private MenuItem menuItem20;
        private MenuItem menuItem21;
        private MenuItem menuItem26;
        private MenuItem menuItem28;
        private MenuItem menuItem32;
        private MenuItem menuItem35;
        private MenuItem menuItem7;
        private MenuItem miContextMarkSplit;
        private MenuItem miContextSaveSplitter;
        private MenuItem miEditCopyFullSummary;
        private MenuItem miEditCopyHeaders;
        private MenuItem miEditCopySession;
        private MenuItem miEditCopyTerseSummary;
        private MenuItem miEditCopyUrl;
        private MenuItem miEditDivider;
        private MenuItem miEditFind;
        private MenuItem miEditMarkBlue;
        private MenuItem miEditMarkGold;
        private MenuItem miEditMarkGreen;
        private MenuItem miEditMarkOrange;
        private MenuItem miEditMarkPurple;
        private MenuItem miEditMarkRed;
        private MenuItem miEditMarkUnmark;
        private MenuItem miEditRemoveAll;
        private MenuItem miEditRemoveSelected;
        private MenuItem miEditRemoveUnselected;
        private MenuItem miEditSelectAll;
        private MenuItem miEditSplit1;
        private MenuItem miFileExit;
        private MenuItem miFileLoad;
        private MenuItem miFileProperties;
        private MenuItem miFileSaveAllSessions;
        private MenuItem miFileSaveHeaders;
        private MenuItem miFileSaveRequest;
        private MenuItem miFileSaveRequestBody;
        private MenuItem miFileSaveResponse;
        private MenuItem miFileSaveResponseBody;
        private MenuItem miFileSaveSession;
        private MenuItem miFileSaveZip;
        private MenuItem miInspectorProperties;
        public ToolStripMenuItem miNotifyCapturing;
        private ToolStripMenuItem miNotifyExit;
        private ToolStripMenuItem miNotifyRestore;
        private MenuItem miSessionAbort;
        private MenuItem miSessionAddComment;
        private MenuItem miSessionCOMETPeek;
        public MenuItem miSessionCopy;
        private MenuItem miSessionCopyColumn;
        private MenuItem miSessionCopyEntire;
        private MenuItem miSessionCopyHeaders;
        private MenuItem miSessionCopyHeadlines;
        private MenuItem miSessionCopySummary;
        private MenuItem miSessionCopyURL;
        internal MenuItem miSessionListScroll;
        private MenuItem miSessionMark;
        private MenuItem miSessionMarkBlue;
        private MenuItem miSessionMarkGold;
        private MenuItem miSessionMarkGreen;
        private MenuItem miSessionMarkOrange;
        private MenuItem miSessionMarkPurple;
        private MenuItem miSessionMarkRed;
        private MenuItem miSessionMarkUnmark;
        public MenuItem miSessionProperties;
        private MenuItem miSessionReissueInIE;
        private MenuItem miSessionReissueRequests;
        private MenuItem miSessionReissueUnconditionally;
        private MenuItem miSessionRemove;
        private MenuItem miSessionRemoveAll;
        private MenuItem miSessionRemoveSelected;
        private MenuItem miSessionRemoveUnselected;
        public MenuItem miSessionReplay;
        private MenuItem miSessionReplayResponse;
        public MenuItem miSessionSave;
        private MenuItem miSessionSaveEntire;
        private MenuItem miSessionSaveFullRequest;
        private MenuItem miSessionSaveFullResponse;
        private MenuItem miSessionSaveHeaders;
        private MenuItem miSessionSaveRequestBody;
        private MenuItem miSessionSaveResponseBody;
        private MenuItem miSessionSaveToZip;
        public MenuItem miSessionSelect;
        private MenuItem miSessionSelectChildren;
        private MenuItem miSessionSelectDuplicates;
        private MenuItem miSessionSelectParent;
        private MenuItem miSessionSplit;
        private MenuItem miSessionSplit2;
        private MenuItem miSessionUnlock;
        private MenuItem miSessionWinDiff;
        private MenuItem miToolsClearCache;
        private MenuItem miToolsClearCookies;
        private MenuItem miToolsCompare;
        private MenuItem miToolsEncodeDecode;
        private MenuItem miToolsInternetOptions;
        private MenuItem miToolsOptions;
        private MenuItem miToolsSplit1;
        private MenuItem miToolsSplit2;
        private MenuItem miToolsSplitCustom;
        internal MenuItem miViewAutoScroll;
        private MenuItem miViewInspector;
        private MenuItem miViewMinimizeToTray;
        private MenuItem miViewRefresh;
        private MenuItem miViewSplit1;
        private MenuItem miViewSplit3;
        private MenuItem miViewSquish;
        public MenuItem miViewStacked;
        private MenuItem miViewStatistics;
        private MenuItem miViewStayOnTop;
        private MenuItem miViewToolbar;
        private MenuItem mnuContextSaveRequest;
        private MenuItem mnuContextSaveResponse;
        private MenuItem mnuContextSaveSessions;
        private MenuItem mnuEdit;
        private MenuItem mnuEditCopy;
        private MenuItem mnuEditMark;
        private MenuItem mnuEditRemove;
        private MenuItem mnuFile;
        private MenuItem mnuFileExport;
        private MenuItem mnuFileSave;
        private MenuItem mnuFileSaveRequest;
        private MenuItem mnuFileSaveResponse;
        private MenuItem mnuFileSaveSessions;
        private ContextMenu mnuInspectorsContext;
        public MainMenu mnuMain;
        public ContextMenuStrip mnuNotify;
        public ContextMenu mnuSessionContext;
        public MenuItem mnuTools;
        private MenuItem mnuView;
        internal NotifyIcon notifyIcon;
        private int oldWidth;
        private static System.Windows.Forms.Timer oReportingQueueTimer = new System.Windows.Forms.Timer();
        public TabPage pageInspector;
        public TabPage pageStatistics;
        internal Panel pnlInfoTip;
        private Panel pnlInspector;
        private Panel pnlSessionControls;
        public Panel pnlSessions;
        private StatusBarPanel sbpBreakpoints;
        private StatusBarPanel sbpCapture;
        public StatusBarPanel sbpInfo;
        private StatusBarPanel sbpProcessFilter;
        private StatusBarPanel sbpSelCount;
        public StatusBar sbStatus;
        private Splitter splitterInspector;
        private Splitter splitterMain;
        public TabControl tabsRequest;
        private TabControl tabsResponse;
        public TabControl tabsViews;
        private ToolStripSeparator toolStripMenuItem1;
        private MenuItem miViewSplit2;
       

        public frmViewer()
        {
            this.InitializeComponent();
        }

        private TabPage _GetTabPageFromPoint(Point pt)
        {
            for (int i = 0; i < this.tabsViews.TabPages.Count; i++)
            {
                if (this.tabsViews.GetTabRect(i).Contains(pt))
                {
                    return this.tabsViews.TabPages[i];
                }
            }
            return null;
        }

        private void _initDonateMenu()
        {
            if (FiddlerApplication.Prefs.GetBoolPref("fiddler.ui.menus.donate.visible", true) && (CONFIG.iStartupCount > 2))
            {
                MenuItem mnuDonate = new MenuItem("&$ Donate");
                mnuDonate.MenuItems.Add("&Learn more...").Click += delegate (object s, EventArgs obj) {
                    Utilities.LaunchHyperlink(CONFIG.GetUrl("REDIR") + "FIDDLERCLIENTDONATION");
                };
                mnuDonate.MenuItems.Add("&Shop at Amazon...").Click += delegate (object s, EventArgs obj) {
                    if (FiddlerApplication.Prefs.GetBoolPref("fiddler.ui.menus.donate.ExplainAmazon", true))
                    {
                        FiddlerApplication.DoNotifyUser("When you start an Amazon shopping trip with this menu, I receive a commission of 7%, at no cost to you. Thanks for your support!", "One-time explanation");
                        FiddlerApplication.Prefs.SetBoolPref("fiddler.ui.menus.donate.ExplainAmazon", false);
                    }
                    Utilities.LaunchHyperlink(CONFIG.GetUrl("ShopAmazon"));
                };
                mnuDonate.MenuItems.Add("&Hide this menu").Click += delegate (object s, EventArgs obj) {
                    FiddlerApplication.Prefs.SetBoolPref("fiddler.ui.menus.donate.visible", false);
                    this.mnuMain.MenuItems.Remove(mnuDonate);
                };
                this.mnuMain.MenuItems.Add(mnuDonate);
            }
        }

        private void _initImportExportMenu()
        {
            this.mnuFileExport = new MenuItem("&Export Sessions");
            this.mnuFile.MenuItems.Add(4, this.mnuFileExport);
            MenuItem miSub = new MenuItem("&All Sessions...");
            this.mnuFileExport.MenuItems.Add(miSub);
            miSub.Click += delegate (object s, EventArgs ea) {
                this.actDoExport(null);
            };
            miSub = new MenuItem("&Selected Sessions...");
            this.mnuFileExport.MenuItems.Add(miSub);
            miSub.Click += delegate (object s, EventArgs ea) {
                Session[] oSelectedSessions = FiddlerApplication.UI.GetSelectedSessions();
                if (oSelectedSessions.Length > 0)
                {
                    this.actDoExport(oSelectedSessions);
                }
            };
            this.mnuFileExport.Popup += delegate (object s, EventArgs ea) {
                miSub.Enabled = FiddlerApplication.UI.lvSessions.SelectedItems.Count > 0;
            };
            MenuItem item = new MenuItem("&Import Sessions...");
            this.mnuFile.MenuItems.Add(4, item);
            item.Click += delegate (object s, EventArgs ea) {
                string[] array = FiddlerApplication.oTranscoders.getImportFormats();
                if (array.Length > 0)
                {
                    Array.Sort<string>(array);
                    string sImportFormat = actSelectImportExportFormat(true, array);
                    Session[] sessionArray = FiddlerApplication.DoImport(sImportFormat, true, null, null);
                    if (sessionArray != null)
                    {
                        this.sbpInfo.Text = string.Concat(new object[] { "Import from ", sImportFormat, " completed. Loaded ", sessionArray.Length, " sessions." });
                    }
                }
                else
                {
                    FiddlerApplication.DoNotifyUser("You can install Importers from http://www.fiddler2.com/redir/?id=FIDDLERTRANSCODERS", "No Importers Installed");
                }
            };
            MenuItem item2 = new MenuItem("-");
            this.mnuFile.MenuItems.Add(4, item2);
        }

        private void _internalTrimSessionList(int iTrimTo)
        {
            this.lvSessions.FlushUpdates();
            this.lvSessions.BeginUpdate();
            Session[] allSessions = this.GetAllSessions();
            int num = allSessions.Length - iTrimTo;
            for (uint i = 0; (i < allSessions.Length) && (num > 0); i++)
            {
                if (((allSessions[i] != null) && (allSessions[i].ViewItem != null)) && (allSessions[i].state >= SessionStates.Done))
                {
                    num--;
                    if ((!(allSessions[i].oFlags["ui-bold"] == "user-marked") && string.IsNullOrEmpty(allSessions[i].oFlags["ui-comments"])) && ((allSessions[i].state != SessionStates.HandTamperRequest) && (allSessions[i].state != SessionStates.HandTamperResponse)))
                    {
                        allSessions[i].ViewItem.Remove();
                    }
                }
            }
            this.lvSessions.EndUpdate();
            this.UpdateStatusBar();
        }

        private void _LoadAnySAZSpecifiedViaCommandLine()
        {
            foreach (string str in Environment.GetCommandLineArgs())
            {
                if (str.EndsWith(".saz", StringComparison.OrdinalIgnoreCase))
                {
                    this.actLoadSessionArchive(str);
                    return;
                }
            }
        }

        private static void _LogExceptionToEventLog(Exception unhandledException)
        {
            try
            {
                if (!EventLog.SourceExists("Fiddler"))
                {
                    EventLog.CreateEventSource("Fiddler", "Fiddler Error Log");
                }
                new EventLog { Source = "Fiddler" }.WriteEntry(unhandledException.Message + "\n" + unhandledException.StackTrace);
            }
            catch (Exception)
            {
            }
        }

        private static string _obtainScheme(Session oSession)
        {
            if ((oSession.oRequest != null) && (oSession.oRequest.headers != null))
            {
                return oSession.oRequest.headers.UriScheme.ToUpper();
            }
            return "?";
        }

        private void _PingLeaderBoard()
        {
            if (CONFIG.IsMicrosoftMachine)
            {
                try
                {
                    string stringPref = FiddlerApplication.Prefs.GetStringPref("microsoft.selfhost.featurelist", "8888");
                    FiddlerApplication.Prefs.SetStringPref("microsoft.selfhost.featurelist", "10000");
                    if (Environment.CommandLine.IndexOf("noversioncheck", StringComparison.OrdinalIgnoreCase) < 1)
                    {
                        WindowsPrincipal principal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
                        string name = principal.Identity.Name;
                        string[] strArray = stringPref.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        StringBuilder builder = new StringBuilder();
                        foreach (string str3 in strArray)
                        {
                            builder.AppendFormat("<FeaturesId>{0}</FeaturesId>", str3);
                        }
                        string str4 = string.Format("{0}{1}<soap:Body>{2}</soap:Body>{3}", new object[] { "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n", "<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n", string.Format("<InsertIntoLeaderBoard xmlns=\"http://localhost/leaderboard\"><leaderBoardObj><UsersId>{0}</UsersId><AppsName>{1}</AppsName><AppsId>{2}</AppsId>{3}<UserPoints>{4}</UserPoints><OsVerHiField>{5}</OsVerHiField><OsVerLoField>{6}</OsVerLoField><AppVerHiField>{7}</AppVerHiField><AppVerLoField>{8}</AppVerLoField></leaderBoardObj></InsertIntoLeaderBoard>", new object[] { name, "Fiddler", 0x22b8, builder.ToString(), 1, Environment.OSVersion.Version.Major, Environment.OSVersion.Version.Minor, CONFIG.FiddlerVersionInfo.Major, ((CONFIG.FiddlerVersionInfo.Minor * 100) + (CONFIG.FiddlerVersionInfo.Build * 10)) + CONFIG.FiddlerVersionInfo.Revision }), "</soap:Envelope>\r\n" });
                        string str5 = "POST /leaderboard/Service.asmx HTTP/1.1\r\nUser-Agent: Microsoft-Self-Host-Logging; see http://leaderboard/applications.aspx?app=Fiddler\r\nContent-Type: text/xml; charset=utf-8\r\nSOAPAction: \"http://localhost/leaderboard/InsertIntoLeaderBoard\"\r\nContent-Length: " + str4.Length.ToString() + "\r\nHost: olpmstorage2\r\n\r\n";
                        StringDictionary oNewFlags = new StringDictionary();
                        if (!FiddlerApplication.Prefs.GetBoolPref("microsoft.selfhost.noisy", false))
                        {
                            oNewFlags.Add("ui-hide", "avoidspam");
                        }
                        FiddlerApplication.oProxy.InjectCustomRequest(str5 + str4, oNewFlags);
                    }
                }
                catch (Exception exception)
                {
                    Trace.WriteLine(exception.Message);
                }
            }
        }

        private void _QuickExecHandlePrefs(string[] sParams)
        {
            if (sParams.Length < 2)
            {
                MessageBox.Show("set <name> <value>\r\nremove <name>\r\nshow {optional filter}\r\nlog\r\nnoisy\r\nquiet\r\n", "Valid Actions");
            }
            else
            {
                switch (sParams[1].ToLower())
                {
                    case "log":
                        FiddlerApplication.Log.LogString(FiddlerApplication._Prefs.ToString(true));
                        this.sbpInfo.Text = "Dumped preferences to log";
                        return;

                    case "show":
                        if (sParams.Length != 2)
                        {
                            FiddlerApplication.DoNotifyUser(FiddlerApplication._Prefs.FindMatches(sParams[2]), "Preferences matching '" + sParams[2] + "'");
                            return;
                        }
                        FiddlerApplication.DoNotifyUser(FiddlerApplication._Prefs.ToString(true), "All Preferences");
                        return;

                    case "noisy":
                        FiddlerApplication.Prefs.AddWatcher(string.Empty, new EventHandler<PrefChangeEventArgs>(this.AllPrefChange));
                        this.sbpInfo.Text = "Fiddler will notify on every preference change.";
                        return;

                    case "quiet":
                        FiddlerApplication.Prefs.RemoveWatcher(new PreferenceBag.PrefWatcher(string.Empty, new EventHandler<PrefChangeEventArgs>(this.AllPrefChange)));
                        this.sbpInfo.Text = "Detached watcher for every preference change.";
                        return;

                    case "set":
                        if (sParams.Length == 4)
                        {
                            FiddlerApplication.Prefs.SetStringPref(sParams[2], sParams[3]);
                            this.sbpInfo.Text = string.Format("Set preference '{0}' to '{1}'", sParams[2], sParams[3]);
                            return;
                        }
                        MessageBox.Show("Correct Syntax is:\r\n\r\n\tprefs SET prefName \"new value\"", "Invalid Parameters");
                        return;

                    case "remove":
                        if (sParams.Length == 3)
                        {
                            FiddlerApplication.Prefs.RemovePref(sParams[2]);
                            this.sbpInfo.Text = string.Format("Removed preference '{0}'", sParams[2]);
                            return;
                        }
                        MessageBox.Show("Correct Syntax is:\r\n\r\n\tprefs REMOVE prefName", "Invalid Parameters");
                        return;
                }
                MessageBox.Show("set <name> <value>\r\nremove <name>\r\nshow {optional filter}\r\nlog\r\nnoisy\r\nquiet\r\n", "Valid Actions");
            }
        }

        internal void _SetProcessFilter(ProcessFilterCategories oCat)
        {
            CONFIG.iShowProcessFilter = oCat;
            this.uihlpUpdateProcessFilterStatus();
        }

        

        internal void actActivateTabByTitle(string sName, TabControl tabSet)
        {
            foreach (TabPage page in tabSet.TabPages)
            {
                if (string.Equals(page.Text, sName, StringComparison.OrdinalIgnoreCase))
                {
                    tabSet.SelectedTab = page;
                    break;
                }
            }
        }

        [CodeDescription("Attach Fiddler as the WinINET proxy.")]
        public void actAttachProxy()
        {
            if (FiddlerApplication.oProxy.Attach())
            {
                this.sbpCapture.Text = "Capturing";
                this.sbpCapture.Style = StatusBarPanelStyle.Text;
            }
        }

        [CodeDescription("Add a screenshot to the capture.")]
        public void actCaptureScreenshot(bool bDelay)
        {
            try
            {
                if (bDelay)
                {
                    Thread.Sleep(0x1388);
                }
                HTTPRequestHeaders headers = new HTTPRequestHeaders {
                    HTTPMethod = "GET"
                };
                headers.Add("Host", "localhost");
                headers.RequestPath = "/Screenshot_" + DateTime.Now.ToString("h-mm-ss") + ".jpg";
                byte[] arrRequest = headers.ToByteArray(true, true, false);
                byte[] bytes = Encoding.UTF8.GetBytes("HTTP/1.1 200 OK\r\nContent-Type: image/jpeg\r\nConnection: close\r\n\r\n");
                MemoryStream stream = new MemoryStream();
                stream.Write(bytes, 0, bytes.Length);
                Screen screen = Screen.FromPoint(Cursor.Position);
                Bitmap image = new Bitmap(screen.Bounds.Width, screen.Bounds.Height, PixelFormat.Format32bppArgb);
                Graphics graphics = Graphics.FromImage(image);
                graphics.CopyFromScreen(screen.Bounds.X, screen.Bounds.Y, 0, 0, screen.Bounds.Size, CopyPixelOperation.SourceCopy);
                graphics.Dispose();
                image.Save(stream, ImageFormat.Jpeg);
                Session oSession = new Session(arrRequest, stream.ToArray(), SessionFlags.ServedFromCache | SessionFlags.ImportedFromOtherTool | SessionFlags.ResponseGeneratedByFiddler | SessionFlags.RequestGeneratedByFiddler) {
                    state = SessionStates.Done
                };
                this.addSession(oSession);
                this.finishSession(oSession);
                this.sbpInfo.Text = "A screenshot has been added to the capture.";
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Screenshot failed");
            }
        }

        private void actCheckForUpdates(bool verbose)
        {
            if (!CONFIG.bVersionCheckBlocked)
            {
                new Updater().CheckForUpdates(verbose);
            }
            else if (verbose)
            {
                FiddlerApplication.DoNotifyUser("Sorry, an Adminstrator has disabled the update check.", "I can't do that, Dave");
            }
        }

        private void actCheckForUpdatesQuiet()
        {
            this.actCheckForUpdates(false);
        }

        private void actCheckForUpdatesVerbose()
        {
            this.actCheckForUpdates(true);
        }

        [CodeDescription("Delete all cached WinINET files.")]
        public void actClearWinINETCache()
        {
            this.sbpInfo.Text = "Clearing WININET cache files...";
            Application.DoEvents();
            FiddlerApplication.UI.UseWaitCursor = true;
            WinINETCache.ClearFiles();
            FiddlerApplication.UI.UseWaitCursor = false;
            this.sbpInfo.Text = "WinINET Temporary Internet Files cache cleared.";
        }

        [CodeDescription("Delete all stored WinINET cookies; won't clear memory-only session cookies")]
        public void actClearWinINETCookies()
        {
            this.sbpInfo.Text = "Clearing WININET cookies...";
            Application.DoEvents();
            FiddlerApplication.UI.UseWaitCursor = true;
            WinINETCache.ClearCookies();
            FiddlerApplication.UI.UseWaitCursor = false;
            this.sbpInfo.Text = "WinINET cookies cleared.";
        }

        internal void actCommentSelectedSessions()
        {
            Session[] selectedSessions = this.GetSelectedSessions();
            if (selectedSessions.Length >= 1)
            {
                string sDefault = selectedSessions[0].oFlags["ui-comments"] ?? string.Empty;
                string str2 = frmPrompt.GetUserString("Enter Session Comment", "Enter a comment to associate with the selected session(s):", sDefault, true);
                if (str2 != null)
                {
                    this.lvSessions.BeginUpdate();
                    foreach (Session session in selectedSessions)
                    {
                        if (str2 != string.Empty)
                        {
                            session.oFlags["ui-comments"] = str2;
                        }
                        else
                        {
                            session.oFlags.Remove("ui-comments");
                        }
                        if (session.ViewItem != null)
                        {
                            session.ViewItem.SubItems[9].Text = str2;
                        }
                    }
                    this.lvSessions.EndUpdate();
                }
            }
        }

        [CodeDescription("Detach Fiddler from WinINET.")]
        public void actDetachProxy()
        {
            if (FiddlerApplication.oProxy.Detach())
            {
                this.sbpCapture.Text = string.Empty;
                this.sbpCapture.Style = StatusBarPanelStyle.OwnerDraw;
            }
        }

        [CodeDescription("Compare two Web sessions using the default comparison tool.")]
        public void actDoCompareSessions(Session oSess1, Session oSess2)
        {
            if (CONFIG.IsMicrosoftMachine)
            {
                FiddlerApplication.logSelfHost(70);
            }
            string path = CONFIG.GetPath("SafeTemp");
            string str2 = path + @"\S1_" + oSess1.id.ToString() + ".txt";
            string str3 = path + @"\S2_" + oSess2.id.ToString() + ".txt";
            try
            {
                this.SaveFilesForUltraDiff(str2, str3, oSess1, oSess2);
            }
            catch (Exception exception)
            {
                FiddlerApplication.DoNotifyUser("Unable to save files for comparison.\n\n" + exception.Message, "Compare Failed", MessageBoxIcon.Hand);
                return;
            }
            try
            {
                string str4 = ((Utilities.GetAsyncKeyState(0x10) < 0) || (Utilities.GetAsyncKeyState(0x11) < 0)) ? "-p" : string.Empty;
                using (Process.Start(CONFIG.GetPath("WINDIFF"), string.Format("\"{0}\" \"{1}\" {2}", str2, str3, str4)))
                {
                }
            }
            catch (Exception exception2)
            {
                if (DialogResult.Yes == MessageBox.Show("Failed to launch comparison tool (" + exception2.Message + ").\n\nPlease ensure that " + CONFIG.GetPath("WINDIFF") + " is installed and in your Path.\n\nWould you like to download Windiff.exe?", "Compare Failed", MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2))
                {
                    Utilities.LaunchHyperlink(CONFIG.GetUrl("REDIR") + "GETWINDIFF");
                }
            }
        }

        private void actDoExport(Session[] oSelectedSessions)
        {
            string[] array = FiddlerApplication.oTranscoders.getExportFormats();
            if (array.Length > 0)
            {
                if (oSelectedSessions == null)
                {
                    oSelectedSessions = this.GetAllSessions();
                }
                Array.Sort<string>(array);
                string sExportFormat = actSelectImportExportFormat(false, array);
                if (sExportFormat != null)
                {
                    Application.DoEvents();
                    if (FiddlerApplication.DoExport(sExportFormat, oSelectedSessions, null, null))
                    {
                        this.sbpInfo.Text = "Export to " + sExportFormat + " completed.";
                    }
                }
            }
            else
            {
                FiddlerApplication.DoNotifyUser("You can install Exporters from http://www.fiddler2.com/redir/?id=FIDDLERTRANSCODERS", "No Exporters Installed");
            }
        }

        [CodeDescription("Launch the Find Sessions user experience.")]
        public void actDoFind()
        {
            frmSearch search = new frmSearch {
                cbSearchSelectedSessions = { Enabled = this.lvSessions.SelectedItems.Count > 0, Checked = this.lvSessions.SelectedItems.Count > 1 }
            };
            if (DialogResult.OK == search.ShowDialog(this))
            {
                IEnumerable selectedItems;
                int num = 0;
                if (search.cbSearchSelectedSessions.Checked)
                {
                    selectedItems = this.lvSessions.SelectedItems;
                }
                else
                {
                    selectedItems = this.lvSessions.Items;
                }
                System.Drawing.Color empty = System.Drawing.Color.Empty;
                if (search.cbxSearchColor.SelectedIndex > 0)
                {
                    empty = System.Drawing.Color.FromName(search.cbxSearchColor.Text);
                }
                if (search.cbSearchSelectMatches.Checked)
                {
                    FiddlerApplication.SuppressReportUpdates = true;
                    this.lvSessions.SelectedItems.Clear();
                    FiddlerApplication.SuppressReportUpdates = false;
                }
                string text = search.txtSearchFor.Text;
                Regex regex = null;
                if (search.txtSearchFor.Text.StartsWith("REGEX:", StringComparison.OrdinalIgnoreCase))
                {
                    try
                    {
                        RegexOptions options = RegexOptions.Singleline | RegexOptions.ExplicitCapture;
                        if (!search.cbSearchCaseSensitive.Checked)
                        {
                            options |= RegexOptions.IgnoreCase;
                        }
                        regex = new Regex(search.txtSearchFor.Text.Substring(6), options);
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show("An invalid regular expression was provided.\n" + exception.ToString(), "Invalid Regular Expression");
                    }
                }
                foreach (ListViewItem item in selectedItems)
                {
                    Session tag = item.Tag as Session;
                    if (tag != null)
                    {
                        bool success;
                        StringBuilder builder = new StringBuilder();
                        if (((search.cbxSearchIn.SelectedIndex < 2) && (tag.oRequest != null)) && (tag.oRequest.headers != null))
                        {
                            if (search.cbxExamine.SelectedIndex < 2)
                            {
                                builder.Append(tag.oRequest.headers.ToString(true, false, true));
                            }
                            if ((((search.cbxExamine.SelectedIndex != 1) && (tag.requestBodyBytes != null)) && (tag.requestBodyBytes.Length > 0)) && (search.cbSearchBinaries.Checked || !Utilities.IsBinaryMIME(tag.oRequest["Content-Type"])))
                            {
                                if (search.cbSearchDecodeFirst.Checked)
                                {
                                    tag.utilDecodeRequest();
                                }
                                builder.Append(Utilities.getEntityBodyEncoding(tag.oRequest.headers, tag.requestBodyBytes).GetString(tag.requestBodyBytes));
                            }
                        }
                        if (((search.cbxSearchIn.SelectedIndex == 0) || (search.cbxSearchIn.SelectedIndex == 2)) && ((tag.oResponse != null) && (tag.oResponse.headers != null)))
                        {
                            if (search.cbxExamine.SelectedIndex != 2)
                            {
                                builder.Append(tag.oResponse.headers.ToString(true, false));
                            }
                            if ((((search.cbxExamine.SelectedIndex != 1) && (tag.responseBodyBytes != null)) && (tag.responseBodyBytes.Length > 0)) && (search.cbSearchBinaries.Checked || !Utilities.IsBinaryMIME(tag.oResponse["Content-Type"])))
                            {
                                if (search.cbSearchDecodeFirst.Checked)
                                {
                                    tag.utilDecodeResponse();
                                }
                                builder.Append(Utilities.getResponseBodyEncoding(tag).GetString(tag.responseBodyBytes));
                            }
                        }
                        if (search.cbxSearchIn.SelectedIndex == 3)
                        {
                            builder.Append(tag.fullUrl);
                        }
                        string input = builder.ToString();
                        if (regex != null)
                        {
                            success = regex.Match(input).Success;
                        }
                        else
                        {
                            success = -1 < input.IndexOf(text, search.cbSearchCaseSensitive.Checked ? StringComparison.CurrentCulture : StringComparison.CurrentCultureIgnoreCase);
                        }
                        if (success)
                        {
                            num++;
                            if (num == 1)
                            {
                                item.EnsureVisible();
                            }
                            if (empty != System.Drawing.Color.Empty)
                            {
                                if ((tag.oFlags["ui-bold"] != "user-marked") && (item.ForeColor != System.Drawing.Color.Black))
                                {
                                    tag.oFlags["ui-oldcolor"] = Utilities.GetStringFromColor(item.ForeColor);
                                }
                                item.BackColor = empty;
                                tag.oFlags["ui-backcolor"] = search.cbxSearchColor.Text;
                            }
                            if (search.cbSearchSelectMatches.Checked)
                            {
                                item.Selected = true;
                            }
                            continue;
                        }
                        if (search.cbUnmarkOld.Checked && (tag.oFlags["ui-backcolor"] == search.cbxSearchColor.Text))
                        {
                            item.BackColor = this.lvSessions.BackColor;
                            tag.oFlags.Remove("ui-backcolor");
                        }
                    }
                }
                string str3 = "contained";
                if (regex != null)
                {
                    str3 = "matched";
                }
                this.sbpInfo.Text = string.Format("{0} session{1} {2} '{3}'", new object[] { num, (num != 1) ? "s" : string.Empty, str3, (regex == null) ? text : text.Substring(6) });
                this.lvSessions.Focus();
            }
            search.Dispose();
        }

        public void actExit()
        {
            base.Close();
        }

        [CodeDescription("Show the most relevant Request and Response inspectors for this session")]
        public void actInspectSession()
        {
            string sName = "HEADERS";
            string str2 = "TEXTVIEW";
            TabPage key = null;
            TabPage page2 = null;
            Session firstSelectedSession = this.GetFirstSelectedSession();
            if (firstSelectedSession != null)
            {
                if (firstSelectedSession.ViewItem != null)
                {
                    firstSelectedSession.ViewItem.EnsureVisible();
                }
                try
                {
                    string stringPref = FiddlerApplication.Prefs.GetStringPref("fiddler.ui.inspectors.request.alwaysuse", null);
                    if (!string.IsNullOrEmpty(stringPref))
                    {
                        sName = stringPref;
                    }
                    else if ((((firstSelectedSession.oRequest != null) && (firstSelectedSession.oRequest.headers != null)) && (!firstSelectedSession.isTunnel && (FiddlerApplication.oInspectors != null))) && ((firstSelectedSession.requestBodyBytes != null) && (firstSelectedSession.requestBodyBytes.Length > 0)))
                    {
                        DictionaryEntry entry = FiddlerApplication.oInspectors.FindBestRequestInspectorForContentType(firstSelectedSession.oRequest["Content-Type"]);
                        if (entry.Key != null)
                        {
                            key = (TabPage) entry.Key;
                        }
                    }
                    string str4 = FiddlerApplication.Prefs.GetStringPref("fiddler.ui.inspectors.response.alwaysuse", null);
                    if (!string.IsNullOrEmpty(str4))
                    {
                        str2 = str4;
                    }
                    else if ((firstSelectedSession.oResponse != null) && (firstSelectedSession.oResponse.headers != null))
                    {
                        if (((firstSelectedSession.isTunnel || (firstSelectedSession.responseBodyBytes == null)) || (firstSelectedSession.responseBodyBytes.Length < 1)) || (((firstSelectedSession.responseCode != 200) && (firstSelectedSession.responseCode != 0xcf)) && (firstSelectedSession.responseCode < 0x194)))
                        {
                            str2 = "HEADERS";
                        }
                        else if (firstSelectedSession.oResponse.headers.Exists("Content-Encoding"))
                        {
                            str2 = "TRANSFORMER";
                        }
                        else if (((firstSelectedSession.responseCode >= 200) && (firstSelectedSession.responseCode < 300)) && (!firstSelectedSession.isTunnel && (FiddlerApplication.oInspectors != null)))
                        {
                            DictionaryEntry entry2 = FiddlerApplication.oInspectors.FindBestResponseInspectorForContentType(firstSelectedSession.oResponse["Content-Type"]);
                            if (entry2.Key != null)
                            {
                                page2 = (TabPage) entry2.Key;
                            }
                        }
                    }
                    else
                    {
                        str2 = "HEADERS";
                    }
                }
                catch (Exception exception)
                {
                    FiddlerApplication.ReportException(exception);
                }
                this.tabsViews.SelectedTab = this.pageInspector;
                if (key != null)
                {
                    this.tabsRequest.SelectedTab = key;
                }
                else
                {
                    this.actActivateTabByTitle(sName, this.tabsRequest);
                }
                if (page2 != null)
                {
                    this.tabsResponse.SelectedTab = page2;
                }
                else
                {
                    this.actActivateTabByTitle(str2, this.tabsResponse);
                }
            }
        }

        [CodeDescription("Unselects all selected sessions, Selects all unselected sessions")]
        public void actInvertSelectedSessions()
        {
            this.lvSessions.BeginUpdate();
            FiddlerApplication.SuppressReportUpdates = true;
            foreach (ListViewItem item in this.lvSessions.Items)
            {
                item.Selected = !item.Selected;
            }
            this.lvSessions.EndUpdate();
            FiddlerApplication.SuppressReportUpdates = false;
            this.actUpdateInspector(true, true);
        }

        [CodeDescription("Display the named RequestInspector object")]
        public void ActivateRequestInspector(string sName)
        {
            this.tabsViews.SelectedTab = this.pageInspector;
            foreach (TabPage page in this.tabsRequest.TabPages)
            {
                if (string.Equals(page.Text, sName, StringComparison.OrdinalIgnoreCase))
                {
                    this.tabsRequest.SelectedTab = page;
                    break;
                }
            }
        }

        [CodeDescription("Display the named ResponseInspector object")]
        public void ActivateResponseInspector(string sName)
        {
            this.tabsViews.SelectedTab = this.pageInspector;
            foreach (TabPage page in this.tabsResponse.TabPages)
            {
                if (string.Equals(page.Text, sName, StringComparison.OrdinalIgnoreCase))
                {
                    this.tabsResponse.SelectedTab = page;
                    break;
                }
            }
        }

        [CodeDescription("Launch the Internet Explorer Control Panel Connections dialog.")]
        public void actLaunchIEProxy()
        {
            Utilities.RunExecutable("rundll32.exe", "shell32.dll,Control_RunDLL inetcpl.cpl,,4");
        }

        public void actLoadScripts()
        {
            this.UpdateLoadFromCbx();
            if (FiddlerApplication.scriptRules != null)
            {
                FiddlerApplication.scriptRules.LoadRulesScript();
            }
        }

        [CodeDescription("Load the specified .SAZ or .ZIP session archive")]
        public bool actLoadSessionArchive(string sFilename)
        {
            bool flag;
            if (!System.IO.File.Exists(sFilename))
            {
                return false;
            }
            if (CONFIG.IsMicrosoftMachine)
            {
                FiddlerApplication.logSelfHost(0x5b);
            }
            string destFileName = null;
            if (sFilename.StartsWith(@"\\"))
            {
                try
                {
                    this.sbpInfo.Text = "Buffering .SAZ locally...";
                    Application.DoEvents();
                    destFileName = Path.GetTempFileName();
                    System.IO.File.Copy(sFilename, destFileName, true);
                    sFilename = destFileName;
                }
                catch (Exception exception)
                {
                    FiddlerApplication.DoNotifyUser("Could not copy the SAZ File locally. " + exception.Message, "Operation Failed", MessageBoxIcon.Hand);
                    return false;
                }
            }
            ZipArchive archive = null;
            try
            {
                this.sbpInfo.Text = "Reading archive...";
                Application.DoEvents();
                FileStream stream = System.IO.File.Open(sFilename, FileMode.Open, FileAccess.Read, FileShare.Read);
                if (((stream.Length < 0x40L) || (stream.ReadByte() != 80)) || (stream.ReadByte() != 0x4b))
                {
                    FiddlerApplication.DoNotifyUser("The selected file is not a Fiddler-generated .SAZ archive of HTTP Sessions.", "Invalid Archive", MessageBoxIcon.Hand);
                    stream.Close();
                    if ((destFileName != null) && System.IO.File.Exists(destFileName))
                    {
                        System.IO.File.Delete(destFileName);
                    }
                    return false;
                }
                stream.Close();
                archive = new ZipArchive(new DiskFile(sFilename));
                archive.BeginUpdate();
                AbstractFolder folder = archive.GetFolder("raw");
                if (!folder.Exists)
                {
                    FiddlerApplication.DoNotifyUser("The selected file is not a Fiddler-generated .SAZ archive of HTTP Sessions.", "Invalid Archive", MessageBoxIcon.Hand);
                    archive.EndUpdate();
                    archive = null;
                    if ((destFileName != null) && System.IO.File.Exists(destFileName))
                    {
                        System.IO.File.Delete(destFileName);
                    }
                    return false;
                }
                this.lvSessions.BeginUpdate();
                AbstractFile[] files = folder.GetFiles(false, new object[] { "*_c.txt" });
                this.sbpInfo.Text = "Reading archive (" + files.Length + " sessions)...";
                Application.DoEvents();
                foreach (AbstractFile file in files)
                {
                    try
                    {
                        Stream stream2;
                        byte[] arrBytes = new byte[file.Size];
                    Label_01BC:
                        try
                        {
                            stream2 = file.OpenRead(FileShare.Read);
                        }
                        catch (InvalidDecryptionPasswordException)
                        {
                            string str2 = frmPrompt.GetUserString("Password-Protected Session Archive", "Enter the password (case-sensitive) that will be used to decrypt this session archive file. Leave blank to abort open.", string.Empty);
                            if (str2 != string.Empty)
                            {
                                archive.DefaultDecryptionPassword = str2;
                                goto Label_01BC;
                            }
                            this.sbpInfo.Text = "Aborted archive load.";
                            this.lvSessions.EndUpdate();
                            return false;
                        }
                        Utilities.ReadEntireStream(stream2, arrBytes);
                        stream2.Close();
                        AbstractFile file2 = folder.GetFile(file.Name.Replace("_c.txt", "_s.txt"));
                        if (!file2.Exists)
                        {
                            FiddlerApplication.DoNotifyUser("Could not find a server response. Missing file:\n" + file2.FullName, "Archive Incomplete", MessageBoxIcon.Hand);
                        }
                        else
                        {
                            byte[] buffer2 = new byte[file2.Size];
                            stream2 = file2.OpenRead();
                            Utilities.ReadEntireStream(stream2, buffer2);
                            stream2.Close();
                            file2 = folder.GetFile(file.Name.Replace("_c.txt", "_m.xml"));
                            this.AddReportedSession(arrBytes, buffer2, file2.Exists ? file2.OpenRead() : null, SessionFlags.LoadedFromSAZ);
                        }
                    }
                    catch (Exception exception2)
                    {
                        FiddlerApplication.DoNotifyUser("Invalid data was present for session [" + Utilities.TrimAfter(file.Name, "_") + "].\n\n" + exception2.Message + "\n" + exception2.StackTrace, "Archive Incomplete", MessageBoxIcon.Hand);
                    }
                }
                files = null;
                this.sbpInfo.Text = "Archived sessions loaded.";
                flag = true;
            }
            catch (Exception exception3)
            {
                FiddlerApplication.DoNotifyUser(string.Concat(new object[] { "The Session Archive File could not be loaded. The file may be corrupt; try redownloading or recreating it.\n\n", exception3.Message, "\n", exception3.StackTrace, "\n\n", exception3.InnerException, "\n" }), "Corrupt Archive", MessageBoxIcon.Hand);
                this.sbpInfo.Text = "Failed to load archive.";
                flag = false;
            }
            this.lvSessions.EndUpdate();
            Application.DoEvents();
            if (archive != null)
            {
                archive.EndUpdate();
                archive = null;
            }
            if ((destFileName != null) && System.IO.File.Exists(destFileName))
            {
                System.IO.File.Delete(destFileName);
            }
            if (CONFIG.bIsViewOnly)
            {
                FiddlerToolbar.SetViewerTitle(Path.GetFileNameWithoutExtension(sFilename));
            }
            return flag;
        }

        public void actMinimizeToTray()
        {
            this.notifyIcon.Visible = true;
            base.Visible = false;
        }

        
        public void actRefreshInspectorsIfNeeded(Session oSession)
        {
            if (oSession == this.GetFirstSelectedSession())
            {
                this.actUpdateInspector(true, true);
            }
        }

        public void actRefreshUI()
        {
            if (this.lvSessions.SelectedItems.Count < 2)
            {
                this.actUpdateInspector(true, true);
            }
            this.actReportStatistics();
            if (this.lvSessions.SelectedItems.Count == 1)
            {
                Session firstSelectedSession = this.GetFirstSelectedSession();
                if (firstSelectedSession == null)
                {
                    this.sbpInfo.Text = string.Empty;
                }
                else if (SessionStates.ReadingResponse == firstSelectedSession.state)
                {
                    if (firstSelectedSession.oResponse["Content-Length"] != string.Empty)
                    {
                        long num;
                        if (long.TryParse(firstSelectedSession.oResponse["Content-Length"], NumberStyles.Integer, NumberFormatInfo.InvariantInfo, out num))
                        {
                            this.sbpInfo.Text = string.Format("Download Progress: {0:N0} of {1:N0} bytes. Hit F5 to refresh.", firstSelectedSession.oResponse._PeekDownloadProgress, num);
                        }
                        else
                        {
                            this.sbpInfo.Text = "Reading server response...";
                        }
                    }
                    else
                    {
                        this.sbpInfo.Text = string.Format("Download Progress: {0:N0} bytes. Hit F5 to refresh.", firstSelectedSession.oResponse._PeekDownloadProgress);
                    }
                }
                else
                {
                    this.sbpInfo.Text = firstSelectedSession.fullUrl;
                }
            }
            else
            {
                this.sbpInfo.Text = string.Empty;
            }
        }

        internal void actReissueSelected()
        {
            int result = 1;
            if (Utilities.GetAsyncKeyState(0x10) < 0)
            {
                string s = frmPrompt.GetUserString("Repeat Count", "Repeat this request how many times?", "5", true);
                if (s == null)
                {
                    return;
                }
                if (!int.TryParse(s, out result))
                {
                    return;
                }
            }
            Session[] selectedSessions = this.GetSelectedSessions();
            StringDictionary oNewFlags = new StringDictionary();
            if (FiddlerApplication.Prefs.GetBoolPref("fiddler.reissue.autoauth", true))
            {
                oNewFlags.Add("x-AutoAuth", "(default)");
            }
            if (FiddlerApplication.Prefs.GetInt32Pref("fiddler.reissue.autoredircount", 0) > 0)
            {
                oNewFlags.Add("x-Builder-MaxRedir", FiddlerApplication.Prefs.GetInt32Pref("fiddler.reissue.autoredircount", 0).ToString());
            }
            for (int i = 0; i < result; i++)
            {
                for (int j = 0; j < selectedSessions.Length; j++)
                {
                    if ((selectedSessions[j].oRequest != null) && (selectedSessions[j].oRequest.headers != null))
                    {
                        FiddlerApplication.oProxy.InjectCustomRequest(selectedSessions[j].oRequest.headers, selectedSessions[j].requestBodyBytes, oNewFlags);
                    }
                }
            }
        }

        [CodeDescription("Reload all inspector objects")]
        public void actReloadInspectors()
        {
            FiddlerApplication.oInspectors.Dispose();
            FiddlerApplication.oInspectors = new Inspectors(this.tabsRequest, this.tabsResponse, this);
        }

        public void actRemoveAllSessions()
        {
            if (CONFIG.bResetCounterOnClear)
            {
                Session.ResetSessionCounter();
            }
            this.lvSessions.BeginUpdate();
            FiddlerApplication.SuppressReportUpdates = true;
            this.lvSessions.Items.Clear();
            this.sbpInfo.Text = string.Empty;
            this.lvSessions.EndUpdate();
            FiddlerApplication.SuppressReportUpdates = false;
            this.actUpdateInspector(true, true);
            FiddlerApplication.oProxy.PurgeServerPipePool();
        }

        [CodeDescription("Remove all selected sessions.")]
        public void actRemoveSelectedSessions()
        {
            ListView.SelectedListViewItemCollection selectedItems = this.lvSessions.SelectedItems;
            if (selectedItems.Count >= 1)
            {
                if (selectedItems.Count == this.lvSessions.Items.Count)
                {
                    this.actRemoveAllSessions();
                }
                else
                {
                    FiddlerApplication.SuppressReportUpdates = true;
                    this.lvSessions.BeginUpdate();
                    foreach (ListViewItem item in selectedItems)
                    {
                        item.Remove();
                    }
                    this.sbpInfo.Text = string.Empty;
                    if (this.lvSessions.FocusedItem != null)
                    {
                        this.lvSessions.FocusedItem.Selected = true;
                    }
                    this.lvSessions.EndUpdate();
                    FiddlerApplication.SuppressReportUpdates = false;
                    this.actUpdateInspector(true, true);
                }
            }
        }

        [CodeDescription("Remove sessions which are not selected")]
        public void actRemoveUnselectedSessions()
        {
            this.lvSessions.BeginUpdate();
            FiddlerApplication.SuppressReportUpdates = true;
            foreach (ListViewItem item in this.lvSessions.Items)
            {
                if (!item.Selected)
                {
                    item.Remove();
                }
            }
            this.lvSessions.EndUpdate();
            FiddlerApplication.SuppressReportUpdates = false;
            this.actUpdateInspector(true, true);
        }

        public void actReportStatistics()
        {
            this.actReportStatistics(false);
        }

        public void actReportStatistics(bool bImmediate)
        {
            this.UpdateStatusBar();
            if (!FiddlerApplication.SuppressReportUpdates)
            {
                if (bImmediate)
                {
                    this.actUpdateReport();
                }
                else if (!oReportingQueueTimer.Enabled)
                {
                    oReportingQueueTimer.Start();
                }
            }
        }

        public void actRestoreWindow()
        {
            if (Utilities.IsIconic(base.Handle))
            {
                Utilities.ShowWindowAsync(base.Handle, 9);
            }
            if (!CONFIG.bAlwaysShowTrayIcon)
            {
                this.notifyIcon.Visible = false;
            }
            base.Visible = true;
            Utilities.SetForegroundWindow(base.Handle);
        }

        [CodeDescription("Immediately resume all paused sessions.")]
        public void actResumeAllSessions()
        {
            this.pnlSessionControls.Visible = false;
            foreach (Session session in this.GetAllSessions())
            {
                if (session != null)
                {
                    if ((session.state == SessionStates.HandTamperRequest) && (session.ViewItem != null))
                    {
                        session.ViewItem.ImageIndex = 0;
                    }
                    if ((session.state == SessionStates.HandTamperResponse) && (session.ViewItem != null))
                    {
                        session.ViewItem.ImageIndex = 2;
                    }
                    session.ThreadResume();
                }
            }
        }

        internal void actSaveAllSessions()
        {
            Session[] allSessions = this.GetAllSessions();
            this.actSaveSessionArchive(allSessions);
        }

        [CodeDescription("Launch the Save Headers to Single File feature.")]
        public void actSaveHeaders()
        {
            if (this.lvSessions.SelectedItems.Count >= 1)
            {
                this.dlgSaveBinary.Title = "Save headers to one text file";
                this.dlgSaveBinary.FileName = ((Session) this.lvSessions.SelectedItems[0].Tag).id.ToString() + "_Headers.txt";
                if (DialogResult.OK == this.dlgSaveBinary.ShowDialog(this))
                {
                    this.actSaveSessions(this.dlgSaveBinary.FileName, true);
                }
            }
        }

        [CodeDescription("Launch the Save Selected Requests feature.")]
        public void actSaveRequests()
        {
            this.dlgSaveBinary.Title = "Save requests to...";
            foreach (Session session in this.GetSelectedSessions())
            {
                this.dlgSaveBinary.FileName = session.id.ToString() + "_Request.txt";
                if (DialogResult.OK != this.dlgSaveBinary.ShowDialog(this))
                {
                    break;
                }
                session.SaveRequest(this.dlgSaveBinary.FileName, false);
            }
        }

        [CodeDescription("Launch the Save Selected Responses feature.")]
        public void actSaveResponses()
        {
            this.dlgSaveBinary.Title = "Save responses to...";
            foreach (Session session in this.GetSelectedSessions())
            {
                this.dlgSaveBinary.FileName = session.id.ToString() + "_Response.txt";
                if (DialogResult.OK != this.dlgSaveBinary.ShowDialog(this))
                {
                    break;
                }
                session.SaveResponse(this.dlgSaveBinary.FileName, false);
            }
            this.UpdateLoadFromCbx();
        }

        private void actSaveSessionArchive(Session[] arrSessions)
        {
            if (DialogResult.OK == this.dlgSaveZip.ShowDialog(this))
            {
                string fileName = this.dlgSaveZip.FileName;
                if (this.dlgSaveZip.FilterIndex == 2)
                {
                    string sTitle = CONFIG.bUseAESForSAZ ? "Password-Protect SAZ (AES Encryption)" : "Password-Protect SAZ";
                    string sPassword = frmPrompt.GetUserString(sTitle, "Enter the password (case-sensitive) that will be used to encrypt this session archive file. Leave blank for no password.", string.Empty, true);
                    if (sPassword == null)
                    {
                        return;
                    }
                    if (sPassword != string.Empty)
                    {
                        this.actSaveSessionArchive(fileName, sPassword, arrSessions);
                        return;
                    }
                }
                this.actSaveSessionArchive(fileName, null, arrSessions);
            }
        }

        private void actSaveSessionArchive(string sFilename, string sPassword, Session[] arrSessions)
        {
            if (CONFIG.IsMicrosoftMachine)
            {
                FiddlerApplication.logSelfHost(90);
            }
            try
            {
                if (System.IO.File.Exists(sFilename))
                {
                    System.IO.File.Delete(sFilename);
                }
                this.sbpInfo.Text = "Archiving...";
                Application.DoEvents();
                DiskFile zipFile = new DiskFile(sFilename);
                ZipArchive archive = new ZipArchive(zipFile) {
                    TempFolder = new MemoryFolder()
                };
                StringBuilder sbHTML = new StringBuilder(0x200);
                sbHTML.Append("<html><head><style>body,thead,td,a,p{font-family:verdana,sans-serif;font-size: 10px;}</style></head><body><table cols=" + ((this.lvSessions.Columns.Count + 1)).ToString() + "><thead><tr>");
                sbHTML.Append("<th>&nbsp;</th>");
                foreach (ColumnHeader header in this.lvSessions.Columns)
                {
                    sbHTML.AppendFormat("<th>{0}</th>", Utilities.HtmlEncode(header.Text));
                }
                sbHTML.Append("</tr></thead><tbody>");
                archive.BeginUpdate();
                ZippedFolder folder1 = (ZippedFolder) archive.CreateFolder("raw");
                if (!string.IsNullOrEmpty(sPassword))
                {
                    if (CONFIG.bUseAESForSAZ)
                    {
                        archive.DefaultEncryptionMethod = EncryptionMethod.WinZipAes;
                    }
                    archive.DefaultEncryptionPassword = sPassword;
                }
                archive.Comment = "Fiddler (v" + Application.ProductVersion + ") Session Archive. See http://www.fiddler2.com";
                int num = 1;
                foreach (Session session in arrSessions)
                {
                    this.sbpInfo.Text = string.Format("Collecting data... #{0} (ID:{1})", num, session.id);
                    Application.DoEvents();
                    Utilities.WriteSessionToSAZ(session, zipFile, num, sbHTML, true);
                    num++;
                }
                sbHTML.Append("</tbody></table></body></html>");
                ZippedFile file2 = new ZippedFile(zipFile, @"\_index.htm");
                StreamWriter writer = new StreamWriter(file2.CreateWrite(FileShare.None), Encoding.UTF8);
                writer.Write(sbHTML.ToString());
                writer.Close();
                this.sbpInfo.Text = "Finalizing archive...";
                Application.DoEvents();
                archive.EndUpdate();
                this.sbpInfo.Text = "Saved to " + sFilename;
                Application.DoEvents();
            }
            catch (Exception exception)
            {
                FiddlerApplication.DoNotifyUser("Failed to save Session Archive.\n\n" + exception.Message, "Save Failed");
            }
        }

        [CodeDescription("Save Selected Request Bodies to Files feature.")]
        public void actSaveSessionRequestBody()
        {
            this.dlgSaveBinary.Title = "Save request bodies to...";
            foreach (Session session in this.GetSelectedSessions())
            {
                if ((session.requestBodyBytes != null) && (0L != session.requestBodyBytes.LongLength))
                {
                    if (DialogResult.OK != this.dlgSaveBinary.ShowDialog(this))
                    {
                        break;
                    }
                    FileStream stream = new FileStream(this.dlgSaveBinary.FileName, FileMode.Create, FileAccess.Write);
                    stream.Write(session.requestBodyBytes, 0, session.requestBodyBytes.Length);
                    stream.Close();
                }
                else
                {
                    FiddlerApplication.DoNotifyUser("There is no request body to save.", "Error");
                }
            }
        }

        [CodeDescription("Save Selected Response Bodies to Files feature.")]
        public void actSaveSessionResponseBody()
        {
            this.dlgSaveBinary.Title = "Save response bodies to...";
            foreach (Session session in this.GetSelectedSessions())
            {
                if ((session.responseBodyBytes != null) && (0L != session.responseBodyBytes.LongLength))
                {
                    this.dlgSaveBinary.FileName = session.SuggestedFilename;
                    if (DialogResult.OK != this.dlgSaveBinary.ShowDialog(this))
                    {
                        break;
                    }
                    session.SaveResponseBody(this.dlgSaveBinary.FileName);
                }
                else
                {
                    FiddlerApplication.DoNotifyUser("There is no response body to save for session #" + session.id.ToString() + ".", "No response body");
                }
            }
        }

        [CodeDescription("Launch the Save Selected Sessions to Single File feature.")]
        public void actSaveSessions()
        {
            if (this.lvSessions.SelectedItems.Count >= 1)
            {
                this.dlgSaveBinary.Title = "Save sessions as one text file";
                this.dlgSaveBinary.FileName = ((Session) this.lvSessions.SelectedItems[0].Tag).id.ToString() + "_Full.txt";
                if (DialogResult.OK == this.dlgSaveBinary.ShowDialog(this))
                {
                    this.actSaveSessions(this.dlgSaveBinary.FileName, false);
                }
            }
        }

        [CodeDescription("Save Selected Sessions to Single File named sFilename.")]
        public void actSaveSessions(string sFilename, bool bHeadersOnly)
        {
            string s = "\r\n\r\n------------------------------------------------------------------\r\n\r\n";
            FileStream oFS = new FileStream(sFilename, FileMode.Create, FileAccess.Write);
            Session[] selectedSessions = this.GetSelectedSessions();
            foreach (Session session in selectedSessions)
            {
                session.WriteToStream(oFS, bHeadersOnly);
                if (selectedSessions.Length > 1)
                {
                    oFS.Write(Encoding.ASCII.GetBytes(s), 0, s.Length);
                }
            }
            oFS.Close();
        }

        [CodeDescription("Launch the Save Selected Sessions to ZipArchive feature.")]
        public void actSaveSessionsToZip()
        {
            Session[] selectedSessions = this.GetSelectedSessions();
            if (selectedSessions.Length < 1)
            {
                FiddlerApplication.DoNotifyUser("Please select sessions in the Session List first", "Cannot Save SAZ");
            }
            else
            {
                this.actSaveSessionArchive(selectedSessions);
            }
        }

        [CodeDescription("Save Selected sessions to ZipArchive named by sFilename.")]
        public void actSaveSessionsToZip(string sFilename)
        {
            this.actSaveSessionsToZip(sFilename, null);
        }

        [CodeDescription("Save Selected sessions to ZipArchive named by sFilename, protected by password sPassword.")]
        public void actSaveSessionsToZip(string sFilename, string sPassword)
        {
            Session[] selectedSessions = this.GetSelectedSessions();
            if (selectedSessions.Length < 1)
            {
                FiddlerApplication.DoNotifyUser("Please select sessions in the Session List first", "Cannot Save SAZ");
            }
            else
            {
                this.actSaveSessionArchive(sFilename, sPassword, selectedSessions);
            }
        }

        [CodeDescription("Select all sessions in the Web Sessions List")]
        public void actSelectAll()
        {
            this.lvSessions.BeginUpdate();
            FiddlerApplication.SuppressReportUpdates = true;
            foreach (ListViewItem item in this.lvSessions.Items)
            {
                item.Selected = true;
            }
            FiddlerApplication.SuppressReportUpdates = false;
            this.lvSessions.EndUpdate();
        }

        private static string actSelectImportExportFormat(bool bIsImport, string[] arrFormats)
        {
            string str = null;
            Form frmPickType = new Form();
            Utilities.AdjustFontSize(frmPickType, CONFIG.flFontSize);
            frmPickType.FormBorderStyle = FormBorderStyle.SizableToolWindow;
            frmPickType.Size = new Size(400, 0xa5);
            frmPickType.MinimumSize = new Size(0x109, 150);
            frmPickType.Text = bIsImport ? "Select Import Format" : "Select Export Format";
            ComboBox oCbx = new ComboBox();
            Utilities.AdjustFontSize(oCbx, CONFIG.flFontSize);
            oCbx.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            oCbx.DropDownStyle = ComboBoxStyle.DropDownList;
            oCbx.Items.AddRange(arrFormats);
            oCbx.Width = 0x177;
            frmPickType.Controls.Add(oCbx);
            oCbx.Location = new Point(5, 5);
            TextBox txtDescription = new TextBox();
            frmPickType.Controls.Add(txtDescription);
            txtDescription.BorderStyle = BorderStyle.None;
            txtDescription.ReadOnly = true;
            txtDescription.BackColor = frmPickType.BackColor;
            txtDescription.WordWrap = true;
            txtDescription.Multiline = true;
            txtDescription.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            txtDescription.Location = new Point(5, 0x23);
            txtDescription.Size = new Size(0x177, 50);
            Button button = new Button {
                AutoSize = true,
                Text = "&Next"
            };
            frmPickType.Controls.Add(button);
            button.Left = (frmPickType.ClientSize.Width - button.Width) - 10;
            button.Top = (frmPickType.ClientSize.Height - button.Height) - 10;
            button.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            frmPickType.AcceptButton = button;
            button.Click += delegate (object s2, EventArgs ea2) {
                frmPickType.DialogResult = DialogResult.OK;
            };
            oCbx.SelectedIndexChanged += delegate (object sender, EventArgs oEA) {
                TranscoderTuple tuple;
                if (bIsImport)
                {
                    if (FiddlerApplication.oTranscoders.m_Importers.TryGetValue(oCbx.SelectedItem.ToString(), out tuple))
                    {
                        txtDescription.Text = tuple.sFormatDescription;
                    }
                }
                else if (FiddlerApplication.oTranscoders.m_Exporters.TryGetValue(oCbx.SelectedItem.ToString(), out tuple))
                {
                    txtDescription.Text = tuple.sFormatDescription;
                }
            };
            oCbx.SelectedIndex = 0;
            Button button2 = new Button {
                AutoSize = true,
                Text = "&Cancel"
            };
            frmPickType.Controls.Add(button2);
            button2.Left = 10;
            button2.Top = (frmPickType.ClientSize.Height - button2.Height) - 10;
            button2.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            frmPickType.KeyPreview = true;
            frmPickType.KeyUp += delegate (object s, KeyEventArgs k) {
                if (k.KeyCode == Keys.Escape)
                {
                    k.Handled = true;
                    k.SuppressKeyPress = true;
                    frmPickType.DialogResult = DialogResult.Cancel;
                }
            };
            button2.Click += delegate (object s2, EventArgs ea2) {
                frmPickType.DialogResult = DialogResult.Cancel;
            };
            frmPickType.StartPosition = FormStartPosition.CenterParent;
            if (DialogResult.OK == frmPickType.ShowDialog(FiddlerApplication.UI))
            {
                str = oCbx.SelectedItem.ToString();
            }
            frmPickType.Dispose();
            return str;
        }

        [CodeDescription("Select Sessions for which the provided matching function returns boolean True")]
        public void actSelectSessionsMatchingCriteria(doesSessionMatchCriteriaDelegate oDel)
        {
            FiddlerApplication.SuppressReportUpdates = true;
            this.lvSessions.BeginUpdate();
            this.lvSessions.SelectedItems.Clear();
            foreach (ListViewItem item in this.lvSessions.Items)
            {
                Session tag = (Session) item.Tag;
                if (tag != null)
                {
                    item.Selected = oDel(tag);
                }
            }
            this.sbpInfo.Text = string.Empty;
            this.lvSessions.EndUpdate();
            FiddlerApplication.SuppressReportUpdates = false;
            this.actUpdateInspector(true, true);
        }

        [CodeDescription("Select Sessions with Request[sHeader] value of containing sPartialValue")]
        public void actSelectSessionsWithRequestHeaderValue(string sHeader, string sPartialValue)
        {
            FiddlerApplication.SuppressReportUpdates = true;
            this.lvSessions.BeginUpdate();
            this.lvSessions.SelectedItems.Clear();
            foreach (ListViewItem item in this.lvSessions.Items)
            {
                Session tag = (Session) item.Tag;
                if (((tag != null) && (tag.oRequest != null)) && ((tag.oRequest.headers != null) && tag.oRequest.headers.ExistsAndContains(sHeader, sPartialValue)))
                {
                    item.Selected = true;
                }
            }
            this.sbpInfo.Text = string.Empty;
            this.lvSessions.EndUpdate();
            FiddlerApplication.SuppressReportUpdates = false;
            this.actUpdateInspector(true, true);
        }

        [CodeDescription("Select Sessions with responseCode == iStatus")]
        public void actSelectSessionsWithResponseCode(uint iStatus)
        {
            this.actSelectSessionsMatchingCriteria(oS => oS.responseCode == iStatus);
        }

        [CodeDescription("Select Sessions with Response[sHeader] containing sPartialValue")]
        public void actSelectSessionsWithResponseHeaderValue(string sHeader, string sPartialValue)
        {
            FiddlerApplication.SuppressReportUpdates = true;
            this.lvSessions.BeginUpdate();
            this.lvSessions.SelectedItems.Clear();
            foreach (ListViewItem item in this.lvSessions.Items)
            {
                Session tag = (Session) item.Tag;
                if (((tag != null) && (tag.oResponse != null)) && ((tag.oResponse.headers != null) && tag.oResponse.headers.ExistsAndContains(sHeader, sPartialValue)))
                {
                    item.Selected = true;
                }
            }
            this.sbpInfo.Text = string.Empty;
            this.lvSessions.EndUpdate();
            FiddlerApplication.SuppressReportUpdates = false;
            this.actUpdateInspector(true, true);
        }

        [CodeDescription("Select Sessions with a response body of at (least/most) iSize bytes")]
        public void actSelectSessionsWithResponseSize(bool bGreater, long iSize)
        {
            FiddlerApplication.SuppressReportUpdates = true;
            this.lvSessions.BeginUpdate();
            this.lvSessions.SelectedItems.Clear();
            foreach (ListViewItem item in this.lvSessions.Items)
            {
                Session tag = (Session) item.Tag;
                if (((tag != null) && (tag.responseBodyBytes != null)) && ((bGreater && (iSize < tag.responseBodyBytes.LongLength)) || (!bGreater && (iSize > tag.responseBodyBytes.LongLength))))
                {
                    item.Selected = true;
                }
            }
            this.sbpInfo.Text = string.Empty;
            this.lvSessions.EndUpdate();
            FiddlerApplication.SuppressReportUpdates = false;
            this.actUpdateInspector(true, true);
        }

        public void actSessionCopy()
        {
            this.CopySessions(false);
        }

        public void actSessionCopyHeaders()
        {
            this.CopySessions(true);
        }

        [CodeDescription("Copies the terse summary of currently selected sessions to the clipboard.")]
        public void actSessionCopyHeadlines()
        {
            Session[] selectedSessions = this.GetSelectedSessions();
            if (selectedSessions.Length >= 1)
            {
                StringBuilder builder = new StringBuilder(0x200);
                foreach (Session session in selectedSessions)
                {
                    if ((session.oRequest != null) && (session.oRequest.headers != null))
                    {
                        builder.AppendFormat("{0} {1}\r\n", session.oRequest.headers.HTTPMethod, session.fullUrl);
                    }
                    if ((session.oResponse != null) && (session.oResponse.headers != null))
                    {
                        switch (session.responseCode)
                        {
                            case 0x12d:
                            case 0x12e:
                            case 0x12f:
                            case 0x133:
                                builder.AppendFormat("{0} to {1}\r\n", session.oResponse.headers.HTTPResponseStatus, session.oResponse["Location"]);
                                goto Label_0110;
                        }
                        builder.AppendFormat("{0} ({1})\r\n", session.oResponse.headers.HTTPResponseStatus, session.oResponse.MIMEType);
                    }
                    else
                    {
                        builder.Append("No response\r\n");
                    }
                Label_0110:
                    if (selectedSessions.Length > 1)
                    {
                        builder.Append("\r\n");
                    }
                }
                Utilities.CopyToClipboard(builder.ToString());
            }
        }

        [CodeDescription("Copies summary of the currently selected sessions to the clipboard.")]
        public void actSessionCopySummary()
        {
            ListView.SelectedListViewItemCollection selectedItems = this.lvSessions.SelectedItems;
            if (selectedItems.Count >= 1)
            {
                StringBuilder data = new StringBuilder(0x200);
                StringBuilder builder2 = new StringBuilder(0x200);
                builder2.Append("<table><tr>");
                foreach (ColumnHeader header in this.lvSessions.Columns)
                {
                    data.Append(header.Text);
                    data.Append("\t");
                    builder2.AppendFormat("<th>{0}</th>", Utilities.HtmlEncode(header.Text));
                }
                data.Append("\r\n");
                builder2.Append("</tr><tr>");
                foreach (ListViewItem item in selectedItems)
                {
                    foreach (ListViewItem.ListViewSubItem item2 in item.SubItems)
                    {
                        data.Append(item2.Text);
                        data.Append("\t");
                        builder2.AppendFormat("<td>{0}</td>", Utilities.HtmlEncode(item2.Text));
                    }
                    data.Append("\r\n");
                    builder2.Append("</tr>");
                }
                DataObject oData = new DataObject("HTML Format", Utilities.StringToCF_HTML(builder2.ToString()));
                oData.SetData(DataFormats.Text, data);
                Utilities.CopyToClipboard(oData);
            }
        }

        [CodeDescription("Copies the URLs of currently selected sessions to the clipboard.")]
        public void actSessionCopyURL()
        {
            Session[] selectedSessions = this.GetSelectedSessions();
            if (selectedSessions.Length >= 1)
            {
                StringBuilder builder = new StringBuilder(0x200);
                foreach (Session session in selectedSessions)
                {
                    if ((session.oRequest != null) && (session.oRequest.headers != null))
                    {
                        builder.AppendFormat("{0}\r\n", session.fullUrl);
                    }
                }
                Utilities.CopyToClipboard(builder.ToString());
            }
        }

        public void actSessionMark(System.Drawing.Color c)
        {
            Session[] selectedSessions = this.GetSelectedSessions();
            if (selectedSessions.Length > 0)
            {
                this.actSessionMark(c, selectedSessions);
            }
        }

        public void actSessionMark(System.Drawing.Color c, Session[] oSessions)
        {
            this.lvSessions.BeginUpdate();
            foreach (Session session in oSessions)
            {
                if (session.ViewItem != null)
                {
                    ListViewItem viewItem = session.ViewItem;
                    if (c != System.Drawing.Color.Empty)
                    {
                        viewItem.Font = new Font(viewItem.Font, FontStyle.Bold);
                        if ((session.oFlags["ui-bold"] != "user-marked") && (viewItem.ForeColor != System.Drawing.Color.Black))
                        {
                            session.oFlags["ui-oldcolor"] = Utilities.GetStringFromColor(viewItem.ForeColor);
                        }
                        session.oFlags["ui-bold"] = "user-marked";
                        session.oFlags["ui-color"] = Utilities.GetStringFromColor(c);
                        viewItem.ForeColor = c;
                    }
                    else
                    {
                        viewItem.Font = new Font(viewItem.Font, FontStyle.Regular);
                        viewItem.ForeColor = System.Drawing.Color.Black;
                        viewItem.BackColor = this.lvSessions.BackColor;
                        string sColor = session.oFlags["ui-oldcolor"];
                        if (sColor != null)
                        {
                            viewItem.ForeColor = Utilities.GetColorFromString(sColor);
                        }
                        session.oFlags.Remove("ui-bold");
                        session.oFlags.Remove("ui-oldcolor");
                        session.oFlags.Remove("ui-color");
                    }
                }
            }
            this.lvSessions.EndUpdate();
        }

        [CodeDescription("Set the font size for (some) Fiddler UI elements.")]
        public void actSetFontSize(float flFontSize)
        {
            FiddlerApplication.Reporter.FontSize = flFontSize;
            this.lvSessions.Font = new Font(this.lvSessions.Font.FontFamily, flFontSize);
            this.sbStatus.Font = new Font(this.sbStatus.Font.FontFamily, flFontSize);
           
            if (FiddlerApplication.oInspectors != null)
            {
                FiddlerApplication.oInspectors.AnnounceFontSizeChange(CONFIG.flFontSize);
            }
            FiddlerApplication.Prefs.SetStringPref("fiddler.ui.font.size", CONFIG.flFontSize.ToString("##.##"));
        }

        internal void actShowEncodingTools()
        {
            if (CONFIG.IsMicrosoftMachine)
            {
                FiddlerApplication.logSelfHost(10);
            }
            new frmTextWizard { Left = base.Left + 100, Top = base.Top + 100 }.Show(this);
        }

        [CodeDescription("Show the Fiddler Options dialog")]
        public void actShowOptions()
        {
            frmOptions options = new frmOptions();
            options.ShowDialog(this);
            options.Dispose();
        }

        internal bool actTearoffInspectors()
        {
            if (this.frmFloatingInspectors != null)
            {
                return false;
            }
            this.btnSquish.Visible = false;
            this.miViewSquish.Enabled = false;
            this.miViewStacked.Checked = false;
            this.miViewStacked.Enabled = false;
            this.frmFloatingInspectors = new Form();
            this.frmFloatingInspectors.FormBorderStyle = FormBorderStyle.SizableToolWindow;
            this.frmFloatingInspectors.Width = 500;
            this.frmFloatingInspectors.Height = base.Height;
            this.frmFloatingInspectors.StartPosition = FormStartPosition.Manual;
            this.frmFloatingInspectors.Left = (base.Left + base.Width) - 500;
            this.frmFloatingInspectors.Top = base.Top + 0x19;
            this.frmFloatingInspectors.Text = "Fiddler - Details View";
            this.frmFloatingInspectors.Controls.Add(this.tabsViews);
            this.splitterMain.Visible = false;
            this.pnlInspector.Dock = DockStyle.Right;
            this.pnlInspector.Width = 0;
            this.pnlSessions.Dock = DockStyle.Fill;
            this.frmFloatingInspectors.Icon = base.Icon;
            this.frmFloatingInspectors.FormClosing += new FormClosingEventHandler(this.frmFloatingInspectors_FormClosing);
            this.frmFloatingInspectors.Show(this);
            return true;
        }

        public void actToggleCapture()
        {
            if (FiddlerApplication.oProxy.IsAttached)
            {
                this.actDetachProxy();
            }
            else
            {
                this.actAttachProxy();
            }
        }

        private void actToggleProcessFilter()
        {
           // CONFIG.iShowProcessFilter = (ProcessFilterCategories)((int)(CONFIG.iShowProcessFilter + 1) % (int)((ProcessFilterCategories)4));
            CONFIG.iShowProcessFilter = (ProcessFilterCategories)((int)(CONFIG.iShowProcessFilter + 1) %4);
            this.uihlpUpdateProcessFilterStatus();
            FiddlerToolbar.ClearProcessFilter();
        }

        public void actToggleSquish()
        {
            if (this.pnlSessions.Width == 0x34)
            {
                this.miViewSquish.Checked = false;
                this.btnSquish.Text = "<<";
                this.pnlSessions.Width = Math.Max(this.oldWidth, 360);
            }
            else
            {
                this.miViewSquish.Checked = true;
                this.btnSquish.Text = ">>";
                this.oldWidth = this.pnlSessions.Width;
                this.pnlSessions.Width = 0x34;
            }
        }

        public void actToggleStackedLayout(bool bStacked)
        {
            CONFIG.bStackedLayout = bStacked;
            this.miViewStacked.Checked = bStacked;
            base.SuspendLayout();
            if (CONFIG.bStackedLayout)
            {
                this.lblSessions.Height = 0;
                this.pnlSessions.Dock = DockStyle.Top;
                this.splitterMain.Dock = DockStyle.Top;
                this.pnlSessions.Height = base.Height / 2;
                this.pnlInspector.Dock = DockStyle.Fill;
                this.btnSquish.Visible = false;
                this.miViewSquish.Enabled = false;
            }
            else
            {
                this.lblSessions.Height = 14;
                this.pnlSessions.Dock = DockStyle.Left;
                this.splitterMain.Dock = DockStyle.Left;
                this.pnlSessions.Width = base.Width / 2;
                this.pnlInspector.Dock = DockStyle.Fill;
                this.btnSquish.Visible = true;
                this.btnSquish.Text = "<<";
                this.miViewSquish.Enabled = true;
                this.miViewSquish.Checked = false;
            }
            base.ResumeLayout();
        }

        internal void actUnconditionallyReissueSelected()
        {
            int result = 1;
            if (Utilities.GetAsyncKeyState(0x10) < 0)
            {
                string s = frmPrompt.GetUserString("Repeat Count", "Reissue this Request (Unconditionally) how many times?", "5", true);
                if (s == null)
                {
                    return;
                }
                if (!int.TryParse(s, out result))
                {
                    return;
                }
            }
            Session[] selectedSessions = this.GetSelectedSessions();
            StringDictionary oNewFlags = new StringDictionary();
            if (FiddlerApplication.Prefs.GetBoolPref("fiddler.reissue.autoauth", false))
            {
                oNewFlags.Add("x-AutoAuth", "(default)");
            }
            if (FiddlerApplication.Prefs.GetInt32Pref("fiddler.reissue.autoredircount", 0) > 0)
            {
                oNewFlags.Add("x-Builder-MaxRedir", FiddlerApplication.Prefs.GetInt32Pref("fiddler.reissue.autoredircount", 0).ToString());
            }
            for (int i = 0; i < result; i++)
            {
                for (int j = 0; j < selectedSessions.Length; j++)
                {
                    if ((selectedSessions[j].oRequest != null) && (selectedSessions[j].oRequest.headers != null))
                    {
                        HTTPRequestHeaders oHeaders = (HTTPRequestHeaders) selectedSessions[j].oRequest.headers.Clone();
                        oHeaders.Remove("Range");
                        oHeaders.Remove("If-Modified-Since");
                        oHeaders.Remove("If-Unmodified-Since");
                        oHeaders.Remove("Unless-Modified-Since");
                        oHeaders.Remove("If-Range");
                        oHeaders.Remove("If-Match");
                        oHeaders.Remove("If-None-Match");
                        FiddlerApplication.oProxy.InjectCustomRequest(oHeaders, selectedSessions[j].requestBodyBytes, oNewFlags);
                    }
                }
            }
        }

        public void actUpdateInspector(bool bRequest, bool bResponse)
        {
            if ((!FiddlerApplication.isClosing && (this.tabsViews.SelectedTab == this.pageInspector)) && (this.lvSessions.SelectedItems.Count < 2))
            {
                Session firstSelectedSession = this.GetFirstSelectedSession();
                this.btnTamperSendServer.Enabled = (firstSelectedSession != null) && (firstSelectedSession.state == SessionStates.HandTamperRequest);
                this.btnTamperSendClient.Enabled = (firstSelectedSession != null) && ((firstSelectedSession.state == SessionStates.HandTamperRequest) || (firstSelectedSession.state == SessionStates.HandTamperResponse));
                this.pnlSessionControls.Visible = this.btnTamperSendServer.Enabled || this.btnTamperSendClient.Enabled;
                if (this.cbxLoadFrom.Items.Count > 0)
                {
                    this.cbxLoadFrom.SelectedIndex = 0;
                }
                if (((firstSelectedSession != null) && (firstSelectedSession.oResponse != null)) && (firstSelectedSession.oResponse.headers != null))
                {
                    this.pnlInfoTip.Visible = ((firstSelectedSession.responseBodyBytes != null) && (firstSelectedSession.responseBodyBytes.Length > 0)) && (firstSelectedSession.oResponse.headers.Exists("Transfer-Encoding") || firstSelectedSession.oResponse.headers.Exists("Content-Encoding"));
                }
                else
                {
                    this.pnlInfoTip.Visible = false;
                }
                IRequestInspector2 activeRequestInspector = this.GetActiveRequestInspector();
                if (bRequest && (activeRequestInspector != null))
                {
                    try
                    {
                        if (firstSelectedSession == null)
                        {
                            activeRequestInspector.Clear();
                        }
                        else
                        {
                            activeRequestInspector.headers = firstSelectedSession.oRequest.headers;
                            activeRequestInspector.body = firstSelectedSession.requestBodyBytes;
                            activeRequestInspector.bReadOnly = (firstSelectedSession.state != SessionStates.HandTamperRequest) && !firstSelectedSession.oFlags.ContainsKey("x-Unlocked");
                        }
                    }
                    catch (Exception exception)
                    {
                        FiddlerApplication.LogAddonException(exception, "Request Inspector Failed");
                    }
                }
                IResponseInspector2 activeResponseInspector = this.GetActiveResponseInspector();
                if (bResponse && (activeResponseInspector != null))
                {
                    try
                    {
                        if (firstSelectedSession == null)
                        {
                            activeResponseInspector.Clear();
                        }
                        else
                        {
                            activeResponseInspector.headers = firstSelectedSession.oResponse.headers;
                            activeResponseInspector.body = firstSelectedSession.responseBodyBytes;
                            activeResponseInspector.bReadOnly = (firstSelectedSession.state != SessionStates.HandTamperResponse) && !firstSelectedSession.oFlags.ContainsKey("x-Unlocked");
                        }
                    }
                    catch (Exception exception2)
                    {
                        FiddlerApplication.LogAddonException(exception2, "Response Inspector Failed");
                    }
                }
            }
        }

        public void actUpdateReport()
        {
            FiddlerApplication.OnCalculateReport(this.GetSelectedSessions());
        }

        private void actUpdateRequest(Session oSession)
        {
            IRequestInspector2 activeRequestInspector = this.GetActiveRequestInspector();
            if ((activeRequestInspector != null) && activeRequestInspector.bDirty)
            {
                this.sbpInfo.Text = "Auto-saved changes to request from " + activeRequestInspector.GetType().ToString() + " at " + DateTime.Now.TimeOfDay.ToString();
                if (activeRequestInspector.headers != null)
                {
                    oSession.oRequest.headers = activeRequestInspector.headers;
                }
                if (activeRequestInspector.body != null)
                {
                    oSession.requestBodyBytes = activeRequestInspector.body;
                    if (oSession.oRequest.headers.Exists("Content-Length"))
                    {
                        oSession.oRequest.headers["Content-Length"] = activeRequestInspector.body.Length.ToString();
                    }
                }
            }
        }

        private void actUpdateResponse(Session oSession)
        {
            IResponseInspector2 activeResponseInspector = this.GetActiveResponseInspector();
            if ((activeResponseInspector != null) && activeResponseInspector.bDirty)
            {
                this.sbpInfo.Text = "Auto-saved changes to response from " + activeResponseInspector.GetType().ToString() + " at " + DateTime.Now.TimeOfDay.ToString();
                if (activeResponseInspector.headers != null)
                {
                    oSession.oResponse.headers = activeResponseInspector.headers;
                }
                if (activeResponseInspector.body != null)
                {
                    oSession.responseBodyBytes = activeResponseInspector.body;
                    if (oSession.oResponse.headers.Exists("Content-Length"))
                    {
                        oSession.oResponse.headers["Content-Length"] = activeResponseInspector.body.Length.ToString();
                    }
                }
            }
        }

        public void actValidateRequest(object sender, CancelEventArgs e)
        {
            if (!FiddlerApplication.isClosing && (this.lvSessions.SelectedItems.Count >= 1))
            {
                Session tag = (Session) this.lvSessions.SelectedItems[0].Tag;
                if (tag != null)
                {
                    this.actUpdateRequest(tag);
                }
            }
        }

        public void actValidateResponse(object sender, CancelEventArgs e)
        {
            if (!FiddlerApplication.isClosing && (this.lvSessions.SelectedItems.Count >= 1))
            {
                Session tag = (Session) this.lvSessions.SelectedItems[0].Tag;
                if (tag != null)
                {
                    this.actUpdateResponse(tag);
                }
            }
        }

        [CodeDescription("Display session properties dialog of the (1) currently selected session.")]
        public void actViewSessionProperties()
        {
            if (CONFIG.IsMicrosoftMachine)
            {
                FiddlerApplication.logSelfHost(80);
            }
            if (this.lvSessions.SelectedItems.Count == 1)
            {
                Session firstSelectedSession = this.GetFirstSelectedSession();
                if (firstSelectedSession != null)
                {
                    new SessionProperties(firstSelectedSession) { Left = base.Left + 250, Top = base.Top + 60 }.Show(this);
                }
            }
        }

        public Session AddReportedSession(byte[] arrRequest, byte[] arrResponse, Stream strmMetadata)
        {
            return this.AddReportedSession(arrRequest, arrResponse, strmMetadata, SessionFlags.None);
        }

        internal Session AddReportedSession(byte[] arrRequest, byte[] arrResponse, Stream strmMetadata, SessionFlags oAdditionalFlags)
        {
            Session oSession = new Session(arrRequest, arrResponse);
            if (strmMetadata != null)
            {
                oSession.LoadMetadata(strmMetadata);
            }
            oSession.BitFlags |= oAdditionalFlags;
            ListViewItem oLVI = new ListViewItem(oSession.id.ToString(), 0) {
                Tag = oSession
            };
            oSession.ViewItem = oLVI;
            oLVI.SubItems.AddRange(new string[] { " - ", oSession.oRequest.headers.UriScheme.ToUpper(), oSession.host, oSession.PathAndQuery, "-1", string.Empty, string.Empty, oSession["SESSION", "x-ProcessInfo"], oSession["SESSION", "ui-comments"], oSession["SESSION", "ui-customcolumn"] });
            oLVI.SubItems.AddRange(this.lvSessions._emptyBoundColumns);
            this.lvSessions.FillBoundColumns(oSession, oLVI);
            this.lvSessions.QueueItem(oLVI);
            this.finishSession(oSession);
            return oSession;
        }

        public void addSession(Session oSession)
        {
            if ((oSession.ViewItem == null) && !oSession.ShouldBeHidden())
            {
                ListViewItem oLVI = new ListViewItem(oSession.id.ToString(), 0);
                if (oSession.state == SessionStates.Aborted)
                {
                    oLVI.ImageIndex = 14;
                }
                oLVI.Tag = oSession;
                oSession.ViewItem = oLVI;
                oLVI.SubItems.AddRange(new string[] { " - ", _obtainScheme(oSession), oSession.host, oSession.PathAndQuery, "-1", string.Empty, string.Empty, oSession["SESSION", "x-ProcessInfo"], oSession["SESSION", "ui-comments"], oSession["SESSION", "ui-customcolumn"] });
                oLVI.SubItems.AddRange(this.lvSessions._emptyBoundColumns);
                this.lvSessions.FillBoundColumns(oSession, oLVI);
                if (oSession.HTTPMethodIs("CONNECT"))
                {
                    oLVI.SubItems[3].Text = "CONNECT";
                }
                this.lvSessions.QueueItem(oLVI);
                if (oSession.oFlags.ContainsKey("x-Builder-Inspect"))
                {
                    this.lvSessions.FlushUpdates();
                    this.lvSessions.SelectedItems.Clear();
                    oSession.ViewItem.Selected = true;
                    oSession.ViewItem.Focused = true;
                    oSession.ViewItem.EnsureVisible();
                    this.tabsViews.SelectedTab = this.pageInspector;
                }
            }
        }

        private void AllPrefChange(object sender, PrefChangeEventArgs oArg)
        {
            MessageBox.Show(sender.ToString() + " pref changed:\n" + oArg.PrefName + ":" + oArg.ValueString, "Preference Change");
        }

        private void btnDecodeResponse_Click(object sender, EventArgs e)
        {
            this.actValidateResponse(sender, null);
            Session firstSelectedSession = this.GetFirstSelectedSession();
            if (firstSelectedSession != null)
            {
                if ((firstSelectedSession.state > SessionStates.ReadingResponse) && (firstSelectedSession.responseBodyBytes != null))
                {
                    firstSelectedSession.utilDecodeResponse();
                    this.actUpdateInspector(false, true);
                }
                else
                {
                    FiddlerApplication.DoNotifyUser("Full response data is not available for decoding.", "Decoding skipped", MessageBoxIcon.Asterisk);
                }
            }
        }

        private void btnSquish_Click(object sender, EventArgs e)
        {
            this.actToggleSquish();
        }

        private void btnTamperSend_Click(object sender, EventArgs e)
        {
            Session firstSelectedSession = this.GetFirstSelectedSession();
            if (firstSelectedSession != null)
            {
                firstSelectedSession.oFlags["x-breakresponse"] = "USERREQUEST";
                firstSelectedSession.bBufferResponse = true;
                this.ResumeBreakpointedSession(firstSelectedSession);
            }
        }

        private void btnTamperSendClient_Click(object sender, EventArgs e)
        {
            Session firstSelectedSession = this.GetFirstSelectedSession();
            if (firstSelectedSession != null)
            {
                firstSelectedSession.oFlags.Remove("x-breakresponse");
                this.ResumeBreakpointedSession(firstSelectedSession);
            }
        }

        private void cbxLoadFrom_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string text;
            Session firstSelectedSession;
            if (this.cbxLoadFrom.SelectedIndex >= 1)
            {
                text = this.cbxLoadFrom.Text;
                if (this.lvSessions.SelectedItems.Count != 1)
                {
                    return;
                }
                firstSelectedSession = this.GetFirstSelectedSession();
                if (firstSelectedSession == null)
                {
                    return;
                }
                if ((firstSelectedSession.state != SessionStates.HandTamperRequest) && (firstSelectedSession.state != SessionStates.HandTamperResponse))
                {
                    return;
                }
                if (!(text == "Find a file..."))
                {
                    goto Label_00C4;
                }
                OpenFileDialog dialog = new OpenFileDialog {
                    DefaultExt = "dat",
                    Title = "Choose response file",
                    Filter = "All Files (*.*)|*.*|Response Files (*.dat)|*.dat"
                };
                if (DialogResult.OK == dialog.ShowDialog(this))
                {
                    this.cbxLoadFrom.Items.Insert(1, dialog.FileName);
                    this.cbxLoadFrom.SelectedIndex = 1;
                    text = dialog.FileName;
                    dialog.Dispose();
                    goto Label_00C4;
                }
                dialog.Dispose();
            }
            return;
        Label_00C4:
            if (firstSelectedSession.state != SessionStates.HandTamperResponse)
            {
                firstSelectedSession.state = SessionStates.HandTamperResponse;
            }
            firstSelectedSession.oResponse = new ServerChatter(firstSelectedSession, "HTTP/1.1 200 OK\r\nServer: Fiddler\r\n\r\n");
            firstSelectedSession.LoadResponseFromFile(text);
            this.actUpdateInspector(false, true);
        }

        [CodeDescription("Copies currently selected sessions to the clipboard.")]
        public void CopySessions(bool HeadersOnly)
        {
            Session[] selectedSessions = this.GetSelectedSessions();
            if (selectedSessions.Length >= 1)
            {
                StringBuilder data = new StringBuilder(0x200);
                StringBuilder builder2 = new StringBuilder(0x200);
                foreach (Session session in selectedSessions)
                {
                    builder2.Append(session.ToHTMLFragment(HeadersOnly));
                    data.Append(session.ToString(HeadersOnly));
                    if (selectedSessions.Length > 1)
                    {
                        builder2.Append("<HR>");
                        data.Append("\r\n------------------------------------------------------------------\r\n");
                    }
                }
                DataObject oData = new DataObject("HTML Format", Utilities.StringToCF_HTML(builder2.ToString()));
                oData.SetData(DataFormats.Text, data);
                Utilities.CopyToClipboard(oData);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        public void finishSession(Session oSession)
        {
            if (oSession != null)
            {
                ListViewItem viewItem = oSession.ViewItem;
                bool flag = oSession.ShouldBeHidden();
                if (!flag && (viewItem == null))
                {
                    if (oSession.responseCode == 0)
                    {
                        return;
                    }
                    this.addSession(oSession);
                    viewItem = oSession.ViewItem;
                }
                if (flag)
                {
                    if (viewItem != null)
                    {
                        oSession.ViewItem = null;
                        this.lvSessions.RemoveOrDequeue(viewItem);
                    }
                }
                else
                {
                    try
                    {
                        this.lvSessions.FillBoundColumns(oSession, viewItem);
                        viewItem.SubItems[2].Text = _obtainScheme(oSession);
                        viewItem.SubItems[1].Text = oSession.responseCode.ToString();
                        viewItem.SubItems[3].Text = oSession.host;
                        viewItem.SubItems[4].Text = oSession.PathAndQuery;
                        viewItem.SubItems[10].Text = oSession.oFlags["ui-customcolumn"];
                        viewItem.SubItems[9].Text = oSession.oFlags["ui-comments"];
                        viewItem.ImageIndex = 4;
                        if (oSession.responseBodyBytes != null)
                        {
                            viewItem.SubItems[5].Text = string.Format("{0:N0}", oSession.responseBodyBytes.LongLength);
                        }
                        else
                        {
                            viewItem.SubItems[5].Text = "0";
                        }
                        string str = string.Empty;
                        if ((oSession.oResponse != null) && (oSession.oResponse.headers != null))
                        {
                            str = oSession.oResponse.headers["Content-Type"];
                            viewItem.SubItems[7].Text = str;
                            viewItem.SubItems[6].Text = string.Empty;
                            if (oSession.oResponse.headers.Exists("Cache-Control"))
                            {
                                viewItem.SubItems[6].Text = oSession.oResponse.headers["Cache-Control"] + "  ";
                            }
                            if (oSession.oResponse.headers.Exists("Expires"))
                            {
                                ListViewItem.ListViewSubItem item1 = viewItem.SubItems[6];
                                item1.Text = item1.Text + "Expires: " + oSession.oResponse.headers["Expires"];
                            }
                        }
                        if (oSession.isTunnel)
                        {
                            if (SessionStates.Aborted != oSession.state)
                            {
                                viewItem.ImageIndex = 13;
                            }
                            else
                            {
                                viewItem.ImageIndex = 14;
                            }
                            if (oSession.HTTPMethodIs("CONNECT"))
                            {
                                viewItem.SubItems[3].Text = "CONNECT";
                                viewItem.ForeColor = System.Drawing.Color.Gray;
                            }
                            else
                            {
                                viewItem.ForeColor = System.Drawing.Color.Olive;
                            }
                        }
                        else if ((oSession.responseCode == 0xcc) || oSession.HTTPMethodIs("HEAD"))
                        {
                            viewItem.ImageIndex = 0x10;
                        }
                        else if (((oSession.responseCode == 0x12d) || (oSession.responseCode == 0x12e)) || ((oSession.responseCode == 0x12f) || (oSession.responseCode == 0x133)))
                        {
                            viewItem.ImageIndex = 10;
                        }
                        else if (oSession.responseCode == 0x130)
                        {
                            viewItem.ForeColor = System.Drawing.Color.Gray;
                            viewItem.ImageIndex = 11;
                        }
                        else if (((oSession.responseCode == 0x191) || (oSession.responseCode == 0x193)) || (oSession.responseCode == 0x197))
                        {
                            viewItem.ImageIndex = 15;
                            viewItem.ForeColor = System.Drawing.Color.Olive;
                        }
                        else if ((oSession.responseCode >= 400) || (oSession.responseCode < 100))
                        {
                            viewItem.ImageIndex = 12;
                            viewItem.ForeColor = System.Drawing.Color.Red;
                        }
                        else if (oSession.HTTPMethodIs("POST"))
                        {
                            viewItem.ImageIndex = 0x20;
                        }
                        else if (str.StartsWith("image/", StringComparison.OrdinalIgnoreCase))
                        {
                            viewItem.ForeColor = System.Drawing.Color.Gray;
                            viewItem.ImageIndex = 5;
                        }
                        else if ((str.StartsWith("application/x-javascript", StringComparison.OrdinalIgnoreCase) || str.StartsWith("application/javascript", StringComparison.OrdinalIgnoreCase)) || str.StartsWith("text/javascript", StringComparison.OrdinalIgnoreCase))
                        {
                            viewItem.ForeColor = System.Drawing.Color.ForestGreen;
                            viewItem.ImageIndex = 6;
                        }
                        else if (str.StartsWith("text/css", StringComparison.OrdinalIgnoreCase))
                        {
                            viewItem.ForeColor = System.Drawing.Color.Purple;
                            viewItem.ImageIndex = 9;
                        }
                        else if (str.StartsWith("text/htm", StringComparison.OrdinalIgnoreCase))
                        {
                            viewItem.ForeColor = System.Drawing.Color.Blue;
                            viewItem.ImageIndex = 8;
                        }
                        else if (str.StartsWith("application/x-shockwave-flash", StringComparison.OrdinalIgnoreCase))
                        {
                            viewItem.ImageIndex = 30;
                        }
                        else if (str.StartsWith("text/xml", StringComparison.OrdinalIgnoreCase) || str.StartsWith("application/xml", StringComparison.OrdinalIgnoreCase))
                        {
                            viewItem.ImageIndex = 7;
                        }
                        else if (str.StartsWith("application/x-silverlight-app", StringComparison.OrdinalIgnoreCase))
                        {
                            viewItem.ImageIndex = 0x1f;
                        }
                        else if (str.StartsWith("audio/", StringComparison.OrdinalIgnoreCase))
                        {
                            viewItem.ImageIndex = 0x1c;
                        }
                        else if (str.StartsWith("video/", StringComparison.OrdinalIgnoreCase))
                        {
                            viewItem.ImageIndex = 0x1b;
                        }
                        else if ((str.StartsWith("font/", StringComparison.OrdinalIgnoreCase) || str.StartsWith("application/vnd.ms-fontobject", StringComparison.OrdinalIgnoreCase)) || str.StartsWith("application/x-woff", StringComparison.OrdinalIgnoreCase))
                        {
                            viewItem.ImageIndex = 0x1d;
                        }
                        else if (str.StartsWith("application/json", StringComparison.OrdinalIgnoreCase))
                        {
                            viewItem.ImageIndex = 0x21;
                        }
                        string sColor = oSession.oFlags["ui-color"];
                        if (sColor != null)
                        {
                            viewItem.ForeColor = Utilities.GetColorFromString(sColor);
                        }
                        sColor = oSession.oFlags["ui-backcolor"];
                        if (sColor != null)
                        {
                            viewItem.BackColor = Utilities.GetColorFromString(sColor);
                        }
                        else if (oSession.isAnyFlagSet(SessionFlags.ImportedFromOtherTool | SessionFlags.LoadedFromSAZ))
                        {
                            viewItem.BackColor = System.Drawing.Color.WhiteSmoke;
                        }
                        if (oSession.oFlags.ContainsKey("ui-bold"))
                        {
                            viewItem.Font = new Font(viewItem.Font, viewItem.Font.Style | FontStyle.Bold);
                        }
                        if (oSession.oFlags.ContainsKey("ui-italic"))
                        {
                            viewItem.Font = new Font(viewItem.Font, viewItem.Font.Style | FontStyle.Italic);
                        }
                        if (oSession.oFlags.ContainsKey("ui-strikeout"))
                        {
                            viewItem.Font = new Font(viewItem.Font, viewItem.Font.Style | FontStyle.Strikeout);
                        }
                        if ((oSession.state == SessionStates.Aborted) && (oSession.oFlags.ContainsKey("X-Fiddler-Aborted") || !oSession.isAnyFlagSet(SessionFlags.RequestGeneratedByFiddler)))
                        {
                            viewItem.ImageIndex = 14;
                        }
                        this.actRefreshInspectorsIfNeeded(oSession);
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        private void frmFloatingInspectors_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.miViewStacked.Enabled = true;
            this.splitterMain.Visible = true;
            this.splitterMain.Dock = DockStyle.Left;
            this.pnlSessions.Dock = DockStyle.Left;
            this.pnlInspector.Dock = DockStyle.Fill;
            this.splitterMain.MinExtra = 50;
            this.pnlSessions.Width = 400;
            this.pnlInspector.Controls.Add(this.tabsViews);
            this.btnSquish.Visible = true;
            this.miViewSquish.Enabled = true;
            this.frmFloatingInspectors = null;
        }

        private void frmViewer_Closing(object sender, CancelEventArgs e)
        {
            FiddlerApplication.isClosing = true;
            FiddlerApplication.Prefs.SetStringPref("fiddler.ui.lastview", FiddlerApplication.UI.tabsViews.SelectedTab.Text);
            oReportingQueueTimer.Stop();
            this.actDetachProxy();
            FiddlerApplication.OnFiddlerShutdown();
            Utilities.UnregisterHotKey(base.Handle, 1);
            CONFIG.SaveSettings(this);
            base.Hide();
           
            FiddlerApplication.oExtensions.Dispose();
            FiddlerApplication._Prefs.Close();
        }

        private void frmViewer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && ((e.KeyCode == Keys.Q) & !e.Control))
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
              
            }
            else if (e.Control)
            {
                float num3;
                switch (e.KeyCode)
                {
                    case Keys.Oemplus:
                        num3 = Math.Min((float) 32f, (float) (this.lvSessions.Font.Size + ((float) 1.0)));
                        this.actSetFontSize(num3);
                        return;

                    case Keys.Oemcomma:
                    case Keys.Right:
                        return;

                    case Keys.OemMinus:
                        num3 = Math.Max((float) 7f, (float) (this.lvSessions.Font.Size - ((float) 1.0)));
                        this.actSetFontSize(num3);
                        return;

                    case Keys.T:
                        this.ActivateRequestInspector("TEXTVIEW");
                        this.ActivateResponseInspector("TEXTVIEW");
                        e.Handled = true;
                        return;

                    case Keys.H:
                        this.ActivateRequestInspector("HEADERS");
                        this.ActivateResponseInspector("HEADERS");
                        e.Handled = true;
                        return;

                    case Keys.Up:
                    {
                        int num2 = this.lvSessions.Items.Count - 1;
                        if (this.lvSessions.SelectedItems.Count > 0)
                        {
                            num2 = this.lvSessions.SelectedIndices[0] - 1;
                        }
                        if (0 <= num2)
                        {
                            FiddlerApplication.SuppressReportUpdates = true;
                            this.lvSessions.SelectedItems.Clear();
                            FiddlerApplication.SuppressReportUpdates = false;
                            this.lvSessions.Items[num2].Selected = true;
                            this.lvSessions.Items[num2].Focused = true;
                            this.lvSessions.Items[num2].EnsureVisible();
                        }
                        e.Handled = true;
                        return;
                    }
                    case Keys.Down:
                    {
                        int num = 0;
                        if (this.lvSessions.SelectedItems.Count > 0)
                        {
                            num = this.lvSessions.SelectedIndices[0] + 1;
                        }
                        if (this.lvSessions.Items.Count > num)
                        {
                            FiddlerApplication.SuppressReportUpdates = true;
                            this.lvSessions.SelectedItems.Clear();
                            FiddlerApplication.SuppressReportUpdates = false;
                            this.lvSessions.Items[num].Selected = true;
                            this.lvSessions.Items[num].Focused = true;
                            this.lvSessions.Items[num].EnsureVisible();
                        }
                        e.Handled = true;
                        return;
                    }
                    case Keys.D0:
                        this.actSetFontSize(8.25f);
                        return;
                }
            }
        }

        private void frmViewer_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            FiddlerApplication.Reporter = new Report();
            FiddlerApplication.Reporter.Parent = this.pageStatistics;
            FiddlerApplication.Reporter.Dock = DockStyle.Fill;
          
            this.actSetFontSize(CONFIG.flFontSize);
            CONFIG.PerformISAFirewallCheck();
            CONFIG.PerformProxySettingsPerUserCheck();
            FiddlerApplication._frmSplash.IndicateProgress("Loading Inspectors...");
            FiddlerApplication.oInspectors = new Inspectors(this.tabsRequest, this.tabsResponse, this);
            FiddlerApplication._frmSplash.IndicateProgress("Loading Extensions...");
          
            CONFIG.EnsureFoldersExist();
            this.dlgSaveZip.InitialDirectory = CONFIG.GetPath("Captures");
            this.dlgLoadZip.InitialDirectory = CONFIG.GetPath("Captures");
            FiddlerApplication.oExtensions = new FiddlerExtensions();
            this._initImportExportMenu();
            this._initDonateMenu();
            if (CONFIG.bLoadScript)
            {
                FiddlerApplication._frmSplash.IndicateProgress("Loading Scripting...");
                FiddlerApplication.scriptRules = new FiddlerScript();
                this.actLoadScripts();
            }
            FiddlerApplication._frmSplash.IndicateProgress("Starting Proxy...");
            if ((FiddlerApplication.oProxy.Start(CONFIG.ListenPort, CONFIG.bAllowRemoteConnections) && CONFIG.bAttachOnBoot) && (Environment.CommandLine.IndexOf("noattach", StringComparison.OrdinalIgnoreCase) < 1))
            {
                FiddlerApplication._frmSplash.IndicateProgress("Attaching...");
                this.actAttachProxy();
            }
            else
            {
                FiddlerApplication._frmSplash.IndicateProgress("Collecting Gateway Information...");
                FiddlerApplication.oProxy.CollectConnectoidAndGatewayInfo();
            }
            this.UpdateUIFromPrefs();
            FiddlerApplication.Prefs.AddWatcher("fiddler.ui.", new EventHandler<PrefChangeEventArgs>(this.OnPrefChange));
          
            this.uihlpUpdateProcessFilterStatus();
            base.SuspendLayout();
            CONFIG.RetrieveFormSettings(this);
            FiddlerToolbar.DisplayIfNeeded();
            this.miViewToolbar.Checked = FiddlerApplication.Prefs.GetBoolPref("fiddler.ui.toolbar.visible", true);
           
            base.ResumeLayout();
            Application.DoEvents();
            if (CONFIG.bIsViewOnly)
            {
                FiddlerApplication.UI.Text = "Fiddler Viewer";
                FiddlerApplication.UI.pnlSessions.BackColor = System.Drawing.Color.FromArgb(200, 220, 250);
               
                FiddlerApplication.UI.miToolsOptions.Enabled = false;
                FiddlerApplication.UI.notifyIcon.Text = "Fiddler Viewer";
                FiddlerApplication.UI.notifyIcon.Icon = Icon.FromHandle(((Bitmap) this.imglSessionIcons.Images[0x13]).GetHicon());
                FiddlerApplication.UI.Icon = Icon.FromHandle(((Bitmap) this.imglSessionIcons.Images[0x13]).GetHicon());
                FiddlerApplication.UI.sbpCapture.Icon = Icon.FromHandle(((Bitmap) this.imglSessionIcons.Images[0x13]).GetHicon());
                FiddlerApplication.UI.sbpCapture.Text = "Viewer Mode";
            }
            if (CONFIG.QuietMode)
            {
                base.ShowInTaskbar = false;
                base.WindowState = FormWindowState.Minimized;
            }
            else
            {
                base.Visible = true;
            }
            FiddlerApplication._frmSplash.Close();
            FiddlerApplication._frmSplash = null;
            if (CONFIG.bAlwaysShowTrayIcon)
            {
                this.notifyIcon.Visible = true;
            }
            if ((CONFIG.bVersionCheck && !CONFIG.QuietMode) && (!CONFIG.bIsViewOnly && (Environment.CommandLine.IndexOf("noversioncheck", StringComparison.OrdinalIgnoreCase) < 1)))
            {
                new Thread(new ThreadStart(this.actCheckForUpdatesQuiet)) { IsBackground = true }.Start();
            }
            FiddlerApplication.OnFiddlerBoot();
            oReportingQueueTimer.Interval = CONFIG.iReporterUpdateInterval;
            oReportingQueueTimer.Tick += new EventHandler(this.oReportingQueueTimer_Tick);
            this.lvSessions.OnSessionsAdded = (SimpleEventHandler) Delegate.Combine(this.lvSessions.OnSessionsAdded, new SimpleEventHandler(this.lvSessions_OnSessionsAdded));
           
            if (!CONFIG.bIsViewOnly)
            {
                Utilities.RegisterHotKey(FiddlerApplication._frmMain.Handle, 1, CONFIG.iHotkeyMod, CONFIG.iHotkey);
            }
            if (!CONFIG.bRevertToDefaultLayout)
            {
                this.actActivateTabByTitle(FiddlerApplication.Prefs.GetStringPref("fiddler.ui.lastview", "Statistics"), FiddlerApplication.UI.tabsViews);
            }
           
            this._LoadAnySAZSpecifiedViaCommandLine();
            this._PingLeaderBoard();
        }

        private IRequestInspector2 GetActiveRequestInspector()
        {
            TabPage selectedTab = this.tabsRequest.SelectedTab;
            if ((selectedTab != null) && (selectedTab.Tag != null))
            {
                return (IRequestInspector2) selectedTab.Tag;
            }
            return null;
        }

        private IResponseInspector2 GetActiveResponseInspector()
        {
            TabPage selectedTab = this.tabsResponse.SelectedTab;
            if ((selectedTab != null) && (selectedTab.Tag != null))
            {
                return (IResponseInspector2) selectedTab.Tag;
            }
            return null;
        }

        [CodeDescription("Returns a Session[] array containing all sessions. Note: returns an empty non-null array if no sessions selected")]
        public Session[] GetAllSessions()
        {
            Session[] sessionArray = new Session[this.lvSessions.Items.Count];
            for (int i = 0; i < sessionArray.Length; i++)
            {
                sessionArray[i] = this.lvSessions.Items[i].Tag as Session;
            }
            return sessionArray;
        }

        public DialogResult GetDecision(frmAlert oAlert)
        {
            oAlert.StartPosition = FormStartPosition.CenterScreen;
            return oAlert.ShowDialog(this);
        }

        private void GetDiffFormattedHeaders(HTTPHeaders h1, HTTPHeaders h2, out string sHeaders1, out string sHeaders2)
        {
            StringBuilder builder = new StringBuilder();
            StringBuilder builder2 = new StringBuilder();
            List<HTTPHeaderItem> list = new List<HTTPHeaderItem>();
            List<HTTPHeaderItem> list2 = new List<HTTPHeaderItem>();
            foreach (HTTPHeaderItem item in h1)
            {
                list.Add((HTTPHeaderItem) item.Clone());
            }
            foreach (HTTPHeaderItem item2 in h2)
            {
                list2.Add((HTTPHeaderItem) item2.Clone());
            }
            foreach (HTTPHeaderItem item3 in list)
            {
                string name = item3.Name;
                string str2 = item3.Value;
                foreach (HTTPHeaderItem item4 in list2)
                {
                    if ((item4.Name == name) && (item4.Value == str2))
                    {
                        builder.AppendFormat("{0}: {1}\r\n", name, str2);
                        builder2.AppendFormat("{0}: {1}\r\n", name, str2);
                        item3.Name = string.Empty;
                        item3.Value = string.Empty;
                        list2.Remove(item4);
                        break;
                    }
                }
            }
            foreach (HTTPHeaderItem item5 in list)
            {
                string str3 = item5.Name;
                string str4 = item5.Value;
                if ((str3 != string.Empty) || (str4 != string.Empty))
                {
                    foreach (HTTPHeaderItem item6 in list2)
                    {
                        if (!(item6.Name == str3))
                        {
                            continue;
                        }
                        int length = this.getFirstMismatchedCharacter(str4, item6.Value);
                        if (length > -1)
                        {
                            builder.AppendFormat("{0}: {1}\r\n>>\t{2}\r\n\r\n", str3, str4.Substring(0, length), str4.Substring(length, str4.Length - length));
                            builder2.AppendFormat("{0}: {1}\r\n>>\t{2}\r\n\r\n", str3, item6.Value.Substring(0, length), item6.Value.Substring(length, item6.Value.Length - length));
                        }
                        else
                        {
                            builder.AppendFormat("{0}: {1}\r\n", str3, str4);
                            builder2.AppendFormat("{0}: {1}\r\n", str3, item6.Value);
                        }
                        item5.Name = string.Empty;
                        item5.Value = string.Empty;
                        list2.Remove(item6);
                        break;
                    }
                    continue;
                }
            }
            foreach (HTTPHeaderItem item7 in list)
            {
                string str5 = item7.Name;
                string str6 = item7.Value;
                if ((str5 != string.Empty) || (str6 != string.Empty))
                {
                    builder.AppendFormat("{0}: {1}\r\n", str5, str6);
                    builder2.AppendLine();
                }
            }
            foreach (HTTPHeaderItem item8 in list2)
            {
                string str7 = item8.Name;
                string str8 = item8.Value;
                builder2.AppendFormat("{0}: {1}\r\n", str7, str8);
                builder.AppendLine();
            }
            sHeaders1 = builder.ToString();
            sHeaders2 = builder2.ToString();
        }

        private int getFirstMismatchedCharacter(string s1, string s2)
        {
            if (s1 == s2)
            {
                return -1;
            }
            int num = 0;
            int length = s1.Length;
            int num3 = s2.Length;
            while ((num < length) && (num < num3))
            {
                if (s1[num] != s2[num])
                {
                    return num;
                }
                num++;
            }
            return num;
        }

        [CodeDescription("Returns the first of the selected sessions, or null if no selected sessions")]
        public Session GetFirstSelectedSession()
        {
            if (this.lvSessions.SelectedItems.Count > 0)
            {
                return (this.lvSessions.SelectedItems[0].Tag as Session);
            }
            return null;
        }

        [CodeDescription("Returns a Session[] array containing all of the selected sessions. Note: returns a non-null empty array if no sessions selected")]
        public Session[] GetSelectedSessions()
        {
            ListView.SelectedListViewItemCollection selectedItems = this.lvSessions.SelectedItems;
            Session[] sessionArray = new Session[selectedItems.Count];
            int index = 0;
            foreach (ListViewItem item in selectedItems)
            {
                sessionArray[index] = item.Tag as Session;
                index++;
            }
            return sessionArray;
        }

        [CodeDescription("Returns a Session[] array containing all (up to specified maximum #) of selected sessions. Note: returns a non-null empty array if no sessions selected")]
        public Session[] GetSelectedSessions(int iMax)
        {
            if (iMax < 0)
            {
                return new Session[0];
            }
            ListView.SelectedListViewItemCollection selectedItems = this.lvSessions.SelectedItems;
            Session[] sessionArray = new Session[Math.Min(iMax, selectedItems.Count)];
            int index = 0;
            foreach (ListViewItem item in selectedItems)
            {
                sessionArray[index] = item.Tag as Session;
                index++;
                if (index >= iMax)
                {
                    return sessionArray;
                }
            }
            return sessionArray;
        }

        internal DialogResult GetUpdateDecision(frmUpdate oUpdatePrompt)
        {
            if (base.InvokeRequired)
            {
                return (DialogResult) base.Invoke(new getUpdateDecisionDelegate(this.GetUpdateDecision), new object[] { oUpdatePrompt });
            }
            return oUpdatePrompt.ShowDialog(this);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmViewer));
            this.mnuMain = new System.Windows.Forms.MainMenu(this.components);
            this.mnuFile = new System.Windows.Forms.MenuItem();
            this.miFileLoad = new System.Windows.Forms.MenuItem();
            this.mnuFileSave = new System.Windows.Forms.MenuItem();
            this.miFileSaveAllSessions = new System.Windows.Forms.MenuItem();
            this.menuItem32 = new System.Windows.Forms.MenuItem();
            this.mnuFileSaveSessions = new System.Windows.Forms.MenuItem();
            this.miFileSaveZip = new System.Windows.Forms.MenuItem();
            this.miFileSaveSession = new System.Windows.Forms.MenuItem();
            this.menuItem26 = new System.Windows.Forms.MenuItem();
            this.miFileSaveHeaders = new System.Windows.Forms.MenuItem();
            this.mnuFileSaveRequest = new System.Windows.Forms.MenuItem();
            this.miFileSaveRequest = new System.Windows.Forms.MenuItem();
            this.miFileSaveRequestBody = new System.Windows.Forms.MenuItem();
            this.mnuFileSaveResponse = new System.Windows.Forms.MenuItem();
            this.miFileSaveResponse = new System.Windows.Forms.MenuItem();
            this.miFileSaveResponseBody = new System.Windows.Forms.MenuItem();
            this.menuItem35 = new System.Windows.Forms.MenuItem();
            this.miFileProperties = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.miFileExit = new System.Windows.Forms.MenuItem();
            this.mnuEdit = new System.Windows.Forms.MenuItem();
            this.mnuEditCopy = new System.Windows.Forms.MenuItem();
            this.miEditCopySession = new System.Windows.Forms.MenuItem();
            this.miEditCopyUrl = new System.Windows.Forms.MenuItem();
            this.miEditCopyHeaders = new System.Windows.Forms.MenuItem();
            this.miEditCopyFullSummary = new System.Windows.Forms.MenuItem();
            this.miEditCopyTerseSummary = new System.Windows.Forms.MenuItem();
            this.mnuEditRemove = new System.Windows.Forms.MenuItem();
            this.miEditRemoveSelected = new System.Windows.Forms.MenuItem();
            this.miEditRemoveUnselected = new System.Windows.Forms.MenuItem();
            this.miEditRemoveAll = new System.Windows.Forms.MenuItem();
            this.miEditSelectAll = new System.Windows.Forms.MenuItem();
            this.miEditSplit1 = new System.Windows.Forms.MenuItem();
            this.mnuEditMark = new System.Windows.Forms.MenuItem();
            this.miEditMarkRed = new System.Windows.Forms.MenuItem();
            this.miEditMarkBlue = new System.Windows.Forms.MenuItem();
            this.miEditMarkGold = new System.Windows.Forms.MenuItem();
            this.miEditMarkGreen = new System.Windows.Forms.MenuItem();
            this.miEditMarkOrange = new System.Windows.Forms.MenuItem();
            this.miEditMarkPurple = new System.Windows.Forms.MenuItem();
            this.menuItem21 = new System.Windows.Forms.MenuItem();
            this.miEditMarkUnmark = new System.Windows.Forms.MenuItem();
            this.miEditDivider = new System.Windows.Forms.MenuItem();
            this.miEditFind = new System.Windows.Forms.MenuItem();
            this.mnuTools = new System.Windows.Forms.MenuItem();
            this.miToolsOptions = new System.Windows.Forms.MenuItem();
            this.miToolsInternetOptions = new System.Windows.Forms.MenuItem();
            this.miToolsSplit1 = new System.Windows.Forms.MenuItem();
            this.miToolsClearCache = new System.Windows.Forms.MenuItem();
            this.miToolsClearCookies = new System.Windows.Forms.MenuItem();
            this.miToolsSplit2 = new System.Windows.Forms.MenuItem();
            this.miToolsEncodeDecode = new System.Windows.Forms.MenuItem();
            this.miToolsCompare = new System.Windows.Forms.MenuItem();
            this.miToolsSplitCustom = new System.Windows.Forms.MenuItem();
            this.mnuView = new System.Windows.Forms.MenuItem();
            this.miViewSquish = new System.Windows.Forms.MenuItem();
            this.miViewStacked = new System.Windows.Forms.MenuItem();
            this.miViewToolbar = new System.Windows.Forms.MenuItem();
            this.miViewSplit1 = new System.Windows.Forms.MenuItem();
            this.miViewStatistics = new System.Windows.Forms.MenuItem();
            this.miViewInspector = new System.Windows.Forms.MenuItem();
            this.miViewSplit2 = new System.Windows.Forms.MenuItem();
            this.miViewMinimizeToTray = new System.Windows.Forms.MenuItem();
            this.miViewStayOnTop = new System.Windows.Forms.MenuItem();
            this.miViewSplit3 = new System.Windows.Forms.MenuItem();
            this.miViewAutoScroll = new System.Windows.Forms.MenuItem();
            this.miViewRefresh = new System.Windows.Forms.MenuItem();
            this.sbStatus = new System.Windows.Forms.StatusBar();
            this.sbpCapture = new System.Windows.Forms.StatusBarPanel();
            this.sbpProcessFilter = new System.Windows.Forms.StatusBarPanel();
            this.sbpBreakpoints = new System.Windows.Forms.StatusBarPanel();
            this.sbpSelCount = new System.Windows.Forms.StatusBarPanel();
            this.sbpInfo = new System.Windows.Forms.StatusBarPanel();
            this.pnlSessions = new System.Windows.Forms.Panel();
            this.mnuSessionContext = new System.Windows.Forms.ContextMenu();
            this.miSessionListScroll = new System.Windows.Forms.MenuItem();
            this.menuItem15 = new System.Windows.Forms.MenuItem();
            this.miSessionCopy = new System.Windows.Forms.MenuItem();
            this.miSessionCopyURL = new System.Windows.Forms.MenuItem();
            this.miSessionCopyColumn = new System.Windows.Forms.MenuItem();
            this.miSessionCopyHeadlines = new System.Windows.Forms.MenuItem();
            this.menuItem19 = new System.Windows.Forms.MenuItem();
            this.miSessionCopyHeaders = new System.Windows.Forms.MenuItem();
            this.menuItem20 = new System.Windows.Forms.MenuItem();
            this.miSessionCopyEntire = new System.Windows.Forms.MenuItem();
            this.miSessionCopySummary = new System.Windows.Forms.MenuItem();
            this.miSessionSave = new System.Windows.Forms.MenuItem();
            this.mnuContextSaveSessions = new System.Windows.Forms.MenuItem();
            this.miSessionSaveToZip = new System.Windows.Forms.MenuItem();
            this.miSessionSaveEntire = new System.Windows.Forms.MenuItem();
            this.menuItem28 = new System.Windows.Forms.MenuItem();
            this.miSessionSaveHeaders = new System.Windows.Forms.MenuItem();
            this.miContextSaveSplitter = new System.Windows.Forms.MenuItem();
            this.mnuContextSaveRequest = new System.Windows.Forms.MenuItem();
            this.miSessionSaveFullRequest = new System.Windows.Forms.MenuItem();
            this.miSessionSaveRequestBody = new System.Windows.Forms.MenuItem();
            this.mnuContextSaveResponse = new System.Windows.Forms.MenuItem();
            this.miSessionSaveFullResponse = new System.Windows.Forms.MenuItem();
            this.miSessionSaveResponseBody = new System.Windows.Forms.MenuItem();
            this.miSessionRemove = new System.Windows.Forms.MenuItem();
            this.miSessionRemoveSelected = new System.Windows.Forms.MenuItem();
            this.miSessionRemoveUnselected = new System.Windows.Forms.MenuItem();
            this.miSessionRemoveAll = new System.Windows.Forms.MenuItem();
            this.miSessionSplit2 = new System.Windows.Forms.MenuItem();
            this.miSessionAddComment = new System.Windows.Forms.MenuItem();
            this.miSessionMark = new System.Windows.Forms.MenuItem();
            this.miSessionMarkRed = new System.Windows.Forms.MenuItem();
            this.miSessionMarkBlue = new System.Windows.Forms.MenuItem();
            this.miSessionMarkGold = new System.Windows.Forms.MenuItem();
            this.miSessionMarkGreen = new System.Windows.Forms.MenuItem();
            this.miSessionMarkOrange = new System.Windows.Forms.MenuItem();
            this.miSessionMarkPurple = new System.Windows.Forms.MenuItem();
            this.miContextMarkSplit = new System.Windows.Forms.MenuItem();
            this.miSessionMarkUnmark = new System.Windows.Forms.MenuItem();
            this.miSessionReplay = new System.Windows.Forms.MenuItem();
            this.miSessionReissueRequests = new System.Windows.Forms.MenuItem();
            this.miSessionReissueUnconditionally = new System.Windows.Forms.MenuItem();
            this.miSessionReissueInIE = new System.Windows.Forms.MenuItem();
            this.miSessionSelect = new System.Windows.Forms.MenuItem();
            this.miSessionSelectParent = new System.Windows.Forms.MenuItem();
            this.miSessionSelectChildren = new System.Windows.Forms.MenuItem();
            this.miSessionSelectDuplicates = new System.Windows.Forms.MenuItem();
            this.miSessionWinDiff = new System.Windows.Forms.MenuItem();
            this.miSessionCOMETPeek = new System.Windows.Forms.MenuItem();
            this.miSessionAbort = new System.Windows.Forms.MenuItem();
            this.miSessionReplayResponse = new System.Windows.Forms.MenuItem();
            this.miSessionUnlock = new System.Windows.Forms.MenuItem();
            this.miSessionSplit = new System.Windows.Forms.MenuItem();
            this.miSessionProperties = new System.Windows.Forms.MenuItem();
            this.imglSessionIcons = new System.Windows.Forms.ImageList(this.components);
            this.btnSquish = new System.Windows.Forms.Button();
            this.lblSessions = new System.Windows.Forms.Label();
            this.splitterMain = new System.Windows.Forms.Splitter();
            this.pnlInspector = new System.Windows.Forms.Panel();
            this.tabsViews = new System.Windows.Forms.TabControl();
            this.pageStatistics = new System.Windows.Forms.TabPage();
            this.pageInspector = new System.Windows.Forms.TabPage();
            this.tabsResponse = new System.Windows.Forms.TabControl();
            this.mnuInspectorsContext = new System.Windows.Forms.ContextMenu();
            this.miInspectorProperties = new System.Windows.Forms.MenuItem();
            this.pnlInfoTip = new System.Windows.Forms.Panel();
            this.btnDecodeResponse = new System.Windows.Forms.Button();
            this.pnlSessionControls = new System.Windows.Forms.Panel();
            this.cbxLoadFrom = new System.Windows.Forms.ComboBox();
            this.lblBreakpoint = new System.Windows.Forms.Label();
            this.btnTamperSendClient = new System.Windows.Forms.Button();
            this.btnTamperSendServer = new System.Windows.Forms.Button();
            this.splitterInspector = new System.Windows.Forms.Splitter();
            this.tabsRequest = new System.Windows.Forms.TabControl();
            this.dlgSaveBinary = new System.Windows.Forms.SaveFileDialog();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.mnuNotify = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miNotifyRestore = new System.Windows.Forms.ToolStripMenuItem();
            this.miNotifyCapturing = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.miNotifyExit = new System.Windows.Forms.ToolStripMenuItem();
            this.dlgSaveZip = new System.Windows.Forms.SaveFileDialog();
            this.dlgLoadZip = new System.Windows.Forms.OpenFileDialog();
            this.imglToolbar = new System.Windows.Forms.ImageList(this.components);
            this.lvSessions = new Fiddler.SessionListView();
            this.colID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colProtocol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHost = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRequest = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colResponseSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colExpires = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colContentType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colProcess = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colComments = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCustom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.sbpCapture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbpProcessFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbpBreakpoints)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbpSelCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbpInfo)).BeginInit();
            this.pnlSessions.SuspendLayout();
            this.pnlInspector.SuspendLayout();
            this.tabsViews.SuspendLayout();
            this.pageInspector.SuspendLayout();
            this.pnlInfoTip.SuspendLayout();
            this.pnlSessionControls.SuspendLayout();
            this.mnuNotify.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuFile,
            this.mnuEdit,
            this.mnuTools,
            this.mnuView});
            // 
            // mnuFile
            // 
            this.mnuFile.Index = 0;
            this.mnuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miFileLoad,
            this.mnuFileSave,
            this.menuItem35,
            this.miFileProperties,
            this.menuItem7,
            this.miFileExit});
            this.mnuFile.Text = "&File";
            this.mnuFile.Popup += new System.EventHandler(this.mnuFile_Popup);
            // 
            // miFileLoad
            // 
            this.miFileLoad.Index = 0;
            this.miFileLoad.Text = "L&oad Archive...";
            this.miFileLoad.Click += new System.EventHandler(this.miFileLoad_Click);
            // 
            // mnuFileSave
            // 
            this.mnuFileSave.Index = 1;
            this.mnuFileSave.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miFileSaveAllSessions,
            this.menuItem32,
            this.mnuFileSaveSessions,
            this.mnuFileSaveRequest,
            this.mnuFileSaveResponse});
            this.mnuFileSave.Text = "&Save";
            this.mnuFileSave.Popup += new System.EventHandler(this.mnuFileSave_Popup);
            // 
            // miFileSaveAllSessions
            // 
            this.miFileSaveAllSessions.Index = 0;
            this.miFileSaveAllSessions.Text = "&All Sessions...";
            this.miFileSaveAllSessions.Click += new System.EventHandler(this.miFileSaveAllSessions_Click);
            // 
            // menuItem32
            // 
            this.menuItem32.Index = 1;
            this.menuItem32.Text = "-";
            // 
            // mnuFileSaveSessions
            // 
            this.mnuFileSaveSessions.Index = 2;
            this.mnuFileSaveSessions.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miFileSaveZip,
            this.miFileSaveSession,
            this.menuItem26,
            this.miFileSaveHeaders});
            this.mnuFileSaveSessions.Text = "Selected &Sessions";
            // 
            // miFileSaveZip
            // 
            this.miFileSaveZip.DefaultItem = true;
            this.miFileSaveZip.Index = 0;
            this.miFileSaveZip.Text = "in Archive&Zip...";
            this.miFileSaveZip.Click += new System.EventHandler(this.miSessionSaveToZip_Click);
            // 
            // miFileSaveSession
            // 
            this.miFileSaveSession.Index = 1;
            this.miFileSaveSession.Text = "as &Text...";
            this.miFileSaveSession.Click += new System.EventHandler(this.miSessionSaveEntire_Click);
            // 
            // menuItem26
            // 
            this.menuItem26.Index = 2;
            this.menuItem26.Text = "-";
            // 
            // miFileSaveHeaders
            // 
            this.miFileSaveHeaders.Index = 3;
            this.miFileSaveHeaders.Text = "as Text (&Headers only)...";
            this.miFileSaveHeaders.Click += new System.EventHandler(this.miSessionSaveHeaders_Click);
            // 
            // mnuFileSaveRequest
            // 
            this.mnuFileSaveRequest.Index = 3;
            this.mnuFileSaveRequest.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miFileSaveRequest,
            this.miFileSaveRequestBody});
            this.mnuFileSaveRequest.Text = "&Request";
            // 
            // miFileSaveRequest
            // 
            this.miFileSaveRequest.Index = 0;
            this.miFileSaveRequest.Text = "&Entire Request...";
            this.miFileSaveRequest.Click += new System.EventHandler(this.miSessionSaveFullRequest_Click);
            // 
            // miFileSaveRequestBody
            // 
            this.miFileSaveRequestBody.Index = 1;
            this.miFileSaveRequestBody.Text = "Request &Body...";
            this.miFileSaveRequestBody.Click += new System.EventHandler(this.miSessionSaveRequestBody_Click);
            // 
            // mnuFileSaveResponse
            // 
            this.mnuFileSaveResponse.Index = 4;
            this.mnuFileSaveResponse.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miFileSaveResponse,
            this.miFileSaveResponseBody});
            this.mnuFileSaveResponse.Text = "R&esponse";
            // 
            // miFileSaveResponse
            // 
            this.miFileSaveResponse.Index = 0;
            this.miFileSaveResponse.Text = "&Entire Response...";
            this.miFileSaveResponse.Click += new System.EventHandler(this.miSessionSaveFullResponse_Click);
            // 
            // miFileSaveResponseBody
            // 
            this.miFileSaveResponseBody.Index = 1;
            this.miFileSaveResponseBody.Text = "&Response Body...";
            this.miFileSaveResponseBody.Click += new System.EventHandler(this.miSessionSaveResponseBody_Click);
            // 
            // menuItem35
            // 
            this.menuItem35.Index = 2;
            this.menuItem35.Text = "-";
            // 
            // miFileProperties
            // 
            this.miFileProperties.Index = 3;
            this.miFileProperties.Text = "&Properties";
            this.miFileProperties.Click += new System.EventHandler(this.miSessionProperties_Click);
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 4;
            this.menuItem7.Text = "-";
            // 
            // miFileExit
            // 
            this.miFileExit.Index = 5;
            this.miFileExit.Text = "E&xit";
            this.miFileExit.Click += new System.EventHandler(this.miExit_Click);
            // 
            // mnuEdit
            // 
            this.mnuEdit.Index = 1;
            this.mnuEdit.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuEditCopy,
            this.mnuEditRemove,
            this.miEditSelectAll,
            this.miEditSplit1,
            this.mnuEditMark,
            this.miEditDivider,
            this.miEditFind});
            this.mnuEdit.Text = "&Edit";
            this.mnuEdit.Popup += new System.EventHandler(this.mnuEdit_Popup);
            // 
            // mnuEditCopy
            // 
            this.mnuEditCopy.Index = 0;
            this.mnuEditCopy.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miEditCopySession,
            this.miEditCopyUrl,
            this.miEditCopyHeaders,
            this.miEditCopyFullSummary,
            this.miEditCopyTerseSummary});
            this.mnuEditCopy.Text = "&Copy";
            // 
            // miEditCopySession
            // 
            this.miEditCopySession.Index = 0;
            this.miEditCopySession.Text = "&Session";
            this.miEditCopySession.Click += new System.EventHandler(this.miSessionCopyEntire_Click);
            // 
            // miEditCopyUrl
            // 
            this.miEditCopyUrl.Index = 1;
            this.miEditCopyUrl.Text = "Just &Url";
            this.miEditCopyUrl.Click += new System.EventHandler(this.miSessionCopyURL_Click);
            // 
            // miEditCopyHeaders
            // 
            this.miEditCopyHeaders.Index = 2;
            this.miEditCopyHeaders.Text = "&Headers only";
            this.miEditCopyHeaders.Click += new System.EventHandler(this.miSessionCopyHeaders_Click);
            // 
            // miEditCopyFullSummary
            // 
            this.miEditCopyFullSummary.Index = 3;
            this.miEditCopyFullSummary.Text = "&Full Summary";
            this.miEditCopyFullSummary.Click += new System.EventHandler(this.miSessionCopySummary_Click);
            // 
            // miEditCopyTerseSummary
            // 
            this.miEditCopyTerseSummary.Index = 4;
            this.miEditCopyTerseSummary.Text = "&Terse Summary";
            this.miEditCopyTerseSummary.Click += new System.EventHandler(this.miSessionCopyHeadlines_Click);
            // 
            // mnuEditRemove
            // 
            this.mnuEditRemove.Index = 1;
            this.mnuEditRemove.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miEditRemoveSelected,
            this.miEditRemoveUnselected,
            this.miEditRemoveAll});
            this.mnuEditRemove.Text = "&Remove";
            this.mnuEditRemove.Popup += new System.EventHandler(this.mnuEditRemove_Popup);
            // 
            // miEditRemoveSelected
            // 
            this.miEditRemoveSelected.Index = 0;
            this.miEditRemoveSelected.Text = "&Selected Sessions\tDel";
            this.miEditRemoveSelected.Click += new System.EventHandler(this.miSessionRemoveSelected_Click);
            // 
            // miEditRemoveUnselected
            // 
            this.miEditRemoveUnselected.Index = 1;
            this.miEditRemoveUnselected.Text = "&Unselected Sessions\tShift+Del";
            this.miEditRemoveUnselected.Click += new System.EventHandler(this.miSessionRemoveUnselected_Click);
            // 
            // miEditRemoveAll
            // 
            this.miEditRemoveAll.Index = 2;
            this.miEditRemoveAll.Text = "&All Sessions\tCtrl+X";
            this.miEditRemoveAll.Click += new System.EventHandler(this.miSessionRemoveAll_Click);
            // 
            // miEditSelectAll
            // 
            this.miEditSelectAll.Index = 2;
            this.miEditSelectAll.Text = "Select &All";
            this.miEditSelectAll.Click += new System.EventHandler(this.miEditSelectAll_Click);
            // 
            // miEditSplit1
            // 
            this.miEditSplit1.Index = 3;
            this.miEditSplit1.Text = "-";
            // 
            // mnuEditMark
            // 
            this.mnuEditMark.Index = 4;
            this.mnuEditMark.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miEditMarkRed,
            this.miEditMarkBlue,
            this.miEditMarkGold,
            this.miEditMarkGreen,
            this.miEditMarkOrange,
            this.miEditMarkPurple,
            this.menuItem21,
            this.miEditMarkUnmark});
            this.mnuEditMark.Text = "&Mark";
            // 
            // miEditMarkRed
            // 
            this.miEditMarkRed.Index = 0;
            this.miEditMarkRed.Text = "&Red";
            this.miEditMarkRed.Click += new System.EventHandler(this.miSessionMarkColor_Click);
            // 
            // miEditMarkBlue
            // 
            this.miEditMarkBlue.Index = 1;
            this.miEditMarkBlue.Text = "&Blue";
            this.miEditMarkBlue.Click += new System.EventHandler(this.miSessionMarkColor_Click);
            // 
            // miEditMarkGold
            // 
            this.miEditMarkGold.Index = 2;
            this.miEditMarkGold.Text = "Gol&d";
            this.miEditMarkGold.Click += new System.EventHandler(this.miSessionMarkColor_Click);
            // 
            // miEditMarkGreen
            // 
            this.miEditMarkGreen.Index = 3;
            this.miEditMarkGreen.Text = "&Green";
            this.miEditMarkGreen.Click += new System.EventHandler(this.miSessionMarkColor_Click);
            // 
            // miEditMarkOrange
            // 
            this.miEditMarkOrange.Index = 4;
            this.miEditMarkOrange.Text = "&Orange";
            this.miEditMarkOrange.Click += new System.EventHandler(this.miSessionMarkColor_Click);
            // 
            // miEditMarkPurple
            // 
            this.miEditMarkPurple.Index = 5;
            this.miEditMarkPurple.Text = "&Purple";
            this.miEditMarkPurple.Click += new System.EventHandler(this.miSessionMarkColor_Click);
            // 
            // menuItem21
            // 
            this.menuItem21.Index = 6;
            this.menuItem21.Text = "-";
            // 
            // miEditMarkUnmark
            // 
            this.miEditMarkUnmark.Index = 7;
            this.miEditMarkUnmark.Text = "&Unmark";
            this.miEditMarkUnmark.Click += new System.EventHandler(this.miSessionMarkColor_Click);
            // 
            // miEditDivider
            // 
            this.miEditDivider.Index = 5;
            this.miEditDivider.Text = "-";
            // 
            // miEditFind
            // 
            this.miEditFind.Index = 6;
            this.miEditFind.Shortcut = System.Windows.Forms.Shortcut.CtrlF;
            this.miEditFind.Text = "&Find Sessions...";
            this.miEditFind.Click += new System.EventHandler(this.miToolsFind_Click);
            // 
            // mnuTools
            // 
            this.mnuTools.Index = 2;
            this.mnuTools.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miToolsOptions,
            this.miToolsInternetOptions,
            this.miToolsSplit1,
            this.miToolsClearCache,
            this.miToolsClearCookies,
            this.miToolsSplit2,
            this.miToolsEncodeDecode,
            this.miToolsCompare,
            this.miToolsSplitCustom});
            this.mnuTools.Text = "&Tools";
            this.mnuTools.Popup += new System.EventHandler(this.mnuTools_Popup);
            // 
            // miToolsOptions
            // 
            this.miToolsOptions.Index = 0;
            this.miToolsOptions.Text = "&Fiddler Options...";
            this.miToolsOptions.Click += new System.EventHandler(this.miToolsOptions_Click);
            // 
            // miToolsInternetOptions
            // 
            this.miToolsInternetOptions.Index = 1;
            this.miToolsInternetOptions.Text = "WinINET &Options...";
            this.miToolsInternetOptions.Click += new System.EventHandler(this.miToolsInternetOptions_Click);
            // 
            // miToolsSplit1
            // 
            this.miToolsSplit1.Index = 2;
            this.miToolsSplit1.Text = "-";
            // 
            // miToolsClearCache
            // 
            this.miToolsClearCache.Index = 3;
            this.miToolsClearCache.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftX;
            this.miToolsClearCache.Text = "&Clear WinINET Cache";
            this.miToolsClearCache.Click += new System.EventHandler(this.miToolsClearCache_Click);
            // 
            // miToolsClearCookies
            // 
            this.miToolsClearCookies.Index = 4;
            this.miToolsClearCookies.Text = "Clear WinINET Coo&kies";
            this.miToolsClearCookies.Click += new System.EventHandler(this.miToolsClearCookies_Click);
            // 
            // miToolsSplit2
            // 
            this.miToolsSplit2.Index = 5;
            this.miToolsSplit2.Text = "-";
            // 
            // miToolsEncodeDecode
            // 
            this.miToolsEncodeDecode.Index = 6;
            this.miToolsEncodeDecode.Shortcut = System.Windows.Forms.Shortcut.CtrlE;
            this.miToolsEncodeDecode.Text = "Text &Encode/Decode...";
            this.miToolsEncodeDecode.Click += new System.EventHandler(this.miToolsBase64_Click);
            // 
            // miToolsCompare
            // 
            this.miToolsCompare.Index = 7;
            this.miToolsCompare.Text = "Co&mpare Sessions";
            this.miToolsCompare.Click += new System.EventHandler(this.miSessionWinDiff_Click);
            // 
            // miToolsSplitCustom
            // 
            this.miToolsSplitCustom.Index = 8;
            this.miToolsSplitCustom.Text = "-";
            // 
            // mnuView
            // 
            this.mnuView.Index = 3;
            this.mnuView.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miViewSquish,
            this.miViewStacked,
            this.miViewToolbar,
            this.miViewSplit1,
            this.miViewStatistics,
            this.miViewInspector,
            this.miViewSplit2,
            this.miViewMinimizeToTray,
            this.miViewStayOnTop,
            this.miViewSplit3,
            this.miViewAutoScroll,
            this.miViewRefresh});
            this.mnuView.Text = "&View";
            // 
            // miViewSquish
            // 
            this.miViewSquish.Index = 0;
            this.miViewSquish.Shortcut = System.Windows.Forms.Shortcut.F6;
            this.miViewSquish.Text = "Squish Session &List";
            this.miViewSquish.Click += new System.EventHandler(this.miSquish_Click);
            // 
            // miViewStacked
            // 
            this.miViewStacked.Index = 1;
            this.miViewStacked.Text = "Stac&ked Layout";
            this.miViewStacked.Click += new System.EventHandler(this.miViewStacked_Click);
            // 
            // miViewToolbar
            // 
            this.miViewToolbar.Checked = true;
            this.miViewToolbar.Index = 2;
            this.miViewToolbar.Text = "Sho&w Toolbar";
            this.miViewToolbar.Click += new System.EventHandler(this.miViewToolbar_Click);
            // 
            // miViewSplit1
            // 
            this.miViewSplit1.Index = 3;
            this.miViewSplit1.Text = "-";
            // 
            // miViewStatistics
            // 
            this.miViewStatistics.Index = 4;
            this.miViewStatistics.Shortcut = System.Windows.Forms.Shortcut.F7;
            this.miViewStatistics.Text = "&Statistics";
            this.miViewStatistics.Click += new System.EventHandler(this.miViewStatistics_Click);
            // 
            // miViewInspector
            // 
            this.miViewInspector.Index = 5;
            this.miViewInspector.Shortcut = System.Windows.Forms.Shortcut.F8;
            this.miViewInspector.Text = "&Inspector";
            this.miViewInspector.Click += new System.EventHandler(this.miViewInspector_Click);
            // 
            // miViewSplit2
            // 
            this.miViewSplit2.Index = 6;
            this.miViewSplit2.Text = "-";
            // 
            // miViewMinimizeToTray
            // 
            this.miViewMinimizeToTray.Index = 7;
            this.miViewMinimizeToTray.Shortcut = System.Windows.Forms.Shortcut.CtrlM;
            this.miViewMinimizeToTray.Text = "&Minimize to Tray";
            this.miViewMinimizeToTray.Click += new System.EventHandler(this.miFileMinimizeToTray_Click);
            // 
            // miViewStayOnTop
            // 
            this.miViewStayOnTop.Index = 8;
            this.miViewStayOnTop.Text = "Stay on &Top";
            this.miViewStayOnTop.Click += new System.EventHandler(this.miViewStayOnTop_Click);
            // 
            // miViewSplit3
            // 
            this.miViewSplit3.Index = 9;
            this.miViewSplit3.Text = "-";
            // 
            // miViewAutoScroll
            // 
            this.miViewAutoScroll.Checked = true;
            this.miViewAutoScroll.Index = 10;
            this.miViewAutoScroll.Text = "&AutoScroll Session List";
            this.miViewAutoScroll.Click += new System.EventHandler(this.miViewAutoScroll_Click);
            // 
            // miViewRefresh
            // 
            this.miViewRefresh.Index = 11;
            this.miViewRefresh.Shortcut = System.Windows.Forms.Shortcut.F5;
            this.miViewRefresh.Text = "&Refresh";
            this.miViewRefresh.Click += new System.EventHandler(this.miViewRefresh_Click);
            // 
            // sbStatus
            // 
            this.sbStatus.Location = new System.Drawing.Point(0, 304);
            this.sbStatus.Name = "sbStatus";
            this.sbStatus.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.sbpCapture,
            this.sbpProcessFilter,
            this.sbpBreakpoints,
            this.sbpSelCount,
            this.sbpInfo});
            this.sbStatus.ShowPanels = true;
            this.sbStatus.Size = new System.Drawing.Size(1000, 22);
            this.sbStatus.TabIndex = 0;
            this.sbStatus.PanelClick += new System.Windows.Forms.StatusBarPanelClickEventHandler(this.sbStatus_PanelClick);
            this.sbStatus.MouseMove += new System.Windows.Forms.MouseEventHandler(this.sbStatus_MouseMove);
            // 
            // sbpCapture
            // 
            this.sbpCapture.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            this.sbpCapture.Icon = global::Fiddler.Properties.Resources.sbpCapture_Icon;
            this.sbpCapture.MinWidth = 85;
            this.sbpCapture.Name = "sbpCapture";
            this.sbpCapture.Style = System.Windows.Forms.StatusBarPanelStyle.OwnerDraw;
            this.sbpCapture.Width = 85;
            // 
            // sbpProcessFilter
            // 
            this.sbpProcessFilter.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            this.sbpProcessFilter.MinWidth = 110;
            this.sbpProcessFilter.Name = "sbpProcessFilter";
            this.sbpProcessFilter.Text = "All Processes";
            this.sbpProcessFilter.Width = 110;
            // 
            // sbpBreakpoints
            // 
            this.sbpBreakpoints.Icon = global::Fiddler.Properties.Resources.sbpBreakpoints_Icon;
            this.sbpBreakpoints.MinWidth = 22;
            this.sbpBreakpoints.Name = "sbpBreakpoints";
            this.sbpBreakpoints.Style = System.Windows.Forms.StatusBarPanelStyle.OwnerDraw;
            this.sbpBreakpoints.Width = 22;
            // 
            // sbpSelCount
            // 
            this.sbpSelCount.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.sbpSelCount.MinWidth = 50;
            this.sbpSelCount.Name = "sbpSelCount";
            this.sbpSelCount.ToolTipText = "Number of sessions";
            this.sbpSelCount.Width = 80;
            // 
            // sbpInfo
            // 
            this.sbpInfo.BorderStyle = System.Windows.Forms.StatusBarPanelBorderStyle.None;
            this.sbpInfo.Name = "sbpInfo";
            this.sbpInfo.Width = 1000;
            // 
            // pnlSessions
            // 
            this.pnlSessions.BackColor = System.Drawing.SystemColors.Control;
            this.pnlSessions.Controls.Add(this.lvSessions);
            this.pnlSessions.Controls.Add(this.btnSquish);
            this.pnlSessions.Controls.Add(this.lblSessions);
            this.pnlSessions.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSessions.Location = new System.Drawing.Point(0, 0);
            this.pnlSessions.Name = "pnlSessions";
            this.pnlSessions.Size = new System.Drawing.Size(400, 304);
            this.pnlSessions.TabIndex = 1;
            // 
            // mnuSessionContext
            // 
            this.mnuSessionContext.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miSessionListScroll,
            this.menuItem15,
            this.miSessionCopy,
            this.miSessionSave,
            this.miSessionRemove,
            this.miSessionSplit2,
            this.miSessionAddComment,
            this.miSessionMark,
            this.miSessionReplay,
            this.miSessionSelect,
            this.miSessionWinDiff,
            this.miSessionCOMETPeek,
            this.miSessionAbort,
            this.miSessionReplayResponse,
            this.miSessionUnlock,
            this.miSessionSplit,
            this.miSessionProperties});
            this.mnuSessionContext.Popup += new System.EventHandler(this.mnuSessionContext_Popup);
            // 
            // miSessionListScroll
            // 
            this.miSessionListScroll.Checked = true;
            this.miSessionListScroll.Index = 0;
            this.miSessionListScroll.Text = "AutoScroll Session List";
            this.miSessionListScroll.Click += new System.EventHandler(this.miSessionListScroll_Click);
            // 
            // menuItem15
            // 
            this.menuItem15.Index = 1;
            this.menuItem15.Text = "-";
            // 
            // miSessionCopy
            // 
            this.miSessionCopy.Index = 2;
            this.miSessionCopy.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miSessionCopyURL,
            this.miSessionCopyColumn,
            this.miSessionCopyHeadlines,
            this.menuItem19,
            this.miSessionCopyHeaders,
            this.menuItem20,
            this.miSessionCopyEntire,
            this.miSessionCopySummary});
            this.miSessionCopy.Text = "&Copy";
            // 
            // miSessionCopyURL
            // 
            this.miSessionCopyURL.Index = 0;
            this.miSessionCopyURL.Shortcut = System.Windows.Forms.Shortcut.CtrlU;
            this.miSessionCopyURL.Text = "Just &Url";
            this.miSessionCopyURL.Click += new System.EventHandler(this.miSessionCopyURL_Click);
            // 
            // miSessionCopyColumn
            // 
            this.miSessionCopyColumn.Index = 1;
            this.miSessionCopyColumn.Text = "This &Column";
            this.miSessionCopyColumn.Click += new System.EventHandler(this.miSessionCopyColumn_Click);
            // 
            // miSessionCopyHeadlines
            // 
            this.miSessionCopyHeadlines.Index = 2;
            this.miSessionCopyHeadlines.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftT;
            this.miSessionCopyHeadlines.Text = "&Terse Summary";
            this.miSessionCopyHeadlines.Click += new System.EventHandler(this.miSessionCopyHeadlines_Click);
            // 
            // menuItem19
            // 
            this.menuItem19.Index = 3;
            this.menuItem19.Text = "-";
            // 
            // miSessionCopyHeaders
            // 
            this.miSessionCopyHeaders.DefaultItem = true;
            this.miSessionCopyHeaders.Index = 4;
            this.miSessionCopyHeaders.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftC;
            this.miSessionCopyHeaders.Text = "&Headers only";
            this.miSessionCopyHeaders.Click += new System.EventHandler(this.miSessionCopyHeaders_Click);
            // 
            // menuItem20
            // 
            this.menuItem20.Index = 5;
            this.menuItem20.Text = "-";
            // 
            // miSessionCopyEntire
            // 
            this.miSessionCopyEntire.Index = 6;
            this.miSessionCopyEntire.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftS;
            this.miSessionCopyEntire.Text = "&Session";
            this.miSessionCopyEntire.Click += new System.EventHandler(this.miSessionCopyEntire_Click);
            // 
            // miSessionCopySummary
            // 
            this.miSessionCopySummary.Index = 7;
            this.miSessionCopySummary.Shortcut = System.Windows.Forms.Shortcut.CtrlC;
            this.miSessionCopySummary.Text = "&Full Summary";
            this.miSessionCopySummary.Click += new System.EventHandler(this.miSessionCopySummary_Click);
            // 
            // miSessionSave
            // 
            this.miSessionSave.Index = 3;
            this.miSessionSave.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuContextSaveSessions,
            this.miContextSaveSplitter,
            this.mnuContextSaveRequest,
            this.mnuContextSaveResponse});
            this.miSessionSave.Text = "&Save";
            // 
            // mnuContextSaveSessions
            // 
            this.mnuContextSaveSessions.Index = 0;
            this.mnuContextSaveSessions.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miSessionSaveToZip,
            this.miSessionSaveEntire,
            this.menuItem28,
            this.miSessionSaveHeaders});
            this.mnuContextSaveSessions.Text = "Selected &Sessions";
            // 
            // miSessionSaveToZip
            // 
            this.miSessionSaveToZip.DefaultItem = true;
            this.miSessionSaveToZip.Index = 0;
            this.miSessionSaveToZip.Text = "in Archive&ZIP...";
            this.miSessionSaveToZip.Click += new System.EventHandler(this.miSessionSaveToZip_Click);
            // 
            // miSessionSaveEntire
            // 
            this.miSessionSaveEntire.Index = 1;
            this.miSessionSaveEntire.Text = "as Text...";
            this.miSessionSaveEntire.Click += new System.EventHandler(this.miSessionSaveEntire_Click);
            // 
            // menuItem28
            // 
            this.menuItem28.Index = 2;
            this.menuItem28.Text = "-";
            // 
            // miSessionSaveHeaders
            // 
            this.miSessionSaveHeaders.Index = 3;
            this.miSessionSaveHeaders.Text = "as Text (&Headers only)...";
            this.miSessionSaveHeaders.Click += new System.EventHandler(this.miSessionSaveHeaders_Click);
            // 
            // miContextSaveSplitter
            // 
            this.miContextSaveSplitter.Index = 1;
            this.miContextSaveSplitter.Text = "-";
            // 
            // mnuContextSaveRequest
            // 
            this.mnuContextSaveRequest.Index = 2;
            this.mnuContextSaveRequest.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miSessionSaveFullRequest,
            this.miSessionSaveRequestBody});
            this.mnuContextSaveRequest.Text = "&Request";
            // 
            // miSessionSaveFullRequest
            // 
            this.miSessionSaveFullRequest.DefaultItem = true;
            this.miSessionSaveFullRequest.Index = 0;
            this.miSessionSaveFullRequest.Text = "&Entire Request...";
            this.miSessionSaveFullRequest.Click += new System.EventHandler(this.miSessionSaveFullRequest_Click);
            // 
            // miSessionSaveRequestBody
            // 
            this.miSessionSaveRequestBody.Index = 1;
            this.miSessionSaveRequestBody.Text = "Request &Body...";
            this.miSessionSaveRequestBody.Click += new System.EventHandler(this.miSessionSaveRequestBody_Click);
            // 
            // mnuContextSaveResponse
            // 
            this.mnuContextSaveResponse.Index = 3;
            this.mnuContextSaveResponse.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miSessionSaveFullResponse,
            this.miSessionSaveResponseBody});
            this.mnuContextSaveResponse.Text = "R&esponse";
            // 
            // miSessionSaveFullResponse
            // 
            this.miSessionSaveFullResponse.Index = 0;
            this.miSessionSaveFullResponse.Text = "&Entire Response...";
            this.miSessionSaveFullResponse.Click += new System.EventHandler(this.miSessionSaveFullResponse_Click);
            // 
            // miSessionSaveResponseBody
            // 
            this.miSessionSaveResponseBody.DefaultItem = true;
            this.miSessionSaveResponseBody.Index = 1;
            this.miSessionSaveResponseBody.Text = "&Response Body...";
            this.miSessionSaveResponseBody.Click += new System.EventHandler(this.miSessionSaveResponseBody_Click);
            // 
            // miSessionRemove
            // 
            this.miSessionRemove.Index = 4;
            this.miSessionRemove.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miSessionRemoveSelected,
            this.miSessionRemoveUnselected,
            this.miSessionRemoveAll});
            this.miSessionRemove.Text = "&Remove";
            // 
            // miSessionRemoveSelected
            // 
            this.miSessionRemoveSelected.Index = 0;
            this.miSessionRemoveSelected.Shortcut = System.Windows.Forms.Shortcut.Del;
            this.miSessionRemoveSelected.Text = "&Selected Sessions";
            this.miSessionRemoveSelected.Click += new System.EventHandler(this.miSessionRemoveSelected_Click);
            // 
            // miSessionRemoveUnselected
            // 
            this.miSessionRemoveUnselected.Index = 1;
            this.miSessionRemoveUnselected.Shortcut = System.Windows.Forms.Shortcut.ShiftDel;
            this.miSessionRemoveUnselected.Text = "&Unselected Sessions";
            this.miSessionRemoveUnselected.Click += new System.EventHandler(this.miSessionRemoveUnselected_Click);
            // 
            // miSessionRemoveAll
            // 
            this.miSessionRemoveAll.Index = 2;
            this.miSessionRemoveAll.Shortcut = System.Windows.Forms.Shortcut.CtrlX;
            this.miSessionRemoveAll.Text = "&All Sessions";
            this.miSessionRemoveAll.Click += new System.EventHandler(this.miSessionRemoveAll_Click);
            // 
            // miSessionSplit2
            // 
            this.miSessionSplit2.Index = 5;
            this.miSessionSplit2.Text = "-";
            // 
            // miSessionAddComment
            // 
            this.miSessionAddComment.Index = 6;
            this.miSessionAddComment.Text = "Commen&t...";
            this.miSessionAddComment.Click += new System.EventHandler(this.miSessionAddComment_Click);
            // 
            // miSessionMark
            // 
            this.miSessionMark.Index = 7;
            this.miSessionMark.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miSessionMarkRed,
            this.miSessionMarkBlue,
            this.miSessionMarkGold,
            this.miSessionMarkGreen,
            this.miSessionMarkOrange,
            this.miSessionMarkPurple,
            this.miContextMarkSplit,
            this.miSessionMarkUnmark});
            this.miSessionMark.Text = "&Mark";
            // 
            // miSessionMarkRed
            // 
            this.miSessionMarkRed.Index = 0;
            this.miSessionMarkRed.Shortcut = System.Windows.Forms.Shortcut.Ctrl1;
            this.miSessionMarkRed.Text = "&Red";
            this.miSessionMarkRed.Click += new System.EventHandler(this.miSessionMarkColor_Click);
            // 
            // miSessionMarkBlue
            // 
            this.miSessionMarkBlue.Index = 1;
            this.miSessionMarkBlue.Shortcut = System.Windows.Forms.Shortcut.Ctrl2;
            this.miSessionMarkBlue.Text = "&Blue";
            this.miSessionMarkBlue.Click += new System.EventHandler(this.miSessionMarkColor_Click);
            // 
            // miSessionMarkGold
            // 
            this.miSessionMarkGold.Index = 2;
            this.miSessionMarkGold.Shortcut = System.Windows.Forms.Shortcut.Ctrl3;
            this.miSessionMarkGold.Text = "Gol&d";
            this.miSessionMarkGold.Click += new System.EventHandler(this.miSessionMarkColor_Click);
            // 
            // miSessionMarkGreen
            // 
            this.miSessionMarkGreen.Index = 3;
            this.miSessionMarkGreen.Shortcut = System.Windows.Forms.Shortcut.Ctrl4;
            this.miSessionMarkGreen.Text = "&Green";
            this.miSessionMarkGreen.Click += new System.EventHandler(this.miSessionMarkColor_Click);
            // 
            // miSessionMarkOrange
            // 
            this.miSessionMarkOrange.Index = 4;
            this.miSessionMarkOrange.Shortcut = System.Windows.Forms.Shortcut.Ctrl5;
            this.miSessionMarkOrange.Text = "&Orange";
            this.miSessionMarkOrange.Click += new System.EventHandler(this.miSessionMarkColor_Click);
            // 
            // miSessionMarkPurple
            // 
            this.miSessionMarkPurple.Index = 5;
            this.miSessionMarkPurple.Shortcut = System.Windows.Forms.Shortcut.Ctrl6;
            this.miSessionMarkPurple.Text = "&Purple";
            this.miSessionMarkPurple.Click += new System.EventHandler(this.miSessionMarkColor_Click);
            // 
            // miContextMarkSplit
            // 
            this.miContextMarkSplit.Index = 6;
            this.miContextMarkSplit.Text = "-";
            // 
            // miSessionMarkUnmark
            // 
            this.miSessionMarkUnmark.Index = 7;
            this.miSessionMarkUnmark.Shortcut = System.Windows.Forms.Shortcut.Ctrl0;
            this.miSessionMarkUnmark.Text = "&Unmark";
            this.miSessionMarkUnmark.Click += new System.EventHandler(this.miSessionMarkColor_Click);
            // 
            // miSessionReplay
            // 
            this.miSessionReplay.Index = 8;
            this.miSessionReplay.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miSessionReissueRequests,
            this.miSessionReissueUnconditionally,
            this.miSessionReissueInIE});
            this.miSessionReplay.Text = "R&eplay";
            // 
            // miSessionReissueRequests
            // 
            this.miSessionReissueRequests.Index = 0;
            this.miSessionReissueRequests.Text = "Reissue &Requests";
            this.miSessionReissueRequests.Click += new System.EventHandler(this.miSessionReissueRequests_Click);
            // 
            // miSessionReissueUnconditionally
            // 
            this.miSessionReissueUnconditionally.Index = 1;
            this.miSessionReissueUnconditionally.Text = "Reissue &Unconditionally";
            this.miSessionReissueUnconditionally.Click += new System.EventHandler(this.miSessionReissueUnconditionally_Click);
            // 
            // miSessionReissueInIE
            // 
            this.miSessionReissueInIE.Index = 2;
            this.miSessionReissueInIE.Text = "Revisit in &IE";
            this.miSessionReissueInIE.Click += new System.EventHandler(this.miSessionReissueInIE_Click);
            // 
            // miSessionSelect
            // 
            this.miSessionSelect.Index = 9;
            this.miSessionSelect.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miSessionSelectParent,
            this.miSessionSelectChildren,
            this.miSessionSelectDuplicates});
            this.miSessionSelect.Text = "Se&lect";
            // 
            // miSessionSelectParent
            // 
            this.miSessionSelectParent.Index = 0;
            this.miSessionSelectParent.Text = "&Parent Request";
            this.miSessionSelectParent.Click += new System.EventHandler(this.miSessionSelectParent_Click);
            // 
            // miSessionSelectChildren
            // 
            this.miSessionSelectChildren.Index = 1;
            this.miSessionSelectChildren.Text = "&Child Requests";
            this.miSessionSelectChildren.Click += new System.EventHandler(this.miSessionSelectChildren_Click);
            // 
            // miSessionSelectDuplicates
            // 
            this.miSessionSelectDuplicates.Index = 2;
            this.miSessionSelectDuplicates.Text = "&Duplicate Requests";
            this.miSessionSelectDuplicates.Click += new System.EventHandler(this.miSessionSelectDuplicates_Click);
            // 
            // miSessionWinDiff
            // 
            this.miSessionWinDiff.Index = 10;
            this.miSessionWinDiff.Shortcut = System.Windows.Forms.Shortcut.CtrlW;
            this.miSessionWinDiff.Text = "C&ompare";
            this.miSessionWinDiff.Click += new System.EventHandler(this.miSessionWinDiff_Click);
            // 
            // miSessionCOMETPeek
            // 
            this.miSessionCOMETPeek.Index = 11;
            this.miSessionCOMETPeek.Text = "COMETPeek";
            this.miSessionCOMETPeek.Click += new System.EventHandler(this.miSessionCOMETPeek_Click);
            // 
            // miSessionAbort
            // 
            this.miSessionAbort.Index = 12;
            this.miSessionAbort.Text = "Abort Session";
            this.miSessionAbort.Click += new System.EventHandler(this.miSessionAbort_Click);
            // 
            // miSessionReplayResponse
            // 
            this.miSessionReplayResponse.Index = 13;
            this.miSessionReplayResponse.Text = "C&lone Response";
            this.miSessionReplayResponse.Click += new System.EventHandler(this.miSessionReplayResponse_Click);
            // 
            // miSessionUnlock
            // 
            this.miSessionUnlock.Index = 14;
            this.miSessionUnlock.Text = "Unloc&k For Editing";
            this.miSessionUnlock.Click += new System.EventHandler(this.miSessionUnlock_Click);
            // 
            // miSessionSplit
            // 
            this.miSessionSplit.Index = 15;
            this.miSessionSplit.Text = "-";
            // 
            // miSessionProperties
            // 
            this.miSessionProperties.Index = 16;
            this.miSessionProperties.Text = "&Properties";
            this.miSessionProperties.Click += new System.EventHandler(this.miSessionProperties_Click);
            // 
            // imglSessionIcons
            // 
            this.imglSessionIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglSessionIcons.ImageStream")));
            this.imglSessionIcons.TransparentColor = System.Drawing.Color.Magenta;
            this.imglSessionIcons.Images.SetKeyName(0, "");
            this.imglSessionIcons.Images.SetKeyName(1, "");
            this.imglSessionIcons.Images.SetKeyName(2, "");
            this.imglSessionIcons.Images.SetKeyName(3, "");
            this.imglSessionIcons.Images.SetKeyName(4, "");
            this.imglSessionIcons.Images.SetKeyName(5, "");
            this.imglSessionIcons.Images.SetKeyName(6, "");
            this.imglSessionIcons.Images.SetKeyName(7, "");
            this.imglSessionIcons.Images.SetKeyName(8, "");
            this.imglSessionIcons.Images.SetKeyName(9, "");
            this.imglSessionIcons.Images.SetKeyName(10, "");
            this.imglSessionIcons.Images.SetKeyName(11, "");
            this.imglSessionIcons.Images.SetKeyName(12, "");
            this.imglSessionIcons.Images.SetKeyName(13, "");
            this.imglSessionIcons.Images.SetKeyName(14, "abort");
            this.imglSessionIcons.Images.SetKeyName(15, "");
            this.imglSessionIcons.Images.SetKeyName(16, "");
            this.imglSessionIcons.Images.SetKeyName(17, "unchecked");
            this.imglSessionIcons.Images.SetKeyName(18, "checked");
            this.imglSessionIcons.Images.SetKeyName(19, "16x16_inspect.bmp");
            this.imglSessionIcons.Images.SetKeyName(20, "16x16_builder.bmp");
            this.imglSessionIcons.Images.SetKeyName(21, "16x16_timer.bmp");
            this.imglSessionIcons.Images.SetKeyName(22, "16x16_timeline2.bmp");
            this.imglSessionIcons.Images.SetKeyName(23, "16x16_NoAutoRespond.bmp");
            this.imglSessionIcons.Images.SetKeyName(24, "16x16_AutoRespond.bmp");
            this.imglSessionIcons.Images.SetKeyName(25, "16x16_filter.bmp");
            this.imglSessionIcons.Images.SetKeyName(26, "16x16_filterbrowser.bmp");
            this.imglSessionIcons.Images.SetKeyName(27, "movie");
            this.imglSessionIcons.Images.SetKeyName(28, "audio");
            this.imglSessionIcons.Images.SetKeyName(29, "session_contenttype_font.bmp");
            this.imglSessionIcons.Images.SetKeyName(30, "session_contenttype_flash.bmp");
            this.imglSessionIcons.Images.SetKeyName(31, "session_contenttype_silverlight.bmp");
            this.imglSessionIcons.Images.SetKeyName(32, "post");
            this.imglSessionIcons.Images.SetKeyName(33, "json");
            // 
            // btnSquish
            // 
            this.btnSquish.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSquish.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSquish.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSquish.Location = new System.Drawing.Point(364, 0);
            this.btnSquish.Name = "btnSquish";
            this.btnSquish.Size = new System.Drawing.Size(36, 14);
            this.btnSquish.TabIndex = 3;
            this.btnSquish.TabStop = false;
            this.btnSquish.Text = "<<";
            this.btnSquish.Click += new System.EventHandler(this.btnSquish_Click);
            // 
            // lblSessions
            // 
            this.lblSessions.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSessions.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSessions.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblSessions.Location = new System.Drawing.Point(0, 0);
            this.lblSessions.Name = "lblSessions";
            this.lblSessions.Size = new System.Drawing.Size(400, 14);
            this.lblSessions.TabIndex = 0;
            this.lblSessions.Text = "Web &Sessions";
            this.lblSessions.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // splitterMain
            // 
            this.splitterMain.BackColor = System.Drawing.Color.LightSlateGray;
            this.splitterMain.Location = new System.Drawing.Point(400, 0);
            this.splitterMain.Name = "splitterMain";
            this.splitterMain.Size = new System.Drawing.Size(3, 304);
            this.splitterMain.TabIndex = 2;
            this.splitterMain.TabStop = false;
            this.splitterMain.DoubleClick += new System.EventHandler(this.splitterMain_DoubleClick);
            // 
            // pnlInspector
            // 
            this.pnlInspector.BackColor = System.Drawing.SystemColors.Control;
            this.pnlInspector.Controls.Add(this.tabsViews);
            this.pnlInspector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInspector.Location = new System.Drawing.Point(403, 0);
            this.pnlInspector.Name = "pnlInspector";
            this.pnlInspector.Size = new System.Drawing.Size(597, 304);
            this.pnlInspector.TabIndex = 3;
            // 
            // tabsViews
            // 
            this.tabsViews.AllowDrop = true;
            this.tabsViews.Controls.Add(this.pageStatistics);
            this.tabsViews.Controls.Add(this.pageInspector);
            this.tabsViews.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabsViews.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabsViews.HotTrack = true;
            this.tabsViews.ImageList = this.imglSessionIcons;
            this.tabsViews.Location = new System.Drawing.Point(0, 0);
            this.tabsViews.Margin = new System.Windows.Forms.Padding(0);
            this.tabsViews.Multiline = true;
            this.tabsViews.Name = "tabsViews";
            this.tabsViews.SelectedIndex = 0;
            this.tabsViews.Size = new System.Drawing.Size(597, 304);
            this.tabsViews.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabsViews.TabIndex = 0;
            this.tabsViews.SelectedIndexChanged += new System.EventHandler(this.tabsViews_SelectedIndexChanged);
            this.tabsViews.DragOver += new System.Windows.Forms.DragEventHandler(this.tabsViews_DragOver);
            // 
            // pageStatistics
            // 
            this.pageStatistics.BackColor = System.Drawing.Color.Transparent;
            this.pageStatistics.ImageIndex = 21;
            this.pageStatistics.Location = new System.Drawing.Point(4, 23);
            this.pageStatistics.Name = "pageStatistics";
            this.pageStatistics.Size = new System.Drawing.Size(589, 277);
            this.pageStatistics.TabIndex = 1;
            this.pageStatistics.Text = "Statistics";
            this.pageStatistics.UseVisualStyleBackColor = true;
            // 
            // pageInspector
            // 
            this.pageInspector.Controls.Add(this.tabsResponse);
            this.pageInspector.Controls.Add(this.pnlInfoTip);
            this.pageInspector.Controls.Add(this.pnlSessionControls);
            this.pageInspector.Controls.Add(this.splitterInspector);
            this.pageInspector.Controls.Add(this.tabsRequest);
            this.pageInspector.ImageIndex = 19;
            this.pageInspector.Location = new System.Drawing.Point(4, 23);
            this.pageInspector.Name = "pageInspector";
            this.pageInspector.Size = new System.Drawing.Size(589, 298);
            this.pageInspector.TabIndex = 0;
            this.pageInspector.Text = "Inspectors";
            this.pageInspector.UseVisualStyleBackColor = true;
            // 
            // tabsResponse
            // 
            this.tabsResponse.AllowDrop = true;
            this.tabsResponse.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabsResponse.ContextMenu = this.mnuInspectorsContext;
            this.tabsResponse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabsResponse.HotTrack = true;
            this.tabsResponse.ImageList = this.imglSessionIcons;
            this.tabsResponse.ItemSize = new System.Drawing.Size(42, 18);
            this.tabsResponse.Location = new System.Drawing.Point(0, 297);
            this.tabsResponse.Margin = new System.Windows.Forms.Padding(0);
            this.tabsResponse.Multiline = true;
            this.tabsResponse.Name = "tabsResponse";
            this.tabsResponse.SelectedIndex = 0;
            this.tabsResponse.Size = new System.Drawing.Size(589, 1);
            this.tabsResponse.TabIndex = 5;
            this.tabsResponse.SelectedIndexChanged += new System.EventHandler(this.tabsResponse_SelectedIndexChanged);
            // 
            // mnuInspectorsContext
            // 
            this.mnuInspectorsContext.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miInspectorProperties});
            // 
            // miInspectorProperties
            // 
            this.miInspectorProperties.Index = 0;
            this.miInspectorProperties.Text = "Inspector &Properties";
            this.miInspectorProperties.Click += new System.EventHandler(this.miInspectorProperties_Click);
            // 
            // pnlInfoTip
            // 
            this.pnlInfoTip.BackColor = System.Drawing.SystemColors.Info;
            this.pnlInfoTip.Controls.Add(this.btnDecodeResponse);
            this.pnlInfoTip.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInfoTip.ForeColor = System.Drawing.SystemColors.InfoText;
            this.pnlInfoTip.Location = new System.Drawing.Point(0, 273);
            this.pnlInfoTip.Name = "pnlInfoTip";
            this.pnlInfoTip.Size = new System.Drawing.Size(589, 24);
            this.pnlInfoTip.TabIndex = 7;
            this.pnlInfoTip.Visible = false;
            // 
            // btnDecodeResponse
            // 
            this.btnDecodeResponse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDecodeResponse.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDecodeResponse.Location = new System.Drawing.Point(0, 0);
            this.btnDecodeResponse.Name = "btnDecodeResponse";
            this.btnDecodeResponse.Size = new System.Drawing.Size(589, 24);
            this.btnDecodeResponse.TabIndex = 1;
            this.btnDecodeResponse.Text = " Response is encoded and may need to be decoded before inspection. Click here to " +
                "transform.";
            this.btnDecodeResponse.UseVisualStyleBackColor = true;
            this.btnDecodeResponse.Click += new System.EventHandler(this.btnDecodeResponse_Click);
            // 
            // pnlSessionControls
            // 
            this.pnlSessionControls.BackColor = System.Drawing.Color.Red;
            this.pnlSessionControls.Controls.Add(this.cbxLoadFrom);
            this.pnlSessionControls.Controls.Add(this.lblBreakpoint);
            this.pnlSessionControls.Controls.Add(this.btnTamperSendClient);
            this.pnlSessionControls.Controls.Add(this.btnTamperSendServer);
            this.pnlSessionControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSessionControls.ForeColor = System.Drawing.SystemColors.WindowText;
            this.pnlSessionControls.Location = new System.Drawing.Point(0, 248);
            this.pnlSessionControls.Name = "pnlSessionControls";
            this.pnlSessionControls.Size = new System.Drawing.Size(589, 25);
            this.pnlSessionControls.TabIndex = 3;
            this.pnlSessionControls.Visible = false;
            // 
            // cbxLoadFrom
            // 
            this.cbxLoadFrom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxLoadFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxLoadFrom.Location = new System.Drawing.Point(410, 1);
            this.cbxLoadFrom.MaxDropDownItems = 20;
            this.cbxLoadFrom.Name = "cbxLoadFrom";
            this.cbxLoadFrom.Size = new System.Drawing.Size(174, 21);
            this.cbxLoadFrom.TabIndex = 5;
            this.cbxLoadFrom.SelectionChangeCommitted += new System.EventHandler(this.cbxLoadFrom_SelectionChangeCommitted);
            // 
            // lblBreakpoint
            // 
            this.lblBreakpoint.Location = new System.Drawing.Point(6, 5);
            this.lblBreakpoint.Name = "lblBreakpoint";
            this.lblBreakpoint.Size = new System.Drawing.Size(162, 14);
            this.lblBreakpoint.TabIndex = 4;
            this.lblBreakpoint.Text = "Breakpoint hit. Tamper, then:";
            // 
            // btnTamperSendClient
            // 
            this.btnTamperSendClient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(217)))), ((int)(((byte)(6)))));
            this.btnTamperSendClient.ForeColor = System.Drawing.Color.Black;
            this.btnTamperSendClient.Location = new System.Drawing.Point(296, 1);
            this.btnTamperSendClient.Name = "btnTamperSendClient";
            this.btnTamperSendClient.Size = new System.Drawing.Size(112, 23);
            this.btnTamperSendClient.TabIndex = 2;
            this.btnTamperSendClient.Text = "Run to &Completion";
            this.btnTamperSendClient.UseVisualStyleBackColor = false;
            this.btnTamperSendClient.Click += new System.EventHandler(this.btnTamperSendClient_Click);
            // 
            // btnTamperSendServer
            // 
            this.btnTamperSendServer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnTamperSendServer.ForeColor = System.Drawing.Color.Black;
            this.btnTamperSendServer.Location = new System.Drawing.Point(174, 1);
            this.btnTamperSendServer.Name = "btnTamperSendServer";
            this.btnTamperSendServer.Size = new System.Drawing.Size(120, 23);
            this.btnTamperSendServer.TabIndex = 0;
            this.btnTamperSendServer.Text = "&Break on Response";
            this.btnTamperSendServer.UseVisualStyleBackColor = false;
            this.btnTamperSendServer.Click += new System.EventHandler(this.btnTamperSend_Click);
            // 
            // splitterInspector
            // 
            this.splitterInspector.BackColor = System.Drawing.Color.LightSlateGray;
            this.splitterInspector.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitterInspector.Location = new System.Drawing.Point(0, 245);
            this.splitterInspector.Name = "splitterInspector";
            this.splitterInspector.Size = new System.Drawing.Size(589, 3);
            this.splitterInspector.TabIndex = 6;
            this.splitterInspector.TabStop = false;
            this.splitterInspector.DoubleClick += new System.EventHandler(this.splitterInspector_DoubleClick);
            // 
            // tabsRequest
            // 
            this.tabsRequest.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabsRequest.ContextMenu = this.mnuInspectorsContext;
            this.tabsRequest.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabsRequest.HotTrack = true;
            this.tabsRequest.ImageList = this.imglSessionIcons;
            this.tabsRequest.ItemSize = new System.Drawing.Size(42, 18);
            this.tabsRequest.Location = new System.Drawing.Point(0, 0);
            this.tabsRequest.Margin = new System.Windows.Forms.Padding(0);
            this.tabsRequest.Multiline = true;
            this.tabsRequest.Name = "tabsRequest";
            this.tabsRequest.SelectedIndex = 0;
            this.tabsRequest.Size = new System.Drawing.Size(589, 245);
            this.tabsRequest.TabIndex = 4;
            this.tabsRequest.SelectedIndexChanged += new System.EventHandler(this.tabsRequest_SelectedIndexChanged);
            // 
            // dlgSaveBinary
            // 
            this.dlgSaveBinary.AddExtension = false;
            this.dlgSaveBinary.Filter = "All files (*.*)|*.*";
            this.dlgSaveBinary.Title = "Save as...";
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.mnuNotify;
            this.notifyIcon.Icon = global::Fiddler.Properties.Resources.notifyIcon_Icon;
            this.notifyIcon.Text = "Fiddler";
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
            // 
            // mnuNotify
            // 
            this.mnuNotify.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miNotifyRestore,
            this.miNotifyCapturing,
            this.toolStripMenuItem1,
            this.miNotifyExit});
            this.mnuNotify.Name = "mnuNotify";
            this.mnuNotify.Size = new System.Drawing.Size(166, 76);
            // 
            // miNotifyRestore
            // 
            this.miNotifyRestore.Name = "miNotifyRestore";
            this.miNotifyRestore.Size = new System.Drawing.Size(165, 22);
            this.miNotifyRestore.Text = "&Restore Fiddler";
            this.miNotifyRestore.Click += new System.EventHandler(this.miNotifyRestore_Click);
            // 
            // miNotifyCapturing
            // 
            this.miNotifyCapturing.CheckOnClick = true;
            this.miNotifyCapturing.Name = "miNotifyCapturing";
            this.miNotifyCapturing.Size = new System.Drawing.Size(165, 22);
            this.miNotifyCapturing.Text = "&Capture Traffic";
            this.miNotifyCapturing.Click += new System.EventHandler(this.miNotifyCapture_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(162, 6);
            // 
            // miNotifyExit
            // 
            this.miNotifyExit.Name = "miNotifyExit";
            this.miNotifyExit.Size = new System.Drawing.Size(165, 22);
            this.miNotifyExit.Text = "E&xit";
            this.miNotifyExit.Click += new System.EventHandler(this.miNotifyExit_Click);
            // 
            // dlgSaveZip
            // 
            this.dlgSaveZip.DefaultExt = "zip";
            this.dlgSaveZip.Filter = "Session Archive (*.saz)|*.saz|Password-Protected SAZ (*.saz)|*.saz";
            this.dlgSaveZip.Title = "Save Session Archive to...";
            // 
            // dlgLoadZip
            // 
            this.dlgLoadZip.DefaultExt = "zip";
            this.dlgLoadZip.Filter = "Session Archive (*.saz)|*.saz|All files|*.*";
            this.dlgLoadZip.Title = "Load Session Archive";
            // 
            // imglToolbar
            // 
            this.imglToolbar.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglToolbar.ImageStream")));
            this.imglToolbar.TransparentColor = System.Drawing.Color.Magenta;
            this.imglToolbar.Images.SetKeyName(0, "textplain");
            this.imglToolbar.Images.SetKeyName(1, "image");
            this.imglToolbar.Images.SetKeyName(2, "script");
            this.imglToolbar.Images.SetKeyName(3, "xml");
            this.imglToolbar.Images.SetKeyName(4, "html");
            this.imglToolbar.Images.SetKeyName(5, "css");
            this.imglToolbar.Images.SetKeyName(6, "redirect");
            this.imglToolbar.Images.SetKeyName(7, "cached");
            this.imglToolbar.Images.SetKeyName(8, "redbang");
            this.imglToolbar.Images.SetKeyName(9, "lock");
            this.imglToolbar.Images.SetKeyName(10, "noentry");
            this.imglToolbar.Images.SetKeyName(11, "key");
            this.imglToolbar.Images.SetKeyName(12, "info");
            this.imglToolbar.Images.SetKeyName(13, "unchecked");
            this.imglToolbar.Images.SetKeyName(14, "checked");
            this.imglToolbar.Images.SetKeyName(15, "inspect");
            this.imglToolbar.Images.SetKeyName(16, "builder");
            this.imglToolbar.Images.SetKeyName(17, "timer");
            this.imglToolbar.Images.SetKeyName(18, "timeline");
            this.imglToolbar.Images.SetKeyName(19, "darkbolt");
            this.imglToolbar.Images.SetKeyName(20, "litbolt");
            this.imglToolbar.Images.SetKeyName(21, "filter");
            this.imglToolbar.Images.SetKeyName(22, "ie");
            this.imglToolbar.Images.SetKeyName(23, "back");
            this.imglToolbar.Images.SetKeyName(24, "copy");
            this.imglToolbar.Images.SetKeyName(25, "find");
            this.imglToolbar.Images.SetKeyName(26, "help");
            this.imglToolbar.Images.SetKeyName(27, "comment");
            this.imglToolbar.Images.SetKeyName(28, "refresh");
            this.imglToolbar.Images.SetKeyName(29, "remove");
            this.imglToolbar.Images.SetKeyName(30, "tools");
            this.imglToolbar.Images.SetKeyName(31, "resume");
            this.imglToolbar.Images.SetKeyName(32, "save");
            this.imglToolbar.Images.SetKeyName(33, "mark");
            this.imglToolbar.Images.SetKeyName(34, "close");
            this.imglToolbar.Images.SetKeyName(35, "tearoff");
            this.imglToolbar.Images.SetKeyName(36, "streaming");
            this.imglToolbar.Images.SetKeyName(37, "clearcache");
            this.imglToolbar.Images.SetKeyName(38, "connected");
            this.imglToolbar.Images.SetKeyName(39, "notconnected");
            this.imglToolbar.Images.SetKeyName(40, "decoder");
            this.imglToolbar.Images.SetKeyName(41, "crosshair");
            this.imglToolbar.Images.SetKeyName(42, "camera");
            // 
            // lvSessions
            // 
            this.lvSessions.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvSessions.AllowColumnReorder = true;
            this.lvSessions.AllowDrop = true;
            this.lvSessions.AutoArrange = false;
            this.lvSessions.BackColor = System.Drawing.SystemColors.Window;
            this.lvSessions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvSessions.CausesValidation = false;
            this.lvSessions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colID,
            this.colStatus,
            this.colProtocol,
            this.colHost,
            this.colRequest,
            this.colResponseSize,
            this.colExpires,
            this.colContentType,
            this.colProcess,
            this.colComments,
            this.colCustom});
            this.lvSessions.ContextMenu = this.mnuSessionContext;
            this.lvSessions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSessions.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvSessions.FullRowSelect = true;
            this.lvSessions.HideSelection = false;
            this.lvSessions.LabelWrap = false;
            this.lvSessions.Location = new System.Drawing.Point(0, 14);
            this.lvSessions.Name = "lvSessions";
            this.lvSessions.Size = new System.Drawing.Size(400, 290);
            this.lvSessions.SmallImageList = this.imglSessionIcons;
            this.lvSessions.TabIndex = 1;
            this.lvSessions.UseCompatibleStateImageBehavior = false;
            this.lvSessions.View = System.Windows.Forms.View.Details;
            this.lvSessions.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.lvSessions_ItemDrag);
            this.lvSessions.SelectedIndexChanged += new System.EventHandler(this.lvSessions_SelectedIndexChanged);
            this.lvSessions.DragDrop += new System.Windows.Forms.DragEventHandler(this.lvSessions_DragDrop);
            this.lvSessions.DragEnter += new System.Windows.Forms.DragEventHandler(this.lvSessions_DragEnter);
            this.lvSessions.DoubleClick += new System.EventHandler(this.lvSessions_DoubleClick);
            this.lvSessions.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvSessions_KeyDown);
            this.lvSessions.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lvSessions_KeyUp);
            // 
            // colID
            // 
            this.colID.Text = "#";
            this.colID.Width = 45;
            // 
            // colStatus
            // 
            this.colStatus.Text = "Result";
            this.colStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colStatus.Width = 50;
            // 
            // colProtocol
            // 
            this.colProtocol.Text = "Protocol";
            this.colProtocol.Width = 55;
            // 
            // colHost
            // 
            this.colHost.Text = "Host";
            this.colHost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colHost.Width = 120;
            // 
            // colRequest
            // 
            this.colRequest.Text = "URL";
            this.colRequest.Width = 150;
            // 
            // colResponseSize
            // 
            this.colResponseSize.Text = "Body";
            this.colResponseSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colResponseSize.Width = 52;
            // 
            // colExpires
            // 
            this.colExpires.Text = "Caching";
            // 
            // colContentType
            // 
            this.colContentType.Text = "Content-Type";
            this.colContentType.Width = 80;
            // 
            // colProcess
            // 
            this.colProcess.Text = "Process";
            // 
            // colComments
            // 
            this.colComments.Text = "Comments";
            this.colComments.Width = 80;
            // 
            // colCustom
            // 
            this.colCustom.Text = "Custom";
            // 
            // frmViewer
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1000, 326);
            this.Controls.Add(this.pnlInspector);
            this.Controls.Add(this.splitterMain);
            this.Controls.Add(this.pnlSessions);
            this.Controls.Add(this.sbStatus);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = global::Fiddler.Properties.Resources.Viewer_Icon;
            this.KeyPreview = true;
            this.Menu = this.mnuMain;
            this.Name = "frmViewer";
            this.Text = "Fiddler - HTTP Debugging Proxy";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmViewer_Closing);
            this.Load += new System.EventHandler(this.frmViewer_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmViewer_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.sbpCapture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbpProcessFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbpBreakpoints)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbpSelCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbpInfo)).EndInit();
            this.pnlSessions.ResumeLayout(false);
            this.pnlInspector.ResumeLayout(false);
            this.tabsViews.ResumeLayout(false);
            this.pageInspector.ResumeLayout(false);
            this.pnlInfoTip.ResumeLayout(false);
            this.pnlSessionControls.ResumeLayout(false);
            this.mnuNotify.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void lvSessions_DoubleClick(object sender, EventArgs e)
        {
            this.actInspectSession();
        }

        private void lvSessions_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] data = (string[]) e.Data.GetData("FileDrop", false);
                foreach (string str in data)
                {
                    if (str.EndsWith(".saz", StringComparison.OrdinalIgnoreCase) || str.EndsWith(".zip", StringComparison.OrdinalIgnoreCase))
                    {
                        this.actLoadSessionArchive(str);
                    }
                }
                e.Effect = DragDropEffects.Copy;
            }
            else if (e.Data.GetDataPresent("Fiddler.Session[]"))
            {
                Session[] sessionArray;
                try
                {
                    sessionArray = (Session[]) e.Data.GetData("Fiddler.Session[]");
                }
                catch (Exception exception)
                {
                    FiddlerApplication.DoNotifyUser("Fiddler is unable to accept drops from other processes.\n\n" + exception.Message, "Operation failed");
                    return;
                }
                foreach (Session session in sessionArray)
                {
                    try
                    {
                        MemoryStream oFS = new MemoryStream();
                        MemoryStream stream2 = new MemoryStream();
                        MemoryStream strmMetadata = new MemoryStream();
                        session.WriteRequestToStream(false, true, oFS);
                        session.WriteResponseToStream(stream2, false);
                        session.WriteMetadataToStream(strmMetadata);
                        if (strmMetadata.Length < 1L)
                        {
                            strmMetadata = null;
                        }
                        else
                        {
                            strmMetadata.Position = 0L;
                        }
                        this.AddReportedSession(oFS.ToArray(), stream2.ToArray(), strmMetadata);
                    }
                    catch (Exception exception2)
                    {
                        FiddlerApplication.ReportException(exception2);
                    }
                }
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void lvSessions_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else if (e.Data.GetDataPresent("Fiddler.Session[]"))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void lvSessions_ItemDrag(object sender, ItemDragEventArgs e)
        {
            Session[] selectedSessions = this.GetSelectedSessions();
            if (selectedSessions.Length > 0)
            {
                this.lvSessions.AllowDrop = false;
                this.lvSessions.DoDragDrop(selectedSessions, DragDropEffects.Copy);
                this.lvSessions.AllowDrop = true;
            }
        }

        private void lvSessions_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Modifiers == Keys.None) && (e.KeyCode == Keys.Return))
            {
                e.SuppressKeyPress = true;
                if (this.lvSessions.SelectedItems.Count > 1)
                {
                    FiddlerApplication.UI.actActivateTabByTitle("Statistics", this.tabsViews);
                }
                else
                {
                    this.actInspectSession();
                }
            }
            if (e.Modifiers == Keys.Control)
            {
                Keys keyCode = e.KeyCode;
                if (keyCode != Keys.A)
                {
                    if (keyCode != Keys.I)
                    {
                        return;
                    }
                }
                else
                {
                    e.SuppressKeyPress = true;
                    this.actSelectAll();
                    return;
                }
                e.SuppressKeyPress = true;
                this.actInvertSelectedSessions();
                return;
            }
            if (((e.KeyCode != Keys.R) && (e.KeyCode != Keys.U)) || ((e.Modifiers != Keys.None) && (e.Modifiers != Keys.Shift)))
            {
                if (e.Modifiers == Keys.None)
                {
                    Keys keys3 = e.KeyCode;
                    if (keys3 <= Keys.Space)
                    {
                        if (keys3 != Keys.Escape)
                        {
                            if (keys3 == Keys.Space)
                            {
                                if (this.lvSessions.SelectedItems.Count <= 0)
                                {
                                    return;
                                }
                                this.lvSessions.SelectedItems[0].EnsureVisible();
                                e.Handled = true;
                                e.SuppressKeyPress = true;
                            }
                            return;
                        }
                    }
                    else
                    {
                        switch (keys3)
                        {
                            case Keys.C:
                                e.SuppressKeyPress = true;
                                this.miSessionSelectChildren_Click(null, null);
                                return;

                            case Keys.D:
                                e.SuppressKeyPress = true;
                                this.miSessionSelectDuplicates_Click(null, null);
                                return;

                            case Keys.M:
                                e.Handled = true;
                                e.SuppressKeyPress = true;
                                this.actCommentSelectedSessions();
                                return;

                            case Keys.P:
                                e.Handled = true;
                                e.SuppressKeyPress = true;
                                this.miSessionSelectParent_Click(null, null);
                                return;
                        }
                        return;
                    }
                    e.SuppressKeyPress = true;
                    FiddlerApplication.SuppressReportUpdates = true;
                    this.lvSessions.SelectedItems.Clear();
                    FiddlerApplication.SuppressReportUpdates = false;
                }
                return;
            }
            switch (e.KeyCode)
            {
                case Keys.R:
                    e.SuppressKeyPress = true;
                    this.miSessionReissueRequests_Click(null, null);
                    break;

                case Keys.U:
                    e.SuppressKeyPress = true;
                    this.miSessionReissueUnconditionally_Click(null, null);
                    goto Label_00E0;
            }
        Label_00E0:
            e.Handled = true;
        }

        private void lvSessions_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Alt)
            {
                if (e.KeyCode == Keys.Return)
                {
                    this.actViewSessionProperties();
                    e.SuppressKeyPress = true;
                }
            }
            else if (e.Modifiers == Keys.None)
            {
                Keys keyCode = e.KeyCode;
                if (keyCode != Keys.Back)
                {
                    if (keyCode != Keys.Insert)
                    {
                        return;
                    }
                }
                else
                {
                    e.SuppressKeyPress = true;
                    this.lvSessions.ActivatePreviousItem();
                    return;
                }
                e.SuppressKeyPress = true;
                if ((this.lvSessions.SelectedItems.Count == 1) && (this.GetFirstSelectedSession().oFlags["ui-bold"] == "user-marked"))
                {
                    this.miSessionMarkColor_Click(this.miSessionMarkUnmark, EventArgs.Empty);
                }
                else
                {
                    this.miSessionMarkColor_Click(this.miSessionMarkRed, EventArgs.Empty);
                }
            }
        }

        private void lvSessions_OnSessionsAdded()
        {
            this.UpdateStatusBar();
        }

        private void lvSessions_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lvSessions.StoreActiveItem();
            this.actRefreshUI();
        }

        [STAThread]
        private static void Main(string[] arrArgs)
        {
            Application.EnableVisualStyles();
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(frmViewer.UnhandledExceptionHandler);
            RunMain(arrArgs);
        }

        

        private void miCaptureEnabled_Click(object sender, EventArgs e)
        {
            this.actToggleCapture();
        }

        private void miCaptureRules_Click(object sender, EventArgs e)
        {
            try
            {
                if (FiddlerApplication.Prefs.GetBoolPref("fiddler.script.delaycreate", true) && !System.IO.File.Exists(CONFIG.GetPath("CustomRules")))
                {
                    FiddlerApplication.Log.LogFormat("Generating user's script file; copying '{0}' to '{1}'.", new object[] { CONFIG.GetPath("SampleRules"), CONFIG.GetPath("CustomRules") });
                    System.IO.File.Copy(CONFIG.GetPath("SampleRules"), CONFIG.GetPath("CustomRules"));
                }
                string arguments = "\"" + CONFIG.GetPath("CustomRules") + "\"";
                using (Process.Start(CONFIG.JSEditor, arguments))
                {
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Failed to launch script editor for CustomRules.js\nJSEditor: " + CONFIG.JSEditor + "\n\n" + exception.Message + "\nPlease see Help for information on setting the JSEditor.", "Editor Cannot Start");
            }
        }

        private void miEditSelectAll_Click(object sender, EventArgs e)
        {
            this.actSelectAll();
        }

        private void miExit_Click(object sender, EventArgs e)
        {
            this.actExit();
        }

        private void miFileLoad_Click(object sender, EventArgs e)
        {
            if (this.dlgLoadZip.ShowDialog(this) == DialogResult.OK)
            {
                this.actLoadSessionArchive(this.dlgLoadZip.FileName);
            }
        }

        private void miFileMinimizeToTray_Click(object sender, EventArgs e)
        {
            this.actMinimizeToTray();
        }

        private void miFileSaveAllSessions_Click(object sender, EventArgs e)
        {
            this.actSaveAllSessions();
        }

        private void miHelpAbout_Click(object sender, EventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            MessageBox.Show(FiddlerApplication.GetDetailedInfo() + "\nAuthor: Eric Lawrence (e_lawrence@hotmail.com)\n\x00a92003-2011 Eric Lawrence. All rights reserved.", "About Fiddler", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void miHelpCommunity_Click(object sender, EventArgs e)
        {
            Utilities.LaunchHyperlink(CONFIG.GetUrl("REDIR") + "FIDDLERDISC");
        }

        private void miHelpContents_Click(object sender, EventArgs e)
        {
            Utilities.LaunchHyperlink(CONFIG.GetUrl("HelpContents") + Application.ProductVersion);
        }

        private void miHelpHTTP_Click(object sender, EventArgs e)
        {
            Utilities.LaunchHyperlink(CONFIG.GetUrl("REDIR") + "HTTPREFERENCE");
        }

        private void miHelpUpdates_Click(object sender, EventArgs e)
        {
            new Thread(new ThreadStart(this.actCheckForUpdatesVerbose)) { IsBackground = true }.Start();
        }

        private void miInspectorProperties_Click(object sender, EventArgs e)
        {
            if ((this.mnuInspectorsContext.SourceControl != null) && (this.mnuInspectorsContext.SourceControl is TabControl))
            {
                TabPage selectedTab = ((TabControl) this.mnuInspectorsContext.SourceControl).SelectedTab;
                if ((selectedTab != null) && (selectedTab.Tag != null))
                {
                    ((Inspector2) selectedTab.Tag).ShowAboutBox();
                }
            }
        }

        private void miManipulateGZIP_Click(object sender, EventArgs e)
        {
        
        }

        private void miManipulateIgnoreImages_Click(object sender, EventArgs e)
        {
           
        }

        private void miManipulateRequireProxyAuth_Click(object sender, EventArgs e)
        {
           
        }

        private void miNotifyCapture_Click(object sender, EventArgs e)
        {
            this.actToggleCapture();
        }

        private void miNotifyExit_Click(object sender, EventArgs e)
        {
            this.actExit();
        }

        private void miNotifyRestore_Click(object sender, EventArgs e)
        {
            this.actRestoreWindow();
        }

        private void miReportBug_Click(object sender, EventArgs e)
        {
            try
            {
                using (Process.Start("mailto:e_lawrence@hotmail.com?Subject=Fiddler%20" + Application.ProductVersion))
                {
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Looks like you don't have a mailto: handler installed.\nJust send an email to e_lawrence@hotmail.com\n" + exception.Message, "Oops");
            }
        }

        

       


        private void miSessionAbort_Click(object sender, EventArgs e)
        {
            Session[] selectedSessions = this.GetSelectedSessions();
            if (selectedSessions.Length >= 1)
            {
                foreach (Session session in selectedSessions)
                {
                    session.Abort();
                }
            }
        }

        private void miSessionAddComment_Click(object sender, EventArgs e)
        {
            this.actCommentSelectedSessions();
        }

        private void miSessionCOMETPeek_Click(object sender, EventArgs e)
        {
            Session firstSelectedSession = this.GetFirstSelectedSession();
            if (firstSelectedSession != null)
            {
                firstSelectedSession.COMETPeek();
                FiddlerApplication.UI.actRefreshUI();
            }
        }

        private void miSessionCopyColumn_Click(object sender, EventArgs e)
        {
            try
            {
                ListView.SelectedListViewItemCollection selectedItems = this.lvSessions.SelectedItems;
                if (selectedItems.Count >= 1)
                {
                    int subItemIndexFromPoint = this.lvSessions.GetSubItemIndexFromPoint(this.lvSessions.PointToClient(this._ptContextPopup));
                    if (subItemIndexFromPoint >= 0)
                    {
                        StringBuilder builder = new StringBuilder(0x200);
                        foreach (ListViewItem item in selectedItems)
                        {
                            string str = (item.SubItems.Count > subItemIndexFromPoint) ? item.SubItems[subItemIndexFromPoint].Text : string.Empty;
                            builder.AppendLine(str);
                        }
                        Utilities.CopyToClipboard(builder.ToString());
                    }
                }
            }
            catch
            {
            }
        }

        private void miSessionCopyEntire_Click(object sender, EventArgs e)
        {
            this.actSessionCopy();
        }

        private void miSessionCopyHeaders_Click(object sender, EventArgs e)
        {
            this.actSessionCopyHeaders();
        }

        private void miSessionCopyHeadlines_Click(object sender, EventArgs e)
        {
            this.actSessionCopyHeadlines();
        }

        private void miSessionCopySummary_Click(object sender, EventArgs e)
        {
            this.actSessionCopySummary();
        }

        private void miSessionCopyURL_Click(object sender, EventArgs e)
        {
            this.actSessionCopyURL();
        }

        private void miSessionListScroll_Click(object sender, EventArgs e)
        {
            CONFIG.bAutoScroll = !this.miSessionListScroll.Checked;
            this.miViewAutoScroll.Checked = this.miSessionListScroll.Checked = CONFIG.bAutoScroll;
        }

        private void miSessionMarkColor_Click(object sender, EventArgs e)
        {
            if ((sender == this.miSessionMarkRed) || (sender == this.miEditMarkRed))
            {
                this.actSessionMark(System.Drawing.Color.Red);
            }
            else if ((sender == this.miSessionMarkBlue) || (sender == this.miEditMarkBlue))
            {
                this.actSessionMark(System.Drawing.Color.Blue);
            }
            else if ((sender == this.miSessionMarkGold) || (sender == this.miEditMarkGold))
            {
                this.actSessionMark(System.Drawing.Color.Gold);
            }
            else if ((sender == this.miSessionMarkGreen) || (sender == this.miEditMarkGreen))
            {
                this.actSessionMark(System.Drawing.Color.Green);
            }
            else if ((sender == this.miSessionMarkOrange) || (sender == this.miEditMarkOrange))
            {
                this.actSessionMark(System.Drawing.Color.Orange);
            }
            else if ((sender == this.miSessionMarkPurple) || (sender == this.miEditMarkPurple))
            {
                this.actSessionMark(System.Drawing.Color.Purple);
            }
            else if ((sender == this.miSessionMarkUnmark) || (sender == this.miEditMarkUnmark))
            {
                this.actSessionMark(System.Drawing.Color.Empty);
            }
        }

        private void miSessionProperties_Click(object sender, EventArgs e)
        {
            this.actViewSessionProperties();
        }

        private void miSessionReissueInIE_Click(object sender, EventArgs e)
        {
            Session[] selectedSessions = this.GetSelectedSessions();
            if (selectedSessions.Length < 1)
            {
                MessageBox.Show("Please select sessions to revisit.", "Nothing to Do");
            }
            else
            {
                for (int i = 0; i < selectedSessions.Length; i++)
                {
                    Utilities.RunExecutable("iexplore.exe", selectedSessions[i].fullUrl);
                }
            }
        }

        private void miSessionReissueRequests_Click(object sender, EventArgs e)
        {
            this.actReissueSelected();
        }

        private void miSessionReissueUnconditionally_Click(object sender, EventArgs e)
        {
            this.actUnconditionallyReissueSelected();
        }

        private void miSessionRemoveAll_Click(object sender, EventArgs e)
        {
            int num = FiddlerApplication.Prefs.GetInt32Pref("fiddler.ui.CtrlX.PromptIfMoreThan", 0);
            if (((num <= 0) || (this.lvSessions.Items.Count < num)) || (DialogResult.No != MessageBox.Show("Remove all " + this.lvSessions.Items.Count.ToString() + " sessions?", "Confirm Removal", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)))
            {
                if (FiddlerApplication.Prefs.GetBoolPref("fiddler.ui.CtrlX.KeepMarked", false))
                {
                    FiddlerApplication.UI.sbpInfo.Text = "Clearing all unmarked sessions";
                    this.TrimSessionList(0);
                    FiddlerApplication.oProxy.PurgeServerPipePool();
                }
                else
                {
                    this.actRemoveAllSessions();
                }
            }
        }

        private void miSessionRemoveSelected_Click(object sender, EventArgs e)
        {
            this.actRemoveSelectedSessions();
        }

        private void miSessionRemoveUnselected_Click(object sender, EventArgs e)
        {
            this.actRemoveUnselectedSessions();
        }

        private void miSessionReplayResponse_Click(object sender, EventArgs e)
        {
            if (this.lvSessions.SelectedItems.Count == 2)
            {
                Session session3;
                Session session4;
                Session tag = this.lvSessions.SelectedItems[0].Tag as Session;
                Session session2 = this.lvSessions.SelectedItems[1].Tag as Session;
                if (tag.state >= session2.state)
                {
                    session3 = session2;
                    session4 = tag;
                }
                else
                {
                    session3 = tag;
                    session4 = session2;
                }
                if (session4.bHasResponse && ((session3.state == SessionStates.HandTamperRequest) || (session3.state == SessionStates.HandTamperResponse)))
                {
                    session3.responseBodyBytes = session4.responseBodyBytes;
                    session3.oResponse.headers = (HTTPResponseHeaders) session4.oResponse.headers.Clone();
                    session3.state = SessionStates.HandTamperResponse;
                    this.lvSessions.SelectedItems.Clear();
                    session3.ViewItem.Selected = session3.ViewItem.Focused = true;
                    this.actRefreshInspectorsIfNeeded(session3);
                    this.actUpdateInspector(false, true);
                    return;
                }
            }
            MessageBox.Show("You must select two sessions, one of which has a response,\nand one of which is breakpointed awaiting a response.", "Invalid operation");
        }

        private void miSessionSaveEntire_Click(object sender, EventArgs e)
        {
            this.actSaveSessions();
        }

        private void miSessionSaveFullRequest_Click(object sender, EventArgs e)
        {
            this.actSaveRequests();
        }

        private void miSessionSaveFullResponse_Click(object sender, EventArgs e)
        {
            this.actSaveResponses();
        }

        private void miSessionSaveHeaders_Click(object sender, EventArgs e)
        {
            this.actSaveHeaders();
        }

        private void miSessionSaveRequestBody_Click(object sender, EventArgs e)
        {
            this.actSaveSessionRequestBody();
        }

        private void miSessionSaveResponseBody_Click(object sender, EventArgs e)
        {
            this.actSaveSessionResponseBody();
        }

        private void miSessionSaveToZip_Click(object sender, EventArgs e)
        {
            this.actSaveSessionsToZip();
        }

        private void miSessionSelectChildren_Click(object sender, EventArgs e)
        {
            Session firstSelectedSession = this.GetFirstSelectedSession();
            if (firstSelectedSession != null)
            {
                string fullUrl = firstSelectedSession.fullUrl;
                string str2 = firstSelectedSession.oRequest.headers.HTTPMethod + firstSelectedSession.fullUrl;
                int id = firstSelectedSession.id;
                FiddlerApplication.SuppressReportUpdates = true;
                this.lvSessions.BeginUpdate();
                this.lvSessions.SelectedItems.Clear();
                foreach (ListViewItem item in this.lvSessions.Items)
                {
                    Session tag = (Session) item.Tag;
                    if (tag.id > id)
                    {
                        if (((tag != null) && (tag.oRequest != null)) && ((tag.oRequest.headers != null) && tag.oRequest.headers.ExistsAndEquals("Referer", fullUrl)))
                        {
                            item.Selected = true;
                            item.Focused = true;
                        }
                        if (str2.Equals(tag.oRequest.headers.HTTPMethod + tag.fullUrl))
                        {
                            break;
                        }
                    }
                }
                this.sbpInfo.Text = "Found " + this.lvSessions.SelectedItems.Count.ToString() + " children.";
                firstSelectedSession.ViewItem.Selected = true;
                if (this.lvSessions.SelectedItems.Count > 0)
                {
                    this.lvSessions.SelectedItems[0].EnsureVisible();
                }
                this.lvSessions.EndUpdate();
                FiddlerApplication.SuppressReportUpdates = false;
                this.actUpdateInspector(true, true);
            }
        }

        private void miSessionSelectDuplicates_Click(object sender, EventArgs e)
        {
            Session firstSelectedSession = this.GetFirstSelectedSession();
            if (firstSelectedSession != null)
            {
                firstSelectedSession.ViewItem.Focused = true;
                string str = firstSelectedSession.oRequest.headers.HTTPMethod + firstSelectedSession.fullUrl;
                FiddlerApplication.SuppressReportUpdates = true;
                this.lvSessions.BeginUpdate();
                this.lvSessions.SelectedItems.Clear();
                foreach (ListViewItem item in this.lvSessions.Items)
                {
                    Session tag = (Session) item.Tag;
                    if (((tag != null) && (tag.oRequest != null)) && ((tag.oRequest.headers != null) && str.Equals(tag.oRequest.headers.HTTPMethod + tag.fullUrl, StringComparison.OrdinalIgnoreCase)))
                    {
                        item.Selected = true;
                    }
                }
                this.sbpInfo.Text = "Found " + ((this.lvSessions.SelectedItems.Count - 1)).ToString() + " duplicates.";
                this.lvSessions.EndUpdate();
                FiddlerApplication.SuppressReportUpdates = false;
                this.actUpdateInspector(true, true);
            }
        }

        private void miSessionSelectParent_Click(object sender, EventArgs e)
        {
            Session firstSelectedSession = this.GetFirstSelectedSession();
            if (firstSelectedSession != null)
            {
                string str = firstSelectedSession.oRequest["Referer"];
                if ((str == null) || (str.Length < 1))
                {
                    this.sbpInfo.Text = "No Referer header was present; cannot find parent.";
                }
                else
                {
                    int id = firstSelectedSession.id;
                    Session session2 = null;
                    FiddlerApplication.SuppressReportUpdates = true;
                    this.lvSessions.BeginUpdate();
                    this.lvSessions.SelectedItems.Clear();
                    foreach (ListViewItem item in this.lvSessions.Items)
                    {
                        Session tag = (Session) item.Tag;
                        if ((((tag.id < id) && (tag != null)) && ((tag.oRequest != null) && (tag.oRequest.headers != null))) && (tag.fullUrl.Equals(str) && ((session2 == null) || (session2.id < tag.id))))
                        {
                            session2 = tag;
                        }
                    }
                    this.sbpInfo.Text = string.Empty;
                    if (session2 != null)
                    {
                        session2.ViewItem.Selected = true;
                        session2.ViewItem.Focused = true;
                        session2.ViewItem.EnsureVisible();
                    }
                    else
                    {
                        this.sbpInfo.Text = "Parent session was not found.";
                    }
                    this.lvSessions.EndUpdate();
                    FiddlerApplication.SuppressReportUpdates = false;
                    this.actUpdateInspector(true, true);
                }
            }
        }

        private void miSessionUnlock_Click(object sender, EventArgs e)
        {
            Session firstSelectedSession = this.GetFirstSelectedSession();
            if (firstSelectedSession != null)
            {
                if (!firstSelectedSession.oFlags.ContainsKey("x-Unlocked"))
                {
                    firstSelectedSession.oFlags["x-Unlocked"] = "User-Request";
                }
                else
                {
                    firstSelectedSession.oFlags.Remove("x-Unlocked");
                }
                this.actUpdateInspector(true, true);
            }
        }

        private void miSessionWinDiff_Click(object sender, EventArgs e)
        {
            if (this.lvSessions.SelectedItems.Count == 2)
            {
                this.actDoCompareSessions((Session) this.lvSessions.SelectedItems[0].Tag, (Session) this.lvSessions.SelectedItems[1].Tag);
            }
        }

        private void miSquish_Click(object sender, EventArgs e)
        {
            this.actToggleSquish();
        }

        private void miToolsBase64_Click(object sender, EventArgs e)
        {
            this.actShowEncodingTools();
        }

        private void miToolsClearCache_Click(object sender, EventArgs e)
        {
            this.actClearWinINETCache();
        }

        private void miToolsClearCookies_Click(object sender, EventArgs e)
        {
            this.actClearWinINETCookies();
        }

        private void miToolsFind_Click(object sender, EventArgs e)
        {
            this.actDoFind();
        }

        private void miToolsInternetOptions_Click(object sender, EventArgs e)
        {
            this.actLaunchIEProxy();
        }

        private void miToolsOptions_Click(object sender, EventArgs e)
        {
            this.actShowOptions();
        }

        private void miViewAutoScroll_Click(object sender, EventArgs e)
        {
            CONFIG.bAutoScroll = !this.miViewAutoScroll.Checked;
            this.miViewAutoScroll.Checked = this.miSessionListScroll.Checked = CONFIG.bAutoScroll;
        }

        

        private void miViewInspector_Click(object sender, EventArgs e)
        {
            this.tabsViews.SelectedTab = this.pageInspector;
        }

        private void miViewRefresh_Click(object sender, EventArgs e)
        {
            this.actRefreshUI();
        }

        private void miViewStacked_Click(object sender, EventArgs e)
        {
            this.actToggleStackedLayout(!this.miViewStacked.Checked);
        }

        private void miViewStatistics_Click(object sender, EventArgs e)
        {
            this.tabsViews.SelectedTab = this.pageStatistics;
        }

        private void miViewStayOnTop_Click(object sender, EventArgs e)
        {
            FiddlerApplication.Prefs.SetBoolPref("fiddler.ui.stayontop", !this.miViewStayOnTop.Checked);
        }

        private void miViewToolbar_Click(object sender, EventArgs e)
        {
            this.miViewToolbar.Checked = !this.miViewToolbar.Checked;
            FiddlerApplication.Prefs.SetBoolPref("fiddler.ui.toolbar.visible", this.miViewToolbar.Checked);
        }

        private void mnuEdit_Popup(object sender, EventArgs e)
        {
            this.mnuEditMark.Enabled = 0 < this.lvSessions.SelectedItems.Count;
        }

        private void mnuEditRemove_Popup(object sender, EventArgs e)
        {
            this.miEditRemoveSelected.Enabled = 0 < this.lvSessions.SelectedItems.Count;
            this.miEditRemoveUnselected.Enabled = 0 < this.lvSessions.SelectedItems.Count;
        }

        private void mnuFile_Popup(object sender, EventArgs e)
        {
            this.miFileProperties.Enabled = 1 == this.lvSessions.SelectedItems.Count;
            this.mnuFileSave.Enabled = 0 < this.lvSessions.Items.Count;
            if (this.mnuFileExport != null)
            {
                this.mnuFileExport.Enabled = this.mnuFileSave.Enabled;
            }
        }

        private void mnuFileSave_Popup(object sender, EventArgs e)
        {
            this.mnuFileSaveRequest.Enabled = this.mnuFileSaveResponse.Enabled = this.mnuFileSaveSessions.Enabled = 0 < this.lvSessions.SelectedItems.Count;
        }

        private void mnuSessionContext_Popup(object sender, EventArgs e)
        {
            this._ptContextPopup = Cursor.Position;
            this.miSessionRemoveAll.Enabled = this.lvSessions.Items.Count > 0;
            int count = this.lvSessions.SelectedItems.Count;
            this.miSessionReplay.Enabled = this.miSessionMark.Enabled = this.miSessionCopy.Enabled = this.miSessionRemoveSelected.Enabled = this.miSessionRemoveUnselected.Enabled = this.miSessionSave.Enabled = this.miSessionSaveEntire.Enabled = this.miSessionSaveHeaders.Enabled = this.miSessionSaveRequestBody.Enabled = this.miSessionAddComment.Enabled = this.miSessionSaveResponseBody.Enabled = this.miSessionAbort.Enabled = count > 0;
            this.miSessionProperties.Enabled = this.miSessionSelect.Enabled = count == 1;
            this.miSessionWinDiff.Enabled = count == 2;
            bool flag = count == 2;
            if (flag)
            {
                flag = ((this.lvSessions.SelectedItems[0].Tag as Session).state > SessionStates.HandTamperResponse) ^ ((this.lvSessions.SelectedItems[1].Tag as Session).state > SessionStates.HandTamperResponse);
            }
            this.miSessionReplayResponse.Enabled = flag;
            if (count == 1)
            {
                this.miSessionUnlock.Enabled = (this.lvSessions.SelectedItems[0].Tag as Session).state >= SessionStates.Done;
                this.miSessionUnlock.Checked = (this.lvSessions.SelectedItems[0].Tag as Session).oFlags.ContainsKey("X-Unlocked");
                this.miSessionCOMETPeek.Enabled = (this.lvSessions.SelectedItems[0].Tag as Session).state == SessionStates.ReadingResponse;
            }
            else
            {
                this.miSessionCOMETPeek.Enabled = this.miSessionUnlock.Enabled = this.miSessionUnlock.Checked = false;
            }
        }

        private void mnuTools_Popup(object sender, EventArgs e)
        {
            this.miToolsCompare.Enabled = 2 == this.lvSessions.SelectedItems.Count;
        }

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.actRestoreWindow();
            }
        }

        private void OnPrefChange(object sender, PrefChangeEventArgs oPref)
        {
            string str;
            if (!FiddlerApplication.isClosing && ((str = oPref.PrefName) != null))
            {
                if (!(str == "fiddler.ui.rules.removeencoding"))
                {
                    if (!(str == "fiddler.ui.toolbar.visible"))
                    {
                        if (!(str == "fiddler.ui.stayontop"))
                        {
                            if (str == "fiddler.ui.sessionlist.updateinterval")
                            {
                                this.lvSessions.uiAsyncUpdateInterval = FiddlerApplication.Prefs.GetInt32Pref("fiddler.ui.sessionlist.updateinterval", 80);
                            }
                        }
                        else
                        {
                            this.miViewStayOnTop.Checked = oPref.ValueString == bool.TrueString;
                            base.TopMost = this.miViewStayOnTop.Checked;
                        }
                    }
                    else
                    {
                        this.miViewToolbar.Checked = oPref.ValueString == bool.TrueString;
                    }
                }
                
            }
        }

        private void oReportingQueueTimer_Tick(object sender, EventArgs e)
        {
            oReportingQueueTimer.Stop();
            this.actUpdateReport();
        }

        private static bool PerformUpgradeIfPending()
        {
            try
            {
                RegistryKey oReg = Registry.CurrentUser.OpenSubKey(CONFIG.GetRegPath("Root"), true);
                if (oReg == null)
                {
                    return false;
                }
                bool flag = Utilities.GetRegistryBool(oReg, "UpdatePending", false);
                oReg.DeleteValue("UpdatePending", false);
                oReg.Close();
                if (!flag)
                {
                    return false;
                }
                Process.Start(Path.GetDirectoryName(Application.ExecutablePath) + @"\UpdateFiddler.exe");
                return true;
            }
            catch
            {
                return false;
            }
        }

        [CodeDescription("Resume a session currently paused at a breakpoint.")]
        public void ResumeBreakpointedSession(Session oSession)
        {
            if (oSession == null)
            {
                return;
            }
            switch (oSession.state)
            {
                case SessionStates.HandTamperRequest:
                    this.actUpdateRequest(oSession);
                    if (oSession.ViewItem != null)
                    {
                        oSession.ViewItem.ImageIndex = 0;
                    }
                    break;

                case SessionStates.HandTamperResponse:
                    this.actUpdateResponse(oSession);
                    if (oSession.ViewItem != null)
                    {
                        oSession.ViewItem.ImageIndex = 2;
                    }
                    goto Label_004C;
            }
        Label_004C:
            this.btnTamperSendServer.Enabled = this.btnTamperSendClient.Enabled = false;
            oSession.ThreadResume();
        }

        private static void RunMain(string[] arrArgs)
        {
            if ((arrArgs.Length != 0) || !PerformUpgradeIfPending())
            {
                Mutex mutex;
                FiddlerApplication._frmSplash = new SplashScreen();
                if (!CONFIG.QuietMode)
                {
                    FiddlerApplication._frmSplash.Show();
                }
                FiddlerApplication._frmSplash.IndicateProgress("Searching for running instance...");
                try
                {
                    string name = !CONFIG.bIsViewOnly ? (@"Global\FiddlerUser_" + Environment.UserName) : ("FiddlerViewer" + Environment.TickCount.ToString());
                    mutex = new Mutex(false, name);
                }
                catch (Exception exception)
                {
                    FiddlerApplication._frmSplash.Close();
                    FiddlerApplication.DoNotifyUser("Fiddler appears to be running in this user account (mutex fail).\n\n" + exception.Message, "Fiddler Startup Aborted", MessageBoxIcon.Hand);
                    return;
                }
                using (mutex)
                {
                    if (!mutex.WaitOne(20, false))
                    {
                        FiddlerApplication._frmSplash.Close();
                        IntPtr hWnd = Utilities.FindWindow(null, "Fiddler - HTTP Debugging Proxy");
                        if (0L != hWnd.ToInt64())
                        {
                            Utilities.SendMessage(hWnd, 0x312, IntPtr.Zero, (IntPtr) ((CONFIG.iHotkey << 0x10) + CONFIG.iHotkeyMod));
                            for (int i = 0; i < arrArgs.Length; i++)
                            {
                                if (arrArgs[i].EndsWith(".saz", StringComparison.OrdinalIgnoreCase))
                                {
                                    Utilities.SendDataStruct lParam = new Utilities.SendDataStruct {
                                        dwData = (IntPtr) 0xeefa,
                                        strData = arrArgs[i],
                                        cbData = Encoding.UTF8.GetBytes(arrArgs[i]).Length
                                    };
                                    Utilities.SendWMCopyMessage(hWnd, 0x4a, IntPtr.Zero, ref lParam);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Fiddler appears to be running in this user account.\n\nMaybe in a terminal services session?", "Fiddler Startup Aborted");
                        }
                    }
                    else
                    {
                        FiddlerApplication._SetXceedLicenseKeys();
                        FiddlerApplication._frmMain = new frmViewer();
                        FiddlerApplication._frmSplash.IndicateProgress("Loading AutoResponder...");
                       
                        FiddlerApplication._frmSplash.IndicateProgress("Creating Proxy...");
                        FiddlerApplication.oProxy = new Proxy(true);
                        FiddlerApplication.Log.LogString("Fiddler Running...");
                        Application.Run(FiddlerApplication._frmMain);
                    }
                }
            }
        }

        private void SaveFilesForUltraDiff(string sFile1, string sFile2, Session oSess1, Session oSess2)
        {
            Utilities.EnsureOverwritable(sFile1);
            Utilities.EnsureOverwritable(sFile2);
            if (!FiddlerApplication.Prefs.GetBoolPref("fiddler.differ.ultradiff", true))
            {
                oSess1.SaveSession(sFile1, false);
                oSess2.SaveSession(sFile2, false);
            }
            else
            {
                string str7;
                string str8;
                FileStream stream = new FileStream(sFile1, FileMode.Create, FileAccess.Write);
                FileStream stream2 = new FileStream(sFile2, FileMode.Create, FileAccess.Write);
                StreamWriter writer = new StreamWriter(stream);
                StreamWriter writer2 = new StreamWriter(stream2);
                string hTTPMethod = oSess1.oRequest.headers.HTTPMethod;
                string str2 = oSess2.oRequest.headers.HTTPMethod;
                string fullUrl = oSess1.fullUrl;
                string str4 = oSess2.fullUrl;
                string hTTPVersion = oSess1.oRequest.headers.HTTPVersion;
                string str6 = oSess2.oRequest.headers.HTTPVersion;
                if (((hTTPMethod == str2) && (fullUrl == str4)) && (hTTPVersion == str6))
                {
                    writer.Write("{0} {1} {2}\r\n", hTTPMethod, fullUrl, hTTPVersion);
                    writer2.Write("{0} {1} {2}\r\n", str2, str4, str6);
                }
                else
                {
                    int length = this.getFirstMismatchedCharacter(fullUrl, str4);
                    if (length > -1)
                    {
                        fullUrl = fullUrl.Substring(0, length) + "\r\n>>\t" + fullUrl.Substring(length, fullUrl.Length - length);
                        str4 = str4.Substring(0, length) + "\r\n>>\t" + str4.Substring(length, str4.Length - length);
                    }
                    writer.Write("{0}\r\n{1}\r\n{2}\r\n\r\n", hTTPMethod, fullUrl, hTTPVersion);
                    writer2.Write("{0}\r\n{1}\r\n{2}\r\n\r\n", str2, str4, str6);
                }
                this.GetDiffFormattedHeaders(oSess1.oRequest.headers, oSess2.oRequest.headers, out str7, out str8);
                writer.WriteLine(str7);
                writer2.WriteLine(str8);
                writer.Flush();
                writer2.Flush();
                if (oSess1.requestBodyBytes != null)
                {
                    stream.Write(oSess1.requestBodyBytes, 0, oSess1.requestBodyBytes.Length);
                }
                if (oSess2.requestBodyBytes != null)
                {
                    stream2.Write(oSess2.requestBodyBytes, 0, oSess2.requestBodyBytes.Length);
                }
                writer.WriteLine("\r\n------------------------------------------------------------\r\n");
                writer2.WriteLine("\r\n------------------------------------------------------------\r\n");
                writer.Flush();
                writer2.Flush();
                if (((oSess1.oResponse != null) && (oSess1.oResponse.headers != null)) && ((oSess2.oResponse != null) && (oSess2.oResponse.headers != null)))
                {
                    hTTPVersion = oSess1.oResponse.headers.HTTPVersion;
                    str6 = oSess2.oResponse.headers.HTTPVersion;
                    string hTTPResponseStatus = oSess1.oResponse.headers.HTTPResponseStatus;
                    string str10 = oSess2.oResponse.headers.HTTPResponseStatus;
                    writer.Write("{0} {1}\r\n", hTTPVersion, hTTPResponseStatus);
                    writer2.Write("{0} {1}\r\n", str6, str10);
                    this.GetDiffFormattedHeaders(oSess1.oResponse.headers, oSess2.oResponse.headers, out str7, out str8);
                    writer.WriteLine(str7);
                    writer2.WriteLine(str8);
                    writer.Flush();
                    writer2.Flush();
                }
                else
                {
                    if ((oSess1.oResponse != null) && (oSess1.oResponse.headers != null))
                    {
                        byte[] buffer = oSess1.oResponse.headers.ToByteArray(true, true);
                        stream.Write(buffer, 0, buffer.Length);
                    }
                    else
                    {
                        stream.WriteByte(13);
                        stream.WriteByte(10);
                    }
                    if ((oSess2.oResponse != null) && (oSess2.oResponse.headers != null))
                    {
                        byte[] buffer2 = oSess2.oResponse.headers.ToByteArray(true, true);
                        stream2.Write(buffer2, 0, buffer2.Length);
                    }
                    else
                    {
                        stream2.WriteByte(13);
                        stream2.WriteByte(10);
                    }
                }
                if (oSess1.responseBodyBytes != null)
                {
                    stream.Write(oSess1.responseBodyBytes, 0, oSess1.responseBodyBytes.Length);
                }
                if (oSess2.responseBodyBytes != null)
                {
                    stream2.Write(oSess2.responseBodyBytes, 0, oSess2.responseBodyBytes.Length);
                }
                stream.Close();
                stream2.Close();
            }
        }

        private void sbStatus_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Location.X < ((this.sbpCapture.Width + this.sbpProcessFilter.Width) + this.sbpBreakpoints.Width))
            {
                this.sbStatus.Cursor = Cursors.Hand;
            }
            else
            {
                this.sbStatus.Cursor = Cursors.Default;
            }
        }

        private void sbStatus_PanelClick(object sender, StatusBarPanelClickEventArgs e)
        {
            if (e.Clicks == 1)
            {
                if (((e.StatusBarPanel == this.sbpCapture) && ((e.Button == MouseButtons.Left) || (e.Button == MouseButtons.Right))) && !CONFIG.bIsViewOnly)
                {
                    lock (this)
                    {
                        this.actToggleCapture();
                    }
                }
                else if (e.StatusBarPanel == this.sbpProcessFilter)
                {
                    this.actToggleProcessFilter();
                }
               
            }
        }

        private void SetMenuItemCheckedFromPref(MenuItem oMI, string sPref)
        {
            oMI.Checked = FiddlerApplication.Prefs.GetBoolPref(sPref, false);
        }

        public void ShowAlert(frmAlert oAlert)
        {
            oAlert.StartPosition = FormStartPosition.CenterScreen;
            oAlert.Show(this);
        }

        private void splitterInspector_DoubleClick(object sender, EventArgs e)
        {
            if (this.tabsRequest.Height > 30)
            {
                this.tabsRequest.Height = 30;
            }
            else
            {
                this.tabsRequest.Height = Math.Max(100, (base.Height - 100) / 2);
            }
        }

        private void splitterMain_DoubleClick(object sender, EventArgs e)
        {
            int num = 0;
            foreach (ColumnHeader header in this.lvSessions.Columns)
            {
                num += header.Width;
            }
            this.pnlSessions.Width = Math.Min((int) (Screen.FromControl(this.btnSquish).WorkingArea.Width - 40), (int) (num + 20));
        }

        private void tabsRequest_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.actUpdateInspector(true, false);
        }

        private void tabsResponse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!FiddlerApplication.isClosing && (this.tabsResponse.SelectedIndex >= 0))
            {
                this.tabsResponse.TabPages[this.tabsResponse.SelectedIndex].Focus();
                this.actUpdateInspector(false, true);
            }
        }

        private void tabsViews_DragOver(object sender, DragEventArgs e)
        {
            try
            {
                Point pt = this.tabsViews.PointToClient(new Point(e.X, e.Y));
                if (pt.Y < this.tabsViews.DisplayRectangle.Top)
                {
                    TabPage page = this._GetTabPageFromPoint(pt);
                    if ((page != null) && (this.tabsViews.SelectedTab != page))
                    {
                        this.tabsViews.SelectedTab = page;
                        if (this.tabsViews.RowCount > 1)
                        {
                            Rectangle tabRect = this.tabsViews.GetTabRect(this.tabsViews.TabPages.IndexOf(page));
                            Point p = new Point(tabRect.Left + (tabRect.Width / 2), tabRect.Top + (tabRect.Height / 2));
                            Cursor.Position = this.tabsViews.PointToScreen(p);
                        }
                    }
                }
            }
            catch
            {
            }
        }

        private void tabsViews_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.actUpdateInspector(true, true);
            this.actReportStatistics(true);
        }

        public void TrimSessionList(int iTrimTo)
        {
            if (this.lvSessions.TotalItemCount() > iTrimTo)
            {
                if (FiddlerApplication._frmMain.InvokeRequired)
                {
                    FiddlerApplication._frmMain.Invoke(new trimSessionListDelegate(this.TrimSessionList), new object[] { iTrimTo });
                }
                else
                {
                    this._internalTrimSessionList(iTrimTo);
                }
            }
        }

        
        private void uihlpUpdateProcessFilterStatus()
        {
            switch (CONFIG.iShowProcessFilter)
            {
                case ProcessFilterCategories.All:
                    this.sbpProcessFilter.Text = "All Processes";
                    this.sbpProcessFilter.Icon = Icon.FromHandle(((Bitmap) this.imglSessionIcons.Images[0x19]).GetHicon());
                    return;

                case ProcessFilterCategories.Browsers:
                    this.sbpProcessFilter.Text = "Web Browsers";
                    this.sbpProcessFilter.Icon = Icon.FromHandle(((Bitmap) this.imglSessionIcons.Images[0x1a]).GetHicon());
                    return;

                case ProcessFilterCategories.NonBrowsers:
                    this.sbpProcessFilter.Text = "Non-Browser";
                    this.sbpProcessFilter.Icon = Icon.FromHandle(((Bitmap) this.imglSessionIcons.Images[20]).GetHicon());
                    return;

                case ProcessFilterCategories.HideAll:
                    this.sbpProcessFilter.Text = "Hide All";
                    this.sbpProcessFilter.Icon = Icon.FromHandle(((Bitmap) this.imglSessionIcons.Images[14]).GetHicon());
                    return;
            }
        }

        private static void UnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs ue)
        {
            Exception exceptionObject = (Exception) ue.ExceptionObject;
            if (CONFIG.bUseEventLogForExceptions)
            {
                _LogExceptionToEventLog(exceptionObject);
            }
            FiddlerApplication.ReportException(exceptionObject);
        }

        [CodeDescription("Rescan the Responses subfolder of the Captures folder and list available files in Fiddler tampering UIs.")]
        public void UpdateLoadFromCbx()
        {
            this.cbxLoadFrom.Items.Clear();
            this.cbxLoadFrom.Items.Add("Choose Response...");
           
            try
            {
                if (Directory.Exists(CONFIG.GetPath("TemplateResponses")))
                {
                    foreach (FileInfo info in new DirectoryInfo(CONFIG.GetPath("TemplateResponses")).GetFiles())
                    {
                        if (!info.Name.StartsWith("_", StringComparison.Ordinal))
                        {
                            this.cbxLoadFrom.Items.Add(info.Name);
                           
                        }
                    }
                }
                if (Directory.Exists(CONFIG.GetPath("Responses")))
                {
                    foreach (FileInfo info2 in new DirectoryInfo(CONFIG.GetPath("Responses")).GetFiles())
                    {
                        if (!info2.Name.StartsWith("_", StringComparison.Ordinal))
                        {
                            this.cbxLoadFrom.Items.Add(info2.Name);
                            
                        }
                    }
                }
            }
            catch
            {
            }
            if (this.cbxLoadFrom.Items.Count > 0)
            {
                this.cbxLoadFrom.SelectedIndex = 0;
            }
           
            this.cbxLoadFrom.Items.Add("Find a file...");
        }

        public void updateSession(Session oSession)
        {
            ListViewItem viewItem = oSession.ViewItem;
            bool flag = oSession.ShouldBeHidden();
            if (!flag && (viewItem == null))
            {
                this.addSession(oSession);
                viewItem = oSession.ViewItem;
            }
            if (flag && (viewItem != null))
            {
                oSession.ViewItem = null;
                this.lvSessions.RemoveOrDequeue(viewItem);
            }
            else
            {
                try
                {
                    viewItem.SubItems[2].Text = _obtainScheme(oSession);
                    viewItem.SubItems[10].Text = oSession.oFlags["ui-customcolumn"];
                    viewItem.SubItems[9].Text = oSession.oFlags["ui-comments"];
                    this.lvSessions.FillBoundColumns(oSession, viewItem);
                    switch (oSession.state)
                    {
                        case SessionStates.ReadingResponse:
                        case SessionStates.SendingResponse:
                            viewItem.ImageIndex = 2;
                            return;

                        case SessionStates.AutoTamperResponseBefore:
                        case SessionStates.AutoTamperResponseAfter:
                        case SessionStates.Done:
                            return;

                        case SessionStates.HandTamperResponse:
                            viewItem.ImageIndex = 3;
                            return;

                        case SessionStates.Aborted:
                            viewItem.ImageIndex = 14;
                            return;

                        case SessionStates.HandTamperRequest:
                            break;

                        default:
                            return;
                    }
                    viewItem.ImageIndex = 1;
                }
                catch (Exception)
                {
                }
            }
        }

        private void UpdateStatusBar()
        {
            if (this.lvSessions.SelectedItems.Count < 1)
            {
                this.sbpSelCount.Text = string.Format("{0:N0}", this.lvSessions.Items.Count);
            }
            else
            {
                this.sbpSelCount.Text = string.Format("{0:N0} / {1:N0}", this.lvSessions.SelectedItems.Count, this.lvSessions.Items.Count);
            }
        }

        private void UpdateUIFromPrefs()
        {
            
            base.TopMost = this.miViewStayOnTop.Checked;
            this.lvSessions.uiAsyncUpdateInterval = FiddlerApplication.Prefs.GetInt32Pref("fiddler.ui.sessionlist.updateinterval", 80);
        }

        protected override void WndProc(ref Message m)
        {
            if (((m.Msg == 5) && (1L == ((long) m.WParam))) && (CONFIG.QuietMode || CONFIG.bHideOnMinimize))
            {
                this.actMinimizeToTray();
            }
            else if (m.Msg == 0x4a)
            {
                Utilities.COPYDATASTRUCT lParam = (Utilities.COPYDATASTRUCT) m.GetLParam(typeof(Utilities.COPYDATASTRUCT));
                if (((((long) lParam.dwData) >= 0xeefaL) && (((long) lParam.dwData) <= 0xeefcL)) && (lParam.cbData >= 1))
                {
                    byte[] destination = new byte[lParam.cbData];
                    Marshal.Copy(lParam.lpData, destination, 0, lParam.cbData);
                    string sFilename = Encoding.UTF8.GetString(destination);
                    if (((long) lParam.dwData) == 0xeefaL)
                    {
                        this.actLoadSessionArchive(sFilename);
                    }
                    else if (((long) lParam.dwData) == 0xeefcL)
                    {
                        FiddlerApplication.DebugSpew("[Fiddler] Got WM_COPYDATA with " + destination);
                       
                    }
                }
            }
            else if (m.Msg == 0x312)
            {
                if (m.LParam == ((IntPtr) ((CONFIG.iHotkey << 0x10) + CONFIG.iHotkeyMod)))
                {
                    this.actRestoreWindow();
                }
            }
            else
            {
                base.WndProc(ref m);
            }
        }
    }
}

