using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollision : MonoBehaviour
{
    // 1) ������ RigidBody �־�� �Ѵ� (isKinematic : Off)
    // 2) ����ü Collider�� �־�� �Ѵ� (isTrigger : Off)
    // 3) ������� Collider�� �־�� �Ѵ� (isTrigger : Off)
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
