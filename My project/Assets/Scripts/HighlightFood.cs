using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightFood : MonoBehaviour
{
    public int toppingID; // Unique ID for the topping, set this in the Inspector
    private Renderer renderer;

    // List to store the current attempt at the customer order
    private static List<int> currentAttemptOrder = new List<int>();

    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    private void OnMouseEnter()
    {
        renderer.material.color = new Color(1f, 1f, 1f); // White color
        Debug.Log("Enter collider");
    }

    private void OnMouseExit()
    {
        renderer.material.color = new Color(94f / 255f, 94f / 255f, 94f / 255f); // Original color
        Debug.Log("Exit collider");
    }

    private void OnMouseDown()
    {
        currentAttemptOrder.Add(toppingID);
        Debug.Log("Topping added: " + toppingID);
    }

    // Optional: Method to clear the current attempt order list
    public static void ClearCurrentAttemptOrder()
    {
        currentAttemptOrder.Clear();
    }

    // Optional: Method to get the current attempt order list
    public static List<int> GetCurrentAttemptOrder()
    {
        return new List<int>(currentAttemptOrder); // Return a copy of the list
    }

}
