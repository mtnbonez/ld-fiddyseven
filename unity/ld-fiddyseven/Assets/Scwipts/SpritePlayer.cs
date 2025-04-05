using UnityEngine;

public class SpritePlayer : MonoBehaviour
{

    [SerializeField] int Columns;
    [SerializeField] int Rows;
    [SerializeField] float FlipSpeed;

    [SerializeField] int IdleFrames;
    [SerializeField] int WalkFrames;
    [SerializeField] int SwingFrames;
    [SerializeField] int JumpFrames;

    float CurrentFrame = 0;
    [SerializeField]  bool flipSprite;
    MeshRenderer SpriteMeshRenderer;
    enum AnimState
    {
        Idle = 0,
        Walk = 1,
        Jump = 2,
        Swing = 3
    }

    AnimState CurrentState = AnimState.Idle;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpriteMeshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (CurrentState)
        {
            case AnimState.Idle:
                CurrentFrame = (Time.fixedTime * FlipSpeed) % (IdleFrames - 1);
                break;
            case AnimState.Walk:
                CurrentFrame = (Time.fixedTime * FlipSpeed) % (WalkFrames - 1);
                break;
            case AnimState.Jump:
                CurrentFrame = (Time.fixedTime * FlipSpeed) % (SwingFrames - 1);
                break;
            case AnimState.Swing:
                CurrentFrame = (Time.fixedTime * FlipSpeed) % (JumpFrames - 1);
                break;
        }
        ;

        SpriteMeshRenderer.material.SetFloat("_CurrentTile", CurrentFrame);

        if (flipSprite)
        {
            flipSpriteMesh();
            flipSprite = false;
        }

    }


    void flipSpriteMesh()
    {
        SpriteMeshRenderer.transform.Rotate(0.0f, 180.0f, 0.0f, Space.World);
    }

}
