using UnityEngine;
using Unity.Properties;
    
[CreateAssetMenu(fileName = "UIData", menuName = "Scriptable Objects/UIData")]
public class UIData : ScriptableObject
{

    [CreateProperty]
    public string OpeningText = "Sail Opening: 0%";

    [CreateProperty]
    public string RotationText = "Sail Rotation: 0%";
}
