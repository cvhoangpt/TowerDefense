
using System.Collections;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public int startMoney = 400;

    public static int Lives;
    //Keep tracks how many lives have left
    public int startLives = 20;

    void Start()
    {
        Money = startMoney;
        Lives = startLives;
    }
}
