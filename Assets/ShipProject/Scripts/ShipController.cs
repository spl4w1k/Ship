using UnityEngine;

public class ShipController : MonoBehaviour
{


    
    private Vector3 _velocity = Vector3.zero;

    [SerializeField]
    [Min(0f)]
    private float _dragCoefficient = 0.2f;

    
    [SerializeField]
    private WindController _windController;

    [SerializeField]
    private SailController _sailController;

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
        Debug.Log(_velocity);


        Vector3 movement = _velocity * Time.deltaTime;
        transform.position = transform.position + movement;
    }




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    
    }

    // Update is called once per frame
    void Update()
    {
       
        ShipMovement();
    }
    
}
