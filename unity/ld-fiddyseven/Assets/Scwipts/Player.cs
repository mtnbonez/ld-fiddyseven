using UnityEngine;
using Unity.Mathematics;
using UnityEngine.Experimental.GlobalIllumination;
using Unity.VisualScripting;

public class Player : MonoBehaviour
{
    public float MovementSensitivity = 1f;
    public float CameraCatchupFactor = 1f;
    public Light lamp;
    private Rigidbody _rb;
    private Camera _camera;
    private BoxCollider _cameraBoxCollider;
   private bool isGrounded = true;

    public void Awake()
    {
        _rb = this.GetComponentInChildren<Rigidbody>();
        _camera = this.GetComponentInChildren<Camera>();
        _cameraBoxCollider = _camera.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    public void Update()
    {
        HandleKeyboard();
        HandleMouse();
        UpdateCameraPosition();
    }

    private void HandleKeyboard()
    {
        if (Input.GetKeyDown("w") && isGrounded)
        {
            //TODO: maybe linear interpolation?
            _rb.AddForce(Vector3.up * MovementSensitivity * 10);
            isGrounded = false;
        }

        if (Input.GetKeyDown("s") || Input.GetKey("s"))
        {
            //TODO: maybe linear interpolation?
            _rb.AddForce(Vector3.down * MovementSensitivity);
        }

        if (Input.GetKeyDown("a") || Input.GetKey("a"))
        {
            //TODO: maybe linear interpolation?
            _rb.AddForce(Vector3.left * MovementSensitivity);
        }

        if (Input.GetKeyDown("d") || Input.GetKey("d"))
        {
            //TODO: maybe linear interpolation?
            _rb.AddForce(Vector3.right * MovementSensitivity);
        }
    }

    private void HandleMouse()
    {
        if (Input.mouseScrollDelta.y != 0)
        {
            lamp.color = GetRandomColorValue();
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
    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
        //lol
    }
    //private void OnCollisionExit(Collision collision)
    //{
    //    isGrounded = false;
    //}
}
