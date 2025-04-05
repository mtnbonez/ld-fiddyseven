using System;
using UnityEngine;

    public class collisionHandler : MonoBehaviour
{
    [SerializeField] private float cooldown = 1.25f;
    private float timeStamp;
    private float raycastDistance = 7f;

    public void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > timeStamp)
        {
            
            //Debug.Log("mouse clicked");
            Vector3 mousePosition = Input.mousePosition;

            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePosition);

            //mouseWorldPos.z = 0;

            Ray ray = new Ray(transform.position, mouseWorldPos);

            
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, raycastDistance))
            {
                //Debug.Log("ROCKS HERE" + hit.collider.tag);
                if(hit.collider.tag == "pickaxe")
                {
                    Destroy(hit.collider.gameObject);
                }
            }

            Debug.DrawRay(ray.origin, ray.direction *raycastDistance, Color.yellow,2f);
            timeStamp = Time.time + cooldown;
        }
    }

    

}
