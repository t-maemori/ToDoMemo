using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API.Models;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EditController : ControllerBase
    {
        /// <summary>
        /// POST: edit/start
        /// 編集開始API
        /// </summary>
        /// <param name="userId">ユーザID</param>
        /// <returns></returns>
        [HttpPost("start")]
        public async Task<IActionResult> PostStartEdit(string userId)
        {
            // 処理は後ほど

            return NoContent();
        }

        /// <summary>
        /// PUT: edit/update
        /// データ更新API
        /// </summary>
        /// <param name="memoData"></param>
        /// <returns></returns>
        [HttpPut("update")]
        public async Task<IActionResult> PutUpdateMemo(string userId, Memo memoData)
        {
            // 処理は後ほど

            return NoContent();
        }

        /// <summary>
        /// DELETE: edit/end
        /// 編集終了API
        /// </summary>
        /// <returns></returns>
        [HttpDelete("end")]
        public async Task<IActionResult> DeleteEndEdit()
        {
            // 処理は後ほど

            return NoContent();
        }

        // ※ここでデータを持つ間のみ、以下のAPIをGETとする。
        /// <summary>
        /// GET: edit/data
        /// データ取得API
        /// </summary>
        /// <returns></returns>
        [HttpGet("data")]
        public async Task<IActionResult> GetMemo()
        {
            // 処理は後ほど

            return NoContent();
        }
    }
}
