using BattleModePlayerVsMonster.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleModePlayerVsMonster
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        GameEntities db = new GameEntities();
        private static int monster = -1;

       // varvar
        private void button4_Click(object sender, EventArgs e)
        {
            monster = 1;
            pictureBox1.BackgroundImage = button4.BackgroundImage;
        }

        private void button5_Click(object sender, EventArgs e)
{
    if (leftMonsters != null)
    {
        for (int i = 0; i <= leftMonsters.Count - 1; i++)
        {
            if ((leftMonsters[i] == 2) || (leftMonsters.Count == 7))
                return;
        }
    }
    leftMonsters.Add(2);

    int local = 0;
    for (int i = 0; i <= 6; i++)
    {
        if (pictBoxs[i].Image == null)
        {
            local = i;
            break;
        }
    }
    for (int i = 0; i <= 6; i++)
    {
        if (i == 6) break;
        else if (pictBoxs[i].Image != null)
        {
            pictBoxs[local].Image = button5.BackgroundImage;
            break;
        }

        else
        {
            pictBoxs[i].Image = button5.BackgroundImage;
            break;
        }

    }
}

private void button6_Click(object sender, EventArgs e)
{
    if (leftMonsters != null)
    {
        for (int i = 0; i <= leftMonsters.Count - 1; i++)
        {
            if ((leftMonsters[i] == 3) || (leftMonsters.Count == 7))
                return;
        }
    }
    leftMonsters.Add(3);

    int local = 0;
    for (int i = 0; i <= 6; i++)
    {
        if (pictBoxs[i].Image == null)
        {
            local = i;
            break;
        }
    }
    for (int i = 0; i <= 6; i++)
    {
        if (i == 6) break;
        else if (pictBoxs[i].Image != null)
        {
            pictBoxs[local].Image = button6.BackgroundImage;
            break;
        }

        else
        {
            pictBoxs[i].Image = button6.BackgroundImage;
            break;
        }

    }

}

private void button7_Click(object sender, EventArgs e)
{
    if (leftMonsters != null)
    {
        for (int i = 0; i <= leftMonsters.Count - 1; i++)
        {
            if ((leftMonsters[i] == 4) || (leftMonsters.Count == 7))
                return;
        }
    }
    leftMonsters.Add(4);

    int local = 0;
    for (int i = 0; i <= 6; i++)
    {
        if (leftBoxs[i].Image == null)
        {
            local = i;
            break;
        }
    }
    for (int i = 0; i <= 6; i++)
    {
        if (i == 6) break;
        else if (leftBoxs[i].Image != null)
        {
            leftBoxs[local].Image = button7.BackgroundImage;
            break;
        }

        else
        {
            leftBoxs[i].Image = button7.BackgroundImage;
            break;
        }

    }
}

private void button8_Click(object sender, EventArgs e)
{
    if (leftMonsters != null)
    {
        for (int i = 0; i <= leftMonsters.Count - 1; i++)
        {
            if ((leftMonsters[i] == 5) || (leftMonsters.Count == 7))
                return;
        }
    }
    leftMonsters.Add(5);

    int local = 0;
    for (int i = 0; i <= 6; i++)
    {
        if (leftBoxs[i].Image == null)
        {
            local = i;
            break;
        }
    }
    for (int i = 0; i <= 6; i++)
    {
        if (i == 6) break;
        else if (leftBoxs[i].Image != null)
        {
            leftBoxs[local].Image = button8.BackgroundImage;
            break;
        }

        else
        {
            leftBoxs[i].Image = button8.BackgroundImage;
            break;
        }

    }
}

private void button9_Click(object sender, EventArgs e)
{
    if (leftMonsters != null)
    {
        for (int i = 0; i <= leftMonsters.Count - 1; i++)
        {
            if ((leftMonsters[i] == 6) || (leftMonsters.Count == 7))
                return;
        }
    }
    leftMonsters.Add(6);

    int local = 0;
    for (int i = 0; i <= 6; i++)
    {
        if (leftBoxs[i].Image == null)
        {
            local = i;
            break;
        }
    }
    for (int i = 0; i <= 6; i++)
    {
        if (i == 6) break;
        else if (leftBoxs[i].Image != null)
        {
            leftBoxs[local].Image = button9.BackgroundImage;
            break;
        }

        else
        {
            leftBoxs[i].Image = button9.BackgroundImage;
            break;
        }

    }
}

private void button10_Click(object sender, EventArgs e)
{
    int local = 0;
    if (leftMonsters != null)
    {
        for (int i = 0; i <= leftMonsters.Count - 1; i++)
        {
            if ((leftMonsters[i] == 7) || (leftMonsters.Count == 7))
                return;
        }
    }
    leftMonsters.Add(7);


    for (int i = 0; i <= 6; i++)
    {
        if (leftBoxs[i].Image == null)
        {
            local = i;
            break;
        }
    }
    for (int i = 0; i <= 6; i++)
    {
        if (i == 6) break;
        else if (leftBoxs[i].Image != null)
        {
            leftBoxs[local].Image = button10.BackgroundImage;
            break;
        }

        else
        {
            leftBoxs[i].Image = button10.BackgroundImage;
            break;
        }

    }
}

    }
}
