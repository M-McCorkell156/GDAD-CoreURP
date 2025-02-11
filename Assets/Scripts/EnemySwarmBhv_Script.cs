using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemySwarmBhv_Script : MonoBehaviour
{
    public GameObject playerObj;
    public NavMeshAgent agent;
    public Collider comfortZone;

    [SerializeField] private float checkTimeSecs; 
    [SerializeField] private GameObject ESTPrefab;

    [SerializeField] private string CfZnTagName;

    [SerializeField] private int groupCount;

    //private GameObject 

    private bool isComfort;

    private void Start()
    {
        groupCount = 0;
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
        //Debug.Log("Chek time ienum ");
        yield return new WaitForSeconds(checkTimeSecs);

        PreferredBehaviour();

        StartCoroutine(CheckTime());
        //Debug.Log("fin");
    }

    private void PreferredBehaviour()
    {
        //Debug.Log("Start PrefBhv");
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

        if (other.gameObject.tag == CfZnTagName)
        {
            Debug.Log("i got friend");
            groupCount++;
        }

        if (groupCount >= 1)
        {
            isComfort = true;
            Debug.Log("isCom true");
        }

        else
        {
            isComfort = false;
            Debug.Log("isCom false");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == CfZnTagName)
        {
            Debug.Log("bye friend");
            groupCount--;
        }
    }

}
