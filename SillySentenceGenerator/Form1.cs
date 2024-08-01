using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

namespace SillySentenceGenerator
{
    public partial class Form1 : Form
    {
        private Label sentenceLabel;
        private Button generateButton;
        private ListBox logListBox;

        private string[] names = { "Neha", "Lee", "Sam", "Paimon", "Navia", "Aether", "Rui", "Tsukasa", "Toya", "Akito", "KAITO", "Rin", "Len" };
        private string[] verbs = { "buys", "rides", "kicks", "makes", "burns", "hits", "bites", "whips", "kisses", "hugs", "kills", "beats", "dates" };
        private string[] nouns = { "lion", "bicycle", "plane", "dog", "cat", "Neha", "Lee", "Sam", "Paimon", "Navia", "Aether", "Rui", "Tsukasa", "Toya", "Akito", "KAITO", "Rin", "Len" };

        private Random random = new Random();
        private List<string> sentenceLog = new List<string>();

        public Form1()
        {
            InitializeComponent();
            SetupUI();
        }

        private void SetupUI()
        {
            this.Text = "Silly Sentence Generator";
            this.Size = new Size(600, 500);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Set the form icon using the embedded resource
            this.Icon = Properties.Resources.ssg;

            sentenceLabel = new Label
            {
                Location = new Point(20, 20),
                Size = new Size(560, 60),
                Text = "Click the button to generate a silly sentence!",
                Font = new Font("Arial", 16, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize = false
            };
            this.Controls.Add(sentenceLabel);

            generateButton = new Button
            {
                Location = new Point(150, 100),
                Size = new Size(300, 60),
                Text = "Generate New Sentence",
                Font = new Font("Arial", 14, FontStyle.Bold)
            };
            generateButton.Click += GenerateButton_Click;
            this.Controls.Add(generateButton);

            logListBox = new ListBox
            {
                Location = new Point(20, 180),
                Size = new Size(560, 270),
                Font = new Font("Arial", 12)
            };
            this.Controls.Add(logListBox);
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            string newSentence = GenerateSentence();
            sentenceLabel.Text = newSentence;
            sentenceLog.Add(newSentence);
            UpdateLogListBox();
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

        private void UpdateLogListBox()
        {
            logListBox.Items.Clear();
            for (int i = sentenceLog.Count - 1; i >= 0; i--)
            {
                logListBox.Items.Add(sentenceLog[i]);
            }
        }
    }

    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}