using UnityEngine;
using System.Collections;

public class GUIFix : MonoBehaviour {
	
	float ratio = 1f;
	float previousScreenWidth = 1f;
	float previousScreenHeight = 1f;
	
	public bool updatePosition = true;
	public bool updateSize = true;
	public float size = 0.1f;
	public float x = 0.5f;
	public float y = 0.5f;
	
	void Awake() {
		
		if(GetComponent<GUITexture>()) {
			
			// Store texture ratio
			ratio = GetComponent<GUITexture>().pixelInset.width / GetComponent<GUITexture>().pixelInset.height;
		}
	}
	
	// Start
	void Start() {
		
		InvokeRepeating("Adjust", 0f, 0.5f);
	}
	
	// Set new size and offset
	void Adjust() {
		
		// Return if screen size did not change
		if(previousScreenWidth == Screen.width && previousScreenHeight == Screen.height) {
			
			return;	
		}
		
		// Store previous screen dimensions
		previousScreenWidth = Screen.width;
		previousScreenHeight = Screen.height;
		
		if(GetComponent<GUIText>()) {
			
			// Set position and font size
			if(updatePosition) {
				
				GetComponent<GUIText>().pixelOffset = new Vector2(Screen.width * x, Screen.height * y);
			}
			
			if(updateSize && size > 0f) {
				
				GetComponent<GUIText>().fontSize = Mathf.RoundToInt(Screen.height * size);
			}
		}
		
		if(GetComponent<GUITexture>()) {
			
			// Set size and position
			float left = GetComponent<GUITexture>().pixelInset.x;
			float top = GetComponent<GUITexture>().pixelInset.y;
			float width = GetComponent<GUITexture>().pixelInset.width;
			float height = GetComponent<GUITexture>().pixelInset.height;
			
			if(updateSize && size > 0f) {
				
				height = Screen.height * size;
				width = height * ratio;
			}
			
			if(updatePosition) {
				
				left = Screen.width * x - width / 2f;
				top = Screen.height * y - height / 2f;
			}
			
			GetComponent<GUITexture>().pixelInset = new Rect(left, top, width, height);
		}
	}
}