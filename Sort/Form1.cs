using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sort
{
    public partial class Form1 : Form
    {
    
        public Form1()
        {
            InitializeComponent();

            init_form();

           
        }
        bool is_sorted;
        List<ListItem> elements;
        List<FormListItem> form_elements;
        

        public void init_elements()
        {
            elements = new List<ListItem>();
            elements.Add(new ListItem(Properties.Resources.Покемон_Иви, "Иви" ));
            elements.Add(new ListItem(Properties.Resources.Vaporeon1,  "Вапореон"));
            elements.Add(new ListItem(Properties.Resources.Sylveon, "Сильвеон"));
            elements.Add(new ListItem(Properties.Resources.Umbreon, "Умбреон"));
            elements.Add(new ListItem(Properties.Resources._136Flareon, "Флареон"));
            elements.Add(new ListItem(Properties.Resources._470_leafeon, "Лифеон"));
            elements.Add(new ListItem(Properties.Resources._471, "Гласеон"));
            elements.Add(new ListItem(Properties.Resources.Espeon, "Эспион"));
            elements.Add(new ListItem(Properties.Resources.Jolteon, "Джолтеон"));
        }


      public void init_form_elements()
        {
            form_elements = new List<FormListItem>();
            form_elements.Add(new FormListItem(pbArray1, tbArray1));
            form_elements.Add(new FormListItem(pbArray2, tbArray2));
            form_elements.Add(new FormListItem(pbArray3, tbArray3));
            form_elements.Add(new FormListItem(pbArray4, tbArray4));
            form_elements.Add(new FormListItem(pbArray5, tbArray5));
            form_elements.Add(new FormListItem(pbArray6, tbArray6));
            form_elements.Add(new FormListItem(pbArray7, tbArray7));
            form_elements.Add(new FormListItem(pbArray8, tbArray8));
            form_elements.Add(new FormListItem(pbArray9, tbArray9));
        }

        public void show_elements()
        {
            for(int i = 0; i < form_elements.Count; i++)
            {
                form_elements[i].Pb.Image = elements[i].Image;
                form_elements[i].Tb.Text = elements[i].Name;
                form_elements[i].Pb.SizeMode = PictureBoxSizeMode.Zoom;
                form_elements[i].Tb.TextAlign = HorizontalAlignment.Center;

            }
        }

        public void init_form()
        {
            init_elements();
            init_form_elements();
            show_elements();
            binary_search_actions(false);
            set_default_colors();

            is_sorted = false;
            btnBinSearch.Enabled = false;
        }

        private List<int> get_indexies()
        {
            List<int> indexies = new List<int>();
            for(int i = 0; i < elements.Count; i++)
            {
                indexies.Add(i);
            }

            return indexies;
        }


        private void mixed_elements()
        {
            List<int> free_indexies = get_indexies();
            Random rnd = new Random();
            for(int i = 0; i < form_elements.Count; i++)
            {
                int elem_index = rnd.Next(0, free_indexies.Count);
                form_elements[i].Pb.Image = elements[free_indexies[elem_index]].Image;
                form_elements[i].Tb.Text = elements[free_indexies[elem_index]].Name;
                form_elements[i].Pb.SizeMode = PictureBoxSizeMode.Zoom;
                form_elements[i].Tb.TextAlign = HorizontalAlignment.Center;

                free_indexies.RemoveAt(elem_index);
            }
            is_sorted = false;
            binary_search_actions(false);
        }

        private void sort_elements()
        {
            QuickSort.quick_sort(elements);
            is_sorted = true;
            binary_search_actions(true);
            show_elements();
        }
        private void btnMixed_Click(object sender, EventArgs e)
        {
            mixed_elements();
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            sort_elements();
           
        }

        private void set_default_colors()
        {
            for(int i = 0; i < form_elements.Count; i++)
            {
                form_elements[i].Tb.BackColor = Color.White;
                
            }
        }


        private void binary_search_actions(bool value)
        {
            btnBinSearch.Enabled = value;
            tbBinarySearch.ReadOnly = !value;
            tbBinarySearch.Text = "";
        }

        private void binary_search(string key)
        {
            int index = BinarySearch.binary_search(elements, key);
            if(index != -1)
            {
                form_elements[index].Tb.BackColor = Color.LightBlue;
            }
            else
            {
                MessageBox.Show("Элемент не найден", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBinSearch_Click(object sender, EventArgs e)
        {
            if (is_sorted)
            {
                tbBinarySearch.ReadOnly = false;
                set_default_colors();
                binary_search(tbBinarySearch.Text);
            }
        }
    }
}
