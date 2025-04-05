using UnityEngine;

public class LavaStripsHandler : MonoBehaviour
{   
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collided");
        if(collision.collider.tag == "pickaxe")
        {
            Destroy(gameObject);
        }
    }
}
