using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private Texture2D defaultCursor;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        CheckForSoundEffects();
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
}
