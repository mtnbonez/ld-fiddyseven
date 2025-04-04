using UnityEngine;
using Unity.Mathematics;
using UnityEngine.Experimental.GlobalIllumination;

public class Player : MonoBehaviour
{
    public float MovementSensitivity = 1;
    public Light lamp;
    private Transform _selfTransform;

    public void Awake()
    {
        _selfTransform = transform;
    }

    // Update is called once per frame
    public void Update()
    {
        HandleKeyboard();
        HandleMouse();
    }

    private void HandleKeyboard()
    {
        if (Input.GetKeyDown("w") || Input.GetKey("w"))
        {
            //TODO: maybe linear interpolation?
            _selfTransform.Translate(Vector3.forward * MovementSensitivity);
        }

        if (Input.GetKeyDown("s") || Input.GetKey("s"))
        {
            //TODO: maybe linear interpolation?
            _selfTransform.Translate(Vector3.back * MovementSensitivity);
        }

        if (Input.GetKeyDown("a") || Input.GetKey("a"))
        {
            //TODO: maybe linear interpolation?
            _selfTransform.Translate(Vector3.left * MovementSensitivity);
        }

        if (Input.GetKeyDown("d") || Input.GetKey("d"))
        {
            //TODO: maybe linear interpolation?
            _selfTransform.Translate(Vector3.right * MovementSensitivity);
        }
    }

    private void HandleMouse()
    {
        if (Input.mouseScrollDelta.y != 0)
        {
            lamp.color = GetRandomColorValue();
        }
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

        //return UnityEngine.Random.Range(0.0f, 1.0f);
    }

}
