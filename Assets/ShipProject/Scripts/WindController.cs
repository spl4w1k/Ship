using UnityEngine;

public class WindController : MonoBehaviour
{

    [SerializeField]
    private Vector3 _windDirection = new Vector3(0f, 0f, 1f);

    [SerializeField]
    private float _windStrength = 10f;

    public float WindStrength => _windStrength;
    public Vector3 WindDirection => _windDirection;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
