using System;

[Serializable]
public class Dialogue
{
    public string name;
    public string sprite;
    public string text;
}

[Serializable]
public class DialogueList
{
    public Dialogue[] dialogues;
}