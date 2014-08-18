using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormPrincipal
{
    public partial class Form1 : Form
    {
        string idade;
        string altura;
        string peso;
        double total2 = 0;
        
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            idade = txtIdade.Text ;
            altura = txtAltura.Text;
            peso = txtPeso.Text;

            double idadeD = Convert.ToDouble(idade);
            double alturaD = Convert.ToDouble(altura);
            double pesoD = Convert.ToDouble(peso);
            

            //Fórmula de Harris-Benedict
            //Homens: 66,437 + (5,0033 x altura [cm]) + (13,7516 x peso [kg]) – (6,755 x idade [anos])
            //1.2 = Sedentário (Pouco ou nenhum exercicio + desk job)
            //1.3-1.4 =Pouco ativo (Pouco ativo no dia-a-dia & exercicios lights 1-3 dias por semana)
            //1.5-1.6 = Moderadamente ativo (Moderadamente ativo no dia-a-dia & exercicios em intensidade moderada 3-5 dias por semana)
            //1.7-1.8 = Muito ativo (Estilo de vida que exige esforco bruto & Exercicio intenso ou reliza algum esporte 6-7 dias por semana)
            //1.9-2.0 = Extremamente ativo (Atividade de vida muito intensa ou esportes e trabalho fisico)
            
            double total = (66 + (5 * alturaD) + (13.7 * pesoD) - (6.8 * idadeD));

            switch (Convert.ToString(cbNivel.SelectedIndex)) {
                case "0":
                    total2 = total * 1.2;
                    break;
                case "1" :
                    total2 = total * 1.4;
                    break;
                case "2":
                    total2 = total * 1.6;
                    break;
                case "3":
                    total2 = total * 1.8;
                    break;
                case "4":
                    total2 = total * 1.9;
                    break;
            } //fim switch

            tmb.Text = Convert.ToString("Taxa Metabolica: "+total);
            atividade.Text = Convert.ToString("Taxa Metabolica \n c/ Atividade: " + total2);
        }
    }
}
