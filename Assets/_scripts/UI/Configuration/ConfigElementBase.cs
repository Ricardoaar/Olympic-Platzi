using UnityEngine;

public abstract class ConfigElementBase : MonoBehaviour
{
    [Tooltip("Corresponding configuration key for this UI element.")]
    [SerializeField] protected string configParameter;
}
