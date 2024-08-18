using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DesktopApplication : MonoBehaviour
{
    [SerializeField] private string applicationName;
    [SerializeField] private GameObject applicationWindowPrefab;
    [SerializeField] private Level firstLevel;
    private Level activeLevel;
    private DesktopWindow window;
    public void StartApplication()
    {
        if(window != null)
        {
            window.CloseWindow();
        }

        if(activeLevel != null)
        {
            activeLevel.gameObject.SetActive(false);
            activeLevel = null;
        }

        GameManager.Instance.player.SetActive(true);

        Debug.Log(applicationName);
        window = Instantiate(applicationWindowPrefab).GetComponent<DesktopWindow>();
        window.application = this;
        AudioManager.Instance.PlaySound(AudioManager.Sounds.blip2);
        firstLevel.StartLevel();
    }

    public void CloseApplication()
    {
        window.application = null;
        window.CloseWindow();
        activeLevel?.gameObject.SetActive(false);
        activeLevel = null;
        GameManager.Instance.player.SetActive(false);
    }

    public void SetActiveLevel(Level _level)
    {
        activeLevel = _level;
    }
}
