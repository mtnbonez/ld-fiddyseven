using UnityEngine;

public class Player : MonoBehaviour
{
    public float MovementSensitivity = 5f;
    public float CameraCatchupFactor = 1f;
    public float JumpMultiplier = 15f;
    public float initialJumpForce = 15f;
    public float maxJump = 15f;
    private Rigidbody _rb;
    private Camera _camera;
    private BoxCollider _cameraBoxCollider;
    private CharacterHandler _characterHandler;
    private CapsuleCollider _capsuleCollider;
    [SerializeField] private bool jumpKeyHeld = false;
    [SerializeField] private bool isJumping = false;
    private bool isSwinging = false;

    public AudioSource DougMmhmm;
    public float MmhmmSFXCooldown = 1.0f;
    private float nextMmhmmSFX;

    public AudioSource DougJump;
    public float JumpSFXCooldown = 1.0f;
    private float nextJumpSFX;

    public GameObject VisionCircle;
    public Transform ArtTransform;

    public bool IsJumping => isJumping || !_characterHandler.IsGrounded;
    public bool IsWalking => Input.GetAxisRaw("Horizontal") != 0;
    public bool IsFlipped => IsWalking && Input.GetAxisRaw("Horizontal") < 0;
    public bool IsIdle => !IsJumping;
    public bool IsSwinging => isSwinging;

    // player State for shop
    private GameObject currentShop;
    private bool isNearShop = false;
    private bool blockPlayerInput = false;
    private bool isDead = false;

    private Camera introCamera;

    public void Awake()
    {
        blockPlayerInput = true;
        isDead = false;

        _rb = this.GetComponentInChildren<Rigidbody>();
        _camera = this.GetComponentInChildren<Camera>();
        _cameraBoxCollider = _camera.GetComponent<BoxCollider>();
        _characterHandler = this.GetComponentInChildren<CharacterHandler>();
        _capsuleCollider = this.GetComponentInChildren<CapsuleCollider>();

        GameManager.Instance.RockVisionCircle = VisionCircle;
        GameManager.Instance.OriginalRockVisionCircleScale = VisionCircle.transform.localScale;

        GameManager.Instance.Character_Collider = _capsuleCollider;
        GameManager.Instance.Original_Character_Collider_Height = _capsuleCollider.height;

        GameManager.Instance.Art_Transform = ArtTransform;
        GameManager.Instance.Original_Art_Scale = ArtTransform.localScale;


        // Hacky af right now dont look at me
        GameObject logos = GameObject.Find( "Logos" );
        if (logos != null)
        {
            introCamera = logos.GetComponentInChildren<Camera>();
        }
    }

    // Update is called once per frame
    public void Update()
    {
        UpdatePlayerInputEnabled();
        HandleInput();
        UpdateCameraPosition();
    }

    public void UpdatePlayerInputEnabled()
    {
        if (!isDead && (introCamera == null || !introCamera.enabled))
        {
            blockPlayerInput = false;
        }
        else if (isDead || introCamera.enabled)
        {
            blockPlayerInput = true;
        }
    }

    public void SetCurrentShop( GameObject shop ){ currentShop = shop; }
    public GameObject GetCurrentShop() { return currentShop; }
    public void SetIsNearShop( bool nearShop ){ isNearShop = nearShop; }
    public bool IsNearShop(){ return isNearShop; }

    public bool GetBlockPlayerInput() { return blockPlayerInput; }
    public void BlockPlayerInput(bool shouldBlock ) { blockPlayerInput = shouldBlock; }
    public void SetPlayerDead(bool dead ) { isDead = dead; }

    private void FixedUpdate()
    {
        if (isJumping)
        {
            if (_rb.linearVelocity.y >= maxJump)
            {
                isJumping = false;
            }
            else
            {
                _rb.linearVelocity = new Vector3(0, _rb.linearVelocity.y + (JumpMultiplier * GameManager.Instance.GetJumpBuffMultiplier()), 0);
            }
        }
    }
    
    private void HandleInput()
    {
        if (blockPlayerInput)
        {
            return;
        }

        float moveInput = Input.GetAxisRaw("Horizontal");

        Vector3 moveDirection = new Vector3(moveInput, 0, 0);

        transform.position += moveDirection * MovementSensitivity * GameManager.Instance.GetSpeedBuffMultiplier() * Time.deltaTime;

        // Jump can ONLY be peformed if grounded
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("w"))
        {
            if(_characterHandler.IsGrounded && !jumpKeyHeld)
            {
                //Debug.Log("Player Jumped");
                isJumping = true;
                _rb.linearVelocity = new Vector3(0, _rb.linearVelocity.y + initialJumpForce, 0);

                if (Time.time > nextJumpSFX)
                {
                    DougJump.Play();
                    nextJumpSFX = Time.time + JumpSFXCooldown;
                }
            }

            jumpKeyHeld = true;
        }
        else if(Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp("w"))
        {
            jumpKeyHeld = false;
            isJumping = false;
        }

        if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
        {
            bool blockBroken = _characterHandler.TryBreakBlock();
            isSwinging = true;
        }
        else
        {
            isSwinging = false;
        }
    }
    
    private void UpdateCameraPosition()
    { 
        _camera.transform.position = Vector3.Lerp(_camera.transform.position, new Vector3(_rb.transform.position.x, _rb.transform.position.y, _camera.transform.position.z), Time.deltaTime * CameraCatchupFactor);
    }

    private Color GetRandomColorValue()
    {
        return new Color
        {
            r = UnityEngine.Random.Range(0.0f, 1.0f),
            g = UnityEngine.Random.Range(0.0f, 1.0f),
            b = UnityEngine.Random.Range(0.0f, 1.0f),
            a = UnityEngine.Random.Range(0.0f, 1.0f),
        };
    }

    public void PlayMmhmm()
    {
        if (Time.time > nextMmhmmSFX)
        {
            DougMmhmm.Play();
            nextMmhmmSFX = Time.time + MmhmmSFXCooldown;
        }
    }
}
