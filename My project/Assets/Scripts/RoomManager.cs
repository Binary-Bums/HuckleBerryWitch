using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [SerializeField] private GameObject targetRoom;
    [SerializeField] private GameObject currentRoom;
    [SerializeField] private GameObject entrance;
    private GameObject player;

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")){
            SwitchRoom();
        }
    }

    private void SwitchRoom()
    {
        currentRoom.SetActive(false);
        targetRoom.SetActive(true);
        player.transform.position = entrance.transform.position;
    }
}
