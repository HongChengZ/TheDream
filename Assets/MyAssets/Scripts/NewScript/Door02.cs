using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door02 : MonoBehaviour
{
    public GameObject TriggerObj01;
    public GameObject TriggerObj02;
    public GameObject Exit;
    public int NumTriggered=0;
    public int NumMax=2;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame

    public void Check()
    {
     if(TriggerObj01.GetComponent<TriggerOpenDoor1>().isTriggered&& TriggerObj02.GetComponent<TriggerOpenDoor1>().isTriggered)
        {
            OpentheDoor();
        }
    }


    public void OpentheDoor()
    {
        GetComponent<Animation>().Play();
    }
}
