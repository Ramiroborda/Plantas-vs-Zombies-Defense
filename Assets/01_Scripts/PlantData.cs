using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlantData 
{
    [Header("Price")]
    public int upgradePrice;
    public int buyPrice = 10;
    public int sellPrice = 8;
    [Header("Plant Settings")]
    public float range =10;
    public float dmg = 20;
    public float timeShoot = 1;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
