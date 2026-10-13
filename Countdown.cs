// Countdown bis zum Essen - small Windows app.
// Build: build.cmd   (uses the C# compiler that ships with Windows)
// Usage: Countdown.exe            -> asks for minutes / time
//        Countdown.exe 37         -> starts 37 minutes right away
//        Countdown.exe 18:30      -> starts countdown until 18:30
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

class CountdownForm : Form
{
    static readonly Color Bg     = Color.FromArgb(24, 24, 30);
    static readonly Color Cyan   = Color.FromArgb(90, 205, 235);
    static readonly Color Yellow = Color.FromArgb(250, 205, 60);
    static readonly Color Gray   = Color.FromArgb(95, 95, 105);
    static readonly Color Green  = Color.FromArgb(110, 220, 120);

    Panel setup;
    NumericUpDown minutesBox;
    TextBox untilBox;
    Button againButton;
    System.Windows.Forms.Timer timer;

    DateTime end;
    int total;
    bool running, done;

    public CountdownForm(string[] args)
    {
        Text = "Bis zum Essen";
        BackColor = Bg;
        ForeColor = Color.White;
        Font = new Font("Segoe UI", 11f);
        ClientSize = new Size(580, 270);
        MinimumSize = new Size(380, 230);
        StartPosition = FormStartPosition.CenterScreen;
        DoubleBuffered = true;
        ResizeRedraw = true;
        KeyPreview = true;

        BuildSetupPanel();

        againButton = MakeButton("Nochmal");
        againButton.Visible = false;
        againButton.Click += delegate { ShowSetup(); };
        Controls.Add(againButton);

        timer = new System.Windows.Forms.Timer();
        timer.Interval = 1000;
        timer.Tick += delegate { Tick(); };

        KeyDown += OnKey;
        Resize += delegate { LayoutControls(); };
        LayoutControls();

        if (args.Length > 0)
        {
            if (args[0].Contains(":") || args[0].Contains(".")) untilBox.Text = args[0];
            else { int m; if (int.TryParse(args[0], out m)) minutesBox.Value = Math.Max(1, Math.Min(999, m)); }
            Shown += delegate { Start(); };
        }
    }

    void BuildSetupPanel()
    {
        setup = new Panel();
        setup.Size = new Size(340, 170);

        var title = new Label();
        title.Text = "Wie lange bis zum Essen?";
        title.ForeColor = Cyan;
        title.Font = new Font("Segoe UI", 14f);
        title.AutoSize = true;
        title.Location = new Point(0, 0);

        var l1 = new Label();
        l1.Text = "Minuten:";
        l1.AutoSize = true;
        l1.Location = new Point(2, 52);

        minutesBox = new NumericUpDown();
        minutesBox.Minimum = 1;
        minutesBox.Maximum = 999;
        minutesBox.Value = 37;
        minutesBox.Width = 80;
        minutesBox.Location = new Point(150, 49);

        var l2 = new Label();
        l2.Text = "oder Uhrzeit:";
        l2.AutoSize = true;
        l2.Location = new Point(2, 90);

        untilBox = new TextBox();
        untilBox.Width = 80;
        untilBox.Location = new Point(150, 87);
        untilBox.TextChanged += delegate { untilBox.BackColor = SystemColors.Window; };

        var hint = new Label();
        hint.Text = "z.B. 18:30";
        hint.ForeColor = Gray;
        hint.AutoSize = true;
        hint.Location = new Point(238, 90);

        var startButton = MakeButton("Start");
        startButton.Location = new Point(0, 128);
        startButton.Click += delegate { Start(); };

        setup.Controls.AddRange(new Control[] { title, l1, minutesBox, l2, untilBox, hint, startButton });
        Controls.Add(setup);
    }

    static Button MakeButton(string text)
    {
        var b = new Button();
        b.Text = text;
        b.Size = new Size(110, 36);
        b.FlatStyle = FlatStyle.Flat;
        b.FlatAppearance.BorderColor = Cyan;
        b.ForeColor = Color.White;
        b.BackColor = Color.FromArgb(40, 40, 50);
        b.Cursor = Cursors.Hand;
        return b;
    }

    void LayoutControls()
    {
        setup.Location = new Point((ClientSize.Width - setup.Width) / 2, (ClientSize.Height - setup.Height) / 2);
        againButton.Location = new Point((ClientSize.Width - againButton.Width) / 2, ClientSize.Height - againButton.Height - 24);
    }

    void OnKey(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter && setup.Visible) { Start(); e.SuppressKeyPress = true; }
        else if (e.KeyCode == Keys.Escape && (running || done)) ShowSetup();
    }

    void Start()
    {
        DateTime now = DateTime.Now;
        string u = untilBox.Text.Trim().Replace('.', ':');
        if (u.Length > 0)
        {
            DateTime t;
            if (!DateTime.TryParseExact(u, new[] { "H:mm", "HH:mm", "H" }, CultureInfo.InvariantCulture, DateTimeStyles.None, out t))
            {
                untilBox.BackColor = Color.FromArgb(255, 200, 200);
                untilBox.Focus();
                return;
            }
            end = now.Date + t.TimeOfDay;
            if (end <= now) end = end.AddDays(1);
        }
        else end = now.AddMinutes((double)minutesBox.Value);

        total = Math.Max(1, (int)Math.Ceiling((end - now).TotalMinutes));
        running = true;
        done = false;
        setup.Visible = false;
        againButton.Visible = false;
        timer.Start();
        Invalidate();
    }

    void ShowSetup()
    {
        timer.Stop();
        running = false;
        done = false;
        againButton.Visible = false;
        setup.Visible = true;
        minutesBox.Focus();
        Invalidate();
    }

    void Tick()
    {
        if ((end - DateTime.Now).TotalSeconds <= 1) Finish();
        else Invalidate();
    }

    void Finish()
    {
        timer.Stop();
        running = false;
        done = true;
        againButton.Visible = true;
        Invalidate();

        // pop the window to the front
        if (WindowState == FormWindowState.Minimized) WindowState = FormWindowState.Normal;
        TopMost = true;
        Activate();
        TopMost = false;

        new Thread(delegate ()
        {
            Console.Beep(880, 400); Console.Beep(880, 400); Console.Beep(1100, 600);
        }) { IsBackground = true }.Start();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        var g = e.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

        if (done)
        {
            using (var f = new Font("Segoe UI", 48f, FontStyle.Bold))
            using (var b = new SolidBrush(Green))
            {
                var fmt = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                g.DrawString("ESSEN!", f, b, new RectangleF(0, 0, ClientSize.Width, ClientSize.Height - 60), fmt);
            }
            return;
        }
        if (!running) return;

        int min = Math.Max(0, (int)Math.Ceiling((end - DateTime.Now).TotalMinutes));
        int gone = Math.Max(0, total - min);
        const int margin = 24;

        using (var f = new Font("Segoe UI", 18f))
        using (var b = new SolidBrush(Cyan))
            g.DrawString(string.Format("Noch {0} {1} bis zum Essen", min, min == 1 ? "Minute" : "Minuten"), f, b, margin, 18);

        using (var f = new Font("Segoe UI", 10f))
        using (var b = new SolidBrush(Gray))
            g.DrawString(string.Format("um {0:HH:mm} Uhr  ·  Esc = abbrechen", end), f, b, margin + 2, 54);

        // bobbles: one big yellow per remaining minute, small gray dot per minute gone
        int n = min + gone;
        if (n == 0) return;
        int top = 88;
        int width = ClientSize.Width - 2 * margin;
        int height = ClientSize.Height - top - margin;
        int d = 22, cell = 0, cols = 1;
        for (; d >= 4; d--)
        {
            cell = d + Math.Max(4, d / 2);
            cols = Math.Max(1, width / cell);
            int rows = (n + cols - 1) / cols;
            if (rows * cell <= height) break;
        }

        using (var yb = new SolidBrush(Yellow))
        using (var gb = new SolidBrush(Gray))
        {
            for (int i = 0; i < n; i++)
            {
                int x = margin + (i % cols) * cell;
                int y = top + (i / cols) * cell;
                if (i < min) g.FillEllipse(yb, x, y, d, d);
                else
                {
                    int s = Math.Max(3, d / 3);
                    g.FillEllipse(gb, x + (d - s) / 2f, y + (d - s) / 2f, s, s);
                }
            }
        }
    }

    [STAThread]
    static void Main(string[] args)
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new CountdownForm(args));
    }
}
