using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;


public class SwitchCar : MonoBehaviour
{
    public CinemachineFreeLook playerCamera;
    public CinemachineFreeLook carCamera;

    public GameObject Player;
    public GameObject Car;

    public Collider ColliderCar;

    public GameObject UICar;

    public Transform PlayerGetsOut;

    bool InCar;

    private void Update()
    {
        //RaycastHit hit;

        //if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
        //{
        //    if (hit.transform.CompareTag("Car"))
        //    {
        //        CanGetInCar();
        //        Debug.Log("CarReady");
        //        UICar.SetActive(true);
        //    }

        //    else
        //    {
        //        UICar.SetActive(false);
        //    }
        //}
    }

    private void OnTriggerEnter(Collider ColliderCar)
    {
        CanGetInCar();
        Debug.Log("CarReady");
        UICar.SetActive(true);
    }

    private void OnTriggerExit(Collider ColliderCar)
    {
        UICar.SetActive(false);
    }

    void CanGetInCar()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            playerCamera.Priority = 0;
            carCamera.Priority = 1;
            CanGetOutCar();
            InCar = true;
            Player.SetActive(false);
        }

    }

    void CanGetOutCar()
    {
        if (InCar == true)
        {
            if(Input.GetKeyDown(KeyCode.E)) 
            { 
                playerCamera.Priority = 1;
                carCamera.Priority = 0;
                Player.SetActive(true);
                //Player.transform.position = PlayerGetsOut;
            }

        }

    }
}
