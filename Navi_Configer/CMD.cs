using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Navi_Configer
{
  

    class CMDFrame
    {
        byte StartSymbol=0x24;              //'$'
        byte CMD_CFG_Main=0x01;
        byte CMD_CFG_Sub=0x00;
        byte[] CMD_Info=new byte[20];
        byte EndSymbol = 0x2A;              //'*' 
        byte CheckSum=0x00;   
        byte CheckSum_high_asc=0x00;
        byte CheckSum_low_asc = 0x00;
        byte ReturnSymbo=0x0D;
        byte ChangeLineSymbo=0x0A;

        byte CMD_Info_Length=0x00;
        
        byte[] Transmit_Buf=new byte[100];

        //$GPRMC,093408.00,V,,,,,,,060818,,,N*7C

        char[] CMD_RMC_Pre = { 'G', 'P', 'R', 'M', 'C' };
        char CMD_Seporator_1= ',';
        byte[] RMC_Time_Buf = new byte[6];
        char CMD_Seporator_2 = '.';
        char CMD_MicroSec1 = '0';
        char CMD_MicroSec2 = '0';
        char CMD_Verify = 'V';
        byte[] RMC_Date_Buf = new byte[6];
        char CMD_Time_North = 'N';
        




        Form1 FormUI;
        USARTClass uc1=null;

        public CMDFrame(Form1 x1)
        {
            FormUI = x1;
            Transmit_Buf = new byte[100];
        }

        public void CMD_Init()
        {

            if ((FormUI.Get_Com_Port() != null)&&(uc1==null))
            {
                uc1 = new USARTClass(FormUI.Get_Com_Port());

            }
            
        }

        public bool CMD_Open_Com()
        {
            if (FormUI.Get_Com_Port() != null) 
            {
                uc1 = new USARTClass(FormUI.Get_Com_Port());

            }
            
            return uc1.openPort();
        }

        public void  CMD_Close_Com()
        {
            if(uc1!=null)
                uc1.closePort();
            uc1 = null;
        }

        void Calc_CheckSum(int info_lenght)
        {
            byte temp=(byte)((int)CMD_CFG_Main^(int)CMD_CFG_Sub);
            for (int i = 0; i < info_lenght; i++)
            {
                temp = (byte)((int)temp ^ (int)CMD_Info[i]);

            }

            CheckSum=temp;

            temp=(byte)((int)(temp>>4)&0x0f);

            if ((temp>=0)&&(temp<=9))
                temp=(byte)((int)temp+'0');

            else if((temp>=10)&&(temp<=15))
                temp=(byte)((int)temp+'A'-10);


            CheckSum_high_asc = temp;

            temp = CheckSum;

            temp = (byte)((int)temp  & 0x0f);

            if ((temp >= 0) && (temp <= 9))
                temp = (byte)((int)temp + '0');

            else if ((temp >= 10) && (temp <= 15))
                temp = (byte)((int)temp + 'A'-10);


            CheckSum_low_asc = temp;


        }

       

        void Send_Frame()
        {
            Transmit_Buf[0] = StartSymbol;
            Transmit_Buf[1] = CMD_CFG_Main;
            Transmit_Buf[2] = CMD_CFG_Sub;
            

            for(int i=0;i<CMD_Info_Length;i++)
            {
                Transmit_Buf[i + 3] = CMD_Info[i];
           
            }
            Transmit_Buf[CMD_Info_Length + 3] = EndSymbol;

            Transmit_Buf[CMD_Info_Length + 4] = CheckSum_high_asc;

            Transmit_Buf[CMD_Info_Length + 5] = CheckSum_low_asc;
            Transmit_Buf[CMD_Info_Length + 6] = ReturnSymbo;
            Transmit_Buf[CMD_Info_Length + 7] = ChangeLineSymbo;
            if (uc1==null) return ;
            uc1.SendData(Transmit_Buf, 0, CMD_Info_Length + 8);

           // uc1.closePort();
        }

        public void Send_CFG_BoardID(byte bid)
        {
            CMD_CFG_Sub=0x01;
            CMD_Info[0]=bid;
            CMD_Info_Length=1;
            Calc_CheckSum(CMD_Info_Length);

            Send_Frame();

            
        }

        public bool Get_CFG_BoardID_RES()
        {
            if (uc1 == null) return false;

            if (uc1.IsReceived)
            {
                if (uc1.ReceiveStr == "CFG BdID OK\r\n")
                {
                    uc1.IsReceived = false;

                    return true;
                }
            }
                
            return false;
        }





        public void Send_CFG_BoardType(byte btype)
        {
            CMD_CFG_Sub=0x02;
            CMD_Info[0]=btype;
            CMD_Info_Length=1;
            Calc_CheckSum(CMD_Info_Length);

            Send_Frame();
        }

        public bool Get_CFG_BoardType_RES()
        {

            if (uc1 == null) return false;

            if (uc1.IsReceived)
            {
                if (uc1.ReceiveStr == "CFG BdType OK\r\n")
                {
                    uc1.IsReceived = false;
                    return true;
                }

            }
            return false;
        }
               

        public void Send_CFG_Enable(byte[] enable_array )
        {
            CMD_CFG_Sub=0x04;
            CMD_Info[0]=enable_array[0];
            CMD_Info[1]=enable_array[1];
            CMD_Info[2]=(byte)((int)enable_array[2]&0x0f);
            CMD_Info_Length=3;
            Calc_CheckSum(CMD_Info_Length);

            Send_Frame();

        }

        public bool Get_CFG_Enable_RES()
        {
            if (uc1 == null) return false;
            if (uc1.IsReceived)
            {
                if (uc1.ReceiveStr == "CFG Enable OK\r\n")
                {
                    uc1.IsReceived = false;
                    return true;
                }

            }
            return false;
        }

        public void Send_CFG_OnStatus(byte[] onstatus_array)
        {
            CMD_CFG_Sub=0x03;
            CMD_Info[0]=onstatus_array[0];
            CMD_Info[1]=onstatus_array[1];
            CMD_Info[2] = (byte)((int)onstatus_array[2] & 0x0f);
            CMD_Info_Length=3;
            Calc_CheckSum(CMD_Info_Length);

            Send_Frame();
        }


        public bool Get_CFG_OnStatus_RES()
        {
            if (uc1 == null) return false;

            if (uc1.IsReceived)
            {
                if (uc1.ReceiveStr == "CFG OnStatus OK\r\n")
                {
                    uc1.IsReceived = false;
                    return true;
                }

            }
            return false;
        }

        public  void Send_CFG_Color(byte[] color_array)
        {
            CMD_CFG_Sub=0x05;

            for(int i=0;i<20;i++)
                CMD_Info[i]=color_array[i];
            
            CMD_Info_Length=20;
            Calc_CheckSum(CMD_Info_Length);

            Send_Frame();
        }

        public bool Get_CFG_Color_RES()
        {
            if (uc1 == null) return false;

            if (uc1.IsReceived)
            {
                if (uc1.ReceiveStr == "CFG LEDColor OK\r\n")
                {
                    uc1.IsReceived = false;
                    return true;
                }

            }
            return false;
        }

        public void Send_CFG_FlashStatus( ushort flashstatus)
        {
             CMD_CFG_Sub=0x06;
             CMD_Info[0]=(byte)(flashstatus>>8);
             CMD_Info[1] = (byte)(flashstatus & 0x00ff);
             CMD_Info_Length=2;
             Calc_CheckSum(CMD_Info_Length);

             Send_Frame();
        }

        public bool Get_CFG_FlashStatus_RES()
        {
            if (uc1 == null) return false;
            if (uc1.IsReceived)
            {
                if (uc1.ReceiveStr == "CFG Flash Status OK\r\n")
                {
                    uc1.IsReceived = false;
                    return true;
                }

            }
            return false;
        }


        //$GPRMC,093408.00,V,,,,,,,060818,,,N*7C
        public void Send_RMC_Time(byte[] time, byte[] date)
        {
            for (int i = 0; i < 6; i++)
            {
                RMC_Date_Buf[i] = date[i];
                RMC_Time_Buf[i] = time[i];
            }

            Cal_RMC_CheckSum();
            Send_RMC_Frame();

        }


        //$GPRMC,093408.00,V,,,,,,,060818,,,N*7C
        void Cal_RMC_CheckSum()
        {
            byte temp = (byte)((int)CMD_RMC_Pre[0] ^ (int)CMD_RMC_Pre[1] ^ (int)CMD_RMC_Pre[2] ^ (int)CMD_RMC_Pre[3] ^ (int)CMD_RMC_Pre[4]);
            for (int i = 0; i < 6; i++)
            {
                temp = (byte)((int)temp ^ (int)RMC_Time_Buf[i]);
                temp = (byte)((int)temp ^ (int)RMC_Date_Buf[i]);

            }

            temp = (byte)((int)temp ^ (int)CMD_Seporator_2);
            temp = (byte)((int)temp ^ (int)CMD_Verify);
            temp = (byte)((int)temp ^ (int)CMD_Time_North);

            CheckSum = temp;

            temp = (byte)((int)(temp >> 4) & 0x0f);

            if ((temp >= 0) && (temp <= 9))
                temp = (byte)((int)temp + '0');

            else if ((temp >= 10) && (temp <= 15))
                temp = (byte)((int)temp + 'A' - 10);


            CheckSum_high_asc = temp;

            temp = CheckSum;

            temp = (byte)((int)temp & 0x0f);

            if ((temp >= 0) && (temp <= 9))
                temp = (byte)((int)temp + '0');

            else if ((temp >= 10) && (temp <= 15))
                temp = (byte)((int)temp + 'A' - 10);


            CheckSum_low_asc = temp;

        }

        //$GPRMC,093408.00,V,,,,,,,060818,,,N*7C
        void Send_RMC_Frame()
        {
            Transmit_Buf[0] = StartSymbol;

            for (int i = 0; i < 5; i++)
            {
                Transmit_Buf[i + 1] =(byte) CMD_RMC_Pre[i];
            }

            Transmit_Buf[6] = (byte)CMD_Seporator_1;

            for (int i = 0; i < 6; i++)
            {
                Transmit_Buf[i + 7] = (byte)RMC_Time_Buf[i];
            }

            Transmit_Buf[13] = (byte)CMD_Seporator_2;
            Transmit_Buf[14] = (byte)CMD_MicroSec1;
            Transmit_Buf[15] = (byte)CMD_MicroSec2;
            Transmit_Buf[16] = (byte)CMD_Seporator_1;
            Transmit_Buf[17] = (byte)CMD_Verify;

            for (int i = 0; i < 7; i++)
            {
                Transmit_Buf[i + 18] = (byte)CMD_Seporator_1;
            }

            for (int i = 0; i < 6; i++)
            {
                Transmit_Buf[i + 25] = (byte)RMC_Date_Buf[i];
            }

            for (int i = 0; i < 3; i++)
            {
                Transmit_Buf[i + 31] = (byte)CMD_Seporator_1;
            }


            Transmit_Buf[34] = (byte)CMD_Time_North;

            
            Transmit_Buf[35] = EndSymbol;

            Transmit_Buf[36] = CheckSum_high_asc;

            Transmit_Buf[37] = CheckSum_low_asc;
            Transmit_Buf[38] = ReturnSymbo;
            Transmit_Buf[39] = ChangeLineSymbo;
            if (uc1 == null) return;
            uc1.SendData(Transmit_Buf, 0, 40);

        }
    }
}
