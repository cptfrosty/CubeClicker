using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// �������� ����
    /// </summary>
    /// <param name="input">���� �����</param>
    public void LoadGame(InputField input)
    {
        if (string.IsNullOrEmpty(input.text)) return;
        GameManager.Instance.SetNickname = input.text;

        //�������� ����������� �����
        SceneManager.LoadScene("Game");
    }

    /// <summary>
    /// ����� �� ����
    /// </summary>
    public void Exit()
    {
        Application.Quit();
    }
}
