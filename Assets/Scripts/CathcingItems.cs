using UnityEngine;

public class CathcingItems : MonoBehaviour
{
    public static CathcingItems instance { get; private set; }
    private int _localCatchItems = 0;
    private int _globalCatchItems = 5;

    public int LocalCatchItems => _localCatchItems;
    public int GlobalCatchItems => _globalCatchItems;
    public void AddCatchItem()
    {
        _localCatchItems++;
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
        _localCatchItems = 0;
        UIUpdate.instance.UpdateLocalCatchItems(LocalCatchItems);
    }

    public void CheckCatchItems()
    {
        if (_localCatchItems >= _globalCatchItems)
        {
            GameMechanics.instance.WinGame();
        }
    }

}
