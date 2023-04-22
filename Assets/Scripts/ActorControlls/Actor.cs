using Cainos.CustomizablePixelCharacter;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Actor : MonoBehaviour
{
    [SerializeField] ActorStatus actorStatus;
    PixelCharacter pixcelCharactor;

    [Header("PlayerUI")]
    [SerializeField] Image faceImage_p;
    [SerializeField] Text hpText_p;
    [SerializeField] Text maxHpText_p;
    [SerializeField] Text nameText_p;
    [SerializeField] Text levelText_p;
    [SerializeField] Text powText_p;
    [SerializeField] Text defText_p;
    [SerializeField] Text spdText_p;
    [SerializeField] Text lckText_p;
    [SerializeField] Text seText_p;
    [SerializeField] Text neText_p;
    [SerializeField] Text goldText_p;

    [Header("EnemyUI")]
    [SerializeField] GameObject enemyUICanvas;
    [SerializeField] Image faceImage_e;
    [SerializeField] Text hpText_e;
    [SerializeField] Text maxHpText_e;
    [SerializeField] Text nameText_e;
    [SerializeField] Text levelText_e;
    [SerializeField] Text powText_e;
    [SerializeField] Text defText_e;
    [SerializeField] Text spdText_e;
    [SerializeField] Text lckText_e;

    float moveSpeed = 0f;
    [SerializeField] float maxMoveSpeed = 10f;

    bool isMove = false;
    public bool IsMove
    {
        set { isMove = value; }
    }
    bool isRight = false;
    public bool IsRight
    {
        set { isRight = value; }
    }
    bool isLeft = false;
    public bool IsLeft
    {
        set { isLeft = value; }
    }
    bool besideEnemy = false;
    public bool BesideEnemy
    {
        set { isLeft = value; }
    }

    void Awake()
    {
        pixcelCharactor = GetComponent<PixelCharacter>();
    }
    void Start()
    {
        ShowPlayerStatus();
        isMove = true;
    }
    void Update()
    {
        MovePlayer();  
    }

    #region ---PlayerUI Method
    private void ShowPlayerStatus()
    {
        actorStatus.ShowHP(hpText_p);
        actorStatus.ShowMaxHP(maxHpText_p);
        actorStatus.ShowImage(faceImage_p);
        actorStatus.ShowName(nameText_p);
        actorStatus.ShowLevel(levelText_p);
        actorStatus.ShowPOW(powText_p);
        actorStatus.ShowDEF(defText_p);
        actorStatus.ShowSPD(spdText_p);
        actorStatus.ShowLCK(lckText_p);
        actorStatus.ShowSumEXP(seText_p);
        actorStatus.ShowNextEXP(neText_p);
        actorStatus.ShowGold(goldText_p);
    }
    #endregion


    #region ---EnemyUI Method
    private void ShowEnemyStatus(Enemy enemy)
    {
        enemy.ActorStatus.ShowHP(hpText_e);
        enemy.ActorStatus.ShowMaxHP(maxHpText_e);
        enemy.ActorStatus.ShowImage(faceImage_e);
        enemy.ActorStatus.ShowName(nameText_e);
        enemy.ActorStatus.ShowLevel(levelText_e);
        enemy.ActorStatus.ShowPOW(powText_e);
        enemy.ActorStatus.ShowDEF(defText_e);
        enemy.ActorStatus.ShowSPD(spdText_e);
        enemy.ActorStatus.ShowLCK(lckText_e);
    }

    public void ShowEnemyUI(Enemy enemy)
    {
        enemyUICanvas.SetActive(true);
        ShowEnemyStatus(enemy);
    }
    public void HideEnemyUI()
    {
        enemyUICanvas.SetActive(false);
    }
    #endregion

    


    #region ---PlayerControlls Method
    public void Attack()
    {
        
        pixcelCharactor.Attack();
    }

    public void MovePlayer()
    {
        MoveSpeedBlender();
        if (isRight)
        {
            pixcelCharactor.Facing = (int)Mathf.Abs(moveSpeed / moveSpeed);
            if (!isMove) { return; }
            else if (isMove)
            {
                this.gameObject.transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
                pixcelCharactor.MovingBlend = Mathf.Clamp01(moveSpeed);
            }
        }
        else if (isLeft)
        {
            Debug.Log("AAA");
            pixcelCharactor.Facing = -(int)Mathf.Abs(moveSpeed / moveSpeed);
            if (!isMove) { return; }
            else if (isMove)
            {

                this.gameObject.transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
                pixcelCharactor.MovingBlend = Mathf.Clamp01(moveSpeed);
            }
        }
        
    }
    
    public void MoveSpeedBlender()
    {
        if (isRight || isLeft)
        {
            if (moveSpeed < maxMoveSpeed)
            {
                moveSpeed += maxMoveSpeed / 10f;
            }
            else if (moveSpeed >= maxMoveSpeed)
            {
                moveSpeed = maxMoveSpeed;
            }
        }
        else if (!isRight && !isLeft)
        {
            moveSpeed = 0f;
        }
    }

    


    #endregion

    // ActorStatusÇéÊìæ
    // MAPÇÃêîÇéÊìæÅïçXêV

    // EnemyÇÃèÍçá
    // Level Å® level + MapCurrent
    // HP Å® HP + (MapCurrent + hpUpAmount)
    // POW Å® POW + MapCurrent
    // DEF Å® DEF + MapCurrent
    // SPD Å® SPD + MapCurrent
    // LCK Å® LCK + MapCurrent
    // Dead Å® DXP + NXP

    // PlayerÇÃèÍçá
    // NXP Å® 
    // Level Å® NXP == 0
    // Levelup Å® StatusPoint + 10, NXP + (Level*100)
    // 
}
