using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC_Controller : MonoBehaviour
{
    [Range(0, 100)]
    public float speed;
    private Vector3 moveDirection;
    private Rigidbody PC_RB;
    private BoxCollider PC_BC;
    // Start is called before the first frame update
    void Start()
    {
        PC_BC = gameObject.AddComponent<BoxCollider>();
        PC_RB = gameObject.AddComponent<Rigidbody>();
        PC_RB.constraints = RigidbodyConstraints.FreezeRotation;



    }

    // Update is called once per frame
    void Update()
    {
        Movement(speed, moveDirection);
    }

    void Movement(float speed, Vector3 direction)
    {
        float H = Input.GetAxis("Horizontal");
        float V = Input.GetAxis("Vertical");
        direction = (transform.forward * V + (transform.right * H)) * Time.deltaTime;
        direction = direction.normalized * speed;
        PC_RB.velocity = direction * speed;
    }
}
