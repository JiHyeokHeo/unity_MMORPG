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
        // Local <-> World <-> (Viewport <-> Screen)( ȭ��) 

        //Debug.Log(Input.mousePosition); // ��ũ�� ��ǥ

        Debug.Log(Camera.main.ScreenToViewportPoint(Input.mousePosition)); // ����Ʈ
    }
}
