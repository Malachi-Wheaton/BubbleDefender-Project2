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

    private void Start()
    {
        startColor = sr.color;
    }

    private void OnMouseEnter()
    {
        sr.color = hoverColor;
    }

    private void OnMouseExit()
    {
        sr.color = startColor;
    }

    private void OnMouseDown()
    {
        if (ArcherTower != null) return;  

        GameObject ArcherTowerToBuild = BuildManager.main.GetSelectedTower();
        ArcherTower = Instantiate(ArcherTowerToBuild, transform.position, Quaternion.identity);
    }
}

