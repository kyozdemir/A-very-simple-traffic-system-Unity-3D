using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KavsakManager : MonoBehaviour
{

    public List<GameObject> carPriorityList = new List<GameObject>();

    public bool kavsakKullanimda = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        print(carPriorityList.Count);
        if (carPriorityList.Count > 0)
        {
            kavsakKullanimda = true;
            carPriorityList[0].GetComponent<CaRAI>().kavsaktaGec = true;
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "carAI")
        {
            if (kavsakKullanimda)
            {
                print("ArabaGeldi");
                other.GetComponent<CaRAI>().kavsaktaGec = false;
                
            }
            carPriorityList.Add(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "carAI")
        {

            carPriorityList.RemoveAt(0);
            
            kavsakKullanimda = false;
        }
    }
}
