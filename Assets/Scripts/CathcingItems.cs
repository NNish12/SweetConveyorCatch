using UnityEngine;

public class CathcingItems : MonoBehaviour
{
    public static CathcingItems instance { get; private set; }
    // private int LocalCatchItems = 0;
    // private int _globalCatchItems = 5;

    public int LocalCatchItems { get; private set; } = 0;
    public int GlobalCatchItems { get; private set; } = 2;
    public void AddCatchItem()
    {
        LocalCatchItems++;
        UIUpdate.instance.UpdateLocalCatchItems(LocalCatchItems);
        CheckCatchItems();
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
    public void ClearState()
    {
        LocalCatchItems = 0;
        UIUpdate.instance.UpdateLocalCatchItems(LocalCatchItems);
    }

    public void CheckCatchItems()
    {
        if (LocalCatchItems >= GlobalCatchItems)
        {
            GameMechanics.instance.WinGame();
        }
    }
    public void BuyAdditionalItem()
    {
        GlobalCatchItems++;
        UIUpdate.instance.UpdateGlobalCatchItems(GlobalCatchItems);
    }

}
