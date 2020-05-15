using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GetController : ControllerBase
    {
        /// <summary>
        /// GET: get/data
        /// データ取得API
        /// </summary>
        /// <returns>メモデータリスト</returns>
        [HttpGet("data")]
        public List<Memo> GetMemo()
        {
            return MemoDataService.GetMemoData();
        }
    }
}