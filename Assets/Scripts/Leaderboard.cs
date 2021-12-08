using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
    public static Leaderboard Instance;

    //���� ��� ���������� �������
    private const string keyLeaderNickname = "LeaderNickname";
    private const string keyLeaderScore = "LeaderScore";

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
    }

    /// <summary>
    /// ��������� ������ �������
    /// </summary>
    /// <returns>������ �������</returns>
    public List<Player> GetList()
    {
        List<Player> listLeaders = new List<Player>();
        for(int i = 0; i < 10; i++)
        {
            Player leader = new Player(); //��������� ���������

            //��������� ������� �� ����� Leader(�����_�������)
            leader.Nickname = PlayerPrefs.GetString(keyLeaderNickname + (i + 1), "NoName");
            leader.Score = PlayerPrefs.GetInt(keyLeaderScore + (i + 1), 0);

            listLeaders.Add(leader); //���������� � ������ �������
        }

        return listLeaders;
    }

    /// <summary>
    /// ��������� ������ � ������� �������
    /// </summary>
    /// <param name="player">���������� �� ������</param>
    public void Add(string nickname, int score)
    {
        Player player = new Player();
        player.Nickname = nickname;
        player.Score = score;

        //��������� ������ �������
        List<Player> leaders = GetList();
        int pos = 0; //�������, ������� ������ ������ �����

        //���� ����� ��������� ������� ����� ���� ������, ��� � ������
        if (leaders[leaders.Count - 1].Score < player.Score)
        {
            //����� ������� �� ������� ������ ������ �����
            for (int i = 0; i < leaders.Count; i++)
            {
                if (leaders[i].Score < player.Score)
                {
                    pos = i;
                    break;
                }
            }

            //�������� ������� ��������
            for (int i = pos+1; i < leaders.Count - 1; i++)
            {
                leaders[i + 1].Nickname = leaders[i].Nickname;
                leaders[i + 1].Score = leaders[i].Score;
            }

            //���������� ������ � ������ �������
            leaders[pos].Nickname = player.Nickname;
            leaders[pos].Score = player.Score;

            Save(leaders);
        }
    }

    /// <summary>
    /// ��������� ������ �������
    /// </summary>
    /// <param name="leaders">������ �������</param>
    private void Save(List<Player> leaders)
    {
        for (int i = 0; i < 10; i++)
        {
            PlayerPrefs.SetString(keyLeaderNickname + (i + 1), leaders[i].Nickname);
            PlayerPrefs.SetInt(keyLeaderScore + (i + 1), leaders[i].Score);
        }
    }
}

//����� ������
public class Player
{
    public string Nickname; //������� ������
    public int Score; //���� ������
}