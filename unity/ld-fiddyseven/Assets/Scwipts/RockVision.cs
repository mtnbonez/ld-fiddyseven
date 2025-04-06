using UnityEngine;
using System.Collections;
using static UnityEditor.Searcher.SearcherWindow.Alignment;
using static UnityEngine.Rendering.DebugUI;

public enum BreakableType
{
    undefined,
    Rock_Normal,
    Rock_Hard,
    Rock_Unbreakable,
    Rock_Gold,
}

public class RockVision : MonoBehaviour
{

    [SerializeField] MeshFilter RockMesh;

    [SerializeField] float meltValue = 0;

    [SerializeField] public BreakableType breakableType;

    public GameObject _boundingBox;

    Color TargetColor = new(1, 0, 0, 0);

    /*
    private void OnTriggerStay(Collider other)
    {
        //PaintVision(other);
    }
    */

    private void OnTriggerEnter(Collider other)
    {
        PaintVision(other);
    }

    private void PaintVision(Collider other)
    {
        if (other.CompareTag("Vision"))
        {
            //Debug.Log("Collided with vision");
            Vector3[] vertices = RockMesh.mesh.vertices;

            // create new colors array where the colors will be created.
            Color[] colors = new Color[vertices.Length];

            TargetColor.r = 0.5f;

            for (int i = 0; i < vertices.Length; i++)
                colors[i] = TargetColor;

            // assign the array of colors to the Mesh.
            RockMesh.mesh.colors = colors;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Vision") && TargetColor.r < 1f)
        {
            //Debug.Log("Starting to fade to " + TargetColor.r);
            //StartCoroutine(UpdateRockColor(1, RockMesh));
        }

    }

    private IEnumerator UpdateRockColor(float waitTime, MeshFilter RockMesh)
    {

        Vector3[] vertices = RockMesh.mesh.vertices;

        // create new colors array where the colors will be created.
        Color[] colors = new Color[vertices.Length];
        
        while (TargetColor.r < 1f)
        {
            for (int i = 0; i < vertices.Length; i++)
                colors[i] = TargetColor;

            // assign the array of colors to the Mesh.
            RockMesh.mesh.colors = colors;

            TargetColor.r += 0.1f;

            yield return new WaitForSecondsRealtime(waitTime);
        }
    }
}
