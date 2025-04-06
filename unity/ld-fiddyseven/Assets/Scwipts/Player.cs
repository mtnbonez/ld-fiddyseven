using UnityEngine;
using Unity.Mathematics;
using UnityEngine.Experimental.GlobalIllumination;
using Unity.VisualScripting;

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
    [SerializeField] private bool jumpKeyHeld = false;
    [SerializeField] private bool isJumping = false;
    private bool isSwinging = false;

    public bool IsJumping => isJumping || !_characterHandler.IsGrounded;
    public bool IsWalking => Input.GetAxisRaw("Horizontal") != 0;
    public bool IsFlipped => IsWalking && Input.GetAxisRaw("Horizontal") < 0;
    public bool IsIdle => !IsJumping;
    public bool IsSwinging => isSwinging;

    // player State for shop
    private GameObject currentShop;
    private bool isNearShop = false;

    public void Awake()
    {
        _rb = this.GetComponentInChildren<Rigidbody>();
        _camera = this.GetComponentInChildren<Camera>();
        _cameraBoxCollider = _camera.GetComponent<BoxCollider>();
        _characterHandler = this.GetComponentInChildren<CharacterHandler>();
    }

    // Update is called once per frame
    public void Update()
    {
        HandleInput();
        UpdateCameraPosition();
    }

    public void SetCurrentShop( GameObject shop ){ currentShop = shop; }
    public GameObject GetCurrentShop() { return currentShop; }
    public void SetIsNearShop( bool nearShop ){ isNearShop = nearShop; }
    public bool IsNearShop(){ return isNearShop; }

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
                _rb.linearVelocity = new Vector3(0, _rb.linearVelocity.y + JumpMultiplier, 0);
            }
        }
    }
    
    private void HandleInput()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");

        Vector3 moveDirection = new Vector3(moveInput, 0, 0);

        transform.position += moveDirection * MovementSensitivity * Time.deltaTime;

        // Jump can ONLY be peformed if grounded
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("w"))
        {
            if(_characterHandler.IsGrounded && !jumpKeyHeld)
            {
                //Debug.Log("Player Jumped");
                isJumping = true;
                _rb.linearVelocity = new Vector3(0, _rb.linearVelocity.y + initialJumpForce, 0);
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
}
