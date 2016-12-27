using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour 
{
    public float damage;

    public void OnTriggerEnter(Collider collidedObject)
    {
        Enemy enemy = collidedObject.gameObject.GetComponent<Enemy>();
        if(enemy != null)
        {
            enemy.ReceiveDamage(damage);
        }
        GameObject.Destroy(this.gameObject);
    }
}
