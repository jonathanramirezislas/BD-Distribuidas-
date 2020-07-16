using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BDDPROYECTO
{
    public partial class FormBBD : Form
    {
        //para las condiciones
        string NCTALU_ALU = "";
        string Nombre_alu = "";
        string AP_alumno = "";
        string AM_alumno = "";
        string Domicilio = "";
        string Telefono = "";
        string CVECARRERA_ALU = "";
        string Semestre = "";
        string Promedio = "";

        string CVECARRERA_CARRERA = "";
        string NomCarrera = "";
        string AñoIniciocarrera = "";

        string CVEMaestro_Maestro = "";
        string NombreMaestro = "";
        string AP_Maestro = "";
        string AM_Maestro = "";
        string GradoMaestro = "";

        string CVEMateria_Materia = "";
        string NombreMateria = "";
        string CreditosMateria = "";

        string CTRALU_CALIFICA = "";
        string CVEMaestro_Califica = "";
        string CVEMateria_Calififca = "";
        string Calificacion = "";
        string Oportunidad = "";




        //fila para matriz temporal
        int filadematriz = 0;
        //para activar localidades
        bool actL1 = true;
        bool actL2 = true;
        bool actL3 = true;
        bool actL4 = true;
        bool actL5 = true;
        bool actL6 = true; bool actL8 = true;
        bool actL7 = true; bool actL9 = true;
        //para saber que localidades buscar
        bool BUSCAR_Alu1a = false; bool BUSCAR_Alu1b = false;
        bool BUSCAR_Alu2a = false; bool BUSCAR_Alu2b = false;
        bool Buscar_alumno=false; bool Buscar_carrera = false;
        bool Buscar_Materia=false; bool Buscar_Maestro = false;
        bool Buscar_Califica=false;
        //para saber que se encontro todos los resultados
        int checador_tablas_A_BUSCAR = 0;
        int checador_tablas_ENCONTRADAS = 0;
        //matriz temporal para las localidades 
        string[,] matrizTemporal = new string[10, 2];
        /// <summary>
        /// localidades
        /// </summary>
        /// tabla catalogo esta en orden 
        string[,] Localidad1 = new string[9, 4] {  { "L1","Alumno1a", "Materia", "Califica" } ,//Localidad 1
                                               { "L2","Alumno1b", "Carrera", "" },//Localidad 2
                                                { "L5","Alumno2b", "Materia", "" },//Localidad5
                                                 { "L3","Alumno2a", "Maestro", "" } ,//Localidad3
                                                  { "L4","Alumno2b", "Maestro", "" } ,//Localidad4
                                                  { "L6","Alumno1a", "Califica", "" } ,//Localidad6
                                                  { "L9","Alumno1b", "Carrera", "" } ,//Localidad9
                                                  { "L7","Materia", "Califica", "" } ,//Localidad7
                                                  { "L8","Alumno2a", "Maestro", "" } //Localidad8
                                                                               };
        string[,] Localidad2 = new string[9, 4] { { "L2","Alumno1b", "Carrera", "" },//Localidad 2
                                                { "L1","Alumno1a", "Materia", "Califica" },//Localidad 1
                                               { "L3","Alumno2a", "Maestro", "" } ,//Localidad3
                                               { "L5","Alumno2b", "Materia", "" },//Localidad5
                                               { "L6","Alumno1a", "Califica", "" } ,//Localidad6
                                                { "L4","Alumno2b", "Maestro", "" } ,//Localidad4
                                                 { "L9","Alumno1b", "Carrera", "" } ,//Localidad9
                                                   { "L7","Materia", "Califica", "" } ,//Localidad7
                                                    { "L8","Alumno2a", "Maestro", "" } //Localidad8
                                                                               };
        string[,] Localidad3 = new string[9, 4] {  { "L3","Alumno2a", "Maestro", "" } ,//Localidad3
                                                { "L2","Alumno1b", "Carrera", "" },//Localidad 2
                                                { "L6","Alumno1a", "Califica", "" } ,//Localidad6
                                                { "L1","Alumno1a", "Materia", "Califica" },//Localidad 1
                                                { "L5","Alumno2b", "Materia", "" },//Localidad5
                                                 { "L4","Alumno2b", "Maestro", "" } ,//Localidad4
                                                 { "L9","Alumno1b", "Carrera", "" } ,//Localidad9
                                                 { "L7","Materia", "Califica", "" } ,//Localidad7
                                                    { "L8","Alumno2a", "Maestro", "" } //Localidad8
                                                                               };
        string[,] Localidad4 = new string[9, 4] { { "L4","Alumno2b", "Maestro", "" } ,//Localidad4
                                               { "L5","Alumno2b", "Materia", "" },//Localidad5
                                                { "L7","Materia", "Califica", "" } ,//Localidad7
                                                { "L1","Alumno1a", "Materia", "Califica" },//Localidad 1
                                                 { "L6","Alumno1a", "Califica", "" } ,//Localidad6
                                                 { "L8","Alumno2a", "Maestro", "" }, //Localidad8
                                                   { "L9","Alumno1b", "Carrera", "" } ,//Localidad9
                                                    { "L2","Alumno1b", "Carrera", "" },//Localidad 2
                                                    { "L3","Alumno2a", "Maestro", "" } //Localidad3
                                                                               };
        string[,] Localidad5 = new string[9, 4] {  {"L5","Alumno2b", "Materia", "" },//Localidad5
                                                   { "L1","Alumno1a", "Materia", "Califica" },//Localidad 1
                                                   { "L4","Alumno2b", "Maestro", "" } ,//Localidad4
                                                   { "L6","Alumno1a", "Califica", "" } ,//Localidad6
                                                   { "L9","Alumno1b", "Carrera", "" } ,//Localidad9
                                                   { "L2","Alumno1b", "Carrera", "" },//Localidad 2
                                                     { "L7","Materia", "Califica", "" } ,//Localidad7
                                                      { "L3","Alumno2a", "Maestro", "" }, //Localidad3
                                                      { "L8","Alumno2a", "Maestro", "" } //Localidad8
                                                                               };
        string[,] Localidad6 = new string[9, 4] { { "L6","Alumno1a", "Califica", "" } ,//Localidad6
                                                       { "L3","Alumno2a", "Maestro", "" }, //Localidad3
                                                       { "L5","Alumno2b", "Materia", "" },//Localidad5
                                                        { "L2","Alumno1b", "Carrera", "" },//Localidad 2
                                                         { "L1","Alumno1a", "Materia", "Califica" },//Localidad 1
                                                         { "L4","Alumno2b", "Maestro", "" } ,//Localidad4
                                                         { "L9","Alumno1b", "Carrera", "" } ,//Localidad9
                                                           { "L7","Materia", "Califica", "" } ,//Localidad7
                                                    { "L8","Alumno2a", "Maestro", "" } //Localidad8
                                                                               };
        string[,] Localidad7 = new string[9, 4] { { "L7","Materia", "Califica", "" } ,//Localidad7
                                                      { "L4","Alumno2b", "Maestro", "" } ,//Localidad4
                                                       { "L8","Alumno2a", "Maestro", "" }, //Localidad8
                                                       { "L5","Alumno2b", "Materia", "" },//Localidad5
                                                       { "L9","Alumno1b", "Carrera", "" } ,//Localidad9
                                                       { "L1","Alumno1a", "Materia", "Califica" },//Localidad 1
                                                       { "L6","Alumno1a", "Califica", "" } ,//Localidad6
                                                        { "L2","Alumno1b", "Carrera", "" },//Localidad 2
                                                        { "L3","Alumno2a", "Maestro", "" } //Localidad3
                                                                               };
        string[,] Localidad8 = new string[9, 4] { { "L8","Alumno2a", "Maestro", "" }, //Localidad8
                                                     { "L7","Materia", "Califica", "" } ,//Localidad7
                                                      { "L9","Alumno1b", "Carrera", "" } ,//Localidad9
                                                      { "L4","Alumno2b", "Maestro", "" } ,//Localidad4
                                                      { "L5","Alumno2b", "Materia", "" },//Localidad5
                                                      { "L1","Alumno1a", "Materia", "Califica" },//Localidad 1
                                                       { "L6","Alumno1a", "Califica", "" } ,//Localidad6
                                                        { "L2","Alumno1b", "Carrera", "" },//Localidad 2
                                                        { "L3","Alumno2a", "Maestro", "" } //Localidad3
                                                                               };
        string[,] Localidad9 = new string[9, 4] {{ "L9","Alumno1b", "Carrera", "" } ,//Localidad9
                                                       { "L5","Alumno2b", "Materia", "" },//Localidad5
                                                       { "L8","Alumno2a", "Maestro", "" }, //Localidad8
                                                       { "L1","Alumno1a", "Materia", "Califica" },//Localidad 1
                                                        { "L4","Alumno2b", "Maestro", "" } ,//Localidad4
                                                        { "L6","Alumno1a", "Califica", "" } ,//Localidad6
                                                        { "L7","Materia", "Califica", "" } ,//Localidad7
                                                         { "L2","Alumno1b", "Carrera", "" },//Localidad 2
                                                        { "L3","Alumno2a", "Maestro", "" } //Localidad3
                                                                          };

        public FormBBD()
        {
            InitializeComponent();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            labelLocalidad_seleccionada.Text = "L3";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            //cambia el numero de localidad
            labelLocalidad_seleccionada.Text = "L9";
        }

        private void buttonLocalidad1_Click(object sender, EventArgs e)
        {
            //cambia el numero de localidad lable
            labelLocalidad_seleccionada.Text = "L1";
            
        }

        private void buttonLocalidad6_Click(object sender, EventArgs e)
        {
            labelLocalidad_seleccionada.Text = "L6";
        }

        private void buttonLocalidad7_Click(object sender, EventArgs e)
        {
            labelLocalidad_seleccionada.Text = "L7";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ///
            if (actL1 == true)
            {
                //fondo de boton rojo de l1
                buttonLocalidad1.BackColor = Color.Red;
                //cambiar la lyeneda del boton activacion
                buttonL1Activate.Text = "Activar";
                //cambiar la varibale booleana de l1
                actL1 = false;
                //cambiar la letra del botno de l1 a rojo
                buttonLocalidad1.ForeColor = Color.Red;

            }
            else
            {
                //cambair el color de fondo del boton l1  azul
                buttonLocalidad1.BackColor = Color.Blue;
                //cambiar la leyenda del boton activacion
                buttonL1Activate.Text = "Desactivar";
                //cambia la variable de la localida l1 a a disponible
                actL1 = true;
                //las letras del bototn de la localidad a azul
                buttonLocalidad1.ForeColor = Color.Blue;
            }
        }

        private void buttonL2Activate_Click(object sender, EventArgs e)
        {
            if (actL2 == true)
            {
                buttonLocalidad2.BackColor = Color.Red;
                buttonL2Activate.Text = "Activar";
                actL2 = false;
                buttonLocalidad2.ForeColor = Color.Red;
            }
            else
            {
                buttonLocalidad2.BackColor = Color.Blue;
                buttonL2Activate.Text = "Desactivar";
                actL2 = true;
                buttonLocalidad2.ForeColor = Color.Blue;
            }
        }

        private void buttonL3Activate_Click(object sender, EventArgs e)
        {
            if (actL3 == true)
            {
                buttonLocalidad3.BackColor = Color.Red;
                buttonL3Activate.Text = "Activar";
                actL3 = false;
                buttonLocalidad3.ForeColor = Color.Red;
            }
            else
            {
                buttonLocalidad3.BackColor = Color.Blue;
                buttonL3Activate.Text = "Desactivar";
                actL3 = true;
                buttonLocalidad3.ForeColor = Color.Blue;
            }
        }

        private void buttonL4Activate_Click(object sender, EventArgs e)
        {
            if (actL4 == true)
            {
                buttonLocalidad4.BackColor = Color.Red;
                buttonL4Activate.Text = "Activar";
                actL4 = false;
                buttonLocalidad4.ForeColor = Color.Red;
            }
            else
            {
                buttonLocalidad4.BackColor = Color.Blue;
                buttonL4Activate.Text = "Desactivar";
                actL4 = true;
                buttonLocalidad4.ForeColor = Color.Blue;
            }
        }

        private void buttonL5Activate_Click(object sender, EventArgs e)
        {
            if (actL5 == true)
            {
                buttonLocalidad5.BackColor = Color.Red;
                buttonL5Activate.Text = "Activar";
                actL5 = false;
                buttonLocalidad5.ForeColor = Color.Red;
            }
            else
            {
                buttonLocalidad5.BackColor = Color.Blue;
                buttonL5Activate.Text = "Desactivar";
                actL5 = true;
                buttonLocalidad5.ForeColor = Color.Blue;
            }
        }

        private void buttonL6Activate_Click(object sender, EventArgs e)
        {
            if (actL6 == true)
            {
                buttonLocalidad6.BackColor = Color.Red;
                buttonL6Activate.Text = "Activar";
                actL6 = false;
                buttonLocalidad6.ForeColor = Color.Red;
            }
            else
            {
                buttonLocalidad6.BackColor = Color.Blue;
                buttonL6Activate.Text = "Desactivar";
                actL6 = true;
                buttonLocalidad6.ForeColor = Color.Blue;

            }
        }

        private void buttonL7Activate_Click(object sender, EventArgs e)
        {
            if (actL7 == true)
            {
                buttonLocalidad7.BackColor = Color.Red;
                buttonL7Activate.Text = "Activar";
                actL7 = false;
                buttonLocalidad7.ForeColor = Color.Red;
            }
            else
            {
                buttonLocalidad7.BackColor = Color.Blue;
                buttonL7Activate.Text = "Desactivar";
                actL7 = true;
                buttonLocalidad7.ForeColor = Color.Blue;
            }

        }

        private void buttonL8Activate_Click(object sender, EventArgs e)
        {
            if (actL8 == true)
            {
                buttonLocalidad8.BackColor = Color.Red;
                buttonL8Activate.Text = "Activar";
                actL8 = false;
                buttonLocalidad8.ForeColor = Color.Red;
            }
            else
            {
                buttonLocalidad8.BackColor = Color.Blue;
                buttonL8Activate.Text = "Desactivar";
                actL8 = true;
                buttonLocalidad8.ForeColor = Color.Blue;
            }
        }

        private void buttonL9Activate_Click(object sender, EventArgs e)
        {
            if (actL9 == true)
            {
                buttonLocalidad9.BackColor = Color.Red;
                buttonL9Activate.Text = "Activar";
                actL9 = false;       
                buttonLocalidad9.ForeColor = Color.Red;
            }
            else
            {
                buttonLocalidad9.BackColor = Color.Blue;
                buttonL9Activate.Text = "Descativar";
               actL9 = true;
                buttonLocalidad9.ForeColor = Color.Blue;

            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxNomAlu.Checked)
            {
                
                comboBoxCampos.Items.Add("Nombre alumno");
            }
            else
            {
               
                comboBoxCampos.Items.Remove("Nombre alumno");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBoxAmAlu_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAmAlu.Checked)
            {
                
                comboBoxCampos.Items.Add("Apelledio M. Alumno");
            }
            else
            {
                
                comboBoxCampos.Items.Remove("Apelledio M. Alumno");

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //label trasparente numero de localidad
            labelLocalidad_seleccionada.BackColor = Color.Transparent;

            //operadores del combox
            comboBoxOperadores.Items.Add("<");
            comboBoxOperadores.Items.Add(">");
            comboBoxOperadores.Items.Add("=<");
            comboBoxOperadores.Items.Add("=>");
            comboBoxOperadores.Items.Add("=");
            comboBoxOperadores.Items.Add("=!");
            comboBoxOperadores.Items.Add("%");
            //que esten activados los cehcbox de inge y lic
            checkBoxIngAlu.Enabled = true;
            checkBoxLICAlu.Enabled = true;
            //localidad por defecto
            labelLocalidad_seleccionada.Text = "L1";

            //dar formato al datgirdview
            DataGridViewTextBoxColumn C1 = new DataGridViewTextBoxColumn();
            C1.HeaderText = "Localidad";
            C1.Width = 150;
            C1.ReadOnly = true;
            DataGridViewTextBoxColumn C2 = new DataGridViewTextBoxColumn();
            C2.HeaderText = "Tabla";
            C2.Width = 150;
            C2.ReadOnly = true;
            dataGridView1.Columns.Add(C1);
            dataGridView1.Columns.Add(C2);
           // dataGridView1.Rows.Add(localidad,tabla); agregar datos 

        }

        private void buttonCONSULTAR_Click(object sender, EventArgs e)
        {
            checador_tablas_A_BUSCAR = 0;
            checador_tablas_ENCONTRADAS = 0;

            //Es cuando no se usaran fragmentos porque no esta activado la condicion de in o lic
            if (!checkBoxIngAlu.Checked && !checkBoxLICAlu.Checked){
                if(checkBoxNoCtrl.Checked || checkBoxNomAlu.Checked || checkBoxApAlumno.Checked || checkBoxAmAlu.Checked || checkBoxDomAlu.Checked ||
                checkBoxTelAlu.Checked){
                    //variables boolenas
                    BUSCAR_Alu1a = true;  
                    BUSCAR_Alu1b = true;
                    //sirve para saber cuantas tabolas debemos buscar 
                    checador_tablas_A_BUSCAR++;
                    checador_tablas_A_BUSCAR++;
                }
                 if(checkBoxCVECarrAlu.Checked || checkBoxSemAlu.Checked || checkBoxProm.Checked || checkBoxTitulo.Checked){
                    BUSCAR_Alu2a = true;  
                    BUSCAR_Alu2b = true;
                    checador_tablas_A_BUSCAR++;
                    checador_tablas_A_BUSCAR++;

                }
               


            }

            

            ///si esta checaod el combox de inge 
                if (checkBoxIngAlu.Checked) {
                //datos personales activados
                if (checkBoxNoCtrl.Checked || checkBoxNomAlu.Checked || checkBoxApAlumno.Checked || checkBoxAmAlu.Checked || checkBoxDomAlu.Checked ||
                checkBoxTelAlu.Checked)
                {
                    //buscar la tabla 1a donde estan contenidos el numero de control nom alu etc
                    BUSCAR_Alu1a = true;
                    //cehcador de  tablas a buscar 
                    checador_tablas_A_BUSCAR++;
                }
                 if (checkBoxCVECarrAlu.Checked || checkBoxSemAlu.Checked || checkBoxProm.Checked || checkBoxTitulo.Checked)
                {
                    BUSCAR_Alu1b = true;
                    checador_tablas_A_BUSCAR++;
                }

            }
            if (checkBoxLICAlu.Checked) {
                if (checkBoxNoCtrl.Checked || checkBoxNomAlu.Checked || checkBoxApAlumno.Checked || checkBoxAmAlu.Checked || checkBoxDomAlu.Checked ||
              checkBoxTelAlu.Checked)
                {
                    BUSCAR_Alu2a = true;
                    checador_tablas_A_BUSCAR++;
                }
                 if (checkBoxCVECarrAlu.Checked || checkBoxSemAlu.Checked || checkBoxProm.Checked || checkBoxTitulo.Checked)
                {
                    BUSCAR_Alu2b = true;
                    checador_tablas_A_BUSCAR++;
                }
            }


            if (checkBox1CVECARRCARR.Checked || checkBoxNomCARR.Checked || checkBoxAñoCarr.Checked) {
                Buscar_carrera = true; checador_tablas_A_BUSCAR++; }
            if (checkBoxCVEMateria.Checked || checkBoxNomMateria.Checked || checkBoxCredMateria.Checked) {
                Buscar_Materia = true; checador_tablas_A_BUSCAR++; }
            if (checkBoxCVEMaest.Checked || checkBoxNomMaestro.Checked || checkBoxAPMaestro.Checked || checkBoxAMMaestro.Checked || checkBoxGradoMa.Checked) {
                Buscar_Maestro = true; checador_tablas_A_BUSCAR++; }
            if (checkBoxNCTRLCalf.Checked || checkBoxCVEMATTECALF.Checked || checkBoxCVEMATTECALF.Checked || checkBoxCalfCALIF.Checked || checkBoxOPOCAL.Checked) {
                Buscar_Califica = true; checador_tablas_A_BUSCAR++; }

          
            //metodo localiddad seleccionada nos regresa una matriz de tabla catalogo de la localidad seleccionada
            Buscar(LocalidadSeleccionada());

            if (checador_tablas_A_BUSCAR==checador_tablas_ENCONTRADAS)
            {

                MessageBox.Show("Si se pudo realizar la consulta");
                //pasar matriz a datagridview
                MOstrardatos();
            }
            else
            {

                MessageBox.Show("No se pudo realizar la consulta");
            }


        }


        public void Buscar(string[,] Localidad)
        {
           

            for (int fila = 0; fila < 9; fila++)
            {

              

                   //localidad 1
                            if(Localidad[fila, 0] == "L1") { 
                    ///si esta activada la localidad l1 podras usar sus tablas
                            if (actL1 == true )
                            {
                        //si esta activada la variable booleana buscar alumno1a
                                if(BUSCAR_Alu1a) {
                            //buscame en la tabla que usaremos para 
                            //mostrar que no este en uso la tabla alu1a
                                if (!Buscartabla("Alumno1a"))   {
                                //agerga a la matris mostrar l1 y la tabla alumno1a
                                    agregaraMatriz("L1", "Alumno1a");
                                //este checador tablas encontradas
                                //se compara con el chedaor tablas a buscar
                                    checador_tablas_ENCONTRADAS++;   }   }

                                if (Buscar_Materia)  {
                                if (!Buscartabla("Materia")) {
                                    agregaraMatriz("L1", "Materia");
                                    checador_tablas_ENCONTRADAS++;
                            }   }

                                if (Buscar_Califica) {
                                if (!Buscartabla("Califica"))
                                {   agregaraMatriz("L1", "Califica");
                                    checador_tablas_ENCONTRADAS++;
                            }  }
 }    }

                            //Localidad 2
                    if (Localidad[fila, 0] == "L2")
                    {
                        if (actL2 == true)
                            {
                                if (BUSCAR_Alu1b) {
                                if (!Buscartabla("Alumno1b"))    {
                                agregaraMatriz("L2", "Alumno1b");
                                checador_tablas_ENCONTRADAS++; }  }

                        if (Buscar_carrera )  {
                                if (!Buscartabla("Carrera")) {
                                    agregaraMatriz("L2", "Carrera");
                                    checador_tablas_ENCONTRADAS++;   } }

    }  }
                   // Localidad 3
                    if (Localidad[fila, 0] == "L3")
                    {
                        if (actL3 == true)
                            {
                                if (BUSCAR_Alu2a)  {
                                    if (!Buscartabla("Alumno2a"))  {
                                    agregaraMatriz("L3", "Alumno2a");
                                    checador_tablas_ENCONTRADAS++; }  }

                        if (Buscar_carrera) {
                                if (!Buscartabla("Carrera")) {
                                    agregaraMatriz("L3", "Carrera");
                                    checador_tablas_ENCONTRADAS++;  }  }
 } }
                    //localidad 4
                    if (Localidad[fila, 0] == "L4")
                        {
                            if (actL4 == true)
                    {
                                if (BUSCAR_Alu2b) {
                                if (!Buscartabla("Alumno2b")) {
                                    agregaraMatriz("L4", "Alumno2b");
                                    checador_tablas_ENCONTRADAS++; } }

                        if (Buscar_Maestro)  {
                                if (!Buscartabla("Maestro")) {
                                    agregaraMatriz("L4", "Maestro");
                                    checador_tablas_ENCONTRADAS++; } }

  } }

                    if (Localidad[fila, 0] == "L5")
                            {
                        if (actL5 == true)
                        {
                            if (BUSCAR_Alu2b) {
                                if (!Buscartabla("Alumno2b")){
                                    agregaraMatriz("L5", "Alumno2b");
                                    checador_tablas_ENCONTRADAS++; } }

                        if (Buscar_Materia) {
                                    if (!Buscartabla("Materia")) {
                                        agregaraMatriz("L5", "Materia");
                                        checador_tablas_ENCONTRADAS++;  }   }
  }}

                    //localidad 6
                    if (Localidad[fila, 0] == "L6")
                    {
                        if (actL6 == true)
                        {
                            if (BUSCAR_Alu1a) {
                                if (!Buscartabla("Alumno1a")) {
                                    agregaraMatriz("L6", "Alumno1a");
                                    checador_tablas_ENCONTRADAS++;} }

                        if (Buscar_Califica) {
                                    if (!Buscartabla("Califica")){
                                        agregaraMatriz("L6", "Califica");
                                        checador_tablas_ENCONTRADAS++; }   }

  }      }


                        ///Localidad 7
                    if (Localidad[fila, 0] == "L7")
                    {
                        if (actL7 == true)   {

                            if (Buscar_Materia) {
                                if (!Buscartabla("Materia")) {
                                    agregaraMatriz("L7", "Materia");
                                    checador_tablas_ENCONTRADAS++; } }

                        if (Buscar_Califica){
                                    if (!Buscartabla("Califica")) {
                                        agregaraMatriz("L7", "Califica");
                                        checador_tablas_ENCONTRADAS++; }   }
  }       }

                    //localidad 8
                    if (Localidad[fila, 0] == "L8") {
                        if (actL8 == true) {

                            if (BUSCAR_Alu2b){
                                if (!Buscartabla("Alumno2b")) {
                                    agregaraMatriz("L8", "Alumno2b");
                                    checador_tablas_ENCONTRADAS++;  }  }

                               if (Buscar_Maestro) {
                                    if (!Buscartabla("Maestro")) {
                                        agregaraMatriz("L8", "Maestro");
                                        checador_tablas_ENCONTRADAS++; } }
 }}

                    //localidad 9
                    if (Localidad[fila, 0] == "L9")
                    {
                        if (actL9 == true)  {

                            if (BUSCAR_Alu1b) {
                                if (!Buscartabla("Alumno1b")) {
                                    agregaraMatriz("L9", "Alumno1b");
                                    checador_tablas_ENCONTRADAS++;}}

                        if (Buscar_carrera) {
                                    if (!Buscartabla("Carrera")){
                                        agregaraMatriz("L9", "Carrera");
                                        checador_tablas_ENCONTRADAS++; } }

                   }  }    



                
            }
        }
        public void MOstrardatos()
        {
            //agrega la matriz  mostrar a l datagridvoew
            for (int fila = 0; fila < 9; fila++)
            {
                if (!string.IsNullOrEmpty(matrizTemporal[fila, 0]))
                {
                    //                               localidad        tabla
                    dataGridView1.Rows.Add(matrizTemporal[fila, 0], matrizTemporal[fila, 1]);
                }
               
            }
        }

        public bool Buscartabla(string tabla)
        {
           //recorre la matriz a mostrar
            bool SeEncontro = false;
            for (int fila = 0; fila < 10; fila++)
            {
                for (int columna = 0; columna < 2; columna++)
                {
                    if (!string.IsNullOrEmpty(tabla))
                    {
                        if (Convert.ToString(matrizTemporal[fila, columna]) == tabla)
                        {
                            SeEncontro = true;
                        }
                    }

                }

            }
            return SeEncontro;
        }

        public int ultimodato()
        {
            
            int rows = matrizTemporal.GetUpperBound(0) - matrizTemporal.GetLowerBound(0) + 1;
            int cols = matrizTemporal.GetUpperBound(1) - matrizTemporal.GetLowerBound(1) + 1;
            int mayor = 0; string aux2 = "";
            int aux = 0;
            int posicion = 0;
            for (int fila = 0; fila < rows; fila++)
            {
                for (int columna = 0; columna < cols; columna++)
                {


                    long number1 = 0;
                    bool canConvert = long.TryParse(matrizTemporal[fila, columna], out number1);


                    if (columna == 0 && canConvert == true)
                    {
                        aux2 = matrizTemporal[fila, columna];
                        aux = Convert.ToInt32(aux2);
                        if (aux > mayor)
                        {

                            mayor = aux;
                            posicion = fila;
                        }
                    }

                }
            }
          
            return posicion;
        }

        public string[,] LocalidadSeleccionada()
        {
            //copia la tabla catalogo que vamos usar a un arreglo  
            string[,] matrizTemporal2 = new string[9, 4];


            switch (labelLocalidad_seleccionada.Text)
            {
                case "L1":
                    Array.Copy(Localidad1, matrizTemporal2, 36);//CANTIDAD DE DATOS EN LA LOCALODAD 36
                    break;
                case "L2":
                    Array.Copy(Localidad2, matrizTemporal2, 36);
                    break;
                case "L3":
                    Array.Copy(Localidad3, matrizTemporal2, 36);
                    break;
                case "L4":
                    Array.Copy(Localidad4, matrizTemporal2, 36);
                    break;
                case "L5":
                    Array.Copy(Localidad5, matrizTemporal2, 36);
                    break;
                case "L6": Array.Copy(Localidad6, matrizTemporal2, 36);
                    break;
                case "L7":
                    Array.Copy(Localidad7, matrizTemporal2, 36);
                    break;
                case "L8":
                    Array.Copy(Localidad8, matrizTemporal2, 36);
                    break;
                case "L9":
                    Array.Copy(Localidad9, matrizTemporal2, 36);
                    break;

            }

            return matrizTemporal2;
        }

        public void agregaraMatriz(string Localidad,string Tabla)
        {
              //agrega la localidad 
            matrizTemporal[filadematriz, 0]=Localidad;
            //agrega la tabla que se usa
            matrizTemporal[filadematriz, 1] = Tabla;
            //aumentar el numeor de renglon de la matrizz
            filadematriz++;
        }

        private void labelLocalidad_seleccionada_Click(object sender, EventArgs e)
        {

        }

        private void buttonLocalidad2_Click(object sender, EventArgs e)
        {
            labelLocalidad_seleccionada.Text = "L2";
        }

        private void buttonLocalidad4_Click(object sender, EventArgs e)
        {
            labelLocalidad_seleccionada.Text = "L4";
        }

        private void buttonLocalidad5_Click(object sender, EventArgs e)
        {
            labelLocalidad_seleccionada.Text = "L5";
        }

        private void buttonLocalidad8_Click(object sender, EventArgs e)
        {
            labelLocalidad_seleccionada.Text = "L8";
        }


        public void limpiar_buscar_localidades()
        {
           BUSCAR_Alu1a = false;  BUSCAR_Alu1b = false;
             BUSCAR_Alu2a = false;  BUSCAR_Alu2b = false;
            Buscar_alumno=false;  Buscar_carrera = false;
             Buscar_Materia= false;  Buscar_Maestro = false;
             Buscar_Califica= false;
        }

        private void checkBoxCVECarrAlu_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCVECarrAlu.Checked)
            {
               
                comboBoxCampos.Items.Add("CVE Carrera(ALU)");
            }
            else
            {
               
                comboBoxCampos.Items.Remove("CVE Carrera(ALU)");
            }
        }

        private void checkBoxTitulo_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTitulo.Checked)
            {
                checkBoxIngAlu.Enabled = false;
                checkBoxLICAlu.Enabled = false;

            }
            else
            {
                checkBoxIngAlu.Enabled = true;
                checkBoxLICAlu.Enabled = true;
            }



        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            //limpiando chec box de alumno
            checkBoxNoCtrl.Checked = false;
            checkBoxNomAlu.Checked = false;
            checkBoxApAlumno.Checked = false;
            checkBoxAmAlu.Checked = false;
            checkBoxDomAlu.Checked = false;
            checkBoxTelAlu.Checked = false;
            checkBoxCVECarrAlu.Checked = false;
            checkBoxSemAlu.Checked = false;
            checkBoxProm.Checked = false;
            checkBoxTitulo.Checked = false;
            checkBoxLICAlu.Checked = false;
            checkBoxIngAlu.Checked = false;
            // descativando objetos de carrera carrera
            checkBox1CVECARRCARR.Checked = false;
            checkBoxNomCARR.Checked = false;
            checkBoxAñoCarr.Checked = false;
            //desactivando objetos de maestro
            checkBoxCVEMaest.Checked = false;
            checkBoxNomMaestro.Checked = false;
            checkBoxAPMaestro.Checked = false;
            checkBoxAMMaestro.Checked = false;
            checkBoxGradoMa.Checked = false;
            //desactivando objetos de materia
            checkBoxCVEMateria.Checked = false;
            checkBoxNomMateria.Checked = false;
            checkBoxCredMateria.Checked = false;
            //descativando objetos de califica
            checkBoxNCTRLCalf.Checked = false;
            checkBoxCVEMAESCALF.Checked = false;
            checkBoxCVEMATTECALF.Checked = false;
            checkBoxCalfCALIF.Checked = false;
            checkBoxOPOCAL.Checked = false;
            //limpiar localidades a buscar
             BUSCAR_Alu1a = false;  BUSCAR_Alu1b = false;
             BUSCAR_Alu2a = false;  BUSCAR_Alu2b = false;
             Buscar_alumno = false;  Buscar_carrera = false;
             Buscar_Materia = false;  Buscar_Maestro = false;
             Buscar_Califica = false;
            //limpiar checadores
             checador_tablas_A_BUSCAR = 0;
             checador_tablas_ENCONTRADAS = 0;
            //limpiar matriz temporal 
            Array.Clear(matrizTemporal, 0, 18);
            //limpar datgridview
            dataGridView1.Rows.Clear();
            //limpiar la condicion
            textBoxCondicion.Text = "";
            //limiar combobox de operadores
            comboBoxOperadores.Text = "";
            //limpar combox =
            comboBoxCampos.Text = "";
        }

       

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox21_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxCALF_CALF_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxNoCtrl_CheckedChanged(object sender, EventArgs e)
        {
            //si se checah el checbox de numero de control se agrega al combox  de campos
            if (checkBoxNoCtrl.Checked)
            {
                comboBoxCampos.Items.Add("NoCtrl Alumno(Alumno)");
            }
            else
            {
                //en caso de que se deseleccione lo eliminara del combobox
                comboBoxCampos.Items.Remove("NoCtrl Alumno(Alumno)");
            }
        }

        private void checkBoxApAlumno_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxApAlumno.Checked)
            {

                comboBoxCampos.Items.Add("Apelledio P. Alumno");
            }
            else
            {

                comboBoxCampos.Items.Remove("Apelledio P. Alumno");

            }

        }

        private void checkBoxDomAlu_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBoxDomAlu.Checked)
            {
     
                comboBoxCampos.Items.Add("Domicilio Alumno");

            }
            else
            {
                
                comboBoxCampos.Items.Remove("Domicilio Alumno");
            }
        }

        private void checkBoxTelAlu_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTelAlu.Checked)
            {
                
                comboBoxCampos.Items.Add("Telefono Alumno");
            }
            else
            {
               
                comboBoxCampos.Items.Remove("Telefono Alumno");
            }
        }

        private void checkBoxSemAlu_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSemAlu.Checked)
            {
               
                comboBoxCampos.Items.Add("Semestre Alumno");
            }
            else
            {
               
                comboBoxCampos.Items.Remove("Semestre Alumno");
            }
        }

        private void checkBoxProm_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxProm.Checked)
            {
              
                comboBoxCampos.Items.Add("Promedio Alumno");
            }
            else
            {
                
                comboBoxCampos.Items.Remove("Promedio Alumno");
            }
        }

        private void checkBox1CVECARRCARR_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1CVECARRCARR.Checked)
            {
                
                comboBoxCampos.Items.Add("CVE Carrera(Carrera)");
            }
            else
            {
                
                comboBoxCampos.Items.Remove("CVE Carrera(Carrera)");
            }
        }

        private void checkBoxNomCARR_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxNomCARR.Checked)
            {
                
                comboBoxCampos.Items.Add("Nombre Carrera");
            }
            else
            {
                
                comboBoxCampos.Items.Remove("Nombre Carrera");
            }
        }

        private void checkBoxAñoCarr_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAñoCarr.Checked)
            {
               
                comboBoxCampos.Items.Add("Año inicio Carrera");
            }
            else
            {
               
                comboBoxCampos.Items.Remove("Año inicio Carrera");
            }
        }

        private void checkBoxCVEMaest_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCVEMaest.Checked)
            {
               
                comboBoxCampos.Items.Add("CVE Maestro(Maestro)");
            }
            else
            {
                
                comboBoxCampos.Items.Remove("CVE Maestro(Maestro)");
            }
        }

        private void checkBoxNomMaestro_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxNomMaestro.Checked)
            {
                
                comboBoxCampos.Items.Add("Nombre del Maestro");
            }
            else
            {
                
                comboBoxCampos.Items.Remove("Nombre del Maestro");
            }
        }

        private void checkBoxAPMaestro_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAPMaestro.Checked)
            {
             
                comboBoxCampos.Items.Add("Apellido P. Maestro");
            }
            else
            {
                
                comboBoxCampos.Items.Remove("Apellido P. Maestro");
            }
        }

        private void checkBoxAMMaestro_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAMMaestro.Checked)
            {
               
                comboBoxCampos.Items.Add("Apellido M. Maestro");
            }
            else
            {
               
                comboBoxCampos.Items.Remove("Apellido M. Maestro");
            }
        }

        private void checkBoxGradoMa_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxGradoMa.Checked)
            {
              
                comboBoxCampos.Items.Add("Grado del Maestro");
            }
            else
            {
                
                comboBoxCampos.Items.Remove("Grado del Maestro");
            }
        }

        private void checkBoxCVEMateria_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCVEMateria.Checked)
            {
                comboBoxCampos.Items.Add("CVE Materia (Materia)");
            }
            else
            {
              
                comboBoxCampos.Items.Remove("CVE Materia (Materia)");
            }
        }

        private void checkBoxNomMateria_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxNomMateria.Checked)
            {
               
                comboBoxCampos.Items.Add("Nombre Materia");
            }
            else
            {
               
                comboBoxCampos.Items.Remove("Nombre Materia");
            }
        }

        private void checkBoxCredMateria_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCredMateria.Checked)
            {
                
                comboBoxCampos.Items.Add("Creditos Materia");
            }
            else
            {
                
                comboBoxCampos.Items.Remove("Creditos Materia");
            }
        }

        private void checkBoxNCTRLCalf_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxNCTRLCalf.Checked)
            {
                comboBoxCampos.Items.Add("NoCtrl Alumno(Califica)");
            }
            else
            {
                comboBoxCampos.Items.Remove("NoCtrl Alumno(Califica)");
            }
        }

        private void checkBoxCVEMATTECALF_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCVEMATTECALF.Checked)
            {
                comboBoxCampos.Items.Add("CVE Materia (Califica)");
            }
            else
            {
                comboBoxCampos.Items.Remove("CVE Materia (Califica)");
            }
        }

        private void checkBoxCVEMAESCALF_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCVEMAESCALF.Checked)
            {
                comboBoxCampos.Items.Add("CVE Maestro(Califica)");
            }
            else
            {
                comboBoxCampos.Items.Remove("CVE Maestro(Califica)");
            }
        }

        private void checkBoxCalfCALIF_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCalfCALIF.Checked)
            {
                comboBoxCampos.Items.Add("Calificacion");
            }
            else
            {
                comboBoxCampos.Items.Remove("Calificacion");
            }
        }

        private void checkBoxOPOCAL_CheckedChanged(object sender, EventArgs e)
        {
            
                 if (checkBoxOPOCAL.Checked)
            {
                comboBoxCampos.Items.Add("Oportunidad");
            }
            else
            {
                comboBoxCampos.Items.Remove("Oportunidad");
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxCampos_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxCampos.Text)
            {
                case "NoCtrl Alumno(Alumno)":
         

                    textBoxCondicion.Text = NCTALU_ALU;

                    break;
                case "Nombre alumno":

                    textBoxCondicion.Text = Nombre_alu;
                   
                    break;
                case "Apelledio P. Alumno":

                    textBoxCondicion.Text = AP_alumno;
                    
                    break;
                case "Apelledio M. Alumno":
                    
                    textBoxCondicion.Text = AM_alumno;
                  
                    break;
                case "Domicilio Alumno":
                 
                    textBoxCondicion.Text = Domicilio;
                    
                    break;
                case "Telefono Alumno":
                    
                    textBoxCondicion.Text = Telefono ;
                  
                    break;
                case "CVE Carrera(ALU)":
                    
                    textBoxCondicion.Text = CVECARRERA_ALU;
                    
                    break;
                case "Semestre Alumno":
                    
                    textBoxCondicion.Text = Semestre;
                    
                    break;
                case "Promedio Alumno":
                     
                    textBoxCondicion.Text = Promedio;
                   
                    break;

                case "CVE Carrera(Carrera)":
                
                    textBoxCondicion.Text = CVECARRERA_CARRERA;
                    
                    break;
                case "Nombre Carrera":
                    
                    textBoxCondicion.Text = NomCarrera;
                    
                    break;
                case "Año inicio Carrera":
                   
                    textBoxCondicion.Text = AñoIniciocarrera;
                    
                    break;

                case "CVE Maestro(Maestro)":
                   
                    textBoxCondicion.Text = CVEMaestro_Maestro;
                    
                    break;
                case "Nombre del Maestro":
                  
                    textBoxCondicion.Text = NombreMaestro;
                   
                    break;
                case "Apellido P. Maestro":
                   
                    textBoxCondicion.Text = AP_Maestro;
                  
                    break;
                case "Apellido M. Maestro":
                    
                    textBoxCondicion.Text = AM_Maestro;
                    
                    break;
                case "Grado del Maestro":
                    
                    textBoxCondicion.Text = GradoMaestro;
                    
                    break;

                case "CVE Materia (Materia)":
                   
                    textBoxCondicion.Text = CVEMateria_Materia;
                    
                    break;
                case "Nombre Materia":
                  
                    textBoxCondicion.Text = NombreMateria;
                    
                    break;
                case "Creditos Materia":
                  
                    textBoxCondicion.Text = CreditosMateria;
                    
                    break;

                case "NoCtrl Alumno(Califica)":
                    
                    textBoxCondicion.Text = CTRALU_CALIFICA;
                    
                    break;
                case "CVE Materia (Califica)":
                
                    textBoxCondicion.Text = CVEMaestro_Califica;
                    
                    break;
                case "CVE Maestro(Califica)":
                 
                    textBoxCondicion.Text = CVEMateria_Calififca;
                    
                    break;
                case "Calificacion":
                  
                    textBoxCondicion.Text = Calificacion;
                   
                    break;
                case "Oportunidad":
                    
                    textBoxCondicion.Text = Oportunidad;
                   
                    break;

            }
        }

        private void checkBoxLICAlu_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxLICAlu.Checked)
            {
                checkBoxTitulo.Enabled = false;
            }
            else
            {
                if (!checkBoxIngAlu.Checked)
                    checkBoxTitulo.Enabled = true;
            }
        }

        private void checkBoxIngAlu_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxIngAlu.Checked)
            {
                checkBoxTitulo.Enabled = false;
            }
            else
            {
                if (!checkBoxLICAlu.Checked)
                    checkBoxTitulo.Enabled = true;
            }
        }

        private void buttonEnterGuardarConsulta_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void buttonEnterGuardarConsulta_Click(object sender, EventArgs e)
        {
            //sio en el comobox esta sleccionado numero de control del alumno d ela tabla alumno
            switch (comboBoxCampos.Text)
            {
                case "NoCtrl Alumno(Alumno)":
                    //variable string Numero de control 
                    NCTALU_ALU = textBoxCondicion.Text;
                    MessageBox.Show("ntc =" + NCTALU_ALU);
                    textBoxCondicion.Text = "";
                    MessageBox.Show("Consulta guardada");

                    break;
                case "Nombre alumno":
                    Nombre_alu = textBoxCondicion.Text;
                    textBoxCondicion.Text = "";
                    MessageBox.Show("Consulta guardada");
                    break;
                case "Apelledio P. Alumno":
                    AP_alumno= textBoxCondicion.Text;
                    textBoxCondicion.Text = "";
                    MessageBox.Show("Consulta guardada");
                    break;
                case "Apelledio M. Alumno":
                    AM_alumno = textBoxCondicion.Text;
                    textBoxCondicion.Text = "";
                    MessageBox.Show("Consulta guardada");
                    break;
                case "Domicilio Alumno":
                    Domicilio=textBoxCondicion.Text;
                    textBoxCondicion.Text = "";
                    MessageBox.Show("Consulta guardada");
                    break;
                case "Telefono Alumno":
                    Telefono = textBoxCondicion.Text;
                    textBoxCondicion.Text = "";
                    MessageBox.Show("Consulta guardada");
                    break;
                case "CVE Carrera(ALU)":
                    CVECARRERA_ALU = textBoxCondicion.Text;
                    textBoxCondicion.Text = "";
                    MessageBox.Show("Consulta guardada");
                    break;
                case "Semestre Alumno":
                    Semestre = textBoxCondicion.Text;
                    textBoxCondicion.Text = "";
                    MessageBox.Show("Consulta guardada");
                    break;
                case "Promedio Alumno":
                    Promedio=textBoxCondicion.Text;
                    textBoxCondicion.Text = "";
                    MessageBox.Show("Consulta guardada");
                    break;

                case "CVE Carrera(Carrera)":
                    CVECARRERA_CARRERA = textBoxCondicion.Text;
                    textBoxCondicion.Text = "";
                    MessageBox.Show("Consulta guardada");
                    break;
                case "Nombre Carrera":
                    NomCarrera = textBoxCondicion.Text;
                    textBoxCondicion.Text = "";
                    MessageBox.Show("Consulta guardada");
                    break;
                case "Año inicio Carrera":
                    AñoIniciocarrera = textBoxCondicion.Text;
                    textBoxCondicion.Text = "";
                    MessageBox.Show("Consulta guardada");
                    break;

                case "CVE Maestro(Maestro)":
                    CVEMaestro_Maestro = textBoxCondicion.Text;
                    textBoxCondicion.Text = "";
                    MessageBox.Show("Consulta guardada");
                    break;
                case "Nombre del Maestro":
                    NombreMaestro = textBoxCondicion.Text;
                    textBoxCondicion.Text = "";
                    MessageBox.Show("Consulta guardada");
                    break;
                case "Apellido P. Maestro":
                    AP_Maestro = textBoxCondicion.Text;
                    textBoxCondicion.Text = "";
                    MessageBox.Show("Consulta guardada");
                    break;
                case "Apellido M. Maestro":
                    AM_Maestro = textBoxCondicion.Text;
                    textBoxCondicion.Text = "";
                    MessageBox.Show("Consulta guardada");
                    break;
                case "Grado del Maestro":
                    GradoMaestro = textBoxCondicion.Text;
                    textBoxCondicion.Text = "";
                    MessageBox.Show("Consulta guardada");
                    break;

                case "CVE Materia (Materia)":
                    CVEMateria_Materia = textBoxCondicion.Text;
                    textBoxCondicion.Text = "";
                    MessageBox.Show("Consulta guardada");
                    break;
                case "Nombre Materia":
                    NombreMateria = textBoxCondicion.Text;
                    textBoxCondicion.Text = "";
                    MessageBox.Show("Consulta guardada");
                    break;
                case "Creditos Materia":
                    CreditosMateria = textBoxCondicion.Text;
                    textBoxCondicion.Text = "";
                    MessageBox.Show("Consulta guardada");
                    break;

                case "NoCtrl Alumno(Califica)":
                    CTRALU_CALIFICA = textBoxCondicion.Text;
                    textBoxCondicion.Text = "";
                    MessageBox.Show("Consulta guardada");
                    break;
                case "CVE Materia (Califica)":
                    CVEMaestro_Califica = textBoxCondicion.Text;
                    textBoxCondicion.Text = "";
                    MessageBox.Show("Consulta guardada");
                    break;
                case "CVE Maestro(Califica)":
                    CVEMateria_Calififca = textBoxCondicion.Text;
                    textBoxCondicion.Text = "";
                    MessageBox.Show("Consulta guardada");
                    break;
                case "Calificacion":
                    Calificacion = textBoxCondicion.Text;
                    textBoxCondicion.Text = "";
                    MessageBox.Show("Consulta guardada");
                    break;
                case "Oportunidad":
                    Oportunidad = textBoxCondicion.Text;
                    textBoxCondicion.Text = "";
                    MessageBox.Show("Consulta guardada");
                    break;

            }

         

        }

        private void textBoxCondicion_TextChanged(object sender, EventArgs e)
        {

        }
    }
}


//if (Localidad[0, 0].Equals("L1") && actL1 == true)
//{

//}
//if (Localidad[0, 0].Equals("L2") && actL2 == true)
//{

//}
//if (Localidad[0, 0].Equals("L3") && actL3 == true)
//{

//}
//if (Localidad[0, 0].Equals("L4") && actL4 == true)
//{

//}
//if (Localidad[0, 0].Equals("L5") && actL5 == true)
//{

//}
//if (Localidad[0, 0].Equals("L6") && actL6 == true)
//{

//}
//if (Localidad[0, 0].Equals("L7") && actL7 == true)
//{

//}
//if (Localidad[0, 0].Equals("L8") && actL8 == true)
//{

//}
//if (Localidad[0, 0].Equals("L9") && actL9 == true)
//{

//}

     //if(BUSCAR_Alu1a==true && Localidad[fila, columna].Equals("Alumno1a"))
     //           if (BUSCAR_Alu1b==true && Localidad[fila, columna].Equals("Alumno1b"))
     //               if (BUSCAR_Alu2a==true && Localidad[fila, columna].Equals("Alumno2a"))
     //                   if (BUSCAR_Alu2b==true && Localidad[fila, columna].Equals("Alumno2b"))
     //                      // if (Buscar_alumno==true && (Localidad[fila, columna].Equals("Alumno1a"))
     //                           if (Buscar_Califica==true && Localidad[fila, columna].Equals("Califica"))
     //                               if (Buscar_carrera==true && Localidad[fila, columna].Equals("Carrera"))
     //                               if (Buscar_Maestro==true && Localidad[fila, columna].Equals("Maestro"))
     //                                   if (Buscar_Materia==true && Localidad[fila, columna].Equals("Materia"))