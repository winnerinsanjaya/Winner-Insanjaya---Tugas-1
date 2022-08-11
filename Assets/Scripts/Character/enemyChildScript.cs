using UnityEngine;

namespace ZombieTap.character
{
    public class enemyChildScript : BaseCharacter
    {
        public GameObject deathEfx;

        void Start()
        {
            setEffect(deathEfx);
        }
    }
}