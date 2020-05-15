using API.Dao;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        /// <returns>-1：異なるユーザが編集中, 0：失敗, 1：成功</returns>
        [HttpPost("start/{userId}")]
        public short PostStartEdit(string userId)
        {
            return EditUserService.StartEditUser(userId);
        }

        /// <summary>
        /// PUT: edit/add/{userId}/{memoId}
        /// データ追加API
        /// </summary>
        /// <param name="userId">ユーザID</param>
        /// <param name="memoId">メモID</param>
        /// <param name="memoData">メモ文字列</param>
        /// <returns>-1：異なるユーザが編集中, 0：失敗, 1：成功</returns>
        [HttpPut("add/{userId}/{memoId}")]
        public short PutAddMemo(string userId, int memoId, string memoData)
        {
            // 編集中ユーザではない
            if (EditUserService.CheckEditUser(userId) != 1)
            {
                return -1;
            }
            
            if (memoId > 0 && MemoDataService.CheckContainMemoId(memoId))
            {
                // データ更新
                return (short) (MemoDataService.UpdateMemoData(memoId, memoData) ? 1 : 0);
            }
            else
            {
                // 新規作成
                return (short)(MemoDataService.AddMemoData(memoData) ? 1 : 0);
            }
        }

        /// <summary>
        /// DELETE: edit/remove/{userId}/{memoId}
        /// データ削除API
        /// </summary>
        /// <param name="userId">ユーザID</param>
        /// <param name="memoId">メモID</param>
        /// <returns>-1：異なるユーザが編集中, 0：失敗, 1：成功</returns>
        [HttpDelete("remove/{userId}/{memoId}")]
        public short DeleteRemoveMemo(string userId, int memoId)
        {
            // 編集中ユーザではない
            if (EditUserService.CheckEditUser(userId) != 1)
            {
                return -1;
            }
            
            if (memoId > 0 && MemoDataService.CheckContainMemoId(memoId))
            {
                return (short)(MemoDataService.RemoveMemoData(memoId) ? 1 : 0); ;
            }

            return 0;
        }

        /// <summary>
        /// DELETE: edit/end/{userId}
        /// 編集終了API
        /// </summary>
        /// <param name="userId">ユーザID</param>
        /// <returns>-1：異なるユーザが編集中, 0：失敗, 1：成功</returns>
        [HttpDelete("end/{userId}")]
        public short DeleteEndEdit(string userId)
        {
            return EditUserService.EndEditUser(userId);
        }
    }
}
