using System;
using Oracle.DataAccess.Client;
using System.Windows.Forms;
using System.Globalization;
using CNDC.DAL;
using CNDC.BLL;
using Controles;

namespace OraDalQuantum
{
    public class OraDalComponenteConfigurador
    {
        #region Singleton
        private static OraDalComponenteConfigurador _intance;
        public static OraDalComponenteConfigurador Instance
        {
            get
            {
                if (_intance == null)
                {
                    _intance = new OraDalComponenteConfigurador();
                }
                return _intance;
            }
        }

        private OraDalComponenteConfigurador()
        {
        }
        #endregion Singleton

        // Función: GetConfiguracionComponente
        // Descripción: Obtiene la configuración del componente deacuerdo a la información de la base de datos
        // Parámetros: 
        //    string form: nombre del formulario en el que se encuentra el componente.
        //    string componente: nombre del componente a validar
        //    string tablaColumna: nombre de la Tabla.Columna de la que se obtiene la información
        // Valor retorno: void 
        // Creador por: JJLA – 22.06.2011
        // Modificado por: 

        public void GetConfiguracionControl(string form, Control control, string nombreCampo)
        {
            string tabla = nombreCampo.Substring(0, nombreCampo.LastIndexOf('.'));
            string campo = nombreCampo.Substring(nombreCampo.LastIndexOf('.') + 1);

            SetControlAtributes(form, control);
            SetAtributesFromDb(tabla, campo, control);
        }

        private void SetAtributesFromDb(string tableName, string columnName, System.Windows.Forms.Control control)
        {
            OracleCommand cmd = Sesion.Instancia.Conexion.CrearCommand();
            cmd.CommandText = 
            @"SELECT DATA_TYPE, DATA_LENGTH, DATA_PRECISION , NULLABLE, DATA_SCALE
            FROM all_tab_columns
            WHERE owner IN (SELECT DB_SCHEMA FROM P_QUANTUM) 
            AND table_name = :pTableName AND column_name = :pColumnName   ";
            cmd.Parameters.Add("pTableName", tableName);
            cmd.Parameters.Add("pColumnName", columnName);

            OracleDataReader odr = cmd.ExecuteReader();
            if (odr.Read())
            {
                string dataType = odr.GetString(0);
                decimal dataLength = odr.GetDecimal(1);
                decimal dataPrecision = -1;
                decimal dataScale = -1;
                string nullable = odr.GetString(3);

                if (odr[2] != DBNull.Value)
                {
                    dataPrecision = odr.GetDecimal(2);
                }

                if (odr[4] != DBNull.Value)
                {
                    dataScale = odr.GetDecimal(4);
                }

                if (control is TextBox)
                {
                    TextBox tb = (TextBox)control;
                    tb.MaxLength = (int)dataLength;
                    switch (dataType)
                    {
                        case "CLOB":
                            tb.MaxLength = int.MaxValue;
                            break;
                        case "NUMBER":
                            tb.MaxLength = 32767;
                            if (tb is CNDCTextBoxNumerico)
                            {
                                CNDCTextBoxNumerico txtNum = (CNDCTextBoxNumerico)tb;
                                if (dataScale == -1)
                                {
                                    txtNum.MaxDigitosEnteros = (int)dataPrecision;
                                }
                                else
                                {
                                    txtNum.MaxDigitosEnteros = (int)dataPrecision - (int)dataScale;
                                }
                                txtNum.MaxDigitosDecimales = (int)dataScale;
                            }
                            break;
                        case "DATE":
                        case "TIMESTAMP(6)":
                            tb.Tag = "dd/mm/yyyy hh:mi:ss";
                            if (tb.Text.Length == 0)
                            {
                                tb.Text = "__/__/____ __:__:__";
                            }

                            tb.MaxLength = tb.Text.Length;
                            break;
                    }
                }

                if (control is Controles.CNDCTextBoxDateTime)
                {
                    Controles.CNDCTextBoxDateTime tb = (Controles.CNDCTextBoxDateTime)control;
                    tb.ValidadorFormatoFecha = new Controles.ValidadorControlFecha((string)(tb.Tag));
                    tb.ValidadorIngresoOnline = new Controles.ValidadorControlFechaParte((string)(tb.Tag));
                    tb.KeyPress += new KeyPressEventHandler(tb_KeyPress);
                    tb.KeyDown += new KeyEventHandler(tb_KeyDown);
                }
                //control.Visible = (visible == 1);
                //control.Enabled = (enabled == 1);

            }
            else
            {
                //control.Visible = false;
                //control.Enabled = false;
            }

            if (odr != null)
            {
                odr.Close();
                odr.Dispose();
            }
            Sesion.Instancia.Conexion.DisposeCommand(cmd);
        }

        void tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                e.Handled = true;
            }
        }

        void tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool isnumber = IsNumberKey(e.KeyChar);
            bool isSpecial = IsDelOrBackspaceOrTabKey(e.KeyChar);
            e.Handled = !isnumber || isSpecial;
        }

        private bool IsNumberKey(char inKey)
        {
            int e = Convert.ToInt32(inKey);

            if (e < (int)Keys.D0 || e > (int)Keys.D9)
            {
                return false;
            }
            return true;
        }

        private bool IsDelOrBackspaceOrTabKey(char inKey)
        {
            int e = Convert.ToInt32(inKey);

            return (inKey == (int)Keys.Delete || inKey == (int)Keys.Back || inKey == (int)Keys.Space);
        }

        private void textBox1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            Controles.CNDCTextBoxDateTime tb = (Controles.CNDCTextBoxDateTime)sender;

            if (tb.Text.Length == tb.MaxLength && tb.SelectedText == "")
            {
                tb.SelectionLength = 1;
            }
        }

        public static void GotFocus_dateTime(Object sender, EventArgs e)
        {
        }

        public static void Validating_DateTime(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Controles.CNDCTextBoxDateTime tb = (Controles.CNDCTextBoxDateTime)sender;
            string errorMsg;
            System.Text.RegularExpressions.Regex rTime = new System.Text.RegularExpressions.Regex(@"[0-2][0-9]\:[0-6][0-9]\:[0-6][0-9]");
            if (tb.Text.Length > 0)
            {
                if (!rTime.IsMatch(tb.Text))
                {
                    MessageBox.Show("Please provide the time in hh:mm:ss format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public static bool ValidDatetime(string datetimeText, out string errorMessage)
        {
            // Confirm that the e-mail address string is not empty.
            errorMessage = "";
            if (datetimeText.Length == 0)
            {
                errorMessage = "La fecha es requerida";
                return false;
            }
            int dia, mes, anno, hora, minutos, segundos;
            dia = 0;
            mes = 0;
            anno = 0;
            hora = 0;
            minutos = 0;
            segundos = 0;

            return true;

            //// Confirm that there is an "@" and a "." in the e-mail address, and in the correct order.
            //if (emailAddress.IndexOf("@") > -1)
            //{
            //    if (emailAddress.IndexOf(".", emailAddress.IndexOf("@")) > emailAddress.IndexOf("@"))
            //    {
            //        errorMessage = "";
            //        return true;
            //    }
            //}
        }

        public static void OnKeyPress_DateTime(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            string dateSeparator = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.DateSeparator ;
            string timeSeparator = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.TimeSeparator ;
            string space = " ";

            string keyInput = e.KeyChar.ToString();
            if (Char.IsDigit(e.KeyChar))
            {
                // Digits are OK
            }
            else if (keyInput.Equals(dateSeparator) || keyInput.Equals(timeSeparator) || keyInput.Equals(space))
            {
                // Decimal separator is OK
            }
            //else if (e.KeyChar == '\b')
            //{
            //    // Backspace key is OK
            //}
            //    else if ((ModifierKeys & (Keys.Control | Keys.Alt)) != 0)
            //    {
            //     // Let the edit control handle control and alt key combinations
            //    }
            else
            {
                // Swallow this invalid key and beep
                e.Handled = true;
                //    MessageBeep();
            }
        }

        private void SetControlAtributes(string form, System.Windows.Forms.Control control)
        {
            OracleCommand cmd = Sesion.Instancia.Conexion.CrearCommand();
            cmd.CommandText =
            @"SELECT  visible , editable
            FROM p_gf_control_rol
            WHERE NUM_ROL IN
                ( SELECT NUM_ROL FROM vmt_roles_usuarios WHERE login = user
                ) 
            AND COD_CONTROL IN
                (    
                    SELECT COD_CONTROL
                    FROM p_gf_ui_control
                    WHERE cod_padre_control =
                        (
                                SELECT cod_padre_control 
                        FROM p_gf_ui_control
                        WHERE nombre_control = upper (:pnombreForm)                                            
                        )
                        AND nombre_control = upper (:pnombreComponente)       
                )";
            cmd.Parameters.Add("pnombreForm", form);
            cmd.Parameters.Add("pnombreComponente", control.Name);

            OracleDataReader odr = cmd.ExecuteReader();
            if (odr.Read())
            {
                int visible = odr.GetInt16(0);
                int enabled = odr.GetInt16(1);
                control.Visible = (visible == 1);
                control.Enabled = (enabled == 1);
            }
            else
            {
                //control.Visible = true;
                //control.Enabled = true;
            }

            if (odr != null)
            {
                odr.Close();
                odr.Dispose();
            }
            Sesion.Instancia.Conexion.DisposeCommand(cmd);
        }
    }
}
