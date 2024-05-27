using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightFood : MonoBehaviour
{
    // Start is called before the first frame update
    
    private void OnMouseEnter()
    {
        GetComponent<Renderer>().material.color = new(255,255,255);
        Debug.Log("Enter collider");
    }
    private void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = new Color(94, 94, 94);
        Debug.Log("Exit collider");
    }
}
