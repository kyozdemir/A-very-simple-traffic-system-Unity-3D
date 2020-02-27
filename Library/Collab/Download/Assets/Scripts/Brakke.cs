using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brakke : MonoBehaviour
{
    [SerializeField]
    LayerMask Hedef1,Hedef2;
    [SerializeField]
    public int mesafe;
    RaycastHit hit;
    public bool musaitMi = true;
    
    

    // Start is called before the first frame update
    void Start()
    {
       
        mesafe = 2;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, mesafe, Hedef1))
        {
            print("if'deyim" + gameObject.transform.parent.parent.name);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit: " + hit.transform.name);
            musaitMi = false;
            
            gameObject.transform.parent.parent.GetComponent<CaRAI>().move = false;

        }
        else
        {
            print("else'deyim" + gameObject.transform.parent.parent.name);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) *15, Color.white);
            Debug.Log("Did not Hit");
            musaitMi = true;
            gameObject.transform.parent.parent.GetComponent<CaRAI>().move = true;
        }
        

    }

 
}
