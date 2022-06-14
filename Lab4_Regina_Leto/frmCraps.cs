using System;
using System.Windows.Forms;

namespace Lab4_Regina_Leto
{
    public partial class frmCraps : Form
    {
        /* ‘Lab 4
‘EGR 1400 - Winter 2021
‘Regina Leto
‘I fully understand the following statement.
‘OU PLAGIARISM POLICY
‘All members of the academic community at Oakland are expected to practice and uphold ‘standards
of academic integrity and honesty. An instructor is expected to inform and instruct ‘students about
the procedures and standards of research and documentation required of students ‘in fulfilling
course work. A student is expected to follow such instructions and be sure the rules ‘and procedures
are understood in order to avoid inadvertent misrepresentation of his work. ‘Students must assume
that individual (unaided) work on exams and lab reports and documentation ‘of sources is expected
unless the instructor specifically says that is not necessary.
‘The following definitions are some examples of academic dishonesty:
 ‘Plagiarizing from work of others. Plagiarism is using someone else's work or ideas without
‘giving the other person credit; by doing this, a student is, in effect, claiming credit for
‘someone else's thinking. Whether the student has read or heard the information he/she uses,
‘the student must document the source of information. When dealing with written sources,
‘a clear distinction would be made between quotations (which reproduce information from
‘the source word-for-word within quotation marks) and paraphrases (which digest the
‘source information and produce it in the student's own words). Both direct quotations and
‘paraphrases must be documented. Just because a student rephrases, condenses or selects
‘from another person's work, the ideas are still the other person's, and failure to give ‘credit
constitutes misrepresentation of the student's actual work and plagiarism of ‘another's ideas.
Naturally, buying a paper and handing it in as one's own work is ‘plagiarism.
 ‘Cheating on lab reports falsifying data or submitting data not based on student's own work.
*/

        //random nums and total will show up on the side of the form
        Random randomDice = new Random();

        //form level variables
        int firstDiceRoll;
        int secondDiceRoll;
        int total;
        int points;
        int score = 0;
        int state = 1;
        public void DicePic()
        {
            switch (firstDiceRoll) // will change first dice picture to match first random number
            {
                case 1:
                    picDie1.BackgroundImage = Properties.Resources.die1;
                    break;
                case 2:
                    picDie1.BackgroundImage = Properties.Resources.die2;
                    break;
                case 3:
                    picDie1.BackgroundImage = Properties.Resources.die3;
                    break;
                case 4:
                    picDie1.BackgroundImage = Properties.Resources.die4;
                    break;
                case 5:
                    picDie1.BackgroundImage = Properties.Resources.die5;
                    break;
                case 6:
                    picDie1.BackgroundImage = Properties.Resources.die6;
                    break;
            }
            switch (secondDiceRoll) // will change second dice picture to match second random number
            {
                case 1:
                    picDie2.BackgroundImage = Properties.Resources.die1;
                    break;
                case 2:
                    picDie2.BackgroundImage = Properties.Resources.die2;
                    break;
                case 3:
                    picDie2.BackgroundImage = Properties.Resources.die3;
                    break;
                case 4:
                    picDie2.BackgroundImage = Properties.Resources.die4;
                    break;
                case 5:
                    picDie2.BackgroundImage = Properties.Resources.die5;
                    break;
                case 6:
                    picDie2.BackgroundImage = Properties.Resources.die6;
                    break;
            }
        }
        public void PuckPic() 
        {
            // default settings
            picOffPuck.Visible = true;
            picPuck1.Visible = false;
            picPuck2.Visible = false;
            picPuck3.Visible = false;
            picPuck4.Visible = false;
            picPuck5.Visible = false;
            picPuck6.Visible = false;

            switch (points) // switches through the puck pics and changes based on what number is rolled
            {
                case 2:
                case 3:
                case 7:
                case 11:
                case 12:
                    picOffPuck.Visible = true;
                    break;
                case 4:
                    picPuck1.Visible = true;
                    break;
                case 5:
                    picPuck2.Visible = true;
                    break;
                case 6:
                    picPuck3.Visible = true;
                    break;
                case 8:
                    picPuck4.Visible = true;
                    break;
                case 9:
                    picPuck5.Visible = true;
                    break;
                case 10:
                    picPuck6.Visible = true;
                    break;
            }
           
        }
        public void DiceRoll()
        { // game play method

            if (state == 1) // auto wins and losses will be addressed as such, if any other number rolled, state changes to 2
            {
                if (total == 7 || total == 11) // || = or; works instead of commas
                {
                    lblComments.Text = "Congratulations, automatic win! Click 'Roll' to play again.";
                    score++;
                    lblScoreOutput.Text = score.ToString();

                    Reset();
                }
                else if (total == 2 || total == 3 || total == 12)
                {
                    lblComments.Text = "Sorry, automatic loss. Click 'Roll' to play again!";
                    score--;
                    lblScoreOutput.Text = score.ToString();

                    Reset();
                }
                else // make SecondRoll method and make sure the puck pics stay with corresponding first rolls
                {
                    lblComments.Text = "Keep rolling! Click 'Roll' to roll again";
                    state = 2;
                    points = total;
                    lblPointNum.Text = points.ToString();
                }
            }
            else // anything other than 2, 3, 7, 11, 12
            {
                if (points == total) // if total from second roll equals points from first roll, you win
                {
                    lblComments.Text = "Congratulations, you win! Click 'Roll' to play again.";
                    state = 1;
                    score++;

                    Reset();
                }
                else if (total == 7) // if second roll total = 7, you lose
                {
                    lblComments.Text = "Sorry, you lose. Click 'Roll' to play again!";
                    state = 1;
                    score--;
                    lblScoreOutput.Text = score.ToString();

                    Reset();
                }
                else // will keep going until second roll total = first roll points or 7
                {
                    lblComments.Text = " Keep rolling!";
                    state = 2;
                }
            }
        }
        public void Reset()
        {
            lblFirstDieNum.Text = "";
            lblSecondDieNum.Text = "";
            lblPointNum.Text = "  ";
            picPuck1.Visible = false;
            picPuck2.Visible = false;
            picPuck3.Visible = false;
            picPuck4.Visible = false;
            picPuck5.Visible = false;
            picPuck6.Visible = false;
            picOffPuck.Visible = true;
            picDie1.Visible = false;
            picDie2.Visible = false; 
        }
        public frmCraps()
        {
            InitializeComponent();
        }
        private void btnRoll_Click(object sender, EventArgs e)
        {
            // generates random numbers for the first and second dice and will assign them to the variables associated
            firstDiceRoll = randomDice.Next(1, 7);
            secondDiceRoll = randomDice.Next(1, 7);
            total = firstDiceRoll + secondDiceRoll; // total number on both dice
            lblFirstDieNum.Text = firstDiceRoll.ToString();
            lblSecondDieNum.Text = secondDiceRoll.ToString();
            lblTotalNum.Text = total.ToString();
            
            DicePic();
            DiceRoll();
            PuckPic();

            lblScoreOutput.Text = score.ToString();
        }
        private void frmCraps_Load(object sender, EventArgs e)
        {
            picPuck1.Visible = false;
            picPuck2.Visible = false;
            picPuck3.Visible = false;
            picPuck4.Visible = false;
            picPuck5.Visible = false;
            picPuck6.Visible = false; 
        }

    }
}
