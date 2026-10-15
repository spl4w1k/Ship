using UnityEngine;

public class ShipController : MonoBehaviour
{


    
    private Vector3 _velocity = Vector3.zero;


    [SerializeField]
    [Min(0f)]
    private float _dragCoefficient = 0.2f;

    [SerializeField]
    private float _rotationSpeed = 10f;
    
    [SerializeField]
    private WindController _windController;

    [SerializeField]
    private SailController _sailController;

    [SerializeField]
    private SteeringWheelController _steeringWheelController;

    private void ShipMovement()
    {
        Vector3 windDirection = _windController.WindDirection.normalized;

        Vector3 sailDirection = _sailController.transform.forward;
        float sailAlignment = Vector3.Dot(sailDirection, windDirection);


        Vector3 sailForceDirection = sailDirection * sailAlignment;
        float forwardEfficiency = Vector3.Dot(sailForceDirection, transform.forward);

        float sailEfficiency = Mathf.Max(0f, forwardEfficiency);

        float strength = _windController.WindStrength;
        float openingFactor = _sailController.SailOpening / 100f;
        float windForce = openingFactor * strength * sailEfficiency;

        Vector3 acceleration = transform.forward * windForce;
        Vector3 dragAcceleration = -_dragCoefficient * _velocity;
        _velocity = _velocity + (acceleration + dragAcceleration) * Time.deltaTime;

        Vector3 movement = _velocity * Time.deltaTime;
        transform.position = transform.position + movement;
    }

    private void ShipRotation()
    {

        float speedFactor= _velocity.magnitude/10;
        float speed = Mathf.Clamp(speedFactor, 0, 1);
     

        float steringInput = _steeringWheelController.SteringInput;

        float angle = steringInput * _rotationSpeed * speed *Time.deltaTime;
        
        float radians = Mathf.Abs(angle * Mathf.Deg2Rad);
        transform.Rotate(0f, angle, 0f);

        Vector3 shipRotate = Vector3.RotateTowards(_velocity, transform.forward, radians, 0f);
        _velocity = shipRotate;
        Debug.Log(_velocity.magnitude);
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    
    }

    // Update is called once per frame
    void Update()
    {
       ShipRotation();
        ShipMovement();
    }
    
}
