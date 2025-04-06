using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class LavaStripsHandler : MonoBehaviour
{
    public float fallSpeed = 1.0f;
    private bool hitRock = false;
    public GameObject canvas;

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
        //Debug.Log("collided");
        if (collision.collider.tag == "pickaxe" && hitRock == false)
        {
            hitRock = true;
            Destroy(collision.gameObject);
        }
        if (collision.collider.tag == "Player")
        {
            Time.timeScale = 0;
            canvas.SetActive(true);
        }
    }

    IEnumerator speedChangeDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        hitRock = false;
    }

}
