using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Node : MonoBehaviour
{
    public static Node selectedNode;
    private Animator anim;
    private bool isSelected = false;
    // Start is called before the first frame update
   
    public void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void OnMouseDown()
    {
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
