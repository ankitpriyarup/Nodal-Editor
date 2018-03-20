//Written with ♥ by Ankit Priyarup
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using NodalEditor;

namespace NodalEditor
{
	[Serializable]
	public class BaseComponents
	{
		public BaseNode node;
		public Rect rect;
		public string txt;

		public BaseComponents(string _txt)
		{
			txt = _txt;
			rect = new Rect();
		}
	}
	[Serializable]
	public abstract class BaseNode : ScriptableObject
	{
		public int id;
		public Rect winRect;
		public string winTitle = "";
		public Texture2D winIcon;
		public Texture2D curveJoinR;
		public Texture2D curveJoinL;	
		public bool ifConnected = false;
		public nodeType type;
		public BaseNode rootNode;
		public List<BaseComponents> attributes = new List<BaseComponents>();
		public connType connectionType = connType.Default;
		
		public enum connType {Default, Extension, Overlay};	
		public enum nodeType {Message, MainMenu, QuitConfirm, SinglePlayer};
		
		public virtual void DrawWindow()
		{
			GUI.skin = NodeEditor.skin;
			winIcon = EditorGUIUtility.Load("markPanel.png") as Texture2D;
			curveJoinR = EditorGUIUtility.Load("joinR.png") as Texture2D;
			curveJoinL = EditorGUIUtility.Load("joinL.png") as Texture2D;

			if (type != nodeType.Message)
			{
				GUI.DrawTexture(new Rect(winRect.width - 34, 14, 20, 20), winIcon, ScaleMode.ScaleToFit, true);
				Handles.BeginGUI();
				Handles.color = new Color(0.4f, 0.4f, 0.4f, 1);
				Handles.DrawLine(new Vector3(8, 38), new Vector2(winRect.width - 8, 38));
				Handles.EndGUI();
				GUILayout.Space(5);
			}
		}

		public virtual Rect ClickedOnRect(Vector2 pos) { return winRect; }

		public virtual void DrawCurves() { }

		public virtual void SetAttributeNode(Rect rect, BaseNode node)
		{
			rect.x -= winRect.x;
			rect.y -= winRect.y;
			for (int i=0; i<attributes.Count; i++)
			{
				if (attributes[i].rect.Equals(rect))
					if (node != NodeEditor.data.n[0]) attributes[i].node = node;
			}
		}

		public virtual void SetInput(BaseNode input, Vector2 clickPos)
		{
			clickPos.x -= winRect.x;
			clickPos.y -= winRect.y;

			Rect titleRect = new Rect(0, 0, winRect.width, 60);
			if (titleRect.Contains(clickPos) && !input.ifConnected)
			{
				if (input.type == nodeType.Message) input.ifConnected = true;
				rootNode = input;
			}
		}

		public virtual void NodeDeleted(BaseNode node)
		{
			if (node.rootNode != null)
			{
				BaseNode sNode = node.rootNode;
				if (sNode.type == nodeType.Message) sNode.ifConnected = false;
				for (int i=0; i<sNode.attributes.Count; i++)
					if(sNode.attributes[i].node == node) sNode.attributes[i].node = null;
			}
		}
	}
}