using UnityEngine;

public class CathcingItems : MonoBehaviour
{
    public static CathcingItems instance { get; private set; }
    private int _localCatchItems = 3;
    private int _globalCatchItems = 4;

    public int LocalCatchItems => _localCatchItems;
    public int GlobalCatchItems => _globalCatchItems;
    public void CatchItemCount()
    {
        _localCatchItems++;
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

    public void CheckCatchItems()
    {
        if (_localCatchItems >= _globalCatchItems)
        {
            ToNextLevel();
        }
    }
    public void ToNextLevel()
    {

    }
}
