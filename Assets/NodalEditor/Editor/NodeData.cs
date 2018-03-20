//Written with ♥ by Ankit Priyarup
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

namespace NodalEditor
{
	public class NodeData : ScriptableObject
	{
		public List<BaseNode> n;
		public int index;
	}
}