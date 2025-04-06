using System;
using UnityEngine;

public class CharacterHandler : MonoBehaviour
{
    [SerializeField] private float cooldown = 1.25f;
    private float timeStamp;
    private float nextMissSFX;
    private float raycastDistance = 26f;
    private float hitDistance = 3f;
    public bool IsGrounded = false;

    public AudioSource PickAxeHit;
    public AudioSource PickAxeMiss;
    public AudioSource DougMmhmm;
    public AudioSource DougJump;
    
    public float PickAxeMissCooldown = 1.0f;
    public GameObject rockBreak;
    public float rockBreakdur = .1f;
    public bool TryBreakBlock()
    {
        bool blockBroken = false;
        if (Time.time > timeStamp)
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

                    Destroy(rockBreakVFX, rockBreakdur);
                    blockBroken = true;
                }
                if(hit.collider.tag == "unbreakable" && hitDistance > maxDistance)
                {
                    PickAxeHit.Play();
                }
            }

            Debug.DrawRay(ray.origin, ray.direction * 26, Color.red, 2f);
            timeStamp = Time.time + cooldown;
        }

        // DO: This logic should move to Player (pukes)
        if (Time.time > nextMissSFX)
        {
            if (!blockBroken)
            {
                PickAxeMiss.Play();
            }
            nextMissSFX = Time.time + PickAxeMissCooldown;
        }

        return blockBroken;
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
