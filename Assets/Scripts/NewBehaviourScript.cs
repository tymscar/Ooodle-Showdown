using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour
{

    public float Max_wanderRadius;
    public float wanderRadius;
    public float wanderTimer;

    private Transform target;
    private NavMeshAgent agent;
    private float timer;


    public bool walk;
    Animator animatorr;

    // Use this for initialization
    void OnEnable()
    {
        walk = true;
        agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;
        wanderRadius = Max_wanderRadius;
    }

    // Update is called once per frame
    void Update()
    {
        if (walk) { 

            timer += Time.deltaTime;

            if (timer >= wanderTimer)
            {
                wanderRadius = Random.Range(0, Max_wanderRadius);
                wanderTimer = Random.Range(0, 5);
                Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
                agent.SetDestination(newPos);
                timer = 0;
            }
        }
 
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }
}