using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] GameObject player;
    [SerializeField] GameObject uiManager;

    // point�̃t�B�[���h�ݒ�
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






    


    // �E�̎��̏���
    // ���̎��̏���
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
    // �傫�������Ƃ��Ă���̂�

    // 0.�v���C���[��EndPoint�ɐG���

    // 1. �L�����N�^�[�̈ʒu�ړ� ���@MapChenger

    // if(rightOrLeft = 1)
    // {
    //     ������ł�
    // }
    // else�@if(rightOrLeft = 0)
    // {
    //     �E����ł�
    // }

    // 2. �G��Spawn������
    // 3. MapText��ω�������
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
