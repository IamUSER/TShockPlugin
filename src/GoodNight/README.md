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

## 更新日志

```
v2.7.3
修正一些广播格式
加入了清理《允许召唤表》的指令（/gn clear）

v2.7.2
修复检测到没有配置文件时，创建的配置没有参数
不会因为使用/reload重复写入或覆盖原来参数等问题

v2.7.1
优化了对《允许召唤表》播报细节的空检查

v2.7.0
加入了播报类型切换
(用于修复禁怪表含有自然刷新怪的情况导致广播刷屏问题)
【只播报BOSS或非BOSS】为true则只播报BOSS生成事件，反之只播报非BOSS
【关闭切换播报类型】为true则恢复默认，false则启动上面这个判断


v2.6.0
修改召唤区逻辑（不再关闭击杀计数）
通过击杀计数从《禁召表》获取ID添加到《可召表》
通过《可召表》的ID，允许《召唤区》内召唤。
添加了切换召唤区是否需要所有人判定:
启用则需所有在线人数到召唤区才能召唤出BOSS
或者有一人在召唤区，其他人在任意位置都可以召唤BOSS
可通过配置项自定义召唤区的region领地名

v2.5.0
优化了指令方法
加入了【允许召唤区】（用于切换2种逻辑的开关）
当开启功能时，则关闭原有击杀计数《允许召唤怪物表》功能
且所有在线玩家处于召唤区才能召唤怪物
否则需等宵禁时间过期或满足指定在线人数解禁
关闭后恢复原有宵禁逻辑
PS：需用TS自带的/Region指令创建名为"召唤区"的领地

v2.4.0
加入了根据击杀《禁止怪物生成表》计数，
写入《允许召唤怪物表》与其相关指令
计数要求则在满足在线人数或不在宵禁时间段
由玩家主动击杀存在《禁止怪物生成表》的怪物自动计入（无需手写）
加个配置项与指令，控制击杀什么怪物ID来重置《允许召唤怪物表》

v2.3.0
加入宵禁时间内可召唤已击败怪物
通过监听怪物死亡事件从禁止怪物表中
取值后比对赋值给"已击败进度限制"配置项实现
击败月总后自动清空"已击败进度限制"配置项

v2.2.1
修复移除内置配置项的"集合型"参数引起的指令覆盖参数问题
修复重启服务器覆盖配置参数的问题

v2.2.0
彻底修复Reload覆盖写入怪物ID问题
给弹幕更新方法补充了权限检查
加入了/gn 指令方法控制配置项

v2.1.1
清除无用代码，给断开玩家连接加入全检查

v2.1.0
修复玩家加入服务器拦截方法
加入在线人数判断禁止召唤怪物
将配置项加以描述，并把禁怪物表整理为全进度BOSS的NpcID
修复每次/Reload都会写入一次内置怪物ID问题

v2.0.0
加入了禁止召唤怪物逻辑
羽学适配了.net6.0并重构了大部分方法
```


## 反馈
- 共同维护的插件库：https:- 国内社区trhub.cn 或 TShock官方群等
