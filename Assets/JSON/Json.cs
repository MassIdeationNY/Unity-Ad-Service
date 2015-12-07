using UnityEngine;
using System.Collections;
using SimpleJSON;

public class Json : MonoBehaviour {

	public GUIText front;
	public string url;

	void Start (){
		StartCoroutine (SendRequest ());
	}

	IEnumerator SendRequest()
	{
		WWW request = new WWW("http://nodejs-campaigner.rhcloud.com/campaign");
		
		
		yield return request;
		
		if (request.error == null || request.error == "")
		{
			
			var N = JSON.Parse(request.text);
			
			Debug.Log(N[0]["ogv"]);
			Debug.Log(N[0]["url"]);

			url=N[0]["url"];
			PlayerPrefs.SetString(N[0]["ogv"],"data");

			//front.text=N[];
		}
		else
		{
			Debug.Log("WWW error: " + request.error);
		}
	}
	
	void Update()
	{
		//StartCoroutine(SendRequest());
//	Cube.transform.localScale = Vector3.Lerp (cubeSize, new Vector3 (1, size / 10, 1),Time.deltaTime*2);
//		cubeSize = Cube.transform.localScale;
	}
	void OnMouseDown() {
		Application.OpenURL (url);
	}
}