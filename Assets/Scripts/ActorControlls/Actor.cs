using Cainos.CustomizablePixelCharacter;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Actor : MonoBehaviour
{
    #region ---Field
    /// <summary>
    /// 変数まとまってるよ
    /// </summary>
    [Header("Status")]
    [SerializeField] Sprite faceIcon;
    [SerializeField] new string name = "";
    [SerializeField] int hp = 100;
    [SerializeField] int maxHp = 100;
    [SerializeField] int level = 1;
    [SerializeField] int pow = 5;
    [SerializeField] int def = 5;
    [SerializeField] int spd = 5;
    [SerializeField] int lck = 5;
    [SerializeField] int sumEXP = 0;
    [SerializeField] int nextExp = 10;
    [SerializeField] int gold = 0;

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

    [Header("Info")]
    [SerializeField] float maxMoveSpeed = 10f;
    [SerializeField] float attackDeleyAmount = 2f;


    // その他
    PixelCharacter pixcelCharactor;
    PlayerCollision playerCollision;
    float moveSpeed = 0f;
    float deleyTime = 0f;

    // set,getで使用する系
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
        set { besideEnemy = value; }
    }
    #endregion



    void Awake()
    {
        pixcelCharactor = GetComponent<PixelCharacter>();
        playerCollision = GetComponent<PlayerCollision>();
    }
    void Start()
    {
        SetPlayerUI();
        isMove = true;
    }
    void Update()
    {
        SetPlayerUI();
        ShowEnemyUI(playerCollision.Enemy);

        MovePlayer();

        if (besideEnemy)
        {
            Attack();
        }
    }

    
    
    

    #region ---PlayerUI Method
    private void SetPlayerUI()
    {
        faceImage_p.sprite = faceIcon;
        nameText_p.text = name;
        hpText_p.text = hp.ToString();
        maxHpText_p.text = maxHp.ToString();
        levelText_p.text = level.ToString();
        powText_p.text = pow.ToString();
        defText_p.text = def.ToString();
        spdText_p.text = spd.ToString();
        lckText_p.text = lck.ToString();
        seText_p.text = sumEXP.ToString();
        neText_p.text = nextExp.ToString();
        goldText_p.text = gold.ToString();

        if(this.hp <= 0)
        {
            this.hp = 0;
            Died();
        }
    }
    #endregion


    #region ---EnemyUI Method
    public void SetEnemyUI(Enemy enemy)
    {
        faceImage_e.sprite = enemy.GetFaceIcon();
        nameText_e.text = enemy.GetName();
        hpText_e.text = enemy.GetEnemyStatus("hp").ToString();
        maxHpText_e.text = enemy.GetEnemyStatus("maxHp").ToString();
        levelText_e.text = enemy.GetEnemyStatus("level").ToString();
        powText_e.text = enemy.GetEnemyStatus("pow").ToString();
        defText_e.text = enemy.GetEnemyStatus("def").ToString();
        spdText_e.text = enemy.GetEnemyStatus("spd").ToString();
        lckText_e.text = enemy.GetEnemyStatus("lck").ToString();

    }

    public void ShowEnemyUI(Enemy enemy)
    {
        
        if (playerCollision.Enemy != null)
        {
            SetEnemyUI(enemy);
            enemyUICanvas.SetActive(true);
        }
        else if (playerCollision.Enemy == null)
        {
            enemyUICanvas.SetActive(false);
        }
        
    }
    #endregion




    #region ---PlayerControlls Method
    void Attack()
    {

        deleyTime += Time.deltaTime;

        if (attackDeleyAmount < deleyTime)
        {
            pixcelCharactor.Attack();
            if(playerCollision.Enemy != null)
            {
                playerCollision.Enemy.Damage(this.pow);
            }
            deleyTime = 0;
        }
    }

    public void Damage(int pow)
    {
        this.hp -= pow;
    }

    void Died()
    {
        pixcelCharactor.IsDead = true;
        Destroy(this.gameObject,1f);
    }



    public void MovePlayer()
    {
        MoveSpeedBlender();
        if (!isRight && !isLeft || !isMove)
        {
            pixcelCharactor.MovingBlend = 0f;
        }

        if (isRight)
        {
            pixcelCharactor.Facing = (int)Mathf.Abs(moveSpeed / moveSpeed);
            if (!isMove) { return; }
            else if (isMove)
            {
                //this.gameObject.transform.position += new Vector3(moveSpeed*Time.deltaTime, 0,0);
                this.gameObject.transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
                pixcelCharactor.MovingBlend = Mathf.Clamp01(moveSpeed);
            }
        }
        else if (isLeft)
        {
            pixcelCharactor.Facing = -(int)Mathf.Abs(moveSpeed / moveSpeed);
            if (!isMove) { return; }
            else if (isMove)
            {

                this.gameObject.transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
                pixcelCharactor.MovingBlend = Mathf.Clamp01(moveSpeed);
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




    #endregion

    // ActorStatusを取得
    // MAPの数を取得＆更新

    // Enemyの場合
    // Level → level + MapCurrent
    // HP → HP + (MapCurrent + hpUpAmount)
    // POW → POW + MapCurrent
    // DEF → DEF + MapCurrent
    // SPD → SPD + MapCurrent
    // LCK → LCK + MapCurrent
    // Dead → DXP + NXP

    // Playerの場合
    // NXP → 
    // Level → NXP == 0
    // Levelup → StatusPoint + 10, NXP + (Level*100)
    // 
}
