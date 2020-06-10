using UnityEditor;


namespace DMX512
{
	[CustomEditor(typeof(ArtNetDMXController))]
	public class ArtNetDMXControllerEditor : Editor
	{	
		private bool showData = false;

		public override void OnInspectorGUI ()
		{
			ArtNetDMXController controller = (ArtNetDMXController)target;

			controller.address = EditorGUILayout.TextField("IP Address", controller.address);
			controller.port = EditorGUILayout.IntField("Port", controller.port);
			controller.universe = EditorGUILayout.IntField("Universe", controller.universe);
			controller.useEditor = EditorGUILayout.Toggle("Use Editor Data", controller.useEditor);

			showData = EditorGUILayout.Foldout(showData, "Data");
			if (showData) {
				for (int j = 0; j < 512; j++) {
					byte num = controller.data [j];
					num = (byte)EditorGUILayout.IntSlider (j.ToString(), 0, 0, 255);
					if(controller.useEditor){
						controller.data [j] = num;
					}
				}
			}

			EditorUtility.SetDirty (target);
		}
	}
}
