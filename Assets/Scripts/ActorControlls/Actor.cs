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
    int sumEXP = 0;
    int nextExp = 10;
    [SerializeField] int statusAddPoint = 0;
    int gold = 0;

    // maxAmount
    int maxLevel = 1250;
    int currentHp = 100;
    int maxHp = 2000;
    int maxPow = 250;  // �U���͂ɉe��
    int maxDef = 250;  // �h��͂ɉe��
    int maxSpd = 250;  // �U�����x�ɉe��
    int maxLck = 250;  // �N���e�B�J�����ɉe��
    int maxskl = 1250; // �Z�\�l�ɉe��

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
    
    // ahievement Amount
    int slimeKillAmount = 0;
    int bossKillAmount = 0;

    [Header("Other")]
    [SerializeField] GameObject uiMasterObj;
    [SerializeField] GameObject mapPoint;

    // component
    PixelCharacter pixcelCharactor = null;
    UIMaster uiMaster = null;
    CurrentMap currentMap = null;
    EndPoint endPoint = null;
    EnemySpawn enemySpawn = null;
    Enemy enemy = null;
    public Enemy Enemy
    {
        get { return enemy; }
    }

    // collision�Ŏg�p
    const int right = 1;
    const int left = -1;

    
    #region ---�v���p�e�B
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
        set { besideWeaponArea = value;}
        get { return besideWeaponArea; }
    }
    bool besideArmorArea = false;
    public bool BesideArmorArea
    {
        set { besideArmorArea = value;}
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
        uiMaster = uiMasterObj.GetComponent<UIMaster>();
        endPoint = mapPoint.GetComponent<EndPoint>();
        enemySpawn = mapPoint.GetComponent<EnemySpawn>();
        currentMap = mapPoint.GetComponent<CurrentMap>();
    }
    void Start()
    {
        isMove = true;
        ResetActorPosition();
        SetMapPoint();
        LoadActorStatus();
    }
    void Update()
    {
        SetPlayerUI();
        SetSystemUI();
        if (isDied) { return; }

        SetEnemyUI();


        MovePlayer();

        if (besideEnemy) { Attack(); }
    }

    #region ---UI Method
    void SetPlayerUI()
    {
        uiMaster.MainManager.MainFrameLeader.PlayerStatusUI.SetAmount(this.pow, this.def, this.spd, this.lck,
                                                                               this.skl, this.sumEXP, this.nextExp);
        uiMaster.MainManager.MainFrameLeader.GoldUI.SetText(this.gold);
        uiMaster.MainManager.MainFrameLeader.PlayerInfoUI.SetPlayerInfoUI(this.faceIcon, this.name, this.level);
        uiMaster.MainManager.HPFrameUI.SetPlayerHPText(this.hp,this.currentHp);
        uiMaster.MainManager.HPFrameUI.SetPlayerHPbar(this.hp,this.currentHp);
        uiMaster.MainManager.HPFrameUI.SetPlayerAttackBar(this.attackDelayAmount,this.maxDelayAmount);
    }

    void SetSystemUI()
    {
        uiMaster.MainManager.MainFrameLeader.LevelupPanelUI.SetAmount(this.pow, this.def, this.spd, this.lck,
                                                                               this.skl, this.currentHp, this.statusAddPoint);

    }

    void SetEnemyUI()
    {
        if(enemy == null) { return; }

        uiMaster.MainManager.MainFrameLeader.EnemyUI.SetUI(enemy);
        uiMaster.MainManager.HPFrameUI.SetEnemyHPbar(enemy);
        uiMaster.MainManager.HPFrameUI.SetEnemyAttackBar(enemy);
    }

    void SetMapPoint()
    {
        endPoint.SetEndPoint(currentMap);
        enemySpawn.SpawnControll(right, currentMap.GetMapAmount());
        uiMaster.WorldObjUI.ShowWorldObj(currentMap);
    }
    #endregion

    #region ---StatusPointChanger Method
    public void CurrentPlayerEXPAndGold(int dropEXP, int dropGold)
    {
        int skip = 0;
        this.sumEXP += dropEXP;
        this.gold += dropGold;
        for (int i = 0; i < dropEXP; i++)
        {
            this.nextExp -= dropEXP/dropEXP;
            if (this.nextExp == 0)
            {
                LevelUp();
                uiMaster.MainManager.MainFrameLeader.InfoPanelUI.ShowEnemyKillPopup(1, 1, dropEXP, 1, dropGold);
                skip++;
            }
            
        }
        if(skip != 1)
        {
            uiMaster.MainManager.MainFrameLeader.InfoPanelUI.ShowEnemyKillPopup(0, 1, dropEXP, 1, dropGold);
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
        if(statusAddPoint > 0)
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
            // actorSE.StatusDownSE();
        }
        else
        {
            // actorSE.SystemErrorSE();
        }
    }
    public void DownStatus(string status)
    {
        if(status == "pow" && this.pow > 5)
        {
            this.pow--;
            this.statusAddPoint++;
            SaveManager.instance.SetPlayerPow(this.pow);
            SaveManager.instance.SetPlayerStatusAddPoint(this.statusAddPoint);
            // actorSE.StatusUpSE();
            return;
        }

        if (status == "def" && this.def > 5)
        {
            this.def--;
            this.statusAddPoint++;
            SaveManager.instance.SetPlayerDef(this.def);
            SaveManager.instance.SetPlayerStatusAddPoint(this.statusAddPoint);
            // actorSE.StatusUpSE();
            return;
        }

        if (status == "spd" && this.spd > 5)
        {
            this.spd--;
            this.statusAddPoint++;
            SaveManager.instance.SetPlayerSpd(this.spd);
            SaveManager.instance.SetPlayerStatusAddPoint(this.statusAddPoint);
            // actorSE.StatusUpSE();
            return;
        }

        if (status == "lck" && this.lck > 5)
        {
            this.lck--;
            this.statusAddPoint++;
            SaveManager.instance.SetPlayerLck(this.lck);
            SaveManager.instance.SetPlayerStatusAddPoint(this.statusAddPoint);
            // actorSE.StatusUpSE();
            return;
        }

        if (status == "currentHp" && this.currentHp > 100)
        {
            this.currentHp -= 5;
            if(this.currentHp <= this.hp)
            {
                this.hp = this.currentHp;
                SaveManager.instance.SetPlayerHp(this.hp);
            }
            this.statusAddPoint++;
            SaveManager.instance.SetPlayerCurrentHp(this.currentHp);
            SaveManager.instance.SetPlayerStatusAddPoint(this.statusAddPoint);
            // actorSE.StatusUpSE();
            return;
        }

        if (status == "skl" && this.skl > 20)
        {
            this.skl -= 5;

            this.statusAddPoint++;
            SaveManager.instance.SetPlayerSkl(this.skl);
            SaveManager.instance.SetPlayerStatusAddPoint(this.statusAddPoint);
            // actorSE.StatusUpSE();
            return;
        }

        // actorSE.SystemErrorSE();
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
            // actorSE.CriticalAttackSE();
            return criticalDamage = damageAmount * 2;
        }
        if (damageAmount > 5)
        {
            // actorSE.AttackSE();
            return damageAmount;
        }
        else
        {
            // actorSE.AttackSE();
            return Random.Range(0, 6);
        }
    }

    public void ShortingAttackDelay(float minusAmount)
    {
        attackDelayAmount -= minusAmount;
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
            if(enemy != null)
            {
                StartCoroutine(enemy.Damage(DamageAmount()));
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
            ShowEnemyUI();
        }

        ShowAnyDoor(collision);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy") 
        {
            enemy = null;
            HideEnemyUI();
        }

        HideAnyDoor(collision);
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
            currentMap.MapFloorChange(right);
            endPoint.SpawnPlayer(this.gameObject, right);
            endPoint.SetEndPoint(currentMap);
            enemySpawn.SpawnControll(right, currentMap.GetMapAmount());
            uiMaster.WorldObjUI.ShowWorldObj(currentMap);
        }

        if (collision.tag == "LeftEndPoint")
        {
            currentMap.MapFloorChange(left);
            endPoint.SpawnPlayer(this.gameObject, left);
            endPoint.SetEndPoint(currentMap);
            enemySpawn.SpawnControll(left, currentMap.GetMapAmount());
            uiMaster.WorldObjUI.ShowWorldObj(currentMap);
        }

    }

    void ShowAnyDoor(Collider2D collision)
    {
        if (collision.gameObject.tag == "HouseDoor") 
        { 
            besideHouseArea = true;
            uiMaster.MainManager.MainFrameLeader.EventButtonUI.ShowThis();
        }

        if (collision.gameObject.tag == "WeaponDoor") 
        { 
            besideWeaponArea = true;
            uiMaster.MainManager.MainFrameLeader.EventButtonUI.ShowThis();
        }

        if (collision.gameObject.tag == "ArmorDoor") 
        { 
            besideArmorArea = true;
            uiMaster.MainManager.MainFrameLeader.EventButtonUI.ShowThis();
        }
    }

    void HideAnyDoor(Collider2D collision)
    {
        if (collision.gameObject.tag == "HouseDoor")
        {
            besideHouseArea = false;
            uiMaster.MainManager.MainFrameLeader.EventButtonUI.HideThis();
        }

        if (collision.gameObject.tag == "WeaponDoor")
        {
            besideWeaponArea = false;
            uiMaster.MainManager.MainFrameLeader.EventButtonUI.HideThis();
        }

        if (collision.gameObject.tag == "ArmorDoor")
        {
            besideArmorArea = false;
            uiMaster.MainManager.MainFrameLeader.EventButtonUI.HideThis();
        }
    }

    void ShowEnemyUI()
    {
        enemy.CurrentStatus(currentMap);
        uiMaster.MainManager.MainFrameLeader.EnemyUI.ShowUI();
        uiMaster.MainManager.HPFrameUI.ShowEnemyHPFrame();
        uiMaster.MainManager.MainFrameLeader.PlayerUI.HideStatusPanel();
    }

    void HideEnemyUI()
    {
        uiMaster.MainManager.MainFrameLeader.EnemyUI.HideUI();
        uiMaster.MainManager.HPFrameUI.HideEnemyHPFrame();
        uiMaster.MainManager.MainFrameLeader.PlayerUI.ShowStatusPanel();
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

    
}