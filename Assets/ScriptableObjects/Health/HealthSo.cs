using UnityEngine;

namespace ScriptableObjects.Health
{
    [CreateAssetMenu (fileName = "HealthSo", menuName = "ScriptableObjects/HealthSo")]
    public class HealthSo : ScriptableObject
    {
        [SerializeField] private int maxHealth;

        public int MaxHealth  { get => maxHealth; set => maxHealth = value; }
    }
}
