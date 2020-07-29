using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    [SerializeField]
    private Text Money;
    [SerializeField]
    private Button damageButton;

    void Start()
    {
        GameObject[] targetGO = GameObject.FindGameObjectsWithTag("Enemy");

    }

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

    public void UpgradeDamageButton()
    {
        if (GameManager.theInstance.Money >= 100)
        {
            GameManager.theInstance.Money -= 100;
            Player.theInstance.UpgradeDamage(3);
        }
    }
    public void UnlockSwordAttack()
    {
        if (GameManager.theInstance.Money >= 1000)
        {
            GameManager.theInstance.Money -= 1000;
            Player.theInstance.UnlockSwordAttack();
        }
    }

}
