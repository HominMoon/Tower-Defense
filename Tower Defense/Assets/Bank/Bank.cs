using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;

    [SerializeField] int currentBalance;

    [SerializeField] TextMeshProUGUI displayBalance;

    public int CurrentBalance { get { return currentBalance; } } // getter
    // -> 외부에서 접근은 할 수 있지만 수정은 불가

    private void Awake()
    {
        currentBalance = startingBalance;
        UpdateDisplay();
    }

    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
        UpdateDisplay();
    }

    public void Withdraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
        UpdateDisplay();
        
        if (currentBalance < 0)
        {
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.buildIndex); //이런식으로도 인덱스 호출 가능
        }

    }

    void UpdateDisplay()
    {
        displayBalance.text = "Gold: " + currentBalance;
    }
}
