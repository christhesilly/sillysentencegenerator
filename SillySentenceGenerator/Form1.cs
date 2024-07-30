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
            this.Size = new Size(600, 300);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Set the form icon using the embedded resource
            this.Icon = Properties.Resources.ssg;

            sentenceLabel = new Label
            {
                Location = new Point(20, 20),
                Size = new Size(560, 100),
                Text = "Click the button to generate a silly sentence!",
                Font = new Font("Arial", 16, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize = false
            };
            this.Controls.Add(sentenceLabel);

            generateButton = new Button
            {
                Location = new Point(150, 180),
                Size = new Size(300, 60),
                Text = "Generate New Sentence",
                Font = new Font("Arial", 14, FontStyle.Bold)
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