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
        public static int step = 1;
        public static double damage = 0;
        int parityCount = 1;
        int countOfAutodamage = 1;
        int monsterAttack = 0;
        int monsterAverageDamage = 0;
        int monsterDefence = 0;
        int monsterMinDamage = 0;
        int monsterMaxDamage = 0;
        int currentHPOfMonster = 0;
        double monstersRemaning = 0;
        double remainingHPOfMonster = 0;
        

        private units GetUnitById(int id)
        {
            units unit = (from a in db.units
                          where a.idUnit == id
                          select a).Single();
            return unit;
        }

        private void UpdateQuantityOfMonster(int idUnit, double quantity)
        {
            units unit = db.units.Find(idUnit);
            unit.monstersRemainingOnRight = quantity;
            db.Entry(unit).State = EntityState.Modified;
            db.SaveChanges();
        }
        private bool CalculateLuck(int luck)
        {
            Random rand = new Random();
            int local = rand.Next(1, 11);
            if (luck >= local)
                return true;
            return false;
        }

        //private int CalculateChanceOfDoubleDamage(int Morale)
        //{
        //    if (leftLabel.BackColor == Color.Gold)
        //        return 0;
        //    Random rand = new Random();
        //    int local = rand.Next(1, 11);
        //    if (Morale >= local)
        //    {
        //        return 2;
        //    }
        //    return 1;
        //}

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                panel3.Visible = true;
            }
            else
            {
                panel3.Visible = false;
            }
        }

        private void nextStepBtn_Click(object sender, EventArgs e)
        {
            if (step % 17 == 0)
            {
                label14.Text = "";
                label16.Text = "";
            }
            if (playerHP.Value <= 0 || monsterHP.Value <= 0)
            {
                MessageBox.Show("Бой завершен");
                textBox8.Visible = true;
                return;
            }
            Random random;
            monstersRemaning = remainingHPOfMonster / GetUnitById(monster).hp;
            if (monstersRemaning > 1)
                monsterAttack = GetUnitById(monster).attack * (int)Math.Floor(monstersRemaning);
            else
                monsterAttack = GetUnitById(monster).attack ;
            monsterDefence = GetUnitById(monster).defence;
            monsterMaxDamage = GetUnitById(monster).maxDamage.GetValueOrDefault();
            monsterMinDamage = GetUnitById(monster).minDamage.GetValueOrDefault();
            random = new Random();
            monsterAverageDamage = random.Next(monsterMinDamage, monsterMaxDamage + 1);
            //Game battle
            if (parityCount == 1)
            //ход игрока
            {
                //обычная атака
                if (radioButton1.Checked)
                {
                    if (Player.Attack >= monsterDefence)
                        damage = Player.GetAverageDamage() * (1 + (Player.Attack - monsterDefence) * 0.05);
                    else
                        damage = Player.GetAverageDamage() / (1 + (monsterDefence - Player.Attack) * 0.05);
                    remainingHPOfMonster -= damage;
                    label14.Text += "\n" + step + ") Игрок ударил \nна " + Math.Round(damage, 2).ToString() + " урона " + GetUnitById(monster).unitName;
                    monstersRemaning = remainingHPOfMonster / GetUnitById(monster).hp;
                    UpdateQuantityOfMonster(GetUnitById(monster).idUnit, monstersRemaning);
                    label21.Text = remainingHPOfMonster.ToString();
                    textBox8.Visible = false;
                    parityCount = 0;
                    if (monstersRemaning > 0)
                    {
                        monsterHP.Value = (int)Math.Ceiling(remainingHPOfMonster);
                        if (monsterAttack >= Player.Defence)
                            damage = monsterAverageDamage * (1 + (monsterAttack - Player.Defence) * 0.05);
                        else
                            damage = monsterAverageDamage / (1 + (Player.Defence - monsterAttack) * 0.05);
                        Player.HP -= damage;
                        label16.Text += "\n" + step + ") " + GetUnitById(monster).unitName + " ответил \nна " + Math.Round(damage, 2).ToString() + " урона";

                        if (Player.HP <= 0)
                        {
                            playerHP.Value = 0;
                            label16.Text += "\n игрок убит";
                            textBox8.Visible = true;
                        }
                        else
                        {
                            playerHP.Value = (int)Math.Ceiling(Player.HP);
                            Player.HP = playerHP.Value;
                        }
                    }
                    else
                    {
                        label14.Text += "\n " + GetUnitById(monster).unitName + " убит";
                        MessageBox.Show("Бой завершен!");
                        textBox8.Visible = true;
                    }

                }
                //доп. атака
                else if (radioButton2.Checked)
                {
                    double twenteenPercent = playerMP.Maximum * 0.2;
                    if (twenteenPercent > playerMP.Value)
                    {
                        MessageBox.Show("Закончилась мана");
                        return;
                    }
                    playerMP.Value = playerMP.Value - (int)twenteenPercent;
                    Player.MP = playerMP.Value;
                    if (Player.Attack >= monsterDefence)
                        damage = Player.GetAverageDamage() * (1 + (Player.Attack + Player.SpellPower - monsterDefence) * 0.05);
                    else
                        damage = Player.GetAverageDamage() / (1 + (monsterDefence - (Player.Attack + Player.SpellPower)) * 0.05);
                    remainingHPOfMonster -= damage;
                    label14.Text += "\n" + step + ") Игрок ударил \nна " + Math.Round(damage, 2).ToString() + " урона " + GetUnitById(monster).unitName;
                    monstersRemaning = remainingHPOfMonster / GetUnitById(monster).hp;
                    UpdateQuantityOfMonster(GetUnitById(monster).idUnit, monstersRemaning);
                    label21.Text = remainingHPOfMonster.ToString();
                    textBox8.Visible = false;
                    parityCount = 0;
                    if (monstersRemaning > 0)
                    {
                        monsterHP.Value = (int)Math.Ceiling(remainingHPOfMonster);
                        if (monsterAttack >= Player.Defence)
                            damage = monsterAverageDamage * (1 + (monsterAttack - Player.Defence) * 0.05);
                        else
                            damage = monsterAverageDamage / (1 + (Player.Defence - monsterAttack) * 0.05);
                        Player.HP -= damage;
                        label16.Text += "\n" + step + ") " + GetUnitById(monster).unitName + " ответил \nна " + Math.Round(damage, 2).ToString() + " урона";

                        if (Player.HP <= 0)
                        {
                            playerHP.Value = 0;
                            label16.Text += "\n игрок убит";
                            textBox8.Visible = true;
                        }
                        else
                        {
                            playerHP.Value = (int)Math.Ceiling(Player.HP);
                            Player.HP = playerHP.Value;
                        }
                    }
                    else
                    {
                        label14.Text += "\n " + GetUnitById(monster).unitName + " убит";
                        monsterHP.Value = 0;
                        MessageBox.Show("Бой завершен!");
                        textBox8.Visible = true;
                    }
                }
                //автобой
                else if (radioButton3.Checked)
                {
                    double twenteenPercent = playerMP.Maximum * 0.2;
                    if (countOfAutodamage <= 5)
                    {
                        countOfAutodamage++;
                        if (!radioButton1.Checked)
                        {
                            if (checkBox2.Checked && !radioButton1.Checked && !radioButton2.Checked)
                            {
                                if (Player.Attack >= monsterDefence)
                                    damage = Player.GetAverageDamage() * (1 + (Player.Attack + Player.SpellPower - monsterDefence) * 0.05);
                                else
                                    damage = Player.GetAverageDamage() / (1 + (monsterDefence - (Player.Attack + Player.SpellPower)) * 0.05);
                                if (twenteenPercent > playerMP.Value)
                                {
                                    if (checkBox4.Checked && !radioButton1.Checked && !radioButton2.Checked)
                                    {
                                        playerMP.Value = playerMP.Maximum;
                                        Player.MPBottleQuantity = Int32.Parse(textBox2.Text) - 1;
                                        textBox2.Text = Player.MPBottleQuantity.ToString();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Закончилась мана");
                                        return;
                                    }
                                }
                                else
                                    playerMP.Value = playerMP.Value - (int)twenteenPercent;
                                Player.MP = playerMP.Value;
                            }
                            else
                            {
                                if (Player.Attack >= monsterDefence)
                                    damage = Player.GetAverageDamage() * (1 + (Player.Attack - monsterDefence) * 0.05);
                                else
                                    damage = Player.GetAverageDamage() / (1 + (monsterDefence - Player.Attack) * 0.05);
                            }
                        }

                        remainingHPOfMonster -= damage;
                        label14.Text += "\n" + step + ") Игрок ударил \nна " + Math.Round(damage, 2).ToString() + " урона " + GetUnitById(monster).unitName;
                        monstersRemaning = remainingHPOfMonster / GetUnitById(monster).hp;
                        UpdateQuantityOfMonster(GetUnitById(monster).idUnit, monstersRemaning);
                        label21.Text = remainingHPOfMonster.ToString();
                        textBox8.Visible = false;
                        parityCount = 0;
                        if (monstersRemaning > 0)
                        {
                            monsterHP.Value = (int)Math.Ceiling(remainingHPOfMonster);
                            if (monsterAttack >= Player.Defence)
                                damage = monsterAverageDamage * (1 + (monsterAttack - Player.Defence) * 0.05);
                            else
                                damage = monsterAverageDamage / (1 + (Player.Defence - monsterAttack) * 0.05);
                            if (checkBox3.Checked && !radioButton1.Checked && !radioButton2.Checked)
                            {
                                if (damage >= playerHP.Value)
                                {
                                    playerHP.Value = playerHP.Maximum;
                                    Player.HP = playerHP.Value;
                                    Player.HPBottleQuantity = Int32.Parse(textBox1.Text) - 1;
                                    textBox1.Text = Player.HPBottleQuantity.ToString();
                                }
                            }
                            Player.HP -= damage;
                            label16.Text += "\n" + step + ") " + GetUnitById(monster).unitName + " ответил \nна " + Math.Round(damage, 2).ToString() + " урона";

                            if (Player.HP <= 0)
                            {
                                playerHP.Value = 0;
                                Player.HP = playerHP.Value;
                                label16.Text += "\n игрок убит";
                                textBox8.Visible = true;
                            }
                            else
                            {
                                playerHP.Value = (int)Math.Ceiling(Player.HP);
                                Player.HP = playerHP.Value;
                            }
                        }
                        else
                        {
                            label14.Text += "\n " + GetUnitById(monster).unitName + " убит";
                            MessageBox.Show("Бой завершен!");
                            textBox8.Visible = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Автобой запрещен, продолжайте бить обычными ударами, либо завершите бой");
                        return;
                    }
                }
                else
                    return;
            }
            else
            //ход монстра
            {
                double twenteenPercent = playerMP.Maximum * 0.2;
                if (monsterAttack >= Player.Defence)
                    damage = monsterAverageDamage * (1 + (monsterAttack - Player.Defence) * 0.05);
                else
                    damage = monsterAverageDamage / (1 + (Player.Defence - monsterAttack) * 0.05);
                if (damage > playerHP.Value)
                {
                    if (checkBox3.Checked && !radioButton1.Checked && !radioButton2.Checked)
                    {
                        playerHP.Value = playerHP.Maximum;
                        Player.HPBottleQuantity = Int32.Parse(textBox1.Text) - 1;
                        textBox1.Text = Player.HPBottleQuantity.ToString();
                        Player.HP = playerHP.Value;
                    }
                    else
                    {
                        MessageBox.Show("Закончилось здоровье");
                        textBox8.Visible = true;
                        return;
                    }
                }
                Player.HP -= damage;
                label16.Text += "\n" + step + ") " + GetUnitById(monster).unitName + " ударил \nна " + Math.Round(damage, 2).ToString() + " урона ";
                if (Player.HP <= 0)
                {
                    MessageBox.Show("Бой завершен!");
                    textBox8.Visible = true;
                    return;
                }
                playerHP.Value = (int)Math.Ceiling(Player.HP);
                Player.HP = playerHP.Value;
                label21.Text = Player.HP.ToString();
                parityCount = 1;
                if (playerHP.Value > 0)
                {
                    if (checkBox2.Checked && !radioButton1.Checked && !radioButton2.Checked)
                    {
                        if (Player.Attack >= monsterDefence)
                            damage = Player.GetAverageDamage() * (1 + (Player.Attack + Player.SpellPower - monsterDefence) * 0.05);
                        else
                            damage = Player.GetAverageDamage() / (1 + (monsterDefence - (Player.Attack + Player.SpellPower)) * 0.05);
                        if (twenteenPercent > playerMP.Value)
                        {
                            if (checkBox4.Checked && !radioButton1.Checked && !radioButton2.Checked)
                            {
                                playerMP.Value = playerMP.Maximum;
                                Player.MPBottleQuantity = Int32.Parse(textBox2.Text) - 1;
                                textBox2.Text = Player.MPBottleQuantity.ToString();
                            }
                            else
                            {
                                MessageBox.Show("Закончилась мана");
                                return;
                            }
                        }
                        else
                            playerMP.Value = playerMP.Value - (int)twenteenPercent;
                        Player.MP = playerMP.Value;
                    }
                    else
                    {
                        if (Player.Attack >= monsterDefence)
                            damage = Player.GetAverageDamage() * (1 + (Player.Attack - monsterDefence) * 0.05);
                        else
                            damage = Player.GetAverageDamage() / (1 + (monsterDefence - Player.Attack) * 0.05);
                    }
                    if (damage > playerHP.Value)
                    {
                        if (checkBox3.Checked && !radioButton1.Checked && !radioButton2.Checked)
                        {
                            playerHP.Value = playerHP.Maximum;
                            Player.HPBottleQuantity = Int32.Parse(textBox1.Text) - 1;
                            textBox1.Text = Player.HPBottleQuantity.ToString();
                            Player.HP = playerHP.Value;
                        }
                        else
                        {
                            MessageBox.Show("Закончилось здоровье");
                            textBox8.Visible = true;
                            return;
                        }
                    }
                    remainingHPOfMonster -= damage;
                    label14.Text += "\n" + step + ") Игрок ответил \nна " + Math.Round(damage, 2).ToString() + " урона " + GetUnitById(monster).unitName;
                    monstersRemaning = remainingHPOfMonster / GetUnitById(monster).hp;
                    UpdateQuantityOfMonster(GetUnitById(monster).idUnit, monstersRemaning);
                    label21.Text = remainingHPOfMonster.ToString();
                    textBox8.Visible = false;
                    if (monstersRemaning <= 0)
                    {
                        monsterHP.Value = 0;
                        label14.Text += "\n " + GetUnitById(monster).unitName + " убит";
                        textBox8.Visible = true;
                        MessageBox.Show("Бой завершен!");
                    }
                    else
                    {
                        monsterHP.Value = (int)Math.Ceiling(remainingHPOfMonster);
                    }
                }
                else
                {
                    label16.Text += "\nигрок убит";
                    textBox8.Visible = true;
                }
            }
            step++;
        }

        //set stats
        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (textBox7.Text == "")
                return;
            Player.PlayerLevel = Int32.Parse(textBox7.Text);
            int hp_mp = Player.CalculateHPorMP();
            label8.Text = hp_mp.ToString();
            label9.Text = hp_mp.ToString();

            playerHP.Maximum = hp_mp;
            playerHP.Value = hp_mp;
            playerMP.Maximum = hp_mp;
            playerMP.Value = hp_mp;
        }

        

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
                return;
            Player.Defence = Int32.Parse(textBox5.Text);
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (textBox6.Text == "")
                return;
            Player.SpellPower = Int32.Parse(textBox6.Text);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                return;
            Player.HPBottleQuantity = Int32.Parse(textBox1.Text);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
                return;
            Player.MPBottleQuantity = Int32.Parse(textBox2.Text);
        }

       

        //монстры варвара
        private void button4_Click_1(object sender, EventArgs e)
        {
            monster = 1;
            pictureBox1.BackgroundImage = button4.BackgroundImage;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            monster = 2;
            pictureBox1.BackgroundImage = button5.BackgroundImage;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            monster = 3;
            pictureBox1.BackgroundImage = button6.BackgroundImage;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            monster = 4;
            pictureBox1.BackgroundImage = button7.BackgroundImage;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            monster = 5;
            pictureBox1.BackgroundImage = button8.BackgroundImage;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            monster = 6;
            pictureBox1.BackgroundImage = button9.BackgroundImage;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            monster = 7;
            pictureBox1.BackgroundImage = button10.BackgroundImage;
        }

        //монстры паладина
        private void button35_Click(object sender, EventArgs e)
        {
            monster = 8;
            pictureBox1.BackgroundImage = button35.BackgroundImage;
        }

        private void button34_Click(object sender, EventArgs e)
        {
            monster = 9;
            pictureBox1.BackgroundImage = button34.BackgroundImage;
        }

        private void button33_Click(object sender, EventArgs e)
        {
            monster = 10;
            pictureBox1.BackgroundImage = button33.BackgroundImage;
        }

        private void button32_Click(object sender, EventArgs e)
        {
            monster = 11;
            pictureBox1.BackgroundImage = button32.BackgroundImage;
        }

        private void button31_Click(object sender, EventArgs e)
        {
            monster = 12;
            pictureBox1.BackgroundImage = button31.BackgroundImage;
        }

        private void button30_Click(object sender, EventArgs e)
        {
            monster = 13;
            pictureBox1.BackgroundImage = button30.BackgroundImage;
        }

        private void button29_Click(object sender, EventArgs e)
        {
            monster = 14;
            pictureBox1.BackgroundImage = button29.BackgroundImage;
        }

        //монстры мага
        private void button11_Click(object sender, EventArgs e)
        {
            monster = 15;
            pictureBox1.BackgroundImage = button11.BackgroundImage;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            monster = 16;
            pictureBox1.BackgroundImage = button12.BackgroundImage;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            monster = 17;
            pictureBox1.BackgroundImage = button13.BackgroundImage;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            monster = 18;
            pictureBox1.BackgroundImage = button14.BackgroundImage;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            monster = 19;
            pictureBox1.BackgroundImage = button15.BackgroundImage;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            monster = 20;
            pictureBox1.BackgroundImage = button16.BackgroundImage;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            monster = 21;
            pictureBox1.BackgroundImage = button17.BackgroundImage;
        }

        //монстры некроманта
        private void button18_Click(object sender, EventArgs e)
        {
            monster = 22;
            pictureBox1.BackgroundImage = button18.BackgroundImage;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            monster = 23;
            pictureBox1.BackgroundImage = button19.BackgroundImage;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            monster = 24;
            pictureBox1.BackgroundImage = button20.BackgroundImage;
        }

        private void button21_Click(object sender, EventArgs e)
        {
            monster = 25;
            pictureBox1.BackgroundImage = button21.BackgroundImage;
        }

        private void button22_Click(object sender, EventArgs e)
        {
            monster = 26;
            pictureBox1.BackgroundImage = button22.BackgroundImage;
        }

        private void button23_Click(object sender, EventArgs e)
        {
            monster = 27;
            pictureBox1.BackgroundImage = button23.BackgroundImage;
        }

        private void button24_Click(object sender, EventArgs e)
        {
            monster = 28;
            pictureBox1.BackgroundImage = button24.BackgroundImage;
        }


        //монстры разбойницы
        private void button28_Click(object sender, EventArgs e)
        {
            monster = 29;
            pictureBox1.BackgroundImage = button28.BackgroundImage;
        }

        private void button27_Click(object sender, EventArgs e)
        {
            monster = 30;
            pictureBox1.BackgroundImage = button27.BackgroundImage;
        }

        private void button26_Click(object sender, EventArgs e)
        {
            monster = 31;
            pictureBox1.BackgroundImage = button26.BackgroundImage;
        }

        private void button252_Click(object sender, EventArgs e)
        {
            monster = 32;
            pictureBox1.BackgroundImage = button252.BackgroundImage;
        }

        private void button242_Click(object sender, EventArgs e)
        {
            monster = 33;
            pictureBox1.BackgroundImage = button242.BackgroundImage;
        }

        private void button232_Click(object sender, EventArgs e)
        {
            monster = 34;
            pictureBox1.BackgroundImage = button232.BackgroundImage;
        }

        private void button222_Click(object sender, EventArgs e)
        {
            monster = 35;
            pictureBox1.BackgroundImage = button222.BackgroundImage;
        }


        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (pictureBox1.BackgroundImage != null)
            {
                if (textBox8.Text == "")
                    return;
                currentHPOfMonster = GetUnitById(monster).hp;
                remainingHPOfMonster = currentHPOfMonster * Int32.Parse(textBox8.Text);
                monsterHP.Maximum = (int)remainingHPOfMonster;
                monsterHP.Value = (int)Math.Ceiling(remainingHPOfMonster);
                label21.Text = Math.Ceiling(remainingHPOfMonster).ToString();
            }
        }

        private void pictureBox1_BackgroundImageChanged(object sender, EventArgs e)
        {
            Random random;
            monsterAttack = GetUnitById(monster).attack;
            monsterDefence = GetUnitById(monster).defence;
            monsterMaxDamage = GetUnitById(monster).maxDamage.GetValueOrDefault();
            monsterMinDamage = GetUnitById(monster).minDamage.GetValueOrDefault();
            random = new Random();
            monsterAverageDamage = random.Next(monsterMinDamage, monsterMaxDamage + 1);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            int countOfBottles = Int32.Parse(textBox1.Text);
            textBox1.Text = (countOfBottles - 1).ToString();
            int maxHP = playerHP.Maximum;
            Player.HP = maxHP;
            playerHP.Value = maxHP;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.BackgroundImage != null)
            {
                MessageBox.Show(" " + GetUnitById(monster).unitName
                + "\n Defence: " + GetUnitById(monster).defence
                + "\n HP: " + GetUnitById(monster).hp
                + "\n maxDamage: " + GetUnitById(monster).maxDamage
                + "\n minDamage: " + GetUnitById(monster).minDamage
                + "\n Attack: " + GetUnitById(monster).attack
                + "\n averageDamage: " + GetUnitById(monster).averageDamage
                );
            }
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) | (Char.IsPunctuation(e.KeyChar))) return;
            else
                e.Handled = true;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) | (Char.IsPunctuation(e.KeyChar))) return;
            else
                e.Handled = true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) | (Char.IsPunctuation(e.KeyChar))) return;
            else
                e.Handled = true;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) | (Char.IsPunctuation(e.KeyChar))) return;
            else
                e.Handled = true;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) | (Char.IsPunctuation(e.KeyChar))) return;
            else
                e.Handled = true;
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) | (Char.IsPunctuation(e.KeyChar))) return;
            else
                e.Handled = true;
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) | (Char.IsPunctuation(e.KeyChar))) return;
            else
                e.Handled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            monster = -1;
            pictureBox1.BackgroundImage = null;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            int countOfBottles = Int32.Parse(textBox2.Text);
            textBox2.Text = (countOfBottles - 1).ToString();
            int maxMP = playerMP.Maximum;
            Player.MP = maxMP;
            playerMP.Value = maxMP;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            label16.Text = "";
            label14.Text = "";
            textBox8.Text = "";
            textBox8.Visible = true;
            step = 1;
            countOfAutodamage = 1;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
                return;
            Player.Attack = Int32.Parse(textBox3.Text);
        }

        private void textBox3_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) | (Char.IsPunctuation(e.KeyChar))) return;
            else
                e.Handled = true;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
                return;
            Player.AverageDamage = Int32.Parse(textBox4.Text);
        }

        private void textBox4_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) | (Char.IsPunctuation(e.KeyChar))) return;
            else
                e.Handled = true;
        }
    }
}
