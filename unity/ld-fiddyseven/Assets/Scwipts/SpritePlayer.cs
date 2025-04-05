using UnityEngine;

public class SpritePlayer : MonoBehaviour
{

    [SerializeField] int Columns;
    [SerializeField] int Rows;
    [SerializeField] float FlipSpeed;
    [SerializeField] int IdleFrames;

    float CurrentFrame = 0;
    [SerializeField]  bool flipSprite;
    MeshRenderer SpriteMeshRenderer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpriteMeshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        CurrentFrame = (Time.fixedTime * FlipSpeed) % (IdleFrames - 1);

        SpriteMeshRenderer.sharedMaterial.SetFloat("_CurrentTile", CurrentFrame);

        if (flipSprite)
        {
            SpriteMeshRenderer.transform.Rotate(0.0f, 180.0f, 0.0f, Space.World);
            flipSprite = false;
        }

    }
}
