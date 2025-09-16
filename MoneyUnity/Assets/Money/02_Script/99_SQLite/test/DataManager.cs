using System.Collections;
using System.Collections.Generic;
using Money.SQLite;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField[] TMP_InputField;
    [SerializeField]
    private Button Button;

    List<Player> dummyPlayers = new List<Player>()
    {
        new Player {Name = "Player01", Score = 110},
        new Player {Name = "Player02", Score = 50},
        new Player {Name = "Player03", Score = 46},
        new Player {Name = "Player04", Score = 19},
    };

    private void Awake()
    {
        SaveSQLite.InitDatabase("Sample");
        //SaveSQLite.CreateTable<DiaryData>();
    }

    private void Start()
    {
        //Diary();
        //InsertDummyData(new Player { Name = "Player02", Score = 200 });
        //ShowPlayers();
        Button.onClick.AddListener(() => OnButton());
    }

    public void InsertDummyData(Player player)
    {
        Player existingPlayer = DataService.GetPlayerByName(player.Name);
        if (existingPlayer != null)
        {
            if (player.Score > existingPlayer.Score)
            {
                existingPlayer.Score = player.Score;
                DataService.UpdatePlayerData(existingPlayer);
            }
        }
        else
        {
            DataService.InsertPlayer(player);
        }

        //foreach(Player player in dummyPlayers)
        //{
        //    DataService.InsertPlayer(player);
        //}
    }

    private void ShowPlayers()
    {
        foreach (var player in DataService.GetAllPlayers())
        {
            Debug.Log($"ID:{player.Id}/NAME:{player.Name}/SCORE:{player.Score} \n");
        }
    }

    private void Diary()
    {
        //List<DiaryData> data = new List<DiaryData>()
        //{
        //    new DiaryData { Title = "タイトル", MainText = "文章文章文章文章文章文章", Tags = "test01,test02" },
        //    new DiaryData { Title = "Title", MainText = "testtesttesttesttesttest", Tags = "test01,test03" },
        //};

        //Debug.Log(SaveSQLite.Database);
        //SaveSQLite.DataSeve<DiaryData>(data[0]);
        //SaveSQLite.DataSeve<DiaryData>(data[1]);

        string[] tags = { "test01"};
        foreach (var setlist in SaveSQLite.FiliterTags<DiaryData>(tags, "Sample"))
        {
            Debug.Log($"{setlist.Id}, {setlist.Day}, {setlist.Title}");
        }
    }

    private void OnButton()
    {
        // 空白が無いようにする
        foreach (var input in TMP_InputField)
        {
            if(string.IsNullOrEmpty(input.text))
            {
                Debug.Log("空白");
                return;
            }
        }

        var data = new DiaryData { Title = $"{TMP_InputField[0].text}", MainText = $"{TMP_InputField[1].text}", Tags = $"{TMP_InputField[2].text}" };
        SaveSQLite.DataSeve<DiaryData>(data);
        foreach (var setlist in SaveSQLite.GetAllPlayers<DiaryData>())
        {
            Debug.Log($"{setlist.Id}, {setlist.Day}, {setlist.Title}");
        }
    }
}
