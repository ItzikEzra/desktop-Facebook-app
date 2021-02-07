using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop_Facebook
{
    public partial class Proxy : FormFacebook
    {
        private List<Label> m_Labels = new List<Label>();

        public Proxy()
        {
            InitializeComponent();
            unionAllLabels();

        }

        private void darkModecheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (DarkModecheckBox.Checked)
            {
                changeBackGroundColor(System.Drawing.Color.Black);
                changeLabalColor(System.Drawing.Color.White);
            }
            else
            {
                changeBackGroundColor(System.Drawing.Color.White);
                changeLabalColor(System.Drawing.Color.Black);

            }
        }
        
        private void changeLabalColor(Color color)
        {
            foreach (Label label in m_Labels)
            {
                label.ForeColor = color;
            }
        }

        private void unionAllLabels()
        {
            m_Labels.Add(labelProfileName);
            m_Labels.Add(labelBirthday);
            m_Labels.Add(labelGender);
            m_Labels.Add(PostLabel);
            m_Labels.Add(CheckinsLabel);
            m_Labels.Add(FriendsLabel);
            m_Labels.Add(AlbumsLabel);  
            m_Labels.Add(AlbumDetailsLabel);
            m_Labels.Add(BestTimeMassagelabel);
            m_Labels.Add(bestTimePicLabel);
            m_Labels.Add(bestTimePostLabel);
            m_Labels.Add(InactiveMassageLabel);
            m_Labels.Add(InactiveLabel);
            m_Labels.Add(labelResult);
            m_Labels.Add(label4);
            m_Labels.Add(label5);
            m_Labels.Add(label6);
        }

        private void changeBackGroundColor(Color color)
        {
            base.panel1.BackColor = color;
            base.tabPage1.BackColor = color;
            base.tabPage2.BackColor = color;
            base.tabPage3.BackColor = color;
            base.tabPage4.BackColor = color;
        }

        private void increaseFontSize(ref Label label)
        {
            var newFontSize = label.Font.Size + 1;
            label.Font= fontSizeChanger(newFontSize);
        }

        private void diecraseFontSize(ref Label label)
        {
            var newFontSize = label.Font.Size - 1;
           label.Font = fontSizeChanger(newFontSize);
        }

        private static Font fontSizeChanger(float newFontSize)
        {
            if(newFontSize < 1)
            {
                newFontSize = 1;
            }

            return new System.Drawing.Font(
                                 "Microsoft Sans Serif",
                                 newFontSize,
                                 System.Drawing.FontStyle.Regular,
                                 System.Drawing.GraphicsUnit.Point,
                                 ((byte)(0)));
        }

        private void SmallerButton_Click(object sender, EventArgs e)
        {
            Label label1 = new Label();
            foreach (Label label in m_Labels)
            {
                label1 = label;
                diecraseFontSize(ref label1);
            }
            mostCommentPost.Font = fontSizeChanger(mostCommentPost.Font.Size - 1);

        }

        private void BiggerButton_Click(object sender, EventArgs e)
        {
            Label label1 = new Label();
            foreach (Label label in m_Labels)
            {
                label1 = label;
                increaseFontSize(ref label1);
            }
            mostCommentPost.Font = fontSizeChanger(mostCommentPost.Font.Size + 1);
        }
    }
}
