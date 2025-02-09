using System;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEditor;
using UnityEditor.Playables;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    [Serializable]
    public class Player
    {
        public string playerName = "";
        public int score = 0;
        public Player(string myNane, int myScore) { playerName = myNane; score = myScore; }
    }

    [Serializable]
    public class PlayerList
    {
        public List<Player> players;
        public PlayerList(List<Player> players) { this.players = players; }
    }

    public static ScoreManager Instance;
    public List<Player> highScores = new List<Player>();
    private string savePath;
    [SerializeField] private GameObject inputFieldObj;
    private TMP_InputField inputField;
    [SerializeField] private GameObject inputFieldClear;
    private TMP_InputField clearInputField;

    [SerializeField] private Button clearAllPath;
    [SerializeField] private Button clearOnePath;

    public string newPlayerName;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        
        highScores = new List<Player>(){new Player("None",0), new Player("None",0), new Player("None",0)};
        
        inputField = inputFieldObj.GetComponent<TMP_InputField>();
        clearInputField = inputFieldClear.GetComponent<TMP_InputField>();
        
        savePath = Application.persistentDataPath + "/High_Scores_Save.json";
        
        clearAllPath.onClick.AddListener(ClearAllPath);
        clearOnePath.onClick.AddListener(ClearOnePath);

        DontDestroyOnLoad(gameObject);

        LoadData();
        
        var shows = FindObjectsByType<FindScore>(FindObjectsSortMode.None);
        foreach (var item in shows)
        {
            item.ShowText();
        }
    }

    // Update is called once per frame
    public void SubmitPlayer()
    {

        newPlayerName = inputField.text;
        print(newPlayerName);

        SceneManager.LoadScene(1);
    }

    public void UpdateList(int score)
    {
        foreach (var player in highScores)
        {
            if (newPlayerName == player.playerName)
            {
                if (player.score >= score)
                {
                    return;
                }
                else
                {
                    player.score = score;
                    highScores.Sort((a, b) => b.score.CompareTo(a.score));
                    SaveData();
                    return;
                }
            }
        }

        highScores.Add(new Player(newPlayerName, score));
        highScores.Sort((a, b) => b.score.CompareTo(a.score));
        
        if (highScores.Count > 3)
        {
            highScores.RemoveAt(3);    
        }

        SaveData();
    }

    public void SaveData()
    {
        string myJson = JsonUtility.ToJson(new PlayerList(highScores));
        File.WriteAllText(savePath, myJson);
    }

    public void LoadData()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            PlayerList playersList = JsonUtility.FromJson<PlayerList>(json);

            highScores = playersList.players;
        }
        else
        {
            highScores = new List<Player>(){new Player("None",0), new Player("None",0), new Player("None",0)};
        }
    }

    private void ClearAllPath()
    {
        File.Delete(savePath);

        highScores = new List<Player>(){new Player("None",0), new Player("None",0), new Player("None",0)};
        
        SaveData();

        var shows = FindObjectsByType<FindScore>(FindObjectsSortMode.None);
        foreach (var item in shows)
        {
            item.ShowText();
        }

        savePath = Application.persistentDataPath + "/High_Scores_Save.json";
    }

    private void ClearOnePath()
    {
        if (clearInputField == null)
        {
            print("Empty input.");
            return;
        }

        LoadData();

        foreach (var pl in highScores)
        {
            if (clearInputField.text == pl.playerName)
            {
                pl.playerName = "None";
                pl.score = 0;
                highScores.Sort((a, b) => b.score.CompareTo(a.score));
                SaveData();

                var shows = FindObjectsByType<FindScore>(FindObjectsSortMode.None);
                foreach (var item in shows)
                {
                    item.ShowText();
                }
                
                return;
            }
        }

        print("Name doesn't match.");
    }
}
