using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] GameObject player;
    [SerializeField] GameObject uiManager;

    // pointのフィールド設定
    [SerializeField] GameObject rightEndPoint;
    [SerializeField] GameObject leftEndPoint;
    [SerializeField] GameObject rightSpawnPoint;
    [SerializeField] GameObject leftSpawnPoint;
    [SerializeField] List<GameObject> enemySpawnList;

    [SerializeField] List<GameObject> enemyPrefab;


    PlayerCollision playerCollision;
    void Awake()
    {
        playerCollision = player.GetComponent<PlayerCollision>();
    }






    


    // 右の時の処理
    // 左の時の処理
    public void MapChange(int number)
    {

    }




    public void IsTriggerSwich(GameObject obj)
    {
        BoxCollider2D c = obj.GetComponent<BoxCollider2D>();
        if (true)
        {
            c.isTrigger = true;
        }
        else
        {
            c.isTrigger = false;
        }
    }

    /*
    // 大きく処理としてあるのが

    // 0.プレイヤーがEndPointに触れる

    // 1. キャラクターの位置移動 →　MapChenger

    // if(rightOrLeft = 1)
    // {
    //     左からでる
    // }
    // else　if(rightOrLeft = 0)
    // {
    //     右からでる
    // }

    // 2. 敵をSpawnさせる
    // 3. MapTextを変化させる
    // 4. 
    // 5. 
    // 6. 
    // 7. 
    // 8. 
    // 9. 
    // 10. 
    // 11. 
    */
}
