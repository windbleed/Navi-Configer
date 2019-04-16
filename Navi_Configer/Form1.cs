using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;



namespace Navi_Configer
{
    public partial class Form1 : Form
    {
        static int CurrentLampIndex = 0;
        Color SetupColor = new Color();
        NationalInstruments.UI.WindowsForms.Led Target = new NationalInstruments.UI.WindowsForms.Led();

        BoardConfig bc1;
        CMDFrame CF1;
        System.DateTime currentTime;

        public Form1()
        {
            InitializeComponent();

            bc1 = new BoardConfig(this);
            CF1 = new CMDFrame(this);
            currentTime= new System.DateTime(); 
            
        }

        private void Enable_Handle(object sender, object Relative_Lamp)
        {
            NationalInstruments.UI.WindowsForms.Switch SWI = (NationalInstruments.UI.WindowsForms.Switch)sender;
            NationalInstruments.UI.WindowsForms.Led lamp = (NationalInstruments.UI.WindowsForms.Led)Relative_Lamp;
            if (SWI.Value)
            {
                lamp.Value = true;
                lamp.Enabled = true;
                Target = lamp;
            }
            else
            {
                lamp.Value = false;
                lamp.Enabled = false;
            }

        
        }

        private void Enable_Lamp1_StateChanged(object sender, NationalInstruments.UI.ActionEventArgs e)
        {
            Enable_Handle(sender, Lamp1);
        }

        private void lamp1_MouseClick(object sender, MouseEventArgs e)
        {
           
            Target = (NationalInstruments.UI.WindowsForms.Led)sender;
          
        }


        public void lamp_SetColor(NationalInstruments.UI.WindowsForms.Led changer, Color x1)
        {
            (changer).OnColor = x1;

        }

        public byte Lamp_GetColor(NationalInstruments.UI.WindowsForms.Led changer)
        {

            if (changer.OnColor == Color.Red)
                return 0;
            else if (changer.OnColor == Color.Lime)
                return 1;
            else if (changer.OnColor == Color.Blue)
                return 2;
            else if (changer.OnColor == Color.Fuchsia)
                return 4;
            else if (changer.OnColor == Color.Yellow)
                return 3;
            else if (changer.OnColor == Color.Cyan)
                return 5;
            else if (changer.OnColor == Color.White)
                return 6;


            return 0;
        }

        public void Set_BoardID(string x)
        {
            Combo_BoardID.Text = x;
        }

        public byte Get_BoardID()
        {
            byte boardid = 99;

            boardid=Convert.ToByte(Combo_BoardID.Text);
            if ((boardid <= 9) && (boardid >= 1))
                return boardid;

            else 
                return 99;

        }

        public void Set_BoardType(string x)
        {
            if (x == "1")

                Combo_BoardType.Text = "航行灯板";

            else if(x=="2")
                Combo_BoardType.Text = "混合灯板";
        }


        public byte Get_BoardType()
        {
           

           // boardtype = Convert.ToByte(Combo_BoardType.Text);

            if (Combo_BoardType.SelectedIndex == 0)
                return 1;
            else if (Combo_BoardType.SelectedIndex == 1)
                return 2;
            else return 99;
                
                    


        }

        public void Lamp_SetEnable_Onstatus_Byindex(int id, bool enable,bool onstatus)
        {
            switch (id)
            {
                case 0:
                    Enable_Lamp1.Value = enable;
                    Lamp1.Enabled = enable;
                    Lamp1.Value = onstatus;
                    break;
                case 1:
                    Enable_Lamp2.Value = enable;
                    Lamp2.Enabled = enable;
                    Lamp2.Value = onstatus;
                    break;
                case 2:
                    Enable_Lamp3.Value = enable;
                    Lamp3.Enabled = enable;
                    Lamp3.Value = onstatus;
                    break;
                case 3:
                    Enable_Lamp4.Value = enable;
                    Lamp4.Enabled = enable;
                    Lamp4.Value = onstatus;
                    break;
                case 4:
                    Enable_Lamp5.Value = enable;
                    Lamp5.Enabled = enable;
                    Lamp5.Value = onstatus;
                    break;
                case 5:
                    Enable_Lamp6.Value = enable;
                    Lamp6.Enabled = enable;
                    Lamp6.Value = onstatus;
                    break;
                case 6:
                    Enable_Lamp7.Value = enable;
                    Lamp7.Enabled = enable;
                    Lamp7.Value = onstatus;
                    break;
                case 7:
                    Enable_Lamp8.Value = enable;
                    Lamp8.Enabled = enable;
                    Lamp8.Value = onstatus;
                    break;
                case 8:
                    Enable_Lamp9.Value = enable;
                    Lamp9.Enabled = enable;
                    Lamp9.Value = onstatus;
                    break;
                case 9:
                    Enable_Lamp10.Value = enable;
                    Lamp10.Enabled = enable;
                    Lamp10.Value = onstatus;
                    break;
                case 10:
                    Enable_Lamp11.Value = enable;
                    Lamp11.Enabled = enable;
                    Lamp11.Value = onstatus;
                    break;
                case 11:
                    Enable_Lamp12.Value = enable;
                    Lamp12.Enabled = enable;
                    Lamp12.Value = onstatus;
                    break;
                case 12:
                    Enable_Lamp13.Value = enable;
                    Lamp13.Enabled = enable;
                    Lamp13.Value = onstatus;
                    break;
                case 13:
                    Enable_Lamp14.Value = enable;
                    Lamp14.Enabled = enable;
                    Lamp14.Value = onstatus;
                    break;
                case 14:
                    Enable_Lamp15.Value = enable;
                    Lamp15.Enabled = enable;
                    Lamp15.Value = onstatus;
                    break;
                case 15:
                    Enable_Lamp16.Value = enable;
                    Lamp16.Enabled = enable;
                    Lamp16.Value = onstatus;
                    break;
                case 16:
                    Enable_Lamp17.Value = enable;
                    Lamp17.Enabled = enable;
                    Lamp17.Value = onstatus;
                    break;
                case 17:
                    Enable_Lamp18.Value = enable;
                    Lamp18.Enabled = enable;
                    Lamp18.Value = onstatus;
                    break;
                case 18:
                    Enable_Lamp19.Value = enable;
                    Lamp19.Enabled = enable;
                    Lamp19.Value = onstatus;
                    break;
                case 19:
                    Enable_Lamp20.Value = enable;
                    Lamp20.Enabled = enable;
                    Lamp20.Value = onstatus;
                    break;

            }
        }

        public void Lamp_GetEnable_Onstatus_Byindex(int id, ref bool enable, ref bool onstatus)
        {
            switch (id)
            {
                case 0:

                    enable = Lamp1.Enabled;
                    onstatus = Lamp1.Value;
                    break;
                case 1:
                    enable = Lamp2.Enabled;
                    onstatus = Lamp2.Value;
                    break;
                   
                case 2:
                    enable = Lamp3.Enabled;
                    onstatus = Lamp3.Value;
                    break;
                case 3:
                    enable = Lamp4.Enabled;
                    onstatus = Lamp4.Value;
                    break;
                case 4:
                    enable = Lamp5.Enabled;
                    onstatus = Lamp5.Value;
                    break;
                case 5:
                    enable = Lamp6.Enabled;
                    onstatus = Lamp6.Value;
                    break;
                case 6:
                    enable = Lamp7.Enabled;
                    onstatus = Lamp7.Value;
                    break;
                case 7:
                    enable = Lamp8.Enabled;
                    onstatus = Lamp8.Value;
                    break;
                case 8:
                    enable = Lamp9.Enabled;
                    onstatus = Lamp9.Value;
                    break;
                case 9:
                    enable = Lamp10.Enabled;
                    onstatus = Lamp10.Value;
                    break;
                case 10:
                    enable = Lamp11.Enabled;
                    onstatus = Lamp11.Value;
                    break;
                case 11:
                    enable = Lamp12.Enabled;
                    onstatus = Lamp12.Value;
                    break;
                case 12:
                    enable = Lamp13.Enabled;
                    onstatus = Lamp13.Value;
                    break;
                case 13:
                    enable = Lamp14.Enabled;
                    onstatus = Lamp14.Value;
                    break;
                case 14:
                    enable = Lamp15.Enabled;
                    onstatus = Lamp15.Value;
                    break;
                case 15:
                    enable = Lamp16.Enabled;
                    onstatus = Lamp16.Value;
                    break;
                case 16:
                    enable = Lamp17.Enabled;
                    onstatus = Lamp17.Value;
                    break;
                case 17:
                    enable = Lamp18.Enabled;
                    onstatus = Lamp18.Value;
                    break;
                case 18:
                    enable = Lamp19.Enabled;
                    onstatus = Lamp19.Value;
                    break;
                case 19:
                    enable = Lamp20.Enabled;
                    onstatus = Lamp20.Value;
                    break;
            }
        }

        public void Lamp_SetColor_Byindex(int id, Color x1)
        {
         switch (id)
         {
             case 0:
                 Lamp1.OnColor = x1;
                 break;
             case 1:
                 Lamp2.OnColor = x1;
                 break;
             case 2:
                 Lamp3.OnColor = x1;
                 break;
             case 3:
                 Lamp4.OnColor = x1;
                 break;
             case 4:
                 Lamp5.OnColor = x1;
                 break;
             case 5:
                 Lamp6.OnColor = x1;
                 break;
             case 6:
                 Lamp7.OnColor = x1;
                 break;
             case 7:
                 Lamp8.OnColor = x1;
                 break;
             case 8:
                 Lamp9.OnColor = x1;
                 break;
             case 9:
                 Lamp10.OnColor = x1;
                 break;
             case 10:
                 Lamp11.OnColor = x1;
                 break;
             case 11:
                 Lamp12.OnColor = x1;
                 break;
             case 12:
                 Lamp13.OnColor = x1;
                 break;
             case 13:
                 Lamp14.OnColor = x1;
                 break;
             case 14:
                 Lamp15.OnColor = x1;
                 break;
             case 15:
                 Lamp16.OnColor = x1;
                 break;
             case 16:
                 Lamp17.OnColor = x1;
                 break;
             case 17:
                 Lamp18.OnColor = x1;
                 break;
             case 18:
                 Lamp19.OnColor = x1;
                 break;
             case 19:
                 Lamp20.OnColor = x1;
                 break;
            

         }
        }

        public byte Lamp_GetColor_Byindex(int id)
        {
            byte color=0;

            switch (id)
            {
                case 0:
                    color=Lamp_GetColor(Lamp1);
                    break;
                case 1:
                    color = Lamp_GetColor(Lamp2);
                    break;
                case 2:
                    color = Lamp_GetColor(Lamp3);
                    break;
                case 3:
                    color = Lamp_GetColor(Lamp4);
                    break;
                case 4:
                    color = Lamp_GetColor(Lamp5);
                    break;
                case 5:
                    color = Lamp_GetColor(Lamp6);
                    break;
                case 6:
                    color = Lamp_GetColor(Lamp7);
                    break;
                case 7:
                    color = Lamp_GetColor(Lamp8);
                    break;
                case 8:
                    color=Lamp_GetColor(Lamp9);
                    break;
                case 9:
                    color = Lamp_GetColor(Lamp10);
                    break;
                case 10:
                    color = Lamp_GetColor(Lamp11);
                    break;
                case 11:
                    color = Lamp_GetColor(Lamp12);
                    break;
                case 12:
                    color = Lamp_GetColor(Lamp13);
                    break;
                case 13:
                    color = Lamp_GetColor(Lamp14);
                    break;
                case 14:
                    color = Lamp_GetColor(Lamp15);
                    break;
                case 15:
                    color = Lamp_GetColor(Lamp16);
                    break;
                case 16:
                    color = Lamp_GetColor(Lamp17);
                    break;
                case 17:
                    color = Lamp_GetColor(Lamp18);
                    break;
                case 18:
                    color = Lamp_GetColor(Lamp19);
                    break;
                case 19:
                    color = Lamp_GetColor(Lamp20);
                    break;


           




            }


            return color;
        }

        private void LED_RedColor_MouseClick(object sender, MouseEventArgs e)
        {
            SetupColor = Color.Red;
            lamp_SetColor(Target, SetupColor);
            LED_RedColor.Value = true;
        }

        private void LED_LimeColor_MouseClick(object sender, MouseEventArgs e)
        {
            SetupColor = Color.Lime;
            lamp_SetColor(Target, SetupColor);
            LED_LimeColor.Value = true;

        }

        private void LED_BlueColor_MouseClick(object sender, MouseEventArgs e)
        {
            SetupColor = Color.Blue;
            lamp_SetColor(Target, SetupColor);
            LED_BlueColor.Value = true;
        }

        private void LED_PurpleColor_MouseClick(object sender, MouseEventArgs e)
        {
            SetupColor = Color.Fuchsia;
            lamp_SetColor(Target, SetupColor);
            LED_PurpleColor.Value = true;
        }

        private void LED_YellowColor_MouseClick(object sender, MouseEventArgs e)
        {
            SetupColor = Color.Yellow;
            lamp_SetColor(Target, SetupColor);
            LED_YellowColor.Value = true;
        }

        private void LED_CyanColor_MouseClick(object sender, MouseEventArgs e)
        {
            SetupColor = Color.Cyan;
            lamp_SetColor(Target, SetupColor);
            LED_CyanColor.Value = true;
        }

        private void LED_WhiteColor_MouseClick(object sender, MouseEventArgs e)
        {
            SetupColor = Color.White;
            lamp_SetColor(Target, SetupColor);
            LED_WhiteColor.Value = true;
        }

        private void Combo_BoardType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Enable_Lamp2_StateChanged(object sender, NationalInstruments.UI.ActionEventArgs e)
        {
            Enable_Handle(sender, Lamp2);
        }

        private void Enable_Lamp3_StateChanged(object sender, NationalInstruments.UI.ActionEventArgs e)
        {
            Enable_Handle(sender, Lamp3);
        }

        private void Enable_Lamp4_StateChanged(object sender, NationalInstruments.UI.ActionEventArgs e)
        {
            Enable_Handle(sender, Lamp4);
        }

        private void Enable_Lamp5_StateChanged(object sender, NationalInstruments.UI.ActionEventArgs e)
        {
            Enable_Handle(sender, Lamp5);
        }

        private void Enable_Lamp6_StateChanged(object sender, NationalInstruments.UI.ActionEventArgs e)
        {
            Enable_Handle(sender, Lamp6);
        }

        private void Enable_Lamp7_StateChanged(object sender, NationalInstruments.UI.ActionEventArgs e)
        {
            Enable_Handle(sender, Lamp7);
        }

        private void Enable_Lamp8_StateChanged(object sender, NationalInstruments.UI.ActionEventArgs e)
        {
            Enable_Handle(sender, Lamp8);
        }

        private void Enable_Lamp9_StateChanged(object sender, NationalInstruments.UI.ActionEventArgs e)
        {
            Enable_Handle(sender, Lamp9);
        }

        private void Enable_Lamp10_StateChanged(object sender, NationalInstruments.UI.ActionEventArgs e)
        {
            Enable_Handle(sender, Lamp10);
        }

        private void Enable_Lamp11_StateChanged(object sender, NationalInstruments.UI.ActionEventArgs e)
        {
            Enable_Handle(sender, Lamp11);
        }

        private void Enable_Lamp12_StateChanged(object sender, NationalInstruments.UI.ActionEventArgs e)
        {
            Enable_Handle(sender, Lamp12);
        }

        private void Enabble_Lamp13_StateChanged(object sender, NationalInstruments.UI.ActionEventArgs e)
        {
            Enable_Handle(sender, Lamp13);
        }

        private void Enable_Lamp14_StateChanged(object sender, NationalInstruments.UI.ActionEventArgs e)
        {
            Enable_Handle(sender, Lamp14);
        }

        private void Enable_Lamp15_StateChanged(object sender, NationalInstruments.UI.ActionEventArgs e)
        {
            Enable_Handle(sender, Lamp15);
        }

        private void Enable_Lamp16_StateChanged(object sender, NationalInstruments.UI.ActionEventArgs e)
        {
            Enable_Handle(sender, Lamp16);
        }

        private void Enable_Lamp17_StateChanged(object sender, NationalInstruments.UI.ActionEventArgs e)
        {
            Enable_Handle(sender, Lamp17);
        }

        private void Enable_Lamp18_StateChanged(object sender, NationalInstruments.UI.ActionEventArgs e)
        {
            Enable_Handle(sender, Lamp18);
        }

        private void Enable_Lamp19_StateChanged(object sender, NationalInstruments.UI.ActionEventArgs e)
        {
            Enable_Handle(sender, Lamp19);
        }

        private void Enable_Lamp20_StateChanged(object sender, NationalInstruments.UI.ActionEventArgs e)
        {
            Enable_Handle(sender, Lamp20);
        }

        private void OpenConfigFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            openFileDialog1.InitialDirectory = "E:\\Works\\Sea_Feed\\NAVI_Configer\\Navi_Configer\\Navi_Configer\\bin\\Debug";
            openFileDialog1.Filter = "xml files (*.xml)|*.xml";


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                bc1.SetConfigFile(openFileDialog1.FileName);
            }

            bc1.LoadFromFile();
            bc1.SetToUI();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

       

        private void SaveConfig_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefiledialog = new SaveFileDialog();
            savefiledialog.InitialDirectory = "E:\\Works\\Sea_Feed\\NAVI_Configer\\Navi_Configer\\Navi_Configer\\bin\\Debug";
            savefiledialog.Filter = "xml files (*.xml)|*.xml";


            if (savefiledialog.ShowDialog() == DialogResult.OK)
            {
                bc1.SaveToFile(savefiledialog.FileName);
            }

          

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int year, month, day, hour, min, sec;
              
            currentTime=System.DateTime.Now; 
            year=currentTime.Year; 
            month=currentTime.Month; 
            day=currentTime.Day; 
            hour=currentTime.Hour; 
            min=currentTime.Minute; 
            sec=currentTime.Second;

            TimeLable.Text = Convert.ToString(hour) + ":" + Convert.ToString(min) + ":" + Convert.ToString(sec);
            DateLabel.Text = Convert.ToString(year) + "年" + Convert.ToString(month) + "月" + Convert.ToString(day)+"日";

        }



        public string Get_Com_Port()
        {
            if (SerialPortCombo.Text!=null)
                return SerialPortCombo.Text;

            else return null;

        }

        static int event_count = 0;

        private void button2_Click(object sender, EventArgs e)
        {
            ResultLable.Text = "开始配置。。。";
            bc1.LoardFromUI();
            timer2.Enabled = true;
            
        }

        private void SerialPortCombo_Click(object sender, EventArgs e)
        {
            string[] str = System.IO.Ports.SerialPort.GetPortNames();
            if (str == null)
            {
                MessageBox.Show("本机没有串口！", "Error");
                return;
            }

            SerialPortCombo.Items.Clear();
            //添加串口项目  
            foreach (string s in System.IO.Ports.SerialPort.GetPortNames())
            {//获取有多少个COM口  
                SerialPortCombo.Items.Add(s);
            }


            //
        }

        private void PortOpen_Click(object sender, EventArgs e)
        {
           // CF1.CMD_Init();

            if (PortOpen.Text == "打开")
            {
                if (SerialPortCombo.Text != "")
                {


                    if (CF1.CMD_Open_Com())
                        PortOpen.Text = "关闭";
                }

                else
                   MessageBox.Show("Please choice serial port");


            }
            else
            {
                CF1.CMD_Close_Com();
                PortOpen.Text = "打开";
            }

            


        }

        static int Exchange_CFG_Status = 0;

        private void timer2_Tick(object sender, EventArgs e)
        {

             bool Respond_OK = false;

             switch (Exchange_CFG_Status)
             {
                 case 0:

                     CF1.Send_CFG_BoardID(bc1.BoardID);

                     Exchange_CFG_Status = 1;
                     
                     break;
                 
                 case 1:
                     
                     Respond_OK=CF1.Get_CFG_BoardID_RES();

                     if (Respond_OK)
                         Exchange_CFG_Status = 2;

                     else
                         Exchange_CFG_Status = 0;


                     break;


                 case 2:

                     CF1.Send_CFG_BoardType(bc1.BoardType);
                     Exchange_CFG_Status = 3;
                     break;


                 case 3:

                     Respond_OK=CF1.Get_CFG_BoardType_RES();

                     if (Respond_OK)
                         Exchange_CFG_Status = 4;

                     else
                         Exchange_CFG_Status = 2;


                     break;




                 case 4:
                     CF1.Send_CFG_Enable(bc1.LampEnable);
                     Exchange_CFG_Status = 5;
                     break;


                 case 5:
                     Respond_OK=CF1.Get_CFG_Enable_RES();

                     if (Respond_OK)
                         Exchange_CFG_Status = 6;

                     else
                         Exchange_CFG_Status = 4;


                     break;


                 case 6:
                     CF1.Send_CFG_OnStatus(bc1.LampOnstatus);
                     Exchange_CFG_Status = 7;
                     break;

                 case 7:
                      Respond_OK=CF1.Get_CFG_OnStatus_RES();

                     if (Respond_OK)
                         Exchange_CFG_Status = 8;

                     else
                         Exchange_CFG_Status = 6;


                     break;

                 case 8:
                      CF1.Send_CFG_Color(bc1.LampColor);
                      Exchange_CFG_Status = 9;
                      break;

                 case 9:
                      Respond_OK=CF1.Get_CFG_Color_RES();

                     if (Respond_OK)
                         Exchange_CFG_Status = 10;

                     else
                         Exchange_CFG_Status = 8;


                     break;
                 case 10:
                      CF1.Send_CFG_FlashStatus(bc1.LampFlashStatus);
                      Exchange_CFG_Status = 11;
                      break;

                 case 11:
                      Respond_OK = CF1.Get_CFG_FlashStatus_RES();

                      if (Respond_OK)
                          Exchange_CFG_Status = 12;

                      else
                          Exchange_CFG_Status = 10;


                      break;

                 case 12:
                        
                      //MessageBox.Show("配置文件传输成功！");

                      ResultLable.Text = "配置成功！";
                      Exchange_CFG_Status = 0;
                      timer2.Enabled = false;
                      timer2.Stop();

                      break;

             }

           

        }

        private void TimeSetupMenu_Click(object sender, EventArgs e)
        {

            int year, month, day, hour, min, sec;
          
            byte[] Time = new byte[6];
            byte[] Date = new byte[6];


            currentTime = System.DateTime.Now;
            year = currentTime.Year;
            month = currentTime.Month;
            day = currentTime.Day;
            hour = currentTime.Hour;
            min = currentTime.Minute;
            sec = currentTime.Second;

           

            Time[0] = ((byte)(hour/10+0x30));
            Time[1] = ((byte)(hour % 10 + 0x30));

            Time[2] = ((byte)(min / 10 + 0x30));
            Time[3] = ((byte)(min % 10 + 0x30));

            Time[4] = ((byte)(sec / 10 + 0x30));
            Time[5] = ((byte)(sec % 10 + 0x30));

            Date[0] = ((byte)(day / 10 + 0x30));
            Date[1] = ((byte)(day% 10 + 0x30));

            Date[2] = ((byte)(month/ 10 + 0x30));
            Date[3] = ((byte)(month % 10 + 0x30));

            Date[4] = ((byte)((year % 100) / 10 + 0x30));
            Date[5] = ((byte)((year % 100) % 10 + 0x30));

        

            CF1.Send_RMC_Time(Time, Date);


        }

       
    }
}
