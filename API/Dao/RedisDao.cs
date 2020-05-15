using System;

namespace API.Dao
{
    public class RedisDao
    {
        private const string HOST_NAME = "redis-container";
        private const int PORT_NUM = 9998;

        private static string editUserId = null;

        /// <summary>
        /// 編集中ユーザを取得する
        /// </summary>
        /// <returns>編集中ユーザ</returns>
        public static string GetEditUser()
        {
            try
            {
                return editUserId;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("エラー：" + e.Message);
                return null;
            }
        }

        /// <summary>
        /// 編集中ユーザを設定する
        /// </summary>
        /// <param name="userId">設定する編集中ユーザ</param>
        /// <returns>True：成功, False：失敗</returns>
        public static bool SetEditUser(string userId)
        {
            try
            {
                editUserId = userId;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("エラー：" + e.Message);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 編集中ユーザデータを削除する
        /// </summary>
        /// <returns>True：成功, False：失敗</returns>
        public static bool RemoveEditUser()
        {
            try
            {
                editUserId = null;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("エラー：" + e.Message);
                return false;
            }
            return true;
        }
    }
}
