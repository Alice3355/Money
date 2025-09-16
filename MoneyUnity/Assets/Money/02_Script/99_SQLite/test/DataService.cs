using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SQLite4Unity3d;
using UnityEngine;

public class DataService
{
    private static SQLiteConnection _database;

    /// <summary>
    /// 新しいインスタンスを作成
    /// </summary>
    /// <param name="databaseName"></param>
    public static void InitDatabase(string databaseName)
    {
        try
        {
            string DBPath = $"Assets/StreamingAssets/{databaseName}";
            _database = new SQLiteConnection(DBPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed to initialize database: {e.Message}");
        }
    }

    /// <summary>
    /// tableを作る
    /// </summary>
    public static void CreateTable()
    {
        try
        {
            _database.CreateTable<Player>();
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed to create table: {e.Message}");
        }
    }

    /// <summary>
    /// 個々のデータを保存する
    /// </summary>
    /// <param name="player"></param>
    public static void InsertPlayer(Player player)
    {
        try
        {
            _database.Insert(player);
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed to insert player: {e.Message}");
        }
    }

    /// <summary>
    /// tableからデータを持ってくる
    /// </summary>
    /// <returns></returns>
    public static List<Player> GetAllPlayers()
    {
        try
        {
            return _database.Table<Player>().OrderByDescending(x => x.Score).ToList();
            // return _database.Table<Player>().ToList();
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed to get all players: {e.Message}");
            return new List<Player>(); // エラーが発生した場合は空のリストを返す
        }
    }


    /// <summary>
    /// データを消す
    /// </summary>
    public static void DeletePlayers()
    {
        try
        {
            _database.DeleteAll<Player>();
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed to delete players: {e.Message}");
        }
    }

    /// <summary>
    /// 名前取得
    /// </summary>
    /// <param name="playerName"></param>
    /// <returns></returns>
    public static Player GetPlayerByName(string playerName)
    {
        try
        {
            return _database.Table<Player>().FirstOrDefault(p => p.Name == playerName);
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed to get player by name: {e.Message}");
            return null; // エラーが発生した場合はnullを返す
        }
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="player"></param>
    public static void UpdatePlayerData(Player player)
    {
        try
        {
            _database.Update(player);
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed to update player data: {e.Message}");
        }
    }
}
