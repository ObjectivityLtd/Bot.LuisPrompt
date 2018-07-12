# Bot.LuisPrompt

[![Build status](https://ci.appveyor.com/api/projects/status/02mi9wwval2610xd?svg=true)](https://ci.appveyor.com/project/ObjectivityAdminsTeam/bot-common-dialogs)

A mixture of choice and confirm prompt. Capable of detecting not only Yes/No responses but also several others using LUIS service.

## Usage

### Call

This class can be used in the same way as you use Prompt from Bot Builder library.
The only difference is that you need to pass the LUIS Service that checks the result.

```cs
LuisPrompt.Confirm(luisService, context, Resume, "What would you do now?", 1, tooManyAttempts: "I have no idea what you meant");
```

You can also list LUIS Intents that should be interpreted as known responses (all the others will trigger reprompt):

```cs
LuisPrompt.Confirm(luisService, context, Resume, "What would you do now?", 1, tooManyAttempts: "I have no idea what you meant", luisIntents: new[] { "Nevermind", "Maybe" });
```

### Return result

The callback to Confirm method should have the following signature:

```cs
private static async Task Resume(IDialogContext context, IAwaitable<LuisPromptResult> result)
```

Returned value can be one of the following cases:

* Yes or No - equivalent to true or false values returned by Bot Builder prompt
* LuisResult - in case the prompt understood another acceptable response, then you need to check LuisResult property to know which one it was
* TooManyAttempts - equivalent to TooManyAttempts exception thrown by Bot Builder prompt; unlike Bot Builder implementation, LuisPrompt does not throw exception after too many attempts but returns this result type instead