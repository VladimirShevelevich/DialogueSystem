using System.Collections;
using System.Collections.Generic;
using Content;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    public ContentProvider ContentProvider;
    public Canvas UiCanvas;
    
    void Start()
    {
        var dialogueSystem = new UI.DialogueSystem(ContentProvider, UiCanvas);
    }
}
