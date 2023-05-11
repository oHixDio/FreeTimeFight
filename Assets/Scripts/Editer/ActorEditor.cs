using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ActorEditor : MonoBehaviour
{
    /*
    #region ---Field

    [Header("Status")]
    [SerializeField] Sprite faceIcon;
    new string name = "�䂤����";
    [SerializeField] int hp = 100;
    int level = 1;
    [SerializeField] int pow = 5;
    int spd = 5;
    int def = 5;
    int lck = 5;
    int skl = 20;


    int slimeKillAmount = 0;
    int bossKillAmount = 0;

    // maxAmount
    int maxLevel = 1250;
    int currentHp = 100;
    int maxHp = 2000;
    int maxPow = 250;  // �U���͂ɉe��
    int maxDef = 250;  // �h��͂ɉe��
    int maxSpd = 250;  // �U�����x�ɉe��
    int maxLck = 250;  // �N���e�B�J�����ɉe��
    int maxskl = 1250; // �Z�\�l�ɉe��

    // otherAmount
    int sumEXP = 0;
    int nextExp = 10;
    int statusAddPoint = 0;
    int gold = 0;
    // damage => pow
    int weaponPow = 3;
    int damageAmount = 0;
    int criticalDamage = 0;
    // defense => def
    int DefenseAmount = 0;
    // mobility => spd
    float maxMobility = 4f;
    float Mobility = 0f;
    // deley => spd
    [SerializeField] float maxDelayAmount = 10f;
    float attackDelayAmount = 0f;
    const float minDelayTime = 0.3f;

    // component
    PixelCharacter pixcelCharactor = null;
    Enemy enemy = null;
    public Enemy Enemy
    {
        get { return enemy; }
    }

    // collision�Ŏg�p
    const int right = 1;
    const int left = -1;

    // bool
    bool isMove = false;
    public bool IsMove
    {
        get { return isMove; }
        set { isMove = value; }
    }
    bool isRight = false;
    public bool IsRight
    {
        get { return isRight; }
        set { isRight = value; }
    }
    bool isLeft = false;
    public bool IsLeft
    {
        get { return isLeft; }
        set { isLeft = value; }
    }
    bool besideEnemy = false;
    public bool BesideEnemy
    {
        set { besideEnemy = value; }
    }
    bool besideHouseArea = false;
    public bool BesideHouseArea
    {
        set { besideHouseArea = value; }
        get { return besideHouseArea; }
    }
    bool besideWeaponArea = false;
    public bool BesideWeaponArea
    {
        set { besideWeaponArea = value; }
        get { return besideWeaponArea; }
    }
    bool besideArmorArea = false;
    public bool BesideArmorArea
    {
        set { besideArmorArea = value; }
        get { return besideArmorArea; }
    }
    bool isDied = false;
    public bool IsDied
    {
        get { return isDied; }
        set { isDied = value; }
    }
    bool isKilledBoss = false;
    public bool IsKilledBoss
    {
        get { return isKilledBoss; }
        set { isKilledBoss = value; }
    }
    #endregion



    void Awake()
    {
        pixcelCharactor = GetComponent<PixelCharacter>();
    }
    void Start()
    {
        isMove = true;
        ResetActorPosition();
        LoadActorStatus();
    }
    void Update()
    {
        SetPlayerUI();
        SetSystemUI();
        if (isDied) { return; }

        SetEnemyUI(enemy);

        MovePlayer();

        if (besideEnemy) { Attack(); }
    }




    #region ---PlayerStatus&UI Method

    void SetPlayerUI()
    {
        Died();

        uiManager.SetPlayerInfoUI(faceIcon, name, level);
        uiManager.SetPlayerHPText(hp, currentHp);
        uiManager.SetPlayerStatusText(pow, def, spd, lck, skl);
        uiManager.SetPlayerEXPText(sumEXP, nextExp);
        uiManager.SetplayerGoldText(gold);
        uiManager.SetPlayerInventoryText();
        uiManager.SetPlayerSkillText();
        uiManager.SetPlayerHPbar(hp, currentHp);
        uiManager.SetPlayerAttackBar(attackDelayAmount, maxDelayAmount);
    }
    void SetSystemUI()
    {
        uiManager.SetLevelUpPanelText(pow, def, spd, lck, skl, currentHp, statusAddPoint);
    }

    public void BossKilledChacker()
    {
        uiManager.ClearChacker();
    }

    public void CurrentPlayerEXPAndGold(int dropEXP, int dropGold)
    {
        int skip = 0;
        this.sumEXP += dropEXP;
        this.gold += dropGold;
        for (int i = 0; i < dropEXP; i++)
        {
            this.nextExp -= dropEXP / dropEXP;
            if (this.nextExp == 0)
            {
                LevelUp();
                uiManager.ShowEnemyKillPopup(1, 1, dropEXP, 1, dropGold);
                skip++;
            }

        }
        if (skip != 1)
        {
            uiManager.ShowEnemyKillPopup(0, 1, dropEXP, 1, dropGold);
        }


        SaveManager.instance.SetPlayerSumExp(this.sumEXP);
        SaveManager.instance.SetPlayerNextExp(this.nextExp);
        SaveManager.instance.SetPlayerGold(this.gold);

    }
    void LevelUp()
    {
        level++;
        // actorSE.LevelUpSE();
        nextExp += level * 10;
        statusAddPoint += 5;
        SaveManager.instance.SetPlayerLevel(this.level);
        SaveManager.instance.SetPlayerStatusAddPoint(this.statusAddPoint);
    }

    public void UpStatus(string status)
    {
        if (statusAddPoint > 0)
        {
            switch (status)
            {
                case "pow":
                    this.pow++;
                    SaveManager.instance.SetPlayerPow(this.pow);
                    break;
                case "def":
                    this.def++;
                    SaveManager.instance.SetPlayerDef(this.def);
                    break;
                case "spd":
                    this.spd++;
                    SaveManager.instance.SetPlayerSpd(this.spd);
                    break;
                case "lck":
                    this.lck++;
                    SaveManager.instance.SetPlayerLck(this.lck);
                    break;
                case "currentHp":
                    this.currentHp += 5;
                    SaveManager.instance.SetPlayerCurrentHp(this.currentHp);
                    break;
                case "skl":
                    this.skl += 5;
                    SaveManager.instance.SetPlayerSkl(this.skl);
                    break;
            }
            statusAddPoint--;
            SaveManager.instance.SetPlayerStatusAddPoint(this.statusAddPoint);
            actorSE.StatusDownSE();
        }
        else
        {
            actorSE.SystemErrorSE();
        }
    }
    public void DownStatus(string status)
    {
        if (status == "pow" && this.pow > 5)
        {
            this.pow--;
            this.statusAddPoint++;
            SaveManager.instance.SetPlayerPow(this.pow);
            SaveManager.instance.SetPlayerStatusAddPoint(this.statusAddPoint);
            actorSE.StatusUpSE();
            return;
        }

        if (status == "def" && this.def > 5)
        {
            this.def--;
            this.statusAddPoint++;
            SaveManager.instance.SetPlayerDef(this.def);
            SaveManager.instance.SetPlayerStatusAddPoint(this.statusAddPoint);
            actorSE.StatusUpSE();
            return;
        }

        if (status == "spd" && this.spd > 5)
        {
            this.spd--;
            this.statusAddPoint++;
            SaveManager.instance.SetPlayerSpd(this.spd);
            SaveManager.instance.SetPlayerStatusAddPoint(this.statusAddPoint);
            actorSE.StatusUpSE();
            return;
        }

        if (status == "lck" && this.lck > 5)
        {
            this.lck--;
            this.statusAddPoint++;
            SaveManager.instance.SetPlayerLck(this.lck);
            SaveManager.instance.SetPlayerStatusAddPoint(this.statusAddPoint);
            actorSE.StatusUpSE();
            return;
        }

        if (status == "currentHp" && this.currentHp > 100)
        {
            this.currentHp -= 5;
            if (this.currentHp <= this.hp)
            {
                this.hp = this.currentHp;
                SaveManager.instance.SetPlayerHp(this.hp);
            }
            this.statusAddPoint++;
            SaveManager.instance.SetPlayerCurrentHp(this.currentHp);
            SaveManager.instance.SetPlayerStatusAddPoint(this.statusAddPoint);
            actorSE.StatusUpSE();
            return;
        }

        if (status == "skl" && this.skl > 20)
        {
            this.skl -= 5;

            this.statusAddPoint++;
            SaveManager.instance.SetPlayerSkl(this.skl);
            SaveManager.instance.SetPlayerStatusAddPoint(this.statusAddPoint);
            actorSE.StatusUpSE();
            return;
        }

        actorSE.SystemErrorSE();
    }

    public void FullHelth()
    {
        this.hp = this.currentHp;
        isDied = false;
        SaveManager.instance.SetPlayerHp(this.hp);
    }

    int DamageAmount()
    {
        // todo: damageAmount�Ƀ����_��������������
        // todo: ����U���͂����Z����
        this.damageAmount = this.pow + this.weaponPow;
        int critical = Random.Range(0, this.lck + maxLck);

        if (critical > maxLck)
        {
            Debug.Log("�N���e�B�J���I�I");
            actorSE.CriticalAttackSE();
            return criticalDamage = damageAmount * 2;
        }
        if (damageAmount > 5)
        {
            actorSE.AttackSE();
            return damageAmount;
        }
        else
        {
            actorSE.AttackSE();
            return Random.Range(0, 6);
        }
    }

    public void ShortingAttackDelay(float minusAmount)
    {
        attackDelayAmount -= minusAmount;
    }
    #endregion

    #region ---EnemyUI Method
    void SetEnemyUI(Enemy e)
    {
        if (e == null) { return; }

        uiManager.SetEnemyInfoUI(e.GetFaceIcon(), e.GetName(), e.GetEnemyStatus("level"));
        uiManager.SetEnemyHPText(e.GetEnemyStatus("hp"), e.GetEnemyStatus("maxHp"));
        uiManager.SetEnemyStatusText(e.GetEnemyStatus("pow"), e.GetEnemyStatus("def"), e.GetEnemyStatus("spd"), e.GetEnemyStatus("lck"));
        uiManager.SetEnemyHPbar(e.GetEnemyStatus("hp"), e.GetEnemyStatus("maxHp"));
        uiManager.SetEnemyAttackBar(e.GetAttackDelayAmount(), e.GetMaxDelayAmount());
    }

    #endregion

    #region ---PlayerAchievement Method
    public void KillEnemyTypeChecker()
    {
        if (enemy.GetEnemyType() == Enemy.EnemyType.Slime)
        {
            slimeKillAmount++;
        }
        if (enemy.GetEnemyType() == Enemy.EnemyType.Boss)
        {
            bossKillAmount++;
        }
    }
    #endregion

    #region ---PlayerControlls Method
    void Attack()
    {
        this.attackDelayAmount -= Time.deltaTime;

        if (0 > this.attackDelayAmount)
        {
            pixcelCharactor.Attack();
            if (enemy != null)
            {
                StartCoroutine(enemy.Damage(DamageAmount()));
                //enemy.Damage(DamageAmount());
            }
            this.attackDelayAmount = this.maxDelayAmount;
        }
    }

    public IEnumerator Damage(int damageAmount)
    {
        yield return new WaitForSeconds(0.4f);
        this.hp -= damageAmount;
        SaveManager.instance.SetPlayerHp(this.hp);
    }

    void Died()
    {
        if (this.hp <= 0)
        {
            pixcelCharactor.IsDead = true;
            isMove = false;
            isDied = true;
            this.hp = 0;
        }
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
            pixcelCharactor.Facing = (int)Mathf.Abs(Mobility / Mobility);
            if (!isMove) { return; }
            else if (isMove)
            {
                //this.gameObject.transform.position += new Vector3(moveSpeed*Time.deltaTime, 0,0);
                this.gameObject.transform.Translate(Mobility * Time.deltaTime, 0, 0);
                pixcelCharactor.MovingBlend = Mathf.Clamp01((float)(Mobility / maxMobility));
            }
        }
        else if (isLeft)
        {
            pixcelCharactor.Facing = -(int)Mathf.Abs(Mobility / Mobility);
            if (!isMove) { return; }
            else if (isMove)
            {

                this.gameObject.transform.Translate(-Mobility * Time.deltaTime, 0, 0);
                pixcelCharactor.MovingBlend = Mathf.Clamp01((float)(Mobility / maxMobility));
            }


        }
    }

    void MoveSpeedBlender()
    {
        if (isRight || isLeft)
        {
            if (Mobility < maxMobility)
            {
                Mobility += maxMobility / 50f;
            }
            else if (Mobility >= maxMobility)
            {
                Mobility = maxMobility;
            }
        }
        else if (!isRight && !isLeft)
        {
            Mobility = 0f;
        }
    }

    public void ResetActorPosition()
    {
        this.gameObject.transform.position = new Vector3(-4, 4, -1);
        this.gameObject.transform.GetChild(0).localScale = new Vector3(1, 1, 1);
    }
    #endregion

    #region ---PlayerCollisionMethod
    void OnTriggerEnter2D(Collider2D collision)
    {
        EnterEndPoint(collision);

        if (collision.gameObject.tag == "Enemy")
        {
            enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.CurrentStatus(current.GetCurrentMapAmount());
            uiManager.ShowEnemyUI();
        }
        if (collision.gameObject.tag == "HouseDoor") { besideHouseArea = true; }
        if (collision.gameObject.tag == "WeaponDoor") { besideWeaponArea = true; }
        if (collision.gameObject.tag == "ArmorDoor") { besideArmorArea = true; }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemy = null;
            uiManager.HideEnemyUI();
        }

        if (collision.gameObject.tag == "HouseDoor") { besideHouseArea = false; }
        if (collision.gameObject.tag == "WeaponDoor") { besideWeaponArea = false; }
        if (collision.gameObject.tag == "ArmorDoor") { besideArmorArea = false; }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "MapEndPoint" || collision.gameObject.tag == "Enemy")
        {
            isMove = false;
        }

        if (collision.gameObject.tag == "Enemy") { besideEnemy = true; }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "MapEndPoint" || collision.gameObject.tag == "Enemy")
        {
            isMove = true;
        }

        if (collision.gameObject.tag == "Enemy") { besideEnemy = false; }
    }

    void EnterEndPoint(Collider2D collision)
    {
        if (collision.tag != "RightEndPoint" && collision.tag != "LeftEndPoint") { return; }

        if (collision.tag == "RightEndPoint")
        {
            end.SpawnPlayer(this.gameObject, right);
            current.MapFloorChange(right);
            spawn.SpawnControll(right, current.GetMapAmount());
        }

        if (collision.tag == "LeftEndPoint")
        {
            end.SpawnPlayer(this.gameObject, left);
            current.MapFloorChange(left);
            spawn.SpawnControll(left, current.GetMapAmount());
        }

    }
    #endregion

    #region ---SaveMethod
    void LoadActorStatus()
    {
        this.name = SaveManager.instance.GetPlayerName();
        this.hp = SaveManager.instance.GetPlayerHp();
        this.currentHp = SaveManager.instance.GetPlayerCurrentHp();
        this.level = SaveManager.instance.GetPlayerLevel();
        this.pow = SaveManager.instance.GetPlayerPow();
        this.def = SaveManager.instance.GetPlayerDef();
        this.spd = SaveManager.instance.GetPlayerSpd();
        this.lck = SaveManager.instance.GetPlayerLck();
        this.skl = SaveManager.instance.GetPlayerSkl();
        this.sumEXP = SaveManager.instance.GetPlayerSumExp();
        this.nextExp = SaveManager.instance.GetPlayerNextExp();
        this.gold = SaveManager.instance.GetPlayerGold();
        this.statusAddPoint = SaveManager.instance.GetPlayerStatusAddPoint();

    }
    #endregion
    */
}

