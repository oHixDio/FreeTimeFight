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
    EndPoint end = null;
    CurrentMap current = null;
    EnemySpawn spawn = null;

    public Enemy Enemy
    {
        get { return enemy; }
    }

    void Awake()
    {
        actor = GetComponent<Actor>();
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        EnterEndPoint(collision);

        if(collision.gameObject.tag == "Enemy")
        {
            enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.CurrentStatus(current.GetMapFloorAmount());
        }
        if(collision.gameObject.tag == "Door") { actor.BesideDoor = true; }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy") { enemy = null; }
        
        if (collision.gameObject.tag == "Door") { actor.BesideDoor = false; }
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "MapEndPoint" || collision.gameObject.tag == "Enemy") 
        {
            actor.IsMove = false;
        }

        if (collision.gameObject.tag == "Enemy") { actor.BesideEnemy = true; }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "MapEndPoint" || collision.gameObject.tag == "Enemy")
        {
            actor.IsMove = true;
        }

        if (collision.gameObject.tag == "Enemy") { actor.BesideEnemy = false; }
    }

    void EnterEndPoint(Collider2D collision)
    {
        if (collision.tag != "RightEndPoint" && collision.tag != "LeftEndPoint") { return; }

        if(end == null)
        {
            end = collision.gameObject.transform.GetComponentInParent<EndPoint>();
            current = collision.gameObject.transform.GetComponentInParent<CurrentMap>();
            spawn = collision.gameObject.transform.GetComponentInParent<EnemySpawn>();
        }
        

        if (collision.tag == "RightEndPoint")
        {
            end.SpawnPlayer(this.gameObject, right);
            current.MapFloorChange(end, right);
            spawn.SpawnControll(right, current.GetMapFloorAmount());
        }

        if (collision.tag == "LeftEndPoint")
        {
            end.SpawnPlayer(this.gameObject, left);
            current.MapFloorChange(end, left);
            spawn.SpawnControll(left, current.GetMapFloorAmount());
        }

    }

    
}
