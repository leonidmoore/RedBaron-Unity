using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerStatusText : MonoBehaviour
    {
        public Player TargetPlayer;

        public TMP_Text HpText;

        public void Update()
        {
            HpText.text = TargetPlayer.DamageReceiver.Health.ToString();
        }
    }
}