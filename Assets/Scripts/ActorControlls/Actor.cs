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
    /// ïœêîÇ‹Ç∆Ç‹Ç¡ÇƒÇÈÇÊ
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
    [SerializeField] int maxSpd = 500;
    [SerializeField] int lck = 5;
    [SerializeField] int maxLck = 500;
    [SerializeField] int sumEXP = 0;
    [SerializeField] int nextExp = 10;
    [SerializeField] int gold = 0;              //todo: ãZî\ílÇ…Ç∑ÇÈ
    [SerializeField] int statusAddPoint = 0;

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
    [SerializeField] Text statusAddPoint_p;
    [SerializeField] GameObject popupEventCanvas;

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
    [SerializeField] float originDeleyAmount = 5f;
    [SerializeField] int damageAdjust = 0;

    // ÇªÇÃëº
    PixelCharacter pixcelCharactor;
    PlayerCollision playerCollision;
    [SerializeField] GameObject uiManagerObj;
    UIManager uiManager;
    float moveSpeed = 0f;
    float attackDeley = 0;
    float attackDeleyTime = 0f;
    int damageAmount = 0;
    int criticalDamage = 0;

    // set,getÇ≈égópÇ∑ÇÈån
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
    bool besideDoor = false;
    public bool BesideDoor
    {
        set { besideDoor = value;}
    }
    bool isDied = false;
    bool isDestroy = false;
    #endregion



    void Awake()
    {
        pixcelCharactor = GetComponent<PixelCharacter>();
        playerCollision = GetComponent<PlayerCollision>();
        uiManager = uiManagerObj.GetComponent<UIManager>();
    }
    void Start()
    {
        //SetPlayerUI();
        isMove = true;
    }
    void Update()
    {
        //SetPlayerUI();

        if (isDied) { Died(); }

        if (isDestroy) { return; }

        //PopupEventUI();

        ShowEnemyUI(playerCollision.Enemy);

        MovePlayer();

        if (besideEnemy) { Attack(); }
    }

    
    
    

    #region ---PlayerStatus&UI Method
    void SetPlayerUI()
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
        statusAddPoint_p.text = statusAddPoint.ToString();

        if(this.hp <= 0)
        {
            this.hp = 0;
            isDied = true;
        }

        if (isDestroy)
        {
            enemyUICanvas.gameObject.SetActive(false);
        }


    }

    void PopupEventUI()
    {
        if (besideDoor)
        {
            popupEventCanvas.gameObject.SetActive(true);
        }
        else if (!besideDoor)
        {
            popupEventCanvas.gameObject.SetActive(false);
        }
    }

    public void CurrentPlayerEXP(int dropEXP)
    {
        sumEXP += dropEXP;
        for(int i = 0; i < dropEXP; i++)
        {
            this.nextExp -= dropEXP/dropEXP;
            if (nextExp == 0)
            {
                LevelUp();
            }
            
        }
        

    }
    void LevelUp()
    {
        Debug.Log("LevelUP!!");
        level++;
        nextExp += level * 10;
        statusAddPoint += 5;
    }

    public void UpStatus(string status)
    {
        if(statusAddPoint > 0)
        {
            switch (status)
            {
                case "pow":
                    this.pow++;
                    break;
                case "def":
                    this.def++;
                    break;
                case "spd":
                    this.spd++;
                    break;
                case "lck":
                    this.lck++;
                    break;
                case "hp":
                    this.hp += 5;
                    this.maxHp += 5;
                    break;
                case "gold":
                    this.gold += 5;
                    break;
            }
            statusAddPoint--;
        }
        
    }
    public void DownStatus(string status)
    {
        if(status == "pow" && this.pow > 5)
        {
            this.pow--;
            this.statusAddPoint++;
        }
        if (status == "def" && this.def > 5)
        {
            this.def--;
            this.statusAddPoint++;
        }
        if (status == "spd" && this.spd > 5)
        {
            this.spd--;
            this.statusAddPoint++;
        }
        if (status == "lck" && this.lck > 5)
        {
            this.lck--;
            this.statusAddPoint++;
        }
        if (status == "maxHp" && this.maxHp > 100)
        {
            this.maxHp -= 5;
            if(this.maxHp <= this.hp)
            {
                this.hp = this.maxHp;
            }
            this.statusAddPoint++;
        }
        if (status == "gold" && this.gold > 20)
        {
            maxHp -= 5;

            this.statusAddPoint++;
        }
    }

    int DamageAmount(int otherDef)
    {
        // todo: damageAmountÇ…ÉâÉìÉ_ÉÄê´ÇéùÇΩÇπÇÈ
        // todo: ïêäÌçUåÇóÕÇâ¡éZÇ∑ÇÈ
        this.damageAmount = (this.pow / 2 - otherDef / 4) * this.damageAdjust;
        int critical = Random.Range(0, this.lck + maxLck);

        if (critical > maxLck)
        {
            Debug.Log("ÉNÉäÉeÉBÉJÉãÅIÅI");
            return criticalDamage = damageAmount * 2;

        }
        if (damageAmount > 5)
        {
            return damageAmount;
        }
        else
        {
            return Random.Range(0, 6);
        }
    }
    float AttackDeleyAmount()
    {
        // attackDeleyèâä˙ílÇT
        attackDeley = originDeleyAmount - ((originDeleyAmount / maxSpd) * this.spd);
        return attackDeley;
    }


    public int GetDefAmount()
    {
        return this.def;
    }
    #endregion


    #region ---EnemyUI Method
    void SetEnemyUI(Enemy enemy)
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

    void ShowEnemyUI(Enemy enemy)
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

        attackDeleyTime += Time.deltaTime;

        if (AttackDeleyAmount() < attackDeleyTime)
        {
            pixcelCharactor.Attack();
            if(playerCollision.Enemy != null)
            {
                playerCollision.Enemy.Damage(DamageAmount(playerCollision.Enemy.GetEnemyStatus("def")));
            }
            attackDeleyTime = 0;
        }
    }

    public void Damage(int damageAmount)
    {
        
        
        Debug.Log(damageAmount);
        this.hp -= damageAmount;
    }

    void Died()
    {
        pixcelCharactor.IsDead = true;
        Destroy(this.gameObject,2f);
        isDestroy = true;
    }



    void MovePlayer()
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

    // damageíl Å®Å@damageAmount  = ((this.pow / 2 - other.def / 4) + weaponPow) * damageAdjust
    // èÌÇ…óêêîÇ™ó~ÇµÇ¢
    // attackDeleyíl Å® attackDeley = originDeleyAmount - ((originDeleyAmount / maxSpd) * this.spd);
    
    //çUåÇä‘äu=100*(å≥ÇÃçUåÇä‘äu+çUåÇä‘äuíZèkorâÑí∑)ÅÄ(100+(çUåÇë¨ìxëùâ¡oríZèk)
    // 0.3Å`5ïbÅ@èâä˙ílÇT
    // àÍíËílà»è„ëÅÇ≠Ç∑ÇÈÇ∆AnimaionÇ™Ç®Ç©ÇµÇ≠Ç»ÇÈÇÃÇ≈í≤êÆïKê{
}
