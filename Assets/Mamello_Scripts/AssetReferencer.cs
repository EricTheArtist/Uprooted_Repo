using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//containing assets to reference them via script instaed of dragging & dropping into components

public class AssetReferencer : MonoBehaviour
{
    private static AssetReferencer internalInstance;

    //instantiating prefab if it doesn't exist yet
    public static AssetReferencer instance
    {
        get
        {
            //if internal reference doesn't exist -> instantiate asset from resources & make reference for this script/class
            if (internalInstance == null) internalInstance = Instantiate(Resources.Load<AssetReferencer>("AssetReferencer"));
            return internalInstance;
        }
    }

    public Transform damagePopup;


}
