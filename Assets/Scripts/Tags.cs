using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tags : MonoBehaviour
{
    //Tags
    static string PLAYER_TAG = "Player";
    public static string GET_PLAYER_TAG { get {return PLAYER_TAG; } }
    static string COLLECTABLE_TAG = "Collectable";
    public static string GET_COLLECTABLE_TAG { get { return COLLECTABLE_TAG; } }
    static string CHECK1_TAG = "Check 1";
    public static string GET_CHECK1_TAG { get { return CHECK1_TAG; } }

    //Animator Tags
    static string START_GAME_TAG = "startGame";
    public static string GET_START_GAME_TAG { get { return START_GAME_TAG; } }

    //SceneLoader Tags
    static string MAIN_MENU_TAG = "Main Menu";
    public static string GET_MAIN_MENU_TAG { get { return MAIN_MENU_TAG; } }
    static string GAME_SCENE_TAG = "Level 1";
    public static string GET_GAME_SCENE_TAG { get { return GAME_SCENE_TAG; } }
    static string SELECETION_MENU_TAG = "Selection Menu";
    public static string GET_SELECETION_MENU_TAG { get { return SELECETION_MENU_TAG; } }

    //PlayerPref Tags
    static string SELECTED_SKYBOX_TAG = "Selected SkyBox";
    public static string GET_SELECTED_SKYBOX_TAG { get { return SELECTED_SKYBOX_TAG; } }
    static string HIGHSCORE_TAG = "Highscore";
    public static string GET_HIGHSCORE_TAG { get { return HIGHSCORE_TAG; } }

}
