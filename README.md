# Nodal-Editor
Nodal Editor is a Unity Editor Scripting library that lets you create node based data structures easily.

![](https://i.imgur.com/CNkL1FG.png)

#### Implementation

- Import latest Nodal-Editor Unity package from [release section](https://github.com/ankitpriyarup/Nodal-Editor/releases/tag/1.0)
- First task is to create suitable notes for that you use NodalEditor namespace in Node class and then inherit it from BaseNode class.
- Override methods from the parent class to implement custom behaviour

| Methods      			| Function          
| --------------------- |:-------------
| DrawWindow  	     	| When node is rendering
| ClickedOnRect       	| When clicked on node
| SetInput  			| During interaction with 
| DrawCurves			| While making connections with other nodes

- Next task is to setup the custom NodeEditor like before, again use NodalEditor namespace and inherit it from NodeEditor class.

| Methods      			| Function          
| --------------------- |:-------------
| OnGUI  	     		| GUI refresh call
| AddNodesItem       	| Called to add custom nodes to the editor
| ContextCallback 		| Called to add context menu options (to create options for other nodes)
| ContextCallback		| Callback for context method
| OnDisable				| Called when the Node Editor is dismissed



##### Example included inside the project
