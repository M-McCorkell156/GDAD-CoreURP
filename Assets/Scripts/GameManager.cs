using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private List<Transform> activeSpawnPos;
    [SerializeField] private int enemyCount;
    [SerializeField] private List<GameObject> allLiveEnemy;

    private void Start()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            int ranSpawnPos = UnityEngine.Random.Range(0, activeSpawnPos.Count);
            float ranSpawnDir = UnityEngine.Random.rotation.y;
            Quaternion quaternion = Quaternion.identity;
            quaternion.y = ranSpawnDir;

            Instantiate(enemyPrefab, activeSpawnPos[ranSpawnPos].position, quaternion);
            allLiveEnemy.Add(enemyPrefab);
        }

    }
}
