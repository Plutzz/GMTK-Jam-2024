using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesktopApplication : MonoBehaviour
{
    [SerializeField] private string applicationName;
    [SerializeField] private GameObject applicationWindowPrefab;
    [SerializeField] private Level firstLevel;
    private Level activeLevel;
    private GameObject window;
    public void StartApplication()
    {
        if(window != null)
        {
            Destroy(window);
        }

        if(activeLevel != null)
        {
            activeLevel.gameObject.SetActive(false);
            activeLevel = null;
        }

        Debug.Log(applicationName);
        window = Instantiate(applicationWindowPrefab);
        window.GetComponent<DesktopWindow>().application = this;
        AudioManager.Instance.PlaySound(AudioManager.Sounds.blip2);
        firstLevel.StartLevel();
    }

    public void CloseApplication()
    {
        Destroy(window);
        activeLevel?.gameObject.SetActive(false);
        activeLevel = null;
    }

    public void SetActiveLevel(Level _level)
    {
        activeLevel = _level;
    }
}
