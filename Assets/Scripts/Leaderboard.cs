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
    public List<Player> GetList()
    {
        List<Player> listLeaders = new List<Player>();
        for(int i = 0; i < 10; i++)
        {
            Player leader = new Player(); //Экземпляр структуры

            //Получение лидеров по ключу Leader(номер_позиции)
            leader.Nickname += PlayerPrefs.GetString(keyLeaderNickname + (i + 1));
            leader.Score += PlayerPrefs.GetInt(keyLeaderScore + (i + 1));

            listLeaders.Add(leader); //Добавление в список лидеров
        }

        return listLeaders;
    }

    /// <summary>
    /// Сохранить игрока в списках лидеров
    /// </summary>
    /// <param name="player">Информация об игроке</param>
    public void SaveLeader(Player player)
    {
        //Получение списка лидеров
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

//Класс игрока
public class Player
{
    public string Nickname; //Никнейм лидера
    public int Score; //Счёт лидера
}
