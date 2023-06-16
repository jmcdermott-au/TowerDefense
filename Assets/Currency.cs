using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Currency : MonoBehaviour
{
    public static int money;
    private int startMoney = 500;
    public TextMeshProUGUI textMeshPro;

    private void Start()
    {
        money = startMoney;

    }

    public void FixedUpdate()
    {
        textMeshPro.text = money.ToString() + "$";
    }
}
