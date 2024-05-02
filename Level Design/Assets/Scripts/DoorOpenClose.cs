using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenClose : MonoBehaviour
{
    private Animator anim;

    public Collider Car;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider Car)
    {
        anim.SetBool("Open", true);
    }

    private void OnTriggerExit(Collider Car)
    {
        anim.SetBool("Open", false);
    }
}
