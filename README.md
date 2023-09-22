# unity-webgl-itch-playerprefs

1. Include the Plugins/jsLibrary.jslib - needs to be in this folder with the .jslib extension. You can probably rename jsLibrary to whatever you want though.
2. Include the UserDataManager.cs
3. Make calls to UserDataManager.Setters/Getters - This is analogous to the PlayerPrefs.Setters/Getters, so should be easy to swap
4. If you're currently saving things to a file, you'll need to instead save to a string (UserDataManager.SetString("SomeKey", theStringYoudNormallySaveToAFile);
