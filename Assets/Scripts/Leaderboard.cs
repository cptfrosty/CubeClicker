using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
    //���� ��� ���������� �������
    private const string keyLeaderNickname = "LeaderNickname";
    private const string keyLeaderScore = "LeaderScore"; 
    

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
            leader.Nickname += PlayerPrefs.GetString(keyLeaderNickname + (i + 1));
            leader.Score += PlayerPrefs.GetInt(keyLeaderScore + (i + 1));

            listLeaders.Add(leader); //���������� � ������ �������
        }

        return listLeaders;
    }

    /// <summary>
    /// ��������� ������ � ������� �������
    /// </summary>
    /// <param name="player">���������� �� ������</param>
    public void SaveLeader(Player player)
    {
        //��������� ������ �������
        List<Player> leaders = GetList();

        for(int i = 0; i < leaders.Count; i++)
        {
            if(leaders[i].Score < player.Score)
            {
                leaders[i].Nickname = player.Nickname;
                leaders[i].Score = player.Score;
            }
        }
    }
}

//����� ������
public class Player
{
    public string Nickname; //������� ������
    public int Score; //���� ������
}
