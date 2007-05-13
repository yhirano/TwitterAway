#region ディレクティブを使用する

using System;

#endregion

namespace TwitterAway
{
    /// <summary>
    /// TwitterAwayの固有情報を記述しているクラス
    /// </summary>
    public sealed class TwitterAwayInfo
    {
        #region アプリケーション固有の情報

        /// <summary>
        /// アプリケーション名
        /// </summary>
        private const string APPLICATION_NAME = "TwitterAway";

        /// <summary>
        /// アプリケーション名
        /// </summary>
        public static string ApplicationName
        {
            get { return APPLICATION_NAME; }
        }

        /// <summary>
        /// アプリケーションのバージョン
        /// </summary>
        private const string VERSION_NUMBER = "0.5";

        /// <summary>
        /// アプリケーションのバージョン
        /// </summary>
        public static string VersionNumber
        {
            get { return VERSION_NUMBER; }
        }

        /// <summary>
        /// 著作権情報
        /// </summary>
        private const string COPYRIGHT = "Copyright (C) 2007 Uraroji";

        /// <summary>
        /// 著作権情報
        /// </summary>
        public static string Copyright
        {
            get { return COPYRIGHT; }
        }

        #endregion

        #region アプリケーションの設定

        /// <summary>
        /// アップデートタイマーの上限
        /// </summary>
        private const int UPDATE_TIMER_MAXIMUM_MILL_SEC = 600000;

        /// <summary>
        /// アップデートタイマーの上限
        /// </summary>
        public static int UpdateTimerMaximumMillSec
        {
            get { return UPDATE_TIMER_MAXIMUM_MILL_SEC; }
        }

        /// <summary>
        /// アップデートタイマーの下限 
        /// </summary>
        private const int UPDATE_TIMER_MINIMUM_MILL_SEC = 15000;

        /// <summary>
        /// アップデートタイマーの下限 
        /// </summary>
        public static int UpdateTimerMinimumMillSec
        {
            get { return UPDATE_TIMER_MINIMUM_MILL_SEC; }
        }

        /// <summary>
        /// Web接続時のタイムアウト時間
        /// </summary>
        private const int WEB_REQUEST_TIMEOUT_MILL_SEC = 20000;

        /// <summary>
        /// Web接続時のタイムアウト時間
        /// </summary>
        public static int WebRequestTimeoutMillSec
        {
            get { return WEB_REQUEST_TIMEOUT_MILL_SEC; }
        }

        /// <summary>
        /// ネットアクセス時のUserAgent設定
        /// </summary>
        private const string USER_AGENT = APPLICATION_NAME + "/" + VERSION_NUMBER;

        /// <summary>
        /// ネットアクセス時のUserAgent設定
        /// </summary>
        public static string UserAgent
        {
            get { return USER_AGENT; }
        }

        /// <summary>
        /// Public TimelineのTwitter API URL
        /// </summary>
        private const string TWITTER_PUBLIC_TIMELINE_XML = "http://twitter.com/statuses/public_timeline.xml";

        /// <summary>
        /// Public TimelineのTwitter API URL
        /// </summary>
        public static string TwitterPublicTimelineXml
        {
            get { return TWITTER_PUBLIC_TIMELINE_XML; }
        }

        /// <summary>
        /// Friends TimelineのTwitter API URL
        /// </summary>
        private const string TWITTER_FRIENDS_TIMELINE_XML = "http://twitter.com/statuses/friends_timeline.xml";

        /// <summary>
        /// Friends TimelineのTwitter API URL
        /// </summary>
        public static string TwitterFriendsTimelineXml
        {
            get { return TWITTER_FRIENDS_TIMELINE_XML; }
        }

        /// <summary>
        /// UpdateのTwitter API URL
        /// </summary>
        private const string TWITTER_UPDATE_XML = "http://twitter.com/statuses/update.xml";

        /// <summary>
        /// UpdateのTwitter API URL
        /// </summary>
        public static string TwitterUpdateXml
        {
            get { return TWITTER_UPDATE_XML; }
        }

        /// <summary>
        /// メインフォームの幅。
        /// フォームデザインはこの幅をベースにControlを置いている。
        /// </summary>
        private const int FORM_BASE_WIDRH = 240;

        /// <summary>
        /// メインフォームの幅。
        /// フォームデザインはこの幅をベースにControlを置いている。
        /// </summary>
        public static int FormBaseWidth
        {
            get { return FORM_BASE_WIDRH; }
        }

        /// <summary>
        /// メインフォームの高さ。
        /// フォームデザインはこの高さをベースにControlを置いている。
        /// </summary>
        private const int FORM_BASE_HIGHT = 268;

        /// <summary>
        /// メインフォームの高さ。
        /// フォームデザインはこの高さをベースにControlを置いている。
        /// </summary>
        public static int FormBaseHight
        {
            get { return FORM_BASE_HIGHT; }
        }

        /// <summary>
        /// アプリケーションの設定ファイル
        /// </summary>
        private const string SETTING_FILE = "Setting.xml";

        /// <summary>
        /// アプリケーションの設定ファイル
        /// </summary>
        public static string SettingFile
        {
            get { return SETTING_FILE; }
        }

        /// <summary>
        /// 例外に出力するログファイル
        /// </summary>
        private const string EXCEPTION_LOG_FILE = "TwitterAwayExceptionLog.log";

        /// <summary>
        /// 例外に出力するログファイル
        /// </summary>
        public static string ExceptionLogFile
        {
            get { return EXCEPTION_LOG_FILE; }
        }

        #endregion

        /// <summary>
        /// シングルトンのためプライベート
        /// </summary>
        private TwitterAwayInfo()
        {
        }
    }
}
