using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviour : NativeCodeRunner, SingularityUnitySdkProtocol {
   public void OnButtonPress(){
      Debug.Log("Button clicked ");
      startLogin(this);
   }

   public void onGetSingularityUserInfo(string info){
      Debug.Log("ButtonBehaviour onGetSingularityUserInfo - " + info);
   }
	
   public void onSingularityClose(){
      Debug.Log("ButtonBehaviour onSingularityClose");
   }
		
   public void onSingularityLogout(){
      Debug.Log("ButtonBehaviour onSingularityLogout");
   }
	
   public void onSingularityError(AndroidJavaObject info, AndroidJavaObject err){
      Debug.Log("ButtonBehaviour onSingularityError");
   }
}