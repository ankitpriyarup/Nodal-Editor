//Written with ♥ by Ankit Priyarup
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using NodalEditor;

[CustomEditor(typeof(UIFlow))]
public class UIFlowEditor : Editor
{
	public string ID;
	public List<BaseNode> curdata = new List<BaseNode>();
    UIFlow m_Target;

	public override void OnInspectorGUI()
	{
		m_Target = (UIFlow)target;
		ID = m_Target.ID;
		DrawDefaultInspector ();
		m_Target.gameObject.name = "UI Flow (" + ID + ")";
		GUI.enabled = !string.IsNullOrEmpty(ID);
        if(GUILayout.Button("Open Editor")) UIFlowNodeEditor.ShowEditor(this);
	}

	public void SetData (List<BaseNode> data)
	{
		curdata = data;
		m_Target.ClearChilds();
		for (int i=0; i<curdata.Count; i++) m_Target.CreateChild(curdata[i].id + " : " + curdata[i].winTitle);
	}
}
