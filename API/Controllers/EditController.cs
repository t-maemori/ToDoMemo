using Microsoft.AspNetCore.Mvc;
using API.Models;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EditController : ControllerBase
    {
        /// <summary>
        /// POST: edit/start/{userId}
        /// 編集開始API
        /// </summary>
        /// <param name="userId">ユーザID</param>
        /// <returns>完了フラグ</returns>
        [HttpPost("start/{userId}")]
        public bool PostStartEdit(string userId)
        {
            // 処理は後ほど
            System.Diagnostics.Debug.WriteLine("111 : " + userId);

            return true;
        }

        /// <summary>
        /// PUT: edit/add/{userId}
        /// データ追加API
        /// </summary>
        /// <param name="userId">ユーザID</param>
        /// <param name="memoData"></param>
        /// <returns>完了フラグ</returns>
        [HttpPut("add/{userId}")]
        public bool PutAddMemo(string userId, Memo memoData)
        {
            // 処理は後ほど
            System.Diagnostics.Debug.WriteLine("222 : " + userId + ", memoData: " + memoData.id + ", " + memoData.data);

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
        public bool DeleteRemoveMemo(string userId, string memoId)
        {
            // 処理は後ほど
            System.Diagnostics.Debug.WriteLine("333 : " + userId + " : " + memoId);

            return true;
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
            // 処理は後ほど
            System.Diagnostics.Debug.WriteLine("444 : " + userId);

            return true;
        }
    }
}
