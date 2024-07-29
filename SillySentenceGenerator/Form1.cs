using System;
using System.Windows.Forms;
using System.Drawing;

namespace SillySentenceGenerator
{
    public partial class Form1 : Form
    {
        private Label sentenceLabel;
        private Button generateButton;

        private string[] names = { "Neha", "Lee", "Sam", "Paimon", "Navia", "Aether", "Rui", "Tsukasa", "Toya", "Akito", "KAITO", "Rin", "Len" };
        private string[] verbs = { "buys", "rides", "kicks", "makes", "burns", "hits", "bites", "whips", "kisses", "hugs", "kills", "beats", "dates" };
        private string[] nouns = { "lion", "bicycle", "plane", "dog", "cat", "Neha", "Lee", "Sam", "Paimon", "Navia", "Aether", "Rui", "Tsukasa", "Toya", "Akito", "KAITO", "Rin", "Len" };

        private Random random = new Random();

        public Form1()
        {
            InitializeComponent();
            SetupUI();
        }

        private void SetupUI()
        {
            this.Text = "Silly Sentence Generator";
            this.Size = new Size(400, 200);
            this.StartPosition = FormStartPosition.CenterScreen;

            sentenceLabel = new Label
            {
                Location = new Point(10, 20),
                Size = new Size(380, 40),
                Text = "Click the button to generate a silly sentence!"
            };
            this.Controls.Add(sentenceLabel);

            generateButton = new Button
            {
                Location = new Point(100, 80),
                Size = new Size(200, 40),
                Text = "Generate New Sentence"
            };
            generateButton.Click += GenerateButton_Click;
            this.Controls.Add(generateButton);
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            sentenceLabel.Text = GenerateSentence();
        }

        private string GenerateSentence()
        {
            string name = Pick(names);
            string verb = Pick(verbs);
            string noun = Pick(nouns);
            return $"{name} {verb} a {noun}.";
        }

        private string Pick(string[] array)
        {
            return array[random.Next(array.Length)];
        }
    }
}

    