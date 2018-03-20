using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodalEditor;

public class UIFlowNodeEditor : NodeEditor
{
	public static UIFlowEditor EditorInstance;

	public static void ShowEditor(UIFlowEditor parent)
	{
		EditorInstance = parent;
		NodeEditor.ShowEditor(EditorInstance.ID, typeof(UIFlowNodeEditor));
	}
	public override void OnGUI()
	{
		base.OnGUI();
		if(data.n == null)
		{
			data.n = new List<BaseNode>();
			Vector2 pos = new Vector2(10, position.height/2 - 30);
			MessageNode o = ScriptableObject.CreateInstance<MessageNode>();
			o.init(pos, 180, "START");
			AddObjectToAssetDatabase(o);
		}
	}
	public override void AddNodesItem(UnityEditor.GenericMenu menu)
	{
		base.AddNodesItem(menu);
		menu.AddItem(new GUIContent("Main Menu"), false, ContextCallback, "mainmenuNode");
		menu.AddItem(new GUIContent("Single Player"), false, ContextCallback, "singleplayerNode");
		menu.AddItem(new GUIContent("Quit Confirm"), false, ContextCallback, "quitconfirmNode");
	}
	public override void ContextCallback(object obj)
	{
		base.ContextCallback(obj);
		switch(obj.ToString())
		{
			case "mainmenuNode":
				NodeMainMenu(mousePos);
			break;
			case "quitconfirmNode":
				NodeQuitConfirm(mousePos);
			break;
			case "singleplayerNode":
				NodeSinglePlayer(mousePos);
			break;
		}
	}
	public static BaseNode NodeMainMenu(Vector2 pos)
	{
		string title = "MAIN MENU";
		string[] options = {"SINGLEPLAYER", "MULTIPLAYER", "OPTIONS", "QUIT"};
		float width = 220;
		MenuNode n = ScriptableObject.CreateInstance<MenuNode>();
		n.init(pos, width, title, options);
		n.type = BaseNode.nodeType.MainMenu;
		AddObjectToAssetDatabase(n);
		return n;
	}
	public static BaseNode NodeQuitConfirm(Vector2 pos)
	{
		string title = "QUIT CONFIRM";
		string[] options = {"CANCEL", "QUIT"};
		float width = 180;
		MenuNode n = ScriptableObject.CreateInstance<MenuNode>();
		n.init(pos, width, title, options);
		n.type = BaseNode.nodeType.QuitConfirm;
		AddObjectToAssetDatabase(n);
		return n;
	}
	public static BaseNode NodeSinglePlayer(Vector2 pos)
	{
		string title = "SINGLE PLAYER";
		string[] options = {"CANCEL", "START GAME"};
		float width = 180;
		MenuNode n = ScriptableObject.CreateInstance<MenuNode>();
		n.init(pos, width, title, options);
		n.type = BaseNode.nodeType.SinglePlayer;
		AddObjectToAssetDatabase(n);
		return n;
	}
	public override void OnDisable()
	{
		EditorInstance.SetData(data.n);
	}
}
