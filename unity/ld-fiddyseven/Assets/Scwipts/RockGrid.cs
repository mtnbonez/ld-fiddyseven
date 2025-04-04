using UnityEngine;

public class RockGrid : MonoBehaviour
{

    [SerializeField] GameObject rocks;
    [SerializeField] int xGridSize = 64;
    [SerializeField] int yGridSize = 64;
    [SerializeField] float spacing = 1f;

    public void OnEnable()
    {
        MakeRocks();
    }

    public void MakeRocks()
    {
        for (int x = 0; x < xGridSize; x++)
        {
            for (int y = 0; y < yGridSize; y++)
            {
                Vector3 position = new Vector3(x * spacing + transform.position.x, -y * spacing + transform.position.y, 0);
                Instantiate(rocks, position, Quaternion.identity, transform);
            }
        }
    }


}
