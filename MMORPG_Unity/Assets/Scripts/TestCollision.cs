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

        //Debug.Log(Camera.main.ScreenToViewportPoint(Input.mousePosition)); // 뷰포트

        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
           
            Debug.DrawRay(Camera.main.transform.position, ray.direction * 100.0f, Color.red, 1.0f);

            // 비트 연산자 (유니티 편하게 만들어 놓은 방법)
            LayerMask mask = LayerMask.GetMask("Monster") | LayerMask.GetMask("Wall");

            // 비트 연산자
            //int mask = (1 << 6) | (1 << 7);

            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 100.0f, mask))
            {
                Debug.Log($"Raycast Camera @ {hit.collider.gameObject.name}");
            }
        }

        //if (Input.GetMouseButtonDown(0))
        //{
        //    Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
        //    Vector3 dir = mouseWorldPos - Camera.main.transform.position;
        //    dir = dir.normalized;

        //    Debug.DrawRay(Camera.main.transform.position, dir * 100.0f, Color.red, 1.0f);

        //    RaycastHit hit;

        //    if (Physics.Raycast(Camera.main.transform.position, dir, out hit, 100.0f))
        //    {
        //        Debug.Log($"Raycast Camera @ {hit.collider.gameObject.name}");
        //    }
        //}

    }
}
