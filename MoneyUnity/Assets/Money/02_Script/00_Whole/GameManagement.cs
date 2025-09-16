using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
namespace Money
{
    /// <summary>
    /// 全体を管理する
    /// </summary>
    public class GameManagement : MonoBehaviour
    {
        private static GameManagement m_Instance;
        public static GameManagement Instance
        {
            get { return m_Instance; }
        }


        /*******************************************
         * 
         * 共有データ
         * 
         *******************************************/

        /// <summary>
        /// 選択した日付
        /// </summary>
        public DateTime SelectDay;

        /********************************************/

        /// <summary>
        /// シングルトンで消えないように
        /// </summary>
        private void Awake()
        {
            if(m_Instance != null)
            {
                Destroy(this.gameObject);
            }
            else
            {
                m_Instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }

        /// <summary>
        /// シーン移行
        /// </summary>
        /// <param name="sceneName"></param>
        public void ChangeScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        /// <summary>
        /// 曜日を日本語で返す
        /// </summary>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public string GetDayOfTheWeek(DayOfWeek dayOfWeek)
        {
            // 日本語の曜日を取得
            string dayOfWeekJa = "";

            switch (dayOfWeek)
            {
                case DayOfWeek.Sunday:
                    dayOfWeekJa = "日";
                    break;
                case DayOfWeek.Monday:
                    dayOfWeekJa = "月";
                    break;
                case DayOfWeek.Tuesday:
                    dayOfWeekJa = "火";
                    break;
                case DayOfWeek.Wednesday:
                    dayOfWeekJa = "水";
                    break;
                case DayOfWeek.Thursday:
                    dayOfWeekJa = "木";
                    break;
                case DayOfWeek.Friday:
                    dayOfWeekJa = "金";
                    break;
                case DayOfWeek.Saturday:
                    dayOfWeekJa = "土";
                    break;
            }
            return dayOfWeekJa;
        }
    }
}

