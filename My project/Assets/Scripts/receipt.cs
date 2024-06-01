using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class receipt : MonoBehaviour
{
    public Text orderText;

    public void UpdateOrderText(string order)
    {
        // does as it says, displays text with the order
        orderText.text = order;
    }
}
