using System;
using UnityEngine;

public class Coin : PickableItem
{
    public event Action<Coin> CoinReleasing;

    protected override void ActionAfterHit()
    {
        CoinReleasing?.Invoke(this);
    }
}