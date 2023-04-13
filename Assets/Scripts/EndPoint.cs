using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    [SerializeField] GameObject rightSpawnPoint;
    [SerializeField] GameObject leftSpawnPoint;

    [SerializeField] BoxCollider2D mapEndPointCollider;
    public BoxCollider2D MapEndPointCollider
    {
        get { return mapEndPointCollider; }
    }

    public void SpawnPlayer(GameObject player, int num)
    {
        if (num == 1)
        {
            player.transform.position = leftSpawnPoint.transform.position;
        }
        else if (num == 0)
        {
            player.transform.position = rightSpawnPoint.transform.position;
        }
    }
}
