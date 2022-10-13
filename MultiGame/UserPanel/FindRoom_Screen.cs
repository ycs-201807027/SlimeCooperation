﻿using MultiGameModule;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiGame.UserPanel
{
    public partial class FindRoom_Screen : UserControl
    {
        private Form1 form;
        public FindRoom_Screen(Form1 form)
        {
            InitializeComponent();
            this.form = form;
        }

        private void enterRoom_btn_Click(object sender, EventArgs e)
        {
            if (roomList_GridView.SelectedRows.Count == 0)
            {
                return;
            }

            // 선택한 방( 행 )의 키를 받음
            int roomKey = int.Parse(roomList_GridView.SelectedRows[0].Cells[0].Value.ToString());

            // 메시지 생성
            MessageGenerator generator = new MessageGenerator(Protocols.REQ_ENTER_ROOM);
            generator.AddInt(roomKey);

            // 서버로 입장 요청
            GameManager.GetInstance().SendMessage(generator.Generate());
        }

        private void findToMain_btn_Click(object sender, EventArgs e)
        {
            // 메시지 생성
            MessageGenerator generator = new MessageGenerator(Protocols.REQ_ROOM_LIST);
            generator.AddBool(false);

            // 서버로 전송
            GameManager.GetInstance().SendMessage(generator.Generate());

            // 메인화면으로 돌아감
            form.ChangeScreen(new MainMenu_Screen(form));
            
        }

        private void roomList_GridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int roomKey = int.Parse(roomList_GridView.SelectedRows[0].Cells[0].Value.ToString());

            // 메시지 생성
            MessageGenerator generator = new MessageGenerator(Protocols.REQ_ENTER_ROOM);
            generator.AddInt(roomKey);

            // 서버로 입장 요청
            GameManager.GetInstance().SendMessage(generator.Generate());
        }
    }
}
