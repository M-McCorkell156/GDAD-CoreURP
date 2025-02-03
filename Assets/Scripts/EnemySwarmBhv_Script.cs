using NUnit.Framework;
using UnityEngine;
using UnityEngine.AI;

public class EnemySwarmBhv_Script : MonoBehaviour
{

   //public List<Transform> LiveEnemies;
    public GameObject playerObj;
    public NavMeshAgent agent;

    private bool alone;



    // Update is called once per frame
    void Update()
    {
        if (alone)
        {

        }
        else
        {
            transform.LookAt(playerObj.transform.position);
            agent.SetDestination(playerObj.transform.position);
        }

        transform.LookAt(playerObj.transform.position);
        agent.SetDestination(playerObj.transform.position);
    }
}
