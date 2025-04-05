using UnityEngine;

public class LavaWallHandler : MonoBehaviour
{
    public float fallSpeed = 1.0f;
    private Transform[] allWalls;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         allWalls = GetComponentsInChildren<Transform>();

        if (allWalls == null || allWalls.Length == 0)
        {
            Debug.LogError("No child transforms found!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Transform walls in allWalls)
        {
            if (walls != transform)
            {
                walls.position += Vector3.down * fallSpeed * Time.deltaTime;
            }
        }
    }

}
