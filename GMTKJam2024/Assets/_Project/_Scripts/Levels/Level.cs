using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private DesktopApplication application;
    [SerializeField] private Vector3 playerStartPos;
    [SerializeField] private bool lastLevelInApplication;

    [SerializeField] private bool resetWindow = true;
    [SerializeField] private Vector3 resetWindowSize = new Vector3(17.7f, 9f, 1f);
    [SerializeField] private Vector3 resetWindowPosition = new Vector3(0, 0.5f, 0);

    [SerializeField] private List<ScaleableObject> scaleableObjects = new List<ScaleableObject>();


    private void Start()
    {
        CheckForObjects(transform);
    }

    private void CheckForObjects(Transform t)
    {
        ScaleableObject so = t.gameObject.GetComponent<ScaleableObject>();
        if (so != null)
        {
            Debug.Log("ADD " + so);
            scaleableObjects.Add(so);
        }
        foreach (Transform child in t)
        {
            CheckForObjects(child);
        }
    }


    public void StartLevel()
    {
        application.SetActiveLevel(this);
        GameManager.Instance.player.transform.position = playerStartPos;
        gameObject.SetActive(true);
        Debug.Log(GameManager.Instance.activeWindow);
        Debug.Log(GameManager.Instance.activeWindow.rend);
        if (resetWindow && GameManager.Instance.activeWindow != null && GameManager.Instance.activeWindow.rend != null)
        {
            ResetWindow();
        }

    }

    public void EndLevel()
    {
        AudioManager.Instance.PlaySound(AudioManager.Sounds.pickupCoin2);
        gameObject.SetActive(false);
        if(lastLevelInApplication)
        {
            application.CloseApplication();
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
        foreach(ScaleableObject so in scaleableObjects)
        {
            so.ResetObject();
        }
    }
}
