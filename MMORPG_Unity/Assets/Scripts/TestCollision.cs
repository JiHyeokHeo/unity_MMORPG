using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollision : MonoBehaviour
{
    // 1) 나 혹은 상대한테 RigidBody 있어야 한다 (isKinematic : Off)
    // 2) 나한체 Collider가 있어야 한다 (isTrigger : Off)
    // 3) 상대한테 Collider가 있어야 한다 (isTrigger : Off)
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Collision : {collision.gameObject.name}");
    }

    // 1) 둘 다 Collider가 있어야 한다. 
    // 2) 둘 중 하나는 isTrigger : On
    // 3) 둘 중 하나는 RigidBody가 있어야한다.
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
        // Local <-> World <-> (Viewport <-> Screen)( 화면) 

        //Debug.Log(Input.mousePosition); // 스크린 좌표

        Debug.Log(Camera.main.ScreenToViewportPoint(Input.mousePosition)); // 뷰포트
    }
}
