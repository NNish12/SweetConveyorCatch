using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class LivesManager : MonoBehaviour
{
    public static LivesManager instance { get; private set; }

    private int _localLives;
    private int _globalLives = 1;

    public int LocalLives
    {
        get => _localLives;
        private set
        {
            _localLives = value;
            UIUpdate.instance.UpdateLocalLives(_localLives);
            if (_localLives <= 0) 
            {
                GameMechanics.instance.GameOver();
            }
        }
    }

    public int GlobalLives
    {
        get => _globalLives;
        set
        {
            _globalLives = Mathf.Max(0, value);
            UIUpdate.instance.UpdateGlobalLives(_globalLives);

            if (_globalLives <= 0)
            {
                // EndGame();
            }
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
        private void Start()
    {
        _localLives = _globalLives;
        UIUpdate.instance.UpdateAllUI();
    }
    public void LoseLife()
    {
        LocalLives--;
        UIUpdate.instance.UpdateLocalLives(_localLives);
    }
    public void ClearState() 
    {
        LocalLives = GlobalLives;
        UIUpdate.instance.UpdateLocalLives(_localLives);
    }

        public void BuyAdditionalLives()
    {
        _globalLives++;
        _localLives = _globalLives;
        UIUpdate.instance.UpdateGlobalLives(GlobalLives);
        UIUpdate.instance.UpdateLocalLives(LocalLives);
    }

}