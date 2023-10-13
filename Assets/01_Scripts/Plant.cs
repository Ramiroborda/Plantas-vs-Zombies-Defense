using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Plant : MonoBehaviour
{
    public string towerName;
    public string towerDescription;
    public float buyPrice;
    public float sellPrice;

    //public float range;
    //public float dmg = 20;
    //public float timeShoot = 1;
    //public Enemy currentTarget;
    //public List<Enemy> currentTargets = new List<Enemy>();
    //public Transform rotationPart;

    void Start()
    {
        //StartCoroutine(ShootTime());
    }

    void Update()
    {
        //EnemyDetection();
    }
    //private void EnemyDetection()
    //{
    //    currentTargets = Physics.OverlapSphere(transform.position, range).Where(currentEnemy =>currentEnemy.GetComponent<Enemy>()).Select(currentEnemy=>currentEnemy.GetComponent<Enemy>()).ToList();
    //    if (currentTargets.Count > 0 )
    //    {
    //        currentTarget = currentTargets[0];
    //    }
    //    else if (currentTargets.Count == 0)
    //    {
    //        currentTarget = null;
    //    }

    //}

    //private void LookRotation()
    //{
    //    if (currentTarget)
    //    {
    //        rotationPart.LookAt(currentTarget.transform);
    //    }
    //}
    //public IEnumerator ShootTime()
    //{
    //    while (true)
    //    {
    //        if (currentTarget)
    //        {
    //            Shoot();
    //            yield return new WaitForSeconds(timeShoot);
    //        }
    //    }
    //}

    //private void Shoot()
    //{
    //    currentTarget.TakeDamage(dmg);
    //}

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(transform.position, range);
    //}
    
   
}
