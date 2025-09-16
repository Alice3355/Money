using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEditor;
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
        [SerializeField]
        private string[] m_NextSceneName;

        private GameManagement m_GameManagement;

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
            m_GameManagement = GameManagement.Instance;

            m_DiaryButton.onClick.AddListener(() => 
            {
                KeepSelectData();
                m_GameManagement.ChangeScene(m_NextSceneName[0]);
            });
            m_MoneyButton.onClick.AddListener(() =>
            {
                KeepSelectData();
                m_GameManagement.ChangeScene(m_NextSceneName[1]);
            });
            m_AddScheduleButton.onClick.AddListener(() =>
            {
                KeepSelectData();
                m_GameManagement.ChangeScene(m_NextSceneName[2]);
            });

            m_CloseButton.onClick.AddListener(() => Destroy(this.gameObject) );
        }

        /// <summary>
        /// 選択したデータを保存
        /// </summary>
        private void KeepSelectData()
        {
            m_GameManagement.SelectDay = m_DateData;
        }

    }
}
