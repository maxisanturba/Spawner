using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SpawnSystem))]
public class SpawnerEditor : Editor
{
    SpawnSystem system;
    GUIStyle titleStyle = new GUIStyle();

    private void OnEnable()
    {
        system = (SpawnSystem)target;
        SetTitleStyle();
    }

    public override void OnInspectorGUI()
    {
        EditorGUILayout.LabelField("Spawner Options", titleStyle);
        system.selector = (SpawnSystem.Selector)EditorGUILayout.EnumPopup("Spawn Mode", system.selector);

        switch (system.selector)
        {
            case SpawnSystem.Selector.SpawnByFixedTime:
                system.singleEnemy = (GameObject)EditorGUILayout.ObjectField("Set the enemy to spawn", system.singleEnemy, typeof(GameObject), true);
                system.quantity = EditorGUILayout.IntField("Set how many enemies to spawn", system.quantity);
                system.timeToSpawn = EditorGUILayout.FloatField("Time to spawn", system.timeToSpawn);
                break;
            case SpawnSystem.Selector.SpawnByRandomTime:
                system.singleEnemy = (GameObject)EditorGUILayout.ObjectField("Set the enemy to spawn", system.singleEnemy, typeof(GameObject), true);
                system.quantity = EditorGUILayout.IntField("Set how many enemies to spawn", system.quantity);
                system.minTime = EditorGUILayout.FloatField("Min time to spawn", system.minTime);
                system.maxTime = EditorGUILayout.FloatField("Max time to spawn", system.maxTime);
                break;
            case SpawnSystem.Selector.SpawnRandomEnemies:
                system.newEnemy = (RandomEnemies)EditorGUILayout.ObjectField("Set array of enemies", system.newEnemy, typeof(RandomEnemies), true);
                system.quantity = EditorGUILayout.IntField("Set how many enemies to spawn", system.quantity);
                system.minTime = EditorGUILayout.FloatField("Min time to spawn", system.minTime);
                system.maxTime = EditorGUILayout.FloatField("Max time to spawn", system.maxTime);
                break;
            default:
                break;
        }
    }

    private void SetTitleStyle()
    {
        titleStyle.fontStyle = FontStyle.Bold;
        titleStyle.alignment = TextAnchor.MiddleCenter;
        titleStyle.normal.textColor = Color.green;
        titleStyle.fontSize = 15;
    }
}
