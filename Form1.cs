using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinesweeperGame
{
    public partial class Form1 : Form
    {
        private int Row ;
        private int Colum ;

        private Button[,] buttons;
        private bool[,] visited;
        private int [,] bombsIndex;

        private int FlagNumber;
        private int PlayingTime;
        private int NumberOfBomb;
        private Image bombImage;
        private Panel buttonPanel;
        private Timer timer1;
        private int counter = 0;


        public Form1(int Time, int bombs, int size)
        {
            PlayingTime = Time;
            NumberOfBomb = bombs;
            Row = size;
            Colum = size;
            InitializeComponent();
            InitializeForm();
            InitializePanel();
            Start();
        }
           




        private void Form1_Load(object sender, EventArgs e)
        {           
        }


        private void Start()
        {

            FlagNumber = NumberOfBomb;
            visited = new bool[Row, Colum];
            buttons = new Button[Row, Colum];
            bombsIndex = new int[NumberOfBomb,2];
            CreateButtonMatrix(Row, Colum);
            InitializeTimer();
            counter = PlayingTime;
            lebFlagNumber.Text = FlagNumber.ToString();
        }

        private void ReStart()
        {
            ClearPanel();
            timer1.Enabled = false;
            Start();
        }

        private void InitializeForm()
        {
            this.Text = "Button Matrix";
            this.Size = new System.Drawing.Size(767, 738);
          
        }
        private void InitializeTimer()
        {
            timer1 = new Timer();
            timer1.Interval = 1000; 
            timer1.Tick += timer1_Tick;
            counter = 0;
            timer1.Start();
        }
      
        private void CreatBombs()
        {
            int BombNumber = NumberOfBomb;
            Random rnd = new Random();
            while (BombNumber > 0)
            {
                int x = rnd.Next(0, Row);
                int y = rnd.Next(0, Colum);

                if (buttons[x, y].Tag != "*") 
                {
                    buttons[x, y].Tag = "*";
                    bombsIndex[NumberOfBomb - BombNumber, 0] = x; 
                    bombsIndex[NumberOfBomb - BombNumber, 1] = y; 

                    setNumbersAroundBomb(x, y); 
                    BombNumber--;
                }
            }
        }

        private void setNumberInButton(Button btn)
        {
            if (btn.Tag == "*") { return; }

            int oldTag=Convert.ToInt32(btn.Tag);
            btn.Tag=(oldTag+1).ToString();
           
        }

        private void setNumbersAroundBomb(int rowIndex, int columIndex)
        {
           
            if (rowIndex - 1 >= 0)
            {
                setNumberInButton(buttons[rowIndex - 1, columIndex]); 
            }

            if (rowIndex + 1 < Row)
            {
                setNumberInButton(buttons[rowIndex + 1, columIndex]); 
            }

            if (columIndex - 1 >= 0)
            {
                setNumberInButton(buttons[rowIndex, columIndex - 1]); 
            }

            if (columIndex + 1 < Colum)
            {
                setNumberInButton(buttons[rowIndex, columIndex + 1]); 
            }

            if (rowIndex - 1 >= 0 && columIndex - 1 >= 0)
            {
                setNumberInButton(buttons[rowIndex - 1, columIndex - 1]); 
            }

            if (rowIndex - 1 >= 0 && columIndex + 1 < Colum)
            {
                setNumberInButton(buttons[rowIndex - 1, columIndex + 1]); 
            }

            if (rowIndex + 1 < Row && columIndex - 1 >= 0)
            {
                setNumberInButton(buttons[rowIndex + 1, columIndex - 1]); 
            }

            if (rowIndex + 1 < Row && columIndex + 1 < Colum)
            {
                setNumberInButton(buttons[rowIndex + 1, columIndex + 1]); 
            }
        }
        private bool IsWinner()
        {
            int flaggedBombs = 0; 
            int uncoveredCells = 0;  

            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Colum; j++)
                {
                    if (buttons[i, j].Tag.ToString() == "*" && buttons[i, j].Text == "🚩")
                    {
                        flaggedBombs++;
                    }
                    if (visited[i, j])
                    {
                        uncoveredCells++;
                    }
                }
            }

            int totalCells = Row * Colum;
            int nonBombCells = totalCells - NumberOfBomb;
            return (flaggedBombs == NumberOfBomb && uncoveredCells == nonBombCells);
        }


        private void ShowColor(Button btn)
        {
            switch (btn.Tag)
            {
                case "*":
                    btn.BackColor = Color.Red; break;

                case "0":
                    btn.BackColor = Color.DimGray; break;

                case "1":
                    btn.BackColor = Color.Aqua; break;

                case "2":
                    btn.BackColor = Color.DeepSkyBlue; break;

                case "3":
                    btn.BackColor = Color.SteelBlue; break;
                case "4":
                    btn.BackColor = Color.SaddleBrown; break;

                case "5":
                    btn.BackColor = Color.SlateGray; break;

                case "6":
                    btn.BackColor = Color.Snow; break;

                case "7":
                    btn.BackColor = Color.Wheat; break;

                case "8":
                    btn.BackColor = Color.Yellow; break;

                default:
                    btn.BackColor = Color.White; break;


            }



        }

        private void ShowNubers(Button btn)
        {
             btn.Text = Convert.ToString(btn.Tag); 
        }
        
        private void Checked(int rowIndex, int columIndex)
        {
          
            if (rowIndex < 0 || rowIndex >= Row || columIndex < 0 || columIndex >= Colum)
                return;

            
            if (visited[rowIndex, columIndex] )
                return;


            if( buttons[rowIndex, columIndex].Tag != "0")
            {
                visited[rowIndex, columIndex] = true;
                ShowColor(buttons[rowIndex, columIndex]);
                ShowNubers(buttons[rowIndex, columIndex]);
                return;
            }

           
            visited[rowIndex, columIndex] = true;
            ShowColor(buttons[rowIndex, columIndex]);
            ShowNubers(buttons[rowIndex, columIndex]);

            
            Checked(rowIndex - 1, columIndex); 
            Checked(rowIndex + 1, columIndex); 
            Checked(rowIndex, columIndex - 1); 
            Checked(rowIndex, columIndex + 1); 
     

        }

        private void InitializePanel()
        {
            buttonPanel = new Panel
            {
                 Width = 720,
                Height = 668,
                Location=new Point(7, 60),
                AutoScroll = true 
            };
            this.Controls.Add(buttonPanel);
        }
        
        private void CreateButtonMatrix(int rows, int cols)
        {
          
            int spacing = 0; 
            int panelWidth = this.ClientSize.Width - 20;
            int panelHeight = this.ClientSize.Height - 100; 
            
            int buttonWidth = Math.Max((panelWidth - (spacing * (cols - 1))) / cols, 10);
            int buttonHeight = Math.Max((panelHeight - (spacing * (rows - 1))) / rows, 10); 

            
            buttonPanel.Width = panelWidth;
            buttonPanel.Height = panelHeight;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Button btn = CreateButton(i, j, buttonWidth, buttonHeight, spacing);
                    buttonPanel.Controls.Add(btn);
                    btn.Tag = "0";
                    btn.FlatStyle = FlatStyle.Popup;
                    btn.BackColor=Color.DarkGray;
                    btn.ForeColor=Color.Black;
                    buttons[i, j] = btn;
                }
            }
            CreatBombs();
        }

        private void LoadResources()
        {
            bombImage = Properties.Resources.time_bomb; 
        }
 
       
        private void ShowAllBomb()
        {
            LoadResources();

                int row;
                int col;
                for (int i = 0; i < bombsIndex.GetLength(0); i++)
                {
                    row = bombsIndex[i,0];
                    col = bombsIndex[i,1];

                    buttons[row, col].BackgroundImage = bombImage;
                    buttons[row, col].BackgroundImageLayout = ImageLayout.Zoom;
                    
                }
            
        }

        private Button CreateButton(int row, int col, int width, int height, int spacing)
        {
            Button btn = new Button
            {
                Width = width,
                Height = height,
                Left = col * (width + spacing),
                Top = row * (height + spacing)
            };

           

            btn.Click += (sender, e) =>
            {

                if (IsWinner())
                {
                    MessageBox.Show("You win!");
                    return;
                }

                if (btn.Tag.ToString() == "*")
                {
                    ShowAllBomb();
                    return;
                }

                if (btn.Tag.ToString() == "0")
                {
                    Checked(row, col);

                    if (IsWinner())
                    {
                        MessageBox.Show(" you win !!");
                        return;
                    }
                }

                ShowColor(buttons[row, col]);
                ShowNubers(buttons[row, col]);
            };

            btn.MouseDown += (sender, e) =>
            {

                if (IsWinner())
                {
                    MessageBox.Show("You win!");
                    return;
                }

                if (FlagNumber == 0)
                {
                    return;
                }

                if (e.Button == MouseButtons.Right)
                {
                    if (btn.Text == "🚩")
                    {
                        btn.Text = "";
                        FlagNumber++;
                        lebFlagNumber.Text = FlagNumber.ToString();
                    }
                    else
                    {
                        btn.Text = "🚩";
                        FlagNumber--;
                        lebFlagNumber.Text = FlagNumber.ToString();
                    }
                }
            };

            return btn;
        }



        private void ClearPanel()
        {
            buttonPanel.Controls.Clear();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }



        private void timer1_Tick(object sender, EventArgs e)
        {

            lebTimer.Text = counter.ToString();
            if (counter == 0) 
            {
                timer1.Enabled = false;
                MessageBox.Show("Time Is 0 :( ");
                return;
            }
            counter--;
           
        }

      

        private void button1_Click(object sender, EventArgs e)
        {
            ReStart();
        }

        private void lebTimer_Click(object sender, EventArgs e)
        {

        }
    }


}

