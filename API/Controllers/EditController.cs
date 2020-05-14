using Microsoft.AspNetCore.Mvc;
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
        /// <returns>完了フラグ（-1:異なるユーザが編集中、0:失敗（エラーなど）、1:成功）</returns>
        [HttpPost("start/{userId}")]
        public short PostStartEdit(string userId)
        {
            // 編集中ユーザではない
            if (editUser != null)
            {
                return -1;
            }

            // 編集中ユーザ更新
            editUser = userId;
            return 1;
        }

        /// <summary>
        /// PUT: edit/add/{userId}/{memoId}
        /// データ追加API
        /// </summary>
        /// <param name="userId">ユーザID</param>
        /// <param name="memoId">メモID</param>
        /// <param name="memoData"></param>
        /// <returns>完了フラグ（-1:異なるユーザが編集中、0:失敗（エラーなど）、1:成功）</returns>
        [HttpPut("add/{userId}/{memoId}")]
        public short PutAddMemo(string userId, int memoId, string memoData)
        {
            // 編集中ユーザではない
            if (!userId.Equals(editUser))
            {
                return -1;
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

            return 1;
        }

        /// <summary>
        /// DELETE: edit/remove/{userId}/{memoId}
        /// データ削除API
        /// </summary>
        /// <param name="userId">ユーザID</param>
        /// <param name="memoId">メモID</param>
        /// <returns>完了フラグ（-1:異なるユーザが編集中、0:失敗（エラーなど）、1:成功）</returns>
        [HttpDelete("remove/{userId}/{memoId}")]
        public short DeleteRemoveMemo(string userId, int memoId)
        {
            // 編集中ユーザではない
            if (!userId.Equals(editUser))
            {
                return -1;
            }

            // 指定されたメモIDがデータにある
            if (memoMap.ContainsKey(memoId))
            {
                memoMap.Remove(memoId);
                return 1;
            }

            return 0;
        }

        /// <summary>
        /// DELETE: edit/end/{userId}
        /// 編集終了API
        /// </summary>
        /// <param name="userId">ユーザID</param>
        /// <returns>完了フラグ（-1:異なるユーザが編集中、0:失敗（エラーなど）、1:成功）</returns>
        [HttpDelete("end/{userId}")]
        public short DeleteEndEdit(string userId)
        {
            // 編集中ユーザではない
            if (!userId.Equals(editUser))
            {
                return -1;
            }

            // 編集中ユーザをいないものに再設定
            editUser = null;
            return 1;
        }
    }
}
