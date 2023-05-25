using Assets.Scripts.Infrastructure.GameOption.LevelData;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Editor
{
    [CustomEditor(typeof(PlayerBaseArea))]
    public class PlayerBaseAreaEditor : UnityEditor.Editor
    {
        [DrawGizmo(GizmoType.Active | GizmoType.Pickable)]
        public static void RenderCustomGizmo(PlayerBaseArea area, GizmoType gizmo)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawCube(area.transform.position, area.transform.localScale);
        }
    }
}
