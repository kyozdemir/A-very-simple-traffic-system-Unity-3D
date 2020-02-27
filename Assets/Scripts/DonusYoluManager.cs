using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonusYoluManager : MonoBehaviour
{
    [SerializeField]
    List<string> nereDonemList = new List<string>();
    int randomWay = 0;
    Transform sagaDon;
    Transform solaDon;
    void Start()
    {
        sagaDon = transform.GetChild(0);
        solaDon = transform.GetChild(1);
    }
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "carAI")
        {
            randomWay = Random.Range(0, nereDonemList.Count);
            print("KASDKASKD " + randomWay);
            if (nereDonemList[randomWay] == "sag")
            {
                other.GetComponent<CaRAI>().hedefCount = 0;
                other.GetComponent<CaRAI>().hedefler = sagaDon;
            }
            else if (nereDonemList[randomWay] == "sol")
            {
                other.GetComponent<CaRAI>().hedefCount = 0;
                other.GetComponent<CaRAI>().hedefler = solaDon;
            }
        }
    }


}
