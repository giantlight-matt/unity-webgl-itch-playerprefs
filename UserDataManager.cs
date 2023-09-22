using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.InputSystem;

public static class UserDataManager
{
    private const string SAVE_PATH = "idbfs/some_unique_path/";

    public static string PrefixKey(string key){
        return SAVE_PATH + key;
    }

    public static void SetString(string key, string data){
        #if UNITY_WEBGL && !UNITY_EDITOR
        aSaveData(PrefixKey(key), data);
        #else
        PlayerPrefs.SetString(key, data);
        #endif
    }

    public static void SetInt(string key, int data){
        #if UNITY_WEBGL && !UNITY_EDITOR
        aSaveData(PrefixKey(key), data.ToString());
        #else
        PlayerPrefs.SetInt(key, data);
        #endif
    }

    public static void SetFloat(string key, float data){
        #if UNITY_WEBGL && !UNITY_EDITOR
        aSaveData(PrefixKey(key), data.ToString());
        #else
        PlayerPrefs.SetFloat(key, data);
        #endif
    }


    public static string GetString(string key, string defaultValue = ""){
        #if UNITY_WEBGL && !UNITY_EDITOR
        return aLoadData(PrefixKey(key));
        #else
        return PlayerPrefs.GetString(key);
        #endif
    }

    public static int GetInt(string key, int defaultValue = 0){
        #if UNITY_WEBGL && !UNITY_EDITOR
        var data = aLoadData(PrefixKey(key));
        if(data != string.Empty){
            return int.Parse(aLoadData(PrefixKey(key)));
        }

        return defaultValue;

        #else
        return PlayerPrefs.GetInt(key, defaultValue);
        #endif
    }

    public static float GetFloat(string key, float defaultValue = 0){
        #if UNITY_WEBGL && !UNITY_EDITOR
        var data = aLoadData(PrefixKey(key));
        if(data != string.Empty){
            return float.Parse(aLoadData(PrefixKey(key)));
        }

        return defaultValue;
        #else
        return PlayerPrefs.GetFloat(key, defaultValue);
        #endif
    }

    public static bool HasKey(string key){
        #if UNITY_WEBGL && !UNITY_EDITOR
        var data = aLoadData(PrefixKey(key));
        return data != string.Empty;
        #else
        return PlayerPrefs.HasKey(key);
        #endif
    }

    public static void DeleteKey(string key){
        #if UNITY_WEBGL && !UNITY_EDITOR
        aDeleteKey(PrefixKey(key));
        #else
        PlayerPrefs.DeleteKey(key);
        #endif
    }

    [DllImport("__Internal")]
    private static extern void aSaveData(string key, string data);

    [DllImport("__Internal")]
    private static extern string aLoadData(string key);

    [DllImport("__Internal")]
    private static extern string aDeleteKey(string key);

    [DllImport("__Internal")]
    private static extern string aDeleteAllKeys(string prefix);

}
