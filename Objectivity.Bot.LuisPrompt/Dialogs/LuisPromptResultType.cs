namespace Objectivity.Bot.LuisPrompt.Dialogs
{
    using System;

    [Serializable]
    public enum LuisPromptResultType
    {
        TooManyAttempts,
        Yes,
        No,
        LuisResult
    }
}