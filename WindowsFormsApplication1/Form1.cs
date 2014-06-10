using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        int step = 0;
        int perLine = 3;
        List<Button> allElements = new  List<Button>() ;
        int temp=0;


        void changeFields(int number){
            this.perLine = number;
           
            for (int i = 0; i < 10000; i++){

                foreach (var button in Controls.OfType<Button>()){
                    if (button.Name != "button10" && button.Name != "button11") {
                        this.Controls.Remove(button);
                        button.Dispose();
                    }

                }

            }

            int x=250,y=50;

            const int marginX = 70;
            const int marginY = 50;


            for (int i = 0; i < number*number; i++){
                x += marginX;

                if (i % this.perLine == 0 && i!=0){
                    y += marginY;
                    x = x - this.perLine * marginX;
                }

                Button but = new Button();

                but.Size = new Size(72, 53);
                but.Location = new Point(x, y); ;

                Controls.Add(but);
            }

            this.addAllButtons();
            this.createNewGame();
        }



        private int getButtonByNumner(int number) {
            return this.allElements.Count - number -1;
        }


        private void createNewGame() {
            this.step = 0;
            foreach (var button in Controls.OfType<Button>()) {
                if (button.Name != "button10" && button.Name != "button11"){
                    button.Text = "";
                    button.Enabled = true;
                    label2.Text = "";
                }
            }

            this.temp = 0;

            if ((string)listBox1.SelectedItem == "Player VS Player")
            {
                var result = MessageBox.Show(label2.Text, "PLAYER VS PLAYER",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Question);
/////////////
            }

        }


        private void addAllButtons() {
            foreach (var button in Controls.OfType<Button>()){
                if (button.Name != "button10" && button.Name != "button11") {
                    button.Click += button_Click;
                    this.allElements.Add(button);
                    this.temp++;
                }
            }
        }


       public Form1() {
            InitializeComponent();  
           // Creationg event of clicking for all buttons
            this.changeFields(this.perLine);
        }


       

        private void win(){
            //label2.Text = player;
            if (this.step % 2 == 1) label2.Text = "Winner is Krestiki!!!!!!111";
            else {
                label2.Text = "Winner is Noliki!!!!!!111";
            }

            foreach (var button in Controls.OfType<Button>()) {
                if (button.Name != "button10" && button.Name != "button11") button.Enabled = false ;
            }

            var result = MessageBox.Show(label2.Text, "THE END",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Question);
        }



        private void isWin(){
            List<bool> temp = new List<bool>();

           //// Horizontal ////
                for (int i = 0; i < this.perLine; i++){
                    for (int j = 0; j < this.perLine; j++){
                        if (allElements[this.getButtonByNumner(i * this.perLine)].Text == allElements[this.getButtonByNumner(j + i * this.perLine)].Text
                            && allElements[this.getButtonByNumner(j + i * this.perLine)].Text != "") temp.Add(true);
                    }
                    if (temp.Count== this.perLine)
                    { this.win(); }
                    temp.Clear();

                }


            
                temp.Clear();

                for (int j = 0; j < this.perLine; j++) {
                    for (int i = 0; i < this.perLine; i++) {
                        if (allElements[this.getButtonByNumner(j)].Text == allElements[this.getButtonByNumner(j + i * this.perLine)].Text
                            && allElements[this.getButtonByNumner(j + i * this.perLine)].Text != "") temp.Add(true);
                    }
                    if (temp.Count == this.perLine)
                    { this.win(); }
                    temp.Clear();

                }

            
        }
            
            
            


        private void clickedButton(Button buttonThatSend)
        {
            buttonThatSend.Enabled = false;

            if (this.step % 2 == 0) {
                buttonThatSend.Text = "X";
            }
            else {
                buttonThatSend.Text = "O";
            }
        }

    
        private void button_Click(object sender, System.EventArgs e) {
               Button b =(Button)sender;
               this.clickedButton(b);
               this.step++;
               this.isWin();
            }

        private void button10_Click(object sender, EventArgs e)
        {
            this.createNewGame();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.changeFields(    Convert.ToInt32(textBox1.Text)  );
        }

       

       
    }
}
