using UnityEngine;

public class Weapon : MonoBehaviour
{
   // TODO: Object Pool
   [SerializeField] GameObject _bulletPrefab;
   
   Bullet _bullet;

   public void Attack(Vector3 direction)
   {
      _bullet = Instantiate(_bulletPrefab, transform.position, Quaternion.identity).GetComponent<Bullet>();
      // Debug.Log(direction);
      _bullet.StartFlying(direction);
   }
}
