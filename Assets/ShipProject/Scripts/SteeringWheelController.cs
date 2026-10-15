using UnityEngine;
using UnityEngine.InputSystem;

public class SteeringWheelController : MonoBehaviour
{

    [SerializeField]
    private InputActionReference _rotateShipLeft;

    [SerializeField]
    private InputActionReference _rotateShipRight;

    private float _steringInput = 0;
    public float SteringInput => _steringInput;

    private void RotateShip()
    {
         if (_rotateShipRight.action.IsPressed() && _rotateShipLeft.action.IsPressed())
        {
            _steringInput = 0;
        }

        else if (_rotateShipLeft.action.IsPressed())
        {

            _steringInput = -1;


        }

        else if (_rotateShipRight.action.IsPressed())
        {

            _steringInput = 1;
        }

        else _steringInput = 0;

       

    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotateShip();

    }

    private void OnEnable()
    {
        _rotateShipLeft.action.Enable();
        _rotateShipRight.action.Enable();


    }

    private void OnDisable()
    {
        _rotateShipLeft.action.Disable();
        _rotateShipRight.action.Disable();


    }
}
