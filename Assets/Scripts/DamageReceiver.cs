using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class DamageReceiver : MonoBehaviour
    {
        public float Health;

        public Player Player;

        public Action<Bullet> Death;

        public AudioSource bulletHit;

        public Score Score;

        public void ReceiveDamage(float damage, Bullet bullet)
        {
            if (Player.PlayerId == PlayerId.Player2) { GameObject.Find("ScoreManager").GetComponent<Score>().IncreaseScoreOnHit(); }
            Health -= damage;
            bulletHit.Play();
            if (Health <= 0)
            {
                Death?.Invoke(bullet);
            }
        }
    }
}
