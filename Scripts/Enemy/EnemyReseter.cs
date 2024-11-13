using UnityEngine;

public class EnemyReseter : MonoBehaviour
{
    [SerializeField] private EnemyHealth _enemyHealth;
    [SerializeField] private SmoothSlider _healthSlider;

    private void OnEnable()
    {
        _enemyHealth.LostHealth += ResetCharacter;
    }

    private void OnDisable()
    {
        _enemyHealth.LostHealth -= ResetCharacter;
    }

    private void ResetCharacter()
    {
        gameObject.SetActive(false);
        _healthSlider.gameObject.SetActive(false);
    }
}