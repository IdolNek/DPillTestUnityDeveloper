using Assets.Scripts.Infrastructure.GameOption.LevelData;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Editor
{
    [CustomEditor(typeof(LevelStaticData))]
    public class LevelStaticDataEditor : UnityEditor.Editor
    {
        private const string initialPoint = "StartPlayerPoint";

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            var levelData = (LevelStaticData)target;
            if (GUILayout.Button("Collect"))
            {
                levelData.SetLevelKey(SceneManager.GetActiveScene().name);
                levelData.SetInitialPlayerPosition(FindObjectOfType<PlayerSpawnMarker>().gameObject.transform.position);
                Transform enemySpawnAreaTransform = FindObjectOfType<EnemySpawnArea>().gameObject.transform;
                levelData.SetEnemySpawnArea(enemySpawnAreaTransform.position, enemySpawnAreaTransform.localScale);
            }
            EditorUtility.SetDirty(target);
        }
    }
}