using UnityEngine;

public class RoomManager : MonoBehaviour
{

    [SerializeField] private GameObject targetRoom;
    [SerializeField] private GameObject currentRoom;
    [SerializeField] private GameObject targetLocation;

    private Transform entranceTransform;
    private Transform playerTransform;

    private void Start()
    {
        entranceTransform = targetLocation.transform;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            SwitchRoom();
        }
    }

    private void SwitchRoom()
    {
        currentRoom.SetActive(false);
        targetRoom.SetActive(true);
         
        playerTransform.position = entranceTransform.position;
    }
}
