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

        //Debug.Log(Camera.main.ScreenToViewportPoint(Input.mousePosition)); // ����Ʈ

        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
           
            Debug.DrawRay(Camera.main.transform.position, ray.direction * 100.0f, Color.red, 1.0f);

            // ��Ʈ ������ (����Ƽ ���ϰ� ����� ���� ���)
            LayerMask mask = LayerMask.GetMask("Monster") | LayerMask.GetMask("Wall");

            // ��Ʈ ������
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
