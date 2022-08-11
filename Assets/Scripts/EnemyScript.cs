using UnityEngine;
public class EnemyScript : BaseCharacter
{

    private int randomType;
    private float randomZigZagTime;

    [SerializeField] Animator m_Animator;
    [SerializeField] GameObject childMove;

    void Start()
    {
        randomType = Random.Range(1, 5);
        randomZigZagTime = Random.Range(1, 4);

        m_Animator = childMove.gameObject.GetComponent<Animator>();
    }
    void Update()
    {

        Move();
        checkBorder();


        if (randomType > 1)
        {
            randomZigZagTime -= Time.deltaTime;
            if (randomZigZagTime <= 0)
            {
               m_Animator.SetBool("isZigZag", true);
            }
        }

    }
}
