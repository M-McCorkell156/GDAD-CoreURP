using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySwarmBhv_Script : MonoBehaviour
{
    public GameObject playerObj;
    public NavMeshAgent agent;
    public Collider comfortZone;

    [SerializeField] private float checkTimeSecs; 
    [SerializeField] private GameObject ESTPrefab;
    private string ESTPrefabName;
    [SerializeField] private int groupCount; 

    //private GameObject 

    public static HashSet<GameObject> allLiveEST

    private bool isComfort;

    private void Start()
    {
        Debug.Log("Begin");

        StartCoroutine(CheckTime());
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (alone)
        {
            //agent.SetDestination()
        }
        else
        {
            transform.LookAt(playerObj.transform.position);
            agent.SetDestination(playerObj.transform.position);
        }
        */
    }

    private IEnumerator CheckTime()
    {
        Debug.Log("Chek time ienum ");
        yield return new WaitForSeconds(checkTimeSecs);

        PreferredBehaviour();

        StartCoroutine(CheckTime());
        Debug.Log("Yield return ");
    }

    private void PreferredBehaviour()
    {
        Debug.Log("Start PrefBhv");
        if (isComfort) // If comfortable charge plyer
        {
            transform.LookAt(playerObj.transform.position);
            agent.SetDestination(playerObj.transform.position);
            Debug.Log("comfy");
        }
        else // not comf find friends 
        {
            Debug.Log("lone");          
        }
    }

    private void NearestEST()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("there collison");
        if (other.gameObject.name == ESTPrefabName)
        {
            Debug.Log("i got friend");
            groupCount++;
        }

        if (groupCount >= 5)
        {
            isComfort = true;
        }
        else
        {
            isComfort = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == ESTPrefabName)
        {
            Debug.Log("bye friend");
            groupCount--;
        }
    }

}
