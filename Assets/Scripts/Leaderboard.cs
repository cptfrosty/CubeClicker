using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
    //Ключ для сохранения лидеров
    private const string keyLeaderNickname = "LeaderNickname";
    private const string keyLeaderScore = "LeaderScore"; 
    

    /// <summary>
    /// Получение списка лидиров
    /// </summary>
    /// <returns>Список лидеров</returns>
    public List<Leader> GetList()
    {
        List<Leader> listLeaders = new List<Leader>();
        for(int i = 0; i < 10; i++)
        {
            Leader leader = new Leader(); //Экземпляр структуры

            //Получение лидеров по ключу Leader(номер_позиции)
            leader.Nickname += PlayerPrefs.GetString(keyLeaderNickname + (i + 1));
            leader.Score += PlayerPrefs.GetInt(keyLeaderScore + (i + 1));

            listLeaders.Add(leader); //Добавление в список лидеров
        }

        return listLeaders;
    }
}

//Структура лидера
public struct Leader
{
    public string Nickname; //Никнейм лидера
    public int Score; //Счёт лидера
}
