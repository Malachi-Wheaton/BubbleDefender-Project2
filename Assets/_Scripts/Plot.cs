using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plot : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Color hoverColor;

    private GameObject ArcherTower;
    private Color startColor;
    private Color invisibleColor = new Color(0, 0, 0, 0);  
    private bool HasTower = false;

    private void Start()
    {
        
        startColor = sr.color;
        sr.color = invisibleColor;  
    }

    private void OnMouseEnter()
    {
        if (HasTower)
        {
            return;
        }
        
        sr.color = startColor;
    }

    private void OnMouseExit()
    {
        
        sr.color = invisibleColor;
    }

    private void OnMouseDown()
    {
        if (ArcherTower != null) return;
        HasTower = true;

        TowerData TowerToBuild = BuildManager.main.GetSelectedTower();

        if (TowerToBuild == null)
        {
            Debug.LogError("No tower selected! Check if BuildManager is returning a tower.");
            return;
        }

        if (TowerToBuild.prefab == null)
        {
            Debug.LogError($"Tower {TowerToBuild.name} has no prefab assigned!");
            return;
        }
        if(TowerToBuild.cost > LevelManager.main.currency)
        {
            Debug.Log("You can't afford this tower");
               return;
        }

        LevelManager.main.SpendCurrency(TowerToBuild.cost);

        ArcherTower = Instantiate(TowerToBuild.prefab, transform.position, Quaternion.identity);
    }
}


