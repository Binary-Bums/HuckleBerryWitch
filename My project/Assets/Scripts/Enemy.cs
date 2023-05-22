using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Health {
        set{
            health = value;
            if(health<=0){
                Defeated(); 
            }
        }
        get{
            return health;
        }
    }

    private GameObject player;
    public float speed;
    private float distance;
    public float health = 1;
    System.Random rand = new System.Random();


    public void TakeDamage(float damage){
        health -= damage;
    }

    public void Defeated(){
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;


        
        if( distance < 1){
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);



         }else{
            int rint = 100;
             float temp1 = (rand.Next(1200000)-600000)%(500000);
             float temp2 = (rand.Next(1200000)-600000)%(500000);
             if(temp1 < 2 || temp2 < 2){
                 //transform.position.x += temp1;
                //transform.position.y += temp2;
                 transform.position = new Vector3((temp1/100000000) + transform.position.x, temp2/(100000000) + transform.position.y,2);
         }
        }
    }
}

