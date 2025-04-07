using UnityEngine;
using UnityEditor;

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

#if UNITY_EDITOR
    public void MakeRocksPrefab()
    {
        for (int y = 0; y < yGridSize; y++)
        {
            for (int x = 0; x < xGridSize; x++)
            {
                Vector3 position = new Vector3(x * spacing + transform.position.x, -y * spacing + transform.position.y, 0);
                //Instantiate(rocks, position, Quaternion.identity, transform);
                GameObject SpawnedRock = PrefabUtility.InstantiatePrefab(rocks) as GameObject;
                SpawnedRock.transform.position = position;
                SpawnedRock.transform.parent = transform;
            }
        }
    }
#endif



}
