﻿#region Using directives

using System;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Diagnostics;
using System.Xml;
using System.Net;
using System.Text;
using TwitterAway.Twitter;
using MiscPocketCompactLibrary.Reflection;
using MiscPocketCompactLibrary.Diagnostics;
using MiscPocketCompactLibrary.Windows.Forms;


#endregion

namespace TwitterAway
{
    /// <summary>
    /// フォームの概要の説明です。
    /// </summary>
    public class MainForm : System.Windows.Forms.Form
    {
        /// <summary>
        /// ゲットしたTwiiterStates
        /// </summary>
        private Twitter.StatusInfomation[] twitterStatuses = null;

        private ListView twitterListView;
        private ColumnHeader screenNameColumnHeader;
        private ColumnHeader doingColumnHeader;
        private TextBox doingPostTextBox;
        private Button updateButton;
        private MenuItem menuMenuItem;
        private MenuItem versionInfoMenuItem;
        private MenuItem separateMenuItem2;
        private MenuItem exitMenuItem;
        private MenuItem pocketLadioSettingMenuItem;
        private MenuItem separateMenuItem1;
        /// <summary>
        /// フォームのメイン メニュー
        /// </summary>
        private System.Windows.Forms.MainMenu mainMenu;
        private Microsoft.WindowsCE.Forms.InputPanel inputPanel;
        private ColumnHeader dateColumnHeader;
        private ContextMenu doingContextMenu;
        private MenuItem cutDoingMenuItem;
        private MenuItem copyDoingMenuItem;
        private MenuItem pasteDoingMenuItem;
        private MenuItem updateMenuItem;
        private MenuItem updateCheckTimerMenuItem;
        private MenuItem separateMenuItem3;
        private Timer updateCheckTimer;

        /// <summary>
        /// CheckTwitterUpdate()の動作排他処理のためのフラグ
        /// </summary>
        private bool checkTwitterUpdateNowFlag;
        private ImageList profileSmallImageList;
        private PictureBox twitterPictureBox;
        private ImageList profileBigImageList;
        private TextBox doingInfomationTextBox;

        /// <summary>
        /// アンカーコントロールのリスト
        /// </summary>
        private ArrayList anchorControlList = new ArrayList();

        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナで生成されたコード
        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.mainMenu = new System.Windows.Forms.MainMenu();
            this.menuMenuItem = new System.Windows.Forms.MenuItem();
            this.updateCheckTimerMenuItem = new System.Windows.Forms.MenuItem();
            this.separateMenuItem1 = new System.Windows.Forms.MenuItem();
            this.pocketLadioSettingMenuItem = new System.Windows.Forms.MenuItem();
            this.separateMenuItem2 = new System.Windows.Forms.MenuItem();
            this.versionInfoMenuItem = new System.Windows.Forms.MenuItem();
            this.separateMenuItem3 = new System.Windows.Forms.MenuItem();
            this.exitMenuItem = new System.Windows.Forms.MenuItem();
            this.updateMenuItem = new System.Windows.Forms.MenuItem();
            this.twitterListView = new System.Windows.Forms.ListView();
            this.screenNameColumnHeader = new System.Windows.Forms.ColumnHeader();
            this.doingColumnHeader = new System.Windows.Forms.ColumnHeader();
            this.dateColumnHeader = new System.Windows.Forms.ColumnHeader();
            this.profileSmallImageList = new System.Windows.Forms.ImageList();
            this.doingPostTextBox = new System.Windows.Forms.TextBox();
            this.doingContextMenu = new System.Windows.Forms.ContextMenu();
            this.cutDoingMenuItem = new System.Windows.Forms.MenuItem();
            this.copyDoingMenuItem = new System.Windows.Forms.MenuItem();
            this.pasteDoingMenuItem = new System.Windows.Forms.MenuItem();
            this.updateButton = new System.Windows.Forms.Button();
            this.inputPanel = new Microsoft.WindowsCE.Forms.InputPanel();
            this.updateCheckTimer = new System.Windows.Forms.Timer();
            this.twitterPictureBox = new System.Windows.Forms.PictureBox();
            this.profileBigImageList = new System.Windows.Forms.ImageList();
            this.doingInfomationTextBox = new System.Windows.Forms.TextBox();
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.Add(this.menuMenuItem);
            this.mainMenu.MenuItems.Add(this.updateMenuItem);
            // 
            // menuMenuItem
            // 
            this.menuMenuItem.MenuItems.Add(this.updateCheckTimerMenuItem);
            this.menuMenuItem.MenuItems.Add(this.separateMenuItem1);
            this.menuMenuItem.MenuItems.Add(this.pocketLadioSettingMenuItem);
            this.menuMenuItem.MenuItems.Add(this.separateMenuItem2);
            this.menuMenuItem.MenuItems.Add(this.versionInfoMenuItem);
            this.menuMenuItem.MenuItems.Add(this.separateMenuItem3);
            this.menuMenuItem.MenuItems.Add(this.exitMenuItem);
            this.menuMenuItem.Text = "メニュー(&M)";
            // 
            // updateCheckTimerMenuItem
            // 
            this.updateCheckTimerMenuItem.Text = "Twitterを一定間隔でチェック(&T)";
            this.updateCheckTimerMenuItem.Click += new System.EventHandler(this.updateCheckTimerMenuItem_Click);
            // 
            // separateMenuItem1
            // 
            this.separateMenuItem1.Text = "-";
            // 
            // pocketLadioSettingMenuItem
            // 
            this.pocketLadioSettingMenuItem.Text = "TwitterAway設定(&T)";
            this.pocketLadioSettingMenuItem.Click += new System.EventHandler(this.pocketLadioSettingMenuItem_Click);
            // 
            // separateMenuItem2
            // 
            this.separateMenuItem2.Text = "-";
            // 
            // versionInfoMenuItem
            // 
            this.versionInfoMenuItem.Text = "バージョン情報(&A)";
            this.versionInfoMenuItem.Click += new System.EventHandler(this.versionInfoMenuItem_Click);
            // 
            // separateMenuItem3
            // 
            this.separateMenuItem3.Text = "-";
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Text = "終了(&X)";
            this.exitMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
            // 
            // updateMenuItem
            // 
            this.updateMenuItem.Text = "Update";
            this.updateMenuItem.Click += new System.EventHandler(this.updateMenuItem_Click);
            // 
            // twitterListView
            // 
            this.twitterListView.Columns.Add(this.screenNameColumnHeader);
            this.twitterListView.Columns.Add(this.doingColumnHeader);
            this.twitterListView.Columns.Add(this.dateColumnHeader);
            this.twitterListView.Location = new System.Drawing.Point(3, 64);
            this.twitterListView.Size = new System.Drawing.Size(234, 174);
            this.twitterListView.SmallImageList = this.profileSmallImageList;
            this.twitterListView.View = System.Windows.Forms.View.Details;
            this.twitterListView.SelectedIndexChanged += new System.EventHandler(this.twitterListView_SelectedIndexChanged);
            // 
            // screenNameColumnHeader
            // 
            this.screenNameColumnHeader.Text = "Name";
            this.screenNameColumnHeader.Width = 60;
            // 
            // doingColumnHeader
            // 
            this.doingColumnHeader.Text = "What are you doing?";
            this.doingColumnHeader.Width = 120;
            // 
            // dateColumnHeader
            // 
            this.dateColumnHeader.Text = "Date";
            this.dateColumnHeader.Width = 50;
            // 
            // profileSmallImageList
            // 
            this.profileSmallImageList.ImageSize = new System.Drawing.Size(16, 16);
            // 
            // doingPostTextBox
            // 
            this.doingPostTextBox.ContextMenu = this.doingContextMenu;
            this.doingPostTextBox.Location = new System.Drawing.Point(3, 244);
            this.doingPostTextBox.Size = new System.Drawing.Size(164, 21);
            this.doingPostTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.doingTextBox_KeyUp);
            this.doingPostTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.doingTextBox_KeyPress);
            this.doingPostTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.doingTextBox_KeyDown);
            // 
            // doingContextMenu
            // 
            this.doingContextMenu.MenuItems.Add(this.cutDoingMenuItem);
            this.doingContextMenu.MenuItems.Add(this.copyDoingMenuItem);
            this.doingContextMenu.MenuItems.Add(this.pasteDoingMenuItem);
            // 
            // cutDoingMenuItem
            // 
            this.cutDoingMenuItem.Text = "切り取り(&T)";
            this.cutDoingMenuItem.Click += new System.EventHandler(this.cutDoingMenuItem_Click);
            // 
            // copyDoingMenuItem
            // 
            this.copyDoingMenuItem.Text = "コピー(&C)";
            this.copyDoingMenuItem.Click += new System.EventHandler(this.copyDoingMenuItem_Click);
            // 
            // pasteDoingMenuItem
            // 
            this.pasteDoingMenuItem.Text = "貼り付け(&P)";
            this.pasteDoingMenuItem.Click += new System.EventHandler(this.pasteDoingMenuItem_Click);
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(173, 244);
            this.updateButton.Size = new System.Drawing.Size(64, 20);
            this.updateButton.Text = "&Update";
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // inputPanel
            // 
            this.inputPanel.EnabledChanged += new System.EventHandler(this.inputPanel_EnabledChanged);
            // 
            // updateCheckTimer
            // 
            this.updateCheckTimer.Tick += new System.EventHandler(this.updateCheckTimer_Tick);
            // 
            // twitterPictureBox
            // 
            this.twitterPictureBox.Location = new System.Drawing.Point(3, 8);
            this.twitterPictureBox.Size = new System.Drawing.Size(44, 44);
            // 
            // profileBigImageList
            // 
            this.profileBigImageList.ImageSize = new System.Drawing.Size(44, 44);
            // 
            // doingInfomationTextBox
            // 
            this.doingInfomationTextBox.ForeColor = System.Drawing.SystemColors.Window;
            this.doingInfomationTextBox.Location = new System.Drawing.Point(53, 3);
            this.doingInfomationTextBox.Multiline = true;
            this.doingInfomationTextBox.ReadOnly = true;
            this.doingInfomationTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.doingInfomationTextBox.Size = new System.Drawing.Size(184, 55);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.doingInfomationTextBox);
            this.Controls.Add(this.twitterPictureBox);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.doingPostTextBox);
            this.Controls.Add(this.twitterListView);
            this.Menu = this.mainMenu;
            this.Text = "TwitterAway";
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.MainForm_Closing);
            this.Load += new System.EventHandler(this.MainForm_Load);

        }

        #endregion

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        static void Main()
        {
            try
            {
                Application.Run(new MainForm());

                // 終了処理
                try
                {
                    // 終了時処理
                    TwitterAwaySpecificProcess.ExitDisable();
                }
                catch (IOException)
                {
                    MessageBox.Show("設定ファイルが書き込めませんでした", "設定ファイル書き込みエラー");
                }
            }
            catch (Exception ex)
            {
                // ログに例外情報を書き込む
                Log exceptionLog = new Log(AssemblyUtility.GetExecutablePath() + @"\" + TwitterAwayInfo.ExceptionLogFile);
                StringBuilder error = new StringBuilder();


                error.Append("Application:       " +
                    TwitterAwayInfo.ApplicationName + " " + TwitterAwayInfo.VersionNumber + "\r\n");
                error.Append("Date:              " +
                    System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "\r\n");
                error.Append("OS:                " +
                    Environment.OSVersion.ToString() + "\r\n");
                error.Append("Culture:           " +
                    System.Globalization.CultureInfo.CurrentCulture.Name + "\r\n");
                error.Append("Exception class:   " +
                    ex.GetType().ToString() + "\r\n");
                error.Append("ToString:   " +
                    ex.ToString() + "\r\n");
                error.Append("Exception message: "
                     + "\r\n");
                error.Append(ex.Message);

                Exception innnerEx = ex.InnerException;
                while (innnerEx != null)
                {
                    error.Append(innnerEx.Message);
                    error.Append("\r\n");
                    innnerEx = innnerEx.InnerException;
                }

                error.Append("\r\n");
                error.Append("\r\n");

                exceptionLog.LogThis(error.ToString(), Log.LogPrefix.date);

#if DEBUG
                // デバッガで例外内容を確認するため、例外をアプリケーションの外に出す
                throw ex;
#else
                Trace.Assert(false, "予期しないエラーが発生したため、終了します");
#endif
            }
        }

        /// <summary>
        /// コントロールにアンカーをセットする
        /// </summary>
        private void SetAnchorControl()
        {
            anchorControlList.Add(new AnchorLayout(twitterPictureBox, AnchorStyles.Top | AnchorStyles.Left, TwitterAwayInfo.FormBaseWidth, TwitterAwayInfo.FormBaseHight));
            anchorControlList.Add(new AnchorLayout(doingInfomationTextBox, AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right, TwitterAwayInfo.FormBaseWidth, TwitterAwayInfo.FormBaseHight));
            anchorControlList.Add(new AnchorLayout(twitterListView, AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom, TwitterAwayInfo.FormBaseWidth, TwitterAwayInfo.FormBaseHight));
            anchorControlList.Add(new AnchorLayout(doingPostTextBox, AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom, TwitterAwayInfo.FormBaseWidth, TwitterAwayInfo.FormBaseHight));
            anchorControlList.Add(new AnchorLayout(updateButton, AnchorStyles.Right | AnchorStyles.Bottom, TwitterAwayInfo.FormBaseWidth, TwitterAwayInfo.FormBaseHight));
        }

        /// <summary>
        /// フォームのサイズ変更時にフォーム内の中身のサイズを適正に変更する
        /// </summary>
        private void FixWindowSize()
        {
            // コントロールを一端消す
            twitterListView.Visible = false;
            doingPostTextBox.Visible = false;
            updateButton.Visible = false;

            foreach (AnchorLayout anchorLayout in anchorControlList)
            {
                anchorLayout.LayoutControl();
            }

            // コントロールを出現させる
            twitterListView.Visible = true;
            doingPostTextBox.Visible = true;
            updateButton.Visible = true;
        }

        /// <summary>
        /// フォームのサイズ変更時にフォーム内の中身のサイズを適正に変更する
        /// </summary>
        /// <param name="parentControlWidth">レイアウトし直す親コントロールの領域の横幅</param>
        /// <param name="parentControlHeight">レイアウトし直す親コントロールの領域の高さ</param>
        private void FixWindowSize(int parentControlWidth, int parentControlHeight)
        {
            // コントロールを一端消す
            twitterListView.Visible = false;
            doingPostTextBox.Visible = false;
            updateButton.Visible = false;

            foreach (AnchorLayout anchorLayout in anchorControlList)
            {
                anchorLayout.LayoutControl(parentControlWidth, parentControlHeight);
            }

            // コントロールを出現させる
            twitterListView.Visible = true;
            doingPostTextBox.Visible = true;
            updateButton.Visible = true;
        }

        /// <summary>
        /// Twitterのチェックと投稿。テキストボックスの内容を投稿する。
        /// </summary>
        private void CheckTwitterUpdate()
        {
            CheckTwitterUpdate(true);
        }

        /// <summary>
        /// Twitterのチェックと投稿
        /// </summary>
        /// <param name="post">trueの場合、テキストボックスの内容を投稿する。</param>
        private void CheckTwitterUpdate(bool post)
        {
            // CheckHeadline()が処理の場合は何もせず終了
            if (checkTwitterUpdateNowFlag == true)
            {
                return;
            }

            // 排他処理のためのフラグを立てる
            checkTwitterUpdateNowFlag = true;

            #region UI前処理

            // フォームをいったん選択不可にする
            menuMenuItem.Enabled = false;
            updateMenuItem.Enabled = false;
            twitterListView.Enabled = false;
            updateButton.Enabled = false;

            #endregion

            Twitter.Twitter twitterAccount = new TwitterAway.Twitter.Twitter(UserSetting.UserName, UserSetting.Password);
            try
            {
                if (post == false || doingPostTextBox.Text == string.Empty)
                {
                    UpdateTwitterListView(twitterAccount);
                }
                else
                {
                    twitterAccount.Update(doingPostTextBox.Text);
                    doingPostTextBox.Text = string.Empty;
                    UpdateTwitterListView(twitterAccount);
                }
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    MessageBox.Show("ステータスをアップデートできませんでした。Twitterのユーザー名とパスワードが間違っている可能性があります。");
                }
                else if (ex.Status == WebExceptionStatus.Timeout)
                {
                    MessageBox.Show("ステータスをアップデートできませんでした。接続がタイムアウトしました。", "警告");
                }
                else
                {
                    MessageBox.Show("ステータスをアップデートできませんでした。", "警告");
                }
            }
            catch (UriFormatException)
            {
                MessageBox.Show("ステータスをアップデートできませんでした。ステータスが長すぎる可能性があります。", "警告");
            }
            finally
            {
                #region  UI後処理

                // フォームを選択可能に回復する
                menuMenuItem.Enabled = true;
                updateMenuItem.Enabled = true;
                twitterListView.Enabled = true;
                updateButton.Enabled = true;

                #endregion

                // 排他処理のためのフラグを下げる
                checkTwitterUpdateNowFlag = false;
            }

        }

        /// <summary>
        /// リストの更新
        /// </summary>
        /// <param name="twitterAccount">Twitterアカウント</param>
        private void UpdateTwitterListView(Twitter.Twitter twitterAccount)
        {
            twitterListView.Items.Clear();
            twitterListView.BeginUpdate();

            twitterStatuses = null;

            if (UserSetting.CheckList == UserSetting.CheckLists.Friends)
            {
                twitterStatuses = twitterAccount.FriendTimeline();
            }
            else if (UserSetting.CheckList == UserSetting.CheckLists.Public)
            {
                twitterStatuses = twitterAccount.PublicTimeline();
            }

            foreach (Twitter.StatusInfomation statusInfomation in twitterStatuses)
            {
                string date = string.Empty;
                if (DateTime.Today <= statusInfomation.CreatedAt)
                {
                    date = statusInfomation.CreatedAt.ToString("HH':'mm");
                }
                else
                {
                    date = statusInfomation.CreatedAt.ToString("M'/'d");
                }

                string[] str = { statusInfomation.User.Name, statusInfomation.Text, date };

                ListViewItem item = new ListViewItem(str);
                if (statusInfomation.User.ProfileImageUrl != null)
                {
                    item.ImageIndex = GetProfileImage(statusInfomation.User.ProfileImageUrl);
                }
                twitterListView.Items.Add(item);
            }

            twitterListView.EndUpdate();

            if (twitterStatuses.Length == 0)
            {
                MessageBox.Show("ステータスがありません。", "情報");
            }
        }

        /// <summary>
        /// プロフィールイメージのURLとインデックスの値のハッシュ
        /// </summary>
        private Hashtable profileIndexHashTable = new Hashtable();

        /// <summary>
        /// ProfileImageのURLからImageを取得、ImageListを作成し、URLに該当するImageListのIndexを返す。
        /// 一度URLから取得したImageは、ImageListに格納したままIndexのみを返す。
        /// </summary>
        /// <param name="profileImageUrl"></param>
        /// <returns></returns>
        private int GetProfileImage(Uri profileImageUrl)
        {
            // すでにハッシュにURLのキーがある場合（profileImageListに既にイメージがある場合）
            if (profileIndexHashTable.ContainsKey(profileImageUrl) == true)
            {
                return (int)profileIndexHashTable[profileImageUrl];
            }
            // ハッシュににURLのキーがない場合
            else
            {
                // イメージを取得する
                Stream st = null;
                Image image = null;
                int value = -1;
                try
                {
                    st = TwitterAwayUtility.GetWebStream(profileImageUrl);
                    image = new Bitmap(st);
                    profileSmallImageList.Images.Add(image);
                    profileBigImageList.Images.Add(image);
                    value = profileSmallImageList.Images.Count - 1;
                    profileIndexHashTable[profileImageUrl] = value;
                }
                catch
                {
                    if (image != null && value != -1)
                    {
                        profileSmallImageList.Images.RemoveAt(profileSmallImageList.Images.Count - 1);
                        profileBigImageList.Images.RemoveAt(profileSmallImageList.Images.Count - 1);
                    }
                    value = -1;
                    profileIndexHashTable[profileImageUrl] = value;
                }
                finally
                {
                    if (st != null)
                    {
                        st.Close();
                    }
                }

                return value;
            }
        }

        /// <summary>
        /// タイマーのスタート時の処理
        /// </summary>
        private void UpdateCheckTimerStart()
        {
            UserSetting.UpdateTimerCheck = true;
            updateCheckTimerMenuItem.Checked = true;
            updateCheckTimer.Interval = UserSetting.UpdateTimerMillSecond;
            updateCheckTimer.Enabled = true;
        }

        /// <summary>
        /// タイマーのストップ時の処理
        /// </summary>
        private void UpdateCheckTimerStop()
        {
            UserSetting.UpdateTimerCheck = false;
            updateCheckTimerMenuItem.Checked = false;
            updateCheckTimer.Enabled = false;
        }

        /// <summary>
        /// タイマーのインターバルが変更されたときの処理
        /// </summary>
        /// <param name="interval">タイマーのインターバル</param>
        public void UpdateTimerIntervalChange(int interval)
        {
            if (UserSetting.UpdateTimerCheck == true)
            {
                updateCheckTimer.Enabled = false;
                updateCheckTimer.Interval = interval;
                updateCheckTimer.Enabled = true;
            }
            else
            {
                updateCheckTimer.Interval = interval;
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            CheckTwitterUpdate();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                // 起動時のチェック
                TwitterAwaySpecificProcess.StartUpCheck();
            }
            catch (DllNotFoundException ex)
            {
                MessageBox.Show(ex.Message);
                Application.Exit();

                return;
            }

            try
            {
                // 起動時の初期化
                TwitterAwaySpecificProcess.StartUpInitialize();

                // アップデートタイマーの設定が有効な場合、タイマーを動作させる
                if (UserSetting.UpdateTimerCheck == true)
                {
                    UpdateCheckTimerStart();
                }
                else
                {
                    UpdateCheckTimerStop();
                }
            }
            catch (XmlException)
            {
                MessageBox.Show("設定ファイルが読み込めませんでした", "設定ファイルの解析エラー");
            }
            catch (IOException)
            {
                MessageBox.Show("設定ファイルが読み込めませんでした", "設定ファイルの読み込みエラー");
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("設定ファイルが読み込めませんでした", "設定ファイルの読み込みエラー");
            }

            twitterListView.Columns[0].Width = UserSetting.TwitterListViewNameColumnWidth;
            twitterListView.Columns[1].Width = UserSetting.TwitterListViewDoingColumnWidth;
            twitterListView.Columns[2].Width = UserSetting.TwitterListViewDateColumnWidth;

            SetAnchorControl();
            FixWindowSize();
        }

        private void versionInfoMenuItem_Click(object sender, EventArgs e)
        {
            VersionInfoForm versionInfoForm = new VersionInfoForm();
            versionInfoForm.ShowDialog();
            versionInfoForm.Dispose();
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            Close();
            Application.Exit();
        }

        private void pocketLadioSettingMenuItem_Click(object sender, EventArgs e)
        {
            SettingForm settingForm = new SettingForm();
            settingForm.ShowDialog();
            settingForm.Dispose();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            FixWindowSize();
        }

        private void inputPanel_EnabledChanged(object sender, EventArgs e)
        {
            // SPIの表示後は、SIPが返すデスクトップ領域のサイズを元にコントロールのレイアウトを変更し、
            // SIPの消去後は、親コントロール（MainFormのこと）のサイズを元にコントロールをレイアウトを変更する。
            // SIPの消去後にSIPが返すデスクトップ領域のサイズが、実際のサイズよりも縦に大きいことがあったため、
            // SIPの消去後は、親コントロールのサイズを元にレイアウトした。
            if (inputPanel.Enabled == true)
            {
                FixWindowSize(inputPanel.VisibleDesktop.Width, inputPanel.VisibleDesktop.Height);
            }
            else
            {
                FixWindowSize();
            }
        }

        private void cutDoingMenuItem_Click(object sender, EventArgs e)
        {
            ClipboardTextBox.Cut(doingPostTextBox);
        }

        private void copyDoingMenuItem_Click(object sender, EventArgs e)
        {
            ClipboardTextBox.Copy(doingPostTextBox);
        }

        private void pasteDoingMenuItem_Click(object sender, EventArgs e)
        {
            ClipboardTextBox.Paste(doingPostTextBox);
        }

        private void doingTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            // 入力ボタンを押したとき
            if (e.KeyCode == Keys.Enter)
            {
                updateButton_Click(sender, e);
            }
            // 切り取りショートカット
            else if (e.KeyCode == Keys.X && e.Control)
            {
                ClipboardTextBox.Cut(doingPostTextBox);
            }
            // 貼り付けショートカット
            else if (e.KeyCode == Keys.V && e.Control)
            {
                ClipboardTextBox.Paste(doingPostTextBox);
            }
        }

        private void doingTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 入力ボタンを押したときの音を消すため
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
            }
        }

        private void doingTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            // コピーショートカット
            if (e.KeyCode == Keys.C && e.Control)
            {
                ClipboardTextBox.Copy(doingPostTextBox);
            }
        }

        private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            UserSetting.TwitterListViewNameColumnWidth = twitterListView.Columns[0].Width;
            UserSetting.TwitterListViewDoingColumnWidth = twitterListView.Columns[1].Width;
            UserSetting.TwitterListViewDateColumnWidth = twitterListView.Columns[2].Width;
        }

        private void updateMenuItem_Click(object sender, EventArgs e)
        {
            updateButton_Click(sender, e);
        }

        private void updateCheckTimerMenuItem_Click(object sender, EventArgs e)
        {
            if (UserSetting.UpdateTimerCheck == true)
            {
                UpdateCheckTimerStop();
            }
            else if (UserSetting.UpdateTimerCheck == false)
            {
                UpdateCheckTimerStart();
            }
        }

        private void updateCheckTimer_Tick(object sender, EventArgs e)
        {
            CheckTwitterUpdate(false);
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            UpdateTimerIntervalChange(UserSetting.UpdateTimerMillSecond);
        }

        private void twitterListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            // リストビューに選択がある場合
            if (twitterListView.SelectedIndices.Count == 1 && twitterListView.SelectedIndices[0] < twitterStatuses.Length)
            {
                Twitter.StatusInfomation status = twitterStatuses[twitterListView.SelectedIndices[0]];
                doingInfomationTextBox.Text = status.User.Name + "\r\n" + status.Text;

                if (profileIndexHashTable.ContainsKey(status.User.ProfileImageUrl) == true && (int)profileIndexHashTable[status.User.ProfileImageUrl] < profileBigImageList.Images.Count)
                {
                    twitterPictureBox.Image = (Image)profileBigImageList.Images[(int)profileIndexHashTable[status.User.ProfileImageUrl]];
                }
                else
                {
                    twitterPictureBox.Image = null;
                }
            }
            // リストビューに選択がない場合
            else
            {
                doingInfomationTextBox.Text = string.Empty;
                twitterPictureBox.Image = null;
            }
        }
    }
}
