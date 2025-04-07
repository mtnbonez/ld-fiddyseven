using UnityEngine;

public class LavaStripsHandler : MonoBehaviour
{
    public float fallSpeed = 2.0f;
    public float riseSpeed = 0.5f;
    private bool hitRock = false;
    public GameObject canvas;
    public Rigidbody rb;

    private void Update()
    {
        rb.linearVelocity = Vector3.Lerp(rb.linearVelocity, Vector3.down * fallSpeed, Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("collided");
        if (collision.collider.tag == "pickaxe" && hitRock == false || collision.collider.tag == "unbreakable" && hitRock == false)
        {
            //hitRock = true;
            rb.linearVelocity = Vector3.Lerp(rb.linearVelocity, Vector3.up * riseSpeed, Time.deltaTime);
            Destroy(collision.gameObject);
        }
        if (collision.collider.tag == "playerCollision")
        {
            Player player = collision.collider.GetComponentInParent<Player>();
            player.SetPlayerDead( true );
            Time.timeScale = 0;
            canvas.SetActive(true);
        }
    }

}
