#pragma strict

var flash:GUITexture;

function Start () {

}

function OnMouseDown () {
	flash.color.a=255;
	white();
}

function white(){
	yield WaitForSeconds(0.05);
		flash.color.a=0;
	
}