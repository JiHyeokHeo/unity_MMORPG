using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollision : MonoBehaviour
{
    // 1) �� Ȥ�� ������� RigidBody �־�� �Ѵ� (isKinematic : Off)
    // 2) ����ü Collider�� �־�� �Ѵ� (isTrigger : Off)
    // 3) ������� Collider�� �־�� �Ѵ� (isTrigger : Off)
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Collision : {collision.gameObject.name}");
    }

    // 1) �� �� Collider�� �־�� �Ѵ�. 
    // 2) �� �� �ϳ��� isTrigger : On
    // 3) �� �� �ϳ��� RigidBody�� �־���Ѵ�.
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Trigger : {other.gameObject.name}");
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 look = transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(transform.position + Vector3.up, look * 10, Color.red);

        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position + Vector3.up, look, 10);

        foreach(RaycastHit hit in hits)
        {
            Debug.Log($"RayCast! {hit.collider.gameObject.name}");
        }

        //if(Physics.Raycast(transform.position + Vector3.up, look, out hit, 10))
        //{
        //    Debug.Log($"RayCast! {hit.collider.gameObject.name}");
        //}
    }
}
