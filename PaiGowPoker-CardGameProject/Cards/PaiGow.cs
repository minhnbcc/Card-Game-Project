using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using BOLayer;
using MessageBox = System.Windows.MessageBox;

namespace Cards
{
    public partial class PaiGow : Form
    {
        private Deck aDeck;
        private Hand hand1;
        private Hand hand2;
        private Hand hand3;

        public PaiGow()
        {
            InitializeComponent();
        }

        private bool isDealHand1Clicked = false;
        private bool isDealHand2Clicked = false;
        private bool isDealHand3Clicked = false;

        private void PaiGowPoker_Load(object sender, EventArgs e)
        {


            string imgPath = @"images\cardback.gif";

            PictureBox pic = new PictureBox()
            {
                Image = Image.FromFile(imgPath),
                Width = 100,
                Height = 130,
                Left = 100
            };

            Panel1.Controls.Add(pic);

            //aDeck = new Deck();

            //aDeck.Shuffle();
            Panel2.Controls.Clear();

            string imgPath2 = @"images\cardback.gif";

            PictureBox pic2 = new PictureBox()
            {
                Image = Image.FromFile(imgPath2),
                Width = 100,
                Height = 130,
                Left = 100
            };

            Panel2.Controls.Add(pic2);

            Panel3.Controls.Clear();

            string imgPath3 = @"images\cardback.gif";

            PictureBox pic3 = new PictureBox()
            {
                Image = Image.FromFile(imgPath3),
                Width = 100,
                Height = 130,
                Left = 100
            };

            Panel3.Controls.Add(pic3);

            aDeck = new Deck();

            aDeck.Shuffle();
            SetUp();
            lblResult.Visible = false;

        }


        private void SetUp()
        {
            try
            {
                aDeck = new Deck();
                aDeck.Shuffle();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btnHand1_Click(object sender, EventArgs e)
        {
            try
            {
                isDealHand1Clicked = true;
                hand1 = aDeck.DealHand(3);
                ShowHand(Panel1, hand1);
                btnHand1.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btnHand2_Click(object sender, EventArgs e)
        {
            try
            {
                isDealHand2Clicked = true;
                hand2 = aDeck.DealHand(3);
                ShowHand(Panel2, hand2);
                btnHand2.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btnHand3_Click(object sender, EventArgs e)
        {
            try
            {
                isDealHand3Clicked = true;
                hand3 = aDeck.DealHand(3);
                ShowHand(Panel3, hand3);
                btnHand3.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void ShowHand(Panel thePanel, Hand theHand)
        {
            thePanel.Controls.Clear();
            Card aCard;
            PictureBox aPic;

            for (int i = 0; i < theHand.Count; i++)
            {
                aCard = theHand[i];
                string path = @"images\" + aCard.FaceValue.ToString() + aCard.Suit.ToString() + ".jpg";

                aPic = new PictureBox()
                {
                    Image = Image.FromFile(path),
                    Text = aCard.FaceValue.ToString(),
                    Width = 100,
                    Height = 130,
                    Left = 100 * i,
                    Tag = aCard,
                };

                aPic.Click += PictureBox_Click;

                thePanel.Controls.Add(aPic);
            }
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            PictureBox picClicked = (PictureBox)sender;
            int cardPos = Panel1.Controls.IndexOf(picClicked);

            int cardPos2 = Panel2.Controls.IndexOf(picClicked);
            if (cardPos != -1)
            {
                hand1.RemoveCard((Card)picClicked.Tag);
                ShowHand(Panel1, hand1);

            }
            else if (cardPos2 != -1)
            {
                hand2.RemoveCard((Card)picClicked.Tag);
                ShowHand(Panel2, hand2);
            }
            else
            {
                hand3.RemoveCard((Card)picClicked.Tag);
                ShowHand(Panel3, hand3);
            }
        }

        private void btnRedeal_Click(object sender, EventArgs e)
        {
            string imgPath = @"images\cardback.gif";
            Panel1.Controls.Clear();
            PictureBox pic = new PictureBox()
            {
                Image = Image.FromFile(imgPath),
                Width = 100,
                Height = 130,
                Left = 100
            };

            Panel1.Controls.Add(pic);

            //aDeck = new Deck();

            //aDeck.Shuffle();
            Panel2.Controls.Clear();

            string imgPath2 = @"images\cardback.gif";

            PictureBox pic2 = new PictureBox()
            {
                Image = Image.FromFile(imgPath2),
                Width = 100,
                Height = 130,
                Left = 100
            };

            Panel2.Controls.Add(pic2);

            Panel3.Controls.Clear();

            string imgPath3 = @"images\cardback.gif";

            PictureBox pic3 = new PictureBox()
            {
                Image = Image.FromFile(imgPath3),
                Width = 100,
                Height = 130,
                Left = 100
            };

            Panel3.Controls.Add(pic3);

            aDeck = new Deck();

            aDeck.Shuffle();

            btnHand1.Enabled = true;
            btnHand2.Enabled = true;
            btnHand3.Enabled = true;

            lblResult.Text = string.Empty;

            
            SetUp();
        }

        private void PaiGow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure you wish to return Menu", "Exit", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnResult_Click(object sender, EventArgs e)
        {
            
            try
            {
                lblResult.Visible = true;
                if (isDealHand1Clicked && isDealHand2Clicked && isDealHand3Clicked)
                {
                    //lblResult.Text = FaceValue.Eight.ToString();
                    int player1Total = Result(hand1);
                    int player2Total = Result(hand2);
                    int player3Total = Result(hand3);

                    if (player1Total > player2Total && player1Total > player3Total)
                    {
                        lblResult.Text = "Player 1: " + player1Total.ToString() + "\n" + "Player 1 Won!";
                        
                    }
                    else if (player2Total > player1Total && player2Total > player3Total)
                    {
                        lblResult.Text = "Player 2: " + player2Total.ToString() + "\n" + "Player 2 Won!";
                        
                    }
                    else if (player3Total > player1Total && player3Total > player2Total)
                    {
                        lblResult.Text = "Player 3: " + player3Total.ToString() + "\n" + "Player 3 Won!";
                        
                    }
                    else if (player3Total == player1Total && player3Total > player2Total)
                    {
                        lblResult.Text = "Player 2 lose";
                        
                    }
                    else if (player3Total == player2Total && player3Total > player1Total)
                    {
                        lblResult.Text = "Player 1 lose";
                        
                    }
                    else if (player2Total == player1Total && player2Total > player3Total)
                    {
                        lblResult.Text = "Player 3 lose";
                        
                    }
                    else if(player2Total == player1Total && player2Total == player3Total)
                    {
                        lblResult.Text = "Draw!";
                        
                    }
                }
                else
                {
                    MessageBox.Show("Players have to show the hand");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        private int Result(Hand hand)
        {
            Card aCard;
            int total = 0;
            int value = 0;
            for (int i = 0; i < hand.Count; i++)
            {
                aCard = hand[i];
                if (aCard.FaceValue.ToString() == "King" || aCard.FaceValue.ToString() == "Queen" || aCard.FaceValue.ToString() == "Jack" || aCard.FaceValue.ToString() == "Ten")
                {
                    value = 0;
                    total += value;
                }
                else if (aCard.FaceValue.ToString() == "Ace")
                {
                    value = 1;
                    total += value;
                }
                else if (aCard.FaceValue.ToString() == "Two")
                {
                    value = 2;
                    total += value;
                }
                else if (aCard.FaceValue.ToString() == "Three")
                {
                    value = 3;
                    total += value;
                }
                else if (aCard.FaceValue.ToString() == "Four")
                {
                    value = 4;
                    total += value;
                }
                else if (aCard.FaceValue.ToString() == "Five")
                {
                    value = 5;
                    total += value;
                }
                else if (aCard.FaceValue.ToString() == "Six")
                {
                    value = 6;
                    total += value;
                }
                else if (aCard.FaceValue.ToString() == "Seven")
                {
                    value = 7;
                    total += value;
                }
                else if (aCard.FaceValue.ToString() == "Eight")
                {
                    value = 8;
                    total += value;
                }
                else if (aCard.FaceValue.ToString() == "Nine")
                {
                    value = 9;
                    total += value;
                }
                if (total >= 10)
                {
                    total -= 10;
                }
            }
            return total;
        }

       
    }
}
