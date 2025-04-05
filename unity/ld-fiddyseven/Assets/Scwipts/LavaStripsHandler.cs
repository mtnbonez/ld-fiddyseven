using UnityEngine;

public class LavaStripsHandler : MonoBehaviour
{
    public float fallSpeed = 1.0f;
    private bool hitRock = false;

    private void Update()
    {
        transform.position += Vector3.down * fallSpeed * Time.deltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collided");
        if (collision.collider.tag == "pickaxe" && hitRock == false)
        {
            hitRock = true;
        }
        if (hitRock)
        {
            fallSpeed = .2f;
            Destroy(collision.gameObject);
            hitRock = false;
        }
    }

}
