using UnityEngine;

public class collisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("pickaxe"))
        {
            Destroy(this.gameObject);
        }
    }
}
