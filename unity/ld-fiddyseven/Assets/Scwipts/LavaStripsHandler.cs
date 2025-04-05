using System.Collections;
using UnityEngine;

public class LavaStripsHandler : MonoBehaviour
{
    public float fallSpeed = 1.0f;
    private bool hitRock = false;

    private void Update()
    {
        if (!hitRock)
        {
            fallSpeed = 2.0f;
        }
        else if (hitRock)
        {
            fallSpeed = 1f;

            StartCoroutine(speedChangeDelay(1f));
        }
            transform.position += Vector3.down * fallSpeed * Time.deltaTime;
    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collided");
        if (collision.collider.tag == "pickaxe" && hitRock == false)
        {
            hitRock = true;
        }
        if (hitRock)
        {

            Destroy(collision.gameObject);
            
        }


           
    }
    IEnumerator speedChangeDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        hitRock = false;
    }

}
