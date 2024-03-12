using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Shooting), true)]
[CanEditMultipleObjects]
public class ShootingEditor : Editor
{
    private SerializedProperty _enemyType;
    private SerializedProperty _shootPoint;
    private SerializedProperty _secondsBetweenShoot;
    private SerializedProperty _towardsBullet;
    private SerializedProperty _straightBullet;
    private SerializedProperty _homingBullet;

    private void OnEnable()
    {
        _enemyType = serializedObject.FindProperty("_enemyType");
        _shootPoint = serializedObject.FindProperty("_shootPoint");
        _secondsBetweenShoot = serializedObject.FindProperty("_secondsBetweenShoot");
        _towardsBullet = serializedObject.FindProperty("_towardsBullet");
        _straightBullet = serializedObject.FindProperty("_straightBullet");
        _homingBullet = serializedObject.FindProperty("_homingBullet");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(_enemyType);
        switch (_enemyType.enumValueIndex)
        {
            case (int)ShootingEnemyType.Gargoyle:
                EditorGUILayout.PropertyField(_homingBullet);
                break;
            case (int)ShootingEnemyType.Spider:
                EditorGUILayout.PropertyField(_straightBullet);
                break;
            case (int)ShootingEnemyType.Turret:
                EditorGUILayout.PropertyField(_towardsBullet);
                break;
            default:
                break;
        }

        DrawLine();

        EditorGUILayout.PropertyField(_shootPoint);
        EditorGUILayout.PropertyField(_secondsBetweenShoot);

        serializedObject.ApplyModifiedProperties();
    }

    private void DrawLine()
    {
        EditorGUILayout.Space(5);
        EditorGUI.DrawRect(EditorGUILayout.GetControlRect(false, 1), Color.gray);
        EditorGUILayout.Space(5);
    }
}
