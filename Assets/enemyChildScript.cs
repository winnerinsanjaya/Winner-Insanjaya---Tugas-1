using UnityEngine;
public class enemyChildScript : BaseCharacter
{
    public GameObject deathEfx;

    void Start()
    {
        setEffect(deathEfx);
    }
}