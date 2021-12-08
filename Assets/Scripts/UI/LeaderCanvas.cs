using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderCanvas : MonoBehaviour
{
    [SerializeField] private Text infoLeaders;

    private void OnEnable()
    {
        //��������� ������ �������
        List<Player> leaders = Leaderboard.Instance.GetList();

        //����������� ������ �������
        for(int i = 0; i < leaders.Count; i++)
        {
            infoLeaders.text += $"{i + 1}. {leaders[i].Nickname}\t - \t{leaders[i].Score}\n";
        }
    }

    private void OnDisable()
    {
        //��� ���������� ������
        //������ ������� ���������
        infoLeaders.text = "";
    }
}
