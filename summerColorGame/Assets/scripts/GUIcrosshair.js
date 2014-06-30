#pragma strict
var crosshairTexture : Texture2D;
var position : Rect;
static var OriginalOn = true;
 
function Update() // Start will only get the screen size once. it will not refresh it. the turn around is to use function Update() instead.
{
    position = Rect((Screen.width - crosshairTexture.width) / 2, (Screen.height - 
        crosshairTexture.height) /2, crosshairTexture.width, crosshairTexture.height);
}
 
function OnGUI()
{
    if(OriginalOn == true)
    {
        GUI.DrawTexture(position, crosshairTexture);
    }
}