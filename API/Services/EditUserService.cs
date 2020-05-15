using API.Dao;

namespace API.Services
{
    public class EditUserService
    {
        /// <summary>
        /// 編集中ユーザを設定する
        /// </summary>
        /// <param name="userId">操作ユーザID</param>
        /// <returns>-1：異なるユーザ, 0：失敗, 1：同じユーザ</returns>
        public static short StartEditUser(string userId)
        {
            // 編集中ユーザがいる
            if (CheckStartEditUser())
            {
                // 異なるユーザである
                if (CheckEditUser(userId) != 1)
                {
                    return -1;
                }
                return 1;
            }

            // 編集中ユーザ設定
            return (short)(RedisDao.SetEditUser(userId) ? 1 : 0);
        }

        /// <summary>
        /// 編集中ユーザをいないものとする
        /// </summary>
        /// <param name="userId">操作ユーザID</param>
        /// <returns>-1：異なるユーザ, 0：失敗, 1：同じユーザ</returns>
        public static short EndEditUser(string userId)
        {
            // 編集中ユーザではない
            if (CheckEditUser(userId) != 1)
            {
                return -1;
            }

            // 編集中ユーザ削除
            return (short)(RedisDao.RemoveEditUser() ? 1 : 0);
        }

        /// <summary>
        /// 編集中ユーザがいるかを確認する
        /// </summary>
        /// <returns>True：いる, False:いない</returns>
        public static bool CheckStartEditUser()
        {
            // 編集中ユーザ取得
            string editUserId = RedisDao.GetEditUser();

            if (editUserId != null)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 編集中ユーザかを確認する
        /// </summary>
        /// <param name="userId">確認ユーザID</param>
        /// <returns>-1：異なるユーザ, 0：失敗, 1：同じユーザ</returns>
        public static short CheckEditUser(string userId)
        {
            // 編集中ユーザ取得
            string editUserId = RedisDao.GetEditUser();

            // 編集中ユーザと確認ユーザが同じ
            if (userId.Equals(editUserId))
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
    }
}
