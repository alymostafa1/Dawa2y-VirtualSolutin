﻿namespace UIWidgets
{
	using System.Collections.Generic;
	using UnityEditor;
	using UnityEngine;

	/// <summary>
	/// Splitter editor.
	/// </summary>
	[CanEditMultipleObjects]
	[CustomEditor(typeof(Splitter), true)]
	public class SplitterEditor : Editor
	{
		/// <summary>
		/// Serialized properties.
		/// </summary>
		protected Dictionary<string, SerializedProperty> SerializedProperties = new Dictionary<string, SerializedProperty>();

		/// <summary>
		/// Serialized cursors.
		/// </summary>
		protected Dictionary<string, SerializedProperty> SerializedCursors = new Dictionary<string, SerializedProperty>();

		/// <summary>
		/// Properties.
		/// </summary>
		protected List<string> Properties = new List<string>();

		/// <summary>
		/// Cursors.
		/// </summary>
		protected List<string> Cursors = new List<string>()
		{
			"CurrentCamera",
			"CursorTexture",
			"CursorHotSpot",
			"DefaultCursorTexture",
			"DefaultCursorHotSpot",
		};

		/// <summary>
		/// Init.
		/// </summary>
		protected virtual void OnEnable()
		{
			Properties.Clear();
			SerializedProperties.Clear();
			SerializedCursors.Clear();

			var property = serializedObject.GetIterator();
			property.NextVisible(true);
			while (property.NextVisible(false))
			{
				AddProperty(property);
			}

			Properties.ForEach(x => SerializedProperties.Add(x, serializedObject.FindProperty(x)));
			Cursors.ForEach(x => SerializedCursors.Add(x, serializedObject.FindProperty(x)));
		}

		void AddProperty(SerializedProperty property)
		{
			if (!Cursors.Contains(property.name))
			{
				Properties.Add(property.name);
			}
		}

		/// <summary>
		/// Toggle cursors block.
		/// </summary>
		protected bool ShowCursors;

		/// <summary>
		/// Draw inspector GUI.
		/// </summary>
		public override void OnInspectorGUI()
		{
			serializedObject.Update();

			EditorGUILayout.PropertyField(SerializedProperties["Type"], true);
			EditorGUILayout.PropertyField(SerializedProperties["UpdateRectTransforms"], true);
			EditorGUILayout.PropertyField(SerializedProperties["UpdateLayoutElements"], true);
			EditorGUILayout.PropertyField(SerializedProperties["mode"], true);

			// compact layout
			if (SerializedProperties["mode"].enumValueIndex == 1)
			{
				EditorGUILayout.PropertyField(SerializedProperties["leftTarget"], true);
				EditorGUILayout.PropertyField(SerializedProperties["rightTarget"], true);
			}

			EditorGUILayout.BeginVertical();

			ShowCursors = GUILayout.Toggle(ShowCursors, "Cursors", "Foldout", GUILayout.ExpandWidth(true));
			if (ShowCursors)
			{
				SerializedCursors.ForEach(x => EditorGUILayout.PropertyField(x.Value, true));
			}

			EditorGUILayout.EndVertical();

			serializedObject.ApplyModifiedProperties();
		}
	}
}