using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookMeat : MonoBehaviour
{
    // Start is called before the first frame update
    public enum COOKEDMEAT 
    {
        RAW = 0,
        COOKED = 1,
        OVERCOOKED = 2
    }
    public COOKEDMEAT stateOfMeat;
    public float raw = 0.0f;
    public float cooked = 2.0f;
    public float overCooked = 4.0f;
    public float time;
    bool isCooking = false;
    public GameObject fillBar;
    public GameObject progressBar;
    

    //Cook meter bar variable
    void Start()
    {
        time = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCooking == true) 
        {
            time += Time.deltaTime;
            fillBar.transform.localScale = new Vector3((2.0f/5.0f) * time, .15f, 1);
            if (fillBar.transform.localScale.x >= 2) 
            {
                fillBar.transform.localScale = new Vector3(2.0f, .15f, 1f);
                //ResetFillBar();
            }
        } 
    }

    private void OnMouseDown() 
    {
        if (isCooking == false)
        {
            isCooking = true;
            gameObject.transform.Find("Meat").gameObject.SetActive(true);
            progressBar.SetActive(true);
            fillBar.SetActive(true);
            Debug.Log("Started cooking meat");
        }
        else if (isCooking == true) 
        {
            isCooking = false;
            gameObject.transform.Find("Meat").gameObject.SetActive(false);
            progressBar.SetActive(false);
            fillBar.SetActive(false);
            Debug.Log("Stopped cooking meat");
            time = 0.0f;
            if (time >= raw && time < cooked)
            {
                stateOfMeat = COOKEDMEAT.RAW;
                Debug.Log("Meat is raw");
            }
            else if (time >= cooked && time <= overCooked) 
            {
                stateOfMeat = COOKEDMEAT.COOKED;
                Debug.Log("Meat is cooked");
            }
            else if(time >= overCooked)
            {
                stateOfMeat = COOKEDMEAT.OVERCOOKED;
                Debug.Log("Meat is overcooked");
            }
        }
    }

    private void OnMouseEnter() 
    {
        transform.position.Set(transform.localPosition.x, transform.localPosition.y + .2f , transform.localPosition.z);
    }
    private void OnMouseExit() 
    {
        transform.position.Set(transform.localPosition.x, transform.localPosition.y - .2f, transform.localPosition.z);
    }
    

    /*void ResetFillBar()
    {
        if (time >= cooked && time < overCooked)
        {
            
            fillBar.GetComponent<Renderer>().material.color = new Color(0f, 1f, 0f);
            progressBar.GetComponent<Renderer>().material.color = new Color(1f, 1f, 0f);
        }
        else if (time >= overCooked) 
        {
            
            fillBar.GetComponent<Renderer>().material.color = new Color(1f, 0f, 0f);
            progressBar.GetComponent<Renderer>().material.color = new Color(0f, 1f, 0f);
        }

    }
    */
}
