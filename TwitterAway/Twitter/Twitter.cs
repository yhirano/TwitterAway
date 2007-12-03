#region ディレクティブを使用する

using System;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Xml;
using System.Text;
using MiscPocketCompactLibrary.Net;

#endregion

namespace TwitterAway.Twitter
{
    /// <summary>
    /// Twitterクラス
    /// </summary>
    public class Twitter
    {
        /// <summary>
        /// ユーザー名
        /// </summary>
        private string userName;

        /// <summary>
        /// パスワード
        /// </summary>
        private string password;

        /// <summary>
        /// public ステータスリスト
        /// </summary>
        private ArrayList publicStatuses = new ArrayList();

        /// <summary>
        /// Friends ステータスリスト
        /// </summary>
        private ArrayList friendsStatuses = new ArrayList();

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="userName">ユーザ名</param>
        /// <param name="password">パスワード</param>
        public Twitter(string userName, string password)
        {
            this.userName = userName;
            this.password = password;
        }

        /// <summary>
        /// PublicTimelineを取得する
        /// </summary>
        /// <returns>取得したPublicTimelineのステータス情報</returns>
        public StatusInfomation[] PublicTimeline()
        {
            WebStream st = null;
            StatusInfomation[] statuses;

            try
            {
                st = TwitterAwayUtility.GetWebStream(new Uri(TwitterAwayInfo.TwitterPublicTimelineXml));
                statuses = PaeseStatuses(st);
            }
            finally
            {
                if (st != null)
                {
                    st.Close();
                }
            }

            return statuses;
        }

        /// <summary>
        /// FriendTimelineを取得する
        /// </summary>
        /// <returns>取得したFriendTimelineのステータス情報</returns>
        public StatusInfomation[] FriendTimeline()
        {
            WebStream st = null;
            StatusInfomation[] statuses;

            try
            {
                st = TwitterAwayUtility.GetWebStream(new Uri(TwitterAwayInfo.TwitterFriendsTimelineXml), userName, password);
                statuses = PaeseStatuses(st);
            }
            finally
            {
                if (st != null)
                {
                    st.Close();
                }
            }

            return statuses;
        }

        /// <summary>
        /// Stream内のXMLをステータス情報にパージングする
        /// </summary>
        /// <param name="st">Stream</param>
        /// <returns>ステータス情報</returns>
        private StatusInfomation[] PaeseStatuses(Stream st)
        {
            XmlTextReader reader = null;

            // ステータスのリスト
            ArrayList statuses = new ArrayList();

            try
            {
                reader = new XmlTextReader(st);

                // ステータス
                StatusInfomation status = null;
                // ユーザー
                UserInfomation user = null;
                // userタグの中にいるか
                bool inUserFlag = false;

                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        if (reader.LocalName == "status")
                        {
                            status = new StatusInfomation();
                        } // End of status
                        else if (reader.LocalName == "created_at")
                        {
                            status.SetCreatedAt(reader.ReadString());
                        } // End of created_at
                        else if (reader.LocalName == "id")
                        {
                            status.Id = reader.ReadString();
                        } // End of id
                        else if (reader.LocalName == "text")
                        {
                            status.Text = reader.ReadString();
                        } // End of text
                        else if (reader.LocalName == "user")
                        {
                            inUserFlag = true;
                            user = new UserInfomation();
                            status.User = user;

                        } // End of user
                        else if (inUserFlag == true)
                        {
                            if (reader.LocalName == "id")
                            {
                                user.Id = reader.ReadString();
                            } // End of id
                            else if (reader.LocalName == "name")
                            {
                                user.Name = reader.ReadString();
                            } // End of name
                            else if (reader.LocalName == "screen_name")
                            {
                                user.ScreenName = reader.ReadString();
                            } // End of screen_name
                            else if (reader.LocalName == "location")
                            {
                                user.Location = reader.ReadString();
                            } // End of location
                            else if (reader.LocalName == "description")
                            {
                                user.Description = reader.ReadString();
                            } // End of description
                            else if (reader.LocalName == "profile_image_url")
                            {
                                try
                                {
                                    user.ProfileImageUrl = new Uri(reader.ReadString());
                                }
                                catch (UriFormatException)
                                {
                                    ;
                                }
                            } // End of profile_image_url
                            else if (reader.LocalName == "url")
                            {
                                try
                                {
                                    user.Url = new Uri(reader.ReadString());
                                }
                                catch (UriFormatException)
                                {
                                    ;
                                }
                            } // End of url
                            else if (reader.LocalName == "protected")
                            {
                                if (reader.ReadString() == Boolean.TrueString)
                                {
                                    user.ProtectedMyUpdate = true;
                                }
                                else
                                {
                                    user.ProtectedMyUpdate = false;
                                }
                            } // End of protected
                        } // End of userタグの中にいるか
                    }
                    else if (reader.NodeType == XmlNodeType.EndElement)
                    {
                        if (reader.LocalName == "status")
                        {
                            statuses.Add(status);
                        }
                        else if (reader.LocalName == "user")
                        {
                            inUserFlag = false;
                        }
                    }
                }
            }
            catch (WebException)
            {
                throw;
            }
            catch (OutOfMemoryException)
            {
                throw;
            }
            catch (IOException)
            {
                throw;
            }
            catch (UriFormatException)
            {
                throw;
            }
            catch (SocketException)
            {
                throw;
            }
            catch (XmlException)
            {
                throw;
            }
            catch (ArgumentException)
            {
                throw;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }

            return (StatusInfomation[])statuses.ToArray(typeof(StatusInfomation));
        }

        /// <summary>
        /// メッセージをUpdateする
        /// </summary>
        /// <param name="message">メッセージ</param>
        public void Update(string message)
        {
            string sendMessage = string.Empty;

            // 送信メッセージをUTF-8化してバイト列に入れる
            byte[] messageBytes = Encoding.Convert(Encoding.Unicode, Encoding.UTF8, Encoding.Unicode.GetBytes(message));

            // URLエンコード
            foreach (byte b in messageBytes)
            {
                sendMessage += "%" + b.ToString("X2");
            }

            WebStream st = null;

            try
            {
                string send = TwitterAwayInfo.TwitterUpdateXml + "?status=" + sendMessage;
                st = TwitterAwayUtility.GetWebStream(new Uri(send), "POST", userName, password);
            }
            catch (WebException)
            {
                throw;
            }
            catch (UriFormatException)
            {
                throw;
            }
            finally
            {
                if (st != null)
                {
                    st.Close();
                }
            }
        }
    }
}
