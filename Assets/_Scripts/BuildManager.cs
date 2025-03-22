using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager main;

    [Header("References")]
    [SerializeField] private GameObject[] ArcherTowerPrefabs;
    [SerializeField] private GameObject[] IceTowerPrefabs;

    private int selectedTower = 0;

    private void Awake()
    {
        main = this;
    }

    public GameObject GetSelectedTower()
    {
        
        return ArcherTowerPrefabs[selectedTower]; 
    }

    public void SetSelectedTower(int towerIndex)
    {
        selectedTower = towerIndex;
    }
}


