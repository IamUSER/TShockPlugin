# Online Gift Package 在线礼包

- Author: Star Night Flower, Yuxue
- Source: [github](https://gitee.com/star-night-flower/tshock-gift)
- This is a TShock server plugin primarily used to distribute random online rewards to players on the server
- After adding items in the [OnlineGiftPackage.json] file, use /Reload in-game to automatically calculate the total probability

## Commands

| Syntax      |        Permission         |      Description       |
|------------|:----------------------:|:-------------------:|
| /onlinegift | OnlineGiftPackage | Display probability table of all items in the gift package |
| /reload    |         None         |    Automatically calculate total probability    |

## Configuration
> Configuration file location: tshock/在线礼包.json
```json5
{
  "Enabled": true,
  "TotalProbability(AutoUpdate)": 60,
  "DistributionInterval/Seconds": 1800,
  "SkipHealthThreshold": 500,
  "LogGiftDistribution": false,
  "GiftList": [
    {
      "ItemName": "Platinum Coin",
      "ItemID": 74,
      "Probability": 1,
      "ItemQuantity": [
        2,
        5
      ]
    }
  ],
    "TriggerSequence": {
    "1": "[c/55CDFF:Server Owner] sent you 1 gift package"
  }
}
```

## Update Log

```
- 1.0.1.2
- Improved unload function

- 1.1.1
- 1. Improved synchronization of "Total Probability" with Reload
- 2. Optimized command display formatting
- 3. Added permission name to command
- 4. Removed "Log non-qualified players" from configuration file
  
- 1.1.0
- 1. Fixed issue where configuration file was overwritten by original config when using /reload or server restart
- 2. Added total probability calculation display to command: /onlinegift
- 3. Using /reload on configuration file will calculate and update "Total Probability" value
- 4. Added "Skip Health Threshold" to configuration to prevent high HP players from receiving online gifts
- 5. Added option to log each gift distribution
- 6. "Log non-qualified players" was for debugging purposes and is not recommended for use
- 7. Players are notified of next gift distribution time after receiving a gift
  
- 1.0.9
- 1. Fixed issue with untimely item distribution
- 2. Removed online time broadcast method
- 3. Added numerous preset item configurations to configuration file
- 4. Fixed issue where /onlinegift command didn't display probabilities
- 5. Changed distribution method to reset to 0+1 after each distribution
- 6. Fixed automatic serialization during configuration initialization
- 7. Added new method for calculating total probability
  
- 1.0.8  
- 1. Added missing variable names to configuration file  
- 2. Added total probability option  
- 3. Players can customize broadcast interval time  
- 4. Further optimized timer
- 5. Adapted for .NET 6.0  
  
- 1.0.7  
- 1. Optimized timer  
- 2. Renamed config file to [OnlineGiftPackage.json] and localized configuration items
```

## Feedback
- Priority: Create an issue -> Shared plugin repository: https://github.com/UnrealMultiple/TShockPlugin
- Secondary: TShock official group: 816771079
- Less likely to be seen but still possible: Domestic communities trhub.cn, bbstr.net, tr.monika.love 