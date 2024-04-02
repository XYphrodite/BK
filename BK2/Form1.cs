namespace BK2;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        Counter.Count();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        var outs = Counter.Get(textBoxG.Text, textBoxP.Text);
        out1.Text = outs[0];
        out2.Text = outs[1];
        out3.Text = outs[2];
        out4.Text = outs[3];
        out5.Text = outs[4];
    }
}
