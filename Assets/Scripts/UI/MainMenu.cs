using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// Загрузка игры
    /// </summary>
    /// <param name="input">Поле ввода</param>
    public void LoadGame(InputField input)
    {
        if (string.IsNullOrEmpty(input.text)) return;
        GameManager.Instance.SetNickname = input.text;

        //Название загружаемой сцены
        SceneManager.LoadScene("Game");
    }

    /// <summary>
    /// Выход из игры
    /// </summary>
    public void Exit()
    {
        Application.Quit();
    }
}
