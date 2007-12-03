#region ディレクティブを使用する

using System;

#endregion

namespace TwitterAway.Twitter
{
    /// <summary>
    /// Twitterのユーザー情報
    /// </summary>
    public class UserInfomation
    {
        private string id;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string screenName;

        public string ScreenName
        {
            get { return screenName; }
            set { screenName = value; }
        }

        private string location;

        public string Location
        {
            get { return location; }
            set { location = value; }
        }

        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private Uri profileImageUrl;

        public Uri ProfileImageUrl
        {
            get { return profileImageUrl; }
            set { profileImageUrl = value; }
        }

        private Uri url;

        public Uri Url
        {
            get { return url; }
            set { url = value; }
        }

        private bool protectedMyUpdate;

        public bool ProtectedMyUpdate
        {
            get { return protectedMyUpdate; }
            set { protectedMyUpdate = value; }
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public UserInfomation()
        {
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="screenName"></param>
        /// <param name="location"></param>
        /// <param name="description"></param>
        /// <param name="profileImageUrl"></param>
        /// <param name="url"></param>
        /// <param name="protectedMyUpdate"></param>
        public UserInfomation(string id, string name, string screenName, string location, string description, Uri profileImageUrl, Uri url, bool protectedMyUpdate)
        {
            this.id = id;
            this.name = name;
            this.screenName = screenName;
            this.location = location;
            this.description = description;
            this.profileImageUrl = profileImageUrl;
            this.url = url;
            this.protectedMyUpdate = protectedMyUpdate;
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="screenName"></param>
        /// <param name="location"></param>
        /// <param name="description"></param>
        /// <param name="profileImageUrl"></param>
        /// <param name="url"></param>
        /// <param name="protectedMyUpdate"></param>
        public UserInfomation(string id, string name, string screenName, string location, string description, string profileImageUrl, string url, bool protectedMyUpdate)
        {
            this.id = id;
            this.name = name;
            this.screenName = screenName;
            this.location = location;
            this.description = description;
            try
            {
                this.profileImageUrl = new Uri(profileImageUrl);
            }
            catch (UriFormatException)
            {
                ;
            } 
            try
            {
                this.url = new Uri(url);
            }
            catch (UriFormatException)
            {
                ;
            }
            this.protectedMyUpdate = protectedMyUpdate;
        }
    }
}
