using UnityEngine;

public class Spell2Physics : Spell
{
    protected override void Effect(PlayerInfo playerInfo)
    {
        transform.position = direction + (Vector2)playerInfo.transform.position;
    }
}
