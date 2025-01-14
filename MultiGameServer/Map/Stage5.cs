using MultiGameServer.Object;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiGameServer
{
    class Stage5 : MapBase
    {
        private TimerBox timerBox1 = null;
        public Stage5(Room room) : base(room)
        {
            _skin = 1;
        }
        protected override void SetSpawnLocation() // 플레이어 시작 좌표
        {
            SpawnLocation[0] = new Point(0, 740);
            SpawnLocation[1] = new Point(100, 740);
            SpawnLocation[2] = new Point(200, 740);
        }

        public override void Start()
        {
            base.Start();
            timerBox1.TimerStart();
        }

        protected override void DesignMap()
        {
            int tempKey;

            // 맵 바깥 벽 (왼)
            tempKey = room.NextObjKey;
            Floor leftWall = new Floor(room, tempKey, new Point(-11, 0), new Size(10, 865));
            leftWall.SkinNum = -1;
            objectManager.AddObject(leftWall);

            // 맵 바깥 벽 (우)
            tempKey = room.NextObjKey;
            Floor rightWall = new Floor(room, tempKey, new Point(1424, 0), new Size(10, 865));
            rightWall.SkinNum = -1;
            objectManager.AddObject(rightWall);

            // 땅
            tempKey = room.NextObjKey;
            Floor Floor = new Floor(room, tempKey, new Point(0, 800), new Point(960, 865));
            Floor.SkinNum = 1;
            objectManager.AddObject(Floor);

            tempKey = room.NextObjKey;
            Floor Floor2 = new Floor(room, tempKey, new Point(500, 759), new Size(40, 40));
            Floor2.SkinNum = 1;
            objectManager.AddObject(Floor2);

            // 중간 바닥
            tempKey = room.NextObjKey;
            Floor Floor3 = new Floor(room, tempKey, new Point(220, 480), new Size(795, 40));
            Floor3.SkinNum = 1;
            objectManager.AddObject(Floor3);


            // 오른쪽 계단
            tempKey = room.NextObjKey;
            Floor Floor5 = new Floor(room, tempKey, new Point(960, 745), new Size(50, 120));
            Floor5.SkinNum = 1;
            objectManager.AddObject(Floor5);

            tempKey = room.NextObjKey;
            Floor Floor6 = new Floor(room, tempKey, new Point(1010, 690), new Size(50, 175));
            Floor6.SkinNum = 1;
            objectManager.AddObject(Floor6);

            tempKey = room.NextObjKey;
            Floor Floor7 = new Floor(room, tempKey, new Point(1060, 635), new Size(50, 230));
            Floor7.SkinNum = 1;
            objectManager.AddObject(Floor7);

            tempKey = room.NextObjKey;
            Floor Floor8 = new Floor(room, tempKey, new Point(1110, 580), new Size(50, 285));
            Floor8.SkinNum = 1;
            objectManager.AddObject(Floor8);

            tempKey = room.NextObjKey;
            Floor Floor9 = new Floor(room, tempKey, new Point(1160, 525), new Size(280, 340));
            Floor9.SkinNum = 1;
            objectManager.AddObject(Floor9);

            // 열쇠 있는쪽 바닥
            tempKey = room.NextObjKey;
            Floor Floor13 = new Floor(room, tempKey, new Point(475, 310), new Size(400, 40));
            Floor13.SkinNum = 1;
            objectManager.AddObject(Floor13);

            // 열쇠 있는 쪽 기둥
            tempKey = room.NextObjKey;
            Floor Floor14 = new Floor(room, tempKey, new Point(435, 180), new Size(40,170));
            Floor14.SkinNum = 1;
            objectManager.AddObject(Floor14);

            // 왼쪽 계단
            tempKey = room.NextObjKey;
            Floor Floor15 = new Floor(room, tempKey, new Point(0, 240), new Size(56, 280));
            Floor15.SkinNum = 1;
            objectManager.AddObject(Floor15);

            tempKey = room.NextObjKey;
            Floor Floor16 = new Floor(room, tempKey, new Point(56, 280), new Size(54, 240));
            Floor16.SkinNum = 1;
            objectManager.AddObject(Floor16);

            tempKey = room.NextObjKey;
            Floor Floor17 = new Floor(room, tempKey, new Point(110, 320), new Size(55, 200));
            Floor17.SkinNum = 1;
            objectManager.AddObject(Floor17);

            tempKey = room.NextObjKey;
            Floor Floor18 = new Floor(room, tempKey, new Point(165, 360), new Size(55, 160));
            Floor18.SkinNum = 1;
            objectManager.AddObject(Floor18);


            // 문 있는 땅
            tempKey = room.NextObjKey;
            Floor Floor20 = new Floor(room, tempKey, new Point(200, 175), new Size(1240, 40));
            Floor20.SkinNum = 1;
            objectManager.AddObject(Floor20);

            tempKey = room.NextObjKey;
            Stone stone1 = new Stone(room, tempKey, new Point(680, 414), new Size(40, 65));
            stone1.weight = 3;
            objectManager.AddObject(stone1);

            // 타이머
            tempKey = room.NextObjKey;
            TimerBox timerBox = new TimerBox(room, tempKey, new Point(645, 0), new Size(150, 80));
            timerBox.StartTime = 40000;
            this.timerBox1 = timerBox;
            timerBox.SetTimerStopAction(delegate () {
                    room.AllDie();
            });
            objectManager.AddObject(timerBox);

            // 문
            tempKey = room.NextObjKey;
            Door door = new Door(room, tempKey, new Point(1323, 87), new Size(70, 88));
            objectManager.AddObject(door);

            // 열쇠
            tempKey = room.NextObjKey;
            KeyObject KeyObject = new KeyObject(room, tempKey, new Point(500, 220), new Size(35, 50));
            objectManager.AddObject(KeyObject);
        }
    }
}