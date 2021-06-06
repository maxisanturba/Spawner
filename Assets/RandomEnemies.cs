using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RandomEnemy", menuName = "ScriptableObjects/GenerateEnemy", order = 1)]
public class RandomEnemies : ScriptableObject
{
    public Enemy[] enemies;

    private void OnEnable()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].prefabName = "New Enemy " + i;
            enemies[i].chances = Random.Range(0f, 1f);
            enemies[i].randomColor = Random.ColorHSV();
        }
    }
}

[System.Serializable]
public class Enemy
{
    public string prefabName;
    public float chances;
    public Color randomColor;
}
