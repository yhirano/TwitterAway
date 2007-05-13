#region ディレクティブを使用する

using System;
using System.IO;
using MiscPocketCompactLibrary.Runtime.InteropServices;
using MiscPocketCompactLibrary.Net;

#endregion

namespace TwitterAway
{
    /// <summary>
    /// PocketLadioのユーティリティ
    /// </summary>
    public sealed class TwitterAwayUtility
    {
        /// <summary>
        /// シングルトンのためプライベート
        /// </summary>
        private TwitterAwayUtility()
        {
        }

        /// <summary>
        /// Web上のストリームを返す
        /// </summary>
        /// <param name="url">URL</param>
        /// <returns>Web上のストリーム</returns>
        public static WebStream GetWebStream(Uri url)
        {
            return GetWebStream(url, string.Empty, string.Empty, string.Empty);
        }

        /// <summary>
        /// Web上のストリームを返す
        /// </summary>
        /// <param name="url">URL</param>
        /// <param name="requestMethod">HTTPリクエストメソッド</param>
        /// <returns>Web上のストリーム</returns>
        public static WebStream GetWebStream(Uri url, string requestMethod)
        {
            return GetWebStream(url, requestMethod, string.Empty, string.Empty);
        }

        /// <summary>
        /// Web上のストリームを返す
        /// </summary>
        /// <param name="url">URL</param>
        /// <param name="userName">Web認証のユーザー名</param>
        /// <param name="password">Web認証のパスワード</param>
        /// <returns>Web上のストリーム</returns>
        public static WebStream GetWebStream(Uri url, string userName, string password)
        {
            return GetWebStream(url, string.Empty, userName, password);
        }

        /// <summary>
        /// Web上のストリームを返す
        /// </summary>
        /// <param name="url">URL</param>
        /// <param name="requestMethod">HTTPリクエストメソッド</param>
        /// <param name="userName">Web認証のユーザー名</param>
        /// <param name="password">Web認証のパスワード</param>
        /// <returns>Web上のストリーム</returns>
        public static WebStream GetWebStream(Uri url, string requestMethod, string userName, string password)
        {
            WebStream ws;
            if (userName != null && userName != string.Empty)
            {
                ws = new WebStream(url, userName, password);
            }
            else
            {
                ws = new WebStream(url);
            }

            if (requestMethod != null && requestMethod != string.Empty)
            {
                ws.Method = requestMethod;
            }

            if (TwitterAway.UserSetting.ProxyUse == UserSetting.ProxyConnects.Unuse)
            {
                ws.ProxyUse = WebStream.ProxyConnect.Unuse;
            }
            else if (TwitterAway.UserSetting.ProxyUse == UserSetting.ProxyConnects.OsSetting)
            {
                ws.ProxyUse = WebStream.ProxyConnect.OsSetting;
            }
            else if (TwitterAway.UserSetting.ProxyUse == UserSetting.ProxyConnects.OriginalSetting)
            {
                ws.ProxyUse = WebStream.ProxyConnect.OriginalSetting;
            }
            ws.ProxyServer = TwitterAway.UserSetting.ProxyServer;
            ws.ProxyPort = TwitterAway.UserSetting.ProxyPort;
            ws.TimeOut = TwitterAwayInfo.WebRequestTimeoutMillSec;
            ws.UserAgent = TwitterAwayInfo.UserAgent;
            ws.AddHeader("X-Twitter-Client", TwitterAwayInfo.ApplicationName);
            ws.AddHeader("X-Twitter-Client-Version", TwitterAwayInfo.VersionNumber);
            ws.CreateWebStream();

            return ws;
        }
    }
}
