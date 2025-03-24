using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager main;

    [Header("References")]
    [SerializeField] private TowerData[] towers;

    private int selectedTower = 0;

    private void Awake()
    {
        main = this;
    }

    public TowerData GetSelectedTower()
    {
        if (towers == null || towers.Length == 0)
        {
            Debug.LogError("No towers assigned in BuildManager!");
            return null;
        }

        return towers[selectedTower];
    }

    public void GetSelectedTower(int towerIndex)
    {
        if (towerIndex >= 0 && towerIndex < towers.Length)
        {
            selectedTower = towerIndex;
        }
    }

    public void SetSelectedTower(int _selectedTower)
    {
        selectedTower = _selectedTower;
    }

}



