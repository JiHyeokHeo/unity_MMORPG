using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollision : MonoBehaviour
{
    // 1) 나한테 RigidBody 있어야 한다 (isKinematic : Off)
    // 2) 나한체 Collider가 있어야 한다 (isTrigger : Off)
    // 3) 상대한테 Collider가 있어야 한다 (isTrigger : Off)
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Col");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger");
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
