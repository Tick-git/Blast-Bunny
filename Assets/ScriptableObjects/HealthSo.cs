using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu]
    public class HealthSo : ScriptableObject
    {
        [SerializeField] private int maxHealth;

        public int MaxHealth  { get => maxHealth; set => maxHealth = value; }
    }
}
