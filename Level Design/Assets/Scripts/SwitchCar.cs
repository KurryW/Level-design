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

    public Transform RespawnPoint;

    MovementCar MovementCar;

    bool InCar;
    bool CanGetInTheCar = false;

    private void Start()
    {
        MovementCar = GetComponent<MovementCar>();
    }

    private void Update()
    {
        CanGetInCar();

        if (InCar == true)
        {
            CanGetOutCar();
            Debug.Log("ik kan uit de auto");
        }
    }

    private void OnTriggerEnter(Collider ColliderCar)
    {
        CanGetInTheCar = true;
        Debug.Log("CarReady");
        UICar.SetActive(true);
    }

    private void OnTriggerExit(Collider ColliderCar)
    {
        UICar.SetActive(false);
        CanGetInTheCar = false;
    }

    void CanGetInCar()
    {
        if(CanGetInTheCar == true)
        {
            if(Input.GetKey(KeyCode.Q))
            {
                gameObject.GetComponent<MovementCar>().enabled = true;
                playerCamera.Priority = 0;
                carCamera.Priority = 1;
                InCar = true;
                Player.SetActive(false);
                Debug.Log("ik zit in de auto");
            }

        }

    }

    void CanGetOutCar()
    {

        if(Input.GetKey(KeyCode.E) && MovementCar.speed <= 1f) 
        {
            gameObject.GetComponent<MovementCar>().enabled = false;
            playerCamera.Priority = 1;
            carCamera.Priority = 0;
            Player.SetActive(true);
            UICar.SetActive(false);
            Player.transform.position = RespawnPoint.transform.position;
            Debug.Log("ik ga de auto uit");
        }

        

    }
}
