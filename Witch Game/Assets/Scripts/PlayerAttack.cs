using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject spell1;
    [SerializeField] private float damageAmount = 30f;
    [SerializeField] private float attackRadius = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            GameObject spell = Instantiate(spell1, transform.position, Quaternion.identity);
            spell.GetComponent<Spell1Physics>().Spawn();
        }
    }
}
