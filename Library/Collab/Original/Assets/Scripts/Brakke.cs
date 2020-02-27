using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brakke : MonoBehaviour
{
    [SerializeField]
    GameObject solRay,sagRay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DistanceControl(); 
    }
    void DistanceControl()
    {

        Ray royroyKazim = new Ray(solRay.transform.position,Vector3.forward*0.1f);
        Ray RayMalifalitiko = new Ray(sagRay.transform.position, Vector3.forward*0.1f);
        RaycastHit hit;
        float maxDistance = 1f;
        if(Physics.Raycast(royroyKazim, out hit))
        {
            Debug.DrawRay(solRay.transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Hit oldu: " + hit.transform.name);
        }
        if (Physics.Raycast(RayMalifalitiko, out hit))
        {
            Debug.DrawRay(sagRay.transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Hit oldu: " + hit.transform.name);
        }
        if (hit.transform.tag == "carAI" && hit.distance <= maxDistance)
        {
            Debug.Log("Yavasliyorum.");
            GetComponentInParent<CaRAI>().move = false;
        }
        else
        {
            GetComponentInParent<CaRAI>().move = true;
        }
        
    }
    
}
