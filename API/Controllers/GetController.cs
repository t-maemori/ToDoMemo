using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;
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
        /// <returns></returns>
        [HttpGet("data")]
        public List<Memo> GetMemo()
        {
            // 処理は後ほど

            return null;
        }
    }
}