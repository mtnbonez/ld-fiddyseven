using System;
using UnityEngine;

public class CharacterHandler : MonoBehaviour
{
    [SerializeField] private float cooldown = 1.25f;
    private float timeStamp;
    private float raycastDistance = 26f;
    private float hitDistance = 3f;
    public bool IsGrounded = false;
    public AudioSource PickAxeHit;
    public GameObject rockBreak;
    public void Update()
    {
        if ((Input.GetMouseButtonDown(0) || Input.GetMouseButton(0)) && Time.time > timeStamp)
        {
            Vector3 mousePosition = Input.mousePosition;

            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            mouseWorldPosition.z = 0;

            Ray ray = Camera.main.ScreenPointToRay(mousePosition);            
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, raycastDistance))
            {
                float maxDistance = Vector3.Distance(transform.position, hit.point);

                //Debug.Log("ROCKS HERE" + hit.collider.tag);
                if(hit.collider.tag == "pickaxe" && hitDistance > maxDistance)
                {
                    // TODO: try to color the other rocks here?
                    /*
                    hit.collider.gameObject.TryGetComponent(out RockVision vision);
                    if (vision != null)
                    {

                    }
                    */
                    GameObject rockBreakVFX = Instantiate(rockBreak, hit.transform.position, Quaternion.identity);
                    Destroy(hit.collider.gameObject);
                    PickAxeHit.Play();
                }
            }

            Debug.DrawRay(ray.origin, ray.direction * 26, Color.red, 2f);
            timeStamp = Time.time + cooldown;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ground" || collision.collider.tag == "pickaxe")
        {
            IsGrounded = true;
        }

        if (collision.collider.tag == "Win")
        {
            // Win condition
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "Ground" || collision.collider.tag == "pickaxe")
        {
            IsGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Ground" || collision.collider.tag == "pickaxe")
        {
            IsGrounded = false;
        }
    }

}
