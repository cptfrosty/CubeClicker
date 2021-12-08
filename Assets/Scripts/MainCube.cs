using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainCube : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Text _clicksInfo;
    [SerializeField] private Text _cubesInfo;

    private GameManager gm;

    private void Start()
    {
        gm = GameManager.Instance;

        //Выключить корутину, если вдруг она была включена
        gm.SetAutoSave(false); 
        //Включить автоматическое сохранение
        gm.SetAutoSave(true);
    }

    private void OnMouseDown()
    {
        transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
        AddCubes(1);
        gm.Clicks++;
        UpdateInfo();
    }

    private void OnMouseUp()
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
    }

    public void AddCubes(int value)
    {
        gm.AddCubes(value);
    }

    public void UpdateInfo()
    {
        _clicksInfo.text = $"Clicks: {gm.Clicks}";
        _cubesInfo.text = $"Cube: {gm.Cubes}";
    }
}
