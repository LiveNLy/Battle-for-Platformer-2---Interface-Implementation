using UnityEngine;

public class MedKit : MonoBehaviour
{
    [SerializeField] private float _healAmount = 60;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out CollisionHandler collisionHandler))
        {
            gameObject.SetActive(false);
        }
    }

    public float HealingChar()
    {
        return _healAmount;
    }
}