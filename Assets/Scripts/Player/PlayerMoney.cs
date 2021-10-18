using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMoney : MonoBehaviour
{
    public int Count { get; private set; }

    public event UnityAction<int> MoneyReceived;
    public event UnityAction MoneyChanged;

    public void PlusReward(Enemy enemy)
    {
        Count += enemy.Reward;

        MoneyReceived?.Invoke(enemy.Reward);
        MoneyChanged?.Invoke();
    }

    public void MinusMoney(int price)
    {
        Count -= price;

        MoneyChanged?.Invoke();
    }
}
