using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;


public class CustomerOrder : MonoBehaviour
{
    public enum TACO_SHELL 
    {
        SOFT = 0,
        HARD = 1,
        CORN = 2
    }

    public enum MEAT 
    {
        GROUND_BEEF = 0,
        CHICKEN = 1,
        STEAK = 2
    }

    public enum TOPPINGS 
    {
        LETTUCE = 0,
        CHEESE = 1,
        TOMATOES = 2,
        FAJITA_VEGGIES = 3,
        GUAC = 4,
        TACO_SAUCE = 5
    }

    public List<int> RandomizeOrder() 
    {
        List<int> order = new List<int>();
        int randomShell = UnityEngine.Random.Range(0, 3);
        order.Add(randomShell);
        int randomMeat = UnityEngine.Random.Range(0, 3);
        order.Add(randomMeat);
        int randomAmountOfToppings = UnityEngine.Random.Range(0, 6);
        Debug.Log("randomAmountOfToppings: " + randomAmountOfToppings);
        while (randomAmountOfToppings > 0) 
        {
            int randomTopping = UnityEngine.Random.Range(0, 6);
            order.Add(randomTopping);
            randomAmountOfToppings--;
        }

        return order;
    }
}
