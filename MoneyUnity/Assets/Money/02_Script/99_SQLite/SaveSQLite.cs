using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SQLite4Unity3d;
using Unity.VisualScripting;
using UnityEngine;
namespace Money.SQLite
{
    /// <summary>
    /// SQLiteに保存する
    /// </summary>
    public class SaveSQLite
    {
        private static SQLiteConnection _database;
        public static SQLiteConnection Database
            { get { return _database; } }

        /// <summary>
        /// tableを探すか作る
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

        // whereで条件を設定できる
        /// <summary>
        /// tableを作る
        /// </summary>
        public static void CreateTable<T>() where T : new()
        {
            try
            {
                _database.CreateTable<T>();
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to create table: {e.Message}");
            }
        }

        /// <summary>
        /// 個々のデータを保存する
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        public static void DataSeve<T>(T data) where T : new()
        {
            try
            {
                _database.Insert(data);
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
        public static List<T> GetAllPlayers<T>() where T : class, IIdentifiable, new()
        {
            try
            {
                return _database.Table<T>().ToList();
                // return _database.Table<Player>().ToList();
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to get all players: {e.Message}");
                return new List<T>(); // エラーが発生した場合は空のリストを返す
            }
        }

        /// <summary>
        /// ID
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public static T GetByID<T>(int id) where T : class, IIdentifiable, new()
        {
            var table = _database.Table<T>();
            var all = table.ToList();

            var prop = typeof(T).GetProperty("Id");

            try
            {
                if(prop == null)
                {
                    return null; // エラーが発生した場合は空のリストを返す
                }


                foreach (var data in table)
                {
                    var value = prop.GetValue(data);
                    if(value is int ID && ID == id)
                    {
                        return data;
                    }
                }
                return null;
                // return _database.Table<Player>().ToList();
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to get all players: {e.Message}");
                return null; // エラーが発生した場合は空のリストを返す
            }
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        public static void UpdataData<T>(T data) where T : new()
        {
            try
            {
                _database.Update(data);
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to update player data: {e.Message}");
            }
        }

        /// <summary>
        /// データを消す
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static void Delete<T>() where T : new()
        {
            try
            {
                _database.DeleteAll<T>();
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to delete players: {e.Message}");
            }
        }

        /// <summary>
        /// tagsのすべてを含むもの
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tags"></param>
        /// <param name="databaseName"></param>
        /// <returns></returns>
        public static List<T> FiliterTags<T>(string[] tags, string databaseName) where T : class, IIdentifiable, new()
        {
            var table = _database.Table<T>();

            // LINQでフィルターを構築
            foreach (var tag in tags)
            {
                string t = tag; // クロージャ対策
                table = table.Where(entry => entry.Tags.Contains(t));
            }

            return table.ToList();
        }

    }
}
