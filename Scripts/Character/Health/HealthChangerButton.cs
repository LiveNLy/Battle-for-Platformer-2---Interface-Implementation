using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public abstract class HealthChangerButton : MonoBehaviour
{
    [SerializeField] protected Health Health;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(ChangeParameter);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(ChangeParameter);
    }

    protected abstract void ChangeParameter();
}
