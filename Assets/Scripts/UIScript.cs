using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    [SerializeField]
    private Text Money;

    // Update is called once per frame
    void Update()
    {
        if (Money != null)
         Money.text = GameManager.theInstance.Money.ToString();
    }

    public void SetMoney(float pMoney)
    {
        Money.text = GameManager.theInstance.Money.ToString();
    }
}
