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
    /// �ϐ��܂Ƃ܂��Ă��
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
    [SerializeField] int gold = 0;              //todo: �Z�\�l�ɂ���
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

    // ���̑�
    PixelCharacter pixcelCharactor;
    PlayerCollision playerCollision;
    float moveSpeed = 0f;
    float attackDeleyTime = 0f;
    int damageAmount = 0;
    int criticalDamage = 0;

    // set,get�Ŏg�p����n
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
    bool isDied = false;
    bool isDestroy = false;
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
        if (isDestroy) { return; }
        ShowEnemyUI(playerCollision.Enemy);

        MovePlayer();

        if (besideEnemy)
        {
            Attack();
        }
        if (isDied)
        {
            Died();
        }
    }

    
    
    

    #region ---PlayerStatus&UI Method
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

    public void LevelUp()
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

    public int DamageAmount(int otherDef)
    {
        // todo: damageAmount�Ƀ����_��������������
        // todo: ����U���͂����Z����
        this.damageAmount = (this.pow / 2 - otherDef / 4) * this.damageAdjust;
        int critical = Random.Range(0, this.lck + maxLck);

        if (critical > maxLck)
        {
            Debug.Log("�N���e�B�J���I�I");
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
    
    

    public int GetDefAmount()
    {
        return this.def;
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

        attackDeleyTime += Time.deltaTime;

        if (this.originDeleyAmount < attackDeleyTime)
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

    // damage�l ���@damageAmount  = ((this.pow / 2 - other.def / 4) + weaponPow) * damageAdjust
    // ��ɗ������~����
    // attackDeley�l �� attackDeley = originDeleyAmount - ((originDeleyAmount / maxSpd) * this.spd);
    
    //�U���Ԋu=100*(���̍U���Ԋu+�U���Ԋu�Z�kor����)��(100+(�U�����x����or�Z�k)
    // 0.3�`5�b�@�����l�T
    // ���l�ȏ㑁�������Animaion�����������Ȃ�̂Œ����K�{
}
