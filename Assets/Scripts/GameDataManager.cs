using System.IO;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    public static GameDataManager Instance { get; private set; }

    private GameData _gameData;

    public string Player { get; set; }

    public string BestPlayer
    {
        get => _gameData.bestPlayer;
        set => _gameData.bestPlayer = value;
    }

    public int HighScore
    {
        get => _gameData.highScore;
        set => _gameData.highScore = value;
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        _gameData = new GameData();
        GetGameData();
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SetHighscore(int score)
    {
        if (score > HighScore)
        {
            HighScore = score;
            BestPlayer = Player;
        }

        var json = JsonUtility.ToJson(_gameData);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void GetGameData()
    {
        var path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            var json = File.ReadAllText(path);
            var gameData = JsonUtility.FromJson<GameData>(json);
            BestPlayer = gameData.bestPlayer;
            HighScore = gameData.highScore;
        }
    }
}
