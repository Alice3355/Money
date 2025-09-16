using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using SQLite4Unity3d;
using UnityEngine;

public class Player
{
    // 主キー、データが追加されるたびにIDが動的に1ずつ増えていく
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Name { get; set; }
    public int Score { get; set; }
}
