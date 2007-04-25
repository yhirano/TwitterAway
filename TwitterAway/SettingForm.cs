#region ディレクティブを使用する

using System;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Diagnostics;
using MiscPocketCompactLibrary.Windows.Forms;

#endregion

namespace TwitterAway
{
    /// <summary>
    /// SettingForm の概要の説明です。
    /// </summary>
    public class SettingForm : System.Windows.Forms.Form
    {
        private TabControl settingTabControl;
        private TabPage settingTabPage;
        private TextBox userNameTextBox;
        private Label userNameLabel;
        private TextBox passwordTextBox;
        private Label passwordLabel;
        private MenuItem okMenuItem;
        private TabPage networkTabPage;
        private Panel proxySettingPanel;
        private RadioButton proxyUseOriginalSettingRadioButton;
        private TextBox proxyPortTextBox;
        private RadioButton proxyUseOsSettingRadioButton;
        private TextBox proxyServerTextBox;
        private RadioButton proxyUnuseRadioButton;
        private Label proxyPortLabel;
        private Label proxyServerLabel;
        private ContextMenu proxyPortContextMenu;
        private MenuItem cutProxyPortMenuItem;
        private MenuItem copyProxyPortMenuItem;
        private MenuItem pasteProxyPortMenuItem;
        private ContextMenu proxyServerContextMenu;
        private MenuItem cutProxyServerMenuItem;
        private MenuItem copyProxyServerMenuItem;
        private MenuItem pasteProxyServerMenuItem;
        private ContextMenu userNameContextMenu;
        private MenuItem cutUserNamePathMenuItem;
        private MenuItem copyUserNameMenuItem;
        private MenuItem pasteUserNameMenuItem;
        private ContextMenu passwordPathContextMenu;
        private MenuItem cutPasswordPathMenuItem;
        private MenuItem copyPasswordPathMenuItem;
        private MenuItem pastePasswordPathMenuItem;
        /// <summary>
        /// フォームのメイン メニューです。
        /// </summary>
        private System.Windows.Forms.MainMenu mainMenu;

        public SettingForm()
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
            this.okMenuItem = new System.Windows.Forms.MenuItem();
            this.settingTabControl = new System.Windows.Forms.TabControl();
            this.settingTabPage = new System.Windows.Forms.TabPage();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.passwordPathContextMenu = new System.Windows.Forms.ContextMenu();
            this.cutPasswordPathMenuItem = new System.Windows.Forms.MenuItem();
            this.copyPasswordPathMenuItem = new System.Windows.Forms.MenuItem();
            this.pastePasswordPathMenuItem = new System.Windows.Forms.MenuItem();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.userNameTextBox = new System.Windows.Forms.TextBox();
            this.userNameContextMenu = new System.Windows.Forms.ContextMenu();
            this.cutUserNamePathMenuItem = new System.Windows.Forms.MenuItem();
            this.copyUserNameMenuItem = new System.Windows.Forms.MenuItem();
            this.pasteUserNameMenuItem = new System.Windows.Forms.MenuItem();
            this.userNameLabel = new System.Windows.Forms.Label();
            this.networkTabPage = new System.Windows.Forms.TabPage();
            this.proxySettingPanel = new System.Windows.Forms.Panel();
            this.proxyUseOriginalSettingRadioButton = new System.Windows.Forms.RadioButton();
            this.proxyPortTextBox = new System.Windows.Forms.TextBox();
            this.proxyPortContextMenu = new System.Windows.Forms.ContextMenu();
            this.cutProxyPortMenuItem = new System.Windows.Forms.MenuItem();
            this.copyProxyPortMenuItem = new System.Windows.Forms.MenuItem();
            this.pasteProxyPortMenuItem = new System.Windows.Forms.MenuItem();
            this.proxyUseOsSettingRadioButton = new System.Windows.Forms.RadioButton();
            this.proxyServerTextBox = new System.Windows.Forms.TextBox();
            this.proxyServerContextMenu = new System.Windows.Forms.ContextMenu();
            this.cutProxyServerMenuItem = new System.Windows.Forms.MenuItem();
            this.copyProxyServerMenuItem = new System.Windows.Forms.MenuItem();
            this.pasteProxyServerMenuItem = new System.Windows.Forms.MenuItem();
            this.proxyUnuseRadioButton = new System.Windows.Forms.RadioButton();
            this.proxyPortLabel = new System.Windows.Forms.Label();
            this.proxyServerLabel = new System.Windows.Forms.Label();
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.Add(this.okMenuItem);
            // 
            // okMenuItem
            // 
            this.okMenuItem.Text = "&OK";
            this.okMenuItem.Click += new System.EventHandler(this.okMenuItem_Click);
            // 
            // settingTabControl
            // 
            this.settingTabControl.Controls.Add(this.settingTabPage);
            this.settingTabControl.Controls.Add(this.networkTabPage);
            this.settingTabControl.Location = new System.Drawing.Point(0, 0);
            this.settingTabControl.SelectedIndex = 0;
            this.settingTabControl.Size = new System.Drawing.Size(240, 268);
            // 
            // settingTabPage
            // 
            this.settingTabPage.Controls.Add(this.passwordTextBox);
            this.settingTabPage.Controls.Add(this.passwordLabel);
            this.settingTabPage.Controls.Add(this.userNameTextBox);
            this.settingTabPage.Controls.Add(this.userNameLabel);
            this.settingTabPage.Location = new System.Drawing.Point(0, 0);
            this.settingTabPage.Size = new System.Drawing.Size(240, 245);
            this.settingTabPage.Text = "基本";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.ContextMenu = this.passwordPathContextMenu;
            this.passwordTextBox.Location = new System.Drawing.Point(81, 31);
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(156, 21);
            this.passwordTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.passwordTextBox_KeyUp);
            this.passwordTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.passwordTextBox_KeyDown);
            // 
            // passwordPathContextMenu
            // 
            this.passwordPathContextMenu.MenuItems.Add(this.cutPasswordPathMenuItem);
            this.passwordPathContextMenu.MenuItems.Add(this.copyPasswordPathMenuItem);
            this.passwordPathContextMenu.MenuItems.Add(this.pastePasswordPathMenuItem);
            // 
            // cutPasswordPathMenuItem
            // 
            this.cutPasswordPathMenuItem.Text = "切り取り(&T)";
            this.cutPasswordPathMenuItem.Click += new System.EventHandler(this.CutPasswordPathMenuItem_Click);
            // 
            // copyPasswordPathMenuItem
            // 
            this.copyPasswordPathMenuItem.Text = "コピー(&C)";
            this.copyPasswordPathMenuItem.Click += new System.EventHandler(this.CopyPasswordPathMenuItem_Click);
            // 
            // pastePasswordPathMenuItem
            // 
            this.pastePasswordPathMenuItem.Text = "貼り付け(&P)";
            this.pastePasswordPathMenuItem.Click += new System.EventHandler(this.PastePasswordPathMenuItem_Click);
            // 
            // passwordLabel
            // 
            this.passwordLabel.Location = new System.Drawing.Point(3, 31);
            this.passwordLabel.Size = new System.Drawing.Size(72, 20);
            this.passwordLabel.Text = "パスワード";
            // 
            // userNameTextBox
            // 
            this.userNameTextBox.ContextMenu = this.userNameContextMenu;
            this.userNameTextBox.Location = new System.Drawing.Point(81, 4);
            this.userNameTextBox.Size = new System.Drawing.Size(156, 21);
            this.userNameTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.userNameTextBox_KeyUp);
            this.userNameTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.userNameTextBox_KeyDown);
            // 
            // userNameContextMenu
            // 
            this.userNameContextMenu.MenuItems.Add(this.cutUserNamePathMenuItem);
            this.userNameContextMenu.MenuItems.Add(this.copyUserNameMenuItem);
            this.userNameContextMenu.MenuItems.Add(this.pasteUserNameMenuItem);
            // 
            // cutUserNamePathMenuItem
            // 
            this.cutUserNamePathMenuItem.Text = "切り取り(&T)";
            this.cutUserNamePathMenuItem.Click += new System.EventHandler(this.CutUserNameMenuItem_Click);
            // 
            // copyUserNameMenuItem
            // 
            this.copyUserNameMenuItem.Text = "コピー(&C)";
            this.copyUserNameMenuItem.Click += new System.EventHandler(this.CopyUserNameMenuItem_Click);
            // 
            // pasteUserNameMenuItem
            // 
            this.pasteUserNameMenuItem.Text = "貼り付け(&P)";
            this.pasteUserNameMenuItem.Click += new System.EventHandler(this.PasteUserNameMenuItem_Click);
            // 
            // userNameLabel
            // 
            this.userNameLabel.Location = new System.Drawing.Point(3, 4);
            this.userNameLabel.Size = new System.Drawing.Size(72, 20);
            this.userNameLabel.Text = "ユーザー名";
            // 
            // networkTabPage
            // 
            this.networkTabPage.Controls.Add(this.proxySettingPanel);
            this.networkTabPage.Location = new System.Drawing.Point(0, 0);
            this.networkTabPage.Size = new System.Drawing.Size(232, 242);
            this.networkTabPage.Text = "ネットワーク";
            // 
            // proxySettingPanel
            // 
            this.proxySettingPanel.Controls.Add(this.proxyUseOriginalSettingRadioButton);
            this.proxySettingPanel.Controls.Add(this.proxyPortTextBox);
            this.proxySettingPanel.Controls.Add(this.proxyUseOsSettingRadioButton);
            this.proxySettingPanel.Controls.Add(this.proxyServerTextBox);
            this.proxySettingPanel.Controls.Add(this.proxyUnuseRadioButton);
            this.proxySettingPanel.Controls.Add(this.proxyPortLabel);
            this.proxySettingPanel.Controls.Add(this.proxyServerLabel);
            this.proxySettingPanel.Location = new System.Drawing.Point(0, 0);
            this.proxySettingPanel.Size = new System.Drawing.Size(240, 169);
            // 
            // proxyUseOriginalSettingRadioButton
            // 
            this.proxyUseOriginalSettingRadioButton.Location = new System.Drawing.Point(3, 55);
            this.proxyUseOriginalSettingRadioButton.Size = new System.Drawing.Size(234, 20);
            this.proxyUseOriginalSettingRadioButton.Text = "プロキシを設定する";
            // 
            // proxyPortTextBox
            // 
            this.proxyPortTextBox.ContextMenu = this.proxyPortContextMenu;
            this.proxyPortTextBox.Location = new System.Drawing.Point(3, 140);
            this.proxyPortTextBox.Size = new System.Drawing.Size(74, 21);
            this.proxyPortTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ProxyPortTextBox_KeyUp);
            this.proxyPortTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ProxyPortTextBox_KeyDown);
            // 
            // proxyPortContextMenu
            // 
            this.proxyPortContextMenu.MenuItems.Add(this.cutProxyPortMenuItem);
            this.proxyPortContextMenu.MenuItems.Add(this.copyProxyPortMenuItem);
            this.proxyPortContextMenu.MenuItems.Add(this.pasteProxyPortMenuItem);
            // 
            // cutProxyPortMenuItem
            // 
            this.cutProxyPortMenuItem.Text = "切り取り(&T)";
            this.cutProxyPortMenuItem.Click += new System.EventHandler(this.CutProxyPortMenuItem_Click);
            // 
            // copyProxyPortMenuItem
            // 
            this.copyProxyPortMenuItem.Text = "コピー(&C)";
            this.copyProxyPortMenuItem.Click += new System.EventHandler(this.CopyProxyPortMenuItem_Click);
            // 
            // pasteProxyPortMenuItem
            // 
            this.pasteProxyPortMenuItem.Text = "貼り付け(&P)";
            this.pasteProxyPortMenuItem.Click += new System.EventHandler(this.PasteProxyPortMenuItem_Click);
            // 
            // proxyUseOsSettingRadioButton
            // 
            this.proxyUseOsSettingRadioButton.Checked = true;
            this.proxyUseOsSettingRadioButton.Location = new System.Drawing.Point(3, 29);
            this.proxyUseOsSettingRadioButton.Size = new System.Drawing.Size(234, 20);
            this.proxyUseOsSettingRadioButton.Text = "OSで設定したプロキシを使用する";
            // 
            // proxyServerTextBox
            // 
            this.proxyServerTextBox.ContextMenu = this.proxyServerContextMenu;
            this.proxyServerTextBox.Location = new System.Drawing.Point(3, 97);
            this.proxyServerTextBox.Size = new System.Drawing.Size(234, 21);
            this.proxyServerTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ProxyServerTextBox_KeyUp);
            this.proxyServerTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ProxyServerTextBox_KeyDown);
            // 
            // proxyServerContextMenu
            // 
            this.proxyServerContextMenu.MenuItems.Add(this.cutProxyServerMenuItem);
            this.proxyServerContextMenu.MenuItems.Add(this.copyProxyServerMenuItem);
            this.proxyServerContextMenu.MenuItems.Add(this.pasteProxyServerMenuItem);
            // 
            // cutProxyServerMenuItem
            // 
            this.cutProxyServerMenuItem.Text = "切り取り(&T)";
            this.cutProxyServerMenuItem.Click += new System.EventHandler(this.CutProxyServerMenuItem_Click);
            // 
            // copyProxyServerMenuItem
            // 
            this.copyProxyServerMenuItem.Text = "コピー(&C)";
            this.copyProxyServerMenuItem.Click += new System.EventHandler(this.CopyProxyServerMenuItem_Click);
            // 
            // pasteProxyServerMenuItem
            // 
            this.pasteProxyServerMenuItem.Text = "貼り付け(&P)";
            this.pasteProxyServerMenuItem.Click += new System.EventHandler(this.PasteProxyServerMenuItem_Click);
            // 
            // proxyUnuseRadioButton
            // 
            this.proxyUnuseRadioButton.Location = new System.Drawing.Point(3, 3);
            this.proxyUnuseRadioButton.Size = new System.Drawing.Size(234, 20);
            this.proxyUnuseRadioButton.Text = "プロキシに接続しない";
            // 
            // proxyPortLabel
            // 
            this.proxyPortLabel.Location = new System.Drawing.Point(3, 121);
            this.proxyPortLabel.Size = new System.Drawing.Size(234, 16);
            this.proxyPortLabel.Text = "プロキシのポート番号 （例： 8080）";
            // 
            // proxyServerLabel
            // 
            this.proxyServerLabel.Location = new System.Drawing.Point(3, 78);
            this.proxyServerLabel.Size = new System.Drawing.Size(234, 16);
            this.proxyServerLabel.Text = "プロキシサーバ （例：proxy.example.com）";
            // 
            // SettingForm
            // 
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.settingTabControl);
            this.Menu = this.mainMenu;
            this.Text = "設定";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.SettingForm_Closing);
            this.Load += new System.EventHandler(this.SettingForm_Load);

        }

        #endregion

        private void SettingForm_Load(object sender, EventArgs e)
        {
            // 設定の読み込み
            {
                userNameTextBox.Text = UserSetting.UserName;
                passwordTextBox.Text = UserSetting.Password;

                if (UserSetting.ProxyUse == UserSetting.ProxyConnect.Unuse)
                {
                    proxyUnuseRadioButton.Checked = true;
                    proxyUseOsSettingRadioButton.Checked = false;
                    proxyUseOriginalSettingRadioButton.Checked = false;
                }
                else if (UserSetting.ProxyUse == UserSetting.ProxyConnect.OsSetting)
                {
                    proxyUnuseRadioButton.Checked = false;
                    proxyUseOsSettingRadioButton.Checked = true;
                    proxyUseOriginalSettingRadioButton.Checked = false;
                }
                else if (UserSetting.ProxyUse == UserSetting.ProxyConnect.OriginalSetting)
                {
                    proxyUnuseRadioButton.Checked = false;
                    proxyUseOsSettingRadioButton.Checked = false;
                    proxyUseOriginalSettingRadioButton.Checked = true;
                }
                else
                {
                    // ここに到達することはあり得ない
                    Trace.Assert(false, "想定外の動作のため、終了します");
                }

                proxyServerTextBox.Text = UserSetting.ProxyServer;
                proxyPortTextBox.Text = UserSetting.ProxyPort.ToString();
            }
        }

        private void SettingForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // 設定の書き込み
            UserSetting.UserName = userNameTextBox.Text;
            UserSetting.Password = passwordTextBox.Text;

            if (proxyUnuseRadioButton.Checked == true)
            {
                UserSetting.ProxyUse = UserSetting.ProxyConnect.Unuse;
            }
            else if (proxyUseOsSettingRadioButton.Checked == true)
            {
                UserSetting.ProxyUse = UserSetting.ProxyConnect.OsSetting;
            }
            else if (proxyUseOriginalSettingRadioButton.Checked == true)
            {
                UserSetting.ProxyUse = UserSetting.ProxyConnect.OriginalSetting;
            }
            else
            {
                // ここに到達することはあり得ない
                Trace.Assert(false, "想定外の動作のため、終了します");
            }
            UserSetting.ProxyServer = proxyServerTextBox.Text.Trim();
            try
            {
                UserSetting.ProxyPort = int.Parse(proxyPortTextBox.Text.Trim());
            }
            catch (ArgumentException)
            {
                ;
            }
            catch (FormatException)
            {
                ;
            }
            catch (OverflowException)
            {
                ;
            }

            try
            {
                UserSetting.SaveSetting();
            }
            catch (IOException)
            {
                MessageBox.Show("設定ファイルが書き込めませんでした", "設定ファイル書き込みエラー");
            }
        }

        private void okMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutProxyServerMenuItem_Click(object sender, EventArgs e)
        {
            ClipboardTextBox.Cut(proxyServerTextBox);
        }

        private void CopyProxyServerMenuItem_Click(object sender, EventArgs e)
        {
            ClipboardTextBox.Copy(proxyServerTextBox);
        }

        private void PasteProxyServerMenuItem_Click(object sender, EventArgs e)
        {
            ClipboardTextBox.Paste(proxyServerTextBox);
        }

        private void CutProxyPortMenuItem_Click(object sender, EventArgs e)
        {
            ClipboardTextBox.Cut(proxyPortTextBox);
        }

        private void CopyProxyPortMenuItem_Click(object sender, EventArgs e)
        {
            ClipboardTextBox.Copy(proxyPortTextBox);
        }

        private void PasteProxyPortMenuItem_Click(object sender, EventArgs e)
        {
            ClipboardTextBox.Paste(proxyPortTextBox);
        }

        private void ProxyServerTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            // 切り取りショートカット
            if (e.KeyCode == Keys.X && e.Control)
            {
                ClipboardTextBox.Cut(proxyServerTextBox);
            }
            // 貼り付けショートカット
            else if (e.KeyCode == Keys.V && e.Control)
            {
                ClipboardTextBox.Paste(proxyServerTextBox);
            }
        }

        private void ProxyServerTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            // コピーショートカット
            if (e.KeyCode == Keys.C && e.Control)
            {
                ClipboardTextBox.Copy(proxyServerTextBox);
            }
        }

        private void ProxyPortTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            // 切り取りショートカット
            if (e.KeyCode == Keys.X && e.Control)
            {
                ClipboardTextBox.Cut(proxyPortTextBox);
            }
            // 貼り付けショートカット
            else if (e.KeyCode == Keys.V && e.Control)
            {
                ClipboardTextBox.Paste(proxyPortTextBox);
            }
        }

        private void ProxyPortTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            // コピーショートカット
            if (e.KeyCode == Keys.C && e.Control)
            {
                ClipboardTextBox.Copy(proxyPortTextBox);
            }
        }

        private void CutUserNameMenuItem_Click(object sender, EventArgs e)
        {
            ClipboardTextBox.Cut(userNameTextBox);
        }

        private void CopyUserNameMenuItem_Click(object sender, EventArgs e)
        {
            ClipboardTextBox.Copy(userNameTextBox);
        }

        private void PasteUserNameMenuItem_Click(object sender, EventArgs e)
        {
            ClipboardTextBox.Paste(userNameTextBox);
        }

        private void CutPasswordPathMenuItem_Click(object sender, EventArgs e)
        {
            ClipboardTextBox.Cut(passwordTextBox);
        }

        private void CopyPasswordPathMenuItem_Click(object sender, EventArgs e)
        {
            ClipboardTextBox.Copy(passwordTextBox);
        }

        private void PastePasswordPathMenuItem_Click(object sender, EventArgs e)
        {
            ClipboardTextBox.Cut(passwordTextBox);
        }

        private void userNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            // 切り取りショートカット
            if (e.KeyCode == Keys.X && e.Control)
            {
                ClipboardTextBox.Cut(userNameTextBox);
            }
            // 貼り付けショートカット
            else if (e.KeyCode == Keys.V && e.Control)
            {
                ClipboardTextBox.Paste(userNameTextBox);
            }
        }

        private void userNameTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            // コピーショートカット
            if (e.KeyCode == Keys.C && e.Control)
            {
                ClipboardTextBox.Copy(userNameTextBox);
            }
        }

        private void passwordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            // 切り取りショートカット
            if (e.KeyCode == Keys.X && e.Control)
            {
                ClipboardTextBox.Cut(passwordTextBox);
            }
            // 貼り付けショートカット
            else if (e.KeyCode == Keys.V && e.Control)
            {
                ClipboardTextBox.Paste(passwordTextBox);
            }
        }

        private void passwordTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            // コピーショートカット
            if (e.KeyCode == Keys.C && e.Control)
            {
                ClipboardTextBox.Copy(passwordTextBox);
            }
        }
    }
}
