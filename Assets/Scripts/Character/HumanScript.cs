using UnityEngine;

namespace ZombieTap.character
{
    public class HumanScript : BaseCharacter
    {
        [SerializeField]
        private float speedItm;
        void Start()
        {
            starter();
        }
        void Update()
        {
            Move();
            checkBorder();
        }

        public void starter()
        {
            SetSpeed();
            orSpeed(speedItm);
        }
    }
}
