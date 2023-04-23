using Cainos.CustomizablePixelCharacter;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player : Actores
{
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

    [Header("Runtime")]
    [SerializeField] float maxMoveSpeed = 10f;
    float moveSpeed = 0f;

    PixelCharacter pixelCharacter;

    void Awake()
    {
        pixelCharacter = GetComponent<PixelCharacter>();
    }
    void Start()
    {
        SetStatus();
        ShowPlayerUI();
        isMove = true;
    }
    void Update()
    {
        MovePlayer();

        if (besideActor)
        {
            Attack(pixelCharacter);
        }
    }


    void ShowPlayerUI()
    {
        ActorStatus.ShowHP(hpText_p);
        ActorStatus.ShowMaxHP(maxHpText_p);
        ActorStatus.ShowImage(faceImage_p);
        ActorStatus.ShowName(nameText_p);
        ActorStatus.ShowLevel(levelText_p);
        ActorStatus.ShowPOW(powText_p);
        ActorStatus.ShowDEF(defText_p);
        ActorStatus.ShowSPD(spdText_p);
        ActorStatus.ShowLCK(lckText_p);
        ActorStatus.ShowSumEXP(seText_p);
        ActorStatus.ShowNextEXP(neText_p);
        ActorStatus.ShowGold(goldText_p);
    }
    void ShowEnemyStatus(Enemies enemies)
    {
        enemies.ActorStatus.ShowHP(hpText_e);
        enemies.ActorStatus.ShowMaxHP(maxHpText_e);
        enemies.ActorStatus.ShowImage(faceImage_e);
        enemies.ActorStatus.ShowName(nameText_e);
        enemies.ActorStatus.ShowLevel(levelText_e);
        enemies.ActorStatus.ShowPOW(powText_e);
        enemies.ActorStatus.ShowDEF(defText_e);
        enemies.ActorStatus.ShowSPD(spdText_e);
        enemies.ActorStatus.ShowLCK(lckText_e);
    }
    public void ShowEnemyUI(Enemies enemies)
    {

        enemyUICanvas.SetActive(true);
        ShowEnemyStatus(enemies);
    }
    public void HideEnemyUI()
    {
        enemyUICanvas.SetActive(false);
    }
    #region ----ActorUI Methods
    /*
    void ShowPlayerUI()
    {
        faceImage_e.sprite = faceIcon;
        hpText_p.text = hp.ToString();
        maxHpText_p.text = maxHp.ToString();
        nameText_p.text = name.ToString();
        levelText_p.text = level.ToString();
        powText_p.text = pow.ToString();
        defText_p.text = def.ToString();
        spdText_p.text = spd.ToString();
        lckText_p.text = lck.ToString();
        seText_p.text = sumEXP.ToString();
        neText_p.text = nextEXP.ToString();
        goldText_p.text = gold.ToString();
    }
    */

    #endregion








    public void MovePlayer()
    {
        MoveSpeedBlender();
        if (!isRight && !isLeft || !isMove)
        {
            pixelCharacter.MovingBlend = 0f;
        }

        if (isRight)
        {
            pixelCharacter.Facing = (int)Mathf.Abs(this.moveSpeed / this.moveSpeed);
            if (!isMove) { return; }
            else if (isMove)
            {
                //this.gameObject.transform.position += new Vector3(moveSpeed*Time.deltaTime, 0,0);
                this.gameObject.transform.Translate(this.moveSpeed * Time.deltaTime, 0, 0);
                pixelCharacter.MovingBlend = Mathf.Clamp01(this.moveSpeed);
            }
        }
        else if (isLeft)
        {
            pixelCharacter.Facing = -(int)Mathf.Abs(this.moveSpeed / this.moveSpeed);
            if (!isMove) { return; }
            else if (isMove)
            {

                this.gameObject.transform.Translate(-this.moveSpeed * Time.deltaTime, 0, 0);
                pixelCharacter.MovingBlend = Mathf.Clamp01(this.moveSpeed);
            }
        }



    }

    void MoveSpeedBlender()
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


}
