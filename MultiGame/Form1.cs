using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Input;
using MultiGame.Client;
using MultiGame.UserPanel;
using MultiGameModule;

namespace MultiGame
{
    public partial class Form1 : Form
    {

        #region 멤버변수

        GameManager gameManager;
        #endregion

        public Form1()
        {
            InitializeComponent();
            
            // 최적화
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            gameManager = GameManager.GetInstance();

            this.Controls.Add(new MainMenu_Screen(this));
            
        }

        // 폼이 완전히 로드되었을 때 호출
        private void Form1_Load(object sender, EventArgs e)
        {
            gameManager.Start(this);
        }


        #region UI관련


        // 키가 눌렸을 때
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // 사용자 캐릭터
            UserClient userClient = gameManager.userClient;

            // 게임이 시작하지 않았다면 키 입력을 처리할 필요가 없음
            if (gameManager.IsGameStart == false)
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }

            MessageGenerator generator = new MessageGenerator(Protocols.C_KEY_INPUT);

            switch (keyData)
            {
                case Keys.Left:
                    if(userClient.LeftDown == false)
                    {
                        userClient.LeftDown = true;
                        generator.AddByte(Keyboards.LEFT_ARROW).AddBool(true);
                        gameManager.SendMessage(generator.Generate());
                    }
                    break;
                case Keys.Right:
                    if(userClient.RightDown == false)
                    {
                        userClient.RightDown = true;
                        generator.AddByte(Keyboards.RIGHT_ARROW).AddBool(true);
                        gameManager.SendMessage(generator.Generate());
                    }
                    break;
                case Keys.Space:
                    userClient.Jump();
                    userClient.JumpDown = true;
                    break;
                case Keys.Up:
                    gameManager.userClient.Interaction();
                    break;
                case Keys.R:
                    {
                        generator.AddByte(Keyboards.RESTART).AddBool(true);
                        gameManager.SendMessage(generator.Generate());
                    }
                    break;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);

            }
            

            return true;
        }

        // 키가 떼어졌을 때
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            // 사용자 캐릭터
            UserClient userClient = gameManager.userClient;

            // 게임이 시작하지 않았다면 키 입력을 처리할 필요가 없음
            if (gameManager.IsGameStart == false)
            {
                return;
            }

            MessageGenerator generator = new MessageGenerator(Protocols.C_KEY_INPUT);

            switch (e.KeyData)
            {
                case Keys.Left:
                    if(userClient.LeftDown == true)
                    {
                        userClient.LeftDown = false;
                        generator.AddByte(Keyboards.LEFT_ARROW).AddBool(false);
                        gameManager.SendMessage(generator.Generate());
                    }
                    break;
                case Keys.Right:
                    if(userClient.RightDown == true)
                    {
                        userClient.RightDown = false;
                        generator.AddByte(Keyboards.RIGHT_ARROW).AddBool(false);
                        gameManager.SendMessage(generator.Generate());
                    }
                    break;
                case Keys.Space:
                    userClient.JumpDown = false;
                    break;
                default:
                    break;
            }
        }

        // 폼의 포커스가 풀리면 ( 알트 탭, 다른 윈도우 선택시 ) 이벤트 발생
        private void Form1_Deactivate(object sender, EventArgs e)
        {
            // 사용자 캐릭터
            UserClient userClient = gameManager.userClient;

            // 게임이 시작하지 않았다면 키 입력을 처리할 필요가 없음
            if (gameManager.IsGameStart == false)
            {
                return;
            }

            // 입력중인 키 모두 해제
            userClient.LeftDown = false;                                                            
            userClient.RightDown = false;                                                           
            userClient.JumpDown = false;
        }
        
        // 보여질 화면 변경
        public void ChangeScreen(UserControl newScreen)
        {
            Control[] array = new Control[Controls.Count];
            Controls.CopyTo(array, 0);
            foreach(var item in array)
            {
                item.Dispose();
            }

            this.Controls.Add(newScreen);
        }


        #endregion

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = new ExitProgram_Form().ShowDialog();

                if (result == DialogResult.No)
                    e.Cancel = true;
            }

        }
    }

    
}