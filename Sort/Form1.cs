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
    public partial class btnMixed : Form
    {
        public btnMixed()
        {
            InitializeComponent();

            init_form();
        }
        List<ListItem> elements;
        List<FormListItem> form_elements;
        bool is_sorted;

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
            for(int i =0; i < form_elements.Count; i++)
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

            is_sorted = false;
            btnBinSearch.Enabled = false;
        }
    }
}
