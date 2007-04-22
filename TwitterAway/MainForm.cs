#region Using directives

using System;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Diagnostics;
using System.Xml;
using System.Net;
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
        private ListView twitterListView;
        private ColumnHeader screenNameColumnHeader;
        private ColumnHeader doingColumnHeader;
        private TextBox doingTextBox;
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
        private System.Windows.Forms.MainMenu mainMenu1;

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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.menuMenuItem = new System.Windows.Forms.MenuItem();
            this.pocketLadioSettingMenuItem = new System.Windows.Forms.MenuItem();
            this.separateMenuItem1 = new System.Windows.Forms.MenuItem();
            this.versionInfoMenuItem = new System.Windows.Forms.MenuItem();
            this.separateMenuItem2 = new System.Windows.Forms.MenuItem();
            this.exitMenuItem = new System.Windows.Forms.MenuItem();
            this.twitterListView = new System.Windows.Forms.ListView();
            this.screenNameColumnHeader = new System.Windows.Forms.ColumnHeader();
            this.doingColumnHeader = new System.Windows.Forms.ColumnHeader();
            this.doingTextBox = new System.Windows.Forms.TextBox();
            this.updateButton = new System.Windows.Forms.Button();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.menuMenuItem);
            // 
            // menuMenuItem
            // 
            this.menuMenuItem.MenuItems.Add(this.pocketLadioSettingMenuItem);
            this.menuMenuItem.MenuItems.Add(this.separateMenuItem1);
            this.menuMenuItem.MenuItems.Add(this.versionInfoMenuItem);
            this.menuMenuItem.MenuItems.Add(this.separateMenuItem2);
            this.menuMenuItem.MenuItems.Add(this.exitMenuItem);
            this.menuMenuItem.Text = "メニュー(&M)";
            // 
            // pocketLadioSettingMenuItem
            // 
            this.pocketLadioSettingMenuItem.Text = "TwitterAway設定(&T)";
            this.pocketLadioSettingMenuItem.Click += new System.EventHandler(this.pocketLadioSettingMenuItem_Click);
            // 
            // separateMenuItem1
            // 
            this.separateMenuItem1.Text = "-";
            // 
            // versionInfoMenuItem
            // 
            this.versionInfoMenuItem.Text = "バージョン情報(&A)";
            this.versionInfoMenuItem.Click += new System.EventHandler(this.versionInfoMenuItem_Click);
            // 
            // separateMenuItem2
            // 
            this.separateMenuItem2.Text = "-";
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Text = "終了(&X)";
            this.exitMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
            // 
            // twitterListView
            // 
            this.twitterListView.Columns.Add(this.screenNameColumnHeader);
            this.twitterListView.Columns.Add(this.doingColumnHeader);
            this.twitterListView.Location = new System.Drawing.Point(3, 3);
            this.twitterListView.Size = new System.Drawing.Size(234, 235);
            this.twitterListView.View = System.Windows.Forms.View.Details;
            // 
            // screenNameColumnHeader
            // 
            this.screenNameColumnHeader.Text = "Name";
            this.screenNameColumnHeader.Width = 60;
            // 
            // doingColumnHeader
            // 
            this.doingColumnHeader.Text = "What are you doing?";
            this.doingColumnHeader.Width = 149;
            // 
            // doingTextBox
            // 
            this.doingTextBox.Location = new System.Drawing.Point(3, 244);
            this.doingTextBox.Size = new System.Drawing.Size(164, 21);
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(173, 244);
            this.updateButton.Size = new System.Drawing.Size(64, 20);
            this.updateButton.Text = "Update";
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.doingTextBox);
            this.Controls.Add(this.twitterListView);
            this.Menu = this.mainMenu1;
            this.Text = "TwitterAway";
            this.Resize += new System.EventHandler(this.MainForm_Resize);
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
                exceptionLog.LogThis(ex.Message, Log.LogPrefix.date);
                exceptionLog.LogThis(ex.ToString(), Log.LogPrefix.date);

                Trace.Assert(false, "予期しないエラーが発生したため、終了します");
            }
        }

        /// <summary>
        /// コントロールにアンカーをセットする
        /// </summary>
        private void SetAnchorControl()
        {
            anchorControlList.Add(new AnchorLayout(twitterListView, AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom, TwitterAwayInfo.FormBaseWidth, TwitterAwayInfo.FormBaseHight));
            anchorControlList.Add(new AnchorLayout(doingTextBox, AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom, TwitterAwayInfo.FormBaseWidth, TwitterAwayInfo.FormBaseHight));
            anchorControlList.Add(new AnchorLayout(updateButton, AnchorStyles.Right | AnchorStyles.Bottom, TwitterAwayInfo.FormBaseWidth, TwitterAwayInfo.FormBaseHight));
        }

        /// <summary>
        /// フォームのサイズ変更時にフォーム内の中身のサイズを適正に変更する
        /// </summary>
        private void FixWindowSize()
        {
            foreach (AnchorLayout anchorLayout in anchorControlList)
            {
                anchorLayout.LayoutControl();
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            #region UI前処理

            // フォームをいったん選択不可にする
            this.Enabled = false;

            #endregion

            Twitter.Twitter twitterAccount = new TwitterAway.Twitter.Twitter(UserSetting.UserName, UserSetting.Password);
            if (doingTextBox.Text == string.Empty)
            {
                UpdateTwitterListView(twitterAccount);
            }
            else
            {
                try
                {
                    twitterAccount.Update(doingTextBox.Text);
                    doingTextBox.Text = string.Empty;
                    UpdateTwitterListView(twitterAccount);
                }
                catch (WebException)
                {
                    MessageBox.Show("ステータスをアップデートできませんでした。Twitterのユーザー名とパスワードが間違っている可能性があります。");
                }
                catch (UriFormatException)
                {
                    MessageBox.Show("ステータスをアップデートできませんでした。ステータスが長すぎる可能性があります。");
                }
            }

            #region  UI後処理

            // フォームを選択可能に回復する
            this.Enabled = true;

            #endregion
        }

        private void UpdateTwitterListView(Twitter.Twitter twitterAccount)
        {
            twitterListView.Items.Clear();
            twitterListView.BeginUpdate();

            Twitter.StatusInfomation[] sts = twitterAccount.FriendTimeline();
            foreach (Twitter.StatusInfomation s in sts)
            {
                string[] str = { s.User.ScreenName, s.Text };
                twitterListView.Items.Add(new ListViewItem(str));
            }

            twitterListView.EndUpdate();
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
    }
}

