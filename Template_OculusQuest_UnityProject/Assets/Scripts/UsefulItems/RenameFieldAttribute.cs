using UnityEditor;

namespace UnityEngine
{
    //SerializeFieldのプロパティの名前をインスペクターから変更可能にする際に名前を扱いやすくする。
    /*使い方
        [field: SerializeField, RenameField(nameof(Hoge))]
        public bool Hoge {get; private set;} = false;
    */

    public class RenameFieldAttribute : PropertyAttribute
    {
        public string Name { get; }

        public RenameFieldAttribute(string name) => Name = name;

#if UNITY_EDITOR
        [CustomPropertyDrawer(typeof(RenameFieldAttribute))]
        public class FieldNameDrawer : PropertyDrawer
        {
            public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
            {
                string[] path = property.propertyPath.Split('.');
                bool isArray = path.Length > 1 && path[1] == "Array";

                if (!isArray && attribute is RenameFieldAttribute fieldName)
                    label.text = fieldName.Name;

                EditorGUI.PropertyField(position, property, label, true);
            }
        }
#endif
    }
}