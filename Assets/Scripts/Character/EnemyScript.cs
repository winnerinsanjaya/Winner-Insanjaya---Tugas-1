using UnityEngine;

namespace ZombieTap.character
{
    public class EnemyScript : BaseCharacter
    {

        private int randomType;

        [SerializeField]
        private float randomZigZagTime, boundary, speedItm;

        private float rBound, lBound;

        public GameObject deathEfx;

        [SerializeField] GameObject childMove;

        [SerializeField]
        private bool isZigZag, zigzaged, isPlayerMovingRight;

        private Vector3 pos, axis;

        void Start()
        {
            starter();
        }
        void Update()
        {
            checkBorder();

            if (!isZigZag)
            {
                Move();
            }

            if (isZigZag)
            {
                MoveZigZag();
            }

            if (randomType > 1 && !isZigZag)
            {
                checkZigZag();
            }
        }

        public void Randomize()
        {

            randomType = Random.Range(1, 5);
            randomZigZagTime = Random.Range(-2.0f, 3.0f);
        }

        public void checkZigZag()
        {
            float currentY = gameObject.transform.position.y;
            if (currentY <= randomZigZagTime)
            {
                
                isZigZag = true;
            }
        }

        public void starter()
        {
            
            orSpeed(speedItm);

            rBound = transform.position.x + boundary;
            lBound = transform.position.x - boundary;
            isPlayerMovingRight = true;
            axis = transform.right;
            setEffect(deathEfx);
            SetSpeed();
            Randomize();
        }


        public void MoveZigZag()
        {
            transform.Translate(speedItm * Time.deltaTime * Vector2.down);


            if (transform.position.x > rBound)
                isPlayerMovingRight = false;
            if (transform.position.x < lBound)
                isPlayerMovingRight = true;

            if (isPlayerMovingRight == true)
            {
                transform.Translate(Vector2.right * Time.deltaTime * speedItm *2);
            }
            if (isPlayerMovingRight == false)
            {
                transform.Translate(Vector2.left * Time.deltaTime * speedItm *2);
            }

        }


    }
}