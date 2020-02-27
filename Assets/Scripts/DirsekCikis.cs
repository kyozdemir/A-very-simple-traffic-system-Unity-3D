using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirsekCikis : MonoBehaviour
{

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "carAI")
        {
            //other.GetComponent<CaRAI>().acceptedDistance = 10f;
        }
    }

}
