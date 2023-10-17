using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [Header("Movement")]
    public List<Transform>waypoints = new List<Transform> ();
    private int targetIndex = 1;
    public float movementSpeed = 4;
    public float rotationSpeed = 6;
    private Animator animator;
    [Header("Life")]
    public bool isDead;
    public float maxLife = 100;
    public float currentLife=0;
    public Image fillLifeImage;
    private Transform canvasRoot;
    private Quaternion initLifeRotation;

    [Header("OnDead")]
    public int moneyOnDead = 10;

    public int damage;
    public GameObject House;





    public void Awake()
    {
        canvasRoot = fillLifeImage.transform.parent.parent;
        initLifeRotation = canvasRoot.rotation;
        animator = GetComponent<Animator> ();
        animator.SetBool("Movement", true);
        GetWayPoints();
    }
    // Start is called before the first frame update
    void Start()
    {
        currentLife = maxLife;
        
    }
    
    public void GetWayPoints()
    {
        waypoints .Clear ();
        var rootWayPoints = GameObject.Find("WaypointsContainer").transform;
        for (int i = 0; i < rootWayPoints.childCount; i++)
        {
            waypoints.Add(rootWayPoints.GetChild(i));
        }
    }

    // Update is called once per frame
    void Update()
    {
        canvasRoot.transform.rotation = initLifeRotation;
        Movement();
        LookAt();
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            TakeDamage(10);
        }
        
    }
    private void Movement()
    {
        if (isDead)
        {
            return;
        }
        transform.position = Vector3.MoveTowards(transform.position, waypoints[targetIndex].position, movementSpeed * Time.deltaTime);
        var distance = Vector3.Distance(transform.position, waypoints[targetIndex].position);
        if (distance <= 0.1f) 
        {
            if (targetIndex >= waypoints.Count-1)
            {
                Debug.Log("Subir Target Index");
                return;
            }
            targetIndex++;
        }
    }
    private void LookAt() 
    {
        if (isDead)
        {
            return;
        }
        transform.LookAt(waypoints[targetIndex]);
        var dir = waypoints[targetIndex].position - transform.position; 
        var rootTarget = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Slerp(transform.rotation,rootTarget, rotationSpeed * Time.deltaTime);
    }

    public void TakeDamage(float dmg)
    {
         var newLife = currentLife -dmg;
        if (isDead)
            return;
        
        if (newLife <=0)
        {
            OnDead();
        }
        currentLife = newLife;
        var fillValue = currentLife * 1 / 100;
        fillLifeImage.fillAmount = fillValue;
        currentLife = newLife;
        StartCoroutine(AnimationDamage());
        ;
    }
    private IEnumerator AnimationDamage()
    {
        animator.SetBool("TakeDamage", true);
        yield return new WaitForSeconds(0.1f);
        animator.SetBool("TakeDamage", false);

    }
    private void OnDead()
    {
        isDead = true;
        animator.SetBool("TakeDamage", false);
        animator.SetBool("Die", true);
        currentLife = 0;
        fillLifeImage.fillAmount = 0;
        StartCoroutine (OnDeadEffect());
        PlayerData.instance.AddMoney(moneyOnDead);
    }
    private IEnumerator OnDeadEffect()
    {
        yield return new WaitForSeconds(1f);
        var finalPositionY = transform.position.y - 5;
        Vector3 target = new Vector3(transform.position.x, finalPositionY, transform.position.z);
        while (transform.position.y != finalPositionY)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, 1.5f * Time.deltaTime);
            yield return null;
        }
        Destroy(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag =="House")
        {
            House.GetComponent<LifeHouse>().lifeHouse -= damage;
        }
        if (other.tag == "Zombie")
        {
            Debug.Log("Esto es un enemigo");
        }
        if (other.tag == "ZombieSmall")
        {
            Debug.Log("Esto es un enemigo");
        }
    }




}
