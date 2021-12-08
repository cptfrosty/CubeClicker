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
        #region ������� Singleton
        //���� ������ �� ������ �� �������
        if (Instance == null)
        {
            //������� ������ �� ���� ������
            Instance = this;
            //� ��� �������� �� ����� �� ������� ���
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            //���� ����� ������ ��� ����, �� ������� ���� ������
            Destroy(this.gameObject);
        }
        #endregion

        _autoSave = AutoSave();
    }

    /// <summary>
    /// �������� �����
    /// </summary>
    /// <param name="value">���-�� �����</param>
    public void AddCubes(int value)
    {
        Cubes += value;
    }

    /// <summary>
    /// �������� ��������������
    /// </summary>
    /// <param name="on">��������/���������</param>
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
    /// �������� �����
    /// </summary>
    /// <param name="value">���-�� ������</param>
    public void AddClicks(int value)
    {
        Clicks += value;
    }
}
