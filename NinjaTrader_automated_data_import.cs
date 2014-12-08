using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Xml;
using Microsoft.Win32;
using System.Text;
using System.Diagnostics;
using System.Threading;

namespace util
{
	class Program
	{
        //Import the FindWindow API to find our window
        [DllImportAttribute("User32.dll")]
        private static extern int FindWindow(String ClassName, String WindowName);

        //Import the SetForeground API to activate it
        [DllImportAttribute("User32.dll")]
        private static extern IntPtr SetForegroundWindow(int hWnd);

        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        static extern int GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern int GetWindowText(int hWnd, StringBuilder text, int count); 
        
        public static void Main(string[] args)
		{
			
            int x = 0;

            while (x == 0)
            {
                try
                {

                    //change times according to when I want to import data
                    if ((System.DateTime.Now.Minute == 0 && System.DateTime.Now.Second == 45) ||
                        (System.DateTime.Now.Minute == 7 && System.DateTime.Now.Second == 45) ||
                        (System.DateTime.Now.Minute == 15 && System.DateTime.Now.Second == 45) ||
                        (System.DateTime.Now.Minute == 23 && System.DateTime.Now.Second == 45) ||
                        (System.DateTime.Now.Minute == 30 && System.DateTime.Now.Second == 45) ||
                        (System.DateTime.Now.Minute == 37 && System.DateTime.Now.Second == 45) ||
                        (System.DateTime.Now.Minute == 45 && System.DateTime.Now.Second == 45) ||
                        (System.DateTime.Now.Minute == 53 && System.DateTime.Now.Second == 45))
                    {
                        Process myProcess = new Process();

                        //display message 15 seconds before data is imported 
                        
                        if (!File.Exists(@"C:\testimport\dataimportmessage.txt"))
                        {
                            using (StreamWriter sw = File.CreateText(@"C:\testimport\dataimportmessage.txt"))
                            {
                                sw.WriteLine("Data import in 15 seconds");

                            }
                        }
                        
                        
                        Process.Start(@"C:\testimport\dataimportmessage.txt");
                        myProcess.Close();
                        Thread.Sleep(1000); //sleep for 1 second so message only displays 1 time

                        int hWnd5 = FindWindow(null, "dataimportmessage.txt - Notepad"); 
                        
                        if (hWnd5 > 0) //If found
                        {
                            SetForegroundWindow(hWnd5); //set focus to displayed message
                            
                        }

                         else
                        {
                            MessageBox.Show("Window Not Found!");
                        }

                    }

                    //change times according to when I want to import data
                    if ((System.DateTime.Now.Minute == 1 && System.DateTime.Now.Second == 1 ) ||
                        (System.DateTime.Now.Minute == 8 && System.DateTime.Now.Second == 1 ) ||
                        (System.DateTime.Now.Minute == 16 && System.DateTime.Now.Second == 1 ) ||
                        (System.DateTime.Now.Minute == 24 && System.DateTime.Now.Second == 1 ) ||
                        (System.DateTime.Now.Minute == 31 && System.DateTime.Now.Second == 1 ) ||
                        (System.DateTime.Now.Minute == 38 && System.DateTime.Now.Second == 1 ) ||
                        (System.DateTime.Now.Minute == 46 && System.DateTime.Now.Second == 1 ) ||
                        (System.DateTime.Now.Minute == 54 && System.DateTime.Now.Second == 1 ))
                    {

                      
                        int hWnd = FindWindow(null, "Control Center - stocks"); //depends on name of workspace
                        if (hWnd > 0) //If found
                        {
                            SetForegroundWindow(hWnd); //Activate it
                            System.Windows.Forms.SendKeys.SendWait("%(x)"); //hotkey to open historical data manager
                            System.Windows.Forms.SendKeys.SendWait("{TAB}{TAB}{TAB}{TAB}");


                            for (int y = 1; y <= 71; y++)
                            {
                                System.Windows.Forms.SendKeys.SendWait("{UP}");  //set timezone
                            }

                            string path = @"C:\testimport\data"; //path of data
                            System.Windows.Forms.SendKeys.SendWait("{TAB}{TAB}"); //select bar type to generate
                            System.Windows.Forms.SendKeys.SendWait(" "); //set bar type to generate
                            Thread.Sleep(1500);
                            System.Windows.Forms.SendKeys.SendWait("{TAB}{TAB}{TAB}{ENTER}");
                            Thread.Sleep(2500);
                            System.Windows.Forms.SendKeys.SendWait(path);
                            Thread.Sleep(2500);
                            System.Windows.Forms.SendKeys.SendWait("{ENTER}");
                            Thread.Sleep(2000);
                            System.Windows.Forms.SendKeys.SendWait("{TAB}{TAB}{TAB}{TAB}{TAB}{TAB}{TAB}{TAB}");
                            System.Windows.Forms.SendKeys.SendWait("+({DOWN}{DOWN}{DOWN}{DOWN}{DOWN}{DOWN})");//depends on the number of symbols being imported
                            Thread.Sleep(1500);
                            System.Windows.Forms.SendKeys.SendWait("{ENTER}"); //click ok to import data
                            Thread.Sleep(2000);
                            System.Windows.Forms.SendKeys.SendWait("%({F4})"); //close data imported window
                            System.Windows.Forms.SendKeys.SendWait("%({F4})"); //close historical data manager window
                            System.Windows.Forms.SendKeys.SendWait("%(c)"); //hotkey to close workspace
                            Thread.Sleep(2000);
                            System.Windows.Forms.SendKeys.SendWait("{ENTER}"); //hit yes to save workspace
                         
                        }
                        
                        else
                        {
                            MessageBox.Show("Window Not Found!");
                        }
                   
                        Thread.Sleep(2000);

                        int hWnd3 = FindWindow(null, "Control Center - test"); //depends on workspace name when main workspace is closed
                        if (hWnd3 > 0) //If found
                        {
                            SetForegroundWindow(hWnd3); //Activate it
                            Thread.Sleep(2000);
                            System.Windows.Forms.SendKeys.SendWait("%(f)"); //access file menu
                            System.Windows.Forms.SendKeys.SendWait("{DOWN}{RIGHT}{DOWN}{ENTER}");
                            System.Windows.Forms.SendKeys.SendWait("{TAB}{TAB}{TAB}{TAB}");
                            System.Windows.Forms.SendKeys.SendWait("{DOWN}{DOWN}"); //depends on where the workspace being opened is in the list
                            Thread.Sleep(2000);
                            System.Windows.Forms.SendKeys.SendWait("{ENTER}");
                        
                        }

                        else
                        {
                            MessageBox.Show("Window Not Found!");
                        }

                        //close notepad message if it is still open
                        int hWnd4 = FindWindow(null, "dataimportmessage.txt - Notepad"); 
                        if (hWnd4 > 0) //If found
                        {
                            SetForegroundWindow(hWnd4); //Activate it
                            Thread.Sleep(1500);
                            System.Windows.Forms.SendKeys.SendWait("%({F4})"); //close window
                        }

                    }

                }

                    catch (Exception e)
                    {
                        Console.WriteLine("The process failed: {0}", e.ToString());
                    }
                    finally { }
            }
         }
	}
}