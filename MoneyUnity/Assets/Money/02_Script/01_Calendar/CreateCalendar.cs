using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
namespace Money.Calendar
{
    public class CreateCalendar : MonoBehaviour
    {
        [SerializeField]
        private GameObject m_Parent;
        [SerializeField]
        private GameObject m_Img;
        [SerializeField]
        private GameObject m_DayOfWeekObj;
        [SerializeField]
        private TextMeshProUGUI m_YearMonthText;

        [SerializeField]
        private Button[] m_ArrowButton;

        [SerializeField]
        private GameObject m_ToDayActionWindow;

        private GameManagement m_GameManagement;

        /// <summary>
        /// 間隔
        /// </summary>
        private float m_Width = 100f;
        private DateTime m_Time;

        /// <summary>
        /// 月のはじめ
        /// </summary>
        private DateTime m_StartDay;

        /// <summary>
        /// 曜日の数値化
        /// </summary>
        private int m_DayOfWeekNum;
        /// <summary>
        /// 1週目の今月ではない日
        /// </summary>
        private bool m_IsNoDay = false;
        /// <summary>
        /// 今月の最終日の日にち
        /// </summary>
        private int m_DayNum;
        /// <summary>
        /// マス
        /// </summary>
        private int m_Square = 7;
        /// <summary>
        /// 今月から前後させる
        /// </summary>
        private int m_AddMonthsNum = 0;


        private void Start()
        {
            m_GameManagement = GameManagement.Instance;

            SetCreateCalendar();
            m_ArrowButton[0].onClick.AddListener(() =>
            {
                m_AddMonthsNum--;
                SetCreateCalendar();
            });
            m_ArrowButton[1].onClick.AddListener(() =>
            {
                m_AddMonthsNum++;
                SetCreateCalendar();
            });
        }

        /// <summary>
        /// 生成したのを消す
        /// </summary>
        private void ParentReset()
        {
            for (int i = 0; i < m_Parent.transform.childCount; i++)
            {
                Destroy(m_Parent.transform.GetChild(i).gameObject);
            }
        }

        /// <summary>
        /// カレンダーを作る
        /// </summary>
        private void SetCreateCalendar()
        {
            ParentReset();
            m_IsNoDay = false;
            m_Time = DateTime.Now.AddMonths(m_AddMonthsNum);
            // 今月のはじめ
            m_YearMonthText.text = $"{m_Time.Year}年\n{m_Time.Month}月";
            m_StartDay = new DateTime(m_Time.Year, m_Time.Month, 1);
            m_DayNum = new DateTime(m_Time.Year, m_Time.Month, DateTime.DaysInMonth(m_Time.Year, m_Time.Month)).Day;
            m_DayOfWeekNum = (int)m_StartDay.DayOfWeek;
            CalendarGeneration();
        }

        /// <summary>
        /// カレンダー生成
        /// </summary>
        private void CalendarGeneration()
        {
            int cnt = 0;

            for (int i = 0; i < m_Square; i++)
            {
                Vector2 pos = new Vector2(i * m_Width, -(m_Width / 3));
                var obj = Instantiate(m_DayOfWeekObj, m_Parent.transform);
                obj.transform.localPosition = pos;
                obj.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = m_GameManagement.GetDayOfTheWeek((DayOfWeek)i);
            }

            for (int i = 1; i < m_Square; i++)
            {
                for (int j = 0; j < m_Square; j++)
                {
                    if (!m_IsNoDay)
                    {
                        if (j == m_DayOfWeekNum)
                        {
                            m_IsNoDay = true;
                        }
                        else
                        {
                            CreateObj(i, j, 0);
                            continue;
                        }
                    }
                    if (cnt >= m_DayNum)
                    {
                        CreateObj(i, j, 0);
                        continue;
                    }

                    cnt++;
                    CreateObj(i, j, cnt);
                }
                if (cnt >= m_DayNum)
                    return;
            }
        }

        /// <summary>
        /// オブジェクト生成
        /// </summary>
        /// <param name="i">Y軸</param>
        /// <param name="j">X軸</param>
        /// <param name="cnt">日付</param>
        private void CreateObj(int i, int j, int cnt)
        {
            Vector2 pos = new Vector2(j * m_Width, -(i * m_Width));
            var obj = Instantiate(m_Img, m_Parent.transform);
            obj.transform.localPosition = pos;
            string Data = cnt.ToString();
            if (cnt == 0)
            {
                obj.GetComponent<Button>().interactable = false;
                Data = "";
            }
            obj.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = Data;
            obj.GetComponent<Button>().onClick.AddListener(() => 
            {
                var obj = Instantiate(m_ToDayActionWindow, this.transform);
                obj.GetComponent<ToDayActionWindow>().DateData = new DateTime(m_Time.Year, m_Time.Month, cnt);
                Debug.Log($"{m_Time.Month}月{Data}日");
            });
        }
    }
}
