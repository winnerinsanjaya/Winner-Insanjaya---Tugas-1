namespace ZombieTap.character
{
    public class HumanScript : BaseCharacter
    {
        void Start()
        {
            SetSpeed();
        }
        void Update()
        {
            Move();
            checkBorder();
        }
    }
}
