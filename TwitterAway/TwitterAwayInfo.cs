#region �f�B���N�e�B�u���g�p����

using System;

#endregion

namespace TwitterAway
{
    /// <summary>
    /// TwitterAway�̌ŗL�����L�q���Ă���N���X
    /// </summary>
    public sealed class TwitterAwayInfo
    {
        #region �A�v���P�[�V�����ŗL�̏��

        /// <summary>
        /// �A�v���P�[�V������
        /// </summary>
        private const string APPLICATION_NAME = "TwitterAway";

        /// <summary>
        /// �A�v���P�[�V������
        /// </summary>
        public static string ApplicationName
        {
            get { return APPLICATION_NAME; }
        }

        /// <summary>
        /// �A�v���P�[�V�����̃o�[�W����
        /// </summary>
        private const string VERSION_NUMBER = "0.5";

        /// <summary>
        /// �A�v���P�[�V�����̃o�[�W����
        /// </summary>
        public static string VersionNumber
        {
            get { return VERSION_NUMBER; }
        }

        /// <summary>
        /// ���쌠���
        /// </summary>
        private const string COPYRIGHT = "Copyright (C) 2007 Uraroji";

        /// <summary>
        /// ���쌠���
        /// </summary>
        public static string Copyright
        {
            get { return COPYRIGHT; }
        }

        #endregion

        #region �A�v���P�[�V�����̐ݒ�

        /// <summary>
        /// �A�b�v�f�[�g�^�C�}�[�̏��
        /// </summary>
        private const int UPDATE_TIMER_MAXIMUM_MILL_SEC = 600000;

        /// <summary>
        /// �A�b�v�f�[�g�^�C�}�[�̏��
        /// </summary>
        public static int UpdateTimerMaximumMillSec
        {
            get { return UPDATE_TIMER_MAXIMUM_MILL_SEC; }
        }

        /// <summary>
        /// �A�b�v�f�[�g�^�C�}�[�̉��� 
        /// </summary>
        private const int UPDATE_TIMER_MINIMUM_MILL_SEC = 15000;

        /// <summary>
        /// �A�b�v�f�[�g�^�C�}�[�̉��� 
        /// </summary>
        public static int UpdateTimerMinimumMillSec
        {
            get { return UPDATE_TIMER_MINIMUM_MILL_SEC; }
        }

        /// <summary>
        /// Web�ڑ����̃^�C���A�E�g����
        /// </summary>
        private const int WEB_REQUEST_TIMEOUT_MILL_SEC = 20000;

        /// <summary>
        /// Web�ڑ����̃^�C���A�E�g����
        /// </summary>
        public static int WebRequestTimeoutMillSec
        {
            get { return WEB_REQUEST_TIMEOUT_MILL_SEC; }
        }

        /// <summary>
        /// �l�b�g�A�N�Z�X����UserAgent�ݒ�
        /// </summary>
        private const string USER_AGENT = APPLICATION_NAME + "/" + VERSION_NUMBER;

        /// <summary>
        /// �l�b�g�A�N�Z�X����UserAgent�ݒ�
        /// </summary>
        public static string UserAgent
        {
            get { return USER_AGENT; }
        }

        /// <summary>
        /// Public Timeline��Twitter API URL
        /// </summary>
        private const string TWITTER_PUBLIC_TIMELINE_XML = "http://twitter.com/statuses/public_timeline.xml";

        /// <summary>
        /// Public Timeline��Twitter API URL
        /// </summary>
        public static string TwitterPublicTimelineXml
        {
            get { return TWITTER_PUBLIC_TIMELINE_XML; }
        }

        /// <summary>
        /// Friends Timeline��Twitter API URL
        /// </summary>
        private const string TWITTER_FRIENDS_TIMELINE_XML = "http://twitter.com/statuses/friends_timeline.xml";

        /// <summary>
        /// Friends Timeline��Twitter API URL
        /// </summary>
        public static string TwitterFriendsTimelineXml
        {
            get { return TWITTER_FRIENDS_TIMELINE_XML; }
        }

        /// <summary>
        /// Update��Twitter API URL
        /// </summary>
        private const string TWITTER_UPDATE_XML = "http://twitter.com/statuses/update.xml";

        /// <summary>
        /// Update��Twitter API URL
        /// </summary>
        public static string TwitterUpdateXml
        {
            get { return TWITTER_UPDATE_XML; }
        }

        /// <summary>
        /// ���C���t�H�[���̕��B
        /// �t�H�[���f�U�C���͂��̕����x�[�X��Control��u���Ă���B
        /// </summary>
        private const int FORM_BASE_WIDRH = 240;

        /// <summary>
        /// ���C���t�H�[���̕��B
        /// �t�H�[���f�U�C���͂��̕����x�[�X��Control��u���Ă���B
        /// </summary>
        public static int FormBaseWidth
        {
            get { return FORM_BASE_WIDRH; }
        }

        /// <summary>
        /// ���C���t�H�[���̍����B
        /// �t�H�[���f�U�C���͂��̍������x�[�X��Control��u���Ă���B
        /// </summary>
        private const int FORM_BASE_HIGHT = 268;

        /// <summary>
        /// ���C���t�H�[���̍����B
        /// �t�H�[���f�U�C���͂��̍������x�[�X��Control��u���Ă���B
        /// </summary>
        public static int FormBaseHight
        {
            get { return FORM_BASE_HIGHT; }
        }

        /// <summary>
        /// �A�v���P�[�V�����̐ݒ�t�@�C��
        /// </summary>
        private const string SETTING_FILE = "Setting.xml";

        /// <summary>
        /// �A�v���P�[�V�����̐ݒ�t�@�C��
        /// </summary>
        public static string SettingFile
        {
            get { return SETTING_FILE; }
        }

        /// <summary>
        /// ��O�ɏo�͂��郍�O�t�@�C��
        /// </summary>
        private const string EXCEPTION_LOG_FILE = "TwitterAwayExceptionLog.log";

        /// <summary>
        /// ��O�ɏo�͂��郍�O�t�@�C��
        /// </summary>
        public static string ExceptionLogFile
        {
            get { return EXCEPTION_LOG_FILE; }
        }

        #endregion

        /// <summary>
        /// �V���O���g���̂��߃v���C�x�[�g
        /// </summary>
        private TwitterAwayInfo()
        {
        }
    }
}
