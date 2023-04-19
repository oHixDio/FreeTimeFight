using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ActorStatus : ScriptableObject
{

    // 継承の実験を行います

    //----------基本ステータス----------//

    //追加する場合はサブクラスの変更も修正する
    [SerializeField] protected new string name = "";
    [SerializeField] protected int hp = 100;
    [SerializeField] protected int maxHp = 100;
    [SerializeField] protected int level = 1;
    [SerializeField] protected int pow = 5;
    [SerializeField] protected int def = 5;
    [SerializeField] protected int speed = 5;
    [SerializeField] protected int luck = 5;

    //----------------------------------//

    //----------基本計算式メソッド----------//

    //追加する場合はサブクラスの変更も修正する

}
