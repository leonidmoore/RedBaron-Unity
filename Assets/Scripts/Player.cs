using UnityEngine;

namespace DefaultNamespace
{
    public class Player : MonoBehaviour
    {
        public BulletSpawner BulletSpawner;

        public DamageReceiver DamageReceiver;

        public Animator TargetAnimator;

        public PlayerId PlayerId;

        public AudioSource explosionSound;
        
        public Score Score;

        public bool alive = true;
        

        public void Awake()
        {
            DamageReceiver.Death = OnDeath;
            BulletSpawner.Shot = OnShot;
        }

        private void OnShot()
        {
            TargetAnimator.SetTrigger("Shoot");
        }

        private void OnDeath(Bullet bullet)
        {
            if (alive == true)
            {
                TargetAnimator.SetBool("Dead", true);
                explosionSound.Play();
                alive = false;
                
                if (PlayerId == PlayerId.Player2) 
                {
                    GameObject.Find("ScoreManager").GetComponent<Score>().IncreaseScoreOnDestroy(); 
                }
                
                Game.Instance.Finish(bullet.Owner.PlayerId);
            }
        }

        public void Shoot()
        {
            BulletSpawner.Shoot(this);
        }
    }
}
