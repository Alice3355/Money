using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Money.Money
{
    /// <summary>
    /// お金
    /// </summary>
    public class CreateMoney : MonoBehaviour
    {
        private GameManagement m_GameManagement;
        private void Start()
        {
            var Day = m_GameManagement.SelectDay;
            Debug.Log($"{Day.Month}月{Day.Day}日({m_GameManagement.GetDayOfTheWeek(Day.DayOfWeek)})");
        }
    }
}
