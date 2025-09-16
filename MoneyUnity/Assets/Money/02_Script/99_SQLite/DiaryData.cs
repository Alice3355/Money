using System.Collections;
using System.Collections.Generic;
using SQLite4Unity3d;
using UnityEngine;
using System;
namespace Money.SQLite
{
    /// <summary>
    /// 日記データ
    /// </summary>
    public class DiaryData : IIdentifiable
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Day;
        public string Title { get; set; }
        public string MainText { get; set; }
        public string Tags { get; set; }
        public string ImagePath { get; set; }
    }

    public interface IIdentifiable
    {
        public int Id { get; set; }
        public string Tags { get; set; }
    }
}
