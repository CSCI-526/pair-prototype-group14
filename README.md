# Function Update
！！ 若git pull后因enemy Spawner未配置导致游戏无法运行，请参照如下图片右侧进行配置
![image](https://github.com/user-attachments/assets/afdce1dc-752a-4b2f-879f-bbdd451bf6e1)
![image](https://github.com/user-attachments/assets/449d6044-9d0d-4916-a27f-d3b99ccdce57)

## Yanbai Lu Update 2/16
一些enemy相关功能更新：
### 索敌相关：
暂时支持索敌离endTrigger最近的敌人，可切换离塔最近的（PlayerShooting 第40-41行）

### 波次相关：（重新上线）
支持对每一波怪物的个性化参数配置，包括实体类型，数量，出怪点（可以不是enemySpawner），出怪间隔，出怪路径和与下一波的时间间隔。

### 收尾相关：
在所有怪物被消灭后停止游戏，并调用胜利结算画面。

### 其他：
由于子弹是三角形但碰撞箱是矩形，导致略有不符。我修改了一定的碰撞箱，但依然没有达到完全符合。
<br><br>
## Yanbai Lu Update 2/17
### UI
Congratulation UI 更新，在游戏胜利后弹出，具有3个功能：<br>
1.restart game<br>
2.quit game<br>
3.return to panel<br>

## Yanbai Lu Update 2/19
enemy相关debug，并重新上线了2/16的功能2
### debug
1.解决了 wave2 怪物莫名旋转的问题<br>
2.解决了 wave2 和 wave3 怪物在endTrigger附近互相碰撞的问题

### 其他
调整了sorry you lose的颜色，与congratulation区分<br>
调整了wayfinding的部分，使其更标准化<br>
调整了enemySpawner和EndTrigger的位置，使用户体验更佳<br>


