using UnityEngine;

public class CathcingItems : MonoBehaviour
{
    public static CathcingItems instance { get; private set; }
    private int _localCatchItems = 0;
    private int _globalCatchItems = 4;

    public int LocalCatchItems => _localCatchItems;
    public int GlobalCatchItems => _globalCatchItems;
    public void CatchItemCount()
    {
        _localCatchItems++;
        CheckCatchItems();
        NewUIUpdate.instance.UpdateLocalCatchItems(_localCatchItems);
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            return;
        }
        Destroy(this.gameObject);
    }
    public void ClearState() => _localCatchItems = 0;

    public void CheckCatchItems()
    {
        if (_localCatchItems >= _globalCatchItems)
        {
            int coinsBeforeReset = CoinsManager.instance.LocalCoins;
            NewGameMechanics.instance.WinGame();
            // NewUIUpdate.instance.UpdateLocalCatchItems(_localCatchItems);
            _localCatchItems = 0;
            NewUIUpdate.instance.UpdateLocalCoins(coinsBeforeReset);

        }
    }

    // public void ToNextLevel()
    // {

    // }

}
