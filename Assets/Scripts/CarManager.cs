using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarManager : MonoBehaviour
{
    [SerializeField]
    WheelCollider SagOn, SolOn, SagArka, SolArka;
    [SerializeField]
    Transform SagOn_M, SolOn_M, SagArka_M, SolArka_M;

    [SerializeField]
    float maxSpeed = 15f, motorTorque = 10f, donusHizi = 10f;
    void Start()
    {
        motorTorque = 55550f;
    }

    // Update is called once per frame
    void Update()
    {

        if (Mathf.Abs(GetComponent<Rigidbody>().velocity.x) > maxSpeed)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(-maxSpeed, GetComponent<Rigidbody>().velocity.y,
                GetComponent<Rigidbody>().velocity.z);
        }
        if (Input.GetAxis("Vertical") != 0)
        {
            HareketET(Input.GetAxis("Vertical"));
        }
        if (Input.GetAxis("Horizontal") != 0)
        {
            Don(Input.GetAxis("Horizontal"));

        }
    }

    void HareketET(float nereGidem)
    {       
        SagOn.motorTorque = motorTorque * nereGidem;
        SolOn.motorTorque = motorTorque * nereGidem;
    }

    void Don(float nereDonem)
    {
        SagOn.steerAngle = donusHizi * nereDonem;
        SolOn.steerAngle = donusHizi * nereDonem;
    }

}
