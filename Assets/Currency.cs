using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currency : MonoBehaviour
{
    public static int money;
    private int startMoney = 500;

    private void Start()
    {
        money = startMoney;

    }
}
