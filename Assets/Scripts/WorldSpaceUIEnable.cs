using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WorldSpaceUIEnable: GraphicRaycaster{
    public override void Raycast(PointerEventData eventData, List<RaycastResult> resultAppendList){
        eventData.position = new(Screen.width/2, Screen.height/2);
        base.Raycast(eventData, resultAppendList);
    }
}



// public class WorldSpaceUIEnable : MonoBehaviour{
//     private void Update(){
//         Cursor.lockState = CursorLockMode.Confined;
//     }
//     private void LateUpdate(){
//         Cursor.lockState = CursorLockMode.Locked;
//     }
// }
 