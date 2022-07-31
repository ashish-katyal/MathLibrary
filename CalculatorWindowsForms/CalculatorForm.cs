using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathLibrary;
using Newtonsoft.Json;
using System.IO;

namespace CalculatorWindowsForms
{
    public partial class CalculatorForm : Form
    {
        private TableLayoutPanel _tableLayoutPanel;
        private TextBox _textBoxDisplay;
        private MainMenu _mainMenu;

        private string _expressionText;
        private int _bracketCount;
        private bool _expressionEvaluated;

        Dictionary<string, OperatorData> _operators = new Dictionary<string, OperatorData>();
        public CalculatorForm()
        {
            this._tableLayoutPanel = new TableLayoutPanel();
            this._textBoxDisplay = new TextBox();
            this._mainMenu = new MainMenu();
            InitializeComponent();
            string jsonPath = "SymbolPrecedence.json";
            _operators = JsonConvert.DeserializeObject<Dictionary<string, OperatorData>>(File.ReadAllText(jsonPath));


        }

        Button CustomButton(string text)
        {
            Button button = new Button();
            button.Text = text;
            button.Size = new Size(90, 60);
            button.Font = new Font("Arial", 18);
            return button;
        }

        private void CalculatorForm_Load(object sender, EventArgs e)
        {
            this.AutoSize = true;
            this.MaximizeBox = false;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            _expressionEvaluated = false;

            _textBoxDisplay.Dock = DockStyle.Top;
            _textBoxDisplay.Text = "0";
            _expressionText = "0";
            _textBoxDisplay.Font = new Font("Arial", 30);
            _tableLayoutPanel.Location = new Point(0, 200);
            _tableLayoutPanel.AutoSize = true;

            _textBoxDisplay.KeyPress += new KeyPressEventHandler(TextBoxKeyPress);

            MenuItem Edit=_mainMenu.MenuItems.Add("&Edit");
            Edit.MenuItems.Add(new MenuItem("&Copy",new EventHandler(CopyClicked)));
            Edit.MenuItems.Add(new MenuItem("&Paste", new EventHandler(PasteClicked)));

            MenuItem Exit = _mainMenu.MenuItems.Add("&Exit");

            MenuItem Help = _mainMenu.MenuItems.Add("&Help");


            int i = 0;
            int j = 0;

            _tableLayoutPanel.RowCount = 5;
            _tableLayoutPanel.ColumnCount = 8;

            int digit = 1;
            for(i=1;i<4;i++)
            {
                for(j=0;j<3;j++)
                {
                    Button button=CustomButton(digit.ToString());
                    button.Name = "digit";
                    button.Click += new EventHandler(onClick);
                    _tableLayoutPanel.Controls.Add(button, j, i);

                    digit++;
                }
            }

            Button decimalButton = CustomButton(".");
            Button equalsButton = CustomButton("=");
            Button zeroButton = CustomButton("0");
            Button clear = CustomButton("C");
            Button clearEntry=CustomButton("CE");
            Button openBracket = CustomButton("(");
            Button closeBracket = CustomButton(")");
            Button square = CustomButton("x²");
            Button pi = CustomButton("π");

            clear.BackColor = Color.Orange;
            clearEntry.BackColor = Color.Orange;

            decimalButton.Click += new EventHandler(onClick);
            zeroButton.Click += new EventHandler(onClick);
            openBracket.Click += new EventHandler(onClick);
            closeBracket.Click += new EventHandler(onClick);
            equalsButton.Click += new EventHandler(OnEvaluation);
            clear.Click += new EventHandler(OnClear);
            square.Click += new EventHandler(onClick);
            pi.Click += new EventHandler(onClick);

            zeroButton.Name = "digit";
            equalsButton.Name = "equalsTo";
            decimalButton.Name = "decimal";
            openBracket.Name = "openBracket";
            closeBracket.Name = "closeBracket";
            clear.Name = "clear";
            square.Name = "square";
            pi.Name = "pi";

            _tableLayoutPanel.Controls.Add(decimalButton, 0, 4);
            _tableLayoutPanel.Controls.Add(zeroButton, 1, 4);
            _tableLayoutPanel.Controls.Add(equalsButton, 2, 4);
            _tableLayoutPanel.Controls.Add(clearEntry, 5, 0);
            _tableLayoutPanel.Controls.Add(clear, 4, 0);
            _tableLayoutPanel.Controls.Add(openBracket, 0, 0);
            _tableLayoutPanel.Controls.Add(closeBracket, 1, 0);
            _tableLayoutPanel.Controls.Add(square, 3, 0);
            _tableLayoutPanel.Controls.Add(pi, 2, 0);


            i = 1;
            j = 3;

            foreach (var keyValue in _operators)
            {
                string text;
                if (keyValue.Key == "reciprocal")
                    text = "1/x";
                else if (keyValue.Key == "negate")
                    text = "+/-";
                else if (keyValue.Key == "absolute")
                    text = "|x|";
                else if (keyValue.Key == "squareRoot")
                    text = "√x";
                else if (keyValue.Key == "multiply")
                    text = "×";
                else
                    text = keyValue.Value.Symbol;
                Button button = CustomButton(text);
                button.Name = keyValue.Key;
                button.Click += new EventHandler(onClick);
                _tableLayoutPanel.Controls.Add(button, j, i);

                i++;
                if (i == 5)
                {
                    i = 1;
                    j++;
                }
            }


            Controls.Add(_textBoxDisplay);
            Controls.Add(_tableLayoutPanel);
            this.Menu = _mainMenu;
        }


        private void onClick(object sender,EventArgs e)
        {
            Button btn = sender as Button;

            if(_bracketCount>0 && btn.Name=="closeBracket")
                _bracketCount--;
            else if(btn.Name=="openBracket")
                _bracketCount++;

            if(_expressionEvaluated && (btn.Name == "digit" || btn.Name=="decimal" || btn.Name == "pi" || (btn.Name!="percent" && btn.Name!="square" && _operators[btn.Name].OperatorType=="unary")))
            {
                _textBoxDisplay.Text = "0";
                _expressionText = "0";
            }

            _expressionEvaluated = false;
            if(btn.Name=="decimal" || btn.Name == "pi")
                _tableLayoutPanel.Controls.Find("decimal", false)[0].Enabled = false;
            if ( btn.Name!="decimal" && btn.Name != "digit")
            {
                _tableLayoutPanel.Controls.Find("decimal", false)[0].Enabled = true;
            }

            if (_textBoxDisplay.Text == "0" && btn.Name != "percent" && ((_operators.ContainsKey(btn.Name) && _operators[btn.Name].OperatorType == "unary") || btn.Name == "digit" || btn.Name == "openBracket" || btn.Name=="closeBracket" || btn.Name=="pi"))
            {
                _textBoxDisplay.Text = String.Empty;
                _expressionText= String.Empty;
            }

            if (_operators.ContainsKey(btn.Name))
            {
                _expressionText += _operators[btn.Name].Symbol;

                if (btn.Name == "reciprocal")
                    _textBoxDisplay.Text += "1/";
                else if (btn.Name == "negate")
                    _textBoxDisplay.Text += "~";
                else if (btn.Name == "squareRoot")
                    _textBoxDisplay.Text += "√";
                else if (btn.Name == "multiply")
                    _textBoxDisplay.Text += "×";
                else
                    _textBoxDisplay.Text += _operators[btn.Name].Symbol;


                if (btn.Name != "percent" && _operators[btn.Name].OperatorType == "unary")
                {
                    _textBoxDisplay.Text += "(";
                    _expressionText += "(";
                    _bracketCount++;
                }
            }
            else
            {
                if (btn.Name == "square")
                {
                    _textBoxDisplay.Text += "^(2)";
                    _expressionText += "^(2)";
                }
                else
                {
                    _textBoxDisplay.Text += btn.Text;
                    _expressionText += btn.Text;
                }
                    
                
            }
            
        }

        private void OnEvaluation(object sender, EventArgs e)
        {
            
            try
            {
                ExpressionEvaluator result = new ExpressionEvaluator();
                while (_bracketCount > 0)
                {
                    _expressionText += ")";
                    _bracketCount--;
                }

                string ans= result.Evaluate(_expressionText).ToString();

                _textBoxDisplay.Text = ans;
                if (ans[0] == '-')
                    _expressionText = "(0" + ans + ")";
                else
                    _expressionText = ans;
                _tableLayoutPanel.Controls.Find("decimal", false)[0].Enabled = true;

                _expressionEvaluated = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _textBoxDisplay.Text = "0";
                _expressionText= "0";
            }
        }

        private void OnClear(object sender, EventArgs e)
        {
            _textBoxDisplay.Text = "0";
            _expressionText = "0";
            _tableLayoutPanel.Controls.Find("decimal", false)[0].Enabled = true;
        }

        private void TextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void CopyClicked(object sender,EventArgs e)
        {
            Clipboard.SetText(_textBoxDisplay.Text);
        }

        private void PasteClicked(object sender, EventArgs e)
        {
            _textBoxDisplay.Text=Clipboard.GetText();
            _expressionText=_textBoxDisplay.Text;
        }
    }
}
