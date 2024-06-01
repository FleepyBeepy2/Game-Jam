using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Security.Cryptography;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;
using System.Text;

public class Customer : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] customerPath;
    public int currentPos;
    public NavMeshAgent agent;
    bool orderTaken = false;
    bool customerSelected = false;
    public float emissionIntensity;
    public float patience;
    // the text object to display
    public receipt orderDisplay;


    void Start()
    {
        currentPos = 0;
        transform.position = customerPath[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (agent.remainingDistance <= .01 && currentPos != 2)
        {
            currentPos += 1;
            agent.SetDestination(customerPath[currentPos].position);
            
        }
        else if (currentPos == 2 && agent.remainingDistance <= .01) 
        {
            if (orderTaken == true) 
            {
                currentPos += 1;
                agent.SetDestination(customerPath[currentPos].position);
                //Begin reducing the patience meter even more
            }
        }
       
    }

    void GenerateOrder() 
    {
        
         CustomerOrder customerOrder = new CustomerOrder();
        List<int> orderSequence = customerOrder.RandomizeOrder();
        StringBuilder orderString = new StringBuilder();
        orderString.Append("Shell: ");
        switch (orderSequence[0])
        {
           case (int)CustomerOrder.TACO_SHELL.SOFT:
                //Enable the image equal to the enum
                Debug.Log("Soft Shell");
                // all of these in the codde append to the order string so we can display it
                orderString.Append("Soft Shell\n");
                break;

           case (int)CustomerOrder.TACO_SHELL.HARD:
                //Enable the image equal to the enum
                Debug.Log("Hard Shell");
                orderString.Append("Hard Shell\n");
                break;

           case (int)CustomerOrder.TACO_SHELL.CORN:
                //Enable the image equal to the enum
                Debug.Log("Corn Shell");
                orderString.Append("Corn Shell\n");
                break;
        }
        orderString.Append("Meat: ");
        switch (orderSequence[1])
        {
            case (int)CustomerOrder.MEAT.GROUND_BEEF:
                //Enable the image equal to the enum
                Debug.Log("Ground Beef");
                orderString.Append("Ground Beef\n");
                break;

            case (int)CustomerOrder.MEAT.CHICKEN:
                //Enable the image equal to the enum
                Debug.Log("Chicken");
                orderString.Append("Chicken\n");
                break;

            case (int)CustomerOrder.MEAT.STEAK:
                //Enable the image equal to the enum
                Debug.Log("Steak");
                orderString.Append("Steak\n");
                break;
        }
        if (orderSequence.Count > 2) 
        {
            orderString.Append("Toppings: ");
            for (int i = 2; i < orderSequence.Count; i++) 
            {
                switch (orderSequence[i]) 
                {
                    case (int)CustomerOrder.TOPPINGS.LETTUCE:
                        //Enable the image equal to the enum
                        Debug.Log("Lettuce");
                        orderString.Append("Lettuce\n");
                        break;

                    case (int)CustomerOrder.TOPPINGS.CHEESE:
                        //Enable the image equal to the enum\
                        Debug.Log("Cheese");
                        orderString.Append("Cheese\n");
                        break;

                    case (int)CustomerOrder.TOPPINGS.TOMATOES:
                        //Enable the image equal to the enum
                        Debug.Log("Tomatoes");
                        orderString.Append("Tomatoes\n");
                        break;

                    case (int)CustomerOrder.TOPPINGS.FAJITA_VEGGIES:
                        //Enable the image equal to the enum
                        Debug.Log("Fajita Veggies");
                        orderString.Append("Fajita Veggies\n");
                        break;

                    case (int)CustomerOrder.TOPPINGS.GUAC:
                        //Enable the image equal to the enum
                        Debug.Log("Guac");
                        orderString.Append("Guac\n");
                        break;

                    case (int)CustomerOrder.TOPPINGS.TACO_SAUCE:
                        //Enable the image equal to the enum
                        Debug.Log("Taco Sauce");
                        orderString.Append("Taco Sauce\n");
                        break;
                }

            }
        }

        // Update the UI text with the order details
        orderDisplay.UpdateOrderText(orderString.ToString());


    }

    private void OnMouseDown()
    {
        Debug.Log("Clicked on customer");
        if (currentPos == 2 && orderTaken == false && customerSelected == true) 
        {
            orderTaken = true;
            GenerateOrder();
        }
    }
    private void OnMouseEnter()
    {
        Debug.Log("Entered customer's collider");
        if (currentPos == 2 && orderTaken == false) 
        {

            customerSelected = true;
            GetComponent<Renderer>().material.SetColor("_EmissionColor", GetComponent<Renderer>().material.color * emissionIntensity);
        }

        //if player is holding a taco and the order has been taken
            //increase emission
            

    }

    private void OnMouseExit()
    {
        Debug.Log("Exited customer's collider");
        if (currentPos == 2 && orderTaken == false)
        {
            customerSelected = true;
            GetComponent<Renderer>().material.DisableKeyword("_EmissionColor");
        }
    }

    private void OnMouseUp()
    {
        //if player is holding a taco, the order has been taken
            //if player has the order right
                //increase score
                //destroy customer gameobject
            //else
                //play the incorrect sound
                //decrease the customer's patience meter by a significant amount
    }
}