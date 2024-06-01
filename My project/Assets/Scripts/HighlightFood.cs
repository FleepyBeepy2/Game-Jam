using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightFood : MonoBehaviour
{
    // Start is called before the first frame update
    
   private void OnMouseEnter()
{
    GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f); // White color
    Debug.Log("Enter collider");
}

private void OnMouseExit()
{
    GetComponent<Renderer>().material.color = new Color(94f / 255f, 94f / 255f, 94f / 255f); // Original color
    Debug.Log("Exit collider");
}

}
