using System;
using UnityEngine;

namespace DefaultNamespace
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet: MonoBehaviour
    {
        public float MoveSpeed;
        public float Lifetime;
        public float Damage = 1f;

        private float _lifeTimeTimer;

        [NonSerialized]
        public Player Owner;

        public void OnShoot(Player owner)
        {
            Owner = owner;
            GetComponent<Rigidbody2D>().velocity = MoveSpeed * transform.right;
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            var border = other.gameObject.GetComponent<Border>();

            if (border != null)
            {
                Destroy(gameObject);
                return;
            }

            var damageReceiver = other.gameObject.GetComponent<DamageReceiver>();
            if (damageReceiver != null && damageReceiver.Player != Owner)
            {
                damageReceiver.ReceiveDamage(Damage, this);
                Destroy(gameObject);
                return;
            }
        }

        public void Update()
        {
            _lifeTimeTimer += Time.deltaTime;
            if (_lifeTimeTimer > Lifetime)
            {
                Destroy(gameObject);
            }
        }
    }
}