using ScriptableObjects.Health;
using UnityEngine;
using UnityEngine.Events;

namespace HealthSystem
{
    public class Health : MonoBehaviour, IDamageable, IUnpierceable
    {
        [SerializeField] HealthSo healthSo;
        [SerializeField] UnityEvent onDeath;
        [SerializeField] UnityEvent<float> onHealthChanged;

        private float _currentHealth;

        private void Awake()
        {
            _currentHealth = healthSo.MaxHealth;
        }

        public void TakeDamage(float damage)
        {
            _currentHealth -= damage;
            
            onHealthChanged.Invoke(_currentHealth);
            
            if(_currentHealth <= 0)
            {
                onDeath.Invoke();
            }
            
            Debug.Log($"{gameObject.name} damaged {damage}!");
        }
    }
}