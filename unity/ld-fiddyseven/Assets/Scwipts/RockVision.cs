using UnityEngine;
using System.Collections;
using static UnityEditor.Searcher.SearcherWindow.Alignment;
using static UnityEngine.Rendering.DebugUI;

public class RockVision : MonoBehaviour
{

    [SerializeField] MeshFilter RockMesh;

    [SerializeField] float meltValue = 0;

    Color TargetColor = new(1, 0, 0, 0);

    void Start()
    {


    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Vision"))
        {
            print("Collided with vision");
            Vector3[] vertices = RockMesh.mesh.vertices;

            // create new colors array where the colors will be created.
            Color[] colors = new Color[vertices.Length];

            TargetColor.r = 0.0f;


            for (int i = 0; i < vertices.Length; i++)
                colors[i] = TargetColor;

            // assign the array of colors to the Mesh.
            RockMesh.mesh.colors = colors;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.collider.CompareTag("Vision") && TargetColor.r > 1f)
        {
            print("Starting to fade to " + TargetColor.r);
            StartCoroutine(UpdateRockColor(1, RockMesh));
        }

    }

    private IEnumerator UpdateRockColor(float waitTime, MeshFilter RockMesh)
    {

        Vector3[] vertices = RockMesh.mesh.vertices;

        // create new colors array where the colors will be created.
        Color[] colors = new Color[vertices.Length];


        for (int i = 0; i < vertices.Length; i++)
            colors[i] = TargetColor;

        // assign the array of colors to the Mesh.
        RockMesh.mesh.colors = colors;

        TargetColor.r = TargetColor.r + 0.1f;

        yield return new WaitForSeconds(waitTime);
    }
}
