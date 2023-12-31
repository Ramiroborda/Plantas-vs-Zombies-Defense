using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Node : MonoBehaviour
{
    public static Node selectedNode;
    private Animator anim;
    private bool isSelected = false;
    public bool isOcuped;
    public Plant towerOcuped; 
    
   
    public void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void OnMouseDown()
    {
        if (isOcuped)
        {
            TowerUIPanelManager.instance.OpenPanel(towerOcuped);
            return;
        }
            
        if (selectedNode && selectedNode != this)
        {
            selectedNode.OnCloseSelection();
        }
        
        selectedNode = this;
        
        isSelected = !isSelected;
        if (isSelected )
        {
            TowerRequestManager.instance.OnOpenRequestPanel();
        }
        else
        
            TowerRequestManager.instance.OnCloseRequestPanel();
        
        anim.SetBool("IsSelected", isSelected);
    }
    public void OnCloseSelection()
    {
        isSelected = false;
        anim.SetBool("IsSelected", isSelected);
    }
}
