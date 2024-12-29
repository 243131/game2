using game2.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace game2
{
    public partial class Form1 : Form
    {
        char[] characters = new char[14];
        string[] newword = new string[3];
        string[] alphabet = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
        string[] sigma = new string[] { "b", "a", "n", "e", "s", "b", "a", "r", "e", "s", "b", "e", "a", "n", "s" };
        int labelcounter = 1;
        int xx = 400;
        int yy = 100;
        Random rnd = new Random();
        List<string> wordList = new List<string>();
        List<char> allCharacters = new List<char>();
        public Form1()
        {
            InitializeComponent();


            StreamReader file = new StreamReader("C:\\Users\\sulai\\source\\repos\\game2\\game2\\bin\\Debug\\ukenglish.txt");
            {
                string word;
                while ((word = file.ReadLine()) != null)
                {
                    if (word.Length == 5)
                    {
                        wordList.Add(word);
                    }
                }
                file.Close();
            }
            
            for (int i = 0; i < 3; i++)
            {
                int wordnumchoose = rnd.Next(0,wordList.Count);
                newword[i] = wordList[wordnumchoose];
                allCharacters.AddRange(newword[i].ToCharArray());
            }
          characters = allCharacters.ToArray();
        
            while (yy < 400)
            {
                for (int i = 0; i < characters.Length; i++)
                {
                    AddLabel(characters[i].ToString(), xx, yy, "label_" + labelcounter);
                    labelcounter++;
                    xx = xx + 50;


                    if (xx > 600)
                    {
                        yy = yy + 100;
                        xx = 400;
                    }
                }
                break;
            } 
           
        }

           
        private void AddLabel(String msg, int x, int y, String labelName)
        {
            Label lbl = new Label();
            lbl.Location = new Point(x, y);
            lbl.Size = new Size(50, 50);
            lbl.BackColor = Color.Transparent;
            lbl.BorderStyle = BorderStyle.FixedSingle;
            lbl.Text = msg;
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.Font = new Font("Colonna MT", 12);
            lbl.Name = labelName;
            this.Controls.Add(lbl);
        }

        private void DrawEllipseInt(PaintEventArgs e)
        {

            Pen blackPen = new Pen(Color.Black, 3);

            int x = 475;
            int y = 350;
            int width = 200;
            int height = 200;

            
            e.Graphics.DrawEllipse(blackPen, x, y, width, height);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            
            base.OnPaint(e);
            int xxx = 500;
                int yyy = 375;
            int j = 1;
            for (int i = 1; i <= 5; i++)
            {
                
                int letternum = rnd.Next(0, 25);
                AddLabel(alphabet[letternum], xxx, yyy, "label_" + labelcounter);
                labelcounter++;
                if (i <= 2)
                {
                    xxx = xxx + 100;
                }
                if (j >= 2)
                {
                    yyy = yyy + 75;
                    xxx = 325;
                    j = 0;
                    xxx = xxx + 150;
                }
                if (i == 3)
                {
                    xxx = xxx + 150;
                }
                if (i >= 4)
                {
                    xxx = 400;
                    yyy = 500;
                    xxx = xxx + 150;
                }
              
                j++;
            }
            DrawEllipseInt(e);
        }
    }
}
