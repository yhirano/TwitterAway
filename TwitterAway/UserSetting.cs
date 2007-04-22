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
        /// プロキシの接続方法列挙
        /// </summary>
        public enum ProxyConnect
        {
            Unuse, OsSetting, OriginalSetting
        }

        /// <summary>
        /// プロキシの接続方法
        /// </summary>
        private static ProxyConnect proxyUse = ProxyConnect.OsSetting;

        /// <summary>
        /// プロキシの接続方法
        /// </summary>
        public static ProxyConnect ProxyUse
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
                            else if (reader.LocalName == "Proxy")
                            {
                                if (reader.MoveToFirstAttribute())
                                {
                                    string use = reader.GetAttribute("use");
                                    if (use == ProxyConnect.Unuse.ToString())
                                    {
                                        ProxyUse = ProxyConnect.Unuse;
                                    }
                                    else if (use == ProxyConnect.OsSetting.ToString())
                                    {
                                        ProxyUse = ProxyConnect.OsSetting;
                                    }
                                    else if (use == ProxyConnect.OriginalSetting.ToString())
                                    {
                                        ProxyUse = ProxyConnect.OriginalSetting;
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

                writer.WriteStartElement("Proxy");
                writer.WriteAttributeString("use", ProxyUse.ToString());
                writer.WriteAttributeString("server", ProxyServer);
                writer.WriteAttributeString("port", ProxyPort.ToString());
                writer.WriteEndElement(); // End of Porxy

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
