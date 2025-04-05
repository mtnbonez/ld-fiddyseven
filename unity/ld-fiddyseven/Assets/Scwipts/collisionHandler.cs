using System;
using UnityEngine;

    public class collisionHandler : MonoBehaviour
{
    private float cooldown = .2f;

    public void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > cooldown)
        {
            
            //Debug.Log("mouse clicked");
            Vector3 mousePosition = Input.mousePosition;

            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePosition);

            mouseWorldPos.z = 0;

            Ray ray = Camera.main.ScreenPointToRay(mousePosition);

            
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                //Debug.Log("ROCKS HERE" + hit.collider.tag);
                if(hit.collider.tag == "pickaxe")
                {
                    Destroy(hit.collider.gameObject);
                }
            }


            cooldown = Time.time + cooldown;
        }
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.CompareTag("pickaxe"))
        //{
        //    Destroy(gameObject);
        //}
    }
}
