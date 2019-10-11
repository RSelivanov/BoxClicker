using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : BoxClickerElement
{
    public void Initialization()
    {
        long? coins = SaveManager.use.LoadCoins();

        if (coins != null)
        {
            GameManager.use.SetCoins((long)coins);
        }
    }
}
