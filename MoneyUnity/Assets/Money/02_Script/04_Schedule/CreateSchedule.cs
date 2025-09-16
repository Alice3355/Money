using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Money.Schedule
{
    /// <summary>
    /// スケジュール
    /// </summary>
    public class CreateSchedule : MonoBehaviour
    {
        private GameManagement m_GameManagement;
        private void Start()
        {
            var Day = m_GameManagement.SelectDay;
            Debug.Log($"{Day.Month}月{Day.Day}日({m_GameManagement.GetDayOfTheWeek(Day.DayOfWeek)})");
        }
    }
}