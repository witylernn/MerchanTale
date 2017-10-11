using UnityEditor;

[CustomEditor(typeof(CubeCustomAsset))]
public class CubeCustomAssetEditor : Editor
{
	public override void OnInspectorGUI()
	{
		this.serializedObject.Update();

		EditorGUILayout.PropertyField(this.serializedObject.FindProperty("InitialPosition"));
		EditorGUILayout.PropertyField(this.serializedObject.FindProperty("Material"));

		this.serializedObject.ApplyModifiedProperties();
	}
}
