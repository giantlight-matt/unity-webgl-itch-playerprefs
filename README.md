# Unity Webgl Itch PlayerPrefs
**For Saving and Loading data in a WebGL build on itch.io**

These are a couple files that demonstrate how to save data to localstorage in a webgl build. This is necessary for the case of itch.io, where each new build gets a new (sub?)domain, which disconnects the game from any existing save data.

1. Include the Plugins/jsLibrary.jslib - needs to be in this folder with the .jslib extension. You can probably rename jsLibrary to whatever you want though.
2. Include the UserDataManager.cs
3. Change the SAVE_PATH value in UserDataManager to something unique-ish for your game.
4. Make calls to UserDataManager.Setters/Getters - This is analogous to the PlayerPrefs.Setters/Getters, so should be easy to swap
5. If you're currently saving things to a file, you'll need to instead save to a string: UserDataManager.SetString("SomeKey", theStringYoudNormallySaveToAFile);
