using UnityEngine;

public class Spell1Physics : Spell
{
    protected override void Effect(PlayerInfo playerInfo)
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        if (rb != null) rb.velocity = direction * speed;
    }
}
