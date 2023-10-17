using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LifeHouse : MonoBehaviour
{
    public int lifeHouse = 100;
    public Slider vidaVisual;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        vidaVisual.GetComponent<Slider>().value = lifeHouse;
        if (lifeHouse <= 0) 
        {
            //Debug.Log("Game Over");
            SceneManager.LoadScene("GameOver");
        }  
    }
}
