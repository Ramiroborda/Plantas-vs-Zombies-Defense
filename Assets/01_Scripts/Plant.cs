using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Plant : MonoBehaviour
{
    public string towerName;
    public string towerDescription;

    public PlantData currentData;
    
    public Enemy currentTarget;
    public List<Enemy> currentTargets = new List<Enemy>();
    public Transform rotationPart;

    
    public Transform shootPosition;
    //public GameObject shootEffect;
    public Bullet bullet;

    [Header("TowerUpgrade")]
    public List<PlantData> plantUpgradeData = new List<PlantData>();
    public int currentIndexUpgrade = 0;



    void Start()
    {
        StartCoroutine(ShootTime());
    }
    private void OnMouseDown()
    {
        TowerUIPanelManager.instance.OpenPanel(this);
    }

    void Update()
    {
        EnemyDetection();
        LookRotation();
    }
    private void EnemyDetection()
    {
        currentTargets = Physics.OverlapSphere(transform.position, currentData.range).Where(currentEnemy => currentEnemy.GetComponent<Enemy>()).Select(currentEnemy => currentEnemy.GetComponent<Enemy>()).Where(currentEnemy => !currentEnemy.isDead).ToList();
        if (currentTargets.Count > 0 && !currentTargets.Contains(currentTarget))
            currentTarget = currentTargets[0];
        else if (currentTargets.Count == 0)
            currentTarget = null;

    }

    private void LookRotation()
    {
        if (currentTarget)
        {
            rotationPart.LookAt(currentTarget.transform);
        }
    }
    public IEnumerator ShootTime()
    {
        while (true)
        {
            if (currentTarget)
            {
                Shoot();
                //shootEffect.SetActive(true);
                //StartCoroutine(DesactiveShootEffect());
                yield return new WaitForSeconds(currentData.timeShoot);
            }
            yield return null;
        }
    }

    //private IEnumerator DesactiveShootEffect()
    //{
    //    yield return new WaitForSeconds(0.12f);
    //shootEffect.SetActive(false);
    //}
    private void Shoot()
    {
        //currentTarget.TakeDamage(dmg);
        var bulletGo = Instantiate(bullet, shootPosition.position, shootPosition.rotation);
        bulletGo.SetBullet(currentTarget, currentData.dmg);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, currentData.range);
    }


}
