using API.Dao;

namespace API.Services
{
    public class EditUserService
    {
        /// <summary>
        /// 編集中ユーザ初期化
        /// </summary>
        /// <param name="userId">操作ユーザID</param>
        /// <returns>-1：異なるユーザ, 0：失敗（エラーなど）, 1：同じユーザ</returns>
        public static short ResetEditUser(string userId)
        {
            // 編集中ユーザではない
            if (CheckEditUser(userId) != 1)
            {
                return -1;
            }

            // 編集中ユーザ削除
            RedisDao.RemoveEditUser();
            return 1;
        }

        /// <summary>
        /// 編集中ユーザ確認
        /// </summary>
        /// <param name="userId">確認ユーザID</param>
        /// <returns>-1：異なるユーザ, 0：失敗（エラーなど）, 1：同じユーザ</returns>
        public static short CheckEditUser(string userId)
        {
            // 編集中ユーザ取得
            string editUserId = RedisDao.GetEditUser();

            // 編集中ユーザと操作ユーザが異なる
            if (editUserId == null || !userId.Equals(editUserId))
            {
                return -1;
            }
            return 1;
        }

        /// <summary>
        /// 編集中ユーザ設定
        /// </summary>
        /// <param name="userId">操作ユーザID</param>
        /// <returns>-1：異なるユーザ, 0：失敗（エラーなど）, 1：同じユーザ</returns>
        public static short SetEditUser(string userId)
        {
            // 編集中ユーザではない
            if (CheckEditUser(userId) != 1)
            {
                return -1;
            }

            // 編集中ユーザ設定
            RedisDao.SetEditUser(userId);
            return 1;
        }
    }
}
