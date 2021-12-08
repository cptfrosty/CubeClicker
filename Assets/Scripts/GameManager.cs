using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private string _nickname;
    public int Cubes { get; set; }
    public int Clicks { get; set; }

    IEnumerator _autoSave;

    public string SetNickname { set => _nickname = value; }
    private void Awake()
    {
        #region Паттерн Singleton
        //Если ссылка на объект не указана
        if (Instance == null)
        {
            //Указать ссылку на этот объект
            Instance = this;
            //И при переходе на сцены не удалять его
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            //Если такой объект уже есть, то удалить этот объект
            Destroy(this.gameObject);
        }
        #endregion

        _autoSave = AutoSave();
    }

    /// <summary>
    /// Добавить кубов
    /// </summary>
    /// <param name="value">кол-во кубов</param>
    public void AddCubes(int value)
    {
        Cubes += value;
    }

    /// <summary>
    /// Включить автосохранение
    /// </summary>
    /// <param name="on">включить/выключить</param>
    public void SetAutoSave(bool on)
    {
        if (on)
        {
            StartCoroutine(_autoSave);
        }
        else
        {
            StopCoroutine(_autoSave);
        }
    }

    private IEnumerator AutoSave()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);
            Leaderboard.Instance.Add(_nickname, Cubes);
        }
    }

    /// <summary>
    /// Добавить клики
    /// </summary>
    /// <param name="value">кол-во кликов</param>
    public void AddClicks(int value)
    {
        Clicks += value;
    }
}
