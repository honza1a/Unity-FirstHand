/*
 * Copyright (c) Meta Platforms, Inc. and affiliates.
 * All rights reserved.
 *
 * Licensed under the Oculus SDK License Agreement (the "License");
 * you may not use the Oculus SDK except in compliance with the License,
 * which is provided at the time of installation or download, or which
 * otherwise accompanies this software in either electronic or hard copy form.
 *
 * You may obtain a copy of the License at
 *
 * https://developer.oculus.com/licenses/oculussdk/
 *
 * Unless required by applicable law or agreed to in writing, the Oculus SDK
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using UnityEditor;
using UnityEngine;

namespace OVR
{

/*
-----------------------

 MixerSnapshotPropertyDrawer

-----------------------
*/
[CustomPropertyDrawer( typeof( MixerSnapshot ) )]
public class MixerSnapshotPropertyDrawer : PropertyDrawer {

    // Draw the property inside the given rect
    public override void OnGUI( Rect position, SerializedProperty property, GUIContent label ) {
        // Using BeginProperty / EndProperty on the parent property means that
        // prefab override logic works on the entire property.
        EditorGUI.BeginProperty( position, label, property );

        // Draw label
        position = EditorGUI.PrefixLabel( position, GUIUtility.GetControlID( FocusType.Passive ), label );

        // Don't make child fields be indented
        var indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;
        EditorGUIUtility.labelWidth = 65;

        float width = ( position.width - 15.0f ) / 2.0f;

        // Calculate rects
        var srcRect = new Rect( position.x, position.y, width + 20, position.height ); position.x += width + 25.0f;
        var destRect = new Rect( position.x, position.y, width - 60, position.height ); position.x += width - 60.0f;
        var secsRect = new Rect( position.x, position.y, 40, position.height );

        // Draw fields - pass GUIContent.none to each so they are drawn without labels
        EditorGUI.PropertyField( srcRect, property.FindPropertyRelative( "snapshot" ), GUIContent.none );
        EditorGUI.PropertyField( destRect, property.FindPropertyRelative( "transitionTime" ), new GUIContent( "Transition" ) );
        EditorGUI.LabelField( secsRect, new GUIContent( "sec(s)" ) );

        // Set indent back to what it was
        EditorGUI.indentLevel = indent;

        EditorGUI.EndProperty();
    }
}

} // namespace OVR
