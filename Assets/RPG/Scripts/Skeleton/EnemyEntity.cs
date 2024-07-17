using UnityEngine;

public class EnemyEntity : MonoBehaviour
{
    [SerializeField] private int _maxHealth; 

    private int _curentHealth;

    private void Start()
    {
        _curentHealth = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        _curentHealth -= damage;

        DetectDeath();
    }

    public void DetectDeath()
    {
        if(_curentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
