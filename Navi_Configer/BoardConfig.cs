using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml;
using System.Drawing;


namespace Navi_Configer
{
    class BoardConfig
    {
        string ConfigFileName= "ConfigBoard.xml";

        Form1 FormUI = null;

        public  byte BoardID=0;
        public  byte BoardType = 0;
        public  byte[] LampEnable=new byte[3];
        public  byte[] LampOnstatus=new byte[3];
        public  byte[] LampColor=new byte[20];
        public  ushort LampFlashStatus=0;



        //$GPRMC,093408.00,V,,,,,,,060818,,,N*7C
        public byte[] Time = new byte[3];
        public byte[] Date = new byte[3];

        public void SetTime(byte[] time)    //hour [0] min [1] sec [2]
        {
            for (int i = 0; i < 3; i++)
                Time[i] = time[i];
        }

        public void SetDate(byte[] date)    //day [0] month [1] year [2]
        {
            for (int i = 0; i < 3; i++)
                Date[i] = date[i];
        }


        public BoardConfig(Form1 f1)
        {
            FormUI = f1;
            //LoadFromFile();

            
           
        }

        public void SetConfigFile(string fileName)
        {
            ConfigFileName = fileName;
        }

       

        public void LoadFromFile()
        {
            XmlDocument doc = new XmlDocument();
 
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreComments = true;                                         //忽略文档里面的注释
            XmlReader reader = XmlReader.Create(@ConfigFileName, settings);

            doc.Load(reader);

            reader.Close();
            XmlNode xn = doc.SelectSingleNode("BoardConfig");
            XmlNodeList xnl = xn.ChildNodes;

            
             XmlElement xe_enable = (XmlElement)xnl.Item(2);
             XmlNodeList xn_enable_0 = xe_enable.ChildNodes;

             XmlElement xe_onstatus = (XmlElement)xnl.Item(3);
             XmlNodeList xn_onstatus_0 = xe_onstatus.ChildNodes;

             XmlElement xe_color = (XmlElement)xnl.Item(4);
             XmlNodeList xn_color_0 = xe_color.ChildNodes;

            BoardID=Convert.ToByte(xnl.Item(0).InnerText);
            BoardType=Convert.ToByte(xnl.Item(1).InnerText);


            //string s1 = xn_enable_0.Item(0).InnerText;
            LampEnable[0]=Convert.ToByte(xn_enable_0.Item(0).InnerText);
            LampEnable[1]=Convert.ToByte(xn_enable_0.Item(1).InnerText);
            LampEnable[2]=Convert.ToByte(xn_enable_0.Item(2).InnerText);
          
            LampOnstatus[0]=Convert.ToByte(xn_onstatus_0.Item(0).InnerText);
            LampOnstatus[1]=Convert.ToByte(xn_onstatus_0.Item(1).InnerText);
            LampOnstatus[2]=Convert.ToByte(xn_onstatus_0.Item(2).InnerText);

            for(int i=0;i<20;i++)
            {
                if (xn_color_0.Item(i).InnerText=="red")
                    LampColor[i]=0;
                else if(xn_color_0.Item(i).InnerText=="green")
                    LampColor[i]=1;
                else if(xn_color_0.Item(i).InnerText=="blue")
                    LampColor[i]=2;
                else if(xn_color_0.Item(i).InnerText=="purple")
                    LampColor[i]=4;
                else if(xn_color_0.Item(i).InnerText=="yellow")
                    LampColor[i]=3;
                else if(xn_color_0.Item(i).InnerText=="cyan")
                    LampColor[i]=5;
                else if(xn_color_0.Item(i).InnerText=="white")
                    LampColor[i]=6;
            }

            LampFlashStatus=0;

                
              
               
           
        }


        

        public void SaveToFile(string fileName)
        {
            string color="white";

            LoardFromUI();

            XmlDocument Doc = new XmlDocument();
            XmlDeclaration dec = Doc.CreateXmlDeclaration("1.0", "utf-8", null);

            Doc.AppendChild(dec);

            XmlElement boardconfig = Doc.CreateElement("BoardConfig");
            Doc.AppendChild(boardconfig);


            //boardid set
            XmlElement boardid = Doc.CreateElement("BoardID");
            boardid.InnerText = Convert.ToString(BoardID);
            boardconfig.AppendChild(boardid);

            //boardtype set
            XmlElement boardtype = Doc.CreateElement("BoardType");
            boardtype.InnerText = Convert.ToString(BoardType);
            boardconfig.AppendChild(boardtype);

            //Lamp enable set

            XmlElement lamp_enable = Doc.CreateElement("LampEnable");
            boardconfig.AppendChild(lamp_enable);

            XmlElement lamp_enable_0 = Doc.CreateElement("LampEnable_0");
            lamp_enable_0.InnerText = Convert.ToString(LampEnable[0]);
            lamp_enable.AppendChild(lamp_enable_0);


            XmlElement lamp_enable_1 = Doc.CreateElement("LampEnable_1");
            lamp_enable_1.InnerText = Convert.ToString(LampEnable[1]);
            lamp_enable.AppendChild(lamp_enable_1);

            XmlElement lamp_enable_2 = Doc.CreateElement("LampEnable_2");
            lamp_enable_2.InnerText = Convert.ToString(LampEnable[2]);
            lamp_enable.AppendChild(lamp_enable_2);

            //lamp onstatus
            XmlElement lamp_onstatus = Doc.CreateElement("LampOnStatus");
            boardconfig.AppendChild(lamp_onstatus);

            XmlElement lamp_onstatus_0 = Doc.CreateElement("LampOn_0");
            lamp_onstatus_0.InnerText = Convert.ToString(LampOnstatus[0]);
            lamp_onstatus.AppendChild(lamp_onstatus_0);

            XmlElement lamp_onstatus_1 = Doc.CreateElement("LampOn_1");
            lamp_onstatus_1.InnerText = Convert.ToString(LampOnstatus[1]);
            lamp_onstatus.AppendChild(lamp_onstatus_1);

            XmlElement lamp_onstatus_2 = Doc.CreateElement("LampOn_2");
            lamp_onstatus_2.InnerText = Convert.ToString(LampOnstatus[2]);
            lamp_onstatus.AppendChild(lamp_onstatus_2);


            //lamp color
            XmlElement lamp_color = Doc.CreateElement("LampColor");
            boardconfig.AppendChild(lamp_color);


            for (int i = 0; i < 20; i++)
            {
                
                XmlElement x1= Doc.CreateElement("LampColor"+Convert.ToString(i+1));
                switch (LampColor[i])
                {
                    case 0:
                        color = "red";
                        break;
                    case 1:
                        color = "green";
                        break;
                    case 2:
                        color = "blue";
                        break;
                    case 4:
                        color = "purple";
                        break;
                    case 3:
                        color = "yellow";
                        break;
                    case 5:
                        color = "cyan";
                        break;
                    case 6:
                        color = "white";
                        break;
                      

                }

                x1.InnerText = color;
                lamp_color.AppendChild(x1);
            }

            XmlElement lamp_flash_status= Doc.CreateElement("LampFlashStatus");
            lamp_flash_status.InnerText = Convert.ToString(LampFlashStatus);
            boardconfig.AppendChild(lamp_flash_status);

            Doc.Save(fileName);
        }




        public void SetToUI()
        {
            Color[]  Lamp_Color_list=new Color[20];

            FormUI.Set_BoardID(Convert.ToString(BoardID));
            FormUI.Set_BoardType(Convert.ToString(BoardType));

            for (int i = 0; i < 20; i++)
            {
                if (LampColor[i] == 0)
                    Lamp_Color_list[i] = Color.Red;
                else if (LampColor[i] == 1)
                    Lamp_Color_list[i] = Color.Lime;
                else if (LampColor[i] == 2)
                    Lamp_Color_list[i] = Color.Blue;
                else if (LampColor[i] == 4)
                    Lamp_Color_list[i] = Color.Fuchsia;
                else if (LampColor[i] == 3)
                    Lamp_Color_list[i] = Color.Yellow;
                else if (LampColor[i] == 5)
                    Lamp_Color_list[i] = Color.Cyan;
                else if (LampColor[i] == 6)
                    Lamp_Color_list[i] = Color.White;

                FormUI.Lamp_SetColor_Byindex(i, Lamp_Color_list[i]);
            }

            byte shiftMask = 0x01;
            byte enableCheck;
            bool enableCheckbool=false;
            byte onstatusCheck;
            bool onstatusCheckbool=false;

            int shiftCount = 8;


            for (int i = 0; i < 3; i++)
            {
                shiftCount = (i < 2) ? 8 : (20 % 8);

                shiftMask = 0x01;

                for (int j = 0; j < shiftCount; j++)
                {
                    enableCheck =(byte)((int) LampEnable[i] & (int)shiftMask);
                   
                    if (enableCheck == 0)
                        enableCheckbool = false;
                    else 
                        enableCheckbool = true;

                    onstatusCheck = (byte)((int)LampOnstatus[i] & (int)shiftMask);

                    if (onstatusCheck == 0)
                        onstatusCheckbool = false;
                    else
                        onstatusCheckbool = true;

                    FormUI.Lamp_SetEnable_Onstatus_Byindex(8*i+j, enableCheckbool, onstatusCheckbool);

                                        
                    shiftMask <<= 1;

                    
                }

            }

          
           
        
        }



        public  void LoardFromUI()
        {
            
            BoardID = FormUI.Get_BoardID();
            BoardType = FormUI.Get_BoardType();

            for (int i = 0; i < 20; i++)
            {
                LampColor[i] = FormUI.Lamp_GetColor_Byindex(i);
            }

            //get enable and onstatus
            byte shiftMask = 0x01;
            byte enableCheck=0;
            bool enableCheckbool=false;
            byte onstatusCheck=0;
            bool onstatusCheckbool=false;

            int shiftCount = 8;


            for (int i = 0; i < 3; i++)
            {
                shiftCount = (i < 2) ? 8 : (20 % 8);

                shiftMask = 0x01;

                for (int j = 0; j < shiftCount; j++)
                {

                    FormUI.Lamp_GetEnable_Onstatus_Byindex(8 * i + j, ref enableCheckbool, ref onstatusCheckbool);
                    if (enableCheckbool)
                        enableCheck =(byte) ((int)enableCheck | (int)shiftMask);
                    else
                        enableCheck = (byte)((int)enableCheck & (int)~shiftMask);

                    if (onstatusCheckbool)
                        onstatusCheck = (byte)((int)onstatusCheck | (int)shiftMask);
                    else
                        onstatusCheck = (byte)((int)onstatusCheck & (int)~shiftMask);


                    shiftMask <<= 1;
                }

                LampEnable[i] = enableCheck;
                LampOnstatus[i] = onstatusCheck;
            }

        }

        
    }
}
