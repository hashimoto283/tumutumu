using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class sukiru : MonoBehaviour
{

    public float additionalTime;
    private TimeScript timeScript;


    public void Timer()
    {
       timeScript= GameObject.Find("Time").GetComponent<TimeScript>();
        


     

        timeScript.AddTime(additionalTime);
        Debug.Log("a");
      
       
    }
    
}
