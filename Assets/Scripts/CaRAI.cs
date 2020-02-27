using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaRAI : MonoBehaviour
{
    [SerializeField]
    float speed = 0.1f;
    [SerializeField]
    public Transform hedefler;
    public int hedefCount = 0;
    [SerializeField]
    public bool move;
    public bool TrafikIsigi = true;
    public bool kavsaktaGec = true;
    float brakes = 0f;
    
    void Start()
    {
        move = true;
    }
    void Update()
    {
        
        if (move && TrafikIsigi && kavsaktaGec)
        {
            transform.Translate(Vector3.forward * speed);
            if (hedefler != null)
            {
                GetComponentInChildren<Brakke>().mesafe = 1;
                transform.LookAt(new Vector3(hedefler.GetChild(hedefCount).position.x,
                transform.position.y, hedefler.GetChild(hedefCount).position.z));
            }
            

            if (hedefler != null && Vector3.Distance(transform.position, new Vector3(hedefler.GetChild(hedefCount).position.x,
                                                                transform.position.y,
                                                                hedefler.GetChild(hedefCount).position.z) ) < 1f)
            {
                hedefCount++;
                if (hedefCount == hedefler.childCount)
                {

                    hedefCount = 0;
                    hedefler = null;
                }
            }
        }
        else
        {
            print("uy çarptım");
        }
    }
    


}
