using UnityEngine;
using UnityEngine.InputSystem;

public class SailController : MonoBehaviour
{
    //sail movement
    [SerializeField]
    [Range(0f,100f)]
    private float _sailOpening = 0f;

    [SerializeField]
    [Range(-45f, 45f)]
    private float _sailRotation = 0f;

    public float SailOpening => _sailOpening;
    public float SailRotation => _sailRotation;

    //input actions
    [SerializeField]
    private InputActionReference _rotateSailLeft;

    [SerializeField]
    private InputActionReference _rotateSailRight;

    [SerializeField]
    private InputActionReference _openSailAction;

    [SerializeField]
    private InputActionReference _closeSailAction;

    private void SailOpen()
    {
        if (_openSailAction.action.IsPressed())
        {
            _sailOpening = _sailOpening + 30f * Time.deltaTime;
        }

        if (_closeSailAction.action.IsPressed())
        {
            _sailOpening = _sailOpening - 30f * Time.deltaTime;
        }
        _sailOpening = Mathf.Clamp(_sailOpening, 0f, 100f);
    }

    private void SailRotate()
    {
        if (_rotateSailLeft.action.IsPressed())
        {
            _sailRotation = _sailRotation - 30f * Time.deltaTime;
        }
        if (_rotateSailRight.action.IsPressed())
        {
            _sailRotation = _sailRotation + 30f * Time.deltaTime;
        }
        _sailRotation = Mathf.Clamp(_sailRotation, -45f, 45f);

        transform.localRotation = Quaternion.Euler(0f, _sailRotation, 0f);

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SailOpen();
        SailRotate();
    }

    private void OnEnable()
    {
        _openSailAction.action.Enable();
        _closeSailAction.action.Enable();

        _rotateSailLeft.action.Enable();
        _rotateSailRight.action.Enable();

    }

    private void OnDisable()
    {
        _openSailAction.action.Disable();
        _closeSailAction.action.Disable();

        _rotateSailLeft.action.Disable();
        _rotateSailRight.action.Disable();

    }

}
