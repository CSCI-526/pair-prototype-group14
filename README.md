# Function Update
## Yanbai Lu Update 2/16
一些enemy相关功能更新：
### 索敌相关：
暂时支持索敌离endTrigger最近的敌人，可切换离塔最近的（PlayerShooting 第40-41行）

### 波次相关：（暂时被覆盖）
支持对每一波怪物的个性化参数配置，包括实体类型，数量，出怪点（可以不是enemySpawner），出怪间隔，出怪路径和与下一波的时间间隔。

### 收尾相关：
在所有怪物被消灭后停止游戏，并调用胜利结算画面。

### 其他：
由于子弹是三角形但碰撞箱是矩形，导致略有不符。我修改了一定的碰撞箱，但依然没有达到完全符合。  


## Yanbai Lu Update 2/17
### UI
Congratulation UI 更新，在游戏胜利后弹出，具有3个功能：
1.restart game
2.quit game
3.return to panel
