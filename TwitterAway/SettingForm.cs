#region ディレクティブを使用する

using System;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Diagnostics;

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
            this.settingTabControl = new System.Windows.Forms.TabControl();
            this.settingTabPage = new System.Windows.Forms.TabPage();
            this.userNameLabel = new System.Windows.Forms.Label();
            this.userNameTextBox = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.okMenuItem = new System.Windows.Forms.MenuItem();
            this.networkTabPage = new System.Windows.Forms.TabPage();
            this.proxySettingPanel = new System.Windows.Forms.Panel();
            this.proxyUseOriginalSettingRadioButton = new System.Windows.Forms.RadioButton();
            this.proxyPortTextBox = new System.Windows.Forms.TextBox();
            this.proxyUseOsSettingRadioButton = new System.Windows.Forms.RadioButton();
            this.proxyServerTextBox = new System.Windows.Forms.TextBox();
            this.proxyUnuseRadioButton = new System.Windows.Forms.RadioButton();
            this.proxyPortLabel = new System.Windows.Forms.Label();
            this.proxyServerLabel = new System.Windows.Forms.Label();
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.Add(this.okMenuItem);
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
            // userNameLabel
            // 
            this.userNameLabel.Location = new System.Drawing.Point(3, 4);
            this.userNameLabel.Size = new System.Drawing.Size(72, 20);
            this.userNameLabel.Text = "ユーザー名";
            // 
            // userNameTextBox
            // 
            this.userNameTextBox.Location = new System.Drawing.Point(81, 4);
            this.userNameTextBox.Size = new System.Drawing.Size(156, 21);
            // 
            // passwordLabel
            // 
            this.passwordLabel.Location = new System.Drawing.Point(3, 31);
            this.passwordLabel.Size = new System.Drawing.Size(72, 20);
            this.passwordLabel.Text = "パスワード";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(81, 31);
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(156, 21);
            // 
            // okMenuItem
            // 
            this.okMenuItem.Text = "&OK";
            this.okMenuItem.Click += new System.EventHandler(this.okMenuItem_Click);
            // 
            // networkTabPage
            // 
            this.networkTabPage.Controls.Add(this.proxySettingPanel);
            this.networkTabPage.Location = new System.Drawing.Point(0, 0);
            this.networkTabPage.Size = new System.Drawing.Size(240, 245);
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
            this.proxyPortTextBox.Location = new System.Drawing.Point(3, 140);
            this.proxyPortTextBox.Size = new System.Drawing.Size(74, 21);
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
            this.proxyServerTextBox.Location = new System.Drawing.Point(3, 97);
            this.proxyServerTextBox.Size = new System.Drawing.Size(234, 21);
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

        private void ProxyPortTextBox_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void ProxyPortTextBox_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void ProxyServerTextBox_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void ProxyServerTextBox_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
