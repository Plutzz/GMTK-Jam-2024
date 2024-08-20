using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DesktopApplication : BaseApplication
{
    [SerializeField] private string applicationName;
    [SerializeField] private GameObject applicationWindowPrefab;
    [SerializeField] private Level firstLevel;
    [SerializeField] private GameObject background;
    [SerializeField] private Vector2 initWindowSize;
    public Level activeLevel;
    private DesktopWindow window;
    public override void StartApplication()
    {
        if(window != null)
        {
            window.CloseWindow();
        }

        if(GameManager.Instance.activeWindow != null)
        {
            GameManager.Instance.activeWindow.CloseWindow();
        }

        if(activeLevel != null)
        {
            activeLevel.gameObject.SetActive(false);
            activeLevel = null;
        }

        GameManager.Instance.player.SetActive(true);

        background.SetActive(true);

        Debug.Log(applicationName);
        window = Instantiate(applicationWindowPrefab).GetComponent<DesktopWindow>();
        GameManager.Instance.activeWindow = window;
        window.application = this;
        ResizeWindow(initWindowSize);
        AudioManager.Instance.PlaySound(AudioManager.Sounds.blip2);
        firstLevel.StartLevel();
        
    }

    public void CloseApplication()
    {
        window.application = null;
        window.CloseWindow();
        background.SetActive(false);
        activeLevel?.gameObject.SetActive(false);
        activeLevel = null;
        GameManager.Instance.player.SetActive(false);
    }

    public void SetActiveLevel(Level _level)
    {
        activeLevel = _level;
    }

    public void ResizeWindow(Vector2 _size)
    {
        window.ResizeWindow(_size);
    }
}
