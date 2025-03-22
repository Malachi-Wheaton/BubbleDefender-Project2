using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class IceTower : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private GameObject iceBulletPrefab;
    [SerializeField] private Transform firingPoint;

    [Header("Attributes")]
    [SerializeField] private float targetingRange = 5f;
    [SerializeField] private float BPS = 0.7f; 
    [SerializeField] private float freezeDuration = 2f; 

    private Transform target;
    private float timeUntilFire;

    private void Update()
    {
        if (target == null)
        {
            FindTarget();
            return;
        }

        if (!CheckTargetIsInRange())
        {
            target = null;
        }
        else
        {
            timeUntilFire += Time.deltaTime;

            if (timeUntilFire >= 1f / BPS)
            {
                Shoot();
                timeUntilFire = 0f;
            }
        }
    }

    private void Shoot()
    {
        GameObject bulletObj = Instantiate(iceBulletPrefab, firingPoint.position, Quaternion.identity);
        IceBullet bulletScript = bulletObj.GetComponent<IceBullet>();
        bulletScript.SetTarget(target);
        bulletScript.SetFreezeEffect(freezeDuration);
    }


    private void FindTarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetingRange, Vector2.zero, 0f, enemyMask);

        if (hits.Length > 0)
        {
            target = hits[0].transform;
        }
    }

    private bool CheckTargetIsInRange()
    {
        return Vector2.Distance(target.position, transform.position) <= targetingRange;
    }

    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.blue;
        Handles.DrawWireDisc(transform.position, transform.forward, targetingRange);
    }
}




