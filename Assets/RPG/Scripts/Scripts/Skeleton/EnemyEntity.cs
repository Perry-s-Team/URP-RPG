using UnityEngine;

public class EnemyEntity : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private int _damageToHim = 10;

    private int _curentHealth;

    private void Start()
    {
        _curentHealth = _maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Sword"))
        {
            TakeDamage(_damageToHim);
        }
    }

    public void TakeDamage(int damage)
    {
        _curentHealth -= damage;
        DetectDeath();
    }

    public void DetectDeath()
    {
        if (_curentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
