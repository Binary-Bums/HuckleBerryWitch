using UnityEngine;

public class Skeleton : Enemy {
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private float arrowSpeed = 2f;
    protected override void DetectPlayer()
    {
        if (nextAttackTime < Time.time)
            Attack();

    }

    private void Attack()
    {
        Vector3 shootDirection = (player.transform.position - transform.position).normalized;
        GameObject arrow = Instantiate(arrowPrefab, transform.position, Quaternion.identity);
        arrow.GetComponent<Arrow>().Initialize(damage, arrowSpeed, shootDirection);
        nextAttackTime = Time.time + attackCooldown;
    }

    
}