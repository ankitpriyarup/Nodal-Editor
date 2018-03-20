//Written with ♥ by Ankit Priyarup
using UnityEngine;
using UnityEditor;
using NodalEditor;

public class MessageNode : BaseNode
{
	public void init(Vector2 pos, float width, string msg)
    {
        type = nodeType.Message;
		winTitle = msg;
		winRect.x = pos.x;
		winRect.y = pos.y;
		winRect.width = width;
		winRect.height = 60;
		NodeEditor.data.n.Add(this as BaseNode);
		id = NodeEditor.data.index;
		NodeEditor.data.index++;
    }
	public override void DrawWindow()
	{
		base.DrawWindow();
		var style = GUI.skin.GetStyle("Label");
		style.alignment = TextAnchor.MiddleCenter;
		style.fontSize = 18;
		EditorGUI.LabelField(new Rect(0, 0, winRect.width, winRect.height), winTitle, style);
	}
}
