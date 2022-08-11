using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapManager : BaseCharacter
{
    public GameObject destroyEffect;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);


            if (hit.collider != null)
            {
                IClickable character = hit.collider.GetComponent<IClickable>();
                if (character != null)
                {
                    character.TakeDamage(gameObject);
                }
            }
        }
    }
}


