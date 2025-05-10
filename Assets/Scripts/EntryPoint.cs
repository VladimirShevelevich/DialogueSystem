using System.Collections;
using System.Collections.Generic;
using Content;
using UI;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    public ContentProvider ContentProvider;
    public Canvas UiCanvas;
    
    void Start()
    {
        LevelSetupModel levelSetupModel = new LevelSetupModel();
        var dialogueSystem = new UI.DialogueSystem(ContentProvider, UiCanvas, levelSetupModel);
    }
}
