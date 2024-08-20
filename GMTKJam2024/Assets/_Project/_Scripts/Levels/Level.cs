using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Tilemaps;

public class Level : MonoBehaviour
{
    [SerializeField] private DesktopApplication application;
    [SerializeField] private Vector3 playerStartPos;
    [SerializeField] private bool lastLevelInApplication;

    [SerializeField] private bool resetWindow = true;
    [SerializeField] private Vector3 resetWindowSize = new Vector3(17.7f, 9f, 1f);
    [SerializeField] private Vector3 resetWindowPosition = new Vector3(0, 0.5f, 0);

    [SerializeField] private List<IResetable> resetableObjects = new List<IResetable>();

    public UnityEvent actionOnStart;
    public UnityEvent actionOnComplete;


    private void Start()
    {
        CheckForObjects(transform);
    }

    private void CheckForObjects(Transform t)
    {
        IResetable _obj = t.gameObject.GetComponent<IResetable>();
        SpriteRenderer _rend = t.gameObject.GetComponent<SpriteRenderer>();
        TilemapRenderer _tileRend = t.gameObject.GetComponent<TilemapRenderer>();

        if( _rend != null )
        {
            _rend.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
        }

        if (_tileRend != null)
        {
            _tileRend.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
        }

        if (_obj != null)
        {
            Debug.Log("ADD " + _obj);
            resetableObjects.Add(_obj);
        }
        foreach (Transform child in t)
        {
            CheckForObjects(child);
        }
    }


    public void StartLevel()
    {
        gameObject.SetActive(true);
        application.SetActiveLevel(this);
        
        GameManager.Instance.player.transform.position = playerStartPos;
        Debug.Log(GameManager.Instance.activeWindow);
        Debug.Log(GameManager.Instance.activeWindow.rend);
        if (resetWindow && GameManager.Instance.activeWindow != null && GameManager.Instance.activeWindow.rend != null)
        {
            ResetWindow();
        }
        ResetLevel();
    }

    public void EndLevel()
    {
        AudioManager.Instance.PlaySound(AudioManager.Sounds.pickupCoin2);
        gameObject.SetActive(false);
        if(lastLevelInApplication)
        {
            application.CloseApplication(true);
        }
    }

    public void ResetWindow()
    {
        foreach(Transform child in GameManager.Instance.activeWindow.transform)
        {
            if(child.GetComponent<IWindowHandle>() != null)
            {
                child.GetComponent<IWindowHandle>().ForceReset();
            }
        }
        GameManager.Instance.activeWindow.rend.size = resetWindowSize;
        GameManager.Instance.activeWindow.transform.position = resetWindowPosition;
    }

    public void ResetPlayer()
    {
        ResetWindow();
        ResetLevel();
        GameManager.Instance.player.transform.position = playerStartPos;
    }

    public void ResetLevel()
    {
        foreach(IResetable _obj in resetableObjects)
        {
            _obj.ResetObject();
        }

    }
}
