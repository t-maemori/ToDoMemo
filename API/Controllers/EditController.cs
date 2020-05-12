using Microsoft.AspNetCore.Mvc;
using API.Models;
using System.Collections.Generic;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EditController : ControllerBase
    {
        private static string editUser = null;
        private static int count = 1;
        private static IDictionary<int, string> memoMap = new Dictionary<int, string>();

        /// <summary>
        /// POST: edit/start/{userId}
        /// 編集開始API
        /// </summary>
        /// <param name="userId">ユーザID</param>
        /// <returns>完了フラグ</returns>
        [HttpPost("start/{userId}")]
        public bool PostStartEdit(string userId)
        {
            // 編集中ユーザがいないか
            if (editUser != null)
            {
                return false;
            }

            // 編集中ユーザ更新
            editUser = userId;
            return true;
        }

        /// <summary>
        /// PUT: edit/add/{userId}/{memoId}
        /// データ追加API
        /// </summary>
        /// <param name="userId">ユーザID</param>
        /// <param name="memoId">メモID</param>
        /// <param name="memoData"></param>
        /// <returns>完了フラグ</returns>
        [HttpPut("add/{userId}/{memoId}")]
        public bool PutAddMemo(string userId, int memoId, string memoData)
        {
            // 編集中ユーザであるか
            if (!userId.Equals(editUser))
            {
                return false;
            }

            if(memoId <= 0)
            {
                // 新規作成
                memoMap.Add(count++, memoData);
            }
            else
            {
                // データ更新
                memoMap.Add(memoId, memoData);
            }

            return true;
        }

        /// <summary>
        /// PUT: edit/remove/{userId}/{memoId}
        /// データ削除API
        /// </summary>
        /// <param name="userId">ユーザID</param>
        /// <param name="memoId">メモID</param>
        /// <returns>完了フラグ</returns>
        [HttpDelete("remove/{userId}/{memoId}")]
        public bool DeleteRemoveMemo(string userId, int memoId)
        {
            // 編集中ユーザであるか
            if (!userId.Equals(editUser))
            {
                return false;
            }

            // 指定されたメモIDがデータにあるか
            if (memoMap.ContainsKey(memoId))
            {
                memoMap.Remove(memoId);
                return true;
            }

            return false;
        }

        /// <summary>
        /// DELETE: edit/end/{userId}
        /// 編集終了API
        /// </summary>
        /// <param name="userId">ユーザID</param>
        /// <returns>完了フラグ</returns>
        [HttpDelete("end/{userId}")]
        public bool DeleteEndEdit(string userId)
        {
            // 編集中ユーザであるか
            if (!userId.Equals(editUser))
            {
                return false;
            }

            // 編集中ユーザをいないものに再設定
            editUser = null;
            return true;
        }
    }
}
