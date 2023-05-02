using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="New Achievement", fileName ="New Achievement")]
public class Achievements : ScriptableObject
{
    [TextArea(2,2)]
    [SerializeField] string achievementTextLine = "";
    [SerializeField] int firstBreakValueAmount = 0;
    [SerializeField] int secondBreakValueAmount = 0;
    [SerializeField] int thirdBreakValueAmount = 0;

    public string GetAchievementTextLine()
    {
        return achievementTextLine;
    }
    public int GetFirstBreakValueAmount()
    {
        return firstBreakValueAmount;
    }
    public int GetSecondBreakValueAmount()
    {
        return secondBreakValueAmount;
    }
    public int GetThirdBreakValueAmount()
    {
        return thirdBreakValueAmount;
    }
}
