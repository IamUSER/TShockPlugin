# VeinMiner 连锁挖矿

- 作者: Megghy|YSpoof|Maxthegreat99|肝帝熙恩
- 出处: [github](https://github.com/Maxthegreat99/TSHockVeinMiner)
- 连锁挖矿，字面意思
- 可以连锁挖一堆矿然后爆指定物品
  
> [!IMPORTANT]
> 启用连锁挖矿需要权限`veinminer`  
> 授权命令: `/group addperm default veinminer`(`default`为默认组，你也可以替换为你需要的组)  


## 指令

| 语法         |    权限     |      说明      |
|------------|:---------:|:------------:|
| /vm        | veinminer |   开关连锁挖矿指令   |
| /vm [任意参数] | veinminer | 开关连锁挖矿提示消息指令 |

## 配置
> 配置文件位置：tshock/VeinMiner.json
```json5
{
  "启用": true,
  "放入背包": true,
  "矿石物块ID": [
    6,
    7,
    8
  ],
  "忽略挖掘表面方块ID": [
    21,
    26,
    88
  ],
  "奖励规则": []
}
```
### 示例
```json5
{
  "启用": true,
  "放入背包": true,
  "矿石物块ID": [
    7,
    6,
    8
  ],
  "忽略挖掘表面方块ID": [
    21,
    26,
    88
  ],
  "奖励规则": [
    {
      "仅给予物品": true,
      "最小尺寸": 10,
      "矿石物块ID": 168,
      "奖励物品": {
        "666": 1,
        "669": 1
      }
    },
    {
      "仅给予物品": true,
      "最小尺寸": 10,
      "矿石物块ID": 8,
      "奖励物品": {
        "662": 5,
        "219": 1
      }
    }
  ]
}
```
## 更新日志

### v1.6.1.0
- 清理一些神秘的ID,卸载命令,移除泥沙、铁链的默认连锁挖矿

### v1.6.0.6
- 修复：背包满的时候去挖达到可获得奖励数量的矿，只会挖掉一个矿，但却会给予一个奖励物品，然后就可以用这个刷奖励
- 完善消息提示逻辑

### v1.6.0.5
- 修复刷矿，添加英文翻译

### v1.6.0.4
- 完善卸载函数

### v1.6.0.3
- 添加配置，当矿石上方有指定方块时，不会触发连锁挖矿（避免刷矿）

## 反馈
- 优先发issued -> 共同维护的插件库：https://github.com/UnrealMultiple/TShockPlugin
- 次优先：TShock官方群：816771079
- 大概率看不到但是也可以：国内社区trhub.cn ，bbstr.net , tr.monika.love
