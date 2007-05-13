#region ディレクティブを使用する

using System;
using System.Text;
using System.IO;
using System.Xml;
using MiscPocketCompactLibrary.Reflection;

#endregion

namespace TwitterAway
{
    /// <summary>
    /// TwitterAwayの設定を保持するクラス
    /// </summary>
    public class UserSetting
    {
        /// <summary>
        /// Twitterユーザー名
        /// </summary>
        private static string userName;

        /// <summary>
        /// Twitterユーザー名
        /// </summary>
        public static string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        /// <summary>
        /// Twitterパスワード
        /// </summary>
        private static string password;

        /// <summary>
        /// Twitterパスワード
        /// </summary>
        public static string Password
        {
            get { return password; }
            set { password = value; }
        }

        /// <summary>
        /// チェックするリスト列挙
        /// </summary>
        public enum CheckLists
        {
            Friends, Public
        }

        /// <summary>
        /// チェックするリスト
        /// </summary>
        private static CheckLists checkList = CheckLists.Friends;

        /// <summary>
        /// チェックするリスト
        /// </summary>
        public static CheckLists CheckList
        {
            get { return checkList; }
            set { checkList = value; }
        }

        /// <summary>
        /// タイマーでチェックするか
        /// </summary>
        private static bool updateTimerCheck;

        /// <summary>
        /// タイマーでチェックするか
        /// </summary>
        public static bool UpdateTimerCheck
        {
            get { return updateTimerCheck; }
            set { updateTimerCheck = value; }
        }

        /// <summary>
        /// タイマーのチェック時間
        /// </summary>
        private static int updateTimerMillSecond = 60000;

        /// <summary>
        /// タイマーのチェック時間
        /// </summary>
        public static int UpdateTimerMillSecond
        {
            get { return updateTimerMillSecond; }
            set
            {
                // 規定に収まる場合
                if (TwitterAwayInfo.UpdateTimerMinimumMillSec <= value && value <= TwitterAwayInfo.UpdateTimerMaximumMillSec)
                {
                    updateTimerMillSecond = value;
                }
                // 規定よりも短い場合
                else if (value < TwitterAwayInfo.UpdateTimerMinimumMillSec)
                {
                    updateTimerMillSecond = TwitterAwayInfo.UpdateTimerMinimumMillSec;
                }
                // 規定よりも長い場合
                else if (value > TwitterAwayInfo.UpdateTimerMaximumMillSec)
                {
                    updateTimerMillSecond = TwitterAwayInfo.UpdateTimerMaximumMillSec;
                }
            }
        }

        /// <summary>
        /// プロキシの接続方法列挙
        /// </summary>
        public enum ProxyConnects
        {
            Unuse, OsSetting, OriginalSetting
        }

        /// <summary>
        /// プロキシの接続方法
        /// </summary>
        private static ProxyConnects proxyUse = ProxyConnects.OsSetting;

        /// <summary>
        /// プロキシの接続方法
        /// </summary>
        public static ProxyConnects ProxyUse
        {
            get { return UserSetting.proxyUse; }
            set { UserSetting.proxyUse = value; }
        }

        /// <summary>
        /// プロキシのサーバ名
        /// </summary>
        private static string proxyServer = "";

        /// <summary>
        /// プロキシのサーバ名
        /// </summary>
        public static string ProxyServer
        {
            get { return proxyServer; }
            set { proxyServer = value; }
        }

        /// <summary>
        /// プロキシのポート番号
        /// </summary>
        private static int proxyPort = 0;

        /// <summary>
        /// プロキシのポート番号
        /// </summary>
        public static int ProxyPort
        {
            get
            {
                if (0x00 <= proxyPort && proxyPort <= 0xFFFF)
                {
                    return proxyPort;
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                if (0x00 <= value && value <= 0xFFFF)
                {
                    proxyPort = value;
                }
                else
                {
                    ;
                }
            }
        }

        /// <summary>
        /// アプリケーションの設定ファイルの保存場所
        /// </summary>
        private static string SettingPath
        {
            get
            {
                // アプリケーションの実行ディレクトリ + アプリケーションの設定ファイル
                return AssemblyUtility.GetExecutablePath() + @"\" + TwitterAwayInfo.SettingFile;
            }
        }

        /// <summary>
        /// TwitterListViewのName欄の幅
        /// </summary>
        private static int twitterListViewNameColumnWidth = 60;

        /// <summary>
        /// TwitterListViewのName欄の幅
        /// </summary>
        public static int TwitterListViewNameColumnWidth
        {
            get { return UserSetting.twitterListViewNameColumnWidth; }
            set { UserSetting.twitterListViewNameColumnWidth = value; }
        }

        /// <summary>
        /// TwitterListViewのDowing欄の幅
        /// </summary>
        private static int twitterListViewDoingColumnWidth = 120;

        /// <summary>
        /// TwitterListViewのDowing欄の幅
        /// </summary>
        public static int TwitterListViewDoingColumnWidth
        {
            get { return UserSetting.twitterListViewDoingColumnWidth; }
            set { UserSetting.twitterListViewDoingColumnWidth = value; }
        }

        /// <summary>
        /// TwitterListViewのDate欄の幅
        /// </summary>
        private static int twitterListViewDateColumnWidth = 50;

        /// <summary>
        /// TwitterListViewのDate欄の幅
        /// </summary>
        public static int TwitterListViewDateColumnWidth
        {
            get { return UserSetting.twitterListViewDateColumnWidth; }
            set { UserSetting.twitterListViewDateColumnWidth = value; }
        }

        /// <summary>
        /// シングルトンのためプライベート
        /// </summary>
        private UserSetting()
        {
        }

        /// <summary>
        /// 設定をファイルから読み込む
        /// </summary>
        public static void LoadSetting()
        {
            if (File.Exists(SettingPath))
            {
                FileStream fs = null;
                XmlTextReader reader = null;

                try
                {
                    fs = new FileStream(SettingPath, FileMode.Open, FileAccess.Read);
                    reader = new XmlTextReader(fs);

                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element)
                        {
                            if (reader.LocalName == "User")
                            {
                                if (reader.MoveToFirstAttribute())
                                {
                                    UserName = reader.GetAttribute("name");
                                    Password = reader.GetAttribute("password");
                                }
                            } // End of User
                            else if (reader.LocalName == "CheckList")
                            {
                                string check = reader.GetAttribute("list");
                                if (check == CheckLists.Friends.ToString())
                                {
                                    CheckList = CheckLists.Friends;
                                }
                                else if (check == CheckLists.Public.ToString())
                                {
                                    CheckList = CheckLists.Public;
                                }
                            } // End of CheckList
                            else if (reader.LocalName == "UpdateTimer")
                            {
                                if (reader.MoveToFirstAttribute())
                                {
                                    string check = reader.GetAttribute("check");
                                    if (check == bool.TrueString)
                                    {
                                        UpdateTimerCheck = true;
                                    }
                                    else if (check == bool.FalseString)
                                    {
                                        UpdateTimerCheck = false;
                                    }
                                    try
                                    {
                                        UpdateTimerMillSecond = Convert.ToInt32(reader.GetAttribute("millsecond"));
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
                                }
                            } // End of UpdateTimer
                            else if (reader.LocalName == "Proxy")
                            {
                                if (reader.MoveToFirstAttribute())
                                {
                                    string use = reader.GetAttribute("use");
                                    if (use == ProxyConnects.Unuse.ToString())
                                    {
                                        ProxyUse = ProxyConnects.Unuse;
                                    }
                                    else if (use == ProxyConnects.OsSetting.ToString())
                                    {
                                        ProxyUse = ProxyConnects.OsSetting;
                                    }
                                    else if (use == ProxyConnects.OriginalSetting.ToString())
                                    {
                                        ProxyUse = ProxyConnects.OriginalSetting;
                                    }

                                    ProxyServer = reader.GetAttribute("server");

                                    try
                                    {
                                        string port = reader.GetAttribute("port");
                                        ProxyPort = int.Parse(port);
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
                                }
                            } // End of Proxy
                            else if (reader.LocalName == "TwitterListViewColumnWidth")
                            {
                                if (reader.MoveToFirstAttribute())
                                {
                                    try
                                    {
                                        string nameWidth = reader.GetAttribute("name");
                                        TwitterListViewNameColumnWidth = int.Parse(nameWidth);
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
                                        string dowingWidth = reader.GetAttribute("doing");
                                        TwitterListViewDoingColumnWidth = int.Parse(dowingWidth);
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
                                        string dateWidth = reader.GetAttribute("date");
                                        TwitterListViewDateColumnWidth = int.Parse(dateWidth);
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
                                }
                            } // End of TwitterListViewColumnWidth
                        }
                    }
                }
                catch (XmlException)
                {
                    throw;
                }
                catch (IOException)
                {
                    throw;
                }
                finally
                {
                    reader.Close();
                    fs.Close();
                }
            }
        }

        /// <summary>
        /// 設定をファイルに保存
        /// </summary>
        public static void SaveSetting()
        {
            FileStream fs = null;
            XmlTextWriter writer = null;

            try
            {
                fs = new FileStream(SettingPath, FileMode.Create, FileAccess.Write);
                writer = new XmlTextWriter(fs, Encoding.GetEncoding("utf-8"));

                writer.Formatting = Formatting.Indented;
                writer.WriteStartDocument(true);

                writer.WriteStartElement("Setting");

                writer.WriteStartElement("Header");

                writer.WriteStartElement("Name");
                writer.WriteAttributeString("name", TwitterAwayInfo.ApplicationName);
                writer.WriteEndElement(); // End of Name.
                writer.WriteStartElement("Version");
                writer.WriteAttributeString("version", TwitterAwayInfo.VersionNumber);
                writer.WriteEndElement(); // End of Version.

                writer.WriteStartElement("Date");
                writer.WriteAttributeString("date", DateTime.Now.ToString());
                writer.WriteEndElement(); // End of Date.

                writer.WriteEndElement(); // End of Header.

                writer.WriteStartElement("Content");

                writer.WriteStartElement("User");
                writer.WriteAttributeString("name", UserName);
                writer.WriteAttributeString("password", Password);
                writer.WriteEndElement(); // End of User

                writer.WriteStartElement("CheckList");
                writer.WriteAttributeString("list", CheckList.ToString());
                writer.WriteEndElement(); // End of CheckList

                writer.WriteStartElement("UpdateTimer");
                writer.WriteAttributeString("check", UpdateTimerCheck.ToString());
                writer.WriteAttributeString("millsecond", UpdateTimerMillSecond.ToString());
                writer.WriteEndElement(); // End of UpdateTimer

                writer.WriteStartElement("Proxy");
                writer.WriteAttributeString("use", ProxyUse.ToString());
                writer.WriteAttributeString("server", ProxyServer);
                writer.WriteAttributeString("port", ProxyPort.ToString());
                writer.WriteEndElement(); // End of Porxy

                writer.WriteStartElement("TwitterListViewColumnWidth");
                writer.WriteAttributeString("name", TwitterListViewNameColumnWidth.ToString());
                writer.WriteAttributeString("doing", TwitterListViewDoingColumnWidth.ToString());
                writer.WriteAttributeString("date", TwitterListViewDateColumnWidth.ToString());
                writer.WriteEndElement(); // End of TwitterListViewColumnWidth

                writer.WriteEndElement(); // End of Content.

                writer.WriteEndElement(); // End of Setting.

                writer.WriteEndDocument();
            }
            catch (IOException)
            {
                throw;
            }
            finally
            {
                writer.Close();
                fs.Close();
            }
        }
    }
}
