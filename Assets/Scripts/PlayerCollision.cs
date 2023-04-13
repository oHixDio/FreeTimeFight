using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    const int right = 1;
    const int left = 0;

    int sidePointNumber = 1;
    public int SidePointNumber
    {
        get { return sidePointNumber; }
    }



    void OnTriggerEnter2D(Collider2D collision)
    {
        EndPoint e = collision.gameObject.transform.GetComponentInParent<EndPoint>();
        CurrentMap c = collision.gameObject.transform.GetComponentInParent<CurrentMap>();
        EnemySpawn s = collision.gameObject.transform.GetComponentInParent<EnemySpawn>();

        if (collision.gameObject.tag == "RightEndPoint")
        {
            e.SpawnPlayer(this.gameObject, right);
            c.MapFloorChange(e, right);
            s.EnemyFacing(right);
        }

        if(collision.gameObject.tag == "LeftEndPoint")
        {
            e.SpawnPlayer(this.gameObject, left);
            c.MapFloorChange(e, left);
            s.EnemyFacing(left);
        }
    }
}
