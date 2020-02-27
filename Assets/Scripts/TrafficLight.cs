using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLight
{
    public GameObject trafficLight;
    public GameObject greenLight;
    public GameObject yellowLight;
    public GameObject redLight;
    public State state;

    public TrafficLight(GameObject trafficLight)
    {
        this.trafficLight = trafficLight; 
        greenLight = trafficLight.transform.GetChild(2).gameObject;
        yellowLight = trafficLight.transform.GetChild(1).gameObject;
        redLight = trafficLight.transform.GetChild(0).gameObject;
    }  
    public enum State
    {
        Red,YellowToRed,YellowToGreen,Green
    }
}
