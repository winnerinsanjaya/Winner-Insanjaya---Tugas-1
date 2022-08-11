using UnityEngine;

namespace ZombieTap.character
{
    public class EnemyScript : BaseCharacter
    {

        private int randomType;
        private float randomZigZagTime;

        [SerializeField] Animator m_Animator;
        [SerializeField] GameObject childMove;

        void Start()
        {
            SetSpeed();
            Randomize();
            m_Animator = childMove.gameObject.GetComponent<Animator>();
        }
        void Update()
        {
            Move();
            checkBorder();


            if (randomType > 1)
            {
                ZigZag();
            }
        }

        public void Randomize()
        {

            randomType = Random.Range(1, 5);
            randomZigZagTime = Random.Range(1, 4);
        }

        public void ZigZag()
        {
            randomZigZagTime -= Time.deltaTime;
            if (randomZigZagTime <= 0)
            {
                m_Animator.SetBool("isZigZag", true);
            }
        }
    }
}