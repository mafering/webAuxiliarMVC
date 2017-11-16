using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model.DEL
{
    //(ADQUI1)
    public class AuxiliarServicio
    {
        //Declaramos los atributos de la clase
        private string numeroAux;
        private string anioCto;
        private string cedRuc; // Campo PENAS__A de la Tabla adqui1
        private string contratista;
        private string objetoCto;
        private string partida;
        private decimal montoCto;
        private string fechaCto;
        private string plazo;
        private string formaPago;
        
        //Creamos un estado para controlar los errores
        //private int estado_error;

        public string NumeroAux
        {
            get
            {
                return numeroAux;
            }

            set
            {
                numeroAux = value;
            }
        }

        public string AnioCto
        {
            get
            {
                return anioCto;
            }

            set
            {
                anioCto = value;
            }
        }

        public string CedRuc
        {
            get
            {
                return cedRuc;
            }

            set
            {
                cedRuc = value;
            }
        }

        public string Contratista
        {
            get
            {
                return contratista;
            }

            set
            {
                contratista = value;
            }
        }

        public string ObjetoCto
        {
            get
            {
                return objetoCto;
            }

            set
            {
                objetoCto = value;
            }
        }

        public string Partida
        {
            get
            {
                return partida;
            }

            set
            {
                partida = value;
            }
        }

        public decimal MontoCto
        {
            get
            {
                return montoCto;
            }

            set
            {
                montoCto = value;
            }
        }

        public string FechaCto
        {
            get
            {
                return fechaCto;
            }

            set
            {
                fechaCto = value;
            }
        }

        public string Plazo
        {
            get
            {
                return plazo;
            }

            set
            {
                plazo = value;
            }
        }
        
        public string FormaPago
        {
            get
            {
                return formaPago;
            }

            set
            {
                formaPago = value;
            }
        }

        //Contructores
        public AuxiliarServicio()
        {

        }

        public AuxiliarServicio(string numeroAux)
        {
            this.NumeroAux = numeroAux;
        }

        public AuxiliarServicio(string numeroAux, string anioCto, string cedRuc, string contratista, string objetoCto,
                                string partida, decimal montoCto, string fechaCto, string plazo, string formaPago)
        {
            this.NumeroAux = numeroAux;
            this.AnioCto = anioCto;
            this.CedRuc = cedRuc;
            this.Contratista = contratista;
            this.ObjetoCto = objetoCto;
            this.Partida = partida;
            this.MontoCto = montoCto;
            this.FechaCto = fechaCto;
            this.Plazo = plazo;
            this.FormaPago = formaPago;
        }

    }

    //(ADQUI2)
    public class AuxiliarServicioDet
    {
        //Declaramos los atributos de la clase
        private string numeroAux;
        private string numeroPla; 
        private string docControl;
        private string docReferencia; //Campo CHEQUE_B de la tabla adqui2 
        private string concepto;
        private string fechaPago;
        private decimal retencionPla; 
        private decimal valorEntregado; 
        private decimal valorPlanilla;
        private decimal valorMulta;
        private decimal valorFinanzas;

        public string NumeroAux
        {
            get
            {
                return numeroAux;
            }

            set
            {
                numeroAux = value;
            }
        }

        public string NumeroPla
        {
            get
            {
                return numeroPla;
            }

            set
            {
                numeroPla = value;
            }
        }

        public string DocControl
        {
            get
            {
                return docControl;
            }

            set
            {
                docControl = value;
            }
        }

        public string DocReferencia
        {
            get
            {
                return docReferencia;
            }

            set
            {
                docReferencia = value;
            }
        }

        public string Concepto
        {
            get
            {
                return concepto;
            }

            set
            {
                concepto = value;
            }
        }

        public string FechaPago
        {
            get
            {
                return fechaPago;
            }

            set
            {
                fechaPago = value;
            }
        }

        public decimal RetencionPla
        {
            get
            {
                return retencionPla;
            }

            set
            {
                retencionPla = value;
            }
        }

        public decimal ValorEntregado
        {
            get
            {
                return valorEntregado;
            }

            set
            {
                valorEntregado = value;
            }
        }

        public decimal ValorPlanilla
        {
            get
            {
                return valorPlanilla;
            }

            set
            {
                valorPlanilla = value;
            }
        }

        public decimal ValorMulta
        {
            get
            {
                return valorMulta;
            }

            set
            {
                valorMulta = value;
            }
        }

        public decimal ValorFinanzas
        {
            get
            {
                return valorFinanzas;
            }

            set
            {
                valorFinanzas = value;
            }
        }

        //Contructores
        public AuxiliarServicioDet()
        {

        }

        public AuxiliarServicioDet(string numeroAux)
        {
            this.NumeroAux = numeroAux;
            //this.NumeroPla = numeroPla;
        }
        public AuxiliarServicioDet(string numeroAux, string numeroPla, string docControl, string docReferencia, 
                                    string concepto, string fechaPago, decimal retencionPla, decimal valorEntregado, 
                                    decimal valorPlanilla, decimal valorMulta, decimal valorFinanzas)
        {
            this.NumeroAux = numeroAux;
            this.NumeroPla = numeroPla;
            this.DocControl = docControl;
            this.DocReferencia = docReferencia;
            this.Concepto = concepto;
            this.FechaPago = fechaPago;
            this.RetencionPla = retencionPla;
            this.ValorEntregado = valorEntregado;
            this.ValorPlanilla = valorPlanilla;
            this.ValorMulta = valorMulta;
            this.ValorFinanzas = valorFinanzas;
        }
    }
}
