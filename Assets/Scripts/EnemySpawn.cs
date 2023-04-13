using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] List<GameObject> spawnPointList = new List<GameObject>();
    [SerializeField] List<GameObject> enemyPrefabList = new List<GameObject>();

    List<GameObject> randomSpawnPoint = new List<GameObject>();


    public void SpawnEnemy(int num)
    {
        if (num == 1)
        {
            Instantiate(enemyPrefabList[Random.Range(0, enemyPrefabList.Count)],
                        spawnPointList[Random.Range(0, 4)].transform.position,
                        Quaternion.identity);
        }
        else if (num == 0)
        {
            Instantiate(enemyPrefabList[Random.Range(0, enemyPrefabList.Count)],
                        spawnPointList[Random.Range(2, spawnPointList.Count)].transform.position,
                        Quaternion.identity);
        }
    }


    public void EnemyFacing(int num)
    {
        if(num == 1)
        { 
            foreach(GameObject e in enemyPrefabList)
            {
                e.transform.localScale = new Vector3(-1,0,0);
            }
        }
        else if(num == 0)
        {
            foreach (GameObject e in enemyPrefabList)
            {
                e.transform.localScale = new Vector3(1, 0, 0);
            }
        }
    }
    
    public void SetupSpawnPoint()
    {
        for(int i = 0; i < 5; i++)
        {
            randomSpawnPoint.Add(spawnPointList[i]);
        }

        int randomAmount = Random.Range(1, 6);
        int randomNum = Random.Range(0, 100);
        
        
        

        /*
         * 0����spawnPointList.Count����spawnPoint������܂� 
         * num=1�Ȃ�0����4
         * num=0�Ȃ�2����spawnPointList.Count
         * 1����5��A���̂Ȃ�SpawnPoint����Enemy�𐶐�����
         *
         *
         */


    }

}
