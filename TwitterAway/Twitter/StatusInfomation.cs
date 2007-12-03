#region ディレクティブを使用する

using System;

#endregion

namespace TwitterAway.Twitter
{
    /// <summary>
    /// Twitterのステータス情報
    /// </summary>
    public class StatusInfomation
    {
        /// <summary>
        /// ステータス情報が作成された時刻
        /// </summary>
        private DateTime createdAt;

        /// <summary>
        /// ステータス情報が作成された時刻
        /// </summary>
        public DateTime CreatedAt
        {
            get { return createdAt; }
            set { createdAt = value; }
        }

        /// <summary>
        /// ID
        /// </summary>
        private string id;

        /// <summary>
        /// ID
        /// </summary>
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        private string text;

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        /// <summary>
        /// ユーザー情報
        /// </summary>
        private UserInfomation user;

        /// <summary>
        /// ユーザー情報
        /// </summary>
        public UserInfomation User
        {
            get { return user; }
            set { user = value; }
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public StatusInfomation()
        {
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="createdAt">ステータス情報が作成された時刻</param>
        /// <param name="id">ID</param>
        /// <param name="user">ユーザー情報</param>
        public StatusInfomation(DateTime createdAt, string id, UserInfomation user)
        {
            this.createdAt = createdAt;
            this.id = id;
            this.user = user;
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="createdAt">ステータス情報が作成された時刻</param>
        /// <param name="id">ID</param>
        /// <param name="user">ユーザー情報</param>
        public StatusInfomation(string createdAt, string id, UserInfomation user)
        {
            try
            {
                SetCreatedAt(createdAt);
            }
            catch (FormatException)
            {
                ;
            }
            this.id = id;
            this.user = user;
        }

        /// <summary>
        /// ステータス情報が作成された時刻をセットする
        /// </summary>
        /// <param name="date">ステータス情報が作成された時刻</param>
        public void SetCreatedAt(string date)
        {
            try
            {
                createdAt = DateTime.ParseExact(date, "ddd MMM d HH':'mm':'ss zzz yyyy",
                    System.Globalization.DateTimeFormatInfo.InvariantInfo,
                    System.Globalization.DateTimeStyles.None);
            }
            catch (FormatException ex)
            {
                throw ex;
            }
        }
    }
}
