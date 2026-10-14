using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private SailController _sailController;

    [SerializeField]
    private UIData _uiData;

    private void Update()
    {
        _uiData.OpeningText = $"Sail Opening: {_sailController.SailOpening:F0}%";

        _uiData.RotationText = $"Sail Rotation: {_sailController.SailRotation:F0}°";
    }
}