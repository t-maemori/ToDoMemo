using System.Collections.Generic;
using API.Models;

namespace API.Services
{
    public class MemoDataService
    {
        /// <summary>
        /// メモデータを追加する
        /// </summary>
        /// <param name="memoData">メモ文字列</param>
        /// <returns>True：成功, 0：失敗</returns>
        public static bool AddMemoData(string memoData)
        {
            // 処理は後ほど
            return true;
        }

        /// <summary>
        /// メモデータを更新する
        /// </summary>
        /// <param name="memoId">メモID</param>
        /// <param name="memoData">メモ文字列</param>
        /// <returns>True：成功, 0：失敗</returns>
        public static bool UpdateMemoData(int memoId, string memoData)
        {
            // 処理は後ほど
            return true;
        }

        /// <summary>
        /// メモデータを削除する
        /// </summary>
        /// <param name="memoId">メモID</param>
        /// <returns>True：成功, 0：失敗</returns>
        public static bool RemoveMemoData(int memoId)
        {
            // 処理は後ほど
            return true;
        }

        /// <summary>
        /// 指定されたメモIDが存在するか確認する
        /// </summary>
        /// <param name="memoId"></param>
        /// <returns>True：あり, False:なし</returns>
        public static bool CheckContainMemoId(int memoId)
        {
            // 処理は後ほど
            return true;
        }

        /// <summary>
        /// メモデータをリストとして取得する
        /// </summary>
        /// <returns>メモデータリスト</returns>
        public static List<Memo> GetMemoData()
        {
            // 処理は後ほど
            return null;
        }
    }
}
