using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
namespace Money.Calendar
{
    /// <summary>
    /// この日に何かする
    /// </summary>
    public class ToDayActionWindow : MonoBehaviour
    {
        [SerializeField]
        private Button m_DiaryButton;
        [SerializeField]
        private Button m_MoneyButton;
        [SerializeField]
        private Button m_AddScheduleButton;
        [SerializeField]
        private Button m_CloseButton;

        /// <summary>
        /// 日付
        /// </summary>
        private DateTime m_DateData;
        public DateTime DateData
        {
            get { return m_DateData; }
            set { m_DateData = value; }
        }

        private void Start()
        {
            m_DiaryButton.onClick.AddListener(() => Debug.Log("日記"));
            m_MoneyButton.onClick.AddListener(() => Debug.Log("お金"));
            m_AddScheduleButton.onClick.AddListener(() => Debug.Log("スケジュール"));

            m_CloseButton.onClick.AddListener(() => Destroy(this.gameObject) );
        }

    }
}
