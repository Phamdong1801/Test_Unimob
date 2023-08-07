using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayGUI : MonoBehaviour
{
    [SerializeField] Button spawn10Units;

    [SerializeField] Button spawn50Units;

    [SerializeField] Button spawn100Units;

    private void Start()
    {
        spawn10Units.onClick.AddListener(()=> GameplayManager.Ins.SpawnUnits(10));
        spawn50Units.onClick.AddListener(() => GameplayManager.Ins.SpawnUnits(50));
        spawn100Units.onClick.AddListener(() => GameplayManager.Ins.SpawnUnits(100));
    }
}
