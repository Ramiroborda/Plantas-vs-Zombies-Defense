using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TowerUIPanelManager : MonoBehaviour
{
    private Plant plant;
    public TextMeshProUGUI towerNameTxt;
    public TextMeshProUGUI towerDescriptionTxt;
    public TextMeshProUGUI towerRangeTxt;
    public TextMeshProUGUI towerDMGTxt;
    public TextMeshProUGUI towerVelocityTxt;
    public TextMeshProUGUI towerSellPriceTxt;
    public TextMeshProUGUI towerUpgradePriceTxt;
    public GameObject root;
    public Button buttonUpgrade;
    public Button buttonSell;

    public static TowerUIPanelManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    public void OpenPanel(Plant plant)
    {
        if (plant == null)
        {
            Debug.Log("Es necesario pasar una torre");
            return;
        }
        this.plant = plant;
        if (plant.currentIndexUpgrade>= plant.plantUpgradeData.Count)
        {
            buttonUpgrade.gameObject.SetActive(false);
        }
        else
        {
            buttonUpgrade.onClick.AddListener(UpdateTower);
        }
        buttonSell.onClick.RemoveAllListeners();
        buttonSell.onClick.AddListener(SellTower);
        SetValues();
        root.SetActive(true);
    }


    public void UpdateTower( )
    {
        if (plant == null)
        {
            Debug.Log("Tower cannot be null");
            return;
        }
        if (PlayerData.instance.money >= plant.plantUpgradeData[plant.currentIndexUpgrade].upgradePrice )
        {
            plant.currentData = plant.plantUpgradeData[plant.currentIndexUpgrade];
            
            PlayerData.instance.TakeMoney(plant.plantUpgradeData[plant.currentIndexUpgrade].upgradePrice);
            if (plant.currentIndexUpgrade +1 >= plant.plantUpgradeData.Count)
            {
                buttonUpgrade.gameObject.SetActive(false);
            }
            else
            {
                plant.currentIndexUpgrade++;
            }
            OpenPanel(plant);
        }
        else
        {
            Debug.Log("not have money");
        }

    }

    public void SellTower()
    {
        if (plant != null)
        {
            PlayerData.instance.AddMoney(plant.currentData.sellPrice);
            Destroy(plant.gameObject);
            CLosePanel();
        }
    }
    private void SetValues()
    {
        towerNameTxt.text = plant.towerName;
        towerDescriptionTxt.text = plant.towerDescription;
        towerRangeTxt.text = "Rango: "+ plant.currentData.range +"";
        towerDMGTxt.text = "Daño: " + plant.currentData.dmg.ToString();
        towerVelocityTxt.text = "Velocidad: " + plant.currentData.timeShoot.ToString();
        towerSellPriceTxt.text = "Suns " + plant.currentData.sellPrice.ToString();
        towerUpgradePriceTxt.text = "Suns " + plant.currentData.upgradePrice.ToString();
    }

    public void CLosePanel()
    {
        root.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
