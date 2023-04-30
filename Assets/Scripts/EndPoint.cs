using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    [SerializeField] GameObject rightSpawnPoint;
    [SerializeField] GameObject leftSpawnPoint;

    [SerializeField] BoxCollider2D rightMapEndPointCollider;
    public BoxCollider2D RightMapEndPointCollider
    {
        get { return rightMapEndPointCollider; }
    }
    [SerializeField] BoxCollider2D leftMapEndPointCollider;
    public BoxCollider2D LeftMapEndPointCollider
    {
        get { return leftMapEndPointCollider; }
    }

    public void SpawnPlayer(GameObject player, int num)
    {
        if (num == 1)
        {
            player.transform.position = leftSpawnPoint.transform.position;
        }
        else if (num == -1)
        {
            player.transform.position = rightSpawnPoint.transform.position;
        }
    }






}
