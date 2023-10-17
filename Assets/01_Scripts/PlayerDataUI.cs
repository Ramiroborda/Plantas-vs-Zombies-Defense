using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerDataUI : MonoBehaviour
{
    public TextMeshProUGUI moneyTxt;
    public static PlayerDataUI instance;


    public void Awake()
    {
        #region singleton
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        #endregion
    }
    public void UpdateMoneyText(string value)
    {
        moneyTxt.text = " " + value;
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
