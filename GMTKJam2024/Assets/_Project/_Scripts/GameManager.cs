using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private Texture2D defaultCursor;
    [HideInInspector] public GameObject player;
    [HideInInspector] public DesktopWindow activeWindow;
    [HideInInspector] public CoinCollectTracker coinCollector;

    [SerializeField] public bool completedMonkeyexe = false;
    [SerializeField] public bool completedDiscordexe = false;

    [Header("Dark Mode")]
    [SerializeField] private Sprite darkModeWallpaper;
    [SerializeField] private Sprite monkeyMissingWallpaper;
    [SerializeField] private SpriteRenderer desktopWallPaper;
    [SerializeField] private Light2D globalLight;
    [SerializeField] private GameObject playerLight;
    [SerializeField] private GameObject darkModeMusic;
    [HideInInspector] public bool darkModeEnabled;


    // Monkey Coins

    [HideInInspector] public CoinPopup coinPopup;
    public int CoinsCollected { get; private set; } = 0;
    public int TotalCoins { get; private set; } = 20;

    // Start is called before the first frame update
    void Start()
    {
        coinCollector = new CoinCollectTracker(50);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.ForceSoftware);
    }

    // Update is called once per frame
    void Update()
    {
        CheckForSoundEffects();

        if(Input.GetKeyDown(KeyCode.Space))
        {
            coinPopup.DoPopup();
        }
    }

    public void SetDefaultCursor()
    {
        Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.ForceSoftware);
    }

    private void CheckForSoundEffects()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            AudioManager.Instance.PlaySound(AudioManager.Sounds.click);
        }
    }

    public void CollectCoin()
    {
        CoinsCollected++;
        coinPopup?.DoPopup();
    }

    public void RemoveMonkeyFromWallpaper()
    {
        desktopWallPaper.sprite = monkeyMissingWallpaper;
    }

    public void ActivateDarkMode()
    {
        darkModeEnabled = true;
        desktopWallPaper.sprite = darkModeWallpaper;
        playerLight.SetActive(true);
        globalLight.intensity = 0f;
        AudioManager.Instance.PlaySound(AudioManager.Sounds.darkMode);
        MusicManager.Instance.PlaySong(darkModeMusic);
    }
}
