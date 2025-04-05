# Goodnight 宵禁
- Author: Jonesn, Yuxue, Shaosiming
- Source: None
- Prohibits server entry or monster summoning during specified times each day (automatically allows monster summoning when online player count is met)
- This plugin integrates features like whitelist, curfew, and monster summoning restrictions
- During curfew hours, it determines whether to allow summoning of defeated or undefeated monsters based on online player count
- When online player count and curfew conditions are met:
- Compares NPC death events with monster IDs in the [Banned Monsters List], automatically adding to the [Allowed Summon List] based on kill count
- Facilitates allowing players to summon specific monsters during curfew hours, preventing single players from advancing server progress
- When online player count doesn't meet the [Required Players to Disable Monster Ban]:
- Players must be in the designated [Summoning Area] Region to summon monsters from the [Allowed Summon List]

## Commands

| Syntax                    |          Aliases          |         Permission         |          Description          |
|-------------------------|:------------------------:|:------------------------:|:---------------------------:|
| /gn                     |         /curfew          |   goodnight.admin        |       View curfew command menu      |
| /gn list                |           None           |   goodnight.admin        |       List all curfew tables       |
| /reload                 |           None           |  tshock.cfg.reload       |        Reload configuration        |
| /gn on                  |           None           |   goodnight.admin        |      Toggle curfew functionality      |
| /gn kick                |           None           |   goodnight.admin        |      Toggle disconnect functionality      |
| /gn pos                 |           None           |   goodnight.admin        |       Toggle summoning area       |
| /gn all                 |           None           |   goodnight.admin        |    Toggle requiring all players in summoning area    |
| /gn clear               |           None           |   goodnight.admin        |    Clear monster IDs from [Allowed Summon List]    |
| /gn boss count          |           None           |   goodnight.admin        |  Set kill count requirement for [Allowed Summon List]   |
| /gn reset MonsterID     |           None           |   goodnight.admin        |   Reset monster ID in [Allowed Summon List]   |
| /gn plr count           |           None           |   goodnight.admin        |   Set online player count to ignore [Banned Monsters List]    |
| /gn add/del MonsterName |           None           |   goodnight.admin        |   Add or remove specified player to disconnect whitelist    |
| /gn plr add/del PlayerName |           None           |   goodnight.admin        |  Add or remove specified monster to [Banned Monsters List]   |
| /gn time a & b 23:59    | /gn time start & stop    |   goodnight.admin        |      Set curfew start and end time      |
| /region define SummonArea |           None           | tshock.admin.region      | Use TShock's /Region command to set summoning area |

## Configuration
> Configuration file location: tshock/宵禁.json
```json5
{
  "DisableCurfew": true,
  "CurfewTimeSettings(MonsterBan/Disconnect)": {
    "Start": "00:00:00",
    "Stop": "23:59:59"
  },
  "EnableDisconnect": false,
  "ServerEntryBlockMessage": "Server is currently in curfew hours, unable to join the game.",
  "DisconnectKickMessage": "It's time, good night",
  "DisconnectWhitelist": [
    "Yuxue"
  ],
  "RequiredPlayersToDisableMonsterBan(Set1ToDisable)": 3,
  "EnableSummoningArea": false,
  "OnlyBroadcastBossOrNonBoss": true,
  "DisableBroadcastTypeSwitching": true,
  "SummoningAreaName": "SummoningArea",
  "RequireAllPlayersInSummoningArea": true,
  "KillCountForAllowedSummonList": 2,
  "ResetMonsterIDForAllowedSummonList": 398,
  "AllowedSummonList(AutomaticallyPopulatedFromBanList)": [
    4
  ],
  "BannedMonstersList(NpcID)": [
    4,
    13,
    14,
    15,
    35,
    36,
    50,
    113,
    114,
    125,
    126,
    127,
    128,
    129,
    130,
    131,
    134,
    135,
    136,
    222,
    245,
    246,
    247,
    248,
    249,
    262,
    266,
    370,
    396,
    397,
    398,
    400,
    439,
    440,
    422,
    493,
    507,
    517,
    636,
    657,
    668
  ]
}
```

## Update Log

```
v2.7.3
- Fixed some broadcast formatting
- Added command to clear [Allowed Summon List] (/gn clear)

v2.7.2
- Fixed issue where created configuration had no parameters when no config file was detected
- Fixed issue where parameters were overwritten when using /reload

v2.7.1
- Optimized empty check for [Allowed Summon List] broadcast details

v2.7.0
- Added broadcast type switching
(To fix broadcast spam issues caused by naturally spawning monsters in banned list)
- When [Only Broadcast Boss or Non-Boss] is true, only boss spawn events are broadcast
- When [Disable Broadcast Type Switching] is true, default behavior is restored

v2.6.0
- Modified summoning area logic (no longer disables kill count)
- Automatically adds IDs to [Allowed Summon List] from [Banned Monsters List] based on kill count
- Allows summoning in [Summoning Area] based on IDs in [Allowed Summon List]
- Added toggle for requiring all players in summoning area:
- When enabled, all online players must be in summoning area to summon bosses
- Or one player in summoning area while others can be anywhere
- Added configuration option to customize summoning area region name

v2.5.0
- Optimized command methods
- Added [Summoning Area] (toggle for two different logics)
- When enabled, disables original kill count [Allowed Summon List] feature
- Requires all online players to be in summoning area to summon monsters
- Otherwise, must wait for curfew to end or meet required player count
- Note: Use TShock's /Region command to create a region named "Summoning Area"

v2.4.0
- Added kill count tracking for [Banned Monsters List]
- Automatically adds to [Allowed Summon List] based on kill count
- Counts are tracked when online player count meets requirements or outside curfew hours
- Automatically tracks kills of monsters in [Banned Monsters List] (no manual entry needed)
- Added configuration option and command to control which monster ID resets [Allowed Summon List]

v2.3.0
- Added ability to summon defeated monsters during curfew
- Monitors monster death events to update [Defeated Progress Restriction] configuration
- Automatically clears [Defeated Progress Restriction] after Moon Lord is defeated

v2.2.1
- Fixed issue with command overwriting parameters when removing built-in "collection type" parameters
- Fixed issue where server restart would overwrite configuration parameters

v2.2.0
- Fixed issue where Reload would overwrite monster IDs
- Added permission check to broadcast update method
- Added /gn command method to control configuration options

v2.1.1
- Removed unused code
- Added full check for player disconnection

v2.1.0
- Fixed server entry interception method
- Added online player count check for monster summoning restrictions
- Added descriptions to configuration options
- Organized banned monster list with full progression boss NPC IDs
- Fixed issue where monster IDs were written on every /Reload

v2.0.0
- Added monster summoning restriction logic
- Adapted for .NET 6.0 and refactored most methods
```

## Feedback
- Shared plugin repository: https://github.com/UnrealMultiple/TShockPlugin
- Domestic community: trhub.cn or TShock official group 