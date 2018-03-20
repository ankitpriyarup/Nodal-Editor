//Written with ♥ by Ankit Priyarup
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using NodalEditor;

public class MenuNode : BaseNode
{
	public void init(Vector2 pos, float width, string title, string[] attributeTitles)
    {
        winTitle = title;
        winRect.x = pos.x;
        winRect.y = pos.y;
        winRect.width = width;
        winRect.height = 60 + 18*attributeTitles.Length;
        NodeEditor.data.n.Add(this as BaseNode);
        id = NodeEditor.data.index;
        for (int i=0; i<attributeTitles.Length; i++) attributes.Add(new BaseComponents(attributeTitles[i]));
        NodeEditor.data.index++;        
    }

    public override void DrawWindow()
	{
        base.DrawWindow();
        Event e = Event.current;

        GUIStyle style = new GUIStyle();
        style.fontSize = 14;
        style.alignment = TextAnchor.UpperRight;
        style.richText = true;
        style.normal.textColor = new Color(1, 1, 1, 0.5f);

        for (int i=0; i<attributes.Count; i++)
        {
            string txt = attributes[i].txt;
            string disTxt = (attributes[i].node != null) ? txt : "<color=#5E5E5EFF>" + txt + "</color>";
            GUILayout.Label(disTxt, style);
            if (e.type == EventType.Repaint) attributes[i].rect = GUILayoutUtility.GetLastRect();
        }
    }

    public override Rect ClickedOnRect(Vector2 pos)
    {
        for (int i=0; i<attributes.Count; i++)
        {
            Rect trect = attributes[i].rect;
            trect.x += winRect.x;
            trect.y += winRect.y;

            if (trect.Contains(pos)) return trect;
        }

        return winRect;
    }

    public override void SetInput(BaseNode input, Vector2 clickPos)
	{
        base.SetInput(input, clickPos);
    }

    public override void DrawCurves()
    {
        if (rootNode != null && rootNode.type == nodeType.Message)
        {
            Rect titleRct = new Rect(winRect.x + 9, winRect.y + 18, 12, 12);
            Rect src = rootNode.winRect;
            Color c = NodeEditor.connectionColors[(int)(connectionType)];
            NodeEditor.DrawNodeCurve(src, new Rect(titleRct.x - 10, titleRct.y, titleRct.width, titleRct.height), c);
            GUI.DrawTexture(new Rect(src.x + src.width - 21, src.y + src.height/2 - 6, 12, 12), curveJoinR);
            GUI.DrawTexture(titleRct, curveJoinL);
        }
        for (int i=0; i<attributes.Count; i++)
        {
            if (attributes[i].node != null)
            {
                Rect tR = attributes[i].rect;
                tR.x += winRect.x + 26;
                tR.y += winRect.y;
                Rect dR = attributes[i].node.winRect;
                dR.x -= dR.width - 9;
                dR.y -= dR.height/2 - 25;
                if (attributes[i].node.type == nodeType.Message) dR.y += 3;
                GUI.DrawTexture(new Rect(tR.x + tR.width - 22, tR.y + 3, 12, 12), curveJoinR);
                GUI.DrawTexture(new Rect(dR.x + dR.width, dR.y + dR.height/2 - 6, 12, 12), curveJoinL);
                Color c = NodeEditor.connectionColors[(int)(attributes[i].node.connectionType)];
                NodeEditor.DrawNodeCurve(tR, dR, c);
            }
        }
    }
}