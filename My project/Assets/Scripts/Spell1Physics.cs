using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell1Physics : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
    private Vector2 move = new Vector2(0, 0);
    public float speed = .01f;
    public void Spawn()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        PlayerInfo playerScript = player.gameObject.GetComponent<PlayerInfo>();
        PlayerInfo.Direction direction = playerScript.direction;

        if (direction == PlayerInfo.Direction.Up)
        {
            move = new Vector2(0, speed);
        }
        else if (direction == PlayerInfo.Direction.Down)
        {
            move = new Vector2(0, -speed);
        }
        else if (direction == PlayerInfo.Direction.Left)
        {
            move = new Vector2(-speed, 0);
        }
        else if (direction == PlayerInfo.Direction.Right)
        {
            move = new Vector2(speed, 0);
        }
        Debug.Log(move);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + move.x, transform.position.y + move.y, transform.position.z);
        
    }
}
