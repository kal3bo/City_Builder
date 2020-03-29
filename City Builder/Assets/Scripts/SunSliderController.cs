using UnityEngine;
using UnityEngine.UI;

public class SunSliderController : MonoBehaviour
{
    [SerializeField] private GameObject objectToRotate;
    [SerializeField] private Slider slider;

    // Preserve the original and current orientation
    private float previousValue;

    void Awake()
    {
        slider.onValueChanged.AddListener(OnSliderChanged);
        previousValue = slider.value;
    }

    /// <summary>
    /// Everytime the slider changes it's value
    /// the Directional Light will rotate.
    /// </summary>
    void OnSliderChanged(float value)
    {
        float delta = value - previousValue;
        objectToRotate.transform.Rotate(Vector3.right * delta * 180);
        previousValue = value;
    }
}