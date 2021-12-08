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
    public List<Leader> GetList()
    {
        List<Leader> listLeaders = new List<Leader>();
        for(int i = 0; i < 10; i++)
        {
            Leader leader = new Leader(); //��������� ���������

            //��������� ������� �� ����� Leader(�����_�������)
            leader.Nickname += PlayerPrefs.GetString(keyLeaderNickname + (i + 1));
            leader.Score += PlayerPrefs.GetInt(keyLeaderScore + (i + 1));

            listLeaders.Add(leader); //���������� � ������ �������
        }

        return listLeaders;
    }
}

//��������� ������
public struct Leader
{
    public string Nickname; //������� ������
    public int Score; //���� ������
}
