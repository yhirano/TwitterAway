﻿#region ディレクティブを使用する

using System;
using System.IO;
using System.Xml;
using MiscPocketCompactLibrary.Reflection;

#endregion

namespace TwitterAway
{
    /// <summary>
    /// PocketLadio固有の処理を記述しているクラス
    /// </summary>
    public sealed class TwitterAwaySpecificProcess
    {
        /// <summary>
        /// シングルトンのためプライベート
        /// </summary>
        private TwitterAwaySpecificProcess()
        {
        }

        /// <summary>
        /// TwitterAway起動時のチェック処理。
        /// </summary>
        public static void StartUpCheck()
        {
            // MiscPocketCompactLibrary.dllが見つからない場合は例外を投げる
            if (File.Exists(AssemblyUtility.GetExecutablePath() + @"\MiscPocketCompactLibrary.dll") == false)
            {
                throw new DllNotFoundException("Not found MiscPocketCompactLibrary.dll.");
            }
        }

        /// <summary>
        /// TwitterAway起動時の初期化処理。
        /// </summary>
        public static void StartUpInitialize()
        {
            try
            {
                // 設定を読み込む
                UserSetting.LoadSetting();
            }
            catch (XmlException)
            {
                throw;
            }
            catch (IOException)
            {
                throw;
            }
            catch (ArgumentNullException)
            {
                throw;
            }
        }

        /// <summary>
        /// TwitterAway終了時の処理。
        /// </summary>
        public static void ExitDisable()
        {
            try
            {
                // 設定ファイルの書き込み
                UserSetting.SaveSetting();
            }
            catch (IOException)
            {
                throw;
            }
        }
    }
}
