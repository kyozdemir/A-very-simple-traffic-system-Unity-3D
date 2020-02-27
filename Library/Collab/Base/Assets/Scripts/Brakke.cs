using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brakke : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "carAI")
        {
            GetComponentInParent<CaRAI>().move = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "carAI")
        {
            GetComponentInParent<CaRAI>().move = true;
        }
    }
}
