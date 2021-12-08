using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
    public static Leaderboard Instance;

    //Ключ для сохранения лидеров
    private const string keyLeaderNickname = "LeaderNickname";
    private const string keyLeaderScore = "LeaderScore";

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
    }

    /// <summary>
    /// Получение списка лидеров
    /// </summary>
    /// <returns>Список лидеров</returns>
    public List<Player> GetList()
    {
        List<Player> listLeaders = new List<Player>();
        for(int i = 0; i < 10; i++)
        {
            Player leader = new Player(); //Экземпляр структуры

            //Получение лидеров по ключу Leader(номер_позиции)
            leader.Nickname = PlayerPrefs.GetString(keyLeaderNickname + (i + 1), "NoName");
            leader.Score = PlayerPrefs.GetInt(keyLeaderScore + (i + 1), 0);

            listLeaders.Add(leader); //Добавление в список лидеров
        }

        return listLeaders;
    }

    /// <summary>
    /// Сохранить игрока в списках лидеров
    /// </summary>
    /// <param name="player">Информация об игроке</param>
    public void Add(string nickname, int score)
    {
        Player player = new Player();
        player.Nickname = nickname;
        player.Score = score;

        //Получение списка лидеров
        List<Player> leaders = GetList();
        int pos = 0; //Позиция, которую должен занять игрок

        //Если самая последняя позиция имеет счёт меньше, чем у игрока
        if (leaders[leaders.Count - 1].Score < player.Score)
        {
            //Поиск позиции на которую должен встать игрок
            for (int i = 0; i < leaders.Count; i++)
            {
                if (leaders[i].Score < player.Score)
                {
                    pos = i;
                    break;
                }
            }

            //Смещение нижнего рейтинга
            for (int i = pos+1; i < leaders.Count - 1; i++)
            {
                leaders[i + 1].Nickname = leaders[i].Nickname;
                leaders[i + 1].Score = leaders[i].Score;
            }

            //Установить игрока в нужную позицию
            leaders[pos].Nickname = player.Nickname;
            leaders[pos].Score = player.Score;

            Save(leaders);
        }
    }

    /// <summary>
    /// Сохранить список лидеров
    /// </summary>
    /// <param name="leaders">Список лидеров</param>
    private void Save(List<Player> leaders)
    {
        for (int i = 0; i < 10; i++)
        {
            PlayerPrefs.SetString(keyLeaderNickname + (i + 1), leaders[i].Nickname);
            PlayerPrefs.SetInt(keyLeaderScore + (i + 1), leaders[i].Score);
        }
    }
}

//Класс игрока
public class Player
{
    public string Nickname; //Никнейм игрока
    public int Score; //Счёт игрока
}