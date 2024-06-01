using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightFood : MonoBehaviour
{
    // Start is called before the first frame update
    Color originalColor;
    private void Start()
    {
        originalColor = GetComponent<Renderer>().material.color;
    }

    private void OnMouseEnter()
{
    GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f); // White color
    Debug.Log("Enter collider");
}

private void OnMouseExit()
{
    GetComponent<Renderer>().material.color = originalColor; // Original color
    Debug.Log("Exit collider");
}

}
