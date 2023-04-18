using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    const int right = 1;
    const int left = -1;

    int sidePointNumber = 1;
    public int SidePointNumber
    {
        get { return sidePointNumber; }
    }



    void OnTriggerEnter2D(Collider2D collision)
    {
        EndPoint end = collision.gameObject.transform.GetComponentInParent<EndPoint>();
        CurrentMap current = collision.gameObject.transform.GetComponentInParent<CurrentMap>();
        EnemySpawn spawn = collision.gameObject.transform.GetComponentInParent<EnemySpawn>();

        if (collision.gameObject.tag == "RightEndPoint")
        {
            end.SpawnPlayer(this.gameObject, right);
            current.MapFloorChange(end, right);
            spawn.SpawnControll(right);
        }

        if(collision.gameObject.tag == "LeftEndPoint")
        {
            end.SpawnPlayer(this.gameObject, left);
            current.MapFloorChange(end, left);
            spawn.SpawnControll(left);
        }
    }
}
