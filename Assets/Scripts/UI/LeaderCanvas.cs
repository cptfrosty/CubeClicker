using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderCanvas : MonoBehaviour
{
    [SerializeField] private Text infoLeaders;

    private void OnEnable()
    {
        //Получение списка лидеров
        List<Player> leaders = Leaderboard.Instance.GetList();

        //Отображение списка лидеров
        for(int i = 0; i < leaders.Count; i++)
        {
            infoLeaders.text += $"{i + 1}. {leaders[i].Nickname}\t - \t{leaders[i].Score}\n";
        }
    }

    private void OnDisable()
    {
        //При отключение каваса
        //Список лидеров очищается
        infoLeaders.text = "";
    }
}
