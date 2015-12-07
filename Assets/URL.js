#pragma strict
var URL :String;
function Start(){
URL=PlayerPrefs.GetString("weblink");
}

function OnMouseDown () {
Application.OpenURL(URL);
}