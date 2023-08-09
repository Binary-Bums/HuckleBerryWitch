using UnityEngine;

public class BeeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject bee;
    [SerializeField] private float spawnDistance = 5f;
    [SerializeField] private float spawnCooldown = 5f;

    private GameObject player;
    private float timer;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        timer = spawnCooldown;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnCooldown && Vector3.Distance(transform.position, player.transform.position) <= spawnDistance)
        {
            timer = 0;
            Instantiate(bee, transform.position, Quaternion.identity);

        }
    }
}
