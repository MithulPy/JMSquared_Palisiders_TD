using UnityEngine;

public class Wave_Enemy : MonoBehaviour
{
    private Vector3 targetLocation;

    private float speed = 3f;

    private float deathTimer;

    private Wave_Manager manager;


    private void Start()
    {
        manager = FindObjectOfType<Wave_Manager>();
        targetLocation = GameObject.FindGameObjectWithTag("enemies").transform.position;
        deathTimer = 3f;
    }

    private void Update()
    {
        deathTimer -= Time.deltaTime;

        if (deathTimer <= 0f)
        {
            manager.EnemyDied();
            Destroy(gameObject);
        }

        transform.position = Vector3.MoveTowards(transform.position, targetLocation, speed * Time.deltaTime);
    }
}