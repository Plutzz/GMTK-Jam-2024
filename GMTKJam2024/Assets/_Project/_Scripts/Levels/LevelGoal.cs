using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGoal : MonoBehaviour
{
    [SerializeField] private Level currentLevel;
    [SerializeField] private Level nextLevel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            currentLevel.EndLevel();
            nextLevel?.StartLevel();
        }
    }


}
