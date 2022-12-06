using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyUI.Toast ;

public class NativeCodeRunner : MonoBehaviour {

	private static SingularityUnitySdkProtocol mListener = null;

	void Awake()
	{
  	  UnityThread.initUnityThread();
	}
	
	private class DeviceCallback : AndroidJavaProxy
	{
		public DeviceCallback() : base("io.neobrix.singularity_sdk_android.SingularityListener") {}

		void onGetSingularityUserInfo(string info)
		{
			Debug.Log("Unity - DeviceCallback - onGetSingularityUserInfo");
			if(info is string){
				Debug.Log("Unity - DeviceCallback - onGetSingularityUserInfo - " + (info as string) );
				mListener.onGetSingularityUserInfo(info);
			}
		}

		void onSingularityClose()
		{
			Debug.Log("Unity - DeviceCallback - onSingularityClose");
			UnityThread.executeInUpdate(() =>
			{
    			Toast.Show ("onSingularityClose") ;
			});
			mListener.onSingularityClose();
			
		}

		void onSingularityLogout()
		{
			Debug.Log("Unity - DeviceCallback - onSingularityLogout");
			UnityThread.executeInUpdate(() =>
			{
    			Toast.Show ("onSingularityLogout") ;
			});
			mListener.onSingularityLogout();
		}

		void onSingularityError(AndroidJavaObject info, AndroidJavaObject err)
		{
			Debug.Log("Unity - DeviceCallback - onSingularityError");
			UnityThread.executeInUpdate(() =>
			{
    			Toast.Show ("onSingularityLogout") ;
			});
			mListener.onSingularityError(info, err);
		}
	}

	void Start() {
		//  var androidJC = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        //  var jo = androidJC.GetStatic<AndroidJavaObject>("currentActivity");

        // //  var jc = new AndroidJavaClass("io.neobrix.singularity_sdk_android.SingularitySDKInitializer");
		//  var jc = new AndroidJavaObject("io.neobrix.singularity_sdk_android.SingularitySDKInitializer");

		//  var deviceCallback = new DeviceCallback();
        //  // Calling a Call method to which the current activity is passed
        // //  jc.CallStatic("activityLauncher", jo);

		// Debug.Log("Unity - NativeCodeRunner - jo - " + jo);
		// Debug.Log("Unity - NativeCodeRunner - deviceCallback - " + deviceCallback);

		// jc.Call("startLogin", jo, null, deviceCallback);
	}

	// public void clickClick() {
	// 	var androidJC = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
    //      var jo = androidJC.GetStatic<AndroidJavaObject>("currentActivity");

    //     //  var jc = new AndroidJavaClass("io.neobrix.singularity_sdk_android.SingularitySDKInitializer");
	// 	 var jc = new AndroidJavaObject("io.neobrix.singularity_sdk_android.SingularitySDKInitializer");

	// 	 var deviceCallback = new DeviceCallback();
    //      // Calling a Call method to which the current activity is passed
    //     //  jc.CallStatic("activityLauncher", jo);

	// 	Debug.Log("Unity - NativeCodeRunner - jo - " + jo);
	// 	Debug.Log("Unity - NativeCodeRunner - deviceCallback - " + deviceCallback);

	// 	jc.Call("startLogin", jo, null, deviceCallback);
	// }

	public void startLogin(SingularityUnitySdkProtocol _listener) {
		mListener = _listener;
		var androidJC = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        var jo = androidJC.GetStatic<AndroidJavaObject>("currentActivity");

        //  var jc = new AndroidJavaClass("io.neobrix.singularity_sdk_android.SingularitySDKInitializer");
		var jc = new AndroidJavaObject("io.neobrix.singularity_sdk_android.SingularitySDKInitializer");

		var deviceCallback = new DeviceCallback();
         // Calling a Call method to which the current activity is passed
        //  jc.CallStatic("activityLauncher", jo);

		Debug.Log("Unity - NativeCodeRunner - jo - " + jo);
		Debug.Log("Unity - NativeCodeRunner - deviceCallback - " + deviceCallback);

		jc.Call("startLogin", jo, null, deviceCallback);
	}

}

public interface SingularityUnitySdkProtocol
{
		public void onGetSingularityUserInfo(string info);
		public void onSingularityClose();
		public void onSingularityLogout();
		public void onSingularityError(AndroidJavaObject info, AndroidJavaObject err);
}