using UnityEngine;

public class SpritePlayer : MonoBehaviour
{
    [SerializeField] float IdleFlipSpeed;
    [SerializeField] float JumpFlipSpeed;
    [SerializeField] float WalkFlipSpeed;
    [SerializeField] float SwingFlipSpeed;

    float CurrentFrame = 0;
    MeshRenderer SpriteMeshRenderer;

    public Player Player;
    private bool alreadyFlipped;

    private float nextFrameTimestamp;

    enum AnimState
    {
        Idle = 0, //0-7
        Walk = 1, //8-15
        Swing = 2, //16-23
        Jump = 3 //24-31
    }

    AnimState CurrentState = AnimState.Idle;


    private float NextFrame(AnimState state)
    {
        // Start on first frame
        if (CurrentState != state)
        {
            nextFrameTimestamp = 0;
            CurrentState = state;
            return (int)state * 8;
        }

        // Did we pass enough time to play another frame?
        if (Time.time > nextFrameTimestamp)
        {
            nextFrameTimestamp = Time.time + GetFlipSpeedFromState(state);
            var nextFrame = CurrentFrame + 1;

            // Loop the frame if we hit the end!
            if (nextFrame > (int)state * 8 + 7)
            {
                return (int)state * 8;
            }

            return nextFrame;
        }

        // If none of these, keep current frame
        return CurrentFrame;
    }   

    private float GetFlipSpeedFromState(AnimState state)
    {
        switch (state)
        {
            case AnimState.Idle:
                return IdleFlipSpeed;
            case AnimState.Walk:
                return WalkFlipSpeed;
            case AnimState.Swing:
                return SwingFlipSpeed;
            case AnimState.Jump:
                return JumpFlipSpeed;
            default:
                return 1.0f;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpriteMeshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: we should let the swing complete all the way?
        // Implied weighting list - jumping is most important
        if (Player.IsSwinging)
        {
            CurrentFrame = NextFrame(AnimState.Swing);
        }
        else if (Player.IsJumping)
        {
            CurrentFrame = NextFrame(AnimState.Jump);
        }
        else if (Player.IsWalking)
        {
            CurrentFrame = NextFrame(AnimState.Walk);
        }
        else // IsIdle
        {
            CurrentFrame = NextFrame(AnimState.Idle);
        }

        //Debug.Log("State = " + CurrentState.ToString() + " | frame = " + CurrentFrame + " @ " + Time.time);

        SpriteMeshRenderer.material.SetFloat("_CurrentTile", CurrentFrame);

        // Handle sprite flipping
        if (Player.IsFlipped && !alreadyFlipped)
        {
            flipSpriteMesh();
            alreadyFlipped = true;
        }
        else if (!Player.IsFlipped && alreadyFlipped && Player.IsWalking)
        {
            flipSpriteMesh();
            alreadyFlipped = false;
        }

    }


    void flipSpriteMesh()
    {
        SpriteMeshRenderer.transform.Rotate(0.0f, 180.0f, 0.0f, Space.World);
    }

}
