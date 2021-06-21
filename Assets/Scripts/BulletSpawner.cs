using System;
using UnityEngine;
using UnityEngine.Audio;

namespace DefaultNamespace
{
    public class BulletSpawner : MonoBehaviour
    {
        public Bullet BulletObject;
        public Transform SpawnTarget;
        public AudioSource shotSound;

        public Transform BulletRoot;

        public Action Shot { get; set; }
        
        public float RateOfFire = 0.5f;
        private float _rateOfFireTimer = 0f;
        
        public void Shoot(Player owner)
        {
            if (_rateOfFireTimer >= RateOfFire)
            {
                shotSound.Play();
                _rateOfFireTimer = 0f;

                var bullet = GameObject.Instantiate(BulletObject.gameObject, BulletRoot);

                bullet.transform.position = SpawnTarget.position;
                bullet.transform.rotation = SpawnTarget.rotation;

                bullet.GetComponent<Bullet>().OnShoot(owner);
                
                Shot?.Invoke();
            }
        }

        private void Update()
        {
            _rateOfFireTimer += Time.deltaTime;
        }
    }
}