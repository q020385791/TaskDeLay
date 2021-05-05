using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskDeLay
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        int test = 1;
        private void btnDoit_Click(object sender, EventArgs e)
        {
            int DelayTimeSec = 1;
            var delayInterval = TimeSpan.FromMilliseconds(DelayTimeSec * 1000);
            var runningTask = DoActionAfter(
            delayInterval,
            () => DoSomething((test+1).ToString()));
            test += 1;
        }
        public static Task DoActionAfter(TimeSpan delay, Action action)
        {
            return Task.Delay(delay).ContinueWith(_ => action());
        }


        public delegate void SomethingDelgate(string Message); // 定義委派
        public  void DoSomething(string Message) 
        {
            SomethingDelgate Delgate = new SomethingDelgate(DoSomething); //新建委派並指定Method
            if (label1.InvokeRequired)
            {
                Invoke(Delgate,new object[] { Message });//如果不是同樣執行序，則使用委派
            }
            else 
            {
                label1.Text = Message;
            }
          
        }
    }

    
}
