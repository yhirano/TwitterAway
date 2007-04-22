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
        private DateTime createdAt;

        public DateTime CreatedAt
        {
            get { return createdAt; }
            set { createdAt = value; }
        }

        private string id;

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

        private UserInfomation user;

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
        /// <param name="createdAt"></param>
        /// <param name="id"></param>
        /// <param name="user"></param>
        public StatusInfomation(DateTime createdAt, string id, UserInfomation user)
        {
            this.createdAt = createdAt;
            this.id = id;
            this.user = user;
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="createdAt"></param>
        /// <param name="id"></param>
        /// <param name="user"></param>
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
