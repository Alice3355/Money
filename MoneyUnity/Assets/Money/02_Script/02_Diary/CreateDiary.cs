using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Money.Diary
{
    /// <summary>
    /// 日記
    /// </summary>
    public class CreateDiary : MonoBehaviour
    {
        private GameManagement m_GameManagement;
        private void Start()
        {
            m_GameManagement = GameManagement.Instance;
            var Day = m_GameManagement.SelectDay;
            Debug.Log($"{Day.Month}月{Day.Day}日({m_GameManagement.GetDayOfTheWeek(Day.DayOfWeek)})");
        }
    }
}
