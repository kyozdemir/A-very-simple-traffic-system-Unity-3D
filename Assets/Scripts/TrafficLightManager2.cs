using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightManager2 : MonoBehaviour
{



    [Range(0, 50)]
    public float greenLightDuration = 10f;
    [Range(0, 50)]
    public float yellowLightDuration = 3f;
    [Range(0, 50)]
    public float redLightDuration = 10f;
    float flashTime = 0f;
    TrafficLight tf1;
    public bool Gec = true;

    // Start is called before the first frame update
    void Start()
    {
        tf1 = new TrafficLight(gameObject);

        tf1.greenLight.SetActive(true);
        tf1.yellowLight.SetActive(false);
        tf1.redLight.SetActive(false);
        tf1.state = TrafficLight.State.Green;


        flashTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        LightControl();
    }
    void LightControl()
    {
        if (tf1.state == TrafficLight.State.Red && (Time.time - flashTime) > redLightDuration)
        {

            flashTime = Time.time;
            tf1.state = TrafficLight.State.YellowToGreen;
            tf1.redLight.SetActive(false);
            tf1.yellowLight.SetActive(true);

        }
        else if (tf1.state == TrafficLight.State.YellowToGreen && (Time.time - flashTime) > yellowLightDuration)
        {

            flashTime = Time.time;
            tf1.state = TrafficLight.State.Green;
            tf1.yellowLight.SetActive(false);
            tf1.greenLight.SetActive(true);

        }
        else if (tf1.state == TrafficLight.State.Green && (Time.time - flashTime) > greenLightDuration)
        {
            flashTime = Time.time;
            tf1.state = TrafficLight.State.YellowToRed;
            tf1.greenLight.SetActive(false);
            tf1.yellowLight.SetActive(true);
        }
        else if (tf1.state == TrafficLight.State.YellowToRed && (Time.time - flashTime) > yellowLightDuration)
        {
            flashTime = Time.time;
            tf1.state = TrafficLight.State.Red;
            tf1.yellowLight.SetActive(false);
            tf1.redLight.SetActive(true);
        }
    }
    TrafficLight.State state()
    {
        return tf1.state;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "carAI" && (state() == TrafficLight.State.Red || state() == TrafficLight.State.YellowToGreen || state() == TrafficLight.State.YellowToRed))
        {
            print("Durmalısın");
            Gec = false;
            other.GetComponent<CaRAI>().TrafikIsigi = false;
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "carAI" && state() == TrafficLight.State.Green)
        {
            print("Gecmelisin");
            Gec = true;
            other.GetComponent<CaRAI>().TrafikIsigi = true;
        }
    }
}
