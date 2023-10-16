using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class TowerRequestManager : MonoBehaviour
{
    public List<Plant> plants = new List<Plant>();
    private Animator anim;
    public static TowerRequestManager instance;
    public void Awake()
    {
        if (!instance)
            instance = this;
        else
            Destroy(instance);
            anim = GetComponent<Animator>();
    }

    public void OnOpenRequestPanel()
    {
        anim.SetBool("IsOpen", true);
    }
    public void OnCloseRequestPanel()
    {
        anim.SetBool("IsOpen", false);
    }

    public void RequestTowerBuy(string towerName)
    {
        //for (int i = 0; i < plants.Count; i++)
        //{
        //    if (plants[i].towerName == towerName)
        //    {
        //        return plants[i];
        //    }

        //}
        //return null;
        var tower = plants.Find(x => x.towerName == towerName);
        if (tower.currentData.buyPrice <= PlayerData.instance.money)
        {
            PlayerData.instance.TakeMoney(tower.currentData.buyPrice);
        }
        else
        {
            Debug.Log("Not Money for Plant: " + towerName);
            return;
        }
        var towerGo = Instantiate(tower, Node.selectedNode.transform.position, tower.transform.rotation);
        Node.selectedNode.towerOcuped = towerGo;
        Node.selectedNode.isOcuped = true;
        OnCloseRequestPanel();  
        Node.selectedNode.OnCloseSelection();
        Node.selectedNode = null;
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
