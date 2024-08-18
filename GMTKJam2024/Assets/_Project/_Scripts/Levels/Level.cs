using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private DesktopApplication application;
    [SerializeField] private Vector3 playerStartPos;
    [SerializeField] private bool lastLevelInApplication;
    [SerializeField] private Vector3 resetWindowSize = new Vector3(17.7f, 9f, 1f);
    [SerializeField] private Vector3 resetWindowPosition = new Vector3(0, 0.5f, 0);
    public void StartLevel()
    {
        application.SetActiveLevel(this);
        GameManager.Instance.player.transform.position = playerStartPos;
        gameObject.SetActive(true);
        Debug.Log(GameManager.Instance.activeWindow);
        Debug.Log(GameManager.Instance.activeWindow.rend);
        if (GameManager.Instance.activeWindow != null && GameManager.Instance.activeWindow.rend != null)
        {
            GameManager.Instance.activeWindow.rend.size = resetWindowSize;
            GameManager.Instance.activeWindow.transform.position = resetWindowPosition;
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

    public void ResetPlayer()
    {
        GameManager.Instance.player.transform.position = playerStartPos;

    }
}
