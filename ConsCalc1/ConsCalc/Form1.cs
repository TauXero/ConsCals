using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsCalc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TimeSpan stopdays,remainWork, oneday;
            
            //착공일, 준공일, 중지일, 중지해제일  컨트롤값
            string startwork = dateTimePicker1.Value.ToShortDateString();
            string endwork = dateTimePicker2.Value.ToShortDateString();
            string stopwork = dateTimePicker3.Value.ToShortDateString();
            string restartwork = dateTimePicker4.Value.ToShortDateString();

            //착공일, 준공일, 중지일, 중지해제일, 변경준공예정일    날짜
            DateTime StartWork = Convert.ToDateTime(startwork);
            DateTime EndWork = Convert.ToDateTime(endwork);
            DateTime StopWork = Convert.ToDateTime(stopwork);
            DateTime RestartWork = Convert.ToDateTime(restartwork);
            DateTime newEndWork;
            
            stopdays = RestartWork - StopWork;     //중지일수
            newEndWork = EndWork + stopdays;  //변경준공예정일
            remainWork = EndWork - StopWork;    //잔여일수
            oneday = new TimeSpan(1, 0, 0, 0);

            if (stopdays.Days <= 0)
            {
                MessageBox.Show("오류 : 중지기간이 0이하");
                return;
            }

            if (remainWork.Days <= 0)
            {
                MessageBox.Show("오류 : 잔여기간이 0이하");
                return;
            }

            //기간, 수행, 잔여, 변경 결과출력
            label5.Text = "공사(용역)기간 : " + StartWork.ToShortDateString() + " ~ " 
                + EndWork.ToShortDateString();
            label6.Text = "중지기간 : " + StopWork.ToShortDateString() + " ~ " 
                + (RestartWork - oneday).ToShortDateString() 
                + "(중지일 : " + stopdays.Days.ToString() + "일)";
            label7.Text = "잔여공기 : " + (remainWork.Days+1).ToString() + "일";
            label8.Text = "변경공사(용역)기간 : " + StartWork.ToShortDateString() + " ~ "
                 + (newEndWork.ToShortDateString());            
        }
    }
}
