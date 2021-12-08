using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buster : MonoBehaviour
{
    [SerializeField] private int _cps;
    [SerializeField] private int _cpsUp;
    [SerializeField] private int _count;
    [SerializeField] private int _cost;
    [SerializeField] private int _costUp;

    [Header("UI")]
    [SerializeField] private Text _cpsInfo;
    [SerializeField] private Text _countInfo;
    [SerializeField] private Text _costInfo;

    private IEnumerator _counterCubes;
    private MainCube mainCube;
    private void Start()
    {
        _counterCubes = AccrualCubes();
        //Поиск объекта с компонентом MainCube
        mainCube = GameObject.FindObjectOfType<MainCube>();
        UpdateInfo(); //Обновление информации о бустере
        StartCoroutine(_counterCubes);
    }

    /// <summary>
    /// Покупка бустеров
    /// </summary>
    public void Click()
    {
        if(GameManager.Instance.Cubes >= _cost)
        {
            GameManager.Instance.Cubes -= _cost;
            _count++;
            _cost += _costUp;
            _cps += _cpsUp;

            UpdateInfo(); //Обновить информацию
            mainCube.UpdateInfo(); //Обновить информацию о кубах
        }
    }

    public void UpdateInfo()
    {
        _cpsInfo.text = $"Cps: {_cps}";
        _countInfo.text = $"Count: {_count}";
        _costInfo.text = $"{_cost}";
    }

    //Корутина зачисления кубов
    IEnumerator AccrualCubes()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            mainCube.AddCubes(_cps);
            mainCube.UpdateInfo();
        }
    }
}
