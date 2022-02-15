using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    [SerializeField] TMP_InputField _nameInputField;
    [SerializeField] TextMeshProUGUI _bestScoreText;

    private void Start()
    {
        _bestScoreText.text = $"Best Score : {GameDataManager.Instance.BestPlayer} : {GameDataManager.Instance.HighScore}";
    }

    public void LoadGame()
    {
        if (SetName())
            SceneManager.LoadScene("main");
    }

    private bool SetName()
    {
        var playerName = _nameInputField.text;
        if (playerName != "")
        {
            Debug.Log(playerName);
            GameDataManager.Instance.Player = playerName;
            return true;
        }

        return false;
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
