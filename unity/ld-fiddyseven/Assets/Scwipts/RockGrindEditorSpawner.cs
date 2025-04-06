using UnityEngine;

[ExecuteInEditMode]
public class RockGrindEditorSpawner : MonoBehaviour
{

    public bool RunRockGen; //"run" or "generate" for example


    void Update()
    {
        if (RunRockGen)
            GenerateRocks();
        RunRockGen = false;

    }

    void GenerateRocks()
    {
        if (GetComponent<RockGrid>())
        {
            GetComponent<RockGrid>().MakeRocksPrefab();
            Debug.Log("Ran Rock Gen");
        }
        else
        {
            Debug.LogWarning("No Rock Gen!");
        }
        
    }

}
