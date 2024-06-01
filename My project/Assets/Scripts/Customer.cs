using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Security.Cryptography;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;

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
        
        switch (orderSequence[0])
        {
           case (int)CustomerOrder.TACO_SHELL.SOFT:
                //Enable the image equal to the enum
                Debug.Log("Soft Shell");
               break;

           case (int)CustomerOrder.TACO_SHELL.HARD:
                //Enable the image equal to the enum
                Debug.Log("Hard Shell");
                break;

           case (int)CustomerOrder.TACO_SHELL.CORN:
                //Enable the image equal to the enum
                Debug.Log("Corn Shell");
                break;
        }
        switch (orderSequence[1])
        {
            case (int)CustomerOrder.MEAT.GROUND_BEEF:
                //Enable the image equal to the enum
                Debug.Log("Ground Beef");
                break;

            case (int)CustomerOrder.MEAT.CHICKEN:
                //Enable the image equal to the enum
                Debug.Log("Chicken");
                break;

            case (int)CustomerOrder.MEAT.STEAK:
                //Enable the image equal to the enum
                Debug.Log("Steak");
                break;
        }
        if (orderSequence.Count > 2) 
        {
            for (int i = 2; i < orderSequence.Count; i++) 
            {
                switch (orderSequence[i]) 
                {
                    case (int)CustomerOrder.TOPPINGS.LETTUCE:
                        //Enable the image equal to the enum
                        Debug.Log("Lettuce");
                        break;

                    case (int)CustomerOrder.TOPPINGS.CHEESE:
                        //Enable the image equal to the enum\
                        Debug.Log("Cheese");
                        break;

                    case (int)CustomerOrder.TOPPINGS.TOMATOES:
                        //Enable the image equal to the enum
                        Debug.Log("Tomatoes");
                        break;

                    case (int)CustomerOrder.TOPPINGS.FAJITA_VEGGIES:
                        //Enable the image equal to the enum
                        Debug.Log("Fajita Veggies");
                        break;

                    case (int)CustomerOrder.TOPPINGS.GUAC:
                        //Enable the image equal to the enum
                        Debug.Log("Guac");
                        break;

                    case (int)CustomerOrder.TOPPINGS.TACO_SAUCE:
                        //Enable the image equal to the enum
                        Debug.Log("Taco Sauce");
                        break;
                }

            }
        }


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