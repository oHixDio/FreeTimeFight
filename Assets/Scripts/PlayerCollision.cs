using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    const int right = 1;
    const int left = -1;

    

    Actor actor = null;
    Enemy enemy = null;

    void Awake()
    {
        actor = GetComponent<Actor>();
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        EnterEndPoint(collision);
        EnterEnemy(collision);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        ExitEnemy(collision);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "MapEndPoint" || collision.gameObject.tag == "Enemy")
        {
            actor.IsMove = false;
        }
        if (collision.gameObject.tag == "Enemy")
        {
            actor.BesideEnemy = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "MapEndPoint" || collision.gameObject.tag == "Enemy")
        {
            actor.IsMove = true;
        }
        if (collision.gameObject.tag == "Enemy")
        {
            actor.BesideEnemy = false;
        }
    }

    void EnterEndPoint(Collider2D collision)
    {
        if (collision.tag != "RightEndPoint" && collision.tag != "LeftEndPoint") { return; }

        EndPoint end = collision.gameObject.transform.GetComponentInParent<EndPoint>();
        CurrentMap current = collision.gameObject.transform.GetComponentInParent<CurrentMap>();
        EnemySpawn spawn = collision.gameObject.transform.GetComponentInParent<EnemySpawn>();

        if (collision.tag == "RightEndPoint")
        {
            end.SpawnPlayer(this.gameObject, right);
            current.MapFloorChange(end, right);
            spawn.SpawnControll(right);
        }

        if (collision.tag == "LeftEndPoint")
        {
            end.SpawnPlayer(this.gameObject, left);
            current.MapFloorChange(end, left);
            spawn.SpawnControll(left);
        }

    }

    void EnterEnemy(Collider2D collision)
    {
        if (collision.tag != "Enemy") { return; }

        enemy = collision.gameObject.GetComponent<Enemy>();
        actor.ShowEnemyUI(enemy);
    }
    void ExitEnemy(Collider2D collision)
    {
        if (collision.tag != "Enemy") { return; }

        enemy = null;
        actor.HideEnemyUI();
    }
}
