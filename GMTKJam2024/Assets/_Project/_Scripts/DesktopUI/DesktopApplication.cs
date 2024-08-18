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
        Debug.Log(applicationName);
        window = Instantiate(applicationWindowPrefab);
        AudioManager.Instance.PlaySound(AudioManager.Sounds.blip2);
        firstLevel.StartLevel();
    }

    public void CloseApplication()
    {
        Destroy(window);
        //activeLevel.EndLevel();
    }

    public void SetActiveLevel(Level _level)
    {
        activeLevel = _level;
    }
}
